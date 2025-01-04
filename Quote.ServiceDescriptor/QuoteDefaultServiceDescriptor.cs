using LightInject;
using Quote.Contracts;

namespace Quote.ServiceDescriptor
{
    public static class QuoteDefaultServiceDescriptor
    {
        public static void Register(IServiceContainer container)
        {
            container.Register<IMarginProvider, DefaultMarginProvider>();
            container.Register<IMapper, Mapper>();
            container.Register<IServiceWrapper, ServiceApitude>();
            container.Register<IQuoteEngine, QuoteService>();
            container.Register<IRefactoredService, RefactoredService>();
        }
    }
}
