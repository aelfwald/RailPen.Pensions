using RailPen.Pensions.Application.DataObjects;
using RailPen.Pensions.Application.Repositories;

namespace RailPen.Pensions.Infrastructure.Repositories;

public class MemberRepository : IMemberRepository
{
    private List<MemberDto> _members;

    public MemberRepository()
    {
        SeedData();
    }

    public IEnumerable<MemberDto> GetAll()
    {
        return _members;
    }

    public MemberDto? GetByPensionRef(string pensionRef)
    {
        return _members.FirstOrDefault(m => m.PensionRef == pensionRef);
    }

    private void SeedData()
    {
        _members =
        [
            new MemberDto
            {
                Id = 1,
                MemberName = "Brian McCall",
                DoB = new DateTime(1965, 8, 1),
                Gender = "M",
                TargetRetirementAge = 60,
                PensionRef = "P0000097"
            },
            new MemberDto
            {
                Id = 2,
                MemberName = "Sarah Kramer",
                DoB = new DateTime(1984, 4, 3),
                Gender = "F",
                TargetRetirementAge = 60,
                PensionRef = "P0000136"
            },
            new MemberDto
            {
                Id = 3,
                MemberName = "Lianne Barrow",
                DoB = new DateTime(1975, 9, 26),
                Gender = "F",
                TargetRetirementAge = 62,
                PensionRef = "P00046570"
            },
            new MemberDto
            {
                Id = 4,
                MemberName = "Kara McCall",
                DoB = new DateTime(1992, 5, 6),
                Gender = "F",
                TargetRetirementAge = 65,
                PensionRef = "P0004782"
            }
        ];
    }

}