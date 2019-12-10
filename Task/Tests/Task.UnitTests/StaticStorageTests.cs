using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Task.CommonTypes.Interfaces;
using Task.CommonTypes.Models;
using Task.ProcessingLogic;

namespace Task.UnitTests
{
    [TestClass]
    public class StaticStorageTests
    {

        private readonly Mock<IRepository<IMoneyMovement>> mockMoneyMovement;
        private readonly List<MoneyMovement> defaultStorage;
        private readonly MoneyMovementRepositoryAggregator<IMoneyMovement> aggregator;

        public StaticStorageTests()
        {
            mockMoneyMovement = new Mock<IRepository<IMoneyMovement>>();
            defaultStorage = new List<MoneyMovement>
            {
                new MoneyMovement
                {
                    Id = 1,
                    Amount = 0,
                    Currency = CommonTypes.Enums.Currency.BYN,
                    Date = DateTime.Now,
                    Direction = CommonTypes.Enums.Direction.IN,
                    UserId = 1
                },
                new MoneyMovement
                {
                    Id = 2,
                    Amount = 1,
                    Currency = CommonTypes.Enums.Currency.BYN,
                    Date = DateTime.Now,
                    Direction = CommonTypes.Enums.Direction.IN,
                    UserId = 1
                },
                new MoneyMovement
                {
                    Id = 3,
                    Amount = 2,
                    Currency = CommonTypes.Enums.Currency.BYN,
                    Date = DateTime.Now,
                    Direction = CommonTypes.Enums.Direction.OUT,
                    UserId = 1
                }
            };

            aggregator = new MoneyMovementRepositoryAggregator<IMoneyMovement>();
        }

        [TestMethod]
        public void Test_SHOULD_Return_All_MoneyMovents()
        {
            #region Arrange
            mockMoneyMovement.Setup(i => i.Get()).Returns(defaultStorage);
            #endregion

            #region Act
            var result = aggregator.Get()?.ToList();
            #endregion

            #region Assert
            CollectionAssert.AreEqual(defaultStorage, result);
            #endregion

        }
    }
}
