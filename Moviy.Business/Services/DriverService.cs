using Moviy.Business.Interfaces;
using Moviy.Business.Interfaces.Services;
using Moviy.Business.Models;
using Moviy.Business.Models.Validations;

namespace Moviy.Business.Services
{
    public class DriverService : BaseService, IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly ITravelRepository _travelRepository;

        public DriverService(IDriverRepository driverRepository,
            ITravelRepository travelRepository,
            INotificator notificator) : base(notificator)
        {
            _driverRepository = driverRepository;
            _travelRepository = travelRepository;
        }

        public async Task Create(Driver driver)
        {
            if (!ExecuteValidation(new DriverValidation(), driver)) return;

            //Ja existe Motorista com o mesmo documento ?
            if (_driverRepository.Find(d => d.DriverLicense == driver.DriverLicense).Result.Any())
            {
                Notificar("Já existe um motorista com a carteira de motorista informada");
                return;
            }
            if (_driverRepository.Find(d => d.Document == driver.Document).Result.Any())
            {
                Notificar("Já existe um motorista com a carteira de motorista informada");
                return;
            }

            await _driverRepository.Create(driver);
        }

        public async Task Delete(Guid id)
        {
            if (_travelRepository.Find(d => d.Driver.Id == id).Result.Any())
            {
                Notificar("Este motorista possui viagens cadastradas em seu nome");
                return;
            }
            await _driverRepository.Delete(id);
        }


        public async Task Update(Driver driver)
        {
            if (!ExecuteValidation(new DriverValidation(), driver)) return;

            if (_driverRepository.Find(d => d.DriverLicense == driver.DriverLicense && d.Id != driver.Id).Result.Any())
            {
                Notificar("Já existe um motorista com a carteira de motorista informada");
                return;
            }
            if (_driverRepository.Find(d => d.Document == driver.Document && d.Id != driver.Id).Result.Any())
            {
                Notificar("Já existe um motorista com a carteira de motorista informada");
                return;
            }

            await _driverRepository.Update(driver);
        }

        public void Dispose()
        {
            _driverRepository?.Dispose();
            _travelRepository?.Dispose();
        }
    }
}
