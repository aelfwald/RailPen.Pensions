using RailPen.Pensions.Application.Dto;

namespace RailPen.Pensions.Application.Services;

public interface  IPensionService
{
    PensionDetailsDto GetForPension(string pensionRef); 
    void Transfer(string pensionRef, int fromFundId, int toFundId, decimal amount);
}