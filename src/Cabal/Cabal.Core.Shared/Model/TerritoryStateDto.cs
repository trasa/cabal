using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Cabal.Core.Shared.Model
{
    [DataContract]
    public class TerritoryStateDto 
    {
        public TerritoryStateDto()
        {
            Armies = new TerritoryStateArmyDto[0];
        }

        [DataMember]
        public int TerritoryId
        {
            get; set;
        }

        [DataMember]
        public int GameId
        {
            get; set;
        }

        [DataMember]
        public Nationality ControlledBy
        {
            get; set;
        }

        [DataMember]
        public TerritoryStateArmyDto[] Armies
        {
            get; set;
        }

        public Nationality ArmyNationalities
        {
            get
            {
                Nationality result = Nationality.None;
                foreach(var a in Armies)
                {
                    result |= a.Nationality;
                }
                return result;
            }
        }

        [ScriptIgnore]
        public Territory Territory 
        {
            get { return Territory.GetById(TerritoryId); }
        }
    }
}
