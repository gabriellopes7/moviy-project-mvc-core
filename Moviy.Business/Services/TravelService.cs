using Moviy.Business.Interfaces;
using Moviy.Business.Interfaces.Services;
using Moviy.Business.Models;

namespace Moviy.Business.Services
{
    public class TravelService : BaseService, ITravelService
    {
        private readonly ITravelRepository _travelRepository;

        public TravelService(ITravelRepository travelRepository
            , INotificator notificator) : base(notificator)

        {
            _travelRepository = travelRepository;
        }

        public async Task OpenTravel(Travel travel)
        {
            if (_travelRepository.Find(t => t.DriverId == travel.DriverId && t.FinishedAt == null).Result.Any())
            {
                Notificar("O motorista informado possui uma viagem em aberto");
                return;
            }
            if (_travelRepository.Find(t => t.BusId == travel.BusId && t.FinishedAt == null).Result.Any())
            {
                Notificar("O veículo informado possui uma viagem em aberto");
                return;
            }

            await _travelRepository.Create(travel);
        }

        public async Task CloseTravel(Guid id)
        {
            if (_travelRepository.Find(t => t.Id == id && t.FinishedAt != null).Result.Any())
            {
                Notificar("Esta viagem já foi encerrada");
                return;
            }

            var travel = await _travelRepository.Get(id);

            travel.FinishedAt = DateTime.Now;

            await _travelRepository.Update(travel);
        }

        public void Dispose()
        {
            _travelRepository?.Dispose();
        }
    }
}
