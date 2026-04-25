namespace RailPen.Pensions.Domain.Pension;

public class Member
{
    internal Member() { }
    public int Id { get; internal set; }
    public string Name { get; internal set; } = string.Empty;
    public string Gender { get; internal set; } = string.Empty;
    public DateTime DateOfBirth { get; internal set; }
    public int RetirementAge { get; internal set; }
    public DateTime RetirementDate => DateOfBirth.AddYears(RetirementAge);
}