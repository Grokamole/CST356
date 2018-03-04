using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using FakeItEasy;
using Lab7.Data.Entities;
using Lab7.Repositories;
using Lab7.Services;

namespace Lab7.Tests
{
    [TestFixture]
    public class CarServiceTests
    {
        private ICarRepository repository;

        [SetUp]
        public void SetUp()
        {
            repository = A.Fake<ICarRepository>();
        }

        [Test]
        public void ShouldHaveMarkupForColor()
        {
            // Arrange
            A.CallTo(() => repository.GetCar(A<int>.Ignored)).Returns(new Car
            {
                Color = "Pink"
            });

            // Act (SUT)
            var carService = new CarService(repository);
            var carViewModel = carService.GetCarDetails(1);

            // Assert
            NUnit.Framework.Assert.IsTrue(carViewModel.Color.Contains("f1948a"));
        }

        [Test]
        public void ShouldNotHaveMarkupForColor()
        {
            // Arrange
            A.CallTo(() => repository.GetCar(A<int>.Ignored)).Returns(new Car
            {
                Color = "Black"
            });

            // Act (SUT)
            var carService = new CarService(repository);
            var carViewModel = carService.GetCarDetails(1);

            // Assert
            NUnit.Framework.Assert.IsFalse(carViewModel.Color.Contains("f1948a"));
        }
    }
}
