﻿using Quote.Models;
using Quote.Models.Api;
using System.Net;
using System.Threading.Tasks;

namespace Quote.Contracts
{
    public interface IQuoteEngine
    {
        Task<TourQuoteResponse> Quote(TourQuoteRequest request);
        Task<RefactoredResponse> GetMarginAsync(string code);
    }
}
