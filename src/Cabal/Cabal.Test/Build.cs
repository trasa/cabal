using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cabal.Core.Factories;
using Cabal.Core.Model;

namespace Cabal.Test
{
    public static class Build
    {
        public static Game Game()
        {
            return new GameFactory().Create(new Player(), "Build.Game",
                                            new Player(), new Player(), new Player(), new Player(), new Player());
        }
    }
}
