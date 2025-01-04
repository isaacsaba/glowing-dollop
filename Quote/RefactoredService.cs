using Quote.Contracts;
using Quote.Models.Api;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Quote
{
    public class RefactoredService : IRefactoredService
    {

        public async Task<RefactoredResponse> GetMarginAsync(string code)
        {
            string url = $"https://refactored-pancake.free.beeceptor.com/margin/{code}";
            var request = WebRequest.Create(url);
            request.Method = "GET";

            try
            {
                using (var response = await Task<WebResponse>.Factory.FromAsync(
                    request.BeginGetResponse,
                    request.EndGetResponse,
                    null
                ))
                using (var httpResponse = (HttpWebResponse)response) 
                using (var stream = httpResponse.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    string result = await reader.ReadToEndAsync();
                    return new RefactoredResponse{
                        StatusCode = httpResponse.StatusCode,
                        Message = result
                    };
                }
            }
            catch (WebException ex)
            {
                if (ex.Response is HttpWebResponse errorResponse)
                {
                    using (var stream = errorResponse.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        string errorResult = await reader.ReadToEndAsync();
                        return new RefactoredResponse
                        {
                            StatusCode = errorResponse.StatusCode,
                            Message = errorResult
                        };
                    }
                }
                throw;
            }
        }
    }
}
