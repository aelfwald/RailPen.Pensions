using RailPen.Pensions.Application.Dto;
using RailPen.Pensions.UI.Models.Members;
using RailPen.Pensions.UI.Models.Pensions;

namespace RailPen.Pensions.UI.Services;

public interface IModelBuilder
{
    MemberModel BuildMembersModel(IEnumerable<MemberDetailsDto> members);
    PensionDetailsModel BuildPensionDetailsModel(PensionDetailsDto pensionDetails);
    TransferModel BuildTransferModel(PensionDetailsDto pensionDetails, int toFundId);
}