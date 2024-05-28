using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_lenguaje_1
{
    class Menu
    {
       private int anchoVentana = Console.WindowWidth;
       private string[] lineasMenu = {
                "=================================",
                "          Menú de Opciones       ",
                "=================================",
                "1. Opción 1 Conversion (Letras)  ",
                "2. Opción 2 Evaluar (Numeros)    ",
                "3. Salir                         ",
                "=================================",
                "Selecciona una opción: "
            };
       
        public Menu()
        {
            Console.Clear(); // Limpiar la pantalla antes de mostrar el menú
         
            foreach (string linea in lineasMenu)
            {
                int espaciosParaCentrar = (anchoVentana - linea.Length) / 2;
                Console.WriteLine(new string(' ', espaciosParaCentrar) + linea);
            }

        }
    }
}
