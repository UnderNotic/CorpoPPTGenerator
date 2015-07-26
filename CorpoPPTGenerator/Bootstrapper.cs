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

            _container = containerBuilder.Build();


            var x = _container.Resolve<IRegularSlideComposer>();
            x.ComposeSlideAsync();




            Console.Read();
        }
    }
}
