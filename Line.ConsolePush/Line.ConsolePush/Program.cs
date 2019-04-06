using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
namespace Line.ConsolePush
{
    static class Program
    {
        //Last Update ： 2019-04-06
        private static string Token = "{Is your channel access token}";
        private static string PushApiUrl = @"https://api.line.me/v2/bot/message/push";
        static void Main(string[] args)
        {
            Console.Write("Input User Id：");
            var UserId = Console.ReadLine();

            while (true)
            {
                PushContext PushConfig = new PushContext();
                PushConfig.to = $"${UserId}";
                PushConfig.messages.Add(new Message()
                {
                    type = "text",
                    text = "Hello World"
                });

                PushConfig.Push();
            }
        }

        public static async void Push(this PushContext Data)
        {
            string Bearer = $"Bearer ${Token}";

            var HttpWebRequest = (HttpWebRequest)WebRequest.Create(PushApiUrl);
            HttpWebRequest.ContentType = "application/json";
            HttpWebRequest.Headers.Add("Authorization", Bearer);
            HttpWebRequest.Method = "POST";

            //將測試訊息預先寫死
            var JsonStr = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(Data));

            Stream Stream = HttpWebRequest.GetRequestStream();
            Stream.Write(JsonStr, 0, JsonStr.Length);
            Stream.Close();

            WebResponse response = HttpWebRequest.GetResponse();
        }
    }
}
