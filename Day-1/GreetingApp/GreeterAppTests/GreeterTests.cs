using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreetingApp;

namespace GreeterAppTests
{
    [TestClass]
    public class GreeterTests
    {
        [TestMethod]
        public void Should_Greet_The_User_Good_Evening_During_Evening()
        {
            //Arrange
            var name = "Magesh";
            //var timeServiceForEvening = new FakeTimeServiceReturningEveningTime();
            var greeter = new GreeterV2(() => new DateTime(2014,7,14,15,0,0));
            var expectedResult = string.Format("Hello {0}, Good Evening!!",name);

            //Act
            var greetMsg = greeter.Greet(name);

            //Assert
            Assert.AreEqual(expectedResult, greetMsg);
        }

        [TestMethod]
        public void Should_Greet_The_User_Good_Day_During_Day()
        {
            //Arrange
            var name = "Magesh";
            var timeServiceForMorning = new FakeTimeServiceReturingMorningTime();
            var greeter = new Greeter(timeServiceForMorning);
            var expectedResult = string.Format("Hello {0}, Have a nice day!", name);

            //Act
            var greetMsg = greeter.Greet(name);

            //Assert
            Assert.AreEqual(expectedResult, greetMsg);
        }
    }

    public class FakeTimeServiceReturingMorningTime : ITimeService
    {
        public DateTime GetCurrentTime()
        {
            return new DateTime(2014, 7, 14, 9, 0, 0);
        }
    }

    public class FakeTimeServiceReturningEveningTime : ITimeService
    {
        public DateTime GetCurrentTime()
        {
            return new DateTime(2014, 7, 14, 17, 0, 0);
        }
    }


}
