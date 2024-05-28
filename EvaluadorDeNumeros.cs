using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_lenguaje_1
{

    public class EvaluadorDeNumeros
    {
        private string expresion;
        private Pilas pila;
        private int balanceParentesis;

        public EvaluadorDeNumeros(string expresion)
        {
            this.expresion = expresion;
            this.pila = new Pilas(expresion.Length);
            this.balanceParentesis = 0;
        }

        public int Evaluar()
        {
            for (int i = 0; i < expresion.Length; i++)
            {
                char caracter = expresion[i];

                if (char.IsDigit(caracter))
                {
                    int numero = 0;
                    while (i < expresion.Length && char.IsDigit(expresion[i]))
                    {
                        numero = numero * 10 + (expresion[i] - '0');
                        i++;
                    }
                    i--;

                    pila.Push(numero);
                }
                else if ("+-*/^".Contains(caracter))
                {
                    if (i == 0 || "+-*/^".Contains(expresion[i - 1]) || expresion[i - 1] == '(')
                    {
                        Console.WriteLine("Expresión mal escrita: operador sin operando anterior.");
                        return 0;
                    }
                    pila.Push(caracter);
                }
                else if (caracter == '(')
                {
                    balanceParentesis++;
                    if (i > 0 && (char.IsDigit(expresion[i - 1]) || expresion[i - 1] == ')'))
                    {
                        Console.WriteLine("Expresión mal escrita: número o paréntesis antes del paréntesis.");
                        return 0;
                    }
                }
                else if (caracter == ')')
                {
                    balanceParentesis--;
                    if (balanceParentesis < 0)
                    {
                        Console.WriteLine("Expresión mal escrita: paréntesis desbalanceados.");
                        return 0;
                    }
                    if (i > 0 && expresion[i - 1] == '(')
                    {
                        Console.WriteLine("Expresión mal escrita: paréntesis vacíos.");
                        return 0;
                    }

                    if (pila.Vacia())
                    {
                        Console.WriteLine("Expresión mal escrita: falta operando.");
                        return 0;
                    }
                    int op2 = Convert.ToInt32(pila.Pop());

                    if (pila.Vacia())
                    {
                        Console.WriteLine("Expresión mal escrita: falta operador.");
                        return 0;
                    }
                    char operador = Convert.ToChar(pila.Pop());
                    if (!"+-*/^".Contains(operador))
                    {
                        Console.WriteLine("Operador inválido: " + operador);
                        return 0;
                    }

                    if (pila.Vacia())
                    {
                        Console.WriteLine("Expresión mal escrita: falta operando.");
                        return 0;
                    }
                    int op1 = Convert.ToInt32(pila.Pop());

                    int resultadoTemp = RealizarOperacion(op1, op2, operador);
                    if (resultadoTemp == int.MinValue) // Error al dividir por 0
                    {
                        Console.WriteLine("Error: División por cero.");
                        return 0;
                    }

                    pila.Push(resultadoTemp);
                }
                else
                {
                    Console.WriteLine("Caracter inválido en la expresión: " + caracter);
                    return 0;
                }
            }

            if (balanceParentesis != 0)
            {
                Console.WriteLine("Expresión mal escrita: paréntesis desbalanceados.");
                return 0;
            }

            if (!pila.Vacia())
            {
                object top = pila.Pop();
                if (top is char operador && "+-*/^".Contains(operador))
                {
                    Console.WriteLine("Expresión mal escrita: operador sin operandos.");
                    return 0;
                }
                return Convert.ToInt32(top);
            }

            return 0;
        }

        private int RealizarOperacion(int op1, int op2, char operador)
        {
            switch (operador)
            {
                case '+':
                    return op1 + op2;
                case '-':
                    return op1 - op2;
                case '*':
                    return op1 * op2;
                case '/':
                    if (op2 == 0)
                        return int.MinValue; // Indicador de error al dividir por 0
                    return op1 / op2;
                case '^':
                    return (int)Math.Pow(op1, op2);
                default:
                    return 0; // Operador no reconocido
            }
        }
    }

}
