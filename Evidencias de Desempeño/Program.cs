using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HTTPupt;

namespace Evidencias_de_Desempeño
{
    public class Program
    {
        private const string Format = "hh_mm";

        public static string Format1 => Format2;

        public static string Format2 => Format;

        static void Main()
        {
            Personal Gerente = new Personal();
            Cocinero Cocinero;
            List<Cocinero>PersonalDelDia = new List<Cocinero>();
            int Exit, ArchivoConta;
            string Opciones;
            bool Flag = true, FlagGerente = true;
            while (Flag == true) 
            {
                Console.WriteLine("Ingrese la opcion que desea realizar \n 1. Entrada Gerente \n 2. Entrada Cocinero \n 3. Asignar Compañero \n 4. Salida Cocinero \n 5. Salida Gerente \n 6. Salir");
                Opciones = Console.ReadLine();
                while (Opciones != "1" && Opciones != "2" && Opciones!= "3" && Opciones != "4" && Opciones != "5" && Opciones != "6") 
                {
                    Console.WriteLine("Opcion no Valida");
                    Opciones = Console.ReadLine();
                }
                switch (Opciones) 
                { 
                    case "1": 
                        {
                            if (FlagGerente == true)
                            {
                                Gerente = EntradaGerente(Gerente);
                                FlagGerente = false;
                            }
                        }
                        break;
                    case "2":
                        {
                            Cocinero = EntradaCocinero();
                            PersonalDelDia.Add(Cocinero);
                        }
                        break;
                    case "3":
                        {
                            AsignarComp(PersonalDelDia);
                        }
                        break;
                    case "4":
                        {
                            SalidaCocinero(PersonalDelDia);
                        }
                        break;
                    case "5":
                        {
                            SalidaGerente(Gerente, PersonalDelDia);
                        }
                        break;
                    case "6":
                        {
                            Console.WriteLine("Seguro que desea salir? \n 1.Si \n 2.No");
                            Exit = int.Parse(Console.ReadLine());
                            if(Exit == 1)
                            {
                                Flag = false;
                                Console.WriteLine("Desea guardar un archivo con los registros de hoy? \n 1. Si \n 2. No");
                                ArchivoConta = int.Parse(Console.ReadLine());
                                if(ArchivoConta == 1)
                                {
                                    GuardarArchivo(Gerente,PersonalDelDia);
                                }
                            }
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Si estas viendo este mensaje ha ocurrido un error, por favor reinicie el sistema \n Si el error persiste por favor contacte al soporte tecnico");
                        }
                        break;
                }
                Console.Clear();
            }
        }

        static Personal EntradaGerente(Personal gerente)
        {
            string datetime;
            Console.WriteLine("Ingrese el nombre del gerente");
            gerente.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el ID del gerente");
            gerente.ID = Console.ReadLine();
            gerente.HoraEntrada = gerente.RegistrarEntrada(datetime = DateTime.Now.ToString("hh:mm:ss tt"));
            Console.WriteLine("Bienvenido: " + gerente.Nombre);
            Console.ReadKey();
            Console.Clear();
            return gerente;
        }
        static Cocinero EntradaCocinero()
        {
            string datetime;
            Cocinero cocinero = new Cocinero();
            Console.WriteLine("Ingrese el nombre del Cocinero");
            cocinero.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el ID del cocinero");
            cocinero.ID = Console.ReadLine();
            cocinero.HoraEntrada = cocinero.RegistrarEntrada(datetime = DateTime.Now.ToString("hh:mm:ss tt"));
            Console.WriteLine("Bienvenido: " + cocinero.Nombre);
            Console.ReadKey();
            Console.Clear();
            return cocinero;
        }
        static void AsignarComp(List<Cocinero>PersonalDia)
        {
            bool flag = false;
            string identificador1,identidicador2;
            Console.WriteLine("Ingrese el nombre o Id de a quien se le asignara compañero");
            identificador1 = Console.ReadLine();
            for(int i = 0; i < PersonalDia.Count; i++)
            {
                if(PersonalDia[i].Nombre == identificador1 || PersonalDia[i].ID == identificador1)
                {
                    Console.WriteLine("Ingrese el nombre o ID del compañero");
                    identidicador2 = Console.ReadLine();
                    for( int j = 0; j < PersonalDia.Count; j++)
                    {
                        if(PersonalDia[j].Nombre == identidicador2 || PersonalDia[j].ID == identidicador2)
                        {
                            PersonalDia[i].AsignarCompañero(PersonalDia[j].Nombre);
                            PersonalDia[j].AsignarCompañero(PersonalDia[i].Nombre);
                            Console.WriteLine("Compañero asignado correctamente");
                            flag = true;
                        }
                    }
                }
            }
            if(flag != true)
            {
                Console.WriteLine("No se encontro al cocinero");
            }
            Console.ReadKey();
            Console.Clear();
        }
        static void SalidaCocinero(List<Cocinero> PersonalDia)
        {
            bool flag = false;
            string identificador, datetime;
            Console.WriteLine("Ingrese el nombre o Id del cocinero que sale");
            identificador = Console.ReadLine();
            
            for(int i = 0; i < PersonalDia.Count; i++)
            {
                if(identificador == PersonalDia[i].ID || identificador == PersonalDia[i].Nombre)
                {
                    PersonalDia[i].HoraSalida = PersonalDia[i].RegistrarSalida(datetime = DateTime.Now.ToString("hh:mm:ss tt"));
                    Console.WriteLine(PersonalDia[i].Nombre + " Salio");
                    flag = true;
                }
            }
            if(flag != true)
            {
                Console.WriteLine("No se encontro al cocinero");
            }
            Console.ReadKey();
            Console.Clear();
        }
        static void SalidaGerente(Personal gerente, List<Cocinero>Cocineros)
        {
            string datetime;
            bool flag = true;
            for(int i = 0;i < Cocineros.Count; i++)
            {
                if(Cocineros[i].HoraSalida == "")
                {
                    flag = false;
                }
            }
            if(flag == true)
            {
                gerente.HoraSalida = gerente.RegistrarSalida(datetime = DateTime.Now.ToString("hh:mm:ss tt"));
                Console.WriteLine(gerente.Nombre + " Salio");
            }
            else
            {
                Console.WriteLine("El Gerente no se puede retirar porque todavia hay otro personal dentro");
            }
            Console.ReadKey();
            Console.Clear();
        }
        static void GuardarArchivo(Personal Gerente,List<Cocinero>PersonalDelDia)
        {
            Personal gerente = Gerente;
            List<Cocinero> PersonaldelDia = PersonalDelDia;
            string NombreArchivo = "Registro" + DateTime.Now.ToString(Format1);
            FileStream Archivo = new FileStream(@"C:\Users\cris-\Desktop\" + NombreArchivo + ".txt", FileMode.CreateNew, FileAccess.Write);
            StreamWriter Escribir = new StreamWriter(Archivo);
            String json = JsonConvertidor.Objeto_Json(gerente);
            Escribir.WriteLine(json);
            if (PersonalDelDia.Count > 0)
            {
                for (int i = 0; i < PersonalDelDia.Count; i++)
                {
                    json = JsonConvertidor.Objeto_Json(PersonaldelDia[i]);
                    Escribir.WriteLine(json);
                }
            }
            Escribir.Close();
        }
    }
}