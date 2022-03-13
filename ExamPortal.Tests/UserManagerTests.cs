using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPortal.Data.Users;
using ExamPortal.Tests.Mocks;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Xunit;

namespace ExamPortal.Tests
{
    public class UserManagerTests
    {
        private List<User> _users = new List<User>
        {
            new User() { FirstName = "Firs1", LastName = "Last1", Email = "test1@test.pl", Id = "091ce2c9-ee03-4c9f-ac61-7aa707d7e296"},
            new User() { FirstName = "Firs2", LastName = "Last2", Email = "test2@test.pl", Id = "4d1d0e17-1090-4757-ae04-1a89de18fc5d" }
        };

        private UserManager<User> _userManager;

        public UserManagerTests()
        {

            _userManager = IdentityMocks.MockUserManager(_users).Object;
        }

        [Fact]
        public async Task Should_create_user_with_correct_data()
        {
            var newUser = new User()
                {FirstName = "Firs3", LastName = "Last3", Email = "test3@test.pl", Id = Guid.NewGuid().ToString()};
            var password = "zaq1@WSX!";

            var result = await _userManager.CreateAsync(newUser, password);

            Assert.Equal(3, _users.Count);
        }

        [Fact]
        public async Task Should_delete_user()
        {
            var result = await _userManager.DeleteAsync(_users[1]);

            Assert.Equal(1,_users.Count);
        }

    }
}
