using Microsoft.AspNetCore.Mvc;
using RailPen.Pensions.Application.Dto;
using RailPen.Pensions.Application.Services;
using RailPen.Pensions.UI.Models.Pensions;
using RailPen.Pensions.UI.Services;

namespace RailPen.Pensions.UI.Controllers;

public class PensionsController(
    IPensionService pensionService,
    IModelBuilder viewModelBuilder) : Controller
{
    public ActionResult Details(string pensionRef)
    {
        PensionDetailsDto pensionDetails = pensionService.GetForPension(pensionRef);
        PensionDetailsModel pensionDetailsVm = viewModelBuilder.BuildPensionDetailsModel(pensionDetails);
        return View(pensionDetailsVm);
    }

    [Route("{pensionRef}/fund/{fundId}")]
    public PartialViewResult Transfer(string pensionRef, int fundId)
    {
        PensionDetailsDto pensionDetails = pensionService.GetForPension(pensionRef);
        TransferModel transferModel = viewModelBuilder.BuildTransferModel(pensionDetails, fundId);
        return PartialView(transferModel);
    }

    [HttpPost]
    public ActionResult ProcessTransfer(TransferModel model)
    {
        if (!ModelState.IsValid)
        {
            return Json(new { success = false, message = "Invalid request" });
        }

        pensionService.Transfer(model.PensionRef, model.FromFundId, model.ToFundId, model.Amount);
        return Json(new { success = true, message = "Transfer completed successfully" });
    }
}