using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Inventario
{
    class Program
    {
        public static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            Console.WriteLine("Bienvenido al Sistema de Gestion de Inventario: ");

            //Ingreso de productos por el usuario
            Console.WriteLine("¿Cuantos productos va a ingresar? ");
            int cantidad = int.Parse(Console.ReadLine());

            // Se ocupa el cielo for para pedir exactamente la cantidad de productos que sea ingresar el usuario.
            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"\n Ingrese el producto {i + 1}: ");
                Console.WriteLine($"Nombre del producto: (agregue _ en lugar de espacios)");
                string nombre = Console.ReadLine();

                Console.WriteLine($"Ingrese el Precio del Producto en dolares: ");
                double precio = double.Parse(Console.ReadLine());

                Producto producto = new Producto(nombre, precio);
                inventario.AgregarProductos(producto);
            }

            //Ingrear el precio minimo para el filtro
            Console.WriteLine("\nIngrese el precio minimo para filtrar los productos: ");
            double precioMinimo = double.Parse(Console.ReadLine());

            // Filtrar y mostrar productos
            var productosFiltrados = inventario.FiltrarYordenarProductos(precioMinimo);

            Console.WriteLine("\nLos productos filtrados y ordenados de menor a mayor: ");
            foreach (var producto in productosFiltrados)
            {
                Console.WriteLine($"Nombre del Producto: {producto.Nombre}, Precio: {producto.Precio}");
            }

            //Para solicitar al usuario que seleccione una de las funciones
            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("\nSeleccione una de las funciones que desea realizar: ");
                Console.WriteLine("1.Ver Inventario de productos");
                Console.WriteLine("2. Eliminar Producto");
                Console.WriteLine("3. Actualizar Precio de un Producto.");
                Console.WriteLine("4. Agrupar Productos.");
                Console.WriteLine("5. Reportes de Inventario.");
                Console.WriteLine("6. Salir del programa.");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {

                    case 1: Console.WriteLine("\n Has seleccionado ver el inventari: ");

                        inventario.MostrarProductos();

                        break;
                    case 2: Console.WriteLine($"\nHas seleccionado elimiar producto");
                        //Ingresar el nombre del producto a eliminar
                        Console.WriteLine("Ingrese el nombre del producto que desea eliminar:          (No agregar espacios)");
                        string nombre = Console.ReadLine() ;

                        while(string.IsNullOrWhiteSpace(nombre))    //valida que si el usuario deja el nombre en blanco le solicite poner un nombre valido
                        {
                            Console.WriteLine($"EL Nombre no puede quedar vacio o tener espacios, intentelo de nuevo");
                            nombre = Console.ReadLine();
                        }

                        //Buscar el producto y eliminarlo
                        var EliminarProducto = inventario.EliminarProducto(nombre);
                        foreach(var productoeliminado in EliminarProducto)
                        {
                            Console.WriteLine($"El Nombre del producto eliminado es: {productoeliminado.Nombre}");
                        }

                        Console.WriteLine("\nInventario despues de eliminar el producto: ");
                        inventario.MostrarProductos();

                        break;

                    case 3: Console.WriteLine("\nHas Seleccionado Actualizar el precio de producto");
                        Console.WriteLine("Ingresa el nombre del producto al que le quieres actualizar precio: ");
                        string nombreProducto = Console.ReadLine() ;

                        while (string.IsNullOrWhiteSpace(nombreProducto))
                        {
                            Console.WriteLine($"EL Nombre no puede quedar vacio o tener espacios, intentelo de nuevo");
                            nombreProducto = Console.ReadLine();
                        }

                        Console.WriteLine("Ingrese el nuevo precio en dolares: ");
                        double precioProducto = double.Parse(Console.ReadLine());

                        while (precioProducto < 0)
                        {
                            Console.WriteLine("El nuevo precio del prodcuto debe ser positivo, intentelo de nuevo");
                            precioProducto = double.Parse (Console.ReadLine());
                        }

                        var productoActualizado = inventario.ActualizarPrecio(nombreProducto, precioProducto);
                        Console.WriteLine($"\nEl producto actualizado es: {nombreProducto}, con nuevo precio de: {precioProducto} $");

                        Console.WriteLine("El inventario con los cambios realizados: ");
                        inventario.MostrarProductos();
                        break;

                    case 4: Console.WriteLine("\nHas seleccionado agrupar productos");
                        bool continuarconAgrupacion = true;

                        while (continuarconAgrupacion)
                        {
                            Console.WriteLine("Selecciona una opcion para agruparlos: ");
                            Console.WriteLine("1. Menores a 100 $");
                            Console.WriteLine("2. Entre 100 y 500 dolares agrupados de mayor a menor.");
                            Console.WriteLine("3. Mayores a 500 dolares.");
                            Console.WriteLine("Salir de la agrupacion.");
                            int opcionAgrupar = int.Parse(Console.ReadLine());

                            switch (opcionAgrupar)
                            {
                                case 1:
                                    Console.WriteLine("\n Has seleccionado menores a 100$");

                                    var productosOrdenados = inventario.Menoresde100dolares();
                                    Console.WriteLine("Los productos cuyo precio es menor a 100 dolares son: ");
                                    foreach (var productos in productosOrdenados)
                                    {
                                        productos.MostrarInformacion();
                                    }

                                    break;

                                case 2:
                                    Console.WriteLine("\n Has Seleccionado los productos cuyo precio esta entre 100 y 500 dolares:");

                                    var productosOrdenados100a500 = inventario.Entre500_y_100dolares();
                                    Console.WriteLine("Los productos cuyo precio esta entre 100 y 500 dolares son: ");
                                    foreach (var productos100a500 in productosOrdenados100a500)
                                    {
                                        productos100a500.MostrarInformacion();
                                    }

                                    break;

                                case 3: Console.WriteLine("Has seleccionado Mayores a 500 dolares");

                                    var productosMayoresde5000 = inventario.MayoresA500dolares();
                                    Console.WriteLine("Los producto cuyo precio es mayor a 500 dolares son: ");
                                    foreach(var productosmayores500 in productosMayoresde5000)
                                    {
                                        productosmayores500.MostrarInformacion();
                                    }

                                    break;

                                case 4: Console.WriteLine("Has salido de las opciones de agrupacion");

                                    continuarconAgrupacion = false;

                                    break;
                            }


                        }

                        
                        break;

                    case 5: Console.WriteLine("\n Has Seleccionado reporte de inventario");

                        bool continuarReporte = true;
                        while (continuarReporte)
                        {
                            Console.WriteLine("Selecciona una opcion:");
                            Console.WriteLine("1. Numero Total de productos.");
                            Console.WriteLine("2. Promedio del precio de los productos");
                            Console.WriteLine("3. Producto con el precio mas bajo y mas alto.");
                            Console.WriteLine("Regresar al menu anterior.");
                            int opcionReporte = int.Parse(Console.ReadLine());

                            switch (opcionReporte)
                            {
                                case 1:
                                    int total = inventario.ObtenerTotalProductos();
                                    Console.WriteLine($" El total de productos en el inventario es de: {total}");

                                    break;

                                case 2:
                                    Console.WriteLine("El promedio del precio de los productos es de: ");

                                    double promedio = inventario.PromedioPrecios();


                                    break;
                                case 3:
                                    double precioMax = inventario.PrecioMaximo();

                                    Console.WriteLine($"El precio maximo es de: {precioMax}");

                                    double precioMin = inventario.PrecioMinimo();
                                    Console.WriteLine($"El precio minimo es de: {precioMin}");

                                    break;

                                case 4:

                                    continuarReporte = false;

                                    break;

                            }

                        }

                    break ;

                    case 6: Console.WriteLine($"\nHas Salido del Programa");

                        continuar = false;
                        break;

                }

            }
        }
    }
}
