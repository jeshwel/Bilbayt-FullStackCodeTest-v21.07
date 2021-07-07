using AutoMapper;
using FakeItEasy;
using FullStackCodeTest.BLL.Contracts;
using FullStackCodeTest.BLL.Services;
using FullStackCodeTest.Data.Contracts;
using FullStackCodeTest.Data.Entities;
using NUnit.Framework;
using System;

namespace FullStackCodeTest.BLL.UnitTests.Services
{
    public class UserServiceTests
    {
        private IAuthenticationService authService;
        private IMapper mapper;
        private IUserRepository repository;
        private IUserService userService;
        [SetUp]
        public void Setup()
        {
            repository = A.Fake<IUserRepository>();
            authService = A.Fake<IAuthenticationService>();
            mapper = A.Fake<IMapper>();
            userService = new UserService(authService, repository, mapper);
        }

        [Test]
        public void ShouldErrorWhenNonRegisteredUserTriesLogin()
        {
            A.CallTo(() => repository.GetByName(A<string>.Ignored))
               .Returns(null);
            Exception ex = Assert.Throws<Exception>(() => userService.Login("SomeUser", "SomePassword"));
            Assert.That(ex.Message, Is.EqualTo("Sorry, you are not a registered user."));
        }

        [Test]
        public void ShouldErrorWhenEnteredPasswordIsIncorrect()
        {
            var mockUser = new User { UserName = "Jes", Password = "Jes" };
            A.CallTo(() => repository.GetByName(A<string>.Ignored))
               .Returns(mockUser);
            Exception ex = Assert.Throws<Exception>(() => userService.Login("Jes", "SomePassword"));
            Assert.That(ex.Message, Is.EqualTo("Oops, password entered is incorrect."));
        }

        [Test]
        public void ShouldGenerateJwtForSuccessfulLogin()
        {
            var mockUser = new User { UserName = "Jes", Password = "Jes" };
            A.CallTo(() => repository.GetByName(A<string>.Ignored))
               .Returns(mockUser);
            var jwt= userService.Login("Jes", "Jes");
            A.CallTo(() => authService.GenerateSecurityToken(A<string>.Ignored)).MustHaveHappenedOnceExactly();
        }
    }
}