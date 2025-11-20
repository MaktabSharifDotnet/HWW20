using App.Domain.AppServices.CarModelAgg;
using App.Domain.Core.AppointmentRequestAgg.Contracts.AppService;
using App.Domain.Core.AppointmentRequestAgg.Dtos;
using App.Domain.Core.AppointmentRequestAgg.Enums;
using App.Domain.Core.CarModelAgg.Contracts.AppService;
using App.Domain.Core.CarModelAgg.Dtos;
using App.EndPoints.RazorPages.HWW20.Excentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.RazorPages.HWW20.Pages.AppointmentRequestAgg
{
    public class CreateModel(IAppointmentRequestAppService appointmentRequestAppService,
        ICarModelAppService carModelAppSerivce) : PageModel
    {
        [BindProperty]
        public RegisterInfoDto RegisterInfoDto { get; set; }
        public List<CarModelDto> CarModelDtos { get; set; } = [];
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
            CarModelDtos = carModelAppSerivce.GetAll();
        }

        public IActionResult OnPost()
        {


            RegisterInfoDto.LicensePlate = $"{PlatePart1}{PlateLetter}{PlatePart2}{PlateIranId}";
            var shamsi = RegisterInfoDto.RequestDateShamsi;
            try
            {
                RegisterInfoDto.RequestDateMiladi = shamsi.ToMiladi().Date;
                if (!RegisterInfoDto.Mobile.IsValidMobileNumber())
                {
                    TempData["ErrorMessageForMobile"] = "فرمت شماره همراه نامعتبر است ";
                    return Page();
                }
                int id = appointmentRequestAppService.Create(RegisterInfoDto);
                if (id > 0)
                {
                    var createdRequest = appointmentRequestAppService.GetById(id);

                    if (createdRequest!.Status == RequestStatusEnum.Pending)
                    {
                        TempData["SuccessMessage"] = "درخواست شما با موفقیت ثبت شد و در انتظار بررسی است.";
                    }
                    else if (createdRequest.Status == RequestStatusEnum.Failed_AgeCriteria)
                    {
                        TempData["WarningMessage"] = " به دلیل سن بالای خودرو درخواست رد گردید.";
                    }
                   
                    else if (createdRequest.Status == RequestStatusEnum.Rejected)
                    {
                        TempData["ErrorMessage"] = "درخواست شما به دلیل عدم تطابق قوانین رد شد.";
                        return Page();
                    }

                }
                else
                {
                    TempData["ErrorMessage"] = "خطا در ثبت درخواست.";
                }
            }

            catch (FormatException e)
            {
                TempData["FailureMessage"] = "فرمت تاریخ شمسی معتبر نیست.";
                CarModelDtos = carModelAppSerivce.GetAll();
                return Page();
            }
            catch (Exception ex)
            {
                TempData["FailureMessage"] = "عملیات با خطا روبرو شد.";
                CarModelDtos = carModelAppSerivce.GetAll();
                return Page();
            }

            return Page();
        }
    }
}
