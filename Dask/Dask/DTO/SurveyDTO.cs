using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using Dask.Data;
using Dask.Models;

namespace Dask.DTO
{
    public class SurveyDTO : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required!")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)] // 20 should be enough (?)
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required!")]
        [StringLength(1000, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)] // 1000 seems right
        public string Description { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
