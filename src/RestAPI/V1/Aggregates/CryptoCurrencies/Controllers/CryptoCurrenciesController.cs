using Application.Aggregates.CryptoCurrencies.Queries.GetByCryptoCurrencyCode;
using Application.Aggregates.CryptoCurrencies.Queries.GetCollections;
using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestAPI.V1.Aggregates.CryptoCurrencies.Models;
using RestAPI.V1.Models;

namespace RestAPI.V1.Aggregates.CryptoCurrencies.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("rest/api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]

    public class CryptoCurrenciesController: ControllerBase
    {
        private readonly IMapper mapper;

        private readonly IMediator mediator;

        public CryptoCurrenciesController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseCollectionModel<CryptoCurrencyDtoResponse[]>>> GetAllCryptoCurrency(CancellationToken cancellationToken)
        {
            var query = new GetCryptoCurrencyCollectionQuery();
            var queryResult = await mediator.Send(query, cancellationToken).ConfigureAwait(false);


            return Ok(new ResponseCollectionModel<CryptoCurrencyDtoResponse>
            {
                Values = mapper.Map<CryptoCurrencyDtoResponse[]>(queryResult.Result),
                TotalCount = queryResult.TotalCount
            });
        }

        [HttpGet("{cryptoCurrencyCode}")]
        public async Task<ActionResult<ResponseModel<CryptoCurrencyDtoResponse>>> GetPriceByCryptoCurrencyCode(
            string cryptoCurrencyCode,
            CancellationToken cancellationToken)
        {
            var query = new GetByCryptoCurrencyCodeQuery { CryptoCurrencyCode = cryptoCurrencyCode };
            var queryResult = await mediator.Send(query, cancellationToken).ConfigureAwait(false);

            if (queryResult is null)
                return NotFound();

            return Ok(new ResponseModel<CryptoCurrencyDtoResponse> { Values = mapper.Map<CryptoCurrencyDtoResponse>(queryResult) });
        }

    }
}
