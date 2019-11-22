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
    class Ejercicio2Guia12 : Program
    {
        static void Main(string[] args)
        {
            BinaryFormatter formateichon = new BinaryFormatter();
            const string FILE = "pets.bin";
            try
            {
                Program.Pets Pet1;
                FileStream fStream1;
                formateichon = new BinaryFormatter();
                if (File.Exists(FILE))
                {
                    try
                    {
                        fStream1 = new FileStream(FILE, FileMode.Open, FileAccess.Read);
                        Pet1 = (Program.Pets)formateichon.Deserialize(fStream1);
                        fStream1.Close();
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Información de Mascotas (Noviembre 2019)");
                        Console.WriteLine("==================================================");
                        Console.ResetColor();
                        Console.WriteLine("Tu mascota se llama {0} y es un {1}, de sexo {2}. Tiene {3} MESES de edad", Pet1.name, Pet1.specie, Pet1.sex, Pet1.age);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Ocurrió un accidente mientras se almacenaba la información, por favor, reiniciar el sistema.");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrió un accidente mientras se almacenaba la información, por favor, reiniciar el sistema.");
            }
        }
    }
}
