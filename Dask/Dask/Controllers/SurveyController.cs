using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dask.Services;


namespace Dask.Controllers
{
    public class SurveyController : Controller
    {
        private readonly IManageSurveysService _surveysService;

        public SurveyController(IManageSurveysService surveyService)
        {
            this._surveysService = surveyService;
        }
        public IActionResult Index()
        {
            var item = _surveysService.GetAllSurveys();


            return View();
        }
    }
}
