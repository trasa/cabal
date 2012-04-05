using Cabal.Core.Model;
using FluentNHibernate.Mapping;

namespace Cabal.Core.Mapping
{
    public class GameMap : ClassMap<Game>
    {
        public GameMap()
        {
            Id(x => x.Id);

            Map(x => x.IsStarted);
            Map(x => x.Description);
            Map(x => x.CurrentNationality);

            References(x => x.Owner).Cascade.All().Not.Nullable();

            References(x => x.SovietPlayer).Cascade.All();
            References(x => x.GermanPlayer).Cascade.All();
            References(x => x.BritishPlayer).Cascade.All();
            References(x => x.JapanesePlayer).Cascade.All();
            References(x => x.AmericanPlayer).Cascade.All();
            References(x => x.CreatedBy).Cascade.All();

            Map(x => x.GermanIpcAmount).Not.Nullable();
            Map(x => x.JapaneseIpcAmount).Not.Nullable();
            Map(x => x.SovietIpcAmount).Not.Nullable();
            Map(x => x.BritishIpcAmount).Not.Nullable();
            Map(x => x.AmericanIpcAmount).Not.Nullable();

            Map(x => x.GermanIncome).Not.Nullable();
            Map(x => x.JapaneseIncome).Not.Nullable();
            Map(x => x.SovietIncome).Not.Nullable();
            Map(x => x.BritishIncome).Not.Nullable();
            Map(x => x.AmericanIncome).Not.Nullable();

            Map(x => x.SovietJetFighters).Not.Nullable();
            Map(x => x.SovietRockets).Not.Nullable();
            Map(x => x.SovietSuperSubs).Not.Nullable();
            Map(x => x.SovietLongRangeAir).Not.Nullable();
            Map(x => x.SovietIndustrialTech).Not.Nullable();
            Map(x => x.SovietHeavyBombers).Not.Nullable();

            Map(x => x.GermanJetFighters).Not.Nullable();
            Map(x => x.GermanRockets).Not.Nullable();
            Map(x => x.GermanSuperSubs).Not.Nullable();
            Map(x => x.GermanLongRangeAir).Not.Nullable();
            Map(x => x.GermanIndustrialTech).Not.Nullable();
            Map(x => x.GermanHeavyBombers).Not.Nullable();

            Map(x => x.BritishJetFighters).Not.Nullable();
            Map(x => x.BritishRockets).Not.Nullable();
            Map(x => x.BritishSuperSubs).Not.Nullable();
            Map(x => x.BritishLongRangeAir).Not.Nullable();
            Map(x => x.BritishIndustrialTech).Not.Nullable();
            Map(x => x.BritishHeavyBombers).Not.Nullable();

            Map(x => x.JapaneseJetFighters).Not.Nullable();
            Map(x => x.JapaneseRockets).Not.Nullable();
            Map(x => x.JapaneseSuperSubs).Not.Nullable();
            Map(x => x.JapaneseLongRangeAir).Not.Nullable();
            Map(x => x.JapaneseIndustrialTech).Not.Nullable();
            Map(x => x.JapaneseHeavyBombers).Not.Nullable();

            Map(x => x.AmericanJetFighters).Not.Nullable();
            Map(x => x.AmericanRockets).Not.Nullable();
            Map(x => x.AmericanSuperSubs).Not.Nullable();
            Map(x => x.AmericanLongRangeAir).Not.Nullable();
            Map(x => x.AmericanIndustrialTech).Not.Nullable();
            Map(x => x.AmericanHeavyBombers).Not.Nullable();



            HasMany(x => x.TerritoryStates)
                .AsMap(x => x.TerritoryId)
                .KeyColumn("GameId");
        }
    }
}
