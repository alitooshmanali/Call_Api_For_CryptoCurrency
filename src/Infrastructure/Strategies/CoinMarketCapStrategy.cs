using Application.Aggregates.CryptoCurrencies.Queries;
using Infrastructure.Helpers;
using Infrastructure.Models;
using Infrastructure.Models.CoinMarketCaps;
using Infrastructure.Services;
using System.Text.Json;

namespace Infrastructure.Strategies
{
    public class CoinMarketCapStrategy : BaseStrategy, IStrategy
    {
        public CoinMarketCapStrategy(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory)
        {
        }

        public async Task<List<CryptoCurrencyQueryResult>> GetListOfAllCryptoCurrency()
        {
            var response = new List<CryptoCurrencyQueryResult>();
            CoinMarketCapResponse deserilizedResponse;
            var headers = new Dictionary<string, string>
            {
                { "X-CMC_PRO_API_KEY",  ThirdPartyConstant.CoinMarketCapApiKey }
            };

            var parameters = new Dictionary<string, string> { };

            var baseResultModel = await base.GetAsync(ThirdPartyConstant.CoinMarketCapProviderBaseUrl, headers, parameters, ThirdPartyConstant.CoinMarketCapTimeout);

            if (!baseResultModel.IsSuccess)
            {
                Console.WriteLine("CoinMarketCapProvider does not any response to request.");

                return new List<CryptoCurrencyQueryResult>();
            }

            try
            {
                deserilizedResponse = baseResultModel.Body.ToConvert<CoinMarketCapResponse>();

                response = deserilizedResponse.Data.Select(x => new CryptoCurrencyQueryResult
                {
                    Id = x.Id,
                    Name = x.Name,
                    Symbol = x.Symbol,
                    Price = x.Quote.USD.Price
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not deserilize response data.");
                return new List<CryptoCurrencyQueryResult>();
            }

            return response;
        }

        public async Task<CryptoCurrencyQueryResult> GetPriceByCryptoCurrency(string cryptoCurrencyCode, CancellationToken cancellationToken = default)
        {
            var response = new CryptoCurrencyQueryResult();

            var headers = new Dictionary<string, string>
            {
                { "X-CMC_PRO_API_KEY",  ThirdPartyConstant.CoinMarketCapApiKey }
            };

            var parameters = new Dictionary<string, string> 
            {
                { "convert",  cryptoCurrencyCode },
                { "symbol",  ThirdPartyConstant.CoinMarketCapProviderSymbols }
            };

            var lastPriceParameters = new Dictionary<string, string>
            {
                { "convert",  "USD" },
                { "symbol",  cryptoCurrencyCode }
            };

            var baseResultLastPriceModel = await base.GetAsync(ThirdPartyConstant.CoinMarketCapProviderQuoteUrl, headers, lastPriceParameters, ThirdPartyConstant.CoinMarketCapTimeout);

            var baseResultModel = await base.GetAsync(ThirdPartyConstant.CoinMarketCapProviderQuoteUrl, headers, parameters, ThirdPartyConstant.CoinMarketCapTimeout);

            if (!baseResultModel.IsSuccess)
            {
                Console.WriteLine("CoinMarketCapProvider does not any response to request.");

                return new CryptoCurrencyQueryResult();
            }

            try
            {
                response = FillLastPriceInMarket(baseResultLastPriceModel, response, cryptoCurrencyCode);
                response = FillPriceInSymbols(baseResultModel, response, cryptoCurrencyCode);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not deserilize response data.");
                return new CryptoCurrencyQueryResult();
            }

            return response;
        }

        private CryptoCurrencyQueryResult FillPriceInSymbols(BaseResultModel baseResultModel, CryptoCurrencyQueryResult response, string cryptoCurrencyCode)
        {
            using (JsonDocument doc = JsonDocument.Parse(baseResultModel.Body))
            {
                var selectedAUDElement = doc.RootElement
                    .GetProperty("data")
                    .GetProperty("AUD");

                if (selectedAUDElement.ValueKind == JsonValueKind.Array)
                {
                    if (selectedAUDElement.GetArrayLength() > 0)
                    {
                        var usdCryptoCurrencyCodeElement = selectedAUDElement[0]
                            .GetProperty("quote")
                            .GetProperty(cryptoCurrencyCode);

                        if (usdCryptoCurrencyCodeElement.TryGetProperty("price", out JsonElement usdpriceElement) && usdpriceElement.ValueKind != JsonValueKind.Null)
                        {
                            response.AUD = usdpriceElement.GetDouble();
                        }

                    }
                }

                var selectedBRLElement = doc.RootElement
                    .GetProperty("data")
                    .GetProperty("BRL");

                if (selectedBRLElement.ValueKind == JsonValueKind.Array)
                {
                    if (selectedBRLElement.GetArrayLength() > 0)
                    {
                        var usdCryptoCurrencyCodeElement = selectedBRLElement[0]
                            .GetProperty("quote")
                            .GetProperty(cryptoCurrencyCode);

                        if (usdCryptoCurrencyCodeElement.TryGetProperty("price", out JsonElement usdpriceElement) && usdpriceElement.ValueKind != JsonValueKind.Null)
                        {
                            response.BRL = usdpriceElement.GetDouble();
                        }

                    }
                }

                var selectedEURElement = doc.RootElement
                    .GetProperty("data")
                    .GetProperty("EUR");

                if (selectedEURElement.ValueKind == JsonValueKind.Array)
                {
                    if (selectedEURElement.GetArrayLength() > 0)
                    {
                        var usdCryptoCurrencyCodeElement = selectedEURElement[0]
                            .GetProperty("quote")
                            .GetProperty(cryptoCurrencyCode);

                        if (usdCryptoCurrencyCodeElement.TryGetProperty("price", out JsonElement usdpriceElement) && usdpriceElement.ValueKind != JsonValueKind.Null)
                        {
                            response.EUR = usdpriceElement.GetDouble();
                        }

                    }
                }

                var selectedGBPElement = doc.RootElement
                    .GetProperty("data")
                    .GetProperty("GBP");

                if (selectedGBPElement.ValueKind == JsonValueKind.Array)
                {
                    if (selectedGBPElement.GetArrayLength() > 0)
                    {
                        var usdCryptoCurrencyCodeElement = selectedGBPElement[0]
                            .GetProperty("quote")
                            .GetProperty(cryptoCurrencyCode);

                        if (usdCryptoCurrencyCodeElement.TryGetProperty("price", out JsonElement usdpriceElement) && usdpriceElement.ValueKind != JsonValueKind.Null)
                        {
                            response.GBP = usdpriceElement.GetDouble();
                        }

                    }
                }

                var selectedUSDElement = doc.RootElement
                    .GetProperty("data")
                    .GetProperty("USD");

                if (selectedUSDElement.ValueKind == JsonValueKind.Array)
                {
                    if (selectedUSDElement.GetArrayLength() > 0)
                    {
                        var usdCryptoCurrencyCodeElement = selectedUSDElement[0]
                            .GetProperty("quote")
                            .GetProperty(cryptoCurrencyCode);

                        if (usdCryptoCurrencyCodeElement.TryGetProperty("price", out JsonElement usdpriceElement) && usdpriceElement.ValueKind != JsonValueKind.Null)
                        {
                            response.USD = usdpriceElement.GetDouble();
                        }

                    }
                }
            }

            return response;
        }

        private CryptoCurrencyQueryResult FillLastPriceInMarket(BaseResultModel baseResultLastPriceModel, CryptoCurrencyQueryResult response, string cryptoCurrencyCode)
        {
            using (JsonDocument doc = JsonDocument.Parse(baseResultLastPriceModel.Body))
            {
                var selectedCryptoCurrency = doc.RootElement
                    .GetProperty("data")
                    .GetProperty(cryptoCurrencyCode)[0];

                if (selectedCryptoCurrency.TryGetProperty("id", out JsonElement idElement) && idElement.ValueKind != JsonValueKind.Null)
                {
                    response.Id = idElement.GetInt32();
                }

                if (selectedCryptoCurrency.TryGetProperty("name", out JsonElement nameElement) && nameElement.ValueKind != JsonValueKind.Null)
                {
                    response.Name = nameElement.GetString();
                }

                if (selectedCryptoCurrency.TryGetProperty("symbol", out JsonElement symbolElement) && symbolElement.ValueKind != JsonValueKind.Null)
                {
                    response.Symbol = symbolElement.GetString();
                }

                var usdElement = selectedCryptoCurrency
                    .GetProperty("quote")
                    .GetProperty("USD");

                if (usdElement.TryGetProperty("price", out JsonElement priceElement) && priceElement.ValueKind != JsonValueKind.Null)
                {
                    response.Price = priceElement.GetDouble();
                }
            }

            return response;
        }
    }
}
