using Microsoft.Extensions.DependencyInjection;
using SafetySystems.SafetyAudit.Application.SafetyInspection;

namespace SafetySystems.SafetyAudit.Application;

public static class DependencyInjectionExtensions
{
    public static void AddSafetySystemsApplication(this IServiceCollection services)
    {
        services.AddTransient<IReportRiskFindingCommandHandler, ReportRiskFindingCommandHandler>();
    }
}
