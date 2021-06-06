using System.Collections.Generic;

namespace ProsperiDevLab.Controllers.Contracts.Response
{
    public class ErrorResponse
    {
        public IEnumerable<NotificationResponse> Errors { get; set; }
    }
}
