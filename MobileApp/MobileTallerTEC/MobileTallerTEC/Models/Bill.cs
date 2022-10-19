using System;
using System.Collections.Generic;
using System.Text;

namespace MobileTallerTEC.Models
{
    /*
     * Clase Bill
     * Estructura de la entidad de Factura
     */
    public class Bill
    {
        /*
         *  service: Nombre del servicio a facturar
	        cost: Costo a facturar 
	        mecanic: Mecánico encargado de la cita a facturar
	        date: Fecha de la factura
	        licensePlate: Número de placa de la cita a facturar
         */
        public string service { get; set; }
        public int cost { get; set; }
        public string mecanic { get; set; }
        public string date { get; set; }

        public string licensePlate { get; set; }
    }
}
