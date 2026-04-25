using RailPen.Pensions.Application.DataObjects;
using RailPen.Pensions.Application.Repositories;
using RailPen.Pensions.Domain.Factories;
using RailPen.Pensions.Domain.Pension;

namespace RailPen.Pensions.Application.Builders;

public class PensionDomainObjectBuilder(
    IPensionFactory pensionFactory,
    IMemberRepository memberRepository,
    IMemberFundRepository memberFundRepository,
    IFundRepository fundRepository
    ) : IPensionDomainObjectBuilder
{
   
    public Pension Build(string pensionRef)
    {
        MemberDto? member = memberRepository.GetByPensionRef(pensionRef);
        if (member == null)
        {
            return null;
        }

        IEnumerable<MemberFundDto> memberFunds = memberFundRepository.GetByMemberId(member.Id);
        IEnumerable<FundDto> availableFunds = fundRepository.GetAll();

        List<Fund> funds = new List<Fund>();
        foreach (FundDto fundDto in availableFunds)
        {
            MemberFundDto memberFund = memberFunds.FirstOrDefault(mf => mf.FundId == fundDto.Id);
            funds.Add(pensionFactory.CreateFund(
                fundDto.Id,
                memberFund?.Id,
                fundDto.FundName,
                fundDto.RiskLevel,
                fundDto.PricePerUnit,
                memberFund?.Units ?? 0));
        }

        Member pensionMember = pensionFactory.CreateMember(
            member.Id,
            member.MemberName,
            member.Gender,
            member.DoB,
            member.TargetRetirementAge);

        Pension pension = pensionFactory.CreatePension(member.PensionRef, pensionMember, funds);

        return pension;
    }
}