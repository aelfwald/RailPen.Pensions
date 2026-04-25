namespace RailPen.Pensions.Application.Dto;

public class PensionDetailsDto
{
    public int Id { get; set; }
    public string MemberName { get; set; } = string.Empty;
    public string PensionRef { get; set; } = string.Empty;
    public decimal PensionValue { get; set; }
    public DateTime Today { get; set; }    
    public List<PensionFundDto> InvestedFunds { get; set; } = [];
    public List<PensionFundDto> AvailableFunds { get; set; } = [];
}