using NUnit.Framework;
using RPG.Nps;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGUnitTest.Nps
{
    class ArcherPlayerTest
    {
        private ArcherPlayer ArcherPlayer;
        private ArcherPlayer RivalPlayer;

        [SetUp]
        public void Setup()
        {
            ArcherPlayer = new ArcherPlayer("Name", 5, 100);
            RivalPlayer = new ArcherPlayer("Name", 5, 100);
        }

        [TearDown]
        public void Dispose()
        {
            ArcherPlayer = null;
            RivalPlayer = null;
        }

        [Test]
        public void CheckValidePlayerData()
        {
            Assert.AreEqual(ArcherPlayer.Health, 100);
            Assert.AreEqual(ArcherPlayer.Force, 5);
            Assert.AreEqual(ArcherPlayer.Name, "Name");
        }

        [Test]
        public void AttackTest()
        {
            Assert.AreEqual(ArcherPlayer.Health, 100);
            Assert.AreEqual(RivalPlayer.Health, 100);
            ArcherPlayer.Attack(RivalPlayer);
            Assert.AreEqual(ArcherPlayer.Health, 100);
            Assert.AreEqual(RivalPlayer.Health, 95);
        }

        [Test]
        public void UltaAttackTest()
        {
            Assert.AreEqual(ArcherPlayer.Health, 100);
            Assert.AreEqual(RivalPlayer.Health, 100);
            ArcherPlayer.UltaAttack(RivalPlayer);
            Assert.AreEqual(ArcherPlayer.Health, 100);
            Assert.AreEqual(RivalPlayer.Health, 93);
            ArcherPlayer.Attack(RivalPlayer);
            Assert.AreEqual(ArcherPlayer.Health, 100);
            Assert.AreEqual(RivalPlayer.Health, 86);
        }

        [TestCase(100, true)]
        [TestCase(0, false)]
        [TestCase(-100, false)]
        public void CheckHealth(int health, bool isHealthy)
        {
            var magePlayer = new ArcherPlayer("Name", 5, health);
            Assert.AreEqual(magePlayer.CheckHealth(), isHealthy);
        }
    }
}
