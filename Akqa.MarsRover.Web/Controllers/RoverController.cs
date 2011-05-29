using System.Collections.Generic;
using System.Web.Mvc;
using Akqa.MarsRover.Business.Domain;
using Akqa.MarsRover.Business.Parsers;
using Akqa.MarsRover.Business.Services;
using Akqa.MarsRover.Web.Models;

namespace Akqa.MarsRover.Web.Controllers
{
    public class RoverController : Controller
    {
        private readonly INavigationService m_navigationService;

        public RoverController(INavigationService navigationService)
        {
            m_navigationService = navigationService;
        }

        public ActionResult Index()
        {
            return View();
        }
        /* I assumed that you were more interested in how I structured the main logic, than the view Logic. Hence:
        *  Needs lots of validation, null reference checking ect, but as I only have one hour lets just keep it very simple.  
        * Also, I would not normally use TempData, but it is a versy simple abstraction that saves me having to wire up databses in a short space of time. */

        public ActionResult SubmitPlateau(int height, int width)
        {
            TempData["Plateau"] = new Plateau(width, height);
            ViewData.Model = new List<RoverModel>();
            return View();
        }

        public ActionResult AddRover(int x, int y, string direction, string movements)
        {
            var rovers = new List<RoverModel>();

            if(TempData["Rovers"] != null)
            {
                rovers = TempData["Rovers"] as List<RoverModel>;
            }

            var position = new Position {X = x, Y = y, Direction = DirectionParser.Parse(direction)};
            var rover = new Rover(position);
            if (rovers != null)
            {
                rovers.Add(new RoverModel {Movements = movements, Rover = rover});

                TempData["Rovers"] = ViewData.Model = rovers;
            }
          
            return new ViewResult {ViewName = "SubmitPlateau", ViewData = ViewData};
        }

        public ActionResult StartExploration()
        {
            var results = new List<Position>();
            foreach(RoverModel model in (List<RoverModel>)TempData["Rovers"])
            {
                results.Add(m_navigationService.ExploreTerrain((Plateau) TempData["Plateau"], model.Rover, CommandParser.Parse(model.Movements)));
            }
            ViewData.Model = results;
            return View();
        }
    }
}
