namespace RailPen.Pensions.Application.Dto;

public class MemberDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string PensionRef { get; set; } = string.Empty;
    public int NumberOfFunds { get; set; }
    public decimal TotalPensionValue { get; set; }
    public DateTime DateOfRetirement { get; set; }
}