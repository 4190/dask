using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dask.DTO;
using Dask.Models;

namespace Dask.Services
{
    public interface IManageSurveysService
    {
        public Task<List<Survey>> GetAllSurveys();
        public Task<Survey> SaveToDB(SurveyDTO model);
    }
}
