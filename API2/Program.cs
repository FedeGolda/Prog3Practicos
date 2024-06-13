using Newtonsoft.Json;
using RestSharp;

namespace API2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://apiv2.allsportsapi.com/");
            var request = new RestRequest("football?met=Countries&APIkey=ad1d734557f4af2afe23faf9accbdc44d061617c06072d0713d54d49333f0730", Method.Get);
            RestResponse response = client.Execute(request);
            if (response.IsSuccessStatusCode)
            {
                ListaPais misPaises = JsonConvert.DeserializeObject<ListaPais>(response.Content);
            }
            else 
            {
                Console.WriteLine(response.Content);
            }


            Console.ReadLine();

        }
    }
}
