using System;

namespace Versioning.Models
{
    public class WeatherForecastV2
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);   //New auto-calculated property

        public string Text { get; set; }    // New test property

        public string Summary { get; set; }
    }
}
