using FluentValidation;
using FluentValidation.AspNetCore;
using LMS.Application.Common.Behaviors;
using LMS.Application.Students.Commands.CreateOrUpdateGuardian;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace LMS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddFluentValidationAutoValidation().AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
