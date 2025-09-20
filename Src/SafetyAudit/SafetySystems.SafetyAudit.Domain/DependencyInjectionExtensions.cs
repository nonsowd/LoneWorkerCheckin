using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SafetySystems.SafetyAudit.Domain.Validation;

namespace SafetySystems.SafetyAudit.Domain
{
    public static class DependencyInjectionExtensions
    {
        public static void AddSafetySystemsDomain(this IServiceCollection services)
        {
            services.AddTransient<IValidator<RiskFinding>, RiskFindingValidator>();
        }
    }
}
