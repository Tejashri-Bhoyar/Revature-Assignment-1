using System;

namespace ArithmeticPolymorphism
{
    // Base class
    public abstract class ArithmeticExpression
    {
        public double Left { get; }
        public double Right { get; }

        protected ArithmeticExpression(double left, double right)
        {
            Left = left;
            Right = right;
        }

        // Polymorphic method
        public abstract double Evaluate();
    }

    // Addition
    public class Addition : ArithmeticExpression
    {
        public Addition(double left, double right) 
            : base(left, right) { }

        public override double Evaluate()
        {
            return Left + Right;
        }
    }

    // Subtraction
    public class Subtraction : ArithmeticExpression
    {
        public Subtraction(double left, double right) 
            : base(left, right) { }

        public override double Evaluate()
        {
            return Left - Right;
        }
    }

    // Multiplication
    public class Multiplication : ArithmeticExpression
    {
        public Multiplication(double left, double right) 
            : base(left, right) { }

        public override double Evaluate()
        {
            return Left * Right;
        }
    }

    // Division
    public class Division : ArithmeticExpression
    {
        public Division(double left, double right) 
            : base(left, right) { }

        public override double Evaluate()
        {
            if (Right == 0)
                throw new DivideByZeroException("Cannot divide by zero");

            return Left / Right;
        }
    }
}