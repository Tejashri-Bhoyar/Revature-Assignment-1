public class ExpressionBodiedMembersDemo
{
    public class Demo
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        // fat arrow
        public int Subtract(int a, int b) => a - b;

        public int Multiply(int a, int b) => a * b;
    }

}