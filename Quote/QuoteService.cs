using Quote.Contracts;
using Quote.Models;
using Quote.Models.Api;
using Quote.Models.Provider;
using System;
using System.Threading.Tasks;

namespace Quote
{
    public class QuoteService : IQuoteEngine
    {
        private readonly IMapper mapper;
        private readonly IServiceWrapper wrapper;
        private readonly IRefactoredService refactored;

        public QuoteService(IMapper mapper, IServiceWrapper wrapper, IRefactoredService refactored)
        {
            this.mapper = mapper;
            this.wrapper = wrapper;
            this.refactored = refactored;
        }

        public async  Task<TourQuoteResponse> Quote(TourQuoteRequest request)
        {
            var detailRequest = this.mapper.Convert(request);
            var detailResponse = new ActivitiesDetailResponse();
            Task.Run(async () =>
            {
                detailResponse = await this.wrapper.GetDetails(detailRequest);
            }).GetAwaiter().GetResult();
            if (detailResponse.Activity == null)
            {
                throw new Exception(string.Format("Unable to find the selected tour. Tour Code: {0}, Tour Uri: {1}", request.TourCode, request.TourUri));
            }

            var result = await this.mapper.Convert(request, detailResponse);
            return result;
        }

        public async Task<RefactoredResponse> GetMarginAsync(string code)
        {
            return await this.refactored.GetMarginAsync(code);
        }
    }
}
