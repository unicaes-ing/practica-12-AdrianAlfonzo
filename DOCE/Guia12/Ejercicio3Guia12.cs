using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Guia12
{
    //------------------UNICAES------------------
    //---Facultad de Ingenería y Arquitectura---
    //--INGENIERÍA EN DESARROLLO DE SOFTWARE--
    //-Última fecha de modificación: 21.11.19
    //-------Luis Adrián Alfonzo Morán-------
    class Ejercicio3Guia12
    {
        [Serializable]
        #region Setter & Getter y Estructura
        public struct Student
        {
            public string id;
            public string name;
            public string run;
            private decimal CUM;
            public decimal GetCUM()
            {
                return CUM;
            }
            public void SetCUM(decimal cum)
            {
                if (cum > 0)
                {
                    this.CUM = cum;
                }
            }
        }
        #endregion
        #region BinaryFormatter & FileStream
        private static Dictionary<string, Student> dataStudent = new Dictionary<string, Student>();
        private static BinaryFormatter formateichon = new BinaryFormatter();
        private const string FILE = "student.bin";
        public static bool AddInfo(Dictionary<string, Student> infoStudent)
        {
            try
            {
                FileStream fStream = new FileStream(FILE, FileMode.Create, FileAccess.Write);
                formateichon.Serialize(fStream, infoStudent);
                fStream.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        #region Reader (Para LEER información generada)
        public static bool ReadInfo()
        {
            try
            {
                FileStream fStream = new FileStream(FILE, FileMode.Open, FileAccess.Read);
                dataStudent = (Dictionary<string, Student>)formateichon.Deserialize(fStream);
                fStream.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        public void Ejercicio3DeEstaMismaGuia12()
        {
            if (File.Exists(FILE))
            {
                ReadInfo();
            }
            else
            {
                AddInfo(dataStudent);
            }
        }
        static void Main(string[] args)
        {
            int option;
            do
            {
                Console.Clear();
                Console.WriteLine("===== SELECCIONA UNA OPCIÓN =====");
                Console.WriteLine(" [1] Agregar alumno");
                Console.WriteLine(" [2] Mostrar alumnos");
                Console.WriteLine(" [3] Buscar alumno");
                Console.WriteLine(" [4] Editar alumno");
                Console.WriteLine(" [5] Eliminar alumno");
                Console.WriteLine(" [6] Salir");
                Console.WriteLine("=================================");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        #region Agregar
                        Console.Clear();
                        Console.WriteLine("===== Agregar Alumno =====");
                        Student studentito = new Student();
                        do
                        {
                            Console.WriteLine("¿Cuál es su carnet?");
                            studentito.id = Console.ReadLine();
                            if (dataStudent.ContainsKey(studentito.id))
                            {
                                Console.WriteLine("El carnet {0} ya existe...", studentito.id);
                            }
                        } while (dataStudent.ContainsKey(studentito.id));
                        Console.WriteLine("¿Cuál es su nombre?");
                        studentito.name = Console.ReadLine();
                        Console.WriteLine("¿Que carrera está estudiando?");
                        studentito.run = Console.ReadLine();
                        Console.WriteLine("¿Cuál es su CUM");
                        studentito.SetCUM(Convert.ToDecimal(Console.ReadLine()));
                        dataStudent.Add(studentito.id, studentito);
                        AddInfo(dataStudent);
                        Console.WriteLine("La información se ha guardado exitosamente");
                        Console.ReadKey();
                        #endregion
                        break;
                    case 2:
                        #region Mostrar
                        Console.Clear();
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("=== Información de los estudiantes de la Universidad Católica de El Salvador ===");
                            Console.WriteLine();
                            Console.ResetColor();
                            Console.WriteLine("{0,-10}    {1,-10}        {2,5}        {3,8}", "Carnet", "Nombre", "Carrera", "CUM");
                            Console.WriteLine("==========================================================================");
                            ReadInfo();
                            foreach (KeyValuePair<string, Student> StudentWr in dataStudent)
                            {
                                Student student = StudentWr.Value;
                                Console.WriteLine("{0,-10}    {1,-10}    {2,5}    {3,8}",
                                student.id, student.name, student.run, student.GetCUM());
                            }
                            Console.WriteLine("=========================================================================");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            throw;
                        }
                        Console.ReadKey();
                        #endregion
                        break;
                    case 3:
                        #region Buscar
                        Console.Clear();
                        string idFind;
                        Console.WriteLine("¿Cuál es el carnet del alumno que desea buscar?");
                        idFind = Console.ReadLine();
                        if (dataStudent.ContainsKey(idFind))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Su estudiante ha sido ENCONTRADO, y ésta es un INFORMACIÓN");
                            Console.ResetColor();
                            Console.WriteLine("{0,3}    {1,-10}   {2,5}    {3,8}", "Carnet", "Nombre", "Carrera", "CUM");
                            Console.WriteLine("=========================================================================");
                            ReadInfo();
                            Console.WriteLine("{0,3}    {1,-10}    {2,5}    {3,8}",
                                dataStudent[idFind].id, dataStudent[idFind].name, dataStudent[idFind].run, dataStudent[idFind].GetCUM());
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("El carnet NO SE ENCONTRÓ");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        #endregion
                        break;
                    case 4:
                        #region Modificar
                        Console.Clear();
                        string idModify;
                        Console.WriteLine("¿Cuál es el carnet del alumno que desea modificar?");
                        idModify = Console.ReadLine();
                        if (dataStudent.ContainsKey(idModify))
                        {
                            Console.WriteLine("===== MODIFICAR =====");
                            dataStudent.Remove(idModify);
                            Student student = new Student();
                            do
                            {
                                Console.WriteLine("Nuevo carnet: ");
                                student.id = Console.ReadLine();
                                if (dataStudent.ContainsKey(student.id))
                                {
                                    Console.WriteLine("El carnet {0} ya existe...", student.id);
                                }
                            } while (dataStudent.ContainsKey(student.id));
                            Console.WriteLine("Nuevo nombre: ");
                            student.name = Console.ReadLine();
                            Console.WriteLine("Nueva carrera: ");
                            student.run = Console.ReadLine();
                            Console.WriteLine("Nuevo CUM: ");
                            student.SetCUM(Convert.ToDecimal(Console.ReadLine()));
                            dataStudent.Add(student.id, student);
                            AddInfo(dataStudent);
                            Console.WriteLine("¡Se ha actualizado la información satisfactoriamente!");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("El carnet {0} NO EXISTE", idModify);
                        }
                        #endregion
                        break;
                    case 5:
                        #region Eliminar
                        Console.Clear();
                        string idRemove;
                        Console.WriteLine("¿Cuál es el carnet del alumno que desea eliminar?");
                        idRemove = Console.ReadLine();
                        if (dataStudent.ContainsKey(idRemove))
                        {
                            dataStudent.Remove(idRemove);
                        }
                        AddInfo(dataStudent);
                        #endregion
                        break;
                }
            } while (option != 6);
        }
    }
}
