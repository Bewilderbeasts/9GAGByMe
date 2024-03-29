﻿using Autofac;
using FunnyImages.Handlers;
using FunnyImages.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FunnyImages.IoC.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IService>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<Encrypter>()
                    .As<IEncrypter>()
                    .SingleInstance();

            builder.RegisterType<JwtHandler>()
                    .As<IJwtHandler>()
                    .SingleInstance();

            builder.RegisterType<Handler>()
                    .As<IHandler>()
                    .SingleInstance();

        }
    }
}
