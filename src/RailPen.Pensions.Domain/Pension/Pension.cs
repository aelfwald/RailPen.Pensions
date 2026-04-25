using System.Collections.ObjectModel;

namespace RailPen.Pensions.Domain.Pension;

public class Pension
{
    internal Pension() { }
    public string PensionRef { get; internal set; } = string.Empty;
    public Member Member { get; internal init; }
    public ReadOnlyCollection<Fund> InvestedFunds => new ReadOnlyCollection<Fund>(Funds.Where(fund => fund.IsInvested).ToList());
    public ReadOnlyCollection<Fund> Funds { get; init; } = new ReadOnlyCollection<Fund>(new List<Fund>());
    public int NumberOfFunds => Funds.Count( fund => fund.IsInvested);
    public decimal TotalValue => Funds.Where(fund => fund.IsInvested).Sum(fund => fund.CurrentValue);
    public decimal GetFundUnits(int fundId)
    {
        var fund = Funds.FirstOrDefault(fund => fund.FundId == fundId);
        return fund?.TotalUnits ?? 0;
    }

    public int? GetMemberFundIdForFund(int fundId)
    {
        return Funds.First(fund => fund.FundId == fundId).MemberFundId;
    }

    public void TransferFunds(int fromFundId, int toFundId, decimal amount)
    {
        var fromFund = Funds.FirstOrDefault(fund => fund.FundId == fromFundId);
        var toFund = Funds.FirstOrDefault(fund => fund.FundId == toFundId);

        fromFund.Sell(amount);
        toFund.Buy(amount);
    }
}