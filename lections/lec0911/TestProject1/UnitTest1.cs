using Testing;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Quadratic_WithPoZitiveDiscriminant_ShouldBeTwoResults()
        {
            //Arrange
            double a = 6, b = 1, c = -1;
            //Act
            var result = MathLib.Quadratic(a, b, c);
            //Assert
            Assert.True(result.x1 != null && result.x2 != null && result.x1 != result.x2);
        }

        [Fact]
        public void Quadratic_WithPoZitiveDiscriminant_ShouldBeOneResults()
        {
            //Arrange
            double a = 9, b = -6, c = 1;
            //Act
            var result = MathLib.Quadratic(a, b, c);
            //Assert
            Assert.True(result.x1 != null && result.x2 != null && result.x1 == result.x2);
        }

        [Fact]
        public void Quadratic_WithNiggativeDiscriminant_ShouldBeTwoResults()
        {
            //Arrange
            double a = 1, b = -4, c = 5;
            //Act
            var result = MathLib.Quadratic(a, b, c);
            //Assert
            Assert.True(result.x1 == null && result.x2 == null);
        }
    }
}