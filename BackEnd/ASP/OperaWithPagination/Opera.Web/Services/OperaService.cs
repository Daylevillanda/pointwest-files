using Operas.Data.Context;
using Operas.Data.Models;
using Operas.Data.Repositories;
using Operas.Web.Models;
using System;
using System.Linq;

namespace Operas.Web.Services
{
    public interface IOperaService
    {
        public PagedResult<OperaEntity> GetOperaPage(int currentPage);
    }

    public class OperaService: GenericService, IOperaService
    {
        private IOperaRepository _operaRepository;
        public OperaService(IOperaRepository operaRepository)
        {
            this._operaRepository = operaRepository;
        }
        public PagedResult<OperaEntity> GetOperaPage(int currentPage)
        {
            return GetPaged<OperaEntity>(_operaRepository.Context.Operas, currentPage, 5);
        }
    }
}
