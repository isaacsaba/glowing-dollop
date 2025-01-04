using Quote.Models;
using Quote.Models.Provider;
using System.Threading.Tasks;

namespace Quote.Contracts
{
    public interface IMapper
    {
        ActivitiesDetailRequest Convert(TourQuoteRequest request);

        Task<TourQuoteResponse> Convert(TourQuoteRequest request, ActivitiesDetailResponse activity);
    }
}
