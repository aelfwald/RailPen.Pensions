using System.ComponentModel.DataAnnotations;

namespace RailPen.Pensions.UI.Models.Members;

public class DetailsModel
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int NumberOfFunds { get; init; }
    [DisplayFormat(DataFormatString = "{0:d}")]
    public DateTime DateOfRetirement { get; init; } = DateTime.MinValue;
    public string PensionRef { get; init; } = string.Empty;
    [DisplayFormat(DataFormatString = "{0:C}")]
    public decimal TotalPensionValue { get; init; }
}