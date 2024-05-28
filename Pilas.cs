using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_lenguaje_1
{
    public class Pilas
    {
        private object[] elementos;
        private int tope;

        public Pilas(int tamaño)
        {
            elementos = new object[tamaño];
            tope = -1;
        }

        public void Push(object elemento)
        {
            if (tope < elementos.Length - 1)
            {
                elementos[++tope] = elemento;
            }
            else
            {
                throw new InvalidOperationException("La pila está llena.");
            }
        }

        public object Pop()
        {
            if (tope >= 0)
            {
                return elementos[tope--];
            }
            else
            {
                throw new InvalidOperationException("La pila está vacía.");
            }
        }

        public bool Vacia()
        {
            return tope == -1;
        }
        public object PopTope()
        {
            if (tope >= 0)
            {
                return elementos[tope];
            }
            else
            {
                throw new InvalidOperationException("La pila está vacía.");
            }
        }
    }

}


