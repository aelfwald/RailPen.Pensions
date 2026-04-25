using RailPen.Pensions.Domain.Pension;

namespace RailPen.Pensions.Domain.Factories
{
    public interface IPensionFactory
    {
        public Pension.Pension CreatePension(string pensionRef, Member member, List<Fund> funds);
        public Member CreateMember(int id, string name, string gender, DateTime dateOfBirth, int retirementAge);
        public Fund CreateFund(int fundId, int? memberFundId, string fundName, string riskLevel, decimal pricePerUnit, decimal totalUnits);
    }
}
