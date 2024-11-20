using MathOperations.Services;

namespace MathOperations.Services
{
    public class MathService : IMathService
    {
        public int Add(int num1, int num2) => num1 + num2;
        public int Subtract(int num1, int num2) => num1 - num2;
        public int Multiply(int num1, int num2) => num1 * num2;
        public double Divide(int num1, int num2)
        {
            if(num2 == 0) 
                throw new DivideByZeroException("Division by zero is not allowed");
            return (double)num1 / num2; 
        }
    }
}
