using Library;

namespace UnitTest
{
    public class UnitTest
    {
        [Fact]
        public void Sum_3Plus2_Returns5()
        {
            int a = 3;
            int b = 2;
            int expected = 5;

            int actual = MathLib.Sum(a, b);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetUsers()
        {
            yield return new object[] { new User("Ivan", "ivan@mail.ru"), "Ivan ivan@mail.ru" };
            yield return new object[] { new User("Nikolay", "ni@mail.ru"), "Nikolay ni@mail.ru" };
        }

        public static IEnumerable<object[]> GetNumbers()
        {
            yield return new object[] { 1, 2, 3 };
            yield return new object[] { 4, 4, 8 };
        }

        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(0, 1, 1)]
        [InlineData(-3, 3, 0)]
        [ClassData(typeof(SumDataGenerator))]
        [MemberData(nameof(GetNumbers))]
        public void Sum_Theory(int a, int b, int expected)
        {
            int actual = MathLib.Sum(a, b);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetUsers))]
        public void GetUserString_Theoy(User user, string expected)
        {
            string actual = UserLib.GetUserString(user);

            Assert.Equal(expected, actual);
        }
    }
}