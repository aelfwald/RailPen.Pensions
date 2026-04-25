using RailPen.Pensions.Application.Dto;
using RailPen.Pensions.UI.Models.Members;
using RailPen.Pensions.UI.Models.Pensions;

namespace RailPen.Pensions.UI.Services;

public class ModelBuilder : IModelBuilder
{
    public MemberModel BuildMembersModel(IEnumerable<MemberDetailsDto> members)
    {
        var model = new MemberModel()
        {
            Members = members.Select(member => new DetailsModel
            {
                Id = member.Id,
                Name = member.Name,
                NumberOfFunds = member.NumberOfFunds,
                DateOfRetirement = member.DateOfRetirement,
                PensionRef = member.PensionRef,
                TotalPensionValue = member.TotalPensionValue
            }).ToList()
        };

        return model;
    }

    public PensionDetailsModel BuildPensionDetailsModel(PensionDetailsDto pensionDetails)
    {
        var model = new PensionDetailsModel()
        {
            Id = pensionDetails.Id,
            MemberName= pensionDetails.MemberName,
            PensionRef = pensionDetails.PensionRef,
            PensionValue = pensionDetails.PensionValue,
            Today = pensionDetails.Today,
            InvestedFunds = pensionDetails.InvestedFunds.Select(fund => new FundModel
            {
                Id = fund.Id,
                Name = fund.Name,
                RiskLevel = fund.RiskLevel,
                UnitPrice = fund.UnitPrice,
                Units = fund.Units,
                Value = fund.Value
            }).ToList(),
            AvailableFunds = pensionDetails.AvailableFunds.Select(fund => new FundModel
            {
                Id = fund.Id,
                Name = fund.Name,
                RiskLevel = fund.RiskLevel,
                UnitPrice = fund.UnitPrice
            }).ToList()
        };
        return model;
    }

    public TransferModel BuildTransferModel(PensionDetailsDto pensionDetails, int toFundId)
    {
        return new TransferModel()
        {
            Amount = 0,
            FromFundId = toFundId,
            FromFundName = pensionDetails.InvestedFunds.First(f => f.Id == toFundId).Name,
            FundValue = pensionDetails.InvestedFunds.First(f => f.Id == toFundId).Value,
            ToFundId = pensionDetails.AvailableFunds.First().Id,
            AvailableFunds = pensionDetails.AvailableFunds.Where(fund => fund.Id != toFundId).Select(fund => new FundSelectModel
            {
                Id = fund.Id,
                Name = $"{fund.Name} ({fund.RiskLevel}) - {fund.UnitPrice:C} Per Unit",
            }).ToList()        
        };
    }
}