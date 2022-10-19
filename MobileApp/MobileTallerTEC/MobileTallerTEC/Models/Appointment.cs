using System;
using System.Collections.Generic;

namespace MobileTallerTEC.Models
{
    /*
     * Clase Appointment
     * Estructura de la entidad de Cita
     */
    public class Appointment
    {
        /*
         * Responsible: Número de cédula del trabajador responsable de la cita
        	Assistant: Número de cédula del trabajador asistente de la cita
        	LicensePlate:  Placa del vehículo al cual se le reserva la cita
        	Service: Servicio a realizar en la cita
        	Client: Número de cédula del cliente  
        	Office: Sucursal en la cual se realizará la cita 
        	Date: Fecha en la cual la cita es asignada
        	Replacements: Repuestos necesarios para la cita
         */
        public string responsible { get; set; }
        public string assistant { get; set; }
        public string licensePlate { get; set; }
        public string service { get; set; }
        public string client { get; set; }
        public string office { get; set; }
        public string date { get; set; }
        public List<Replacements> replacements { get; set; }

    }
    /*
     * Clase Replacements
     * Estructura de la relacion entre repuesto y cita
     */
    public class Replacements
    {
        /*
         * LicensePlate: Placa del carro al cual se le asignan los repuestos y la cita
	       Replacement: Repuesto necesario para la cita

         */
        public string LicensePlate { get; set; }
        public string Replacement { get; set; }

    }
}
