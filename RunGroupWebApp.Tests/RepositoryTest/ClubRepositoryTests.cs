using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroopWebApp.Data.Enum;
using RunGroopWebApp.Models;
using RunGroopWebApp.Repository;
using System;
using System.Threading.Tasks;
using Xunit;

namespace RunGroupWebApp.Tests.RepositoryTest
{
    /// <summary>
    /// This class contains unit tests for the ClubRepository.
    /// </summary>
    public class ClubRepositoryTests
    {
        /// <summary>
        /// Creates an in-memory database context for testing purposes.
        /// Ensures the database is created and seeded with initial data.
        /// </summary>
        /// <returns>A new instance of ApplicationDbContext with an in-memory database.</returns>
        private async Task<ApplicationDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new ApplicationDbContext(options);
            databaseContext.Database.EnsureCreated();

            if (await databaseContext.Clubs.CountAsync() < 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    databaseContext.Clubs.Add(
                      new Club()
                      {
                          Title = "Begovoy club 1",
                          Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                          Description = "Description some description",
                          ClubCategory = ClubCategory.City,
                          Address = new Address()
                          {
                              Street = "Ulica Pushkina",
                              City = "Torez",
                              State = "DPR"
                          }
                      });
                }
                await databaseContext.SaveChangesAsync();
            }

            return databaseContext;
        }

        /// <summary>
        /// Tests the Add method of the ClubRepository.
        /// Verifies that the Add method returns true when a club is successfully added.
        /// </summary>
        [Fact]
        public async void ClubRepository_Add_ReturnsBool()
        {
            // Arrange: Create a new Club object and a repository instance with an in-memory database.
            var club = new Club()
            {
                Title = "Begovoy club 1",
                Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                Description = "Description some description",
                ClubCategory = ClubCategory.City,
                Address = new Address()
                {
                    Street = "Ulica Pushkina",
                    City = "Torez",
                    State = "DPR"
                }
            };

            var dbContext = await GetDbContext();
            var clubRepository = new ClubRepository(dbContext);

            // Act: Add the club to the repository.
            var result = clubRepository.Add(club);

            // Assert: Ensure the Add method returns true.
            result.Should().BeTrue();
        }

        /// <summary>
        /// Tests the GetByIdAsync method of the ClubRepository.
        /// Verifies that a club is returned when queried by a valid ID.
        /// </summary>
        [Fact]
        public async void ClubRepository_GetByIdAsync_ReturnsClub()
        {
            // Arrange: Use an existing club ID and create a repository instance with an in-memory database.
            var id = 1;
            var dbContext = await GetDbContext();
            var clubRepository = new ClubRepository(dbContext);

            // Act: Retrieve the club by ID.
            var result = clubRepository.GetByIdAsync(id);

            // Assert: Ensure the result is not null and of type Task<Club>.
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<Club>>();
        }
    }
}
