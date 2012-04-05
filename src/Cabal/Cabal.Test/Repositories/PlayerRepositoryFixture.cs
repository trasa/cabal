using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blackfin.Core.NHibernate;
using Cabal.Core.Config;
using Cabal.Core.Model;
using Cabal.Core.Repositories;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Cabal.Test.Repositories
{
    public class PlayerRepositoryFixture : NHibernateSessionFixture
    {
        private PlayerRepository playerRepository;
        private int cpuId;
        protected override void Given()
        {
            base.Given();
            var cpuPlayer = new Player {UserName = null};

            cpuPlayer = Load(cpuPlayer);
            cpuId = cpuPlayer.Id;
            FlushSessionAndEvict(cpuPlayer);
            var settingsProvider = new StubCabalSettingsProvider(new CabalSection {Server = new ServerElement {CpuPlayerId = cpuId}});
            playerRepository = new PlayerRepository(NHibernateSession, settingsProvider);
        }

        [Test]
        public void When_Retreving_Cpu_Player()
        {
            Player cpu = playerRepository.GetCpuPlayer();
            Assert.That(cpu.IsCpu);
            Assert.That(cpu.Id, Is.EqualTo(cpuId));
        }
    }
}
