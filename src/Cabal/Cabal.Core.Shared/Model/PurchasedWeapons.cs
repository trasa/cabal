using System.Collections.Generic;

namespace Cabal.Core.Shared.Model
{
    public class PurchasedWeapons
    {
        private readonly Dictionary<Nationality, bool[]> weapons = new Dictionary<Nationality, bool[]>
                                                                       {
                                                                           {Nationality.Germany, new bool[7]},
                                                                           {Nationality.SovietUnion, new bool[7]},
                                                                           {Nationality.Japan, new bool[7]},
                                                                           {Nationality.UnitedKingdom, new bool[7]},
                                                                           {Nationality.UnitedStates, new bool[7]},
                                                                       };


        public PurchasedWeapons(IGame game)
        {
            SetPurchased(Nationality.UnitedStates,
                         game.AmericanJetFighters,
                         game.AmericanRockets,
                         game.AmericanSuperSubs,
                         game.AmericanLongRangeAir,
                         game.AmericanIndustrialTech,
                         game.AmericanHeavyBombers);

            SetPurchased(Nationality.SovietUnion,
                         game.SovietJetFighters,
                         game.SovietRockets,
                         game.SovietSuperSubs,
                         game.SovietLongRangeAir,
                         game.SovietIndustrialTech,
                         game.SovietHeavyBombers);

            SetPurchased(Nationality.Germany,
                         game.GermanJetFighters,
                         game.GermanRockets,
                         game.GermanSuperSubs,
                         game.GermanLongRangeAir,
                         game.GermanIndustrialTech,
                         game.GermanHeavyBombers);

            SetPurchased(Nationality.Japan,
                         game.JapaneseJetFighters,
                         game.JapaneseRockets,
                         game.JapaneseSuperSubs,
                         game.JapaneseLongRangeAir,
                         game.JapaneseIndustrialTech,
                         game.JapaneseHeavyBombers);

            SetPurchased(Nationality.UnitedKingdom,
                         game.BritishJetFighters,
                         game.BritishRockets,
                         game.BritishSuperSubs,
                         game.BritishLongRangeAir,
                         game.BritishIndustrialTech,
                         game.BritishHeavyBombers);
        }

        public bool Purchased(Nationality n, Weapon w)
        {
            return weapons[n][(int)w];
        }

        private void SetPurchased(Nationality nationality, bool jetPower, bool rockets, bool superSubs, bool longRangeAir, bool indTech, bool bombers)
        {
            SetPurchased(nationality, Weapon.JetPower, jetPower);
            SetPurchased(nationality, Weapon.Rockets, rockets);
            SetPurchased(nationality, Weapon.SuperSubs, superSubs);
            SetPurchased(nationality, Weapon.LongRangeAir, longRangeAir);
            SetPurchased(nationality, Weapon.IndustrialTech, indTech);
            SetPurchased(nationality, Weapon.HeavyBombers, bombers);
        }

        private void SetPurchased(Nationality nationality, Weapon weapon, bool purchased)
        {
            weapons[nationality][(int)weapon] = purchased;
        }
    }
}
