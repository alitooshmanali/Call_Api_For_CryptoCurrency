using Infrastructure.Helpers;
using Infrastructure.Models;
using System.Text;

namespace Infrastructure.Strategies
{
    public abstract class BaseStrategy
    {
        private readonly HttpClient _client;

        protected BaseStrategy(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient();
        }

        /// <summary>
        /// Http get request
        /// </summary>
        /// <param name="url">Request url</param>
        /// <param name="headers">Request headers</param>
        /// <param name="parameters">Request parameters</param>
        /// <returns>BaseResultModel</returns>
        public async Task<BaseResultModel> GetAsync(string url, Dictionary<string, string> headers, Dictionary<string, string> parameters, int timeout)
        {
            var response = new BaseResultModel() { IsSuccess = false };

            try
            {
                string uri = UrlBuilder(url, parameters);
                var request = new HttpRequestMessage(HttpMethod.Get, uri);

                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }

                string content = string.Empty;

                var httpResponseMessage = new HttpResponseMessage();

                using (var cts = new CancellationTokenSource())
                {
                    cts.CancelAfter(TimeSpan.FromMilliseconds(timeout));

                    httpResponseMessage = await _client.SendAsync(request, cts.Token);

                    content = await httpResponseMessage.Content.ReadAsStringAsync();
                }

                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    response.ErrorMessage = $"Response was contaning error! content:{content}";

                    return response;
                }

                if (string.IsNullOrWhiteSpace(content))
                {
                    response.ErrorMessage = $"Returned null value!";

                    return response;
                }

                response.IsSuccess = true;
                response.Body = content;
                response.ResponseJson = content.ToJson();
                response.ResponseCode = httpResponseMessage.StatusCode;
            }
            catch (TimeoutException timeoutEx)
            {
                var message = timeoutEx.InnerException != null ? timeoutEx.InnerException.Message.ToString() : timeoutEx.Message.ToString();
                response.ErrorMessage = $"Timeout error whenever calling the url {url}! Error detail:{message}";
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.InnerException != null ? ex.InnerException.Message.ToString() : ex.Message.ToString();
            }

            return response;
        }

        public virtual string UrlBuilder(string url, Dictionary<string, string> parameters)
        {
            if (!parameters.Any())
                return url;


            StringBuilder urlBuilder = new StringBuilder();
            if (!url.EndsWith("?"))
                urlBuilder.Append($"{url}?");
            else urlBuilder.Append(url);

            urlBuilder.Append(string.Join("&", parameters.Select(x => $"{x.Key}={x.Value}").ToList()));


            return urlBuilder.ToString();
        }
    }
}
