
using System;
using System.Runtime.Serialization;

namespace Cabal.Core.Shared.Model
{
    [Flags]
    [DataContract(Name = "Nationality", Namespace = "http://meancat.com/")]
    public enum Nationality
    {
        [EnumMember]
        None = 0,

        [EnumMember]
        SovietUnion = 1 << 0,

        [EnumMember]
        UnitedKingdom = 1 << 1,

        [EnumMember]
        UnitedStates = 1 << 2,
        
        [EnumMember]
        Germany = 1 << 3,
        
        [EnumMember]
        Japan = 1 << 4,

        [EnumMember]
        GermanyJapan = Germany | Japan,

        [EnumMember]
        SovietUnionUnitedKingdom = SovietUnion | UnitedKingdom,
        
        [EnumMember]
        SovietUnionUnitedStates = SovietUnion | UnitedStates,
        
        [EnumMember]
        UnitedKingdomUnitedStates = UnitedKingdom | UnitedStates,
        
        [EnumMember]
        SovietUnionUnitedKingdomUnitedStates = SovietUnionUnitedKingdom | UnitedStates,
    }
}
