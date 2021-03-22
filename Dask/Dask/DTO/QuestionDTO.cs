using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Dask.Data;
using Dask.Models;

namespace Dask.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Question is required!")]
        [StringLength(1000,ErrorMessage ="Question can be 1000 characters long!")]        
        public string QuestionName { get; set; }
        public Survey Survey { get; set; } // It creates SurveyId, init?
        public string SurveyId { get; set; } 

    }
}
