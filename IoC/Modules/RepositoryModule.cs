using Autofac;
using FunnyImages.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FunnyImages.IoC.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(RepositoryModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<CommentRepository>()
                   .As<ICommentRepository>()
                   .SingleInstance();

            builder.RegisterType<VoteRepository>()
                   .As<IVoteRepository>()
                   .SingleInstance();

            builder.RegisterType<MongoUserRepository>()
                    .As<IUserRepository>()
                    .SingleInstance();

            builder.RegisterType<ImageRepository>()
                   .As<IImageRepository>()
                   .SingleInstance();
        }
    }
}
