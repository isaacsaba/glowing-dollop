using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Quote.Contracts;

namespace Quote
{
    public class DefaultMarginProvider : IMarginProvider
    {
        private readonly IRefactoredService refactored;

        public DefaultMarginProvider( IRefactoredService refactored)
        {
            this.refactored = refactored;
        }
        public decimal GetMargin(string code)
        {
            return 0.25M;
        }

        public async Task<decimal> GetMarginApi(string code)
        {
            var result = await this.refactored.GetMarginAsync(code);
            if (result.StatusCode == HttpStatusCode.OK)
                return JObject.Parse(result.Message)["margin"].Value<decimal>();
            
            return GetMargin(code);
        }
    }
}
