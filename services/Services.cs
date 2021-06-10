
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
//Using System.Net.Http directive which will enable HttpClient.
using System.Net.Http;
//use newtonsoft to convert json to c# objects.
using Newtonsoft.Json.Linq;



namespace DiscordBot.Services
{
    public static class WatherService
    {
        public static string GetWeather()
        {
            var data = GetWeatherData().Result;
            string formattedWeather = FormatData(data);
            return formattedWeather;
        }

        public static string FormatData(JObject data)
        {
            Console.WriteLine(data);
            string description = data["weather"][0]["description"].ToString();
            string temp = data["main"]["temp"].ToString();
            string temp_min = data["main"]["temp_min"].ToString();
            string temp_max = data["main"]["temp_max"].ToString();
            string humidity = data["main"]["humidity"].ToString();
            double wind = (double)data["wind"]["speed"];
            Console.WriteLine("TEMP: " + temp + "°C");

            return $@"Sää Jyväskylässä nyt:
            Lämpötila: {temp} °C
            Alin lämpötila: {temp_min} °C
            Ylin lämpötila: {temp_max} °C
            Ilmankosteus: {humidity} %
            Tuuli: {wind} m/s
            Kuvaus: {description}
            ";
        }



        /**
        Conver the unit of temp to °C in JavaScript:
            Conver the unit of temp to °C
            const kelvinToCelcius = temp => Math.round(temp - 273.15);
        */
        //Get data from weather api
        public static async Task<JObject> GetWeatherData()
        {
            //Base url for api. Id is set to Jyväskylä
            string baseUrl = $"http://api.openweathermap.org/data/2.5/weather/?id=655195&units=metric&APIKEY={AppServices.GetAppSetting("api_key")}";
            try
            {
                //Http clien for fetching data
                using (HttpClient client = new HttpClient())
                {
                    // Async Get reguest from the client
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        //Get content from the response
                        using (HttpContent content = res.Content)
                        {
                            //Content to data variable, by converting it into a string
                            var data = await content.ReadAsStringAsync();
                            //If the data isn't null return log convert the data to JObject
                            if (data != null)
                            {


                                // Console.WriteLine("data------------{0}", JObject.Parse(data));
                                return JObject.Parse(data);
                            }
                            else
                            {
                                Console.WriteLine("NO Data----------");
                                return null;
                            }

                        }
                    }

                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception Hit------------");
                Console.WriteLine(exception);
                return null;
            }

        }


    }
    public static class AppServices
    {
        /**
        Gets token from file that is gitignored. Add token to this json file for bot to work
        key = key from the json file you want
        */
        public static string GetAppSetting(string key)
        {
            string appsettings = File.ReadAllText(@"appsettings.json");
            Dictionary<string, string> appsettingsObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(appsettings);

            return appsettingsObject[key];
        }
    }
}