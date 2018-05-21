using Data.DBModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Repository.Interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using WebAPI.Controllers;
using Xunit;
using static Repository.DatabaseContex;

namespace xUnitTest
{
    public class HobbyUnitTest
    {

        [Fact]
        public void ShouldReturnNewHobby() {
            List<Hobby> hobbyList = new List<Hobby>() {
                new Hobby() {
                    Id = 1,AdministratorId = 1,Color = "#123123",Description="Lorem ipsum", Logo = "test.png", Name = "Test"
                },
                new Hobby() {
                    Id = 2,AdministratorId = 1,Color = "#123432",Description="Lorem ipsum 2", Logo = "test.png", Name = "Test 2"
                },
                new Hobby() {
                    Id = 23,AdministratorId = 3,Color = "#fff",Description="Lorem ipsum 3", Logo = "test.png", Name = "Test 3"
                },
            };

            var hobbyRepository = new Mock<IHobbyRepository>();
            hobbyRepository.Setup(x => x.GetAll()).Returns(hobbyList.AsQueryable());
            var hobbyService = new HobbyService(hobbyRepository.Object);
            var hobbyController = new HobbyController(hobbyService);

            List<Hobby> results = hobbyController.GetAll();

            Assert.Equal(hobbyList, results);
        }
    }
}
