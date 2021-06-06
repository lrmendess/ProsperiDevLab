using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using ProsperiDevLab.Controllers.Contracts.Response;
using ProsperiDevLab.Services.Notificator;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProsperiDevLab.Controllers.Filters
{
    public class ErrorNotificationFilter : IAsyncResultFilter
    {
        private readonly INotificator _notificator;
		private readonly IMapper _mapper;

        public ErrorNotificationFilter(INotificator notificator, IMapper mapper)
        {
            _notificator = notificator;
			_mapper = mapper;
        }

		public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
		{
			if (_notificator.HasErrors())
			{
				context.HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
				context.HttpContext.Response.ContentType = "application/json";

				var errors = JsonSerializer.Serialize(new ErrorResponse
				{
					Errors = _mapper.Map<IEnumerable<NotificationResponse>>(_notificator.GetErrors())
				});
				
				await context.HttpContext.Response.WriteAsync(errors);

				return;
			}

			await next();
		}
	}
}
