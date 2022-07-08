using FunnyImages.Commands;
using System;
using System.Threading.Tasks;

namespace FunnyImages.Handlers
{
    public interface ICommandHandler<T> where T : ICommand 
    {
        Task HandleAsync(T command);
    }
}
