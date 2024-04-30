using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            Console.Clear();
            Console.WriteLine("Nothing OS");
            Console.WriteLine();
        }

        protected override void Run()
        {
            Console.Write(">");
            var input = Console.ReadLine();
            var args = input.Split(' ');
            if (args.Length != 0) 
            {
                switch (args[0])
                {
                   case "help":
                        {
                            Console.WriteLine("restart -- reboot the computer");
                            Console.WriteLine("shutdown -- shutdown the computer");
                            Console.WriteLine("cls -- clear the console");
                            Console.WriteLine("calculator -- open the calculator");
                            break;
                        }
                   case "shutdown":
                        {
                            Sys.Power.Shutdown();
                            break;
                        }
                   case "restart":
                        {
                            Sys.Power.Reboot();
                            break;
                        }
                   case "cls":
                        {
                            Console.Clear();
                            Console.WriteLine("Nothing OS");
                            Console.WriteLine();
                            break;
                        }
                    case "calculator":
                        {
                            Console.WriteLine("Enter an expression in the format: [number] [operator] [number]");
                            string expression = Console.ReadLine();
                            string[] parts = expression.Split(' ');
                            if (parts.Length == 3)
                            {
                                double num1, num2;
                                if (double.TryParse(parts[0], out num1) && double.TryParse(parts[2], out num2))
                                {
                                    double result = 0;
                                    switch (parts[1])
                                    {
                                        case "+":
                                            result = num1 + num2;
                                            break;
                                        case "-":
                                            result = num1 - num2;
                                            break;
                                        case "*":
                                            result = num1 * num2;
                                            break;
                                        case "/":
                                            if (num2 != 0)
                                                result = num1 / num2;
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Error: Division by zero.");
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }
                                            break;
                                        default:
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Error: Invalid operator.");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            break;
                                    }
                                    Console.WriteLine("Result: " + result);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error: Invalid numbers.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error: Invalid expression format.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            break;
                        }
                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid Command");
                            Console.WriteLine("use help to view the list of commands");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }
                }
            }
        }
    }
}
