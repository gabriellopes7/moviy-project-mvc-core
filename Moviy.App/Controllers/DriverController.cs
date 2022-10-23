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
    public class DriverController : BaseController
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;
        private readonly IDriverService _driverService;


        public DriverController(IMapper mapper, IDriverRepository driverRepository,
            IDriverService driverService,
            INotificator notificator) : base(notificator)
        {
            _mapper = mapper;
            _driverRepository = driverRepository;
            _driverService = driverService;
        }

        [Route("drivers")]
        public async Task<IActionResult> Index()
        {
            var driverList = await _driverRepository.GetAll();

            return View(_mapper.Map<IEnumerable<DriverViewModel>>(driverList));
        }

        [Route("driver/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var driver = await _driverRepository.Get(id);

            if (driver == null)
                return NotFound();

            return View(_mapper.Map<DriverViewModel>(driver));
        }

        [Route("driver/create")]
        [ClaimsAuthorize("Driver", "Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("driver/create")]
        [HttpPost]
        [ClaimsAuthorize("Driver", "Create")]
        public async Task<IActionResult> Create(DriverViewModel driverViewModel)
        {
            if (!ModelState.IsValid)
                return View(driverViewModel);

            //Para adicionar imagem pro motorista
            var imgPrefixo = Guid.NewGuid() + "_";
            if (!await UploadArquivo(driverViewModel.ImageUpload, imgPrefixo))
            {
                return View(driverViewModel);
            }

            //Passando o nome do arquivo para o banco
            driverViewModel.Image = imgPrefixo + driverViewModel.ImageUpload.FileName;

            if (driverViewModel.IsActive)
                driverViewModel.ActivatedAt = DateTime.Now;
            else
                driverViewModel.DeactivatedAt = DateTime.Now;

            var driver = _mapper.Map<Driver>(driverViewModel);
            await _driverService.Create(driver);

            if (!ValidOperation())
                return View(driverViewModel);

            return RedirectToAction("Index");
        }

        [Route("driver/update/{id:guid}")]
        [ClaimsAuthorize("Driver", "Update")]
        public async Task<IActionResult> Update(Guid id)
        {
            var driverViewModel = _mapper.Map<DriverViewModel>(await _driverRepository.Get(id));





            if (driverViewModel == null)
                return NotFound();

            return View(driverViewModel);


        }

        [Route("driver/update/{id:guid}")]
        [HttpPost]
        [ClaimsAuthorize("Driver", "Update")]
        public async Task<IActionResult> Update(Guid id, DriverViewModel driverViewModel)
        {
            if (id != driverViewModel.Id)
                return BadRequest();

            var driverAtualizacao = await _driverRepository.Get(id);

            driverViewModel.Image = driverAtualizacao.Image;


            if (driverViewModel.ImageUpload != null)
            {
                //Para adicionar imagem pro motorista
                var imgPrefixo = Guid.NewGuid() + "_";

                if (!await UploadArquivo(driverViewModel.ImageUpload, imgPrefixo))
                {
                    return View(driverViewModel);
                }

                //Passando o nome do arquivo para o banco
                driverAtualizacao.Image = imgPrefixo + driverViewModel.ImageUpload.FileName;

            }

            if (driverViewModel.IsActive && driverViewModel.ActivatedAt == null)
            {
                driverViewModel.ActivatedAt = DateTime.Now;
                driverViewModel.DeactivatedAt = null;

            }
            else if (!driverViewModel.IsActive && driverViewModel.DeactivatedAt == null)
            {
                driverViewModel.DeactivatedAt = DateTime.Now;
                driverViewModel.ActivatedAt = null;
            }

            driverAtualizacao.Name = driverViewModel.Name;
            driverAtualizacao.DriverLicense = driverViewModel.DriverLicense;
            driverAtualizacao.BirthDate = driverViewModel.BirthDate;
            driverAtualizacao.IsActive = driverViewModel.IsActive;
            driverAtualizacao.ActivatedAt = driverViewModel.ActivatedAt;
            driverAtualizacao.DeactivatedAt = driverViewModel.DeactivatedAt;


            var driver = _mapper.Map<Driver>(driverAtualizacao);
            await _driverService.Update(driver);

            if (!ValidOperation())
                return View(driverViewModel);

            return RedirectToAction("Index");
        }

        [Route("driver/delete/{id:guid}")]
        [ClaimsAuthorize("Driver", "Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var driverViewModel = _mapper.Map<DriverViewModel>(await _driverRepository.Get(id));

            if (driverViewModel == null)
                return NotFound();



            return View(driverViewModel);
        }


        [Route("driver/delete/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ClaimsAuthorize("Driver", "Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var driver = await _driverRepository.Get(id);


            if (driver == null)
                return NotFound();

            await _driverService.Delete(id);

            if (!ValidOperation())
                return View(_mapper.Map<DriverViewModel>(driver));

            return RedirectToAction("Index");
        }


        private async Task<bool> UploadArquivo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo.Length <= 0)
                return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imgPrefixo + arquivo.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "A file with the same name already exists");
                return false;
            }


            //Metodo de gravação em disco
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }

    }
}
