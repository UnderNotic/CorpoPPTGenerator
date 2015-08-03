using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using Newtonsoft.Json;
using unirest_net.http;

namespace CorpoPPTGenerator.Providers
{
    public interface IFamousQuotesProvider
    {
        Task<QuoteRestResponse> GetQuoteAsync();
        HttpResponse<string> GetQuote();
    }

    public class FamousQuotesProvider : IFamousQuotesProvider
    {
        private readonly UniRestClient _uniRestClient;

        private const string MashapeKey = "cNDN6ZMddNmshYOGm7f7Tr4LEnj4p12AAcbjsni8FX89CiaFdL";

        private const string Address = "https://andruxnet-random-famous-quotes.p.mashape.com/cat=famous";

        public FamousQuotesProvider(UniRestClient uniRestClient)
        {
            _uniRestClient = uniRestClient;
        }

        public async Task<QuoteRestResponse> GetQuoteAsync()
        {
            Task<HttpResponse<string>> response = Unirest.post(
                Address)
                .header("X-Mashape-Key", MashapeKey)
                .header("Accept", "application/json")
                .asJsonAsync<string>();

            var serializer = new JsonSerializer();
            var result = await response;
            var  quoteRestResponse = serializer.Deserialize<QuoteRestResponse>(new JsonTextReader(new StringReader(result.Body)));

            return quoteRestResponse;
        }

        public HttpResponse<string> GetQuote()
        {
            HttpResponse<string> response = Unirest.post(
                Address)
                .header("X-Mashape-Key", MashapeKey)
                .header("Accept", "application/json")
                .asJson<string>();

            return response;
        }
    }
       public class QuoteRestResponse
        {
            public string Quote { get; set; }
            public string Author { get; set; }
        }
}