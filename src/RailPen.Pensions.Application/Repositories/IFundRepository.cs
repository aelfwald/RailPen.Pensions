using RailPen.Pensions.Application.DataObjects;

namespace RailPen.Pensions.Application.Repositories;

public interface IFundRepository
{
    IEnumerable<FundDto> GetAll();
}