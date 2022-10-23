using Moviy.Business.Interfaces;
using Moviy.Business.Interfaces.Services;
using Moviy.Business.Models;

namespace Moviy.Business.Services
{
    public class LineRouteService : BaseService, ILineRouteService
    {
        private readonly ILineRouteRepository _lineRouteRepository;

        public LineRouteService(ILineRouteRepository lineRouteRepository
            , INotificator notificator) : base(notificator)
        {
            _lineRouteRepository = lineRouteRepository;
        }

        public async Task Create(LineRoute lineRoute)
        {
            await _lineRouteRepository.Create(lineRoute);
        }

        public async Task Delete(Guid id)
        {
            await _lineRouteRepository.Delete(id);
        }

        public async Task Update(LineRoute lineRoute)
        {
            await _lineRouteRepository.Update(lineRoute);
        }

        public void Dispose()
        {
            _lineRouteRepository?.Dispose();
        }
    }
}
