namespace RailPen.Pensions.Application.DataObjects;

public class FundDto
{
    public int Id { get; set; }
    public string FundName { get; set; } = string.Empty;
    public string RiskLevel { get; set; } = string.Empty;
    public decimal PricePerUnit { get; set; } 
}
