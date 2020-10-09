﻿using System;
using Dominio;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeViajes
{
    public class Program

    {
        static Agencia unaAgencia = new Agencia();
        //
        static void Main(string[] args)
        {
            int opcion;
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------" + "\n");
                Console.WriteLine("                      AGENCIA DE VIAJES                   " + "\n");
                Console.WriteLine("                           MENU                           " + "\n");
                Console.WriteLine("----------------------------------------------------------" + "\n");
                Console.WriteLine("                 1- Ingresa un destino                    " + "\n");
                Console.WriteLine("                 2- Listar todos los destinos             " + "\n");
                Console.WriteLine("                 3- Cotización del dolar                  " + "\n");
                Console.WriteLine("                 4- Registrar excursiones                 " + "\n");
                Console.WriteLine("                 5- Listar excursiones                    " + "\n");
                Console.WriteLine("                 6- Listar excursiones en fecha dada      " + "\n");
                Console.WriteLine("                 7- Salir                                 " + "\n");
                Console.WriteLine("----------------------------------------------------------" + "\n");
                int.TryParse(Console.ReadLine(), out opcion);
              
                switch (opcion)
                {
                    case 1:
                        IngresaDestino();
                        Console.ReadKey();
                        break;
                    case 2:
                        ListarDestinos();
                        Console.ReadKey();
                        break;
                    case 3:
                        MostrarCotizacion();
                        break;
                    case 4:
                        AltaExcursion();
                        break;
                    case 5:
                        ListarExcursiones();
                        Console.ReadKey();
                        break;
                    case 6:
                        //ListarExcursionesEnFecha();
                        break;
                    case 7:
                        return;                       
                    default:
                        break;
                }
            }

            
        }

        private static string PedirTexto(string mensaje)
        {
            Console.WriteLine(mensaje);
            string texto = Console.ReadLine();
            return texto;
        }
        //Muestro la lista excursiones
        
        private static void MostrarListaExcursiones(List<Excursion> asist, string msgError)
        {
            if (asist.Count > 0)
            {
                foreach (Excursion unExcursion in asist)
                {
                    Console.WriteLine(unExcursion);
                }
            }
            else
            {
                Console.WriteLine(msgError);
            }
        }
        // Muestra en pantalla la lista de destinos si los hubiera
        private static void MostrarListaDestinos(List<Destino> asist, string msgError)
        {
            if (asist.Count > 0)
            {
                foreach (Destino unDestino in asist)
                {
                    Console.WriteLine(unDestino);
                }
            }
            else
            {
                Console.WriteLine(msgError);
            }
        }
        private static int PedirNumero(string mensaje = "Ingrese el numero")
        {
            int num;
            bool valido = false;
            do
            {
                Console.WriteLine(mensaje);
                valido = int.TryParse(Console.ReadLine(), out num);
                if (!valido)
                {
                    Console.WriteLine("Solo se admiten numeros");
                }

            } while (!valido);

            return num;
        }

        private static void IngresaDestino()
        {
            string ciudad, pais;
            decimal costo;
            decimal cantidadDias;
            bool bandera = false;
            ciudad = PedirTexto("Ingrese la ciudad");
            pais = PedirTexto("Ingrese el pais");
            costo = PedirNumero("Ingrese el costo");
            cantidadDias = PedirNumero("Ingrese los días");
            if (Destino.ValidarString2(ciudad) && Destino.ValidarString2(pais) && Destino.ValidarEnteros(costo) && Destino.ValidarEnteros(cantidadDias))
            {
                bandera = unaAgencia.AgregarDestinos(ciudad, pais, costo, cantidadDias);
                if (bandera)
                {
                    Console.WriteLine("Alta destino OK");
                }
                else
                {
                    Console.WriteLine("Error, algo salió mal. Verifique que lo ingresado este correcto.");
                }
            }
        }

        private static void AltaExcursion()
        {
            string descripcion;
            DateTime fecha;
            int diasTraslados;
            int stockLugares;
            int idExcursion;
            bool esInteres;
            descripcion = PedirTexto("Ingrese la descripcion de la excursion");
            //fecha = PedirTexto("Ingrese la fecha");
            diasTraslados = PedirNumero("Indique los días");
            stockLugares = PedirNumero("Ingrese los lugares que quedan");
            idExcursion = PedirNumero("Ingresar numero de id");
            //esInteres = PedirTexto("S/N")
        }


        // Creo una lista auxiliar de excursiones, la cargo con la lista de excursiones (agencia) y la mando al método MostrarLista
        private static void ListarExcursiones()
        {
            List<Excursion> asist = unaAgencia.Excursiones(); // obtiene una lista de excursiones generada desde el método en Agencia
            MostrarListaExcursiones(asist, "No hay excursiones.");
        }
        private static void ListarDestinos()
        {
            List<Destino> asist = unaAgencia.Destinos();
            MostrarListaDestinos(asist, "No hay destinos.");
        }

        private static void MostrarCotizacion()
        {
            int opcion;
            bool salir = false;
            decimal cotiz = unaAgencia.MostrarDolar();          
            Console.WriteLine("\nLa cotizacion actual del dólar es: $ " + cotiz);
            do
            {
                Console.WriteLine("Desea modificar la cotizacion?\n");
                opcion = PedirNumero("1 - Si\n2 - No");
                if (opcion == 1)
                {
                    ModificarCotizacion();
                    salir = true;
                }               
            } while (opcion == 1 && !salir);

        }

        private static void ModificarCotizacion()
        {
            decimal cotizacion;
            Console.WriteLine("Ingrese la nueva cotizacion: ");
            decimal.TryParse(Console.ReadLine(), out cotizacion);
            bool valido = unaAgencia.ModificarDolar(cotizacion);
            if (!valido)
            {
                Console.WriteLine("El valor debe ser positivo");

            } else
            {
                Console.WriteLine("\nLa cotizacion actualizada es: $ " + cotizacion);
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
            }         
        }
    }
}
