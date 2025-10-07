using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Extensions;
using Library;
using Library.Users;
using Moq;

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

        //[Theory]
        //[MemberData(nameof(GetUsers))]
        //public void GetUserString_Theoy(User user, string expected)
        //{
        //    string actual = UserService.GetUserString(user);

        //    Assert.Equal(expected, actual);
        //}

        [Fact]
        public void Div_WithCorrectValues_ReturnResult()
        {
            double a = 1, b = 3;

            double expected = 0.3;

            double actual = MathLib.Div(a, b);

            Assert.Equal(expected, actual, 0.04);
        }

        [Fact]
        public void Div_WithZeroDivider_ThrowsException()
        {
            double a = 1, b = 0;

            Assert.Throws<DivideByZeroException>(() => MathLib.Div(a, b));
        }

        //[Fact]
        //public void FluentAssertionsTest()
        //{
        //    string actual = "Hello World";
        //    var action = () => { throw new Exception("Hi-hi"); };
        //    List<int> numbers = new() { 1, 2, 3, -1 };
        //    List<User> user = new()
        //    {
        //        new User("Ivan", "ivan@mail.ru"),
        //        new User("Nikolay", "ni@mail.ru")
        //    };

        //    new UnitTest().ExecutionTimeOf(x => x.Div_WithZeroDivider_ThrowsException()).Should().BeLessThan(500.Seconds());
        //    DateTime date = new(2020, 05, 10, 21, 20, 30);
        //    10.May(2020).At(21, 20, 30).Should().Be(date);

        //    using (new AssertionScope())
        //    {
        //        actual.Should().StartWith("He").And.EndWith("d").And.Contain("ll").And.HaveLength(11);
        //        action.Should().Throw<Exception>().WithMessage("Hi-hi");
        //        actual.Should().BeNullOrWhiteSpace();
        //        actual.Should().Be("Hello World");
        //        actual.Should().BeSameAs(actual);
        //        actual.Should().BeOfType<string>();

        //        numbers.Should().BeInAscendingOrder();
        //        numbers.Should().OnlyContain(n => n > 0).And.HaveCount(4, "bcs i use arch btw");

        //        user.Should().AllSatisfy(x =>
        //        {
        //            x.Name.Should().HaveLength(3);
        //            x.Name.Should().NotBeNullOrEmpty();
        //        });
        //    }
        //}

        //[Fact]
        //public void MoqTest()
        //{
        //    var mock = new Mock<IRepository>();
        //    mock.Setup(x => x.GetStrings()).Returns(new List<string> { "hello", "goodbye" });

        //    var repository = mock.Object;

        //    repository.GetStrings().Should().Contain("hello");

        //    mock.Verify(x=> x.GetStrings(), Times.Once);
        //}
    }
}