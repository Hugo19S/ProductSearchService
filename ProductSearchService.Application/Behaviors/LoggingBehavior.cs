using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ProductSearchService.Application.Behaviors;

public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
: IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse> 
    where TResponse : IErrorOr
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {

        var requestType = request.GetType().Name;
        var requestId = Guid.NewGuid();

        logger.LogInformation("Entrou o Pedido {requestType} com id {requestId}", requestType, requestId);

        
        try
        {
            TResponse result = await next();

            if (result.IsError) 
            {
                var errors = result.Errors;
                logger.LogWarning("An exception occured: {errors}", errors);
            }
            else{
                logger.LogInformation("O pedido com o id {requestId} ocorreu com sucesso!", requestId);
            }

            return result;

        }
        catch (Exception ex)
        {
            logger.LogError(default, ex);
            throw;
        }
    }
}
