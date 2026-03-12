using System;

namespace _12_2_26WorkSameLetters
{
    internal class MathMatrices
    {
        public MathMatrices() { }

        public static double[,] Invert(double[,] matrix)
        {
            int n = matrix.GetLength(0);

            // 1. VALIDATION: Only square matrices have inverses.
            if (n != matrix.GetLength(1))
                throw new ArgumentException("Matrix must be square.");

            // 2. AUGMENTATION: Create a matrix of size [n, 2n].
            // It looks like: [ Original Matrix | Identity Matrix ]
            // 
            double[,] augmented = new double[n, 2 * n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    augmented[i, j] = matrix[i, j];

                // Place '1' in the diagonal of the right half (Identity)
                augmented[i, i + n] = 1.0;
            }

            // 3. GAUSS-JORDAN ELIMINATION
            for (int i = 0; i < n; i++)
            {
                // --- STEP A: Partial Pivoting ---
                // Find the row with the largest absolute value in the current column 'i'.
                // This reduces rounding errors and prevents dividing by zero.
                int pivotIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (Math.Abs(augmented[j, i]) > Math.Abs(augmented[pivotIndex, i]))
                        pivotIndex = j;
                }

                // Swap the current row with the pivot row found above.
                if (pivotIndex != i)
                { 
                    for (int k = 0; k < 2 * n; k++)
                    {
                        double temp = augmented[i, k];
                        augmented[i, k] = augmented[pivotIndex, k];
                        augmented[pivotIndex, k] = temp;
                    }
                }

                // --- STEP B: Singular Matrix Check ---
                // If the pivot is zero, the matrix is "singular" and has no inverse.
                if (Math.Abs(augmented[i, i]) < 1e-12)
                    throw new InvalidOperationException("Matrix is singular (cannot be inverted).");

                // --- STEP C: Normalization ---
                // Divide the entire pivot row by the pivot value so the diagonal becomes 1.
                double divisor = augmented[i, i];
                for (int j = i; j < 2 * n; j++)
                    augmented[i, j] /= divisor;

                // --- STEP D: Elimination ---
                // For every other row (above and below the pivot)...
                for (int row = 0; row < n; row++)
                {
                    if (row != i) // Don't subtract the pivot row from itself
                    {
                        // Find the factor that would make the value in the current column 0.
                        double factor = augmented[row, i];

                        // Subtract (factor * pivotRow) from the current row.
                        for (int col = i; col < 2 * n; col++)
                        {
                            augmented[row, col] -= factor * augmented[i, col];
                        }
                    }
                }
            }

            // 4. EXTRACTION: The left side is now the Identity matrix.
            // The right side [n to 2n] is now the Inverse.
            double[,] inverse = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    inverse[i, j] = augmented[i, j + n];
            }

            return inverse;
        }

        public static double[] Solve(double[,] inverseMatrix, double[] b)
        {
            int n = b.Length;
            double[] x = new double[n];

            for (int i = 0; i < n; i++)
            {
                x[i] = 0;
                for (int j = 0; j < n; j++)
                {
                    // multiplies the inverse by the constants
                    x[i] += inverseMatrix[i, j] * b[j];
                }
            }
            return x;
        }



        /*
         So basically the logic goes like this.. i first pass into the function the matrix and then the fuction
         starts off by checking that the dimensions of the matrix are right.. (it must be 9x9), if ok the matrix 
         proceeds by checking every single cell horizontally, verticaly and each submatrix.. 
         this is done by nesting 1 for inside another each with the condition n < 9.. since the first loop will
         be used to check both rows and cols at the same time with the help of the second for as well.. by only swapping the
         i and j when needed.. and then we proceed with the most difficult part of the program that 
         is the checking of the 3x3 subarrays. 
         */

        /*
         Remdinder that the checking is done by using 
         */


        public bool EsSolucionValida(int?[,] matrix)
        {
            if (matrix.GetLength(0) != 9 || matrix.GetLength(1) != 9)
                return false;

            for (int i = 0; i < 9; i++)
            {
                // Checklists for numbers 1-9 for this iteration
                bool[] rowCheck = new bool[9];
                bool[] colCheck = new bool[9];
                bool[] gridCheck = new bool[9];

                for (int j = 0; j < 9; j++)
                {
                    // 1. checks row
                    if (!ValidarCelda(matrix[i, j], rowCheck)) return false;

                    // 2. checks column
                    if (!ValidarCelda(matrix[j, i], colCheck)) return false;

                    // 3. checks 3x3 submatrix

                    /*
                     1. Row Offset [3 * (i / 3)]: 
 * Determines the vertical starting point of the 3x3 box.
 * i = 0,1,2 (Top)    -> 0/3, 1/3, 2/3 = 0 -> Offset 0
 * i = 3,4,5 (Middle) -> 3/3, 4/3, 5/3 = 1 -> Offset 3
 * i = 6,7,8 (Bottom) -> 6/3, 7/3, 8/3 = 2 -> Offset 6
 *
 * 2. Column Offset [3 * (i % 3)]: 
 * Determines the horizontal starting point of the 3x3 box.
 * i = 0,3,6 (Left)   -> 0%3, 3%3, 6%3 = 0 -> Offset 0
 * i = 1,4,7 (Center) -> 1%3, 4%3, 7%3 = 1 -> Offset 3
 * i = 2,5,8 (Right)  -> 2%3, 5%3, 8%3 = 2 -> Offset 6
 * 
 * 
 * 
 * so basically the submatrix traversal goes like this x -> x -> x
 *                                                     x -> ..
 * basically from left to right and from up to down
                     */

                    int rowIdx = 3 * (i / 3) + (j / 3);
                    int colIdx = 3 * (i % 3) + (j % 3);
                    if (!ValidarCelda(matrix[rowIdx, colIdx], gridCheck)) return false;
                }
            }
            return true;
        }

        private bool ValidarCelda(int? valor, bool[] checklist)
        {
            // the cell cant be null
            if (valor == null) return false;

            int num = valor.Value;

            // verifies numbers are between 1 and 9
            if (num < 1 || num > 9) return false;

            // verifies the num is not in the checklist already
            if (checklist[num - 1]) return false;

            // marks as seen
            checklist[num - 1] = true;
            return true;
        }

    }
}

