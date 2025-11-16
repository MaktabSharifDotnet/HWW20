using App.Domain.Core.AppointmentRequestAgg.Enums;
using App.Domain.Core.OperatorAgg.Entities;

public class RequestLog
{
    public int Id { get; set; }

    public int RequestId { get; set; }
    public AppointmentRequest AppointmentRequest { get; set; }

    public RequestStatusEnum OldStatus { get; set; }
    public RequestStatusEnum NewStatus { get; set; }

    public DateTime ChangedAt { get; set; }

    public int? OperatorId { get; set; }
    public Operator Operator { get; set; }

    public string Description { get; set; }
}
