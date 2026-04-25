using RailPen.Pensions.Application.Builders;
using RailPen.Pensions.Application.DataObjects;
using RailPen.Pensions.Application.Dto;
using RailPen.Pensions.Application.Repositories;

namespace RailPen.Pensions.Application.Services;

public class MemberService (
    IMemberRepository memberRepository, 
    IPensionDomainObjectBuilder builder)
    : IMemberService
{
    public IEnumerable<MemberDetailsDto> GetAll()
    {
        IEnumerable<MemberDto> members = memberRepository.GetAll();
        foreach (var member in members)
        {
            var pension = builder.Build(member.PensionRef);
            yield return new MemberDetailsDto
            {
                Id = member.Id,
                Name = member.MemberName,
                PensionRef = member.PensionRef,
                NumberOfFunds = pension.NumberOfFunds,
                TotalPensionValue = pension.TotalValue,
                DateOfRetirement = pension.Member.RetirementDate
            };
        }
    }
}