using Dask.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dask.Models
{
    public class Question : IEntity
    {
        public int Id { get; set; }
        public string QuestionName { get; set; }
        public Survey Survey { get; set; } // It creates SurveyId, init?



    }
}
