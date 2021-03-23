using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dask.Data.EfCore;
using Dask.Models;
using Dask.DTO;

namespace Dask.Services
{
    public class ManageSurveysService : IManageSurveysService
    {
        private readonly EfCoreSurveysRepository _surveysRepository;
        private readonly IMapper mapper;


        public ManageSurveysService(EfCoreSurveysRepository _surveysRepository, IMapper mapper)
        {
            this._surveysRepository = _surveysRepository;
            this.mapper = mapper;
        }

        public async Task<List<Survey>> GetAllSurveys()
        {
            return await _surveysRepository.GetAll();
        }

        public async Task<Survey> SaveToDB(SurveyDTO model)
        {
            Survey s = mapper.Map<Survey>(model);
            await _surveysRepository.Add(s);

            return s;
        }
    }
}
