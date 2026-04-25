using RailPen.Pensions.Application.DataObjects;
using RailPen.Pensions.Application.Repositories;

namespace RailPen.Pensions.Infrastructure.Repositories;

public class FundRepository : IFundRepository
{
    private List<FundDto> _funds;

    public FundRepository()
    {
        SeedData();
    }

    public IEnumerable<FundDto> GetAll()
    {
        return _funds;
    }

    private void SeedData()
    {
        _funds =
        [
            new FundDto
            {
                Id = 1,
                FundName = "Default Fund",
                RiskLevel = "Low",
                PricePerUnit = 1.25m
            },
            new FundDto
            {
                Id = 2,
                FundName = "Long Term Growth",
                RiskLevel = "Low",
                PricePerUnit = 1.26m
            },
            new FundDto
            {
                Id = 3,
                FundName = "High Rollers Fund",
                RiskLevel = "High",
                PricePerUnit = 1.45m
            },
            new FundDto
            {
                Id = 4,
                FundName = "Property Fund",
                RiskLevel = "Medium",
                PricePerUnit = 1.30m
            }
        ];
    }
}