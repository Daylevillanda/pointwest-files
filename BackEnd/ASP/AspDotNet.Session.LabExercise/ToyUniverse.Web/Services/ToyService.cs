using ToyUniverse.Data.Models;
using ToyUniverse.Data.Repositories;
using ToyUniverse.Web.Models;

namespace ToyUniverse.Web.Services
{
    public interface IToyService
    {
        public PagedResult<Toy> GetOperaPage(int currentPage);
    }

    public class ToyService : GenericService, IToyService
    {
        private IToyRepository _toyRepository;
        public ToyService(IToyRepository toyRepository)
        {
            this._toyRepository = toyRepository;
        }
        public PagedResult<Toy> GetOperaPage(int currentPage)
        {
            return GetPaged<Toy>(_toyRepository.Context.Toys, currentPage, 5);
        }
    }
}
