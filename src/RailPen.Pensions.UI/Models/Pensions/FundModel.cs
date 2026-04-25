using System.ComponentModel.DataAnnotations;

namespace RailPen.Pensions.UI.Models.Pensions;

public class FundModel
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string RiskLevel { get; init; } = string.Empty;
    [DisplayFormat(DataFormatString = "{0:C}")]
    public decimal UnitPrice { get; init; }
    [DisplayFormat(DataFormatString = "{0:N4}")]
    public decimal Units { get; init; }
    [DisplayFormat(DataFormatString = "{0:C}")]
    public decimal Value { get; init; }
}