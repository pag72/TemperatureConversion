using TemperatureAPI.Helpers;

namespace TemperatureAPI.UnitTest.Helpers
{
    public class When20CelsiusIsConvertedToFahrenheit
    {
        [Fact]
        public void FarernheitIsReturned()
        {
            var fahrenheit = TemperatureConverter.CelsiusToFahrenheit(20);
            Assert.True(fahrenheit == 68);
        }
    }

    public class When20CelsiusIsConvertedToKelvin
    {
        [Fact]
        public void AValueOf293Point15IsReturned()
        {
            var kelvin = TemperatureConverter.CelsiusToKelvin(20);
            Assert.True(kelvin == 293.15);
        }
    }

    public class When5FahrenheitIsConvertedToCelsius
    {
        [Fact]
        public void AValueOfMinus15IsReturned()
        {
            var celsius = TemperatureConverter.FahrenheitToCelsius(5);
            Assert.True(celsius == -15);
        }
    }

    public class When5KelvinIsConvertedToCelsius
    {
        [Fact]
        public void AValueOfMinus268Point15IsReturned()
        {
            var celsius = TemperatureConverter.KelvinToCelsius(20);
            Assert.True(celsius == -268.15);
        }
    }

    public class WhenMinus274CelsiusIsConvertedToFahrenheit
    {
        [Fact]
        public void AnErrorIsReturned()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => TemperatureConverter.CelsiusToFahrenheit(-274));
        }
    }

    public class WhenMinus273Point16CelsiusIsConvertedToKelvin
    {
        [Fact]
        public void AnErrorIsReturned()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => TemperatureConverter.CelsiusToKelvin(-273.16));
        }
    }

    public class WhenMinus1KelvinIsConvertedToCelsius
    {
        [Fact]
        public void AnErrorIsReturned()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => TemperatureConverter.KelvinToCelsius(-1));
        }
    }

    public class WhenMinus459Point68FahrenheitIsConvertedToCelsius
    {
        [Fact]
        public void AnErrorIsReturned()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => TemperatureConverter.FahrenheitToCelsius(-459.68));
        }
    }
}


