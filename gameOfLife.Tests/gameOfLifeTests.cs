using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gameOfLife.Library;

namespace gameOfLife.Tests
{
    [TestFixture]
    public class gameOfLifeTests
    {
        [Test]
        public void gameOfLife_generateBoard_or2DArray()
        {
            //arrange
            int cols = 5;
            int rows = 5;

            //act
            int[,] actual = gameOfLife.Library.gameOfLife.createBoard(cols, rows);
            int[,] expected = new int[cols, rows];
            //assert
            Assert.AreEqual(expected.GetLength(0), actual.GetLength(0));
            Assert.AreEqual(expected.GetLength(1), actual.GetLength(1));
        }
        [Test]
        public void gameOfLife_populateBoard()
        {
            //arrange 
            int[,] board = gameOfLife.Library.gameOfLife.createBoard(0, 0);
            //act 
            bool isPopulated = gameOfLife.Library.gameOfLife.checkPopulatation(board);
            //assert
            Assert.AreEqual(true, isPopulated);
        }
        [Test]
        public void gameOfLife_countLiveNeighbors()
        {
            int[,] vs = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
            int liveNeighborsCount = gameOfLife.Library.gameOfLife.countNeighbors(vs, 2, 1);

            Assert.AreEqual(5, liveNeighborsCount);
        }
        [Test]
        public void gameOfLife_changeState()
        {
            int [,] board = { { 0, 1, 0 }, { 0, 1, 1 }, { 0, 0, 0 } };
            int col = 1;
            int row = 1;
            int totalNeighbors = gameOfLife.Library.gameOfLife.countNeighbors(board, col, row);
            int newState = gameOfLife.Library.gameOfLife.changeState(totalNeighbors);

            Assert.AreEqual(1, newState);
        }
        [Test]
        public void gameOfLife_createNextGeneration()
        {

        }
 

    }
}
