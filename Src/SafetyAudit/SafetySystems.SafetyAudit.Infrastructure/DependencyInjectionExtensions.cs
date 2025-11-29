using Microsoft.Extensions.DependencyInjection;
using SafetySystems.SafetyAudit.Infrastructure.DAL;

namespace SafetySystems.SafetyAudit.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static void AddSafetySystemsInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IRiskFindingRepository, RiskFindingRepository>();
    }
}
