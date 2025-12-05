using System;
public class Program
{
    // Performs a basic mathematical operation between two numbers
    public static double BasicCalc(double n1, double n2, char? op)
    {
        switch (op)
        {
            case '+':
                double sum = n1 + n2;
                return sum;
            case '-':
                double diff = n1 - n2;
                return diff;
            case '*':
                double pro = n1 * n2;
                return pro;
            case '/':
                double quo = n1 / n2;  // no division-by-zero check here    
                return quo;
            default:
                // Operator entered is invalid
                throw new ArithmeticException($"Error: the entered symbol '{op}' is not a valid math operator, enter one of this symbols +, -, *, /.");
        }
    }

    // Calculates the average of an array of integers
    public static double CalculateAverageGrade(double[] grades)
    {
        double sum = grades.AsEnumerable().Sum();

        double gra = sum / grades.Length;
        return gra;
    }

    // Returns baseNum raised to the exponent power
    public static double PowerOf(double baseNum, int exponent)
    {
        double power = Math.Pow(baseNum, exponent);
        return power;
    }

    // Returns the square root of a given number
    public static double Sqrt(double radicant)
    {
        double root = Math.Sqrt(radicant);
        return root;
    }

    // Returns a percentage of a given value
    public static double Percentage(double value, int percentage)
    {
        double percOf = value * percentage / 100;
        return percOf;
    }

    // Computes a trigonometric function (sine, cosine, tangent) on an angle in degrees
    public static double AngleCalc(double angle, string? trigonometryFun)
    {
        // Convert degrees to radians because Math functions use radians
        double radAngle = angle * Math.PI / 180;
        
        switch (trigonometryFun)
        {
            case "sine":
                double sine = Math.Sin(radAngle);
                return sine;
            case "cosine":
                double cosine = Math.Cos(radAngle);
                return cosine;
            case "tangent":
                double tangent = Math.Tan(radAngle);
                return tangent;
            default:
                // If the function name is not recognized
                throw new ArithmeticException($"Error: the entered trigonometry function is not valid, please enter one of the following functions (sine, cosine, tangent).");
        }
    }

    public static void Main(string[] arg)
    {
        // Main loop allowing the user to restart or exit after each operation
        while (true)
        {
            Console.WriteLine($"ADVANCED MULTI-MODE CALCULATOR");
            Console.WriteLine($"Chose mode: ");
            Console.WriteLine($"1: Basic calculator");
            Console.WriteLine($"2: Advanced calculator");
            Console.WriteLine($"3: Grade calculator");

            // Validate mode selection (must be 1, 2, or 3)
            if (!int.TryParse(Console.ReadLine(), out int mod) || mod < 1 || mod > 3)
            {
                Console.WriteLine("Error: please enter a valid number between 1 and 3 to select a mode.");
                continue;   // restart loop
            }

            switch (mod)
            {
                // ---------------------- BASIC CALCULATOR ----------------------
                case 1:
                    Console.WriteLine($"BASIC CALCULATOR MODE");

                    // Read and validate operator
                    char ope;
                    Console.WriteLine("Enter math operator (+, -, *, /):");
                    while (!char.TryParse(Console.ReadLine(), out ope) || "+-*/".IndexOf(ope) == -1)    // Check if input is valid
                    {
                        Console.WriteLine("Error: the input is invalid, please enter a valid math operator (+, -, *, /).");
                    }

                    // Read first number
                    double num1;
                    Console.WriteLine("Enter first number:");
                    while (!double.TryParse(Console.ReadLine(), out num1))  // Check if input is valid
                    {
                        Console.WriteLine("Error: the input is invalid, please enter a valid number.");
                    }

                    // Read second number
                    double num2;
                    Console.WriteLine("Enter second number:");
                    while (!double.TryParse(Console.ReadLine(), out num2))  // Check if input is valid
                    {
                        Console.WriteLine("Error: the input is invalid, please enter a valid number.");
                    }

                    // Calculate and display result
                    double res1 = BasicCalc(num1, num2, ope);
                    Console.WriteLine($"Result is: {res1}");
                    break;


                // ---------------------- ADVANCED CALCULATOR ----------------------
                case 2:
                    Console.WriteLine($"ADVANCED CALCULATOR MODE");
                    Console.WriteLine($"Enter one of the following options (power, square root, percentage, trigonometry):");

                    // Read operation type and validate it
                    string? adop;
                    while (true)
                    {
                        adop = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(adop))
                            break;
                        Console.WriteLine("Error: enter one of the following options (power, square root, percentage, trigonometry):");
                    }

                    // Normalize the string for switch-case matching
                    adop = adop.Trim().ToLower();

                    switch (adop)
                    {
                        // ----- Power function -----
                        case "power":
                            double nu1;
                            Console.WriteLine("Enter the number to be raised to a power:");
                            while (!double.TryParse(Console.ReadLine(), out nu1))   // Check if input is valid
                            {
                                Console.WriteLine("Error: the input is invalid, please enter a valid number.");
                            }

                            int exp;
                            Console.WriteLine("Enter the exponent:");
                            while (!int.TryParse(Console.ReadLine(), out exp))  // Check if input is valid
                            {
                                Console.WriteLine("Error: the input is invalid, please enter a valid number.");
                            }

                            Console.WriteLine($"Result is: {PowerOf(nu1, exp)}");
                            break;

                        // ----- Square root function -----
                        case "square root":
                            double rad;
                            Console.WriteLine("Enter the radicand:");
                            while (!double.TryParse(Console.ReadLine(), out rad))   // Check if input is valid
                            {
                                Console.WriteLine("Error: the input is invalid, please enter a valid number.");
                            }
                            Console.WriteLine($"Result is: {Sqrt(rad)}");
                            break;

                        // ----- Percentage function -----
                        case "percentage":
                            double val;
                            Console.WriteLine("Enter the percentage base:");
                            while (!double.TryParse(Console.ReadLine(), out val))   // Check if input is valid
                            {
                                Console.WriteLine("Error: the input is invalid, please enter a valid number.");
                            }

                            int perc;
                            Console.WriteLine("Enter the percentage:");
                            while (!int.TryParse(Console.ReadLine(), out perc))     // Check if input is valid
                            {
                                Console.WriteLine("Error: the input is invalid, please enter a valid number.");
                            }

                            Console.WriteLine($"Result is: {Percentage(val, perc)}");
                            break;

                        // ----- Trigonometry -----
                        case "trigonometry":
                            string triFun;
                            int angle;

                            // Loop until the user enters a valid trigonometry function
                            while (true)
                            {
                                Console.WriteLine("Enter a trigonometry function (sine, cosine, tangent):");
                                string? triFun_nullable = Console.ReadLine()?.Trim().ToLower();

                                // Check if the input is one of the allowed functions
                                if (triFun_nullable == "sine" || triFun_nullable == "cosine" || triFun_nullable == "tangent")
                                {
                                    triFun = triFun_nullable;
                                    break; // Valid input → exit the loop
                                }

                                // Input is invalid → show error and repeat
                                Console.WriteLine("Error: invalid function. Please enter sine, cosine or tangent.");
                            }

                            // Loop until the user enters a valid integer angle
                            while (true)
                            {
                                Console.WriteLine("Enter angle:");
                                if (int.TryParse(Console.ReadLine(), out angle))
                                {
                                    break; // Valid number → exit the loop
                                }

                                // Invalid number → show error and repeat
                                Console.WriteLine("Error: please enter a valid number.");
                            }

                            // Call the AngleCalc function and display the result
                            Console.WriteLine($"Result is: {AngleCalc(angle, triFun)}");
                            break;


                        default:
                            Console.WriteLine("Error: invalid option.");
                            break;
                    }
                    break;


                // ---------------------- GRADE CALCULATOR ----------------------
                case 3:
                    Console.WriteLine($"GRADE CALCULATOR MODE");
                    Console.WriteLine($"Enter a sequence of numbers like this: n1;n2;...");

                    string text;

                    while (true)
                    {
                        // Ensure that at least one number is entered
                        string? text_nullable = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(text_nullable))
                        {
                            text = text_nullable;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Error: invalid input, please enter at least one number.");
                        }

                    }

                    double[] studentGrades = text
                        .Split(";") // Split at commas
                        .AsEnumerable() // Turn into enumerable
                        .Select(s => double.Parse(s)) // Turn all elements of the enumerable into doubles
                        .ToArray(); // Turn into array

                    // Calculate average grade
                    double averageGrade = CalculateAverageGrade(studentGrades);
                    Console.WriteLine($"Average grade: {averageGrade}");
                    break;


                default:
                    Console.WriteLine("Error: the input is invalid, please enter a valid number.");
                    break;
            }

            // Ask the user to restart or exit
            Console.WriteLine($"Enter 0 to exit or 1 to restart: ");
            if (!int.TryParse(Console.ReadLine(), out int findec) || findec > 1)
            {
                Console.WriteLine("Error: please enter 0 or 1.");
                continue;   // restart loop
            }

            if (findec == 0)
                break;
            else if (findec == 1)
                continue;
        }
    }
}
//Creator: PsHyCo71 _