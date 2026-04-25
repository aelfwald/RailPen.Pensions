using RailPen.Pensions.Application.DataObjects;

namespace RailPen.Pensions.Application.Repositories;

public interface IMemberRepository
{
    IEnumerable<MemberDto> GetAll();
    MemberDto? GetByPensionRef(string pensionRef);
}