using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PhoneBookApp.Models.States;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace PhoneBookApp.App.States
{
    public class StateBase
    {
        protected static HttpClient client;
        protected static bool isHttpSetup = false;
        protected IConfiguration configuration;
        protected StateResult stateResult = new StateResult();

        public StateBase(IConfiguration configuration)
        {
            this.configuration = configuration;
            OpenHttp();
        }

        protected StateResult ReturnChangeState(AppState newState)
        {
            stateResult.ShouldChangeState = true;
            stateResult.NewState = newState;

            return stateResult;
        }

        protected void OpenHttp()
        {
            if (isHttpSetup)
                return;

            client = new HttpClient();
            client.BaseAddress = new Uri(configuration["APIURL"]);
            var val = "application/json";
            var media = new MediaTypeWithQualityHeaderValue(val);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(media);

            isHttpSetup = true;
        }

        protected void ClearScreen()
        {
            Console.Clear();
        }

        protected string ReadStringNoEmpty(string question)
        {
            WriteLine(question);

            var value = Console.ReadLine();
            if(String.IsNullOrWhiteSpace(value))
            {
                WriteLine("Please enter a valid value.");
                ReadStringNoEmpty(question);
            }

            return value;
        }

        protected void WriteHeader(string text)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine(text);
            Console.WriteLine("-----------------------");
        }

        protected void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        protected void Write(string text)
        {
            Console.Write(text);
        }

        protected T Deserialize<T>(string json)
        {
            T deserializedObject = JsonConvert.DeserializeObject<T>(json);
            return deserializedObject;
        }

        protected HttpContent CreateHttpContent(object content)
        {
            var json = JsonConvert.SerializeObject(content);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+

            return stringContent;
        }

    }
}
