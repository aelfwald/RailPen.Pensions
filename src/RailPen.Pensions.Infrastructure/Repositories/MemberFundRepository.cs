using RailPen.Pensions.Application.DataObjects;
using RailPen.Pensions.Application.Repositories;

namespace RailPen.Pensions.Infrastructure.Repositories;

public class MemberFundRepository : IMemberFundRepository
{
    private List<MemberFundDto> _memberFunds;

    public MemberFundRepository()
    {
        SeedData();
    }

    public IEnumerable<MemberFundDto> GetAll()
    {
        return _memberFunds;
    }

    public void Add(MemberFundDto memberFundDto)
    {
        memberFundDto.Id = _memberFunds.Max(memberFund => memberFund.Id) + 1;
        _memberFunds.Add(memberFundDto);
    }

    public void Delete(int id)
    {
        var memberFund = _memberFunds.FirstOrDefault(memberFund => memberFund.Id == id);
        if (memberFund != null)
        {
            _memberFunds.Remove(memberFund);
        }   
    }

    public void Update(int id, decimal units)
    {
        var memberFund = _memberFunds.FirstOrDefault(memberFund => memberFund.Id == id);
        if (memberFund != null)
        {
            memberFund.Units = units;
        }
    }

    public IEnumerable<MemberFundDto> GetByMemberId(int personId)
    {
        return _memberFunds.Where(memberFund => memberFund.MemberId == personId);
    }

    private void SeedData()
    {
        _memberFunds =
        [
            new MemberFundDto
            {
                Id = 1,
                Units = 102564m,
                MemberId = 1,
                FundId = 4
            },
            new MemberFundDto
            {
                Id = 2,
                Units = 52477m,
                MemberId = 2,
                FundId = 2
            },
            new MemberFundDto
            {
                Id = 3,
                Units = 25654m,
                MemberId = 3,
                FundId = 1
            },
            new MemberFundDto
            {
                Id = 4,
                Units = 10000m,
                MemberId = 3,
                FundId = 3
            },
            new MemberFundDto
            {
                Id = 5,
                
                Units = 5486m,
                MemberId = 4,
                FundId = 1
            }
        ];
    }
}