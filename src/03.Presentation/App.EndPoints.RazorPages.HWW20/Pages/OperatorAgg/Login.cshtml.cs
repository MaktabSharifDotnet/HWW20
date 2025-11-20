using App.Domain.Core._common.InMemory;
using App.Domain.Core.OperatorAgg.Contracts.AppService;
using App.Domain.Core.OperatorAgg.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.RazorPages.HWW20.Pages.OperatorAgg
{
    public class LoginModel(IOperatorAppService operatorAppService) : PageModel
    {
        [BindProperty]
        public LogInInfoDto LogInInfoDto { get; set; }
        public void OnGet()
        {
          
        }
        public IActionResult OnPost() 
        {
            try
            {
               int result=operatorAppService.Login(LogInInfoDto.Username, LogInInfoDto.Password);
                if (result>0)
                {
                    var operatorLogin=operatorAppService.GetByUsername(LogInInfoDto.Username);
                    LocalStorage.Operator = operatorLogin;
                    return RedirectToPage("ListAppointmentsRequest");
                }
                else 
                {
                    TempData["ErrorMessage"] = "درخواست شما به دلیل عدم تطابق قوانین رد شد.";
                    return Page();
                }
            }
            catch (Exception ex) 
            {
                TempData["ErrorMessage"] = ex.Message;
                return Page();
            }

        }
    }
}
