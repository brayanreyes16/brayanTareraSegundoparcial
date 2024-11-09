using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Inventario
{
    public class Inventario
    {
        private List<Producto> productos;

        public Inventario() 
        {
            productos = new List<Producto>();
        }

        public void AgregarProductos(Producto producto) 
        {
            productos.Add(producto);
        }
        public void MostrarProductos() 
        {
            foreach (var producto in productos) 
            {
                Console.WriteLine(producto.MostrarInformacion());
            }
        }

        public IEnumerable<Producto> FiltrarYordenarProductos(double precioMinimo)
        {
            return productos
                .Where(p => p.Precio > precioMinimo)
                .OrderBy(p => p.Precio);

        }
        public IEnumerable<Producto> EliminarProducto(string nombre)
        {
            var  productoAeliminar = productos
                .Where (p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase) )
                .ToList(); //Hace que al eliminar el producto se cree una nueva lista sin el producto para evitar errores de modificacion al eliminar el prodcuto
            
            
            foreach(var producto in productoAeliminar) 
            {
                productos.Remove(producto);
            }

            return productoAeliminar; // Se retorna la lista con el producto ya eliminado de la lista
        }

        
        public IEnumerable<Producto> ActualizarPrecio(string nombreProducto, double precioProducto)
        {
            var productoAactualizar = productos
                .FirstOrDefault(p => p.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase)); //Busca directamente el nombre del producto y devuelve el primer elemento que cumpla la condicion

            if (productoAactualizar != null)
            {
                productoAactualizar.Precio = precioProducto;
                Console.WriteLine($"El Precio del producto: {productoAactualizar.Nombre} ha actualizado su precio a: {productoAactualizar.Precio} $");
            }
            else 
            {
                Console.WriteLine($"NO SE ENCONTRO EL PRODUCTO CON EL NOMBRE: {nombreProducto}");
            }
            return productos; //Retorna la lista de productos con los cambios realizados
                
        }

        //agrupar los productos menores a 100 dolares
        public IEnumerable<Producto> Menoresde100dolares() 
        {
            return productos
                .Where(p => p.Precio < 100)
                .ToList();
        }

        //agrupar los productos entre 100 y 500 dolares y ordenarlos de mayor a menor
        public IEnumerable<Producto> Entre500_y_100dolares()
        {
            return productos
                .Where(p => p.Precio >= 100 && p.Precio <= 500)
                .OrderByDescending(p => p.Precio);  // los ordena de mayor a menor
        }

        //agrupar los productos mayores a 500 dolares
        public IEnumerable<Producto> MayoresA500dolares() 
        {
            return productos
                .Where(p => p.Precio > 500)
                .OrderByDescending (p => p.Precio);
        }

        public int ObtenerTotalProductos()
        {
            return productos.Count();
        }

        public double PromedioPrecios()
        {
            return productos.Average(p => p.Precio);
        }

        public double PrecioMaximo()
        {
            return productos.Max(p => p.Precio);
        }

        public double PrecioMinimo()
        {
            return productos.Min(p => p.Precio);
        }
    }
}
