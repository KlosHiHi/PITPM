namespace Library
{
    public class MathLib
    {
        public static int Sum(int a, int b) => a + b;

        public static double Div(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException();

            return a / b;
        }
    }
}
