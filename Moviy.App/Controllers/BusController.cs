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
    public class BusController : BaseController
    {
        private readonly IBusRepository _busRepository;
        private readonly IBusService _busService;
        private readonly IMapper _mapper;

        public BusController(IMapper mapper,
            IBusRepository busRepository,
            IBusService busService,
            INotificator notificator) : base(notificator)
        {
            _mapper = mapper;
            _busRepository = busRepository;
            _busService = busService;
        }

        public async Task<IActionResult> Index()
        {
            var busList = await _busRepository.GetAll();


            return View(_mapper.Map<IEnumerable<BusViewModel>>(busList));
        }

        [Route("bus/details/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var bus = await _busRepository.Get(id);
            if (bus == null)
                return NotFound();

            return View(_mapper.Map<BusViewModel>(bus));
        }

        [Route("bus/create")]
        [ClaimsAuthorize("Bus", "Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("bus/create")]
        [ClaimsAuthorize("Bus", "Create")]
        public async Task<IActionResult> Create(BusViewModel busViewModel)
        {
            if (!ModelState.IsValid)
                return View(busViewModel);

            if (busViewModel.IsActive)
                busViewModel.ActivatedAt = DateTime.Now;
            else
                busViewModel.DeactivatedAt = DateTime.Now;

            var bus = _mapper.Map<Bus>(busViewModel);
            await _busService.Create(bus);

            if (!ValidOperation())
                return View(busViewModel);

            return RedirectToAction("Index");
        }

        [Route("bus/update/{id:guid}")]
        [ClaimsAuthorize("Bus", "Update")]
        public async Task<IActionResult> Update(Guid id)
        {
            var busViewModel = _mapper.Map<BusViewModel>(await _busRepository.Get(id));

            if (busViewModel == null)
                return NotFound();

            return View(busViewModel);
        }


        [Route("bus/update/{id:guid}")]
        [HttpPost]
        [ClaimsAuthorize("Bus", "Update")]
        public async Task<IActionResult> Update(Guid id, BusViewModel busViewModel)
        {


            if (id != busViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(busViewModel);



            if (busViewModel.IsActive && busViewModel.ActivatedAt == null)
            {
                busViewModel.ActivatedAt = DateTime.Now;
                busViewModel.DeactivatedAt = null;

            }
            else if (!busViewModel.IsActive && busViewModel.DeactivatedAt == null)
            {
                busViewModel.DeactivatedAt = DateTime.Now;
                busViewModel.ActivatedAt = null;
            }

            var bus = _mapper.Map<Bus>(busViewModel);
            await _busService.Update(bus);

            if (!ValidOperation())
                return View(busViewModel);

            return RedirectToAction("Index");
        }

        [Route("bus/delete/{id:guid}")]
        [ClaimsAuthorize("Bus", "Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var busViewModel = _mapper.Map<BusViewModel>(await _busRepository.Get(id));

            if (busViewModel == null)
            {
                return NotFound();
            }

            return View(busViewModel);
        }


        [Route("bus/delete/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ClaimsAuthorize("Bus", "Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bus = await _busRepository.Get(id);

            if (bus == null) return NotFound();

            await _busService.Delete(bus.Id);

            if (!ValidOperation())
                return View(_mapper.Map<BusViewModel>(bus));

            return RedirectToAction("Index");
        }


    }
}
