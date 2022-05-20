using Microsoft.Extensions.Logging;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SetAssessment.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using SetAssessment;
using System.Linq;

namespace SetAssessmentTests
{
    [TestFixture]
    public class WeatherTests
    {

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        internal WeatherForecastController weatherForecastController;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [SetUp]
        public void Setup()
        {
            var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>();
            Assume.That(factory != null, "Unable to set up logger to test WeatherForcastController. Logger factory was NULL!");
            var logger = factory.CreateLogger<WeatherForecastController>();
            weatherForecastController = new WeatherForecastController(logger);
            Assume.That(weatherForecastController != null, "The weather forcast controller was NULL!");
        }

        [Test]
        public void Test1()
        {
            //Assert.Pass();
            IEnumerable<WeatherForecast> forcast = weatherForecastController.Get();
            Assert.IsNotNull(forcast, "Forcast was NULL!");
            List<WeatherForecast> forcastList = forcast.ToList();
            Assert.IsTrue(forcastList.Count == 5, "Expected 5 forcasts in the list but received: " + forcastList.Count);
        }
    }
}