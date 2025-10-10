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

        public static bool IsPrime(int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException();
            if (n <= 1)
                return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        //Примеры мутаций
        /*
        a+b => a-b
        a*b => a/b
        True => False
        a>b => a<b
        [1, 2, 4] => []
        "Hello" => "Goodbye"
        a && b => a || b 
        

        выражение; => ;
        условие => !условие

        При каждом тесте вноситься лишь одна мутаци

        Виды мутаций:
        - Убитые (выявленные) - мутации, которые выявил хотя бы один код.
        - Выжившие (невыявленные) - мутации, которые необнаружилне один из тестов.

        - Покрытые
        - Непокрытые

        MSI - (Mutatuion Score Indicator) = Кол-во убитых / Общее кол-во * 100%
        */
    }
}
