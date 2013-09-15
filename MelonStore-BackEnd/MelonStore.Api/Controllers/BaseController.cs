namespace MelonStore.Api.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class BaseController : ApiController
    {
        protected T PerformOperationAndHandleExceptions<T>(Func<T> action)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                var response = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(response);
            }
        }
    }
}