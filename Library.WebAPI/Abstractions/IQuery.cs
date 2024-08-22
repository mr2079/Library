using MediatR;

namespace Library.WebAPI.Abstractions;

public interface IQuery<out TResponse> 
    : IRequest<TResponse>
    where TResponse : notnull;