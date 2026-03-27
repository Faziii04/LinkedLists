using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _12_2_26WorkSameLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialize class instances for vector, matrix and math operations
            Matriz matrixHandler = new Matriz();
            Vector vectorHandler = new Vector();
            
            int?[] currentArr = null;
            int?[,] currentMatrix = null;
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║          SISTEMA INTEGRAL DE PROCESAMIENTO DE DATOS EN C#                      ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════╝");
                Console.ResetColor();

                Console.WriteLine("\n┌─ [ VECTORES / ARRAYS ] ─────────────────────────┐  ┌─ [ MATRICES ] ──────────────┐");
                Console.WriteLine("│  1. Probar Anagramas                            │  │ 12. Crear Matriz Rnd       │");
                Console.WriteLine("│  2. Crear Array Rnd                             │  │ 13. Crear Matriz Manual    │");
                Console.WriteLine("│  3. Crear Array Manual                          │  │ 14. Mostrar Matriz         │");
                Console.WriteLine("│  4. Mostrar Array                               │  │ 15. Buscar en Matriz       │");
                Console.WriteLine("│  5. Buscar en Array                             │  │ 16. Eliminar de Matriz     │");
                Console.WriteLine("│  6. Eliminar de Array                           │  │                            │");
                Console.WriteLine("│  7. Ordenar - BubbleSort                        │  │ ┌─ [ MATEMÁTICAS ] ────────┤");
                Console.WriteLine("│  8. Ordenar - ShellSort                         │  │ │ 17. Validar Sudoku        │");
                Console.WriteLine("│  9. Ordenar - QuickSort                         │  │ │ 18. Invertir Matriz        │");
                Console.WriteLine("│ 10. Buscar Anagrama                             │  │ │ 19. Resolver Ecuaciones    │");
                Console.WriteLine("│ 11. Info de Array                               │  │ │ 20. Info de Array          │");
                Console.WriteLine("└─────────────────────────────────────────────────┘  └────────────────────────────┘");
                Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║  0. SALIR");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════╝");
                Console.Write("\n>>> Seleccione una opción: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ProbarAnagramas(vectorHandler);
                        break;

                    case "2":
                        int nro = GetSafeInt("\nCantidad de elementos del array: ");
                        currentArr = vectorHandler.CrearVectorRnd(nro);
                        break;

                    case "3":
                        currentArr = vectorHandler.CrearVectorManual();
                        break;

                    case "4":
                        vectorHandler.RecorridoVector(currentArr);
                        break;

                    case "5":
                        if (currentArr != null)
                        {
                            int target = GetSafeInt("\nNúmero a buscar: ");
                            vectorHandler.BusquedaVector(currentArr, target);
                        }
                        else Console.WriteLine("\n[!] Error: Primero crea un array.");
                        break;

                    case "6":
                        if (currentArr != null)
                        {
                            int targetDel = GetSafeInt("\nNúmero a eliminar: ");
                            currentArr = vectorHandler.EliminarElemento(currentArr, targetDel);
                            Console.WriteLine("✔ Elemento eliminado.");
                        }
                        else Console.WriteLine("\n[!] Error: Primero crea un array.");
                        break;

                    case "7":
                        if (currentArr != null)
                        {
                            currentArr = vectorHandler.BubbleSort(currentArr);
                        }
                        else Console.WriteLine("\n[!] Error: Primero crea un array.");
                        break;

                    case "8":
                        if (currentArr != null)
                        {
                            int?[] intArr = vectorHandler.ShellSort(currentArr);
                            currentArr = intArr.Cast<int?>().ToArray();
                        }
                        else Console.WriteLine("\n[!] Error: Primero crea un array.");
                        break;

                    case "9":
                        if (currentArr != null)
                        {
                            currentArr = vectorHandler.QuickSort(currentArr);
                        }
                        else Console.WriteLine("\n[!] Error: Primero crea un array.");
                        break;

                    case "10":
                        Console.Write("\nPalabra 1: ");
                        string p1 = Console.ReadLine();
                        Console.Write("Palabra 2: ");
                        string p2 = Console.ReadLine();
                        if (vectorHandler.SonAnagramas(p1, p2))
                            Console.WriteLine("✔ Las palabras SON anagramas.");
                        else
                            Console.WriteLine("[!] Las palabras NO son anagramas.");
                        break;

                    case "11":
                        MostrarInfoArray(currentArr);
                        break;

                    case "12":
                        int r1 = GetSafeInt(" Cantidad de Filas: ");
                        int c1 = GetSafeInt(" Cantidad de Columnas: ");
                        currentMatrix = matrixHandler.CreacionMatrizRnd(r1, c1);
                        Console.WriteLine("✔ Matriz aleatoria generada.");
                        break;

                    case "13":
                        int r2 = GetSafeInt(" Cantidad de Filas: ");
                        int c2 = GetSafeInt(" Cantidad de Columnas: ");
                        currentMatrix = matrixHandler.CreacionMatrizManual(r2, c2);
                        break;

                    case "14":
                        if (currentMatrix != null)
                        {
                            Console.WriteLine();
                            matrixHandler.MostrarMatriz(currentMatrix);
                        }
                        else Console.WriteLine("\n[!] Error: No hay matriz cargada.");
                        break;

                    case "15":
                        if (currentMatrix != null)
                        {
                            int target = GetSafeInt(" Número a buscar: ");
                            matrixHandler.EncontrarElemento(target, currentMatrix);
                        }
                        else Console.WriteLine("\n[!] Error: No hay matriz cargada.");
                        break;

                    case "16":
                        if (currentMatrix != null)
                        {
                            int targetDel = GetSafeInt(" Número a eliminar: ");
                            matrixHandler.BorrarElemento(targetDel, currentMatrix);
                        }
                        else Console.WriteLine("\n[!] Error: No hay matriz cargada.");
                        break;

                    case "17":
                        ValidarSudoku();
                        break;

                    case "18":
                        InvertirMatriz();
                        break;

                    case "19":
                        ResolverSistemaEcuaciones();
                        break;

                    case "20":
                        MostrarInfoArray(currentArr);
                        break;

                    case "0":
                        exit = true;
                        Console.WriteLine("\n✔ Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("\n[!] Opción no válida. Intente de nuevo.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        static int GetSafeInt(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result))
                    return result;
                Console.WriteLine("[!] Dato no válido. Ingrese un número.");
            }
        }

        static void ProbarAnagramas(Vector vectorHandler)
        {
            Console.Write("\nPalabra 1: ");
            string p1 = Console.ReadLine();
            Console.Write("Palabra 2: ");
            string p2 = Console.ReadLine();
            
            if (vectorHandler.SonAnagramas(p1, p2))
                Console.WriteLine("✔ Las palabras SON anagramas.");
            else
                Console.WriteLine("[!] Las palabras NO son anagramas.");
        }

        static void ValidarSudoku()
        {
            Console.WriteLine("\n--- Validador de Sudoku ---");
            Console.WriteLine("Ingrese una matriz 9x9 con números del 1 al 9.\n");

            int[,] sudokuMatrix = new int[9, 9];
            Console.WriteLine("Escriba cada fila (9 números separados por espacio):\n");

            for (int i = 0; i < 9; i++)
            {
                bool rowSuccess = false;
                while (!rowSuccess)
                {
                    Console.Write($"Fila {i + 1}/9: ");
                    string input = Console.ReadLine() ?? "";
                    string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length != 9)
                    {
                        Console.WriteLine("[!] Error: Se esperaban 9 elementos.");
                        continue;
                    }

                    try
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            sudokuMatrix[i, j] = int.Parse(parts[j]);
                        }
                        rowSuccess = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("[!] Error: Uno de los elementos no es un número válido.");
                    }
                }
            }

            if (MathMatrices.EsSolucionValidaV3(sudokuMatrix))
                Console.WriteLine("\n✔ ¡Sudoku válido!");
            else
                Console.WriteLine("\n[!] Sudoku inválido. Contiene números repetidos.");
        }

        static void MostrarInfoArray(int?[] currentArr)
        {
            if (currentArr != null)
            {
                Console.WriteLine($"\n--- Información del Array ---");
                Console.WriteLine($"Longitud: {currentArr.Length}");
                Console.WriteLine($"Elementos no nulos: {currentArr.Count(x => x.HasValue)}");
                if (currentArr.Any(x => x.HasValue)) 
                {
                    Console.WriteLine($"Mínimo: {currentArr.Where(x => x.HasValue).Min()}");
                    Console.WriteLine($"Máximo: {currentArr.Where(x => x.HasValue).Max()}");
                    Console.WriteLine($"Promedio: {currentArr.Where(x => x.HasValue).Average():F2}");
                }
            }
            else Console.WriteLine("\n[!] Error: Primero crea un array.");
        }

        // Invert a matrix
        static void InvertirMatriz()
        {
            Console.WriteLine("\n--- Inversor de Matrices ---");
            Console.WriteLine("Ingrese una matriz cuadrada NxN.\n");

            int n = GetSafeInt("Tamaño de la matriz (N): ");
            double[,] matrix = new double[n, n];

            Console.WriteLine($"\nIngrese los {n * n} elementos de la matriz (separados por espacio).\n");

            for (int i = 0; i < n; i++)
            {
                bool rowSuccess = false;
                while (!rowSuccess)
                {
                    Console.Write($"Fila {i + 1}/{n}: ");
                    string input = Console.ReadLine() ?? "";
                    string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length != n)
                    {
                        Console.WriteLine($"[!] Error: Se esperaban {n} elementos.");
                        continue;
                    }

                    try
                    {
                        for (int j = 0; j < n; j++)
                        {
                            matrix[i, j] = double.Parse(parts[j]);
                        }
                        rowSuccess = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("[!] Error: Uno de los elementos no es un número válido.");
                    }
                }
            }

            try
            {
                double[,] inverse = MathMatrices.Invert(matrix);
                Console.WriteLine("\n--- Matriz Inversa ---\n");
                MostrarMatrizDouble(inverse);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\n[!] Error: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"\n[!] Error: {ex.Message}");
            }
        }

        static void ResolverSistemaEcuaciones()
        {
            Console.WriteLine("\n--- Resoltor de Sistemas de Ecuaciones ---");
            Console.WriteLine("Resolverá sistemas de la forma: Ax = b\n");

            int n = GetSafeInt("Número de ecuaciones (N): ");
            double[,] matrixA = new double[n, n];
            double[] vectorB = new double[n];

            Console.WriteLine($"\nIngrese la matriz de coeficientes A ({n}x{n}):\n");

            for (int i = 0; i < n; i++)
            {
                bool rowSuccess = false;
                while (!rowSuccess)
                {
                    Console.Write($"Fila {i + 1}/{n}: ");
                    string input = Console.ReadLine() ?? "";
                    string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length != n)
                    {
                        Console.WriteLine($"[!] Error: Se esperaban {n} elementos.");
                        continue;
                    }

                    try
                    {
                        for (int j = 0; j < n; j++)
                        {
                            matrixA[i, j] = double.Parse(parts[j]);
                        }
                        rowSuccess = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("[!] Error: Uno de los elementos no es un número válido.");
                    }
                }
            }

            Console.WriteLine($"\nIngrese el vector de constantes b ({n} elementos):\n");

            bool bSuccess = false;
            while (!bSuccess)
            {
                Console.Write("Constantes (separadas por espacio): ");
                string input = Console.ReadLine() ?? "";
                string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != n)
                {
                    Console.WriteLine($"[!] Error: Se esperaban {n} elementos.");
                    continue;
                }

                try
                {
                    for (int i = 0; i < n; i++)
                    {
                        vectorB[i] = double.Parse(parts[i]);
                    }
                    bSuccess = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("[!] Error: Uno de los elementos no es un número válido.");
                }
            }

            try
            {
                double[,] inverseA = MathMatrices.Invert(matrixA);
                double[] solution = MathMatrices.Solve(inverseA, vectorB);

                Console.WriteLine("\n--- Solución del Sistema ---\n");
                for (int i = 0; i < solution.Length; i++)
                {
                    Console.WriteLine($"x[{i + 1}] = {solution[i]:F6}");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\n[!] Error: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"\n[!] Error: {ex.Message}");
            }
        }

        // Display double matrix
        static void MostrarMatrizDouble(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"[{matrix[i, j]:F6}] ");
                }
                Console.WriteLine();
            }
        }
    }
}
