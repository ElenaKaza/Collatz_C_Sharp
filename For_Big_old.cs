using System;

namespace Collatz31
{
    class Program
    {
        static void Main(string[] args)
        {
            void Collatz() // our function 
            {
                int  SumMembers(int[] x)
                {
                    int sum = 0;
                    foreach (int value in x)
                    {
                        sum += value;
                    }
                    //Console.WriteLine( "sum =  " + sum);
                    if (x[^1] == 1 && sum == 1 )
                    {
                        sum = 0;
                    }
                    return sum;
                }
                void for_even (int[] x) // division on 2
                {
                    int w = 0;
                    for (int i = 0; i < x.Length; i++)
                    {
                        x[i] += 10 * w;
                        w = x[i] % 2;
                        x[i] = x[i] / 2;
                    }
                }
                void for_odd(int[] x) // 3*arr+1
                {
                    int w = 0;

                    for (int i = x.Length - 1; i >= 0; i--)
                    {
                        x[i] = 3 * x[i];
                        x[i] += w;

                        if (x[i] > 9)
                        {
                            w = x[i] / 10; // 2 from 27
                            x[i] = x[i] % 10; // 7 from 27
                        }
                        else
                        {
                            w = 0;
                        }

                    }
                }
                void add_1(int[] x) // +1
                {
                    int w = 0;
                    for (int i = x.Length - 1; i >= 0; i--)
                    {
                        x[i] += w;
                        if (x[i] == 9)
                        {
                            x[i] = 0;
                            w = 1;
                        }
                        else if (x[i] == 10)
                        {
                            x[i] = 0;
                            w = 1;
                        }
                        else
                        {
                            x[i] = x[i] + 1 - w;
                            break;
                        }

                    }
                   
                }
                
                int q1 = 0; //amount of even
                int q2 = 0; //amount of odd
                                
                Console.WriteLine("Input some number:");
                string N = Console.ReadLine(); // input number into string
                char[] ar = N.ToCharArray(); // then into  char array
                int[] arr = new int[ar.Length]; //create new int array
                Array.Resize(ref arr, arr.Length + 1); // increase length for 1
               
                for (int i = 0; i < ar.Length; i++) //write char into int array
                    {
                    arr[i] = ar[i] - '0';
                    }
                for (int i = arr.Length - 1; i > 0; i--) // 
                {
                    arr[i] = arr[i - 1];
                }
                
                //int[] arr1 = new int[arr.Length];
                int[] maxmemb = new int[arr.Length];             
                arr[0] = 0; // set the first member = 0

                while (SumMembers(arr) != 0)
                {
                    if (arr[^1] % 2 == 0) // if last member is even, number is even
                    {
                        for_even(arr);// call arr/2 function;
                        q1 += 1; // number of 2k operations
                    }
                    else
                    {
                        for_odd(arr);//call 3*arr function;
                        add_1(arr);//call add_1 function; 
                        q2 += 1; // number of 3k+1 operations
                    }
                    
                    for (int i = 0; i < arr.Length; i++) // compare arrays
                    {
                        
                        if (maxmemb[i] < arr[i])
                        {
                            Array.Copy(arr, 0, maxmemb, 0, arr.Length);
                            break;

                        }
                        else if (maxmemb[i] > arr[i])
                        {
                            break;
                        }

                    }
                }
                Console.WriteLine("number of 2k operations = " + q1);
                Console.WriteLine("number of 3k+1 operations = " + q2);
                Console.WriteLine("Maximum member = ");
                Console.WriteLine(string.Join("",maxmemb));

            }
            // The begin of executable code:
            string willing = "y";
            while (willing == "y")
            {
                Console.WriteLine("Do you want to investigate Collatz sequence?");
                Console.WriteLine("If Yes, press Y");
                willing = Console.ReadLine();
                willing = willing.ToLower();
                if (willing == "y")
                { Collatz(); }
                else
                { Console.WriteLine("Bye!"); }
            }

        }
    }
}
