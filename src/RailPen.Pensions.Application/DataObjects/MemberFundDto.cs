namespace RailPen.Pensions.Application.DataObjects;

public class MemberFundDto
{
    public int Id { get; set; }
    public decimal Units { get; set; }
    public int MemberId { get; set; }
    public int FundId { get; set; }
}
