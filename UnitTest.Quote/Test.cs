using System;
using System.Threading.Tasks;
using LightInject;
using NUnit.Framework;
using Quote;
using Quote.Contracts;
using Quote.Models;
using Quote.ServiceDescriptor;

namespace UnitTest.Quote
{
    [TestFixture]
    public class Test
    {
        private IServiceContainer container;
        private IQuoteEngine quote;

        [SetUp]
        public void SetUp()
        {
            this.container = new ServiceContainer();
            QuoteDefaultServiceDescriptor.Register(this.container);
            this.quote = this.container.GetInstance<IQuoteEngine>();
        }

        [Test]
        public void TestQuote()
        {
            var request = new TourQuoteRequest
            {
                adults = 1,
                ArrivalDate = DateTime.Now.AddDays(1),
                DepartingDate = DateTime.Now.AddDays(2),
                getAllRates = true,
                GetQuotes = true,
                RetrieveOptions = new TourQuoteRequestOptions
                {
                    GetContracts = true,
                    GetCalculatedQuote = true,
                },
                TourUri = "",
                Language = Language.Spanish
            };
            var result = this.quote.Quote(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.HasQuote);
        }

        [Test]
        public void TestQuoteError()
        {
            var request = new TourQuoteRequest
            {
                adults = 1,
                ArrivalDate = DateTime.Now.AddDays(1),
                DepartingDate = DateTime.Now.AddDays(2),
                getAllRates = true,
                GetQuotes = true,
                RetrieveOptions = new TourQuoteRequestOptions
                {
                    GetContracts = true,
                    GetCalculatedQuote = true,
                },
                TourCode = "E-U10-PRVPARKTRF",
                Language = Language.Spanish
            };
            Assert.Throws<InvalidOperationException>(
                () => this.quote.Quote(request));
        }

        [Test]
        public async Task TestApi()
        {
            var request = "E-U10-DSCVCOVE";
            var result = await this.quote.GetMarginAsync(request);
            Assert.IsNotNull(result);

        }
    }
}
