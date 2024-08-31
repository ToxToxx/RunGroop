using FakeItEasy;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Services;
using RunGroopWebApp.Repository;
using RunGroopWebApp.Models;
using Microsoft.AspNetCore.Http;
using RunGroopWebApp.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace RunGroupWebApp.Tests.ControllerTest
{
    /// <summary>
    /// This class contains unit tests for the ClubController.
    /// </summary>
    public class ClubControllerTests
    {
        private readonly ClubController _clubController;
        private readonly IClubRepository _clubRepository;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the ClubControllerTests class.
        /// Sets up the test dependencies using FakeItEasy.
        /// </summary>
        public ClubControllerTests()
        {
            // Dependencies setup
            _clubRepository = A.Fake<IClubRepository>();
            _photoService = A.Fake<IPhotoService>();
            _httpContextAccessor = A.Fake<IHttpContextAccessor>();

            // System Under Test (SUT)
            _clubController = new ClubController(_clubRepository, _photoService);
        }

        /// <summary>
        /// Tests the Index action of the ClubController.
        /// Verifies that the action returns a successful result.
        /// </summary>
        [Fact]
        public void ClubController_Index_ReturnsSuccess()
        {
            // Arrange: Create a fake collection of Club objects and set up the repository to return it.
            var clubs = A.Fake<IEnumerable<Club>>();
            A.CallTo(() => _clubRepository.GetAll()).Returns(clubs);

            // Act: Invoke the Index action.
            var result = _clubController.Index();

            // Assert: Ensure the result is of type Task<IActionResult>.
            result.Should().BeOfType<Task<IActionResult>>();
        }

        /// <summary>
        /// Tests the DetailClub action of the ClubController.
        /// Verifies that the action returns a successful result when given a valid club ID.
        /// </summary>
        [Fact]
        public void ClubController_DetailClub_ReturnsSuccess()
        {
            // Arrange: Create a fake Club object and set up the repository to return it when queried by ID.
            var id = 1;
            var club = A.Fake<Club>();
            A.CallTo(() => _clubRepository.GetByIdAsync(id)).Returns(club);

            // Act: Invoke the DetailClub action with the given ID and a fake club name.
            var result = _clubController.DetailClub(id, club.ToString());

            // Assert: Ensure the result is of type Task<IActionResult>.
            result.Should().BeOfType<Task<IActionResult>>();
        }
    }
}
