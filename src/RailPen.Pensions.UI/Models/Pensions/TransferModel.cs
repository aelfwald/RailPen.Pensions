using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RailPen.Pensions.UI.Models.Pensions;

public class TransferModel 
{
    public string PensionRef { get; init; }

    public int FromFundId { get; init; }

    [DisplayName("From Fund Name")]
    public string FromFundName { get; init; } = string.Empty;

    [DisplayName("Fund Value")]
    [DisplayFormat(DataFormatString = "{0:C}")]
    public decimal FundValue { get; init; }

    [DisplayName("To Fund")]
    public int ToFundId { get; init; }

    [BindNever]
    public List<FundSelectModel> AvailableFunds { get; init; } = [];

    [DisplayName("Transfer Amount")]
    public decimal Amount { get; init; }

}