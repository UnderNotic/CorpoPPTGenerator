using System;
using CorpoPPTGenerator.Providers;
using Spire.Presentation;

namespace CorpoPPTGenerator.Composers
{
    public interface IRegularSlideComposer
    {
        void ComposeSlideAsync();
    }

    public class RegularSlideComposer : IRegularSlideComposer
    {
        private readonly ICorpoSentencesProvider _corpoSentencesProvider;

        public RegularSlideComposer(ICorpoSentencesProvider corpoSentencesProvider)
        {
            _corpoSentencesProvider = corpoSentencesProvider;
        }

        public async void ComposeSlideAsync()
        {
           var sentences = _corpoSentencesProvider.GetSentencesAsync(5);

            //make slide

            foreach (var sentence in await sentences)
            {
              

                Console.WriteLine(sentence);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}