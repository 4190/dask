using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dask.Services;
using Dask.Models;
using Dask.ViewModels;


namespace Dask.Controllers
{
    public class SurveyController : Controller
    {
        private readonly IManageSurveysService _surveysService;

        public SurveyController(IManageSurveysService surveyService)
        {
            this._surveysService = surveyService;
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

    }
}
