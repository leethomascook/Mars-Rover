using System.Collections.Generic;
using System.Linq;
using Akqa.MarsRover.Business.Domain;
using Akqa.MarsRover.Business.Services;
using Akqa.MarsRover.Web.Controllers;
using Akqa.MarsRover.Web.Models;
using Moq;
using NUnit.Framework;

namespace Akqa.MarsRover.Test
{
    [TestFixture]
    public class ControllerTests
    {
        private Mock<INavigationService> m_navigationService;

        [TestFixtureSetUp]
        public void Setup()
        {
            m_navigationService = new Mock<INavigationService>();
        }

        [Test]
        public void Test_Rover_Controller_Add_Rover_Persisted()
        {
            RoverController controller = new RoverController(m_navigationService.Object);

            controller.AddRover(1, 2, "N", "M"); 
            
            Assert.IsNotNull(controller.TempData["Rovers"]);
            List<RoverModel> list = (List<RoverModel>) controller.TempData["Rovers"];


            Assert.IsTrue(list.Count == 1);
            RoverModel model = list[0];
            Assert.IsTrue(model.Movements.ToCharArray().First() == 'M'); 
            Assert.IsTrue(model.Rover.GetCurrentPosition().Direction == Direction.North);
            Assert.IsTrue(model.Rover.GetCurrentPosition().X == 1);
            Assert.IsTrue(model.Rover.GetCurrentPosition().Y == 2);
        }

        [Test]
        public void Test_Rover_Controller_Add_Plateau_Persisted()
        {
            RoverController controller = new RoverController(m_navigationService.Object);
            controller.SubmitPlateau(1, 2);
            Assert.IsNotNull(controller.TempData["Plateau"]);
            Plateau plateau = (Plateau)controller.TempData["Plateau"];
            Assert.IsTrue(plateau.Length == 2);
            Assert.IsTrue(plateau.Height == 1);
        }

        /* Should only test one thing really */
        [Test]
        public void Test_Rover_Controller_Start_Exploration_Calls_Navigation_Service_For_Each_Rover_And_Sets_View_Data_Model()
        {
            RoverController controller = new RoverController(m_navigationService.Object);
            List<RoverModel> rovers = new List<RoverModel>();
            RoverModel rover1 = new RoverModel
                                    {
                                        Movements = "M",
                                        Rover = new Rover(new Position() {Direction = Direction.North, X = 0, Y = 0})
                                    };

            RoverModel rover2 = new RoverModel
                                    {
                                        Movements = "M",
                                        Rover = new Rover(new Position() {Direction = Direction.North, X = 1, Y = 0})
                                    };

            rovers.Add(rover1);
            rovers.Add(rover2);

            controller.TempData["Rovers"] = rovers;
            controller.TempData["Plateau"] = new Plateau(1, 2);
            controller.StartExploration();
            m_navigationService.Verify( n => n.ExploreTerrain(It.IsAny<Plateau>(), It.IsAny<Rover>(), It.IsAny<List<Command>>()),Times.Exactly(2));
            Assert.IsNotNull(controller.ViewData.Model);
        }
    }
}
