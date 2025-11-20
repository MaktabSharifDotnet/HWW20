using App.Domain.Core._common.InMemory;
using App.Domain.Core.AppointmentRequestAgg.Contracts.AppService;
using App.Domain.Core.AppointmentRequestAgg.Dtos;
using App.Domain.Core.AppointmentRequestAgg.Enums;
using App.Domain.Core.CarModelAgg.Enums;
using App.EndPoints.RazorPages.HWW20.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.RazorPages.HWW20.Pages.OperatorAgg
{//
    public class ListAppointmentsRequestModel(IAppointmentRequestAppService appointmentRequestAppService) : PageModel
    {
        public List<AppointmentRequestSummaryDto> AppointmentRequestSummaryDto { get; set; }

        [BindProperty]
        public ChangeStatusInfoDto ChangeStatusInfoDto { get; set; }
        public void OnGet(string fromDate, string toDate, CompanyEnum? company)
        {
            var filter = new AppointmentFilterDto();
            if (!string.IsNullOrEmpty(fromDate))
                filter.FromDate = DateHelper.ShamsiToMiladi(fromDate);

            if (!string.IsNullOrEmpty(toDate))
                filter.ToDate = DateHelper.ShamsiToMiladi(toDate);

            filter.CompanyEnum = company;

            AppointmentRequestSummaryDto = appointmentRequestAppService.GetFiltered(filter);

            foreach (var item in AppointmentRequestSummaryDto)
                item.RequestDateShamsi = DateHelper.MiladiToShamsi(item.RequestDate);
        }

        public IActionResult OnPostAccept(int id)
        {
            ChangeStatusInfoDto = new ChangeStatusInfoDto
            {
                RequestId = id,
                NewStatusEnum = RequestStatusEnum.Approved,
                OperatorId = LocalStorage.Operator!.Id
            };
            appointmentRequestAppService.ChangeStatus(ChangeStatusInfoDto);
            return RedirectToPage();
        }

        public IActionResult OnPostReject(int id)
        {
            ChangeStatusInfoDto = new ChangeStatusInfoDto
            {
                RequestId = id,
                NewStatusEnum = RequestStatusEnum.Rejected,
                OperatorId = LocalStorage.Operator!.Id
            };
            appointmentRequestAppService.ChangeStatus(ChangeStatusInfoDto);
            return RedirectToPage();
        }
    }
}
