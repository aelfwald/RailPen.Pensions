using RailPen.Pensions.Domain.Pension;

namespace RailPen.Pensions.Application.Services;

public interface IPersistenceService
{
    public void SaveFunds(Pension pension, int[] fundIds);
}