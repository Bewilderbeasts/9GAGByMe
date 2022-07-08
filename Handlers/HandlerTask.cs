using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Handlers
{
    public class HandlerTask : IHandlerTask
    {
        private readonly IHandler _handler;
        private readonly Func<Task> _run;
        private Func<Task> _validate;
        private Func<Task> _always;
        private Func<Task> _onSuccess;
        private Func<Exception, Task> _onError;
        private bool _propagateException = true;
        private bool _executeOnError = true;

        public HandlerTask(IHandler handler, Func<Task> run, Func<Task> validate = null)
        {
            _run = run;
            _handler = handler;
            _validate = validate;
        }


        public IHandlerTask Always(Func<Task> always)
        {
            _always = always;
            return this;
        }

        public IHandlerTask DoNotPropagateException()
        {
            _propagateException = false;
            return this;
        }

        public async Task ExecuteAsync()
        {
            try
            {
                if (_validate != null)
                {
                    await _validate();
                }
                await _run();
                if (_onSuccess != null)
                {
                    await _onSuccess();
                }
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(exception);
                if (_propagateException)
                {
                    throw;
                }
            }
            finally
            {
                if (_always != null)
                {
                    await _always();
                }
            }
        }




        public IHandler Next()
        {
            throw new NotImplementedException();
        }

        

        public IHandlerTask OnError(Func<Exception, Task> onError, bool propagateException = false, bool executeOnError = false)
        {
            _onError = onError;
            _propagateException = propagateException;
            _executeOnError = executeOnError;

            return this;
        }

        public IHandlerTask OnSuccess(Func<Task> onSuccess)
        {
            _onSuccess = onSuccess;
            return this;
        }

        public IHandlerTask PropagateException()
        {
            _propagateException = true;

            return this;
        }

        private Task HandleExceptionAsync(Exception exception)
        {
           throw new NotImplementedException();

            //var executeOnError = _executeOnError = null;
            //if (!executeOnError)
            //{
            //    return;
            //}

            //if (_onError != null)
            //{
            //    await _onError(exception);
            //}
        }

    }
}
