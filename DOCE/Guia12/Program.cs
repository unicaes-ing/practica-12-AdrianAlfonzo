using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Guia12
{
    //------------------UNICAES------------------
    //---Facultad de Ingenería y Arquitectura---
    //--INGENIERÍA EN DESARROLLO DE SOFTWARE--
    //-Última fecha de modificación: 21.11.19
    //-------Luis Adrián Alfonzo Morán-------
    public class Program
    {
        [Serializable]
        public struct Pets
        {
            public int age;
            public string sex;
            public string name;
            public string specie;
        }
        static void Main(string[] args)
        {
            Pets petInfo = new Pets();
            FileStream nameFS;
            BinaryFormatter formateichon = new BinaryFormatter();
            const string FILE = "pets.bin";
            try
            {
                Console.WriteLine("¿Cuál es el nombre de su mascota?");
                petInfo.name = Console.ReadLine();
                Console.WriteLine("============================================");
                Console.WriteLine("¿Cuál es la especie de {0}?", petInfo.name);
                petInfo.specie = Console.ReadLine();
                Console.WriteLine("============================================");
                Console.WriteLine("¿Cuál es el sexo de {0}?", petInfo.name);
                petInfo.sex = Console.ReadLine();
                Console.WriteLine("============================================");
                Console.WriteLine("¿Cuál es la edad EN MESES de {0}?", petInfo.name);
                petInfo.age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("============================================");
                Console.Clear();
                Console.WriteLine("Información almacenada exitosamente...");
                nameFS = new FileStream(FILE, FileMode.Create, FileAccess.Write);
                formateichon.Serialize(nameFS, petInfo);
                nameFS.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrió un accidente mientras se almacenaba la información, por favor, reiniciar el sistema.");
            }
            Console.ReadKey();
        }
    }
}
