using System;
using System.Collections.Generic;

struct Producto
{
    public string Codigo;
    public string Nombre;
    public int Cantidad;
    public decimal Precio;

    public Producto(string codigo, string nombre, int cantidad, decimal precio)
    {
        Codigo = codigo;
        Nombre = nombre;
        Cantidad = cantidad;
        Precio = precio;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Producto> inventario = new List<Producto>();
        int opcion;

        do
        {
            Console.WriteLine("Menú de opciones:");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Eliminar producto");
            Console.WriteLine("3. Modificar producto");
            Console.WriteLine("4. Consultar producto");
            Console.WriteLine("5. Mostrar todos los productos");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarProducto(inventario);
                    break;
                case 2:
                    EliminarProducto(inventario);
                    break;
                case 3:
                    ModificarProducto(inventario);
                    break;
                case 4:
                    ConsultarProducto(inventario);
                    break;
                case 5:
                    MostrarProductos(inventario);
                    break;
                case 6:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    break;
            }

        } while (opcion != 6);
    }

    static void AgregarProducto(List<Producto> inventario)
    {
        Console.Write("Ingrese el código del producto: ");
        string codigo = Console.ReadLine();
        Console.Write("Ingrese el nombre del producto: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese la cantidad: ");
        int cantidad = Convert.ToInt32(Console.ReadLine());
        Console.Write("Ingrese el precio: ");
        decimal precio = Convert.ToDecimal(Console.ReadLine());

        Producto nuevoProducto = new Producto(codigo, nombre, cantidad, precio);
        inventario.Add(nuevoProducto);
        Console.WriteLine("Producto agregado correctamente.");
    }

    static void EliminarProducto(List<Producto> inventario)
    {
        Console.Write("Ingrese el código del producto a eliminar: ");
        string codigo = Console.ReadLine();
        Producto? productoAEliminar = ConsultarProductoPorCodigo(inventario, codigo);

        if (productoAEliminar.HasValue)
        {
            inventario.Remove(productoAEliminar.Value);
            Console.WriteLine("Producto eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    static void ModificarProducto(List<Producto> inventario)
    {
        Console.Write("Ingrese el código del producto a modificar: ");
        string codigo = Console.ReadLine();
        Producto? productoAModificar = ConsultarProductoPorCodigo(inventario, codigo);

        if (productoAModificar.HasValue)
        {
            // Modificar nombre
            Console.Write("Ingrese el nuevo nombre: ");
            string nuevoNombre = Console.ReadLine();

            Console.Write("Ingrese la nueva cantidad: ");
            int nuevaCantidad = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el nuevo precio: ");
            decimal nuevoPrecio = Convert.ToDecimal(Console.ReadLine());

            // Modificar los datos del producto
            Producto modificado = productoAModificar.Value;
            modificado.Nombre = nuevoNombre;  // Modificar el nombre
            modificado.Cantidad = nuevaCantidad;
            modificado.Precio = nuevoPrecio;

            // Reemplazar el producto en la lista
            int index = inventario.IndexOf(productoAModificar.Value);
            inventario[index] = modificado;

            Console.WriteLine("Producto modificado correctamente.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }


    static void ConsultarProducto(List<Producto> inventario)
    {
        Console.Write("Ingrese el código del producto a consultar: ");
        string codigo = Console.ReadLine();
        Producto? producto = ConsultarProductoPorCodigo(inventario, codigo);

        if (producto.HasValue)
        {
            Console.WriteLine($"Código: {producto.Value.Codigo}, Nombre: {producto.Value.Nombre}, Cantidad: {producto.Value.Cantidad}, Precio: {producto.Value.Precio:C}");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    static Producto? ConsultarProductoPorCodigo(List<Producto> inventario, string codigo)
    {
        foreach (var producto in inventario)
        {
            if (producto.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase))
            {
                return producto;
            }
        }
        return null; // Producto no encontrado
    }

    static void MostrarProductos(List<Producto> inventario)
    {
        Console.WriteLine("Productos en el inventario:");
        if (inventario.Count == 0)
        {
            Console.WriteLine("El inventario está vacío.");
            return;
        }

        foreach (var producto in inventario)
        {
            Console.WriteLine($"Código: {producto.Codigo}, Nombre: {producto.Nombre}, Cantidad: {producto.Cantidad}, Precio: {producto.Precio:C}");
        }
    }
}
