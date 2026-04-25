using RailPen.Pensions.Application.Builders;
using RailPen.Pensions.Application.DataObjects;
using RailPen.Pensions.Application.Dto;
using RailPen.Pensions.Application.Repositories;
using RailPen.Pensions.Domain.Pension;

namespace RailPen.Pensions.Application.Services;

public class PensionService (
    IMemberFundRepository memberFundRepository,
    IPensionDomainObjectBuilder builder)
    : IPensionService
{
    public PensionDetailsDto GetForPension(string pensionRef)
    {
        Pension pension = builder.Build(pensionRef);
        PensionDetailsDto pensionDetails = new PensionDetailsDto
        {
            Id = pension.Member.Id,
            MemberName = pension.Member.Name,
            PensionRef = pension.PensionRef,
            PensionValue = pension.TotalValue,
            Today = DateTime.UtcNow,
            InvestedFunds = pension.InvestedFunds.Select(fund => new PensionFundDto()
            {
                Id = fund.FundId,
                Name = fund.FundName,
                RiskLevel = fund.RiskLevel,
                UnitPrice = fund.PricePerUnit,
                Units = fund.TotalUnits,
                Value = fund.CurrentValue
            }).ToList(),
            AvailableFunds = pension.Funds.Select(fund => new PensionFundDto()
            {
                Id = fund.FundId,
                Name = fund.FundName,
                RiskLevel = fund.RiskLevel,
                UnitPrice = fund.PricePerUnit,
                Units = 0,
                Value = 0
            }).ToList()
        };

        return pensionDetails;
    }

    public void Transfer(string pensionRef, int fromFundId, int toFundId, decimal amount)
    {
        Pension pension = builder.Build(pensionRef);
        pension.TransferFunds(fromFundId, toFundId, amount);

        decimal toFundUnits = pension.GetFundUnits(toFundId);
        int? toFundMemberFundId = pension.GetMemberFundIdForFund(toFundId);
        if (!toFundMemberFundId.HasValue)
        {
            memberFundRepository.Add(new MemberFundDto()
            {
                FundId = toFundId,
                MemberId = pension.Member.Id,
                Units = toFundUnits
            });
        }
        else
        {
            memberFundRepository.Update(toFundMemberFundId.Value, toFundUnits);
        }

        decimal fromMemberFundUnits = pension.GetFundUnits(fromFundId);
        int fromMemberFundId = pension.GetMemberFundIdForFund(fromFundId)!.Value;
        if (fromMemberFundUnits == 0)
        {
            memberFundRepository.Delete(fromMemberFundId);
        }
        else
        {
            memberFundRepository.Update(fromMemberFundId, fromMemberFundUnits);
        }
    }
}