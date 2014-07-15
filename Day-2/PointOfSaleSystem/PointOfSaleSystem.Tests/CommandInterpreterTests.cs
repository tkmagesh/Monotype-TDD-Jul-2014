using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PointOfSaleSystem.Tests
{
    [TestClass]
    public class CommandInterpreterTests
    {
        CommandInterpreter interpreter;
        ISaleEventListener saleEventListner;
        bool hasBeginSaleCalled;

        [TestInitialize]
        public void Setup()
        {
            hasBeginSaleCalled = false;
            saleEventListner = new PointOfSaleSystem.Fakes.StubISaleEventListener()
            {
                BeginSale = () =>
                {
                    hasBeginSaleCalled = true;
                }
            };
            interpreter = new CommandInterpreter(saleEventListner);

        }
        [TestMethod]
        public void Should_Be_Able_To_Initiate_A_Sale()
        {
            //Arrange
            var beginSaleCommand = "command:BeginSale";
                     

            //Act
            interpreter.Parse(beginSaleCommand);

            //Assert
            //Assert that the saleEventListener has received a command to commence a sale
            Assert.IsTrue(hasBeginSaleCalled);
        }
    }
}
