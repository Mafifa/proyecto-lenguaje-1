using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_lenguaje_1
{
    public class EvaluadorDeExpresion
    {
        private string expresion;
        private Pilas pila;
        private string resultado;
        private int balanceParentesis;

        public EvaluadorDeExpresion(string expresion)
        {
            this.expresion = expresion;
            this.pila = new Pilas(expresion.Length);
            this.resultado = "";
            this.balanceParentesis = 0;
        }

        public string Evaluar()
        {
            for (int i = 0; i < expresion.Length; i++)
            {
                char caracter = expresion[i];

                if (char.IsLetter(caracter))
                {
                    pila.Push(caracter);
                }
                else if ("+-*/^".Contains(caracter))
                {
                    if (i == 0 || "+-*/^".Contains(expresion[i - 1]) || expresion[i - 1] == '(')
                    {
                        Console.WriteLine("Expresión mal escrita: operador sin operando anterior.");
                        Console.ReadLine();
                        return "";
                    }
                    pila.Push(caracter);
                }
                else if (caracter == '(')
                {
                    balanceParentesis++;
                    if (i > 0 && char.IsLetter(expresion[i - 1]))
                    {
                        Console.WriteLine("Expresión mal escrita: letra antes del paréntesis.");
                        Console.ReadLine();
                        return "";
                    }
                }
                else if (caracter == ')')
                {
                    balanceParentesis--;
                    if (balanceParentesis < 0)
                    {
                        Console.WriteLine("Expresión mal escrita: paréntesis desbalanceados.");
                        Console.ReadLine();
                        return "";
                    }
                    if (i > 0 && expresion[i - 1] == '(')
                    {
                        Console.WriteLine("Expresión mal escrita: paréntesis vacíos.");
                        Console.ReadLine();
                        return "";
                    }

                    if (pila.Vacia())
                    {
                        Console.WriteLine("Expresión mal escrita: falta operando.");
                        Console.ReadLine();
                        return "";
                    }
                    char op2 = (char)pila.Pop();

                    if (pila.Vacia())
                    {
                        Console.WriteLine("Expresión mal escrita: falta operador.");
                        Console.ReadLine();
                        return "";
                    }
                    char operador = (char)pila.Pop();
                    if (!"+-*/^".Contains(operador))
                    {
                        Console.WriteLine("Operador inválido: " + operador);
                        Console.ReadLine();
                        return "";
                    }

                    if (pila.Vacia())
                    {
                        Console.WriteLine("Expresión mal escrita: falta operando.");
                        Console.ReadLine();
                        return "";
                    }
                    char op1 = (char)pila.Pop();

                    resultado += op1;
                    resultado += op2;
                    resultado += operador;
                }
                else
                {
                    Console.WriteLine("Caracter inválido en la expresión: " + caracter);
                        Console.ReadLine();

                    return "";
                }
            }

            if (balanceParentesis != 0)
            {
                Console.WriteLine("Expresión mal escrita: paréntesis desbalanceados.");
                Console.ReadLine();

                return "";
            }

            if (!pila.Vacia() && "+-*/^".Contains((char)pila.Pop()))
            {
                Console.WriteLine("Expresión mal escrita: operador sin operandos.");
                Console.ReadLine(); 

                return "";
            }

            return resultado;
        }
    }
}
