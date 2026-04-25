using Microsoft.AspNetCore.Mvc;
using RailPen.Pensions.Application.Services;
using RailPen.Pensions.UI.Services;

namespace RailPen.Pensions.UI.Controllers;

public class MembersController (
    IMemberService membersService,
    IModelBuilder viewModelBuilder          
)
    : Controller
{
    public ActionResult Index()
    {
        var members = membersService.GetAll();
        var membersVm = viewModelBuilder.BuildMembersModel(members);

        return View(membersVm);
    }
}