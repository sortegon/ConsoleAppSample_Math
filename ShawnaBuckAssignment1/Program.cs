using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace ShawnaBuckAssignment1
{
    class Program
    {
        public static void Main()
        {
            int a = 5, b = 15;
            printPrimeNumbers(a, b);

            int n1 = 5;
            double r1 = getSeriesResult(n1);
            Console.WriteLine("The sum of the series is: " + r1);


            long n2 = 15;
            long r2 = decimalToBinary(n2);
            Console.WriteLine("Binary conversion of the decimal number " + n2 + " is: " + r2);


            long n3 = 1111;
            long r3 = binaryToDecimal(n3);
            Console.WriteLine("Decimal conversion of the binary number " + n3 + " is: " + r3);


            int n4 = 5;
            printTriangle(n4);

            int[] arr = new int[] { 1, 2, 3, 2, 2, 1, 3, 2 };
            computeFrequency(arr);

            // write your self-reflection here as a comment

        }


        public static void printPrimeNumbers(int a, int b)
        {
            try
            {
                /* Check if user switched parameters by seeing if larger number was entered first */
                if (b < a)
                {
                    Console.WriteLine("Do you mean to return the prime values between a and b? Type yes or no.");
                    /*	If user enters yes, assign b to a and a to b */
                    string response = Console.ReadLine();
                    if (response != null && response.ToUpper() == "YES")
                    {
                        int temp = a;
                        a = b;
                        b = temp;
                    }
                    /*	If user selects no from message box, go back to initial prompt */
                    else
                    {
                        return;
                    }
                }

                /* Instantiate new array to hold prime numbers */
                string primeNumbers = "";

                while (a<b)
                {
                    if(IsPrime(a))
                    {
                        if(primeNumbers.Length > 0)
                        {
                            primeNumbers += ", ";
                        }
                        primeNumbers += a;
                    }
                    a += 1;
                }
                Console.WriteLine(primeNumbers);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printPrimeNumbers()");
            }
        }

        public static bool IsPrime(int a)
        {
            if (a < 2)
            {
                return false;
            }
            if (a == 2)
            {
                return true;
            }
            if (a % 2 == 0)
            {
                return false;
            }
            for (int i = 3; i <= Math.Sqrt(a); i += 2)
            {
                if (a % i == 0)
                {
                    return false;
                }
            }
            return true;
        }


        public static double getSeriesResult(int n)
        {
            try
            {
                /*What if user enters 0 or negative number?'*/
                double seriesSum = 1.0/2;
                double sign = -1;
                for (double top = 2; top <= n; top++)
                {
                    seriesSum += sign * nFactorial(top) / (top+1);
                    sign *= (-1);
                }
                return seriesSum;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing getSeriesResult()");
            }

            return 0;
        }

        public static double nFactorial(double n)
        {
            /* need to add comments*/
            double factorial = n;
            for (double i = n - 1; i > 0; i--)
            {
                factorial = factorial * i;
            }

            return factorial;
        }

        public static long decimalToBinary(long n)
        {
            try
            {
                /*TODO: add code to handle 0 and negative numbers*/
                string binString = "";
                while (n > 0)
                {
                    var r = n % 2;
                    n = n / 2;
                    binString=r+binString;
                }

                return long.Parse(binString);

            }
            catch
            {
                Console.WriteLine("Exception occured while computing decimalToBinary()");
            }

            return 0;
        }

        public static long binaryToDecimal(long n)
        {

            try
            {
                string binString = n.ToString();
                int len = binString.Length - 1;
                int dec = 0;
                for (int x = 0; x <= len; x++)
                {
                    dec += int.Parse(binString[x].ToString()) * Power(len-x);
                }

                return dec;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing binaryToDecimal()");
            }

            return 0;
        }

        public static int Power(int i)
        {
            int q = 1;
            for (; i > 0; i--)
            {
                q *= 2;
            }

            return q;
        }

        public static void printTriangle(int n)
        {
            try
            {
                for (int i = 1; i <= n; i++)
                {
                    int printStars = (i * 2) - 1;
                    int nonStars = n - i;
                    for (int j=1; j <= nonStars; j++)
                    {
                        Console.Write(" ");
                    }
                    for (int k=1; k <= printStars; k++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }
        }

        public static void computeFrequency(int[] a)
        {
            try
            {
                int max = 0;
                foreach (int number in a)
                {
                    if (number>max)
                    {
                        max = number;
                    }
                }
                int[] frequency = new int[max];
                foreach (int numbers in a)
                {
                    frequency[numbers - 1]++;
                }
                Console.WriteLine( "Number\tFrequency");
                for (int i = 0; i < max; i++)
                {
                    if (frequency[i]>0)
                    {
                        Console.Write(i+1);
                        Console.Write("\t");
                        Console.Write(frequency[i]);
                        Console.WriteLine();
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing computeFrequency()");
            }
        }
    }
}

