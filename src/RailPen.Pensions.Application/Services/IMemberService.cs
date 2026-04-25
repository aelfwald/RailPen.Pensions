using RailPen.Pensions.Application.Dto;

namespace RailPen.Pensions.Application.Services;

public interface  IMemberService
{
    IEnumerable<MemberDetailsDto> GetAll(); 
}