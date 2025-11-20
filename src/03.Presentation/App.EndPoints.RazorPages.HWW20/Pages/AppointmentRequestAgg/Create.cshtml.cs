using App.Domain.Core.AppointmentRequestAgg.Contracts.AppService;
using App.Domain.Core.AppointmentRequestAgg.Dtos;
using App.Domain.Core.CarModelAgg.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.RazorPages.HWW20.Pages.AppointmentRequestAgg
{
    public class CreateModel(IAppointmentRequestAppService appointmentRequestAppService) : PageModel
    {
        public int MyProperty { get; set; }

        [BindProperty]
        public RegisterInfoDto RegisterInfoDto { get; set; }

        
        public List<CarModelDto> CarModelDtos { get; set; }
        public void OnGet()
        {
            
        }
    }
}
