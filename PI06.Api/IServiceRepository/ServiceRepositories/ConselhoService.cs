using PI06.Data.IRepository;
using PI06.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PI06.Api.IServiceRepository.ServiceRepositories
{
    public class ConselhoService : ServiceBase<Conselho>, IConselhoService
    {
        private readonly IConselhoRepository _repository;
        public ConselhoService(IConselhoRepository repository) : base(repository)
        {

            _repository = repository;
        }

    }
}
