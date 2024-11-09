using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Inventario
{
    public class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public Producto(string nombre, double precio) 
        {
            Nombre = nombre;
            Precio = precio;
        }

        public string MostrarInformacion () 
        {
            return $"Producto: {Nombre}, Precio: {Precio}";
        }
    }
}
