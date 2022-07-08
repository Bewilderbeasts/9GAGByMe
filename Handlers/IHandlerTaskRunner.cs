using System;
using System.Threading.Tasks;

namespace FunnyImages.Handlers
{
    public interface IHandlerTaskRunner
    {
        IHandlerTask Run(Func<Task> run);
    }
}