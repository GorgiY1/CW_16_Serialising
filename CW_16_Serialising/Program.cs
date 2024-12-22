using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CW_16_Serialising
{
   [Serializable] // For XML Sirializeble It's can not write
    //[Serializable] // For XML Sirializeble It's can not write
    //[DataContract] // For JSON Sirializeble 
    public class Person
    {
        [NonSerialized]
        const string Planet = "Earth";

        [NonSerialized]
        // [DataMember]
        private int _id;

        //[DataMember]
        public string Name { get; set; }

        //[DataMember]
        public int Age { get; set; }

        public Person()
        {
            _id = new Random().Next(1000, 10000);
        }
        public override string ToString()
        {
            return $"{_id} {Name} {Age} { Planet}";
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Person person = new Person { Name = "Jeena", Age = 37 };
            //Console.WriteLine(person);

            // =========================== Binary Serialize =============================

            //BinaryFormatter binaryFormatter = new BinaryFormatter();

            //try
            //{
            //    using (FileStream stream = File.Create("Test.bin"))
            //    {
            //        binaryFormatter.Serialize(stream, person);
            //    }
            //    Console.WriteLine("ok");

            //    Person p = null;
            //    using (FileStream stream1 = File.OpenRead("Test.bin"))
            //    {
            //        p = binaryFormatter.Deserialize(stream1) as Person;
            //    }
            //    Console.WriteLine(p);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            // ===================== SOAP (Simple Object Access Protocol) =======================

            //SoapFormatter binaryFormatter = new SoapFormatter();

            //try
            //{
            //    using (FileStream stream = File.Create("Test.soap"))
            //    {
            //        binaryFormatter.Serialize(stream, person);
            //    }
            //    Console.WriteLine("Serialize ok");

            //    Person p = null;
            //    using (FileStream stream1 = File.OpenRead("Test.soap"))
            //    {
            //        p = binaryFormatter.Deserialize(stream1) as Person;
            //    }
            //    Console.WriteLine(p);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            // ================================ XML () ===================================

            List<Person> people = new List<Person>
            {
                new Person { Name = "Jack", Age = 45},
                new Person { Name = "Bob", Age = 18},
                new Person { Name = "Clarck", Age = 45}
            };

            XmlSerializer formatter = new XmlSerializer(typeof(List<Person>)); // persen.GetType()

            try
            {
                using (FileStream stream = File.Create("TestList.xml"))
                {
                    formatter.Serialize(stream, people);
                }
                Console.WriteLine("Serialize ok");

                List<Person> list = null;
                using (FileStream stream = File.OpenRead("TestList.xml"))
                {
                    list = formatter.Deserialize(stream) as List<Person>;
                }

                foreach (Person p in list)
                {
                    Console.WriteLine(p);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // ======================================= JSON () =========================================

            //Person person = new Person { Name = "Jeena", Age = 37 };
            //Console.WriteLine(person);

            //DataContractJsonSerializer formatter = new DataContractJsonSerializer(person.GetType());

            //try
            //{
            //    using (FileStream stream = File.Create("TestJson.json"))
            //    {
            //        formatter.WriteObject(stream, person);
            //    }
            //    Console.WriteLine("Serialize ok");

            //    Person p = null;
            //    using (FileStream stream = File.OpenRead("TestJson.json"))
            //    {
            //        p = formatter.ReadObject(stream) as Person;
            //    }
            //    Console.WriteLine(p);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //-------------------------------------------------------------------------------

            //List<Person> people = new List<Person>
            //{
            //    new Person { Name = "Jack", Age = 45},
            //    new Person { Name = "Bob", Age = 18},
            //    new Person { Name = "Clarck", Age = 45}
            //};

            //DataContractJsonSerializer formatter = new DataContractJsonSerializer(people.GetType());

            //try
            //{
            //    using (FileStream stream = File.Create("TestJsonList.json"))
            //    {
            //        formatter.WriteObject(stream, people);
            //    }
            //    Console.WriteLine("Serialize ok");

            //    List<Person> list = null;
            //    using (FileStream stream = File.OpenRead("TestJsonList.json"))
            //    {
            //        list = formatter.ReadObject(stream) as List<Person>;
            //    }

            //    foreach (Person p in list)
            //    {
            //        Console.WriteLine(p);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            Console.ReadKey();
        }
    }
}
