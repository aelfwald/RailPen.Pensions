namespace RailPen.Pensions.Application.Dto;

public class PensionFundDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string RiskLevel { get; set; } = string.Empty;   
    public decimal UnitPrice { get; set; }
    public decimal Units { get; set; }
    public decimal Value { get; set; }
}