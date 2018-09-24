using ProducerConsoleApp;
using System;
using Xunit;

namespace ProducerxUnitTest
{
    public class UnitTests
    {
        [Fact]
        public void ValidateReturnsTrueForOnlyCharacters()
        {
            var producer = new Producer();
            var expected = true;
            var result = producer.ValidateInput("sgsgsgds");

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ValidateReturnsFalseForEmptyString()
        {
            var producer = new Producer();
            var expected = false;
            var result = producer.ValidateInput(string.Empty);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ValidateReturnsFalseForNumbers()
        {
            var producer = new Producer();
            var expected = false;
            var result = producer.ValidateInput("2345sgsgsgds");
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ValidateReturnsFalseForSpecialCharacters()
        {
            var producer = new Producer();
            var expected = false;
            var result = producer.ValidateInput("afaffa@q&sgsgsgds%");
            Assert.Equal(expected, result);
        }
    }
}
