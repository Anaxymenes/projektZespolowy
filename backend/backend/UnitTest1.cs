using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using AutoMapper;
using System.Linq;
using Data.DBModels;
using Data.DTO;
using Repository.Interfaces;
using Services.Services;
using WebApi.Controllers;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldReturnAccountDTOList(){
            var accountList = new List<Account>() {
                new Account {
                    Username = "Tester", Id = 1, Email = "tester@onlyForTest.pl", Password = "T3st3r" },
                new Account {
                    Username = "Tester2", Id = 2, Email = "tester2@onlyForTest.pl", Password = "T3st3r" }
            };

            var expectedAccountList = new List<AccountDTO>() {
                new AccountDTO {
                    Username = "Tester", Id = 1, Email = "tester@onlyForTest.pl" },
                new AccountDTO {
                    Username = "Tester2", Id = 2, Email = "tester2@onlyForTest.pl" }
            };

            var _accountRepository = new Mock<IRepository<Account>>();
            _accountRepository.Setup(x => x.GetAll()).Returns(accountList.AsQueryable());
            var _accountService = new AccountService(_accountRepository.Object);
            var _accountController = new AccountController(_accountService);

            //act
            List<AccountDTO> result = _accountController.GetAll();

            //assert
            Assert.Equal<AccountDTO>(expectedAccountList, result);
        }
    }
}
