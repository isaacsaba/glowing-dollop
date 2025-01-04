using Quote.Models.Api;
using System.Net;
using System.Threading.Tasks;

namespace Quote.Contracts
{
    public interface IRefactoredService
    {
        Task<RefactoredResponse> GetMarginAsync(string code);
    }
}
