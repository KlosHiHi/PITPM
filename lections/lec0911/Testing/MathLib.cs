namespace Testing
{
    public static class MathLib
    {
        public static (double? x1, double? x2) Quadratic(double a, double b, double c) // нахождение корней кв уравнения
        {
            double D = (b * b - 4 * a * c);
            if (D > 0)
                return (-b + Math.Sqrt(D) / (2 * a), -b - Math.Sqrt(D) / (2 * a));
            else if (D == 0)
                return (-b / (2 * a), -b / (2 * a));
            else
                return (null, null); 
        }
    }
}
