using FifthLab.Enums;
using FifthLab.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace FifthLab.Classes
{
    [DataContract]
    public class ResearchTeam : Team, INameAndCopy, IEnumerable, IComparer<ResearchTeam>
    {
        #region Fields

        private string _nameOfStudy;
        private TimeFrame _durationOfResearch;
        private List<Paper> _publications;
        private List<Person> _members;

        #endregion Fields

        #region Constructors

        public ResearchTeam() : base()
        {
            _publications = new List<Paper>();
            _members = new List<Person>();
            _nameOfStudy = default;
            _durationOfResearch = default;
        }

        public ResearchTeam(string name, string nameOfStudy, int registrationNumber, TimeFrame durationOfResearch, List<Paper> publications) : base(name, registrationNumber)
        {
            _members = new List<Person>();
            _nameOfStudy = nameOfStudy;
            _durationOfResearch = durationOfResearch;
            _publications = publications;
        }

        #endregion Constructors

        #region Properties

        [DataMember]
        public string NameOfStudy
        {
            get => _nameOfStudy;
            set => _nameOfStudy = value;
        }

        [DataMember]
        public TimeFrame DurationOfResearch { get => _durationOfResearch; set => _durationOfResearch = value; }

        [DataMember]
        public List<Paper> Publication { get => _publications; set => _publications = value; }

        [DataMember]
        public List<Person> Members { get => _members; set => _members = value; }

        [DataMember]
        public Team Team { get => new Team(name, registryNumber); set { name = value.Name; registryNumber = value.RegistryNumber; } }

        public Paper LastPublication
        {
            get
            {
                if (!(Publication == null || Publication.Count > 0))
                {
                    return Publication.Last();
                }
                return null;
            }
        }

        #endregion Properties

        #region Indexers

        public bool this[TimeFrame durationOfResearch] => DurationOfResearch == durationOfResearch;

        #endregion Indexers

        #region Methods

        public static T DeepCopy<T>(object obj) where T : class
        {
            if (obj is T serialisedObject)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                    try
                    {
                        serializer.WriteObject(ms, serialisedObject);
                        ms.Position = 0;
                        return serializer.ReadObject(ms) as T;
                    }
                    catch (InvalidDataContractException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (SerializationException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        ms.Close();
                    }
                }
            }
            throw new ArgumentException($"I cannot convert { nameof(serialisedObject) } to ResearchTeam");
        }

        public static bool Load(string fileName, ResearchTeam researchTeam)
        {
            string fileLocation = @"D:\";
            string fileFormat = ".txt";

            try
            {
                using (FileStream fstream = File.OpenRead(fileLocation + fileName + fileFormat))
                {
                    byte[] array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);
                    string json = Encoding.Default.GetString(array);

                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
                    ResearchTeam deserializedTeam = new ResearchTeam();
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedTeam.GetType());
                    deserializedTeam = ser.ReadObject(ms) as ResearchTeam;

                    researchTeam.NameOfStudy = deserializedTeam.NameOfStudy;
                    researchTeam.name = deserializedTeam.name;
                    researchTeam.DurationOfResearch = deserializedTeam.DurationOfResearch;
                    researchTeam.RegistryNumber = deserializedTeam.RegistryNumber;
                    researchTeam.Publication = deserializedTeam.Publication;
                    researchTeam.Members = deserializedTeam.Members;

                    ms.Close();
                    fstream.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public static bool Save(string fileName, ResearchTeam saveResearchTeam)
        {
            string fileLocation = @"D:\";
            string fileFormat = ".txt";

            ResearchTeam researchTeam = new ResearchTeam(saveResearchTeam.NameOfStudy, saveResearchTeam.name, saveResearchTeam.RegistryNumber, saveResearchTeam.DurationOfResearch, saveResearchTeam.Publication);
            researchTeam.Members = saveResearchTeam.Members;

            MemoryStream ms = new MemoryStream();
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ResearchTeam));
                ser.WriteObject(ms, researchTeam);
                byte[] json = ms.ToArray();

                var objectToJson = Encoding.UTF8.GetString(json, 0, json.Length);
                FileStream fstream = new FileStream(fileLocation + fileName + fileFormat, FileMode.OpenOrCreate);
                fstream.SetLength(0);
                byte[] array = Encoding.Default.GetBytes(objectToJson);
                fstream.Write(array, 0, array.Length);
                fstream.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                ms.Close();
            }
            return false;
        }

        public static bool operator ==(ResearchTeam researchTeam1, ResearchTeam researchTeam2)
        {
            return researchTeam1.Equals(researchTeam2);
        }

        public static bool operator !=(ResearchTeam researchTeam1, ResearchTeam researchTeam2)
        {
            return !researchTeam1.Equals(researchTeam2);
        }

        public void AddMembers(params Person[] personsList)
        {
            Members.AddRange(personsList);
        }

        public IEnumerable<Paper> GetPublishingInRecentYear(int year)
        {
            var publications = _publications.Where(x => (DateTime.Now.Year - x.DateOfPublish.Year) < year);
            if (publications.Count() < 0)
            {
                yield break;
            }

            foreach (Paper paper in publications)
            {
                yield return paper;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return GetMembersWithoutAnyPublish();
        }

        public IEnumerable<Person> GetMembersWithoutAnyPublish()
        {
            var members = _members.Where(x => !_publications.Any(p => p.Author.Equals(x)));
            if (members.Count() < 0)
            {
                yield break;
            }

            foreach (Person person in members)
            {
                yield return person;
            }
        }

        public void AddPapers(params Paper[] papers)
        {
            foreach (var paper in papers)
            {
                _publications.Append(paper);
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"{_nameOfStudy} {_durationOfResearch}\n\t{string.Join("\n\t", _publications.Select(x => x.ToString()).ToArray())}";
        }

        public virtual string ToShortString()
        {
            return base.ToString() + $"{_nameOfStudy} {_durationOfResearch}";
        }

        public override object DeepCopy()
        {
            ResearchTeam research = new ResearchTeam(name, _nameOfStudy, registryNumber, _durationOfResearch, _publications);
            research._members = _members;
            return research;
        }

        public int Compare(ResearchTeam x, ResearchTeam y)
        {
            return x.NameOfStudy.CompareTo(y.NameOfStudy);
        }

        public bool Save(string fileName)
        {
            string fileLocation = @"D:\";
            string fileFormat = ".txt";

            ResearchTeam researchTeam = new ResearchTeam(NameOfStudy, Name, RegistryNumber, DurationOfResearch, Publication);
            researchTeam.Members = Members;

            MemoryStream ms = new MemoryStream();
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ResearchTeam));
                ser.WriteObject(ms, researchTeam);
                byte[] json = ms.ToArray();

                var objectToJson = Encoding.UTF8.GetString(json, 0, json.Length);
                FileStream fstream = new FileStream(fileLocation + fileName + fileFormat, FileMode.OpenOrCreate);
                fstream.SetLength(0);
                byte[] array = Encoding.Default.GetBytes(objectToJson);
                fstream.Write(array, 0, array.Length);
                fstream.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                ms.Close();
            }
            return false;
        }

        public bool Load(string fileName)
        {
            string fileLocation = @"D:\";
            string fileFormat = ".txt";

            try
            {
                using (FileStream fstream = File.OpenRead(fileLocation + fileName + fileFormat))
                {
                    byte[] array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);
                    string json = Encoding.Default.GetString(array);

                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
                    ResearchTeam deserializedTeam = new ResearchTeam();
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedTeam.GetType());
                    deserializedTeam = ser.ReadObject(ms) as ResearchTeam;

                    NameOfStudy = deserializedTeam.NameOfStudy;
                    Name = deserializedTeam.Name;
                    DurationOfResearch = deserializedTeam.DurationOfResearch;
                    RegistryNumber = deserializedTeam.RegistryNumber;
                    Publication = deserializedTeam.Publication;
                    Members = deserializedTeam.Members;

                    ms.Close();
                    fstream.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public bool AddPaperFromConsole()
        {
            Console.WriteLine("Введiть данi для об'єкту Paper наступного формату: " +
                              "назва публiкацiї;дата публiкацiї;Автор: iм'я;прiзвище;дата народження(формат: YYYY:MM:DD)\n" +
                              "Приклад: C# tutorial;2018-01-11;James;Bay;1990-04-23");

            Person person = new Person();
            Paper paper = new Paper();
            var input = Console.ReadLine();
            string[] splitedString = new string[] { "" };

            if (input != null)
            {
                splitedString = input.Split(';');
            }

            try
            {
                paper.NameOfPublish = splitedString[0];
                var yearOfPublishing = int.Parse(splitedString[1].Split('-')[0]);
                var monthOfPublishing = int.Parse(splitedString[1].Split('-')[1]);
                var dayOfPublishing = int.Parse(splitedString[1].Split('-')[2]);
                paper.DateOfPublish = new DateTime(yearOfPublishing, monthOfPublishing, dayOfPublishing);

                person.FirstName = splitedString[2];
                person.LastName = splitedString[3];
                var yearOfBirth = int.Parse(splitedString[4].Split('-')[0]);
                var monthOfBirth = int.Parse(splitedString[4].Split('-')[1]);
                var dayOfBirth = int.Parse(splitedString[4].Split('-')[2]);
                person.Birthday = new DateTime(yearOfBirth, monthOfBirth, dayOfBirth);
                paper.Author = person;
                Publication.Add(paper);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public ResearchTeam ShallowCopy()
        {
            return (ResearchTeam)MemberwiseClone();
        }

        #endregion Methods
    }
}