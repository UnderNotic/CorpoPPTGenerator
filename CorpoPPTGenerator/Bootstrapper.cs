using System;
using Autofac;
using CorpoPPTGenerator.Composers;
using CorpoPPTGenerator.Providers;

namespace CorpoPPTGenerator
{
    class Bootstrapper
    {
        private static IContainer _container;

        static void Main(string[] args)
        {
            
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<MySuperWebClient>();
            containerBuilder.RegisterType<MainMenu>().As<IStartable>().SingleInstance();
            containerBuilder.RegisterType<CorpoSentencesProvider>().As<ICorpoSentencesProvider>();
            containerBuilder.RegisterType<RegularSlideComposer>().As<IRegularSlideComposer>();
            containerBuilder.RegisterType<UniRestClient>();
            containerBuilder.RegisterType<FamousQuotesProvider>().As<IFamousQuotesProvider>();
            _container = containerBuilder.Build();


         
            GetAsync();



            Console.Read();
        }


        public async static void GetAsync()
        {
            var x = _container.Resolve<IFamousQuotesProvider>();
            var res = await x.GetQuoteAsync();
            Console.WriteLine(res.Author + res.Quote);
        }


    }
}
