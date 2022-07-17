using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using Razor_Form_Submit.Models;

namespace Razor_Form_Submit.Pages
{
    public class IndexModel : PageModel
    {
        public string ErrorMessage { get; set; } = "Invalid Zip, City Name, or IP";

        public string High { get; set; }

        public string Low { get; set; }

        public string Location { get; set; }

        public string Rain { get; set; }

        public string Condition { get; set; }

        public string ConditionIcon { get; set; }

        public bool Error { get; set; }

        public bool IsPost { get; set; }

        public void OnGet()
        {
            IsPost = false;
        }

        public void OnPostSubmit(WeatherModel weather)
        {
            IsPost = true;
            GetWeather(weather);
        }

        public void UpdateValues(WeatherModel weather)
        {
            Error = weather.Error;
            Location = weather.Location;
            Condition = weather.Condition;
            ConditionIcon = weather.ConditionIcon;
            High = "High: " + weather.High.ToString();
            Low = "Low: " + weather.Low.ToString();
            Rain = "Chance of Rain: " + weather.Rain.ToString();
        }

        // Fetches weather based on result.searchKey, passed object is populated with results
        private void GetWeather(WeatherModel result)
        {
            string apiKey = Environment.GetEnvironmentVariable("WeatherAPIKey");
            Console.WriteLine(apiKey);
            string path = "http://api.weatherapi.com/v1/forecast.json?key=" + apiKey + "&q=" + result.SearchKey + "&days=1&aqi=no&alerts=no";
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.GetAsync(path).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                string responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                JObject json = JObject.Parse(responseBody);


                result.Error = false;
                result.Location = json.SelectToken("location.name").Value<String>() + ", "
                    + json.SelectToken("location.region").Value<String>() + ", "
                    + json.SelectToken("location.country").Value<String>();
                result.Condition = json.SelectToken("forecast.forecastday[0].day.condition.text").Value<String>();
                result.ConditionIcon = json.SelectToken("forecast.forecastday[0].day.condition.icon").Value<String>();
                result.High = json.SelectToken("forecast.forecastday[0].day.maxtemp_f").Value<float>();
                result.Low = json.SelectToken("forecast.forecastday[0].day.mintemp_f").Value<float>();
                result.Rain= json.SelectToken("forecast.forecastday[0].day.daily_chance_of_rain").Value<int>();
            } 
            else
            {
                result.Error = true;
            }
            UpdateValues(result);
        }
    }
}