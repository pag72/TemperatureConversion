using TemperatureAPI.Shared.Models;

namespace TemperatureAPI.Helpers
{
    public static class TemperatureConverter
    {
        public static double CelsiusToFahrenheit(double temperature)
        {
            if (temperature < -273.15)
            {
                throw new ArgumentOutOfRangeException($"The value of Celsius cannot be less than -273.15");
            }
            return temperature * 9 / 5 + 32;
        }

        public static double CelsiusToKelvin(double temperature)
        {
            if (temperature < -273.15)
            {
                throw new ArgumentOutOfRangeException($"The value of Celsius cannot be less than -273.15");
            }
            return temperature + 273.15;
        }

        public static double KelvinToCelsius(double temperature)
        {
            if (temperature < 0)
            {
                throw new ArgumentOutOfRangeException($"The value of Kelvin cannot be less than 0");
            }
            return temperature - 273.15;
        }

        public static double FahrenheitToCelsius(double temperature)
        {
            if (temperature < -459.67)
            {
                throw new ArgumentOutOfRangeException($"The value of Fahrenheit cannot be less than -459.67");
            }
            return (temperature - 32) * 5 / 9;
        }

        public static TemperatureConversion ConvertTemperature(string scale, double temperature)
        {
            var temperatureConversion = new TemperatureConversion();
            switch (scale)
            {
                case "celsius":
                    temperatureConversion.Celsius = temperature;
                    temperatureConversion.Fahrenheit = CelsiusToFahrenheit(temperature);
                    temperatureConversion.Kelvin = CelsiusToKelvin(temperature);
                    break;
                case "kelvin":
                    temperatureConversion.Celsius = KelvinToCelsius(temperature);
                    temperatureConversion.Fahrenheit = CelsiusToFahrenheit(temperatureConversion.Celsius);
                    temperatureConversion.Kelvin = temperature;
                    break;
                case "fahrenheit":
                    temperatureConversion.Celsius = CelsiusToFahrenheit(temperature);
                    temperatureConversion.Fahrenheit = temperature;
                    temperatureConversion.Kelvin = CelsiusToFahrenheit(temperatureConversion.Celsius);
                    break;
                default:
                    break;
            }
            return temperatureConversion;
        }

    }
}

