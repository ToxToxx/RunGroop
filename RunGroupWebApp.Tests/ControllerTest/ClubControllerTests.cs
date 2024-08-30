using FakeItEasy;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Services;
using RunGroopWebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RunGroopWebApp.Models;
using Microsoft.AspNetCore.Http;
using RunGroopWebApp.Controllers;

namespace RunGroupWebApp.Tests.ControllerTest
{
    public class ClubControllerTests
    {
        private ClubController _clubController;
        private IClubRepository _clubRepository;
        private IPhotoService _photoService;
        private IHttpContextAccessor _httpContexAccessor;

        public ClubControllerTests() 
        {
            //Dependencies
            _clubRepository = A.Fake<IClubRepository>();
            _photoService = A.Fake<IPhotoService>();
            _httpContexAccessor = A.Fake<HttpContextAccessor>();

            ///SUT
            _clubController = new ClubController(_clubRepository, _photoService);
        }

        [Fact]
        public void ClubController_Index_ReturnsSuccess()
        {
            //Arrange - what needed to bring in
            var clubs = A.Fake<IEnumerable<Club>>();
            A.CallTo(() => _clubRepository.GetAll()).Returns(clubs);

            //Act

            //Assert
        }
        
    }
}
