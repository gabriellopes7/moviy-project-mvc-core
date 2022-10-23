using Microsoft.AspNetCore.Mvc;
using Moviy.Business.Interfaces;

namespace Moviy.App.Controllers
{
    public class BaseController : Controller
    {
        private readonly INotificator _notificator;

        public BaseController(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected bool ValidOperation()
        {
            return !_notificator.HasNotification();
        }
    }
}
