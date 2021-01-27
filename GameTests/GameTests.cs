using System;
using MemoryGameLogic;
using Shouldly;
using Xunit;

namespace GameTests
{
    public class GameTests
    {
        [Fact]
        public void StartNewGame_CheckBoardSize_CheckIfSizeCorrect()
        {
            // Arrange
            const int boardSize = 6;
            var game = new Game();

            // Act
            game.StartNewGame(boardSize);
            

            // Assert
            game.Board.Length.ShouldBe((int) Math.Pow(boardSize, 2));
        }
    }
}