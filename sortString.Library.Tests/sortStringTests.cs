using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sortString.Library.Tests
{
    [TestFixture]
    public class sortStringTests
    {
        [Test]
        public void sortString_whenEmpty_ReturnsEmpty() 
        {
            //Arrange
            string input = "";

            //Act
            string output = sortString.GetValue(input);

            //Assert
            Assert.AreEqual("Please Enter A String", output);
        }
        [Test]
        public void sortString_checkForSpecialChars()
        {
            //arrange 
            string input = "Why did you come here?";
            string inputTwo = "Why did you come here";
            string inputThree = "Whydidyoucomehere";
            string inputFour = "!!!!a$$%%#^^v";

            //act 
            string output = sortString.GetValue(input);
            string output2 = sortString.GetValue(inputTwo);
            string output3 = sortString.GetValue(inputThree);
            string output4 = sortString.GetValue(inputFour);

            //Assert
            Assert.AreEqual("cddeeehhimooruwyy", output);
            Assert.AreEqual("cddeeehhimooruwyy", output2);
            Assert.AreEqual("cddeeehhimooruwyy", output3);
            Assert.AreEqual("av", output4);
        }
        [Test]
        public void sortString_removeForCaps()
        {
            //arrange
            string input = "AAABBccc";

            //act
            string output = sortString.GetValue(input);

            //assert 
            Assert.AreEqual("aaabbccc", output);
        }
        [Test]
        public void sortString_orderCharacters(
            [Values( "Contrary to popular belief, the pink unicorn flies east." )]
        string input)
        {
            //act
            string output = sortString.GetValue(input);

            //assert
            Assert.AreEqual("aaabcceeeeeffhiiiiklllnnnnooooppprrrrssttttuuy", output);
            
      
        }
    }
}
