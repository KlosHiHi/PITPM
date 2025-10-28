using FluentAssertions;
using PasswordLibrary;

namespace xUnitTestProject
{
    public class UnitTest
    {
        [Fact]
        public void IsPasswordValidate_CorrectData_ReturnTrue()
        {
            var result = Password.IsPasswordValidate("1qWd67!h");

            result.Should().BeTrue();
        }

        [Fact]
        public void IsPasswordValidate_WithLittleLength_ReturnFalse()
        {
            var result = Password.IsPasswordValidate("123qwe");

            result.Should().BeFalse();
        }

        [Fact]
        public void IsPasswordValidate_WithoutDigit_ReturnFalse()
        {
            var result = Password.IsPasswordValidate("qwertyUi");

            result.Should().BeFalse();
        }

        [Fact]
        public void IsPasswordValidate_WithoutLatWord_ReturnFalse()
        {
            var result = Password.IsPasswordValidate("привет2007");

            result.Should().BeFalse();
        }
    }
}