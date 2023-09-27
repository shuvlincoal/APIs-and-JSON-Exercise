using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;


namespace APIsAndJSON
{
    public class Program
    {

        static async Task  Main(string[] args)
        {
            HttpClient client = new HttpClient(); //

            for (int i = 0; i < 5; i++) 
             {

            string ronUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";  //endpoint
            string ronResponse = client.GetStringAsync(ronUrl).Result;  //send and receive the response
            JArray ronObject = JArray.Parse(ronResponse);
            Console.WriteLine("Ron Says:  " + ronObject[0]);

            //string chuckUrl          = "https://api.chucknorris.io/jokes/random";  //endpoint  
            //string chuckResponse     = client.GetStringAsync(chuckUrl).Result;  //send and receive the response
            //JObject chuckObject      = JObject.Parse(chuckResponse);
            //Console.WriteLine(chuckObject["value"]);

            //string makeupUrl         = "https://makeup-api.herokuapp.com/api/v1/products.json?brand=maybelline";  //endpoint
            //string makeupResponse    = client.GetStringAsync(makeupUrl).Result;  //send and receive the response
            //JArray makeupObject = JArray.Parse(makeupResponse);
            //Console.WriteLine(makeupObject[1]["description"]);

            //Console.WriteLine("Kanye------");
            //string kanyeUrl = "https://api.kanye.rest";  //endpoint  
            //string kanyeResponse = await client.GetStringAsync(kanyeUrl).Result;  //send and receive the response
            //JObject kanyeObject = JObject.Parse(kanyeResponse);
            //Console.WriteLine(kanyeObject["quote"]);

            string kanyeUrl = "https://api.kanye.rest";  // Endpoint

            try
            {
                string kanyeResponse = await client.GetStringAsync(kanyeUrl);  // Send and receive the response asynchronously
                JObject kanyeObject = JObject.Parse(kanyeResponse);
                Console.WriteLine("Kanye Says: " + kanyeObject["quote"]);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }






            }//For


            var weatherConfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string apiKeyStr = weatherConfig.GetConnectionString("PrvKey");

            //----------EXERCISE 2 Local Weather
            Console.WriteLine("\n\n\nExercise 2 The Weather From Nashville------");
            Console.WriteLine("Press Return to continue> ");
            Console.ReadLine();
            string weatherUrl        = "http://api.openweathermap.org/data/2.5/weather?lat=36.1622767&lon=-86.7742984&&units=imperia&appid="+apiKeyStr;
            string weatherResponse   =  client.GetStringAsync(weatherUrl).Result;  //send and receive the response
            JObject weatherObject    = JObject.Parse(weatherResponse);
            //Console.WriteLine(weatherObject);
            Console.WriteLine("The Nashville Weather is:");
            Console.WriteLine("Temperature: " + weatherObject["main"]["temp"] + " Degrees");
            Console.WriteLine("Barometric Pressure: " + weatherObject["main"]["pressure"] + " Milibars");
            Console.WriteLine("Relative Humidity: " + weatherObject["main"]["humidity"] + "%");




        }//method
    }//class
}//namespace
