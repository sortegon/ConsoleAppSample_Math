using System;

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

            // Student Self-Reflection:
            // I felt that being given the appendix made what I could and could not do with the Main Method unclear. 
            //      I would have liked to be able to include instructions or messages to the user for user input instead of just having the program specify the inputs outright.
            // I understand the restriction on API methods but having freedom to write code however I want is part of what being a programmer is.
            //      Having one part of the assignment with the freedom to do whatever would have been fun and could show off research skills that come in handy in the industry.

        }


        /* This method prints all the prime numbers between a and b, if there are no prime numbers between a and b this method does not print anything */
        public static void printPrimeNumbers(int a, int b)
        {
            try
            {
                /* Check if user switched parameters by seeing if larger number was entered first */
                if (b < a)
                {
                    Console.WriteLine("Do you mean to return the prime values between " + b + " and " + a + "? Type yes or no.");
                    /*	If user enters yes, assign b to a and then a to b using a temporary holding variable */
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

                /* Instantiate new string to hold prime numbers from isPrime Method */
                string primeNumbers = "";

                /* This while loop tests every number for Primality between a and b */
                while (a<b)
                {
                    if(IsPrime(a))
                    {
                        /* If there are no prime numbers in the string primeNumbers, a is added. Otherwise add ", " and then a */
                        if (primeNumbers.Length > 0)
                        {
                            primeNumbers += ", ";
                        }
                        primeNumbers += a;
                    }
                    a += 1;
                }
                /* Result is printed to console rather than being returned */
                Console.WriteLine(primeNumbers);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printPrimeNumbers()");
            }
        }

        /* Method checks to see if integer a is Prime */
        public static bool IsPrime(int a)
        {
            /* 0, 1, and all negative numbers are not prime */
            if (a < 2)
            {
                return false;
            }
            /* Optimization: 2 is the only even prime number so check it first and then we only have to check odd numbers */
            /* 2 is a prime number */
            if (a == 2)
            {
                return true;
            }
            /* If a is divisible by 2 it is not prime */
            if (a % 2 == 0)
            {
                return false;
            }
            /* Check odd numbers for factors.
               Optimization: Any factor greater than the square root of a will have a co-factor less than the square root of a. 
               Thus we only have to check for factors less than the square root of a. */
            for (int i = 3; i <= Math.Sqrt(a); i += 2)
            {
                /* If a is divisible by i, a is not prime */
                if (a % i == 0)
                {
                    return false;
                }
            }
            /* We did not find any factors so a must be prime */
            return true;
        }

        /* This method computes the series 1/2 – 2!/3 + 3!/4 – 4!/5 --- n, where ! means factorial, i.e., 4! = 4*3*2*1 = 24. */
        public static double getSeriesResult(int n)
        {
            try
            {
                /* Special case: 0 terms in the series equals 0 */
                if (n == 0)
                {
                    return 0;
                }

                /* Store n's sign then make it positive to do the calculation on a positive number below */
                int nSign = 1;
                if (n < 0)
                {
                    nSign = -1;
                    n = -n;
                }

                /* First term of the series is 1/2 */
                double seriesSum = 1.0/2;
                /* Variable sign keeps track of the alternating adding and subtracting (subtraction is next) */
                double sign = -1;
                /* Calculate remaining terms in the form: top!/(top+1) */
                for (double top = 2; top <= n; top++)
                {
                    seriesSum += sign * nFactorial(top) / (top+1);
                    /* Flip the sign for the next term in the series */
                    sign *= (-1);
                }

                /* Add the sign back in, and round to 3 decimal places */
                return Math.Round(nSign * seriesSum, 3);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing getSeriesResult()");
            }

            return 0;
        }

        /* Calculates the factorial of n */
        public static double nFactorial(double n)
        {
            /* Start with n */
            double factorial = n;
            /* Multiply by every positive integer less than n */
            for (double i = n - 1; i > 0; i--)
            {
                factorial = factorial * i;
            }

            return factorial;
        }

        /* This method converts a number from decimal (base 10) to binary (base 2). */
        public static long decimalToBinary(long n)
        {
            try
            {
                /* Special case, decimal 0 = binary 0 */
                if (n == 0)
                {
                    return 0;
                }

                /* Store n's sign then make it positive to do the conversion on a positive number below */
                int sign = 1;
                if (n < 0)
                {
                    sign = -1;
                    n = -n;
                }

                /* Instantiate new empty string to hold binary result of function */
                string binString = "";
                /* Divides decimal by 2 and adds remainder to the beginning of binString to simulate keeping binary numbers from right to left
                   Divides decimal by 2 keeping only the whole number for use through the next loop */
                while (n > 0)
                {
                    var r = n % 2;
                    n = n / 2;
                    binString=r+binString;
                }

                /* Convert the binary string to long and add the sign back in */
                return sign * long.Parse(binString);

            }
            catch
            {
                Console.WriteLine("Exception occured while computing decimalToBinary()");
            }

            return 0;
        }

        /* This method converts a number from binary (base 2) to decimal (base 10). */
        public static long binaryToDecimal(long n)
        {
            try
            {
                /* Special case, decimal 0 = binary 0 */
                if (n == 0)
                {
                    return 0;
                }

                /* Store n's sign then make it positive to do the conversion on a positive number below */
                int sign = 1;
                if (n < 0)
                {
                    sign = -1;
                    n = -n;
                }

                /* Convert n from type long to a string to be able to go digit-by-digit
                   Store the string length for later use in the loop 
                   Subtract 1 from the length of the string to enable the use of the position index to pull characters from the binary string from right to left */
                string binString = n.ToString();
                int len = binString.Length - 1;
                long dec = 0;
                for (int x = 0; x <= len; x++)
                {
                    // Process the next digit. If '0', continue to the next power of two. If '1', add the power of two. If anything else, throw an Exception since n is not binary.
                    switch (binString[x])
                    {
                        case '0':
                            continue;
                        case '1':
                            dec += Power(len - x);
                            break;
                        default:
                            throw new ArgumentException("String representation of n must be only 0's and 1's.");
                    }
                }

                /* Add the sign back in */
                return sign * dec;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing binaryToDecimal()");
            }

            return 0;
        }

        /* This method calculates the ith power of 2. */
        public static int Power(int i)
        {
            /* Multiply by 2, i times, to calculate 2^i */
            int q = 1;
            for (/* int i */; i > 0; i--)
            {
                q *= 2;
            }

            return q;
        }

        /* This method prints a triangle using '*'. For negative numbers, prints the triangle upside-down */
        public static void printTriangle(int n)
        {
            try
            {
                /* Store n's sign then make it positive to do the conversion on a positive number below */
                bool negative = false;
                if (n < 0)
                {
                    negative = true;
                    n = -n;
                }

                /* Print n rows, one row at a time */
                for (int i = 1; i <= n; i++)
                {
                    /* Adjust the rows so it goes n--1 instead of 1--n for negative numbers */
                    int row = i;
                    if (negative)
                    {
                        row = n - i + 1;
                    }

                    /* The number of stars on row i is the ith odd number, which is 2i-1 */
                    int printStars = (row * 2) - 1;
                    /* The number of spaces before the first star on row i is one space for each remaining row after i, which is n-i */
                    int nonStars = n - row;
                    /* Print the spaces before the stars */
                    for (int j=1; j <= nonStars; j++)
                    {
                        Console.Write(" ");
                    }
                    /* Print the stars */
                    for (int k=1; k <= printStars; k++)
                    {
                        Console.Write("*");
                    }
                    /* Go to the next line */
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }
        }

        /* This method computes the frequency of each element in the array */
        public static void computeFrequency(int[] a)
        {
            try
            {
                /* If there are no integers, do nothing */
                if (a == null || a.Length == 0)
                {
                    return;
                }

                /* Go through the array once to find the highest and lowest value */
                int max = a[0], min = a[0];
                foreach (int number in a)
                {
                    if (number>max)
                    {
                        max = number;
                    }
                    
                    if (number<min)
                    {
                        min = number;
                    }
                }

                /* Declare an array to track the frequency of each integer. Size is max-min+1 to include room to tally from min to max, inclusive */
                int[] frequency = new int[max-min+1];
                /* Go through the array tallying the numbers */
                foreach (int numbers in a)
                {
                    /* Offset index by min to match the sizing of the array */
                    frequency[numbers-min]++;
                }
                
                /* Output the results, skipping integers with 0 frequency */
                Console.WriteLine( "Number\tFrequency");
                for (int i = min; i <= max; i++)
                {
                    if (frequency[i-min]>0)
                    {
                        Console.Write(i);
                        Console.Write("\t");
                        Console.Write(frequency[i-min]);
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

