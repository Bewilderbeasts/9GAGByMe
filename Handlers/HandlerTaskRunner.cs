﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Handlers
{
    public class HandlerTaskRunner : IHandlerTaskRunner
    {
        private readonly IHandler _handler;
        private readonly Func<Task> _validate;
        private readonly ISet<IHandlerTask> _handlerTasks;
        public HandlerTaskRunner(IHandler handler, Func<Task> validate,
                ISet<IHandlerTask> handlerTasks)
        {
            _handlerTasks = handlerTasks;
            _validate = validate;
            _handler = handler;
        }
        public IHandlerTask Run(Func<Task> run)
        {
            var handlerTask = new HandlerTask(_handler, run);
            _handlerTasks.Add(handlerTask);

            return handlerTask;
        }
    }
}
