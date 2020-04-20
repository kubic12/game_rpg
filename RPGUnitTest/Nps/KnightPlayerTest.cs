using NUnit.Framework;
using RPG.Nps;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGUnitTest.Nps
{
    class KnightPlayerTest
    {
        private KnightPlayer KnightPlayer;
        private KnightPlayer RivalPlayer;

        [SetUp]
        public void Setup()
        {
            KnightPlayer = new KnightPlayer("Name", 5, 100);
            RivalPlayer = new KnightPlayer("Name", 5, 100);
        }

        [TearDown]
        public void Dispose()
        {
            KnightPlayer = null;
            RivalPlayer = null;
        }

        [Test]
        public void CheckValidePlayerData()
        {
            Assert.AreEqual(KnightPlayer.Health, 100);
            Assert.AreEqual(KnightPlayer.Force, 5);
            Assert.AreEqual(KnightPlayer.Name, "Name");
        }

        [Test]
        public void AttackTest()
        {
            Assert.AreEqual(KnightPlayer.Health, 100);
            Assert.AreEqual(RivalPlayer.Health, 100);
            KnightPlayer.Attack(RivalPlayer);
            Assert.AreEqual(KnightPlayer.Health, 100);
            Assert.AreEqual(RivalPlayer.Health, 95);
        }

        [Test]
        public void UltaAttackTest()
        {
            Assert.AreEqual(KnightPlayer.Health, 100);
            Assert.AreEqual(RivalPlayer.Health, 100);
            KnightPlayer.UltaAttack(RivalPlayer);
            Assert.AreEqual(KnightPlayer.Health, 100);
            Assert.AreEqual(RivalPlayer.Health, 93.5);
            KnightPlayer.Attack(RivalPlayer);
            Assert.AreEqual(KnightPlayer.Health, 100);
            Assert.AreEqual(RivalPlayer.Health, 88.5);
        }

        [TestCase(100, true)]
        [TestCase(0, false)]
        [TestCase(-100, false)]
        public void CheckHealth(int health, bool isHealthy)
        {
            var magePlayer = new KnightPlayer("Name", 5, health);
            Assert.AreEqual(magePlayer.CheckHealth(), isHealthy);
        }
    }
}
