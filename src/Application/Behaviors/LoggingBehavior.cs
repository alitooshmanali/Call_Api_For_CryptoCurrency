﻿using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Logger<LoggingBehavior<TRequest, TResponse>> logger;

        public LoggingBehavior(Logger<LoggingBehavior<TRequest,TResponse>> logger)
        {
            this.logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request, 
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var requestName = request.GetType().Name;
            var requestBody = JsonSerializer.Serialize(request);

            try
            {
                logger.LogInformation($"Handling request {requestName} started. Values: {requestBody}.");
                var response = await next().ConfigureAwait( false );
                logger.LogInformation($"Handling request {requestName} finished.");

                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex,$"Handling request {requestName} failed.");
                throw;
            }
        }
    }
}
