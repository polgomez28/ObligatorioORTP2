﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Agencia
    {
        // Atributos
        private List<Excursion> excursiones = new List<Excursion>();
        private List<Destino> destinos = new List<Destino>();
        private List<CompaniaAerea> companiasAereas = new List<CompaniaAerea>();
        private static decimal dolar = 45; /////////// "Precargar" la cotizacion??
        // Propiedades
        //public List<Excursion> Excursiones
        //{
          //  get { return excursiones; }
        //}
        public List<Destino> Destino
        {
            get { return destinos; }
        }
        public List<CompaniaAerea> CompaniasAereas
        {
            get { return companiasAereas; }
        }
        public decimal Dolar
        {
            get { return dolar; }
        }
        //Precargas
        public Agencia()
        {
            PrecargaCompaniaAerea();
            PrecargasDestinos();
            PrecargarExcursiones();
        }
        // Precarga Comanias aereas

        
        // Precarga Companias aereas

        private void PrecargaCompaniaAerea()
        {
            AltaCompaniaAerea("Alemania", 1);
            AltaCompaniaAerea("Argentina", 2);
            AltaCompaniaAerea("EE.UU", 3);
            AltaCompaniaAerea("Brasil", 4);
            AltaCompaniaAerea("Brasil", 4);
        }

        private void PrecargasDestinos()
        {
            // Destinos internacionales
            AgregarDestinos("Barcelona", "España", 150, 5);
            AgregarDestinos("Madrid", "España", 150, 5);
            AgregarDestinos("Granada", "España", 150, 5);
            AgregarDestinos("Mallorca", "España", 150, 5);
            AgregarDestinos("Paris", "Francia", 150, 5);
            AgregarDestinos("Lyon", "Francia", 150, 5);
            AgregarDestinos("Roma", "Italia", 150, 5);
            AgregarDestinos("Atenas", "Grecia", 150, 5);
            AgregarDestinos("Venecia", "Italia", 150, 5);
            // Destinos Nacionales
            AgregarDestinos("Montevideo", "Uruguay", 150, 5);
            AgregarDestinos("Salto", "Uruguay", 150, 5);
            AgregarDestinos("Paysandu", "Uruguay", 150, 5);
            AgregarDestinos("Artigas", "Uruguay", 150, 5);
            AgregarDestinos("San José", "Uruguay", 150, 5);
            AgregarDestinos("Maldonado", "Uruguay", 150, 5);
            AgregarDestinos("Rivera", "Uruguay", 150, 5);
            AgregarDestinos("Rocha", "Uruguay", 150, 5);
            AgregarDestinos("Fray Bentos", "Uruguay", 150, 5);
        }
        // Precarga excursiones
        
        private void PrecargarExcursiones()
        {
            DateTime fecha;

            fecha = new DateTime(2020, 08, 10);
            AltaExcursionNacional("Cabo Polonio", fecha, 5, 45, 1200, true, DevolverDestino("Montevideo", "Uruguay", "San José", "Uruguay"));

            fecha = new DateTime(2020, 01, 10);
            AltaExcursionNacional("Portezuelo", fecha, 5, 45, 1000, true, DevolverDestino("Salto", "Uruguay", "Artigas", "Uruguay"));

            fecha = new DateTime(2020, 02, 10);
            AltaExcursionNacional("Atlantida", fecha, 5, 45, 1400, true, DevolverDestino("Rivera", "Uruguay", "Maldonado", "Uruguay"));

            fecha = new DateTime(2020, 03, 10);
            AltaExcursionNacional("Cerro chato", fecha, 5, 45, 1500, true, DevolverDestino("Rocha", "Uruguay", "Fray Bentos", "Uruguay"));

            //Excursiones internacionales

            fecha = new DateTime(2020, 02, 01);
            AltaExcursionesInternacionales("OctoberFest", fecha, 4, 25, 1800, 4, DevolverDestino("Barcelona","España","Madrid","España"));

            fecha = new DateTime(2020, 01, 01);
            AltaExcursionesInternacionales("San Fermin", fecha, 4, 15, 1500, 4, DevolverDestino("Granada", "España", "Mayorca", "España"));

            fecha = new DateTime(2020, 04, 01);
            AltaExcursionesInternacionales("Madrid", fecha, 4, 25, 1900, 4, DevolverDestino("Paris", "Francia", "Lyon", "Francia"));

            fecha = new DateTime(2020, 06, 01);
            AltaExcursionesInternacionales("Roma", fecha, 4, 25, 1200, 4, DevolverDestino("Roma", "Italia", "Atenas", "Italia"));
        }
        
        //*********************************************************
        //Generar método que agregue PrecargarDestinosAExcursiones
        //*********************************************************

        // Alta compania aerea
        private bool AltaCompaniaAerea(string pais, int idCompania)
        {
            bool exito = false, existe = BuscarCompania(idCompania);
            if (!existe)
            {
                CompaniaAerea unCompaniaAerea = new CompaniaAerea(pais);
                companiasAereas.Add(unCompaniaAerea);
                exito = true;
            }
            return exito;
        }
        public bool PrecargarDestinosAExcursiones(List<Destino> aux, Excursion excursion)
        {
            bool exito = false;

            return exito;
        }
        // Alta Destinos
        /*public bool AgregarDestinos(string ciudad, string pais, decimal costo, decimal cantidadDias)
        {
            bool exito = false;
            Destino unD = new Destino(ciudad, pais, costo, cantidadDias);

            destinos.Add(unD);
            exito = true;
            return exito;
        }*/
        
        //Buscar compania a partir del id
        private bool BuscarCompania(int idCompania)
        {
            bool encontre = false;
            int i = 0;
            while (!encontre && i < companiasAereas.Count)
            {
                if (companiasAereas[i].Id == idCompania)
                {
                    encontre = true;
                }
                i++;
            }
            return encontre;
        }
        // Obtener compania a partir del id
        private CompaniaAerea ObtenerCompania(int idCompania)
        {
            bool encontre = false;
            int i = 0;
            CompaniaAerea unCompania = null;
            while (!encontre && i < companiasAereas.Count)
            {
                if (companiasAereas[i].Id == idCompania)
                {
                    //encontre = true;
                     unCompania = companiasAereas[i];
                }
                i++;
            }
            return unCompania;
        }
        //Alta de excursiones nacionales
        public bool AltaExcursionNacional(string descripcion, DateTime fecha, int diasTraslados, int stockLugares, int idExcursion, bool esInteres, List<Destino> destinos)
        {
            bool exito = false, existe = BuscarExcursion(idExcursion);
            if (!existe)
            {
                Nacional unNacional = new Nacional(descripcion, fecha, diasTraslados, stockLugares, esInteres, destinos);
                excursiones.Add(unNacional);
                exito = true;
            }
            return exito;
        }
        // Alta de excursiones internacionales
        public bool AltaExcursionesInternacionales(string descripcion, DateTime fecha, int diasTraslados, int stockLugares, int idExcursion, int idCompania, List<Destino> destinos)
        {
            bool exito = false, existe = BuscarExcursion(idExcursion);
            if (!existe)
            {
                CompaniaAerea unCompania = ObtenerCompania(idCompania);
                if (unCompania != null)
                {
                    Internacional unInter = new Internacional(descripcion, fecha, diasTraslados, stockLugares, unCompania, destinos);
                    excursiones.Add(unInter);
                    exito = true;
                }
            }
            return exito;
        }
        // Buscar excursión existente
        public bool BuscarExcursion(int id)
        {
            bool encontre = false;
            int i = 0;
            while (!encontre && i < excursiones.Count)
            {
                if (excursiones[i].Id == id)
                {
                    encontre = true;
                }
                i++;
            }
            return encontre;
        }


        public List<Excursion> Excursiones()
        {
            List<Excursion> asist = new List<Excursion>();
            foreach (Excursion unaExcursion in excursiones)
            {
                asist.Add(unaExcursion);
            }
            return asist;
        }
        public List<Destino> Destinos()
        {
            List<Destino> asist = new List<Destino>();
            foreach (Destino unDestino in destinos)
            {
                asist.Add(unDestino);
            }
            return asist;
        }

        //Mostrar Cotización
        public decimal MostrarDolar()
        {           
            return dolar;
        }
        //Modificar Cotización
        public bool ModificarDolar(decimal numero)
        {
            bool valido = false;
            if (numero > 0)
            {
                dolar = numero;
                valido = true;
            }
            return valido;
        }

        //Buscar destino
        public Destino BuscarDestino(string ciudad, string pais, decimal costo, decimal cantidadDias, List<Destino> auxDestino)
        {
            int i = 0;
            Destino destino = null;
            while (destino == null && i < auxDestino.Count)
            {
                if(auxDestino[i].Ciudad == ciudad)
                {
                    destino = destinos[i];
                }
                i++;
            }
            return destino;
        }

        public Destino BuscarDestino(string ciudad)
        {
            int i = 0;
            Destino destino = null;
            while (destino == null && i < destinos.Count)
            {
                if (destinos[i].Ciudad == ciudad)
                {
                    destino = destinos[i];
                }
                i++;
            }
            return destino;
        }
        //Ultimo Método actualizado de Agregar Destino
        public bool AgregarDestinos(string ciudad, string pais, decimal costo, decimal cantidadDias)
        {
            bool exito = false;
            if (BuscarDestino(ciudad) == null)
            {
                Destino unDestino = new Destino(ciudad, pais, costo, cantidadDias);
                destinos.Add(unDestino);
                exito = true;
            }
            return exito;
        }

        public List<Destino> DevolverDestino(string ciudad, string pais, string ciudad2, string pais2)
        {
            List<Destino> aux = new List<Destino>();
            foreach (Destino unDestino in destinos)
            {
                if (unDestino.Ciudad == ciudad && unDestino.Pais == pais || unDestino.Ciudad == ciudad2 && unDestino.Pais == pais2)
                {
                    aux.Add(unDestino);
                }
            }
            return aux;
        }
    }
}
