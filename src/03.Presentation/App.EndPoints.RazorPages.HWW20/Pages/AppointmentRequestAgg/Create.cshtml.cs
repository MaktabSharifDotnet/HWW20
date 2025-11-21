using App.Domain.Core._common.InMemory;
using App.Domain.Core.AppFileAgg;
using App.Domain.Core.AppointmentRequestAgg.Contracts.AppService;
using App.Domain.Core.AppointmentRequestAgg.Dtos;
using App.Domain.Core.AppointmentRequestAgg.Enums;
using App.Domain.Core.AppointmentRequestAgg.Exceptions;
using App.Domain.Core.CarModelAgg.Contratcs.AppService;
using App.Domain.Core.CarModelAgg.Dtos;
using App.Domain.Core.Exceptions;
using App.EndPoints.RazorPages.HWW20.Pages.Extensions;
using App.Infra.Data.Repos.Ef.AppFileAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.RazorPages.HWW20.Pages.AppointmentRequest
{
    public class CreateModel(IAppointmentRequestAppService appointmentRequestAppService
        , IFileUploader fileUploader, ICarModelAppSerivce carModelAppSerivce ) : PageModel
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

        [BindProperty]
        public List<IFormFile> UploadedImages { get; set; }
        public void OnGet()
        {
            CarModelDtos=carModelAppSerivce.GetAll();
        }
        public IActionResult OnPost() 
        {


            RegisterInfoDto.LicensePlate = $"{PlatePart1}{PlateLetter}{PlatePart2}{PlateIranId}";
            var shamsi = RegisterInfoDto.RequestDate;
            try
            {
                RegisterInfoDto.RequestDateMiladi = shamsi.ToMiladi().Date;
                if (!RegisterInfoDto.Mobile.IsValidMobileNumber()) 
                {
                    TempData["ErrorMessageForMobile"] = "فرمت شماره همراه نامعتبر است ";
                    return Page();
                }
                if (UploadedImages != null && UploadedImages.Count > 0)
                {
                   
                    foreach (var file in UploadedImages)
                    {
                
                        if (file.Length > 0)
                        {

                            string path = fileUploader.Upload(file, "CarImages");

                            RegisterInfoDto.ImagePaths.Add(path);
                        }
                    }
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
                    else if (createdRequest.Status == RequestStatusEnum.Failed_DailyLimit)
                    {
                        TempData["WarningMessage"] = " ظرفیت روزانه تکمیل است.";
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
           
            catch(LicensePlateIsExistException e) 
            {
                TempData["FailureMessage"] = e.Message;
                CarModelDtos = carModelAppSerivce.GetAll();
                return Page();
            }
            catch(FormatException e) 
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
