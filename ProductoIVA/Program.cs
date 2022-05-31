using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoIVA
{
    internal class Program
    {
        public static string[] productosTienda = { "Lápiz,", "Lapicero", "Maquinilla", "Computadora", "Teléfono celular", "Cuaderno" };
        public static double[] precios_Productos = { 200, 750, 300, 500000, 350000, 1850 };
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    ejecutar_sistema();
                    break;
                }catch(Exception e)
                {
                    Console.WriteLine("***************************************\n"+
                                      "* POR FAVOR INGRESE VALORES NUMERICOS *\n"+
                                      "***************************************\n"+
                                      "* Error: "+e);

                    Console.WriteLine("\n***************************************\n" +
                                      "*    PRESIONE ENTER PARA CONTINUAR    *\n" +
                                      "***************************************\n");
                    Console.ReadKey();
                    Console.Clear();
                }

            }

        }
        public static void muestra_proposito()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------" +
                           "\n| Este programa tiene como fin calcular y mostrar el precio que deberá pagar por un |\n" +
                             "| producto incluyendo el IVA.                                                       |\n" +
                             "-------------------------------------------------------------------------------------");
        }
        public static int menu_productos()
        {
            int opcion = 0;
            Console.WriteLine("| PRODUCTOS |\n"+
                              "*************\n");
            for (int i = 0; i < productosTienda.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + productosTienda[i]);
            }
            Console.WriteLine("--------------------------------------------------\n"
                             +"Ingrese el numero del producto que desea comprar:");
            opcion = int.Parse(Console.ReadLine());
            Console.WriteLine("--------------------------------------------------\n");
            //Console.Clear();
            return opcion;
        }

        public static (string, double, double, double, double) calculaPrecio(int opcion)
        {
            string producto_comprar = "";
            double precio_articulo = 0;
            
            double monto_iva;
            
            double monto_descuento;
            double precio_final;

            for (int i = 0; i < productosTienda.Length; i++)
            {
                if ((opcion - 1) == i)
                {
                    producto_comprar = productosTienda[i];
                    precio_articulo = precios_Productos[i];
                    break;
                }
            }
            monto_iva = precio_articulo * 0.13;
            monto_descuento = precio_articulo * 0.05;
            precio_final = (precio_articulo - monto_descuento) + monto_iva;

            return (producto_comprar, precio_articulo, monto_iva, monto_descuento, precio_final);
        }

        public static void muestra_precios(string nombre_articulo, double precio_inicial, double monto_iva, double monto_descuento,
            double precio_final)
        {
            Console.WriteLine("----------------------"+
                            "\n| DETALLE DE PRECIOS |\n" +
                              "-----------------------------------------------------\n" +
                              "| Nombre producto ............ " + nombre_articulo + "\n" +
                              "| Precio Oficial ............. " + precio_inicial + "\n" +
                              "| Monto de IVA ............... " + monto_iva + "\n" +
                              "| Monto de descuento ......... " + monto_descuento + "\n" +
                              "| Precio final ............... " + precio_final+"\n"+
                              "-----------------------------------------------------");

        }

        public static int menu_principal() {
            int opcion = 0;
            Console.WriteLine("----------------------------\n" +
                              "|       MENU PRINCIPAL     |\n" +
                              "............................\n" +
                              "| 1. Comprar articulo      |\n" +
                              "| 2. Salir del programa    |\n" +
                              "----------------------------\n");
            Console.WriteLine("Ingrese la opcion que desea ejecutar: ");
            opcion = int.Parse(Console.ReadLine());
            return opcion;
        
        }

        public static void ejecutar_sistema()
        {
            int opcion_menu = 0;
            while (opcion_menu < 2)
            {
                opcion_menu = menu_principal();
                if(opcion_menu < 2)
                {
                    muestra_proposito();
                }

                switch (opcion_menu)
                {
                    case 1:
                        
                        (string nombre_articulo, double precio_inicial, double monto_iva, double monto_descuento,double precio_final) =  calculaPrecio(menu_productos());
                        muestra_precios(nombre_articulo,precio_inicial, monto_iva, monto_descuento, precio_final);
                        Console.WriteLine("Presione cualquier tecla para volver al menú principal.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                        
                    case 2:
                        Console.WriteLine("-------------------------------------------" +
                                        "\n|              ¡Hasta Pronto!             |");
                      Console.WriteLine("\n| Presione cualquier teclas para salir... |" +
                                        "\n-------------------------------------------");
                        Console.ReadKey();
                        break;
                }
            }
        }



    }
}
