//using System.Linq;
//using System.Reflection;
//using Autofac;
//using MediatR;
//using TaskableChallenge.Model.Orders.Events;

//namespace TaskableChallenge.Server.Infrastructure
//{
//    public class MediatorModule : Autofac.Module
//    {
//        protected override void Load(ContainerBuilder builder)
//        {
//            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
//                .AsImplementedInterfaces();

//            // Register the DomainEventHandler classes (they implement INotificationHandler<>) in assembly holding the Domain Events
//            builder.RegisterAssemblyTypes(typeof(OrderedMembershipDomainEventHandler).GetTypeInfo().Assembly)
//                .AsClosedTypesOf(typeof(INotificationHandler<>));
//            builder.Register<ServiceFactory>(context =>
//            {
//                var componentContext = context.Resolve<IComponentContext>();
//                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
//            });

//            //builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));
//            //builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
//            //builder.RegisterGeneric(typeof(TransactionBehaviour<,>)).As(typeof(IPipelineBehavior<,>));

//        }

//        IMediator BuildMediator()
//        {
//            //AutoFac
//            var builder = new ContainerBuilder();
//            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

//            var mediatrOpenTypes = new[] {
//            typeof(IRequestHandler<,>)
//        };

//            foreach (var mediatrOpenType in mediatrOpenTypes)
//            {
//                builder
//                    .RegisterAssemblyTypes(typeof(LogInUserByFormRequest).GetTypeInfo().Assembly)
//                    .AsClosedTypesOf(mediatrOpenType)
//                    .AsImplementedInterfaces();
//            }

//            builder.Register<ServiceFactory>(ctx => {
//                var c = ctx.Resolve<IComponentContext>();
//                return t => c.Resolve(t);
//            });

//            //...all other needed dependencies.

//            //...

//            var container = builder.Build();

//            var mediator = container.Resolve<IMediator>();
//            return mediator;
//        }
//    }
//}
