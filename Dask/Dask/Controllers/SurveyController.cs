using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dask.DTO;
using Dask.Models;
using Dask.Services;
using Dask.ViewModels;


namespace Dask.Controllers
{
    public class SurveyController : Controller
    {
        private readonly IManageSurveysService _surveysService;

        public SurveyController(IManageSurveysService surveyService)
        {
            _surveysService = surveyService;
        }   
        public async Task<IActionResult> Index()
        {
            var item = await _surveysService.GetAllSurveys();
            var model = new SurveyViewModel()
            {
                ListOfSurveys = item
            };
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SurveyDTO model)
        {
            await _surveysService.SaveToDB(model);

            return Content("ok"); //TODO
        }
    }
}
