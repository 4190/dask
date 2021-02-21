using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dask.Data.EfCore;
using Dask.Models;

namespace Dask.Services
{
    public class ManageSurveysService : IManageSurveysService
    {
        private readonly EfCoreSurveysRepository _surveysRepository;

        public ManageSurveysService(EfCoreSurveysRepository _surveysRepository)
        {
            this._surveysRepository = _surveysRepository;
        }

        public async Task<List<Survey>> GetAllSurveys()
        {
            return await _surveysRepository.GetAll();
        }

    }
}
