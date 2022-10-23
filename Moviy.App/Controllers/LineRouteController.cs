using AutoMapper;
using DevIO.App.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moviy.App.ViewModels;
using Moviy.Business.Interfaces;
using Moviy.Business.Interfaces.Services;
using Moviy.Business.Models;

namespace Moviy.App.Controllers
{
    [Authorize]
    public class LineRouteController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ILineRouteRepository _lineRouteRepository;
        private readonly ILocalRepository _localRepository;
        private readonly ILineRouteService _lineRouteService;

        public LineRouteController(ILineRouteRepository lineRouteRepository,
            IMapper mapper,
            ILocalRepository localRepository, ILineRouteService lineRouteService,
            INotificator notificator) : base(notificator)
        {
            _lineRouteRepository = lineRouteRepository;
            _mapper = mapper;
            _localRepository = localRepository;
            _lineRouteService = lineRouteService;
        }

        public async Task<IActionResult> Index()
        {

            return View(_mapper.Map<IEnumerable<LineRouteViewModel>>(await _lineRouteRepository.GetAll()));
        }


        [Route("line/create")]
        [ClaimsAuthorize("LineRoute", "Create")]
        public async Task<IActionResult> Create()
        {
            LineRouteViewModel lineRouteViewModel = new LineRouteViewModel();

            lineRouteViewModel.LocalsList.Add(new SelectListItem
            {
                Text = "Select Local",
                Value = ""
            });

            var locals = _mapper.Map<IEnumerable<LocalViewModel>>(await _localRepository.GetAll());

            foreach (var local in locals)
            {
                lineRouteViewModel.LocalsList.Add(new SelectListItem
                {
                    Text = local.Code,
                    Value = Convert.ToString(local.Id)
                });
            }




            return View(lineRouteViewModel);
        }



        [Route("line/create")]
        [HttpPost]
        [ClaimsAuthorize("LineRoute", "Create")]
        public async Task<IActionResult> Create(LineRouteViewModel lineRouteViewModel)
        {

            if (lineRouteViewModel.IsActive)
                lineRouteViewModel.ActivatedAt = DateTime.Now;
            else
                lineRouteViewModel.DeactivatedAt = DateTime.Now;


            if (!ModelState.IsValid)
                return RedirectToAction("Index", lineRouteViewModel);

            await _lineRouteService.Create(_mapper.Map<LineRoute>(lineRouteViewModel));

            return RedirectToAction("Index");
        }
    }
}
