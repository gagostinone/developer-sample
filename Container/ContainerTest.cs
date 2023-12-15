using System;
using Xunit;

namespace DeveloperSample.Container
{
    internal interface IContainerTestInterface
    {
    }

    internal class ContainerTestClass : IContainerTestInterface
    {
    }

    public class ContainerTest
    {
        [Fact]
        public void CanBindAndGetService()
        {
            var container = new Container();
            container.Bind(typeof(IContainerTestInterface), typeof(ContainerTestClass));
            var testInstance = container.Get<IContainerTestInterface>();
            Assert.IsType<ContainerTestClass>(testInstance);
        }
        [Fact]
        public void Bind_WithInvalidInterfaceType_ThrowsArgumentException()
        {
            // Arrange
            var container = new Container();
            var invalidInterfaceType = typeof(ContainerTestClass);
            var validImplementationType = typeof(object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => container.Bind(invalidInterfaceType, validImplementationType));
        }

        [Fact]
        public void Bind_WithInvalidImplementationType_ThrowsArgumentException()
        {
            // Arrange
            var container = new Container();
            var validInterfaceType = typeof(ContainerTestClass);
            var invalidImplementationType = typeof(string);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => container.Bind(validInterfaceType, invalidImplementationType));
        }

        [Fact]
        public void Get_WithUnboundType_ThrowsInvalidOperationException()
        {
            // Arrange
            var container = new Container();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => container.Get<IComparable>());
        }
    }
}