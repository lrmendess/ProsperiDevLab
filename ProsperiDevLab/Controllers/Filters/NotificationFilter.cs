using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using ProsperiDevLab.Services.Notificator;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProsperiDevLab.Controllers.Filters
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly INotificator _notificator;

        public NotificationFilter(INotificator notificator)
        {
            _notificator = notificator;
        }

		public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
		{
			if (_notificator.HasErrors())
			{
				context.HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
				context.HttpContext.Response.ContentType = "application/json";

				var notifications = JsonSerializer.Serialize(_notificator.GetErrors());
				
				await context.HttpContext.Response.WriteAsync(notifications);

				return;
			}

			await next();
		}
	}
}
