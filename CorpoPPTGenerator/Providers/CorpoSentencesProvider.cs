using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace CorpoPPTGenerator.Providers
{
    public interface ICorpoSentencesProvider
    {
        Task<Queue<string>> GetSentencesAsync(int number);
    }

    public class CorpoSentencesProvider : ICorpoSentencesProvider
    {
        private readonly MySuperWebClient _mySuperWebClient;


        public CorpoSentencesProvider(MySuperWebClient mySuperWebClient)
        {
            _mySuperWebClient = mySuperWebClient;
        }

        private readonly Queue<string> _sentences = new Queue<string>(); 

        public async Task<Queue<string>> GetSentencesAsync(int number)
        {
            if (_sentences.Count < number)
            {
                await ScrapSentencesAsync();
            }
            return _sentences;
        }

        private async Task ScrapSentencesAsync()
        {
            var htmlString = DownloadHtmlAsStringAsync();
            var doc = new HtmlDocument();
            doc.LoadHtml(await htmlString);

            var sentences = doc.DocumentNode.SelectNodes("//li").Select(x => x.InnerText).Where(x=>x.Length < 150);
            sentences.ToList().ForEach(_sentences.Enqueue);
        }

        private async Task<string> DownloadHtmlAsStringAsync()
        {
            return await _mySuperWebClient.DownloadStringTaskAsync(new Uri(_mySuperWebClient.CbsgAddress));
        }


    }
}