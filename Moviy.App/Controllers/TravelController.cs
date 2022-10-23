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
    public class TravelController : BaseController
    {
        private readonly ITravelRepository _travelRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly IBusRepository _busRepository;
        private readonly ILineRouteRepository _lineRouteRepository;
        private readonly IMapper _mapper;
        private readonly ITravelService _travelService;



        public TravelController(ITravelRepository travelRepository,
            IMapper mapper,
            IDriverRepository driverRepository,
            IBusRepository busRepository,
            ILineRouteRepository lineRouteRepository, ITravelService travelService,
            INotificator notificator) : base(notificator)
        {
            _travelRepository = travelRepository;
            _mapper = mapper;
            _driverRepository = driverRepository;
            _busRepository = busRepository;
            _lineRouteRepository = lineRouteRepository;
            _travelService = travelService;
        }

        public async Task<IActionResult> Index()
        {
            var travels = await _travelRepository.GetAll();
            return View(_mapper.Map<IEnumerable<TravelViewModel>>(travels));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var travel = await _travelRepository.GetTravelDriverBusRoute(id);

            if (travel == null)
                return NotFound();


            return View(_mapper.Map<TravelViewModel>(travel));
        }

        [Route("close-travel/{id:guid}")]
        [ClaimsAuthorize("Travel", "Close")]
        public async Task<IActionResult> CloseTravel(Guid id)
        {
            var travelViewModel = await _travelRepository.Get(id);
            if (travelViewModel == null)
                return NotFound();


            await _travelService.CloseTravel(id);

            if (!ValidOperation())
                return RedirectToAction("Index");


            TempData["Sucesso"] = "Viagem finalizada com sucesso !";
            return RedirectToAction("Index");
        }

        [Route("travel/open-travel")]
        [ClaimsAuthorize("Travel", "Open")]
        public async Task<IActionResult> OpenTravel()
        {

            TravelViewModel travelViewModel = new TravelViewModel();

            travelViewModel.DriverList.Add(new SelectListItem
            {
                Text = "Select Driver",
                Value = ""
            });

            var drivers = _mapper.Map<IEnumerable<DriverViewModel>>(await _driverRepository.GetAll());

            foreach (var driver in drivers)
            {
                travelViewModel.DriverList.Add(new SelectListItem
                {
                    Text = driver.Name,
                    Value = Convert.ToString(driver.Id)
                });
            }


            travelViewModel.BusList.Add(new SelectListItem
            {
                Text = "Select Bus",
                Value = ""
            });

            var buses = _mapper.Map<IEnumerable<BusViewModel>>(await _busRepository.GetAll());

            foreach (var bus in buses)
            {
                travelViewModel.BusList.Add(new SelectListItem
                {
                    Text = bus.LicensePlate,
                    Value = Convert.ToString(bus.Id)
                });
            }


            travelViewModel.LineRouteList.Add(new SelectListItem
            {
                Text = "Select Line",
                Value = ""
            });

            var lines = _mapper.Map<IEnumerable<LineRouteViewModel>>(await _lineRouteRepository.GetAll());

            foreach (var line in lines)
            {
                travelViewModel.LineRouteList.Add(new SelectListItem
                {
                    Text = Convert.ToString(line.Id),
                    Value = Convert.ToString(line.Id)
                });
            }



            return View(travelViewModel);
        }


        [Route("travel/open-travel")]
        [HttpPost]
        [ClaimsAuthorize("Travel", "Open")]
        public async Task<IActionResult> OpenTravel(TravelViewModel travelViewModel)
        {
            travelViewModel.StartedAt = DateTime.Now;

            if (!ModelState.IsValid)
                return View(travelViewModel);


            await _travelService.OpenTravel(_mapper.Map<Travel>(travelViewModel));

            if (!ValidOperation())
                return View(travelViewModel);

            return RedirectToAction("Index");
        }
    }
}
