namespace RailPen.Pensions.Application.DataObjects;

public class MemberDto
{
    public int Id { get; set; }
    public string MemberName { get; set; } = string.Empty;
    public DateTime DoB { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string PensionRef { get; set; } = string.Empty;
    public int TargetRetirementAge { get; set; }
}