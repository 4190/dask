using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dask.Data.EfCore;
using Dask.Models;

namespace Dask.Services
{
    public class ManageQuestionService:IManageQuestionService
    {
        private readonly EfCoreQuestionRepository _questionsRepository;
        public ManageQuestionService(EfCoreQuestionRepository _questionRepository)
        {
            this._questionsRepository = _questionRepository;
        }

        //yet empty 
    }
}
