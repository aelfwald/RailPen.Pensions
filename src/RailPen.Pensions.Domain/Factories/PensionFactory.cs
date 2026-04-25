using RailPen.Pensions.Domain.Pension;

namespace RailPen.Pensions.Domain.Factories;

public class PensionFactory : IPensionFactory
{
    public Pension.Pension CreatePension(string pensionRef, Pension.Member member, List<Pension.Fund> funds)
    {
        return new Pension.Pension
        {
            PensionRef = pensionRef,
            Member = member,
            Funds = new System.Collections.ObjectModel.ReadOnlyCollection<Fund>(funds)
        };
    }
    public Member CreateMember(int id, string name, string gender, DateTime dateOfBirth, int retirementAge)
    {
        return new Member
        {
            Id = id,
            Name = name,
            Gender = gender,
            DateOfBirth = dateOfBirth,
            RetirementAge = retirementAge
        };
    }

    public Fund CreateFund(int fundId, int? memberFundId, string fundName, string riskLevel, decimal pricePerUnit, decimal totalUnits)
    {
        return new Fund
        {
            FundId = fundId,
            MemberFundId = memberFundId,
            FundName = fundName,
            RiskLevel = riskLevel,
            PricePerUnit = pricePerUnit,
            TotalUnits = totalUnits
        };
    }
}