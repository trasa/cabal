
namespace Cabal.Core.Shared.Model
{
    public interface IGame
    {
        int Id { get; set; }

        bool SovietJetFighters { get; set; }
        bool SovietRockets { get; set; }
        bool SovietSuperSubs { get; set; }
        bool SovietLongRangeAir { get; set; }
        bool SovietIndustrialTech { get; set; }
        bool SovietHeavyBombers { get; set; }

        bool GermanJetFighters { get; set; }
        bool GermanRockets { get; set; }
        bool GermanSuperSubs { get; set; }
        bool GermanLongRangeAir { get; set; }
        bool GermanIndustrialTech { get; set; }
        bool GermanHeavyBombers { get; set; }

        bool BritishJetFighters { get; set; }
        bool BritishRockets { get; set; }
        bool BritishSuperSubs { get; set; }
        bool BritishLongRangeAir { get; set; }
        bool BritishIndustrialTech { get; set; }
        bool BritishHeavyBombers { get; set; }

        bool JapaneseJetFighters { get; set; }
        bool JapaneseRockets { get; set; }
        bool JapaneseSuperSubs { get; set; }
        bool JapaneseLongRangeAir { get; set; }
        bool JapaneseIndustrialTech { get; set; }
        bool JapaneseHeavyBombers { get; set; }

        bool AmericanJetFighters { get; set; }
        bool AmericanRockets { get; set; }
        bool AmericanSuperSubs { get; set; }
        bool AmericanLongRangeAir { get; set; }
        bool AmericanIndustrialTech { get; set; }
        bool AmericanHeavyBombers { get; set; }
    }
}
