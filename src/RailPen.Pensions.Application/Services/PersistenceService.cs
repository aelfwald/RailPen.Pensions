using RailPen.Pensions.Application.DataObjects;
using RailPen.Pensions.Application.Repositories;
using RailPen.Pensions.Domain.Pension;

namespace RailPen.Pensions.Application.Services;

public class PersistenceService(IMemberFundRepository memberFundRepository) : IPersistenceService
{
    public void SaveFunds(Pension pension, int[] fundIds)
    {
        foreach (int fundId in fundIds)
        { 
            decimal units = pension.GetFundUnits(fundId);
            int? memberFundId = pension.GetMemberFundIdForFund(fundId);
            if (memberFundId.HasValue && units == 0)
            {
                memberFundRepository.Delete(memberFundId.Value);
            }
            else if (!memberFundId.HasValue && units > 0)
            {
                memberFundRepository.Add(new MemberFundDto()
                {
                    FundId = fundId,
                    MemberId = pension.Member.Id,
                    Units = units
                });
            }
            else if (memberFundId.HasValue)
            {
                memberFundRepository.Update(memberFundId.Value, units);
            }
        }
    }
}