using System.Collections.Generic;
using AutoMapper;
using Blackfin.Core.Model;
using Cabal.Core.Shared.Model;

namespace Cabal.Core.Model
{
    public class TerritoryState : Entity<TerritoryState>
    {
        public TerritoryState()
        {
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            Armies = new Dictionary<Nationality, TerritoryStateArmy>();
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        public virtual Game Game { get; set; }
        public virtual Nationality ControlledBy { get; set; }
        public virtual IDictionary<Nationality, TerritoryStateArmy> Armies { get; set; }

        public virtual int TerritoryId { get; set; }

        public virtual Territory Territory
        {
            get { return Territory.GetById(TerritoryId); }
        }

        public virtual void AddUnits(Nationality nationality, MilitaryUnit unit, int unitCount)
        {
            TerritoryStateArmy army;
            if (!Armies.TryGetValue(nationality, out army))
            {
                army = new TerritoryStateArmy
                           {
                               TerritoryState = this,
                               Nationality = nationality
                           };
                Armies.Add(nationality, army);
            }
            army.AddUnits(unit, unitCount);
        }

        public virtual TerritoryStateDto ToDto()
        {
            return Mapper.Map<TerritoryState, TerritoryStateDto>(this);
        }
    }
}