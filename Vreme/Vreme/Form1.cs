using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Vreme
{
    public partial class Form1 : Form
    {
        private static readonly string ApiKey = "2ea8e51332377ce7ae6d78634925dd75"; // Single API key
        public Form1()
        {
            InitializeComponent();
            textBox1.KeyDown += textBox1_KeyDown;
        }

        private async void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string city = textBox1.Text;
                await GetAndDisplayGeoLocation(city);
            }
        }

        private async Task GetAndDisplayGeoLocation(string city)
        {
            List<WeatherApi.GeoLocation> locations = await WeatherApi.GetGeoLocation(city);

            if (locations != null && locations.Count > 0)
            {
                WeatherApi.GeoLocation location = locations[0];
                labelCity.Text = $"City: {location.name}";

                await GetAndDisplayWeather(location.lat, location.lon);
                await GetAndDisplayForecast(location.lat, location.lon);
            }
            else
            {
                MessageBox.Show("Failed to retrieve geolocation data.");
            }
        }

        private async Task GetAndDisplayWeather(double lat, double lon)
        {
            WeatherApi.WeatherData weatherData = await WeatherApi.GetWeatherData(lat, lon);

            if (weatherData != null)
            {
                labelTemperature.Text = $"Temperature: {weatherData.main.temp - 273.15:F2} °C";
                labelDescription.Text = $"Description: {weatherData.weather[0].description}";
                labelHumidity.Text = $"Humidity: {weatherData.main.humidity}%";
            }
            else
            {
                MessageBox.Show("Failed to retrieve weather data.");
            }
        }

        private async Task GetAndDisplayForecast(double lat, double lon)
        {
            WeatherApi.ForecastData forecastData = await WeatherApi.GetForecastData(lat, lon);

            if (forecastData != null && forecastData.list.Count > 0)
            {
                string forecastText = "3-Day Forecast:\n";

                for (int i = 0; i < 8 * 3; i += 8)
                {
                    DateTime forecastTime = DateTimeOffset.FromUnixTimeSeconds(forecastData.list[i].dt).DateTime.ToLocalTime();
                    double temp = forecastData.list[i].main.temp - 273.15;
                    string description = forecastData.list[i].weather[0].description;
                    forecastText += $"{forecastTime.ToShortDateString()}: {temp:F2} °C, {description}\n";
                }
                labelForecast.Text = forecastText;
            }
            else
            {
                MessageBox.Show("Failed to retrieve forecast data.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelHumidity_Click(object sender, EventArgs e)
        {

        }
    }

    public partial class WeatherApi
    {
        private static readonly string ApiKey = "2ea8e51332377ce7ae6d78634925dd75"; // Single API key
        private static readonly HttpClient client = new HttpClient();

        public static async Task<List<GeoLocation>> GetGeoLocation(string city)
        {
            try
            {
                string url = $"http://api.openweathermap.org/geo/1.0/direct?q={Uri.EscapeDataString(city)}&appid={ApiKey}";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                List<GeoLocation> locations = JsonConvert.DeserializeObject<List<GeoLocation>>(json);

                return locations;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting geolocation: {ex.Message}");
                return null;
            }
        }

        public static async Task<WeatherData> GetWeatherData(double lat, double lon)
        {
            try
            {
                string url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={ApiKey}";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(json);

                return weatherData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting weather data: {ex.Message}");
                return null;
            }
        }

        public static async Task<ForecastData> GetForecastData(double lat, double lon)
        {
            try
            {
                string url = $"https://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&appid={ApiKey}";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                ForecastData forecastData = JsonConvert.DeserializeObject<ForecastData>(json);

                return forecastData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting forecast data: {ex.Message}");
                return null;
            }
        }

        public class GeoLocation
        {
            public string name { get; set; }
            public double lat { get; set; }
            public double lon { get; set; }
            public string country { get; set; }
            public string state { get; set; }
        }

        public class WeatherData
        {
            public MainData main { get; set; }
            public List<WeatherDescription> weather { get; set; }
        }

        public class MainData
        {
            public double temp { get; set; }
            public int humidity { get; set; }
        }

        public class WeatherDescription
        {
            public string description { get; set; }
        }

        public class ForecastData
        {
            public List<ForecastItem> list { get; set; }
        }

        public class ForecastItem
        {
            public long dt { get; set; }
            public MainData main { get; set; }
            public List<WeatherDescription> weather { get; set; }
        }
    }
}