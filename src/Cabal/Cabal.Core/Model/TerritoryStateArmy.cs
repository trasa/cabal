using System;
using System.Collections.Generic;
using Blackfin.Core.Model;
using Cabal.Core.Shared.Model;

namespace Cabal.Core.Model
{
    public class TerritoryStateArmy : Entity<TerritoryStateArmy>
    {
        private readonly Dictionary<MilitaryUnit, Func<int, int>> addUnitActions = new Dictionary<MilitaryUnit, Func<int, int>>();
        // Note: can't use uint for these types because SQL Server doesn't support unsigned ints.  :(
        private int aircraftCarriers;
        private int antiaircraft;
        private int armor;
        private int battleships;
        private int bombers;
        private int fighters;
        private int industrialComplexes;
        private int infantry;
        private int submarines;
        private int transports;

        public TerritoryStateArmy()
        {
            addUnitActions.Add(MilitaryUnit.Infantry, u => Infantry += u);
            addUnitActions.Add(MilitaryUnit.Armor, u => Armor += u);
            addUnitActions.Add(MilitaryUnit.Fighter, u => Fighters += u);
            addUnitActions.Add(MilitaryUnit.Bomber, u => Bombers += u);
            addUnitActions.Add(MilitaryUnit.Antiaircraft, u => Antiaircraft += u);
            addUnitActions.Add(MilitaryUnit.Battleship, u => Battleships += u);
            addUnitActions.Add(MilitaryUnit.AircraftCarrier, u => AircraftCarriers += u);
            addUnitActions.Add(MilitaryUnit.Transport, u => Transports += u);
            addUnitActions.Add(MilitaryUnit.Submarine, u => Submarines += u);
            addUnitActions.Add(MilitaryUnit.IndustrialComplex, u => IndustrialComplexes += u);
        }

        public virtual TerritoryState TerritoryState { get; set; }
        
        public virtual int TerritoryId { get { return TerritoryState.TerritoryId;}}

        public virtual Nationality Nationality { get; set; }

        public virtual int Infantry
        {
            get { return infantry; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", value, "Must be Positive");
                infantry = value;
            }
        }

        public virtual int Armor
        {
            get { return armor; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", value, "Must be Positive");
                armor = value;
            }
        }

        public virtual int Fighters
        {
            get { return fighters; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", value, "Must be Positive");
                fighters = value;
            }
        }

        public virtual int Bombers
        {
            get { return bombers; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", value, "Must be Positive");
                bombers = value;
            }
        }

        public virtual int Antiaircraft
        {
            get { return antiaircraft; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", value, "Must be Positive");
                antiaircraft = value;
            }
        }

        public virtual int Battleships
        {
            get { return battleships; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", value, "Must be Positive");
                battleships = value;
            }
        }

        public virtual int AircraftCarriers
        {
            get { return aircraftCarriers; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", value, "Must be Positive");
                aircraftCarriers = value;
            }
        }

        public virtual int Transports
        {
            get { return transports; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", value, "Must be Positive");
                transports = value;
            }
        }

        public virtual int Submarines
        {
            get { return submarines; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", value, "Must be Positive");
                submarines = value;
            }
        }

        public virtual int IndustrialComplexes
        {
            get { return industrialComplexes; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", value, "Must be Positive");
                if (value > 1)
                    throw new ArgumentOutOfRangeException("value", value, "Can have maximum of 1 Industrial Complex per territory.");
                industrialComplexes = value;
            }
        }


        public virtual void AddUnits(MilitaryUnit unit, int unitCount)
        {
            addUnitActions[unit].Invoke(unitCount);
        }
    }
}
