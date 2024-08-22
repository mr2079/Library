using MediatR;

namespace Library.WebAPI.Abstractions;

public interface ICommand : ICommand<Unit>;

public interface ICommand<out TResponse>
    : IRequest<TResponse>
    where TResponse : notnull;