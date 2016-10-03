using App.Factories;
using Core.enums;
using Domain;
using Moq;
using NUnit.Framework;

namespace App.Tests.Unit.CarCreatorTests
{
    [TestFixture]
    public class ProduceTests
    {
        private Mock<ICarFactory> _mockCarFactory;

        private Car _result;
        private Car _expectedResult;

        [OneTimeSetUp]
        public void GivenACarFactory_WhenProduceIsCalled()
        {
            _expectedResult = new Car
            {
                Manufacturer = "Ford",
                Make = "Ka",
                Engine = new Engine
                {
                    EngineSize = EngineSize.ReallyBig,
                    EngineType = "V6"
                }
            };

            _mockCarFactory = new Mock<ICarFactory>();
            _mockCarFactory.Setup(factory => factory.Produce()).Returns(_expectedResult);

            var carCreator = new CarCreator(_mockCarFactory.Object);
            _result = carCreator.Create();
        }

        [Test]
        public void ThenACarShouldBeReturned()
        {
            Assert.That(_result.GetType(), Is.EqualTo(typeof(Car)));
        }

        [Test]
        public void ThenTheCarShouldHaveTheExpectedEngineSize()
        {
            Assert.That(_result.Engine.EngineSize, Is.EqualTo(EngineSize.ReallyBig));   
        }

        [Test]
        public void ThenTheCareShouldHaveTheExpectedEngineType()
        {
            Assert.That(_result.Engine.EngineType, Is.EqualTo(_expectedResult.Engine.EngineType));
        }

        [Test]
        public void ThenTheCarShouldHaveTheExpectedManufacturer()
        {
            Assert.That(_result.Manufacturer, Is.EqualTo(_expectedResult.Manufacturer));
        }

        [Test]
        public void ThenTheCarShouldHaveTheExpectedMake()
        {
            Assert.That(_result.Make, Is.EqualTo(_expectedResult.Make));
        }
    }
}
