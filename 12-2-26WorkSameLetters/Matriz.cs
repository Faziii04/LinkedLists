using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_2_26WorkSameLetters
{
    internal class Matriz
    {
        // Creacion
        // Insercion
        // Recorrido
        // Busqueda
        // Ordenacion
        // Borrado
        internal Matriz() { }

        internal int?[,] CreacionMatrizRnd(int rows, int cols)
        {
            int?[,] matrix = new int?[rows, cols];
            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = random.Next(1, 1000);

                }
            }
            return matrix;
        }

        internal int?[,] CreacionMatrizManual(int rows, int cols)
        {
            int?[,] matrix = new int?[rows, cols];
            Console.WriteLine($"\n--- Entrada Manual: {rows}x{cols} ---");
            Console.WriteLine($"Escriba los {cols} números separados por espacio y presione Enter.\n");

            for (int i = 0; i < rows; i++)
            {
                bool rowSuccess = false;
                while (!rowSuccess) 
                {
                    Console.Write($"Fila {i + 1}/{rows}: ");
                    string input = Console.ReadLine() ?? "";

                    string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length != cols)
                    {
                        Console.WriteLine($"Error: Se esperaban {cols} elementos, pero recibí {parts.Length}. Reintente.");
                        continue;
                    }

                    try
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            matrix[i, j] = int.Parse(parts[j]);
                        }
                        rowSuccess = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error: Uno de los elementos no es un número válido. Reintente.");
                    }
                }
            }
            Console.WriteLine("Matriz cargada con éxito.");
            return matrix;
        }


        internal void MostrarMatriz(int?[,] matrix)
        {
            for (int i = 0; matrix.GetLength(0) > i; i++)
            {
                for (int j = 0; matrix.GetLength(1) > j; j++)
                {
                    Console.Write($"[{matrix[i, j]}] ");
                }
                Console.Write("\n");
            }
        }
        internal void EncontrarElemento(int target, int?[,] matrix)
        {
            bool found = false;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == target)
                    {
                        Console.WriteLine($"Objeto: {target} encontrado en el indice: [{i + 1}, {j + 1}]");
                        found = true;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine($"El numero {target} no existe en la matriz actual.");
            }
        }


        internal void BorrarElemento(int target, int?[,] matrix)
        {
            bool foundAtLeastOne = false;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == target)
                    {
                        matrix[i, j] = null;
                        foundAtLeastOne = true;

                        Console.WriteLine($"Objeto: {target} fue borrado en el indice: [{i + 1}, {j + 1}]");
                    }
                }
            }

            if (!foundAtLeastOne)
            {
                Console.WriteLine($"El numero {target} no se encuentra en la matriz.");
            }
        }




    }

    }
