using System;
using CorpoPPTGenerator.Providers;
using Microsoft.Office.Interop.PowerPoint;

namespace CorpoPPTGenerator.Composers
{
    public interface IRegularSlideComposer
    {

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

        private async void ComposeSlideAsync()
        {
           var sentences = _corpoSentencesProvider.GetSentencesAsync(5);

           CustomLayout customLayout = pptPresentation.SlideMaster.CustomLayouts[Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText];
        }

        private async void ComposeQuoteSlideAsync()
        {
            var quote = _famousQuotesProvider.GetQuoteAsync();
        }

    }
}