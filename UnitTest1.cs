using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Xunit;

namespace stringCalculator.Tests
{

    [TestClass]
    public class CalculatorTest
    {
        private StringCalculator calculator = new StringCalculator(); 
        //[TestMethod]

        ////[Theory]
        ////[InlineData("", 0)]
        ////[InlineData(1, "1")]
        ////[InlineData("1,2",3)]

        //public void Add_AddsUpToTwoNumbers_WhenStringIsValid(string calculations, int expected)
        //{
        //    var calculator = new StringCalculator();

        //    var result = calculator.Calculate(calculations);


        //    Assert.AreEqual(expected, result);
        //}

        [TestMethod]
        public void Return0GivenEmptyString()
        {
            var result = calculator.Calculate("");
            Assert.AreEqual(0,result);
        }
        [TestMethod]
        public void ReturnNumberGivenWithStringNumber()
        {
            var result = calculator.Calculate("21");
            Assert.AreEqual(21, result);
        }

        [TestMethod]        
        public void ReturnSumGivenWithTwoStringNo()
        {
            var result = calculator.Calculate("1,2");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void ReturnSumDelimitedByMultiplyNo()
        {
            var result = calculator.Calculate("1,2,3");
            Assert.AreEqual(6, result);
        }
        [TestMethod]
        public void ReturnSumdDilimitedByNewline()
        {
            var result = calculator.Calculate("12\n4");
            Assert.AreEqual(16, result);
        }

        [TestMethod]
        public void ThrowExceptionAddNegative()
        {
            //var result = calculator.Calculate("-1,2,3");
            Assert.ThrowsException<ArgumentException>(() => calculator.Calculate("-1,2,3"));
        }
        [TestMethod]
        public void ThrowExceptionGraterThan1000()
        {
            Assert.ThrowsException<ArgumentException>(() => calculator.Calculate("10000"));
        }
    }
}
