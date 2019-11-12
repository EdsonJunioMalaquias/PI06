﻿using PI06.Data.IRepository;
using PI06.Models.Entity;
using System.Collections.Generic;

namespace PI06.Api.IServiceRepository.ServiceRepositories
{
    public class PacienteService : ServiceBase<Paciente>, IPacienteService
    {
        private readonly IPacienteRepository _repository;

        public PacienteService(IPacienteRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Paciente GetByCPFIncludingProperties(string cpf)
        {
            return _repository.GetByCPFIncludingProperties(cpf);
        }

        public Paciente GetByIdIncludingProperties(int id)
        {
            return _repository.GetByIdIncludingProperties(id);
        }
        public IEnumerable<Paciente> GetAllIncludingProperties()
        {
            return _repository.GetAllIncludingProperties();
        }
    }
}
