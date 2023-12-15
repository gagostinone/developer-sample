using Xunit;

namespace DeveloperSample.ClassRefactoring
{
    public class ClassRefactorTest
    {
        [Fact]
        public void AfricanSwallowHasCorrectSpeed()
        {
            var swallowFactory = new SwallowFactory();
            var swallow = swallowFactory.GetSwallow(SwallowType.African);
            Assert.Equal(22, swallow.GetAirspeedVelocity());
        }

        [Fact]
        public void LadenAfricanSwallowHasCorrectSpeed()
        {
            var swallowFactory = new SwallowFactory();
            var swallow = swallowFactory.GetSwallow(SwallowType.African);
            swallow.ApplyLoad(SwallowLoad.Coconut);
            Assert.Equal(18, swallow.GetAirspeedVelocity());
        }

        [Fact]
        public void EuropeanSwallowHasCorrectSpeed()
        {
            var swallowFactory = new SwallowFactory();
            var swallow = swallowFactory.GetSwallow(SwallowType.European);
            Assert.Equal(20, swallow.GetAirspeedVelocity());
        }

        [Fact]
        public void LadenEuropeanSwallowHasCorrectSpeed()
        {
            var swallowFactory = new SwallowFactory();
            var swallow = swallowFactory.GetSwallow(SwallowType.European);
            swallow.ApplyLoad(SwallowLoad.Coconut);
            Assert.Equal(16, swallow.GetAirspeedVelocity());
        }

        [Fact]
        public void GetAirspeedVelocity_WithInvalidSwallowLoad_ThrowsUnsupportedSwallowLoadException()
        {
            // Arrange
            var swallow = new EuropeanSwallow();
            swallow.ApplyLoad((SwallowLoad)999); //Invalid Load Number

            // Act & Assert
            Assert.Throws<UnsupportedSwallowLoadException>(() => swallow.GetAirspeedVelocity());
        }

        [Fact]
        public void GetSwallow_WithInvalidSwallowType_ThrowsUnsupportedSwallowTypeException()
        {
            // Arrange
            var swallowFactory = new SwallowFactory();
            var invalidSwallowType = (SwallowType)999; //Invalid Swallow Number

            // Act & Assert
            Assert.Throws<UnsupportedSwallowTypeException>(() => swallowFactory.GetSwallow(invalidSwallowType));
        }
    }
}