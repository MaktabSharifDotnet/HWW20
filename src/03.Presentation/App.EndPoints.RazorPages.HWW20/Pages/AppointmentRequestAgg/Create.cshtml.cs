using App.Domain.Core.AppointmentRequestAgg.Contracts.AppService;
using App.Domain.Core.AppointmentRequestAgg.Dtos;
using App.Domain.Core.CarModelAgg.Contratcs.AppService;
using App.Domain.Core.CarModelAgg.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.RazorPages.HWW20.Pages.AppointmentRequest
{
    public class CreateModel(IAppointmentRequestAppService appointmentRequestAppService , ICarModelAppSerivce carModelAppSerivce ) : PageModel
    {
        [BindProperty]
        public RegisterInfoDto RegisterInfoDto { get; set; }
        public List<CarModelDto> CarModelDtos { get; set; }
        [BindProperty]
        public string PlatePart1 { get; set; } 

        [BindProperty]
        public string PlateLetter { get; set; }

        [BindProperty]
        public string PlatePart2 { get; set; } 

        [BindProperty]
        public string PlateIranId { get; set; }
        public List<string> AlphabetList { get; set; } = new List<string>()
        {
            "الف", "ب", "پ", "ت", "ث", "ج", "د", "ز", "س", "ش", "ص", "ط", "ع", "ف", "ق", "ک", "گ", "ل", "م", "ن", "و", "ه", "ی", "ژ", "معلولین"
        };
        public void OnGet()
        {
            CarModelDtos=carModelAppSerivce.GetAll();


        }
        public IActionResult OnPost() 
        {
            RegisterInfoDto.LicensePlate = $"{PlatePart1}{PlateLetter}{PlatePart2}{PlateIranId}";
            appointmentRequestAppService.Create(RegisterInfoDto);

           return Page();
        }
    }
}
