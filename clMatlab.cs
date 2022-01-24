using System;
using System.IO;

namespace clMatlab
{
    /// <summary>
    /// Various Octave/Matlab operations implemented in C#.
    /// There is only one class and it has the same name as the namespace.
    /// This is done with the intent that the user, upon call, doesn't have to remember to which class
    /// his particular funciton of intrest belongs to. 
    /// TIP: 
    /// Modify your call to the library as follows,
    /// 	"using clMatlab.clMatlb;" --> "using cl=clMatlab.clMatlab;"
    /// for ease of call: call someFunc() by cl.someFunc() instead of clMatlab.clMatlab.someFunc().
    /// </summary>
    public class clMatlab
    {
        /// <summary>
        /// Reads matrix from .txt file.
        /// </summary>
        /// <param name="path"> Path to .txt file. </param>
        /// <param name="sp"> Separator e.g. "," or " ". </param>
        /// <param name="rowOffset"> Number of row to start reading file. </param>
        /// <remarks>This is a remark.</remarks>
        /// <example>M = getMatrixFromPath(pathToFile," ",112);</example>
        /// <returns>  </returns>
        public static int[,] getMatrixFromPath(string path, string sp,int rowOffset = 0)
        {
            int[,] M = null;
            string[] rows = File.ReadAllLines(path);
            string[] row = rows[rowOffset].Split(sp);
            row = new string[row.Length];
            M = new int[rows.Length - rowOffset, row.Length - 1];
            for (int i = rowOffset; i < rows.Length; i++)
            {
                row = rows[i].Split(sp);
                for (int j = 0; j < row.Length - 1; j++) 
                {
                    M[i - rowOffset, j] = Convert.ToInt32(row[j]);
                }
            }
            return M;
        }
        /// <summary>
        /// Reads matrix from .txt file.
        /// </summary>
        /// <param name="path"> Path to .txt file. </param>
        /// <param name="sp"> Separator e.g. "," or " ". </param>
        /// <param name="rowOffset"> Number of row to start reading file. </param>
        /// <remarks>This is a remark.</remarks>
        /// <example>M = getMatrixFromPath(pathToFile," ",112);</example>
        /// <returns>  </returns>
        public static double[,] getDoubleMatrixFromPath(string path, string sp, int rowOffset = 0)
        {
            double[,] M = null;
            string[] rows = File.ReadAllLines(path);
            string[] row = rows[rowOffset].Split(sp);
            int N;
            if (row[row.Length - 1].Equals(sp) || row[row.Length - 1].Equals(""))
            {
                N = row.Length - 1;
            }
            else
            {
                N = row.Length;
            }

            M = new double[rows.Length - rowOffset, N];
            for (int i = rowOffset; i < rows.Length; i++)
            {
                row = rows[i].Split(sp);
                for (int j = 0; j < N; j++)
                {
                    M[i - rowOffset, j] = Convert.ToDouble(row[j]);
                }
            }
            return M;
        }
        /// <summary>
        /// Prints an array onto a console. 
        /// </summary>
        /// <param name="M">Array to print.</param>
        public static void printMatrix(int[] M)
        {
            int H = M.Length;
            Console.WriteLine("Printing Matrix Length = {0}", H);
            for (int i = 0; i < H; i++)
            {
                Console.Write("{0,5}: ", i);
                Console.Write("{0} ", M[i]);
                Console.WriteLine("");
            }
        }
        /// <summary>
        /// Prints a matrix onto a console.
        /// </summary>
        /// <param name="M">Matrix to print.</param>
        public static void printMatrix(int[,] M)
        {
            int H = M.GetLength(0);
            int W = M.GetLength(1);
            Console.WriteLine("Printing Matrix Size = {0} x {1} = {2}", H, W, H * W);
            for (int i = 0; i < H; i++)
            {
                Console.Write("{0,5}: ", i);
                int j = 0;
                for (; j < W - 1; j++) 
                {
                    Console.Write("{0} ",M[i, j]);
                }
                Console.WriteLine("{0}", M[i, j]);
            }
            Console.WriteLine("");
        }
        /// <summary>
        /// Prints an array onto a console. 
        /// </summary>
        /// <param name="M">Array to print.</param>
        public static void printMatrix(double[] M)
        {
            int W = M.Length;
            Console.WriteLine("Printing Vector of length = {0}",W);
            int i = 0;
            for (; i < W-1; i++)
            {
                Console.Write("{0} ", M[i]);
            }
            Console.WriteLine("{0}\n", M[i]);
        }
        /// <summary>
        /// Prints a matrix onto a console. Good for "small" matrices. 
        /// For large matrices use printMatrixLean(). 
        /// </summary>
        /// <param name="M">Matrix to print.</param>
        public static void printMatrix(double[,] M)
        {
            int H = M.GetLength(0);
            int W = M.GetLength(1);
            Console.WriteLine("Printing Matrix Size = {0} x {1} = {2}", H, W, H * W);
            for (int i = 0; i < H; i++)
            {
                Console.Write("{0,5}: ", i);
                int j = 0;
                for (; j < W - 1; j++)
                {
                    Console.Write("{0} ", M[i, j]);
                }
                Console.WriteLine("{0}", M[i, j]);
            }
        }
        /// <summary>
        /// Prints corners of a matrix onto a console.
        /// </summary>
        /// <param name="M">Matrix to print.</param>
        public static void printMatrixLean(int[,] M)
        {
            int H = M.GetLength(0);
            int W = M.GetLength(1);
            int R = 5;
            int C = 5;

            Console.WriteLine("Printing Matrix Size = {0} x {1} = {2}\n", H, W, H * W);
            int i = 0;
            for (; i < R + 1; i++)
            {
                Console.Write("{0,10}: ", i);
                int j = 0;
                for (; j < C + 1; j++)
                {
                    Console.Write("{0,10} ", M[i, j]);
                }
                Console.Write("... ");
                j = W - 1 - C;
                for (; j < W - 1; j++)
                {
                    Console.Write("{0,10} ", M[i, j]);
                }
                Console.WriteLine("{0,10}", M[i, j]);
            }
            for (int k = 0; k < 3; k++)
            {
                Console.WriteLine("{0,22}{0,11}{0,11}", '.');
            }
            i = H - 1 - R;
            for (; i < H; i++)
            {
                Console.Write("{0,10}: ", i);
                int j = 0;
                for (; j < C + 1; j++)
                {
                    Console.Write("{0,10} ", M[i, j]);
                }
                Console.Write("... ");
                j = W - 1 - C;
                for (; j < W - 1; j++)
                {
                    Console.Write("{0,10} ", M[i, j]);
                }
                Console.WriteLine("{0,10}", M[i, j]);
            }
            Console.WriteLine("\n");
        }
        /// <summary>
        /// Prints corners of a matrix onto a console.
        /// </summary>
        /// <param name="M">Matrix to print.</param>
        public static void printMatrixLean(double[,] M)
        {
            int H = M.GetLength(0);
            int W = M.GetLength(1);
            if (H <= 10 || W <= 10) 
            {
                clMatlab.printMatrix(M);
                return;
            }
            int R = 5;
            int C = 5;

            Console.WriteLine("Printing Matrix Size = {0} x {1} = {2}\n", H, W, H * W); int i = 0;
            for (; i < R + 1; i++)
            {
                Console.Write("{0,10}: ", i);
                int j = 0;
                for (; j < C + 1; j++)
                {
                    Console.Write("{0: 00.000,10} ", M[i, j]);
                }
                Console.Write("... ");
                j = W - 1 - C;
                for (; j < W - 1; j++)
                {
                    Console.Write("{0: 00.000,10} ", M[i, j]);
                }
                Console.WriteLine("{0: 00.000,10}", M[i, j]);
            }
            for (int k = 0; k < 3; k++)
            {
                Console.WriteLine("{0,22}{0,11}{0,11}", '.');
            }
            i = H - 1 - R;
            for (; i < H; i++)
            {
                Console.Write("{0,10}: ", i);
                int j = 0;
                for (; j < C + 1; j++)
                {
                    Console.Write("{0: 00.000,10} ", M[i, j]);
                }
                Console.Write("... ");
                j = W - 1 - C;
                for (; j < W - 1; j++)
                {
                    Console.Write("{0: 00.000,10} ", M[i, j]);
                }
                Console.WriteLine("{0: 00.000,10}", M[i, j]);
            }
            Console.WriteLine("\n");
        }
        /// <summary>
        /// Compute mean of matrix values.
        /// </summary>
        /// <param name="M">Input matrix.</param>
        /// /// <returns>double</returns>
        public static double MatrixMean(int[,] M)
        {
            double mm = 0;
            int H = M.GetLength(0);
            int W = M.GetLength(1);
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    mm += M[i, j];
                }
            }
            mm /= (W*H);
            return mm;
        }
        /// <summary>
        /// Compute mean of matrix values.
        /// </summary>
        /// <param name="M">Input matrix.</param>
        /// <returns>double</returns>
        public static double MatrixMean(double[,] M)
        {
            double mm = 0;
            int H = M.GetLength(0);
            int W = M.GetLength(1);
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    mm += M[i, j];
                }
            }
            mm /= Convert.ToDouble(W * H);
            return mm;
        }
        /// <summary>
        /// Finds index of smallest element in array.
        /// </summary>
        /// <param name="M">Input matrix.</param>
        /// <returns>int</returns>
        public static int MatrixIdxOfMin(double[] M)
        {
            int W = M.Length;
            int minIdx = 0;
            for (int j = 1; j < W; j++)
            {
                if (M[j] < M[minIdx])
                {
                    minIdx = j;
                }
            }
            return minIdx;
        }
        /// <summary>
        /// Finds index of smallest element in matrix.
        /// </summary>
        /// <param name="M">Input matrix.</param>
        /// <returns>int[1,2]</returns>
        public static int[,] MatrixIdxOfMin(double[,] M)
        {
            int H = M.GetLength(0);
            int W = M.GetLength(1);
            int[,] minIdx = new int[1, 2];
            minIdx[0, 0] = 0;
            minIdx[0, 1] = 0;
            for (int i = 0; i < H; i++)
            {
                for (int j = 1; j < W; j++)
                {
                    if (M[i, j] < M[minIdx[0, 0], minIdx[0, 1]])
                    {
                        minIdx[0, 0] = i;
                        minIdx[0, 1] = j;
                    }
                }
            }
            return minIdx;
        }
        /// <summary>
        /// Finds index of smallest element in array.
        /// </summary>
        /// <param name="M">Input matrix.</param>
        /// <returns>int</returns>
        public static int MatrixIdxOfMin(int[] M)
        {
            int W = M.Length;
            int minIdx = 0;
            for (int j = 1; j < W; j++)
            {
                if (M[j] < M[minIdx])
                {
                    minIdx = j;
                }
            }
            return minIdx;
        }
        /// <summary>
        /// Finds index of smallest element in matrix.
        /// </summary>
        /// <param name="M">Input matrix.</param>
        /// <returns>int[1,2]</returns>
        public static int[,] MatrixIdxOfMin(int[,] M)
        {
            int H = M.GetLength(0);
            int W = M.GetLength(1);
            int[,] minIdx = new int[1, 2];
            minIdx[0, 0] = 0;
            minIdx[0, 1] = 0;
            for (int i = 0; i < H; i++)
            {
                for (int j = 1; j < W; j++)
                {
                    if (M[i, j] < M[minIdx[0, 0], minIdx[0, 1]])
                    {
                        minIdx[0, 0] = i;
                        minIdx[0, 1] = j;
                    }
                }
            }
            return minIdx;
        }
        /// <summary>
        /// Converts an int[,] to double[,].
        /// </summary>
        /// <param name="M">Input matrix.</param>
        /// <returns>double[,]</returns>
        public static double[,] ConvertIntArrayToDouble(int[,] M)
        {
            int H = M.GetLength(0);
            int W = M.GetLength(1);
            double[,] D = new double[H, W];
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    D[i, j] = Convert.ToDouble(M[i, j]);
                }
            }
            return D;
        }
        /// <summary>
        /// Converts an int[] to double[].
        /// </summary>
        /// <param name="M">Input array.</param>
        /// <returns>double[]</returns>
        public static double[] ConvertIntArrayToDouble(int[] M)
        {
            int H = M.GetLength(0);
            double[] D = new double[H];
            for (int i = 0; i < H; i++)
            {
                D[i] = Convert.ToDouble(M[i]);
            }
            return D;
        }
        /// <summary>
        /// Adds element-wise a consant to an array.
        /// </summary>
        /// <param name="M">Input array.</param>
        /// <param name="val">Constant to add.</param>
        /// <remarks>Overwrites given array.</remarks>
        public static void MatrixAdd(double[] M, double val)
        {
            int W = M.Length;
            for (int j = 0; j < W; j++)
            {
                M[j] += val;
            }
            return;
        }
        /// <summary>
        /// Adds element-wise a consant to a matrix.
        /// </summary>
        /// <param name="M">Input matrix.</param>
        /// <param name="val">Constant to add.</param>
        /// <remarks>Overwrites given matrix.</remarks>
        public static void MatrixAdd(double[,] M, double val)
        {
            int H = M.GetLength(0);
            int W = M.GetLength(1);
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    M[i,j] += val;
                }
            }
            return;
        }
        /// <summary>
        /// Multiplies element-wise a matrix by a constant. 
        /// </summary>
        /// <param name="M">Input matrix.</param>
        /// <param name="val">Constant to multiply.</param>
        /// <remarks>Overwrites given matrix.</remarks>
        public static void MatrixMultiply(int[,] M, int val)
        {
            int H = M.GetLength(0);
            int W = M.GetLength(1);
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    M[i, j] *= val;
                }
            }
            return;
        }
        /// <summary>
        /// Multiplies element-wise a matrix by a constant. 
        /// </summary>
        /// <param name="M">Input matrix.</param>
        /// <param name="val">Constant to multiply.</param>
        /// <remarks>Overwrites given matrix.</remarks>
        public static void MatrixMultiply(double[,] M, double val)
        {
            int H = M.GetLength(0);
            int W = M.GetLength(1);
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    M[i, j] *= val;
                }
            }
            return;
        }
        /// <summary>
        /// Multiplies element-wise an array by a constant. 
        /// </summary>
        /// <param name="M">Input array.</param>
        /// <param name="val">Constant to multiply.</param>
        /// <remarks>Overwrites given array.</remarks>
        public static void MatrixMultiply(double[] M, double val)
        {
            int W = M.Length;
            for (int j = 0; j < W; j++)
            {
                M[j] *= val;
            }
            return;
        }
        /// <summary>
        /// Zeros each element whose value is <= threshold.
        /// </summary>
        /// <param name="M">Input matrix.</param>
        /// <param name="th">Threshold</param>
        /// <remarks>Default threshold is 0.</remarks>
        /// <remarks>Overwrites given matrix.</remarks>
        public static void ZeroBelowThreshold(int[,] M, int th = 0)
        {
            int H = M.GetLength(0);
            int W = M.GetLength(1);
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    M[i, j] = (M[i, j] <= th) ? 0 : M[i, j];
                }
            }
            return;
        }
        /// <summary>
        /// Zeros each element whose value is <= threshold.
        /// </summary>
        /// <param name="M">Input matrix.</param>
        /// <param name="th">Threshold</param>
        /// <remarks>Default threshold is 0.</remarks>
        /// <remarks>Overwrites given matrix.</remarks>
        public static void ZeroBelowThreshold(double[,] M, double th = 0)
        {
            int H = M.GetLength(0);
            int W = M.GetLength(1);
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    M[i, j] = (M[i, j] <= th) ? 0 : M[i, j];
                }
            }
            return;
        }
        /// <summary>
        /// Finds all elements whose value is > threshold.
        /// </summary>
        /// <param name="M">Input matrix.</param>
        /// <param name="th">Threshold.</param>
        /// <returns>int[,2]</returns>
        /// <remarks>Default threshold is 0.</remarks>
        /// <remarks>Overwrites given matrix.</remarks>
        public static int[,] FindAboveThreshold(double[,] M, double th = 0)
        {
            int H = M.GetLength(0);
            int W = M.GetLength(1);
            int k = 0;
            int[,] ijs = new int[H * W, 2];
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    if (M[i, j] > th) 
                    {
                        ijs[k, 0] = i;
                        ijs[k, 1] = j;
                        k++;
                    }
                }
            }
            int[,] ijs0 = new int[k, 2];
            for (int i = 0; i < k; i++)
            {
                ijs0[i, 0] = ijs[i, 0];
                ijs0[i, 1] = ijs[i, 1];
            }
            return ijs0;
        }
        /// <summary>
        /// Returns part of a given matrix.
        /// </summary>
        /// <param name="M">Input matrix.</param>
        /// <param name="ii">From row.</param>
        /// <param name="ie">To row.</param>
        /// <param name="ji">From column.</param>
        /// <param name="je">To column.</param>
        /// <returns>int[ie-ii+1,je-ji+1]</returns>
        public static int[,] GetPartOfMatrix(int[,] M, int ii, int ie, int ji, int je)
        {
            //Add check for exceeding indecies!
            int[,] Mout = new int[ie - ii + 1, je - ji + 1];
            for (int i = 0; i < Mout.GetLength(0); i++)
            {
                for (int j = 0; j < Mout.GetLength(1); j++)
                {
                    Mout[i, j] = M[ii + i, ji + j];
                }
            }
            return Mout;
        }
        /// <summary>
        /// Returns part of a given matrix.
        /// </summary>
        /// <param name="M">Input matrix.</param>
        /// <param name="ii">From row.</param>
        /// <param name="ie">To row.</param>
        /// <param name="ji">From column.</param>
        /// <param name="je">To column.</param>
        /// <returns>int[ie-ii+1,je-ji+1]</returns>
        public static double[,] GetPartOfMatrix(double[,] M, int ii,int ie, int ji, int je)
        {
            double[,] Mout = new double[ie - ii + 1, je - ji + 1];
            for (int i = 0; i < Mout.GetLength(0); i++)
            {
                for (int j = 0; j < Mout.GetLength(1); j++)
                {
                    Mout[i, j] = M[ii + i, ji + j];
                }
            }
            return Mout;
        }
        /// <summary>
        /// Returns part of a given matrix.
        /// </summary>
        /// <param name="M">Input matrix.</param>
        /// <param name="centCoo">Indecies of center element.</param>
        /// <param name="d">Width of square.</param>
        /// <returns>int[d,d]</returns>
        public static int[,] GetPartOfMatrix(int[,] M, int[] centCoo, int d)
        {
            // Modify to address exceeding indecies.
            int dd = d / 2;
            int T = centCoo[0] - dd + (1 - d % 2);
            int B = centCoo[0] + dd;
            int L = centCoo[1] - dd + (1 - d % 2);
            int R = centCoo[1] + dd;
            int[,] K = new int[B - T + 1, R - L + 1];
            for (int i = 0; i < K.GetLength(0); i++)
            {
                for (int j = 0; j < K.GetLength(1); j++)
                {
                    K[i, j] = M[T + i, L + j];
                }
            }
            return K;
        }
        /// <summary>
        /// Computes sum of elements column-wise.
        /// </summary>
        /// <param name="M">Input matrix.</param>
        /// <returns>int[M.GetLength(1)]</returns>
        /// <remarks>[i,j]~[row,column]</remarks>
        public static int[] sumOfRows(int[,] M)
        {
            int[] hProf = new int[M.GetLength(1)];
            for (int j = 0; j < hProf.Length; j++)
            {
                for (int i = 0; i < M.GetLength(0); i++)
                {
                    hProf[j] += M[i, j];
                }
            }
            return hProf;
        }
        /// <summary>
        /// Computes sum of elements column-wise.
        /// </summary>
        /// <param name="M">Input matrix.</param>
        /// <returns>int[M.GetLength(1)]</returns>
        /// <remarks>[i,j]~[row,column]</remarks>
        public static double[] sumOfRows(double[,] M)
        {
            double[] hProf = new double[M.GetLength(1)];
            for (int j = 0; j < hProf.Length; j++)
            {
                for (int i = 0; i < M.GetLength(0); i++)
                {
                    hProf[j] += M[i, j];
                }
            }
            return hProf;
        }
        /// <summary>
        /// Computes sum of elements row-wise.
        /// </summary>
        /// <param name="M">Input matrix.</param>
        /// <returns>int[M.GetLength(0)]</returns>
        /// <remarks>[i,j]~[row,column]</remarks>
        public static int[] sumOfCols(int[,] M)
        {
            int[] vProf = new int[M.GetLength(0)];
            for (int i = 0; i < vProf.Length; i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                {
                    vProf[i] += M[i, j];
                }
            }
            return vProf;
        }
        /// <summary>
        /// Computes sum of elements row-wise.
        /// </summary>
        /// <param name="M">Input matrix.</param>
        /// <returns>int[M.GetLength(0)]</returns>
        /// <remarks>[i,j]~[row,column]</remarks>
        public static double[] sumOfCols(double[,] M)
        {
            double[] vProf = new double[M.GetLength(0)];
            for (int i = 0; i < vProf.Length; i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                {
                    vProf[i] += M[i, j];
                }
            }
            return vProf;
        }
        /// <summary>
        /// Applies an RC filter to an array.
        /// </summary>
        /// <param name="V">Input array.</param>
        /// <param name="k">Filter coefficent.</param>
        /// <returns>double[V.Length]</returns>
        /// <remarks>k = ( 1+2*PI*( f_cutoff / f_sampling ) )^-1</remarks>
        /// <remarks>f_cutoff = cutoff frequency.</remarks>
        /// <remarks>f_sampling = sampling frequency. frequency.</remarks>
        public static double[] rcFilter(double[] V, double k = 0.5)
        {
            // Change to overwrite the given array!
            double[] Vout = new double[V.Length];
            Vout[0] = (1 - k) * V[0];
            for (int i = 1; i < V.Length; i++)
            {
                Vout[i] = k * Vout[i - 1] + (1 - k) * V[i];
            }
            return Vout;
        }
        /// <summary>
        /// Flips order of elements in array.
        /// </summary>
        /// <param name="V">Input array.</param>
        /// <returns>double[V.length]</returns>
        public static double[] flipArray(double[] V)
        {
            // Modify to overwrite the array.
            double[] Vout = new double[V.Length];
            for (int i = 0; i < V.Length; i++)
            {
                Vout[i] = V[V.Length - i - 1];
            }
            return Vout;
        }
        /// <summary>
        /// Returns the index of the centroid element in the array.
        /// </summary>
        /// <param name="V">Input array.</param>
        /// <returns>int</returns>
        /// <remarks>
        /// The centroid is (usually) located between neighboring elements. 
        /// The index returned refers to the element with a lower index.
        /// </remarks>
        public static int centroid(double[] V)
        {
            double loc = 0;
            double sum = 0;
            for (int i = 0; i < V.Length; i++)
            {
                loc += (i + 1) * V[i];
                sum += V[i];
            }
            return Convert.ToInt32(Math.Round(loc / sum) - 1);
        }
        /// <summary>
        /// Returns indecies of first n sorted maximum elements in a matrix.
        /// </summary>
        /// <param name="M">Input matrix.</param>
        /// <param name="n">Number of maximum elements.</param>
        /// <returns>int[n,2]</returns>
        /// <remarks>Default n = 1.</remarks>
        public static int[,] maxk(int[,] M, int n = 1)
        {
            int[] maxVals = new int[n];
            int[,] maxIdxs = new int[n, 2];
            int H = M.GetLength(0);
            int W = M.GetLength(1);
            int val = 0;
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    val = M[i, j];
                    if (val > maxVals[n - 1])
                    {
                        int k = 0;
                        for (; k < n; k++)
                        {
                            if (val > maxVals[k])
                            {
                                break;
                            }
                        }
                        for (int s = n - 1; s > k; s--)
                        {
                            maxVals[s] = maxVals[s - 1];
                            maxIdxs[s, 0] = maxIdxs[s - 1, 0];
                            maxIdxs[s, 1] = maxIdxs[s - 1, 1];
                        }
                        maxVals[k] = val;
                        maxIdxs[k, 0] = i;
                        maxIdxs[k, 1] = j;
                    }
                }
            }
            return maxIdxs;
        }
        /// <summary>
        /// Returns indecies of first n sorted maximum elements in a array.
        /// </summary>
        /// <param name="M">Input array.</param>
        /// <param name="n">Number of maximum elements.</param>
        /// <returns>int[n]</returns>
        /// <remarks>Default n = 1.</remarks>
        public static int[] maxk(double[] M, int n = 1)
        {
            double[] maxVals = new double[n];
            int[] maxIdxs = new int[n];
            int H = M.Length;
            double val;
            for (int i = 0; i < H; i++)
            {
                val = M[i];
                if (val > maxVals[n - 1])
                {
                    int k = 0;
                    for (; k < n; k++)
                    {
                        if (val > maxVals[k])
                        {
                            break;
                        }
                    }
                    for (int s = n - 1; s > k; s--)
                    {
                        maxVals[s] = maxVals[s - 1];
                        maxIdxs[s] = maxIdxs[s - 1];
                    }
                    maxVals[k] = val;
                    maxIdxs[k] = i;
                }
            }
            return maxIdxs;
        }
        /// <summary>
        /// Returns indecies of first n sorted maximum elements in a matrix.
        /// </summary>
        /// <param name="M">Input matrix.</param>
        /// <param name="n">Number of maximum elements.</param>
        /// <returns>int[n,2]</returns>
        /// <remarks>Default n = 1.</remarks>
        public static int[,] maxk(double[,] M, int n = 1)
        {
            double[] maxVals = new double[n];
            int[,] maxIdxs = new int[n, 2];
            int H = M.GetLength(0);
            int W = M.GetLength(1);
            double val;
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    val = M[i, j];
                    if (val > maxVals[n - 1]) 
                    {
                        int k = 0;
                        for (; k < n; k++)
                        {
                            if (val > maxVals[k])
                            {
                                break;
                            }
                        }
                        for (int s = n-1; s > k; s--)
                        {
                            maxVals[s] = maxVals[s-1];
                            maxIdxs[s, 0] = maxIdxs[s - 1, 0];
                            maxIdxs[s, 1] = maxIdxs[s - 1, 1];
                        }
                        maxVals[k] = val;
                        maxIdxs[k, 0] = i;
                        maxIdxs[k, 1] = j;
                    }
                }
            }
            return maxIdxs;
        }
        /// <summary>
        /// Returns the matrix addition of two matrecies.
        /// </summary>
        /// <param name="A">1st input matrix.</param>
        /// <param name="B">2nd input matrix.</param>
        /// <returns>int[A.GetLength(0),A.GetLength(1)]</returns>
        public static int[,] MatrixAddition(int[,] A, int[,] B)
        {
            // Add check that matrecies are of equal dimesnion.
            int H = A.GetLength(0);
            int W = A.GetLength(1);
            int[,] C = new int[H, W];
            if (H!=B.GetLength(0) || W != B.GetLength(1))
            {
                Console.WriteLine("Matrix dimensions aren't equal.");
                return C;
            }
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    C[i, j] = A[i, j] + B[i, j];
                }
            }
            return C;
                
        }
        /// <summary>
        /// Returns unique values in an array.
        /// </summary>
        /// <param name="M">Input array.</param>
        /// <param name="del">
        /// Value of least difference required for an element 
        /// to be considered unique. 
        /// </param>
        /// <returns>Output length is input dependent.</returns>
        public static int[] Unique(int[] M ,int del)
        {
            int N = M.Length;
            int[] idxs = new int[N];
            int[] P = new int[N];
            int k = 0;
            P[k] = M[0];
            idxs[k] = 0;
            for (int i = 1; i < N; i++)
            {
                for (int j = 0; j < k + 1; j++)
                {
                    if (Math.Abs(P[j] - M[i]) < del) 
                    {
                        break;
                    }
                    if (j == k) 
                    {
                        k++;
                        P[k] = M[i];
                        idxs[k] = i;
                    }
                }
            }
            int[] Pout = new int[k + 1];
            for (int i = 0; i < Pout.Length; i++)
            {
                Pout[i] = M[idxs[i]];
            }
            return Pout;
        }
        /// <summary>
        /// Returns unique values in an matrix.
        /// </summary>
        /// <param name="M">Input matrix.</param>
        /// <param name="del">
        /// Value of least difference required for an element 
        /// to be considered unique. 
        /// </param>
        /// <returns>Output length is input dependent.</returns>
        public static int[,] Unique(int[,] M, int del)
        {
            int N = M.GetLength(0);
            int[] idxs = new int[N];
            int[,] P = new int[N,2];
            int k = 0;
            P[k, 0] = M[0, 0];
            P[k, 1] = M[0, 1];
            idxs[k] = 0;
            for (int i = 1; i < N; i++)
            {
                for (int j = 0; j < k + 1; j++)
                {
                    if (Math.Abs(P[j,0] - M[i,0]) < del && Math.Abs(P[j, 1] - M[i, 1]) < del)
                    {
                        break;
                    }
                    if (j == k)
                    {
                        k++;
                        P[k, 0] = M[i, 0];
                        P[k, 1] = M[i, 1];
                        idxs[k] = i;
                    }
                }
            }
            int[,] Pout = new int[k + 1,2];
            for (int i = 0; i < Pout.GetLength(0); i++)
            {
                Pout[i, 0] = M[idxs[i], 0];
                Pout[i, 1] = M[idxs[i], 1];
            }
            return Pout;
        }
        /// <summary>
        /// Generates a matrix of given dimensions populated by random integers.
        /// </summary>
        /// <param name="ub">Upperbound of integer sampling interval.</param>
        /// <param name="H">Number of rows.</param>
        /// <param name="W">Number of columns.</param>
        /// <returns>int[H,W]</returns>
        public static int[,] randi(int ub, int H, int W)
        {
            int[,] A = new int[H, W];
            Random rnd = new Random();
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    A[i, j] = rnd.Next(ub);
                }
            }
            return A;
        }
        /// <summary>
        /// Computes interpolated values at abscissas p[] for given coordinates x and y.
        /// </summary>
        /// <param name="p">Abscissas of intrest.</param>
        /// <param name="x">Given abscissas.</param>
        /// <param name="y">Given ordinates.</param>
        /// <remarks>The given coordinates must be ordered!</remarks>
        /// <returns>f[p.length]</returns>
        public static double[] fInterpolant(double[] p, double[] x, double[] y)
        {
            double[] f = new double[p.Length];
            for (int i = 0; i < p.Length; i++)
            {
                for (int j = 0; j < x.Length; j++)
                {
                    if (p[i]==x[j])
                    {
                        f[i] = y[j];
                        break;
                    }
                    else if (p[i]<x[j])
                    {
                        double x0 = x[j - 1];
                        double y0 = y[j - 1];
                        double x1 = x[j];
                        double y1 = y[j];
                        f[i] = y0 + (y1 - y0) * (p[i] - x0) / (x1 - x0);
                        break;
                    }
                }
            }
            return f;
        }
        /// <summary>
        /// Computes interpolated value at abscissa p for given coordinates x and y.
        /// </summary>
        /// <param name="p">Abscissa of intrest.</param>
        /// <param name="x">Given abscissas.</param>
        /// <param name="y">Given ordinates.</param>
        /// <remarks>The given coordinates must be ordered!</remarks>
        /// <returns>f[1]</returns>
        public static double fInterpolant(double p, double[] x, double[] y)
        {
            double f=0;
            for (int j = 0; j < x.Length; j++)
            {
                if (p == x[j])
                {
                    f = y[j];
                    break;
                }
                else if (p < x[j])
                {
                    double x0 = x[j - 1];
                    double y0 = y[j - 1];
                    double x1 = x[j];
                    double y1 = y[j];
                    f = y0 + (y1 - y0) * (p - x0) / (x1 - x0);
                    break;
                }
            }
            return f;
        }
        /// <summary>
        /// Convert matrix to a 1D array by row elements.
        /// </summary>
        /// <param name="M">Input matrix.</param>
        /// <returns>A[M.GetLength(0) * M.GetLength(1)]</returns>
        public static double[] flattenTo1DArray(double[,] M)
        {
            double[] A = new double[M.GetLength(0) * M.GetLength(1)];
            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                {
                    A[i * M.GetLength(1) + j] = M[i, j];
                }
            }
            return A;
        }
        /// <summary>
        /// Convert matrix to a 1D array by row elements.
        /// </summary>
        /// <param name="M">Input matrix.</param>
        /// <returns>A[M.GetLength(0) * M.GetLength(1)]</returns>
        public static int[] flattenTo1DArray(int[,] M)
        {
            int[] A = new int[M.GetLength(0) * M.GetLength(1)];
            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                {
                    A[i * M.GetLength(1) + j] = M[i, j];
                }
            }
            return A;
        }
    }
}
