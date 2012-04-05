using System.Runtime.Serialization;

namespace Cabal.Core.Shared.Model
{
    [DataContract]
    public class GameDto : IGame
    {
        [DataMember]
        public int Id
        {
            get;
            set;
        }

        [DataMember]
        public string Description
        {
            get;
            set;
        }

        [DataMember]
        public string Status
        {
            get;
            set;
        }

        #region SuperWeapons Flags
        [DataMember]
        public bool SovietJetFighters { get; set; }
        [DataMember]
        public bool SovietRockets { get; set; }
        [DataMember]
        public bool SovietSuperSubs { get; set; }
        [DataMember]
        public bool SovietLongRangeAir { get; set; }
        [DataMember]
        public bool SovietIndustrialTech { get; set; }
        [DataMember]
        public bool SovietHeavyBombers { get; set; }

        [DataMember]
        public bool GermanJetFighters { get; set; }
        [DataMember]
        public bool GermanRockets { get; set; }
        [DataMember]
        public bool GermanSuperSubs { get; set; }
        [DataMember]
        public bool GermanLongRangeAir { get; set; }
        [DataMember]
        public bool GermanIndustrialTech { get; set; }
        [DataMember]
        public bool GermanHeavyBombers { get; set; }

        [DataMember]
        public bool BritishJetFighters { get; set; }
        [DataMember]
        public bool BritishRockets { get; set; }
        [DataMember]
        public bool BritishSuperSubs { get; set; }
        [DataMember]
        public bool BritishLongRangeAir { get; set; }
        [DataMember]
        public bool BritishIndustrialTech { get; set; }
        [DataMember]
        public bool BritishHeavyBombers { get; set; }

        [DataMember]
        public bool JapaneseJetFighters { get; set; }
        [DataMember]
        public bool JapaneseRockets { get; set; }
        [DataMember]
        public bool JapaneseSuperSubs { get; set; }
        [DataMember]
        public bool JapaneseLongRangeAir { get; set; }
        [DataMember]
        public bool JapaneseIndustrialTech { get; set; }
        [DataMember]
        public bool JapaneseHeavyBombers { get; set; }

        [DataMember]
        public bool AmericanJetFighters { get; set; }
        [DataMember]
        public bool AmericanRockets { get; set; }
        [DataMember]
        public bool AmericanSuperSubs { get; set; }
        [DataMember]
        public bool AmericanLongRangeAir { get; set; }
        [DataMember]
        public bool AmericanIndustrialTech { get; set; }
        [DataMember]
        public bool AmericanHeavyBombers { get; set; }

        #endregion
    }
}
