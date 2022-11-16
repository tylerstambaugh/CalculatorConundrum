// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography.X509Certificates;

string output = SimpleCalculator.Calculate(23, 25, "+");
Console.WriteLine(output);
Console.WriteLine();

//output = SimpleCalculator.Calculate(23, 25, "");
//Console.WriteLine(output + "  -empty string");
//Console.WriteLine();

output = SimpleCalculator.Calculate(23, 25, null);
Console.WriteLine(output + "  - null");
Console.WriteLine();

output = SimpleCalculator.Calculate(23, 25, "(");
Console.WriteLine(output + " - (");
Console.WriteLine();

output = SimpleCalculator.Calculate(23, 0, "/");
Console.WriteLine(output + "divide by zero");
Console.ReadLine();



public class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation)
    {
        string output = "";
        try
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            if (operation == "")
            {
                throw new ArgumentException(nameof(operation));
            }

            if (!(operation == "+") &&
                !(operation == "*") &&
                !(operation == "/"))
            {
                throw new ArgumentOutOfRangeException(nameof(operation));
            }

            if (operand2 == 0 && operation == "/")
            {
                throw new DivideByZeroException();
            }

            Func<int, int> answer = (x =>
            {
                return operand1 * operand2;
            });

            output = $"{operand1} {operation} {operand2} = {answer}";

        }

        catch (ArgumentNullException e)
        {
            Console.WriteLine($"Argument null exception {e.Message}");
            //throw;
            
        }
        
        catch(ArgumentOutOfRangeException e)
        {
            Console.WriteLine($"Argument out of range exception {e.Message}");
            //throw;

        }
        catch (DivideByZeroException e)
        {
            return "Division by zero is not allowed.";
            
        }
        catch (ArgumentException e) 
        {
            Console.WriteLine($"Argument exception {e.Message}");
           // throw;
            
        }

        return output;
    }
}