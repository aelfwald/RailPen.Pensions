using RailPen.Pensions.Domain.Pension;

namespace RailPen.Pensions.Application.Builders;

public interface IPensionDomainObjectBuilder
{
    Pension Build(string pensionRef);
}