using Moviy.Business.Interfaces;
using Moviy.Business.Interfaces.Services;
using Moviy.Business.Models;
using Moviy.Business.Models.Validations;

namespace Moviy.Business.Services
{
    public class BusService : BaseService, IBusService
    {
        private readonly IBusRepository _busRepository;
        private readonly ITravelRepository _travelRepository;

        public BusService(IBusRepository busRepository,
            ITravelRepository travelRepository,
            INotificator notificator) : base(notificator)
        {
            _busRepository = busRepository;
            _travelRepository = travelRepository;
        }
        public async Task Create(Bus bus)
        {
            if (!ExecuteValidation(new BusValidation(), bus)) return;

            if (_busRepository.Find(b => b.BusNumber == bus.BusNumber).Result.Any())
            {
                Notificar("Já existe um veículo com este número");
                return;
            }
            if (_busRepository.Find(b => b.LicensePlate == bus.LicensePlate).Result.Any())
            {
                Notificar("Já existe um veículo com esta placa");
                return;
            }

            await _busRepository.Create(bus);

        }

        public async Task Delete(Guid id)
        {
            if (_travelRepository.Find(b => b.BusId == id).Result.Any())
            {
                Notificar("Existem viagens cadastradas para este veículo");
                return;
            }

            await _travelRepository.Delete(id);

        }

        public async Task Update(Bus bus)
        {
            if (!ExecuteValidation(new BusValidation(), bus)) return;

            if (_busRepository.Find(b => b.BusNumber == bus.BusNumber && b.Id != bus.Id).Result.Any())
            {
                Notificar("Já existe um veículo com este número");
                return;
            }
            if (_busRepository.Find(b => b.LicensePlate == bus.LicensePlate && b.Id != bus.Id).Result.Any())
            {
                Notificar("Já existe um veículo com esta placa");
                return;
            }

            await _busRepository.Update(bus);
        }



        public void Dispose()
        {
            _busRepository?.Dispose();
            _travelRepository?.Dispose();
        }
    }
}
