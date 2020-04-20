using NUnit.Framework;
using RPG.Nps;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGUnitTest.Nps
{
    class MagePlayerTest
    {
        private MagePlayer MagePlayer;
        private MagePlayer RivalPlayer;

        [SetUp]
        public void Setup()
        {
            MagePlayer = new MagePlayer("Name", 5, 100);
            RivalPlayer = new MagePlayer("Name", 5, 100);
        }

        [TearDown]
        public void Dispose()
        {
            MagePlayer = null;
            RivalPlayer = null;
        }

        [Test]
        public void CheckValidePlayerData()
        {
            Assert.AreEqual(MagePlayer.Health, 100);
            Assert.AreEqual(MagePlayer.Force, 5);
            Assert.AreEqual(MagePlayer.Name, "Name");
        }

        [Test]
        public void AttackTest()
        {
            Assert.AreEqual(MagePlayer.Health, 100);
            Assert.AreEqual(RivalPlayer.Health, 100);
            MagePlayer.Attack(RivalPlayer);
            Assert.AreEqual(MagePlayer.Health, 100);
            Assert.AreEqual(RivalPlayer.Health, 95);
        }

        [Test]
        public void UltaAttackTest()
        {
            Assert.AreEqual(MagePlayer.Health, 100);
            Assert.AreEqual(RivalPlayer.Health, 100);
            MagePlayer.UltaAttack(RivalPlayer);
            Assert.AreEqual(MagePlayer.Health, 100);
            Assert.AreEqual(RivalPlayer.Health, 100);
        }

        [TestCase(100, true)]
        [TestCase(0, false)]
        [TestCase(-100, false)]
        public void CheckHealth(int health, bool isHealthy)
        {
            var magePlayer = new MagePlayer("Name", 5, health);
            Assert.AreEqual(magePlayer.CheckHealth(), isHealthy);
        }
    }
}
