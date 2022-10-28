using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Linq;
using System.Numerics;
using WebAPIClient.Models;

namespace WebAPIClient

{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var msg = await ClientGET();

            Console.WriteLine(JToken.Parse(msg).ToString());

            var resultPOST = await ClientPOST();
            Console.WriteLine(resultPOST);

            var resultPUT = await ClientPUT();
            Console.WriteLine(resultPUT);

            var resultDELETE = await ClientDELETE();
            Console.WriteLine(resultDELETE);

        }

        public class Header : HttpClient
        {
            public string requestUri { get; set; }
            public HttpClient client { get; set; }

            public Header()
            {
                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("User-Agent", "Ashley's API");

                requestUri = "https://localhost:7117/api/Players/";
            }
        }


        public static async Task<string> ClientGET()
        {

            Header client = new Header();
            var requestUri = client.requestUri;

            var stringTask = client.GetStringAsync(requestUri);
            var msg = await stringTask;

            return msg;

        }
        public static async Task<HttpResponseMessage> ClientPOST()
        {
            Header client = new Header();
            var requestUri = client.requestUri;

            var PlayerPOST = new Player { Name = "Myles Garret", Number = 95, Position = "Left Defensive End", Line = "First" };
            var resultPOST = await client.PostAsync<Player>(requestUri, PlayerPOST, new JsonMediaTypeFormatter());


            return (HttpResponseMessage)resultPOST;

        }

        public static async Task<HttpResponseMessage> ClientPUT()
        {
            Header client = new Header();
            var requestUri = client.requestUri;

            var PlayerPUT = new Player { Id = 15, Name = "Jordan Elliott", Number = 96, Position = "Left Defensive Tackle", Line = "First" };
            var resultPUT = await client.PutAsync<Player>(requestUri + "15", PlayerPUT, new JsonMediaTypeFormatter());

            return (HttpResponseMessage)resultPUT;
        }

        public static async Task<HttpResponseMessage> ClientDELETE()
        {
            Header client = new Header();
            var requestUri = client.requestUri;

            var resultDELETE = await client.DeleteAsync(requestUri + "10");

            return (HttpResponseMessage)resultDELETE;
        }
    }
}