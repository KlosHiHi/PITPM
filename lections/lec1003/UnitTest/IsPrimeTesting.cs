using Library;

namespace UnitTest
{
    public class IsPrimeTesting
    {
        [Theory]
        [InlineData(2)]
        [InlineData(7)]
        [InlineData(11)]
        public void IsPrime_OnPrimeNumbres_ReturnTrue(int prime)
        {
            var result = MathLib.IsPrime(prime);

            Assert.True(result);
        }

        [Fact]
        public void IsPrime_OnNegativeValues_ThrowsExeption()
        {
            Assert.Throws<ArgumentOutOfRangeException>(()
                => MathLib.IsPrime(-1));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(4)]
        public void IsPrime_OnNonePrimeNumbers_ReturnsFalse(int prime)
        {
            var result = MathLib.IsPrime(prime);
            Assert.False(result);
        }
    }
}