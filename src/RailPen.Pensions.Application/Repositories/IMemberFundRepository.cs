using RailPen.Pensions.Application.DataObjects;

namespace RailPen.Pensions.Application.Repositories;

public interface IMemberFundRepository
{
    IEnumerable<MemberFundDto> GetAll();
    void Add(MemberFundDto memberFundDto);
    void Delete (int id);
    void Update(int id, decimal units);
    IEnumerable<MemberFundDto> GetByMemberId(int personId);

}