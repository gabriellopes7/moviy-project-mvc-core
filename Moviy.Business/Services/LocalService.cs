using Moviy.Business.Interfaces;
using Moviy.Business.Interfaces.Services;
using Moviy.Business.Models;

namespace Moviy.Business.Services
{
    public class LocalService : BaseService, ILocalService
    {
        private readonly ILocalRepository _localRepository;

        public LocalService(ILocalRepository localRepository
            , INotificator notificator) : base(notificator)
        {
            _localRepository = localRepository;
        }

        public async Task Create(Local local)
        {
            await _localRepository.Create(local);
        }

        public async Task Delete(Guid id)
        {
            await _localRepository.Delete(id);
        }

        public void Dispose()
        {
            _localRepository?.Dispose();
        }
    }
}
