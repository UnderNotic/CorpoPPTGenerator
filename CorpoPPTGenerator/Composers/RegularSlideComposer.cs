using System;
using System.Linq;
using System.Threading.Tasks;
using CorpoPPTGenerator.Providers;
using Microsoft.Office.Interop.PowerPoint;

namespace CorpoPPTGenerator.Composers
{
    public interface IRegularSlideComposer
    {
        Task ComposeSlideAsync(Slide slide);
        Task ComposeQuoteSlideAsync(Slide slide);

    }

    public class RegularSlideComposer : IRegularSlideComposer
    {
        private readonly ICorpoSentencesProvider _corpoSentencesProvider;
        private readonly IFamousQuotesProvider _famousQuotesProvider;

        public RegularSlideComposer(ICorpoSentencesProvider corpoSentencesProvider, IFamousQuotesProvider famousQuotesProvider)
        {
            _corpoSentencesProvider = corpoSentencesProvider;
            _famousQuotesProvider = famousQuotesProvider;
        }

        public async Task ComposeSlideAsync(Slide slide)
        {
           var sentences = await _corpoSentencesProvider.GetSentencesAsync(4);
           var objText = slide.Shapes[2].TextFrame.TextRange;

            var x = Enumerable.Range(0, 4).Select(_ => sentences.Dequeue()).Aggregate((s, s1) => s + @"\n" + s1);
            objText.Text = x;

            slide.NotesPage.Shapes[2].TextFrame.TextRange.Text = "Created by PPTCorpoGenerator";
        }

        public async Task ComposeQuoteSlideAsync(Slide slide)
        {
            var quote = await _famousQuotesProvider.GetQuoteAsync();
            var objText = slide.Shapes[2].TextFrame.TextRange;
            objText.Text = quote.Quote + " by " + quote.Author;
        }

    }
}