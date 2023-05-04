using System;

class Program
{
    static int[][] pascalTriangle;

    static void Main()
    {
        // leer el número de casos de prueba
        int t = int.Parse(Console.ReadLine());

        // procesar cada caso de prueba
        for (int i = 0; i < t; i++)
        {
            // leer los valores de m y n
            string[] input = Console.ReadLine().Split();
            int m = int.Parse(input[0]);
            int n = int.Parse(input[1]);

            // calcular y mostrar la suma de los valores del triángulo de Pascal
            Console.WriteLine(CalculatePascalSum(m, n));
        }
    }

    static void CalculatePascalTriangle(int n)
    {
        pascalTriangle = new int[n + 1][];
        pascalTriangle[0] = new int[] { 1 };

        for (int i = 1; i <= n; i++)
        {
            pascalTriangle[i] = new int[i + 1];
            pascalTriangle[i][0] = 1;

            for (int j = 1; j <= i; j++)
            {
                if (j == i)
                {
                    pascalTriangle[i][j] = 1;
                }
                else
                {
                    pascalTriangle[i][j] = (pascalTriangle[i - 1][j - 1] + pascalTriangle[i - 1][j]) % 1000000007;
                }
            }
        }
    }

    static int CalculatePascalSum(int m, int n)
    {
        CalculatePascalTriangle(n);

        int sum = 0;

        for (int i = m; i <= n; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                sum = (sum + pascalTriangle[i][j]) % 1000000007;
            }
        }

        return sum;
    }
}