using FakeItEasy;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunGroupWebApp.Tests.ControllerTest
{
    public class ClubControllerTests
    {
        private IClubRepository _clubRepository;
        public ClubControllerTests() 
        {
            _clubRepository = A.Fake<IClubRepository>();
        }
        
    }
}
