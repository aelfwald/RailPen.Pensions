
namespace RailPen.Pensions.Domain.Pension;

public class Fund
{
    internal Fund() { }
    public int FundId { get; internal set; }
    public int? MemberFundId { get; internal set; }
    public string FundName { get; internal set; } = string.Empty;
    public string RiskLevel { get; internal set; } = string.Empty;
    public decimal PricePerUnit { get; internal set; }
    public decimal TotalUnits { get; internal set; }
    public decimal CurrentValue => Math.Round(PricePerUnit * TotalUnits, 2, MidpointRounding.ToEven);
    public bool IsInvested => TotalUnits > 0;
    public void Sell(decimal amount)
    {
        if(amount > CurrentValue)
        {
            throw new InvalidOperationException("Cannot sell more than the total value of the fund.");
        }

        var unitsToSell = Math.Round(amount / PricePerUnit, 4, MidpointRounding.ToEven) ;
        TotalUnits -= unitsToSell;
    }
    public void Buy(decimal amount)
    {
        var unitsToBuy = Math.Round( amount / PricePerUnit, 4, MidpointRounding.ToEven);
        TotalUnits += unitsToBuy;
    }
}
