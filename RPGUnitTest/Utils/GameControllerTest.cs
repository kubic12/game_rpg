using NUnit.Framework;
using RPG.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGUnitTest.Utils
{
    class GameControllerTest
    {
        [Test]
        public void PlayScenarioTest()
        {
            // Generate players.
            GameController.GeneratePlayers(4);

            // Verify that was generated 4 players.
            Assert.AreEqual(GameController.GetPlayers().Count, 4);

            // Start game.
            GameController.StartRound();

            // Verify that left only one winner.
            Assert.AreEqual(GameController.GetPlayers().Count, 1);
            Assert.AreEqual(GameController.GetPlayers()[0], GameController.GetWinner());
        }
    }
}
