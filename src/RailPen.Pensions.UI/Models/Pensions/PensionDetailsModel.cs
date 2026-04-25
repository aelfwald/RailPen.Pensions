using System.ComponentModel.DataAnnotations;

namespace RailPen.Pensions.UI.Models.Pensions;

public class PensionDetailsModel
{
    public int Id { get; init; }
    public string MemberName { get; init; } = string.Empty;
    public string PensionRef { get; init; } = string.Empty;

    [DisplayFormat(DataFormatString = "{0:C}")]
    public decimal PensionValue { get; init; }
    [DisplayFormat(DataFormatString = "{0:d}")]
    public DateTime Today { get; init; }    
    public List<FundModel> InvestedFunds { get; init; } = [];
    public List<FundModel> AvailableFunds { get; init; } = [];
}