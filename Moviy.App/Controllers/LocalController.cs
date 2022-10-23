using AutoMapper;
using DevIO.App.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moviy.App.ViewModels;
using Moviy.Business.Interfaces;
using Moviy.Business.Interfaces.Services;
using Moviy.Business.Models;

namespace Moviy.App.Controllers
{
    [Authorize]
    public class LocalController : BaseController
    {
        private readonly ILocalRepository _localRepository;
        private readonly IMapper _mapper;
        private readonly ILocalService _localService;

        public LocalController(IMapper mapper,
            ILocalRepository localRepository, ILocalService localService,
            INotificator notificator) : base(notificator)
        {
            _mapper = mapper;
            _localRepository = localRepository;
            _localService = localService;
        }

        public async Task<IActionResult> Index()
        {
            var localList = _mapper.Map<IEnumerable<LocalViewModel>>(await _localRepository.GetAll());

            return View(localList);
        }

        [ClaimsAuthorize("Local", "Create")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ClaimsAuthorize("Local", "Create")]
        public async Task<IActionResult> Create(LocalViewModel localViewModel)
        {
            if (!ModelState.IsValid)
                return View(localViewModel);

            var local = _mapper.Map<Local>(localViewModel);
            await _localService.Create(local);

            return RedirectToAction("Index");
        }



    }
}
