using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_lenguaje_1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                // Mostrar el menu
                Menu menu = new Menu();

                // Colocar el cursor después de Selecciona una opción
                int filaSeleccion = Console.CursorTop - 1;
                int longitudSeleccion= "Selecciona una opción: ".Length;
                int espaciosParaCentrar = (Console.WindowWidth - longitudSeleccion) / 2;
                Console.SetCursorPosition(espaciosParaCentrar + longitudSeleccion, filaSeleccion);

                // Leer la opciIon
                string entradaUsuario = Console.ReadLine();

                // Procesar la opcion
                switch (entradaUsuario)
                {
                    case "1":
                        Console.WriteLine("Ingrese una expresión:");
                        string expresion = Console.ReadLine();
                        EvaluadorDeExpresion evaluador = new EvaluadorDeExpresion(expresion);
                        string resultado = evaluador.Evaluar();

                        if (!string.IsNullOrEmpty(resultado))
                        {
                            Console.WriteLine("Resultado de la transformación: " + resultado);

                        }
                        else
                        {
                            Console.WriteLine("La expresión ingresada es inválida.");

                        }
                            Console.ReadLine();
                        break;

                    case "2":
                        Console.WriteLine("Ingrese una expresión:");
                        string expresion2 = Console.ReadLine();
                        EvaluadorDeNumeros evaluador2 = new EvaluadorDeNumeros(expresion2);
                        int resultado2 = evaluador2.Evaluar();
                        if (resultado2 != 0)
                        {
                            Console.WriteLine("El resultado de la expresión " + expresion2 + " es: " + resultado2);
                        }

                        Console.ReadLine();

                        break;
                    case "3":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, elige una opción del 1 al 4.");
                        break;
                }
            }

            Console.WriteLine("Gracias por usar la aplicación. ¡Adiós!");
        }
    }
}
