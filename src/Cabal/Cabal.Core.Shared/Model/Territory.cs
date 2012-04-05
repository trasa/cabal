using System.Collections.Generic;
using System.Reflection;
using Blackfin.Core.Model;
using Cabal.Core.Shared.Exceptions;

namespace Cabal.Core.Shared.Model
{
    public abstract class Territory : Entity<Territory>
    {

        protected Territory(int id, string name)
        {
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            Id = id;

            Name = name;
            NeighborList = new Dictionary<string, Territory>();
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }


        
        public string Name { get; set;}
        public int ManufacturingPoints { get; protected set; }

        public IEnumerable<Territory> Neighbors { get { return NeighborList.Values; }}

        public bool IsAdjacentTo(Territory neighbor)
        {
            if (neighbor == null)
                return false;
            return NeighborList.ContainsKey(neighbor.Name);
        }


        protected Dictionary<string, Territory> NeighborList { get; private set; }

        public virtual string ControlName
        {
            get { return Name.Replace(' ', '_'); }
        }

        protected void AddNeighbor(Territory neighbor)
        {
            if (neighbor == this)
            {
                throw new InvalidGameStateException("I can't be my own neighbor: " + neighbor.Name);
            }
            // Hello, Neighbor.
            if (!NeighborList.ContainsKey(neighbor.Name))
                NeighborList.Add(neighbor.Name, neighbor);
            
            if (!neighbor.NeighborList.ContainsKey(Name))
                neighbor.NeighborList.Add(Name, this);

        }


        private static readonly Territory[] TerritoryById;
        private static readonly Dictionary<string, Territory> TerritoryByName;

        public static Territory GetById(int id)
        {
            return TerritoryById[id];
        }

        public static Territory GetByName(string name)
        {
            Territory t;
            if (!TerritoryByName.TryGetValue(name, out t))
                return null;
            return t;
        }

        public static Territory GetByControlName(string controlName)
        {
            controlName = controlName
                .Replace("Piece", "")
                .Replace('_', ' ');
            return GetByName(controlName);
        }


        public static IEnumerable<Territory> GetAllTerritories()
        {
            foreach (var fieldInfo in typeof(Territory).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var t = fieldInfo.GetValue(typeof(Territory)) as Territory;
                if (t != null)
                    yield return t;
            }
        }

        #region static Territory declarations 

        public static CapitalTerritory UnitedKingdom;
        public static SeaTerritory EnglishChannel;
        public static NeutralTerritory Eire;
        public static SeaTerritory SpanishAtlantic;
        public static NeutralTerritory Spain;
        public static LandTerritory Gibraltar;
        public static LandTerritory FinlandNorway;
        public static LandTerritory Sweden;
        public static SeaTerritory BalticSea;
        public static LandTerritory WesternEurope;
        public static CapitalTerritory Germany;
        public static NeutralTerritory Switzerland;
        public static LandTerritory SouthernEurope;
        public static LandTerritory EasternEurope;
        public static LandTerritory Ukraine;
        public static LandTerritory Karelia;
        public static LandTerritory Caucasus;
        public static CapitalTerritory Russia;
        public static LandTerritory Kazakh;
        public static LandTerritory Novosibirsk;
        public static LandTerritory Evenki;
        public static LandTerritory Yakut;
        public static LandTerritory SovietFarEast;
        public static NeutralTerritory Turkey;
        public static LandTerritory SyriaIraq;
        public static LandTerritory Persia;
        public static NeutralTerritory Afghan;
        public static NeutralTerritory SaudiArabia;
        public static LandTerritory India;
        public static SeaTerritory BlackSea;
        public static SeaTerritory CaspianSea;
        public static LandTerritory Sinkiang;
        public static LandTerritory China;
        public static NeutralTerritory Mongolia;
        public static LandTerritory FrenchIndoChina;
        public static LandTerritory Kwangtung;
        public static LandTerritory Manchuria;
        public static CapitalTerritory Japan;
        public static SeaTerritory SovietFarEastSea;
        public static SeaTerritory IndianOcean;
        public static SeaTerritory SouthChinaSea;
        public static SeaTerritory KwangtungSea;
        public static SeaTerritory SeaOfJapan;
        public static CanalTerritory RedSea;
        public static SeaTerritory GibraltarMediterraneanSea;
        public static SeaTerritory MediterraneanSea;
        public static SeaTerritory EastMediterraneanSea;
        public static LandTerritory Algeria;
        public static LandTerritory Libya;
        public static LandTerritory AngloEgyptSudan;
        public static NeutralTerritory RioDeOro;
        public static LandTerritory FrenchWestAfrica;
        public static LandTerritory FrenchEquatorialAfrica;
        public static LandTerritory BelgianCongo;
        public static LandTerritory ItalianEastAfrica;
        public static LandTerritory KenyaRhodesia;
        public static NeutralTerritory Angola;
        public static LandTerritory SouthAfrica;
        public static NeutralTerritory Mozambique;
        public static LandTerritory Madagascar;
        public static SeaTerritory SouthAfricaSea;
        public static SeaTerritory FrenchWestAfricaSea;
        public static SeaTerritory BelgianCongoSea;
        public static SeaTerritory AngolaSea;
        public static SeaTerritory MadagascarSea;
        public static SeaTerritory WestIndianOcean;
        public static SeaTerritory EastIndianOcean;
        public static SeaTerritory SouthWestIndianOcean;
        public static SeaTerritory SouthEastIndianOcean;
        public static LandTerritory EastIndies;
        public static SeaTerritory EastIndiesSea;
        public static LandTerritory BorneoCelebes;
        public static SeaTerritory BorneoCelebsSea;
        public static LandTerritory PhilipineIslands;
        public static SeaTerritory PhilipineIslandsSea;
        public static LandTerritory NewGuinea;
        public static SeaTerritory NewGuineaSea;
        public static LandTerritory CarolineIslands;
        public static SeaTerritory CarolineIslandsSea;
        public static LandTerritory SolomonIslands;
        public static SeaTerritory SolomonIslandsSea;
        public static LandTerritory Okinawa;
        public static SeaTerritory OkinawaSea;
        public static LandTerritory WakeIsland;
        public static SeaTerritory WakeIslandSea;
        public static SeaTerritory NorthPacificOcean;
        public static LandTerritory MidwayIsland;
        public static SeaTerritory MidwayIslandSea;
        public static LandTerritory HawaiianIslands;
        public static SeaTerritory HawaiianIslandsSea;
        public static LandTerritory Australia;
        public static SeaTerritory WestAustraliaSea;
        public static SeaTerritory EastAustraliaSea;
        public static SeaTerritory SouthAustraliaSea;
        public static LandTerritory NewZealand;
        public static SeaTerritory NewZealandSea;
        public static SeaTerritory SouthEastPacificOcean;
        public static SeaTerritory SouthPacificOcean;
        public static SeaTerritory FarSouthPacificOcean;
        public static LandTerritory Alaska;
        public static SeaTerritory BeringStrait;
        public static LandTerritory WesternCanada;
        public static SeaTerritory WesternCanadaSea;
        public static LandTerritory WesternUsa;
        public static SeaTerritory WesternUsaSea;
        public static LandTerritory Mexico;
        public static SeaTerritory WestMexicoSea;
        public static SeaTerritory GulfOfMexico;
        public static LandTerritory EasternCanada;
        public static CapitalTerritory EasternUsa;
        public static SeaTerritory EasternCanadaSea;
        public static SeaTerritory EasternUsaSea;
        public static LandTerritory WestIndies;
        public static LandTerritory Panama;
        public static CanalTerritory CaribbeanSea;
        public static SeaTerritory AtlanticOcean;
        public static NeutralTerritory VenezuelaColumbia;
        public static NeutralTerritory Peru;
        public static SeaTerritory PeruSea;
        public static LandTerritory Brazil;
        public static SeaTerritory NorthBrazilSea;
        public static SeaTerritory SouthBrazilSea;
        public static NeutralTerritory ArgentinaChile;
        public static SeaTerritory SouthArgentinaSea;
        public static SeaTerritory EastArgentinaSea;
        public static SeaTerritory SouthAtlantic;
        public static SeaTerritory FarSouthAtlantic;
        public static SeaTerritory BarentsSea;

        #endregion

        static Territory()
        {
            #region Territory Definition
            int id = 1;
            UnitedKingdom = new CapitalTerritory(id++, "United Kingdom", 8);
            Eire = new NeutralTerritory(id++, "Eire");
            EnglishChannel = new SeaTerritory(id++, "English Channel");

            SpanishAtlantic = new SeaTerritory(id++, "Spanish Atlantic");
            Spain = new NeutralTerritory(id++, "Spain");
            Gibraltar = new LandTerritory(id++, "Gibraltar", 0);
            GibraltarMediterraneanSea = new SeaTerritory(id++, "Gibraltar Sea");

            WesternEurope = new LandTerritory(id++, "Western Europe", 6);
            Germany = new CapitalTerritory(id++, "Germany", 10);
            Switzerland = new NeutralTerritory(id++, "Switzerland");
            SouthernEurope = new LandTerritory(id++, "Southern Europe", 6);
            MediterraneanSea = new SeaTerritory(id++, "Mediterranean Sea");
            EasternEurope = new LandTerritory(id++, "Eastern Europe", 3);
            Ukraine = new LandTerritory(id++, "Ukraine SSR", 3);

            FinlandNorway = new LandTerritory(id++, "Finland Norway", 2);
            Sweden = new NeutralTerritory(id++, "Sweden");
            BalticSea = new SeaTerritory(id++, "Baltic Sea");

            Karelia = new LandTerritory(id++, "Karelia SSR", 3);
            BarentsSea = new SeaTerritory(id++, "Barents Sea");
            Caucasus = new LandTerritory(id++, "Caucasus", 3);
            Russia = new CapitalTerritory(id++, "Russia", 8);
            Kazakh = new LandTerritory(id++, "Kazakh SSR", 2);
            Novosibirsk = new LandTerritory(id++, "Novosibirsk", 2);
            Evenki = new LandTerritory(id++, "Evenki", 2);
            Yakut = new LandTerritory(id++, "Yakut SSR", 2);
            SovietFarEast = new LandTerritory(id++, "Soviet Far East", 2);
            SovietFarEastSea = new SeaTerritory(id++, "Soviet Far East Sea");

            Turkey = new NeutralTerritory(id++, "Turkey");
            EastMediterraneanSea = new SeaTerritory(id++, "East Mediterranean Sea");
            BlackSea = new SeaTerritory(id++, "Black Sea");
            SyriaIraq = new LandTerritory(id++, "Syria Iraq", 1);
            Persia = new LandTerritory(id++, "Persia", 1);
            CaspianSea = new SeaTerritory(id++, "Caspian Sea");
            Afghan = new NeutralTerritory(id++, "Afghan");
            SaudiArabia = new NeutralTerritory(id++, "Saudi Arabia");
            RedSea = new CanalTerritory(id++, "Red Sea");
            India = new LandTerritory(id++, "India", 3);
            IndianOcean = new SeaTerritory(id++, "Indian Ocean");


            Sinkiang = new LandTerritory(id++, "Sinkiang", 2);
            China = new LandTerritory(id++, "China", 2);
            Mongolia = new NeutralTerritory(id++, "Mongolia");
            FrenchIndoChina = new LandTerritory(id++, "French Indo China Burma", 3);
            SouthChinaSea = new SeaTerritory(id++, "South China Sea");
            Kwangtung = new LandTerritory(id++, "Kwangtung", 3);
            KwangtungSea = new SeaTerritory(id++, "Kwangtung Sea");
            Manchuria = new LandTerritory(id++, "Manchuria", 3);
            Japan = new CapitalTerritory(id++, "Japan", 8);
            SeaOfJapan = new SeaTerritory(id++, "Sea of Japan");

            Algeria = new LandTerritory(id++, "Algeria", 1);
            Libya = new LandTerritory(id++, "Libya", 1);
            AngloEgyptSudan = new LandTerritory(id++, "Anglo Egypt Sudan", 2);
            RioDeOro = new NeutralTerritory(id++, "Rio De Oro");
            FrenchWestAfrica = new LandTerritory(id++, "French West Africa", 1);
            FrenchWestAfricaSea = new SeaTerritory(id++, "French West Africa Sea");
            FrenchEquatorialAfrica = new LandTerritory(id++, "French Equatorial Africa", 1);
            BelgianCongo = new LandTerritory(id++, "Belgian Congo", 1);
            BelgianCongoSea = new SeaTerritory(id++, "Belgian Congo Sea");
            ItalianEastAfrica = new LandTerritory(id++, "Italian East Africa", 1);
            KenyaRhodesia = new LandTerritory(id++, "Kenya Rhodesia", 1);
            Angola = new NeutralTerritory(id++, "Angola");
            AngolaSea = new SeaTerritory(id++, "Angola Sea");
            SouthAfrica = new LandTerritory(id++, "South Africa", 2);
            SouthAfricaSea = new SeaTerritory(id++, "South Africa Sea");
            Mozambique = new NeutralTerritory(id++, "Mozambique");
            Madagascar = new LandTerritory(id++, "French Madagascar", 1);
            MadagascarSea = new SeaTerritory(id++, "Madagascar Sea");

            WestIndianOcean = new SeaTerritory(id++, "West Indian Ocean");
            EastIndianOcean = new SeaTerritory(id++, "East Indian Ocean");
            SouthWestIndianOcean = new SeaTerritory(id++, "SouthWest Indian Ocean");
            SouthEastIndianOcean = new SeaTerritory(id++, "SouthEast Indian Ocean");

            EastIndies = new LandTerritory(id++, "East Indies", 2);
            EastIndiesSea = new SeaTerritory(id++, "East Indies Sea");

            BorneoCelebes = new LandTerritory(id++, "Borneo Celebes", 1);
            BorneoCelebsSea = new SeaTerritory(id++, "Borneo Celebes Sea");
            PhilipineIslands = new LandTerritory(id++, "Philipine Islands", 3);
            PhilipineIslandsSea = new SeaTerritory(id++, "Philipine Islands Sea");
            NewGuinea = new LandTerritory(id++, "New Guinea", 1);
            NewGuineaSea = new SeaTerritory(id++, "New Guinea Sea");
            CarolineIslands = new LandTerritory(id++, "Caroline Islands", 0);
            CarolineIslandsSea = new SeaTerritory(id++, "Caroline Islands Sea");
            SolomonIslands = new LandTerritory(id++, "Solomon Islands", 0);
            SolomonIslandsSea = new SeaTerritory(id++, "Solomon Islands Sea");
            Okinawa = new LandTerritory(id++, "Okinawa", 1);
            OkinawaSea = new SeaTerritory(id++, "Okinawa Sea");
            WakeIsland = new LandTerritory(id++, "Wake Island", 0);
            WakeIslandSea = new SeaTerritory(id++, "Wake Island Sea");
            NorthPacificOcean = new SeaTerritory(id++, "North Pacific Ocean");
            MidwayIsland = new LandTerritory(id++, "Midway Island", 0);
            MidwayIslandSea = new SeaTerritory(id++, "Midway Island Sea");
            HawaiianIslands = new LandTerritory(id++, "Hawaiian Islands", 1);
            HawaiianIslandsSea = new SeaTerritory(id++, "Hawaiian Islands Sea");

            SouthPacificOcean = new SeaTerritory(id++, "South Pacific Ocean");
            FarSouthPacificOcean = new SeaTerritory(id++, "Far South Pacific Ocean");
            SouthEastPacificOcean = new SeaTerritory(id++, "SouthEast Pacific Ocean");

            Australia = new LandTerritory(id++, "Australia", 2);
            WestAustraliaSea = new SeaTerritory(id++, "West Australia Sea");
            EastAustraliaSea = new SeaTerritory(id++, "East Australia Sea");
            SouthAustraliaSea = new SeaTerritory(id++, "South Australia Sea");
            NewZealand = new LandTerritory(id++, "New Zealand", 1);
            NewZealandSea = new SeaTerritory(id++, "New Zealand Sea");

            Alaska = new LandTerritory(id++, "Alaska", 2);
            BeringStrait = new SeaTerritory(id++, "Bering Strait");

            WesternCanada = new LandTerritory(id++, "Western Canada", 1);
            WesternCanadaSea = new SeaTerritory(id++, "Western Canada Sea");
            WesternUsa = new LandTerritory(id++, "Western USA", 10);
            WesternUsaSea = new SeaTerritory(id++, "Western USA Sea");
            Mexico = new LandTerritory(id++, "Mexico", 2);
            WestMexicoSea = new SeaTerritory(id++, "West Mexico Sea");
            GulfOfMexico = new SeaTerritory(id++, "Gulf of Mexico");
            
            EasternCanada = new LandTerritory(id++, "Eastern Canada", 3);
            EasternUsa = new CapitalTerritory(id++, "Eastern USA", 12);
            EasternCanadaSea = new SeaTerritory(id++, "Eastern Canada Sea");
            EasternUsaSea = new SeaTerritory(id++, "Eastern USA Sea");

            WestIndies = new LandTerritory(id++, "West Indies", 1);
            Panama = new LandTerritory(id++, "Panama", 1);
            CaribbeanSea = new CanalTerritory(id++, "Caribbean Sea");
            AtlanticOcean = new SeaTerritory(id++, "Atlantic Ocean");

            VenezuelaColumbia = new NeutralTerritory(id++, "Venezuela Columbia");
            Peru = new NeutralTerritory(id++, "Peru");
            PeruSea = new SeaTerritory(id++, "Peru Sea");
            Brazil = new LandTerritory(id++, "Brazil", 3);
            NorthBrazilSea = new SeaTerritory(id++, "North Brazil Sea");
            SouthBrazilSea = new SeaTerritory(id++, "South Brazil Sea");
            ArgentinaChile = new NeutralTerritory(id++, "Argentina Chile");
            SouthArgentinaSea = new SeaTerritory(id++, "South Argentina Sea");
            EastArgentinaSea = new SeaTerritory(id++, "East Argentina Sea");
            SouthAtlantic = new SeaTerritory(id++, "South Atlantic");
            FarSouthAtlantic = new SeaTerritory(id++, "Far South Atlantic");

            #endregion

            #region Neighbors
           
            UnitedKingdom.AddNeighbor(EnglishChannel);
            
            Eire.AddNeighbor(EnglishChannel);

            EnglishChannel.AddNeighbor(EasternCanadaSea);
            EnglishChannel.AddNeighbor(SpanishAtlantic);
            EnglishChannel.AddNeighbor(BarentsSea);
            EnglishChannel.AddNeighbor(BalticSea);

            WesternEurope.AddNeighbor(EnglishChannel);
            WesternEurope.AddNeighbor(SpanishAtlantic);
            WesternEurope.AddNeighbor(BalticSea);
            WesternEurope.AddNeighbor(Spain);
            WesternEurope.AddNeighbor(Germany);
            WesternEurope.AddNeighbor(Switzerland);
            WesternEurope.AddNeighbor(SouthernEurope);
            WesternEurope.AddNeighbor(GibraltarMediterraneanSea);

            Spain.AddNeighbor(SpanishAtlantic);
            Spain.AddNeighbor(Gibraltar);
            Spain.AddNeighbor(GibraltarMediterraneanSea);

            SpanishAtlantic.AddNeighbor(EasternCanadaSea);
            SpanishAtlantic.AddNeighbor(AtlanticOcean);
            SpanishAtlantic.AddNeighbor(MediterraneanSea);

            EasternCanadaSea.AddNeighbor(AtlanticOcean);
            EasternCanadaSea.AddNeighbor(EasternUsaSea);

            EasternUsaSea.AddNeighbor(AtlanticOcean);
            EasternUsaSea.AddNeighbor(CaribbeanSea);
            EasternUsaSea.AddNeighbor(GulfOfMexico);

            AtlanticOcean.AddNeighbor(FrenchWestAfricaSea);
            AtlanticOcean.AddNeighbor(NorthBrazilSea);


            Gibraltar.AddNeighbor(GibraltarMediterraneanSea);

            GibraltarMediterraneanSea.AddNeighbor(MediterraneanSea);
            GibraltarMediterraneanSea.AddNeighbor(SpanishAtlantic);

            MediterraneanSea.AddNeighbor(BlackSea);
            MediterraneanSea.AddNeighbor(EastMediterraneanSea);

            EastMediterraneanSea.AddNeighbor(BlackSea);
            EastMediterraneanSea.AddNeighbor(RedSea);

            Germany.AddNeighbor(Switzerland);
            Germany.AddNeighbor(SouthernEurope);
            Germany.AddNeighbor(EasternEurope);
            Germany.AddNeighbor(BalticSea);

            SouthernEurope.AddNeighbor(Switzerland);
            SouthernEurope.AddNeighbor(MediterraneanSea);
            SouthernEurope.AddNeighbor(EasternEurope);

            EasternEurope.AddNeighbor(BalticSea);
            EasternEurope.AddNeighbor(Karelia);
            EasternEurope.AddNeighbor(Ukraine);
            EasternEurope.AddNeighbor(BlackSea);

            Ukraine.AddNeighbor(Karelia);
            Ukraine.AddNeighbor(Caucasus);
            Ukraine.AddNeighbor(BlackSea);

            FinlandNorway.AddNeighbor(EnglishChannel);
            FinlandNorway.AddNeighbor(Sweden);
            FinlandNorway.AddNeighbor(Karelia);
            FinlandNorway.AddNeighbor(BalticSea);

            Sweden.AddNeighbor(BalticSea);

            Karelia.AddNeighbor(BarentsSea);
            Karelia.AddNeighbor(Caucasus);
            Karelia.AddNeighbor(Russia);

            Caucasus.AddNeighbor(Russia);
            Caucasus.AddNeighbor(BlackSea);
            Caucasus.AddNeighbor(CaspianSea);
            Caucasus.AddNeighbor(Turkey);
            Caucasus.AddNeighbor(Persia);

            Russia.AddNeighbor(Evenki);
            Russia.AddNeighbor(Novosibirsk);
            Russia.AddNeighbor(Kazakh);
            Russia.AddNeighbor(CaspianSea);

            Evenki.AddNeighbor(Yakut);
            Evenki.AddNeighbor(Novosibirsk);

            Novosibirsk.AddNeighbor(Yakut);
            Novosibirsk.AddNeighbor(Mongolia);
            Novosibirsk.AddNeighbor(Sinkiang);
            Novosibirsk.AddNeighbor(Kazakh);

            Kazakh.AddNeighbor(CaspianSea);
            Kazakh.AddNeighbor(Sinkiang);
            Kazakh.AddNeighbor(Afghan);
            Kazakh.AddNeighbor(Persia);

            Yakut.AddNeighbor(SovietFarEast);
            Yakut.AddNeighbor(Manchuria);
            Yakut.AddNeighbor(Mongolia);

            SovietFarEastSea.AddNeighbor(SovietFarEast);
            SovietFarEastSea.AddNeighbor(Manchuria);

            Turkey.AddNeighbor(BlackSea);
            Turkey.AddNeighbor(Persia);
            Turkey.AddNeighbor(SyriaIraq);
            Turkey.AddNeighbor(EastMediterraneanSea);
            
            SyriaIraq.AddNeighbor(EastMediterraneanSea);
            SyriaIraq.AddNeighbor(Persia);
            SyriaIraq.AddNeighbor(SaudiArabia);
            SyriaIraq.AddNeighbor(RedSea); // TODO: this can't be right - that should be persian gulf or something..

            SaudiArabia.AddNeighbor(RedSea); // TODO: this can't be right - that should be persian gulf or something..
            SaudiArabia.AddNeighbor(Persia);

            Persia.AddNeighbor(Afghan);
            Persia.AddNeighbor(India);
            Persia.AddNeighbor(RedSea); // TODO: this can't be right - that should be persian gulf or something..
            Persia.AddNeighbor(CaspianSea);

            India.AddNeighbor(Afghan);
            India.AddNeighbor(Sinkiang);
            India.AddNeighbor(FrenchIndoChina);
            India.AddNeighbor(IndianOcean);

            Sinkiang.AddNeighbor(Mongolia);
            Sinkiang.AddNeighbor(China);
            Sinkiang.AddNeighbor(FrenchIndoChina);
            Sinkiang.AddNeighbor(Afghan);

            China.AddNeighbor(Mongolia);
            China.AddNeighbor(Manchuria);
            China.AddNeighbor(Kwangtung);
            China.AddNeighbor(FrenchIndoChina);

            FrenchIndoChina.AddNeighbor(Kwangtung);
            FrenchIndoChina.AddNeighbor(SouthChinaSea);

            Kwangtung.AddNeighbor(Manchuria);
            Kwangtung.AddNeighbor(KwangtungSea);

            Manchuria.AddNeighbor(Mongolia);
            Manchuria.AddNeighbor(SeaOfJapan);

            Japan.AddNeighbor(SeaOfJapan);

            SeaOfJapan.AddNeighbor(NorthPacificOcean);

            Algeria.AddNeighbor(GibraltarMediterraneanSea);
            Algeria.AddNeighbor(SpanishAtlantic);
            Algeria.AddNeighbor(FrenchWestAfrica);
            Algeria.AddNeighbor(Libya);
            Algeria.AddNeighbor(FrenchEquatorialAfrica);

            Libya.AddNeighbor(MediterraneanSea);
            Libya.AddNeighbor(AngloEgyptSudan);
            Libya.AddNeighbor(FrenchEquatorialAfrica);
            
            AngloEgyptSudan.AddNeighbor(EastMediterraneanSea);
            AngloEgyptSudan.AddNeighbor(RedSea); // TODO wrong..
            AngloEgyptSudan.AddNeighbor(ItalianEastAfrica);
            AngloEgyptSudan.AddNeighbor(KenyaRhodesia);
            AngloEgyptSudan.AddNeighbor(BelgianCongo);
            AngloEgyptSudan.AddNeighbor(FrenchEquatorialAfrica);

            ItalianEastAfrica.AddNeighbor(RedSea); // TODO wrong..
            ItalianEastAfrica.AddNeighbor(KenyaRhodesia);

            RedSea.AddNeighbor(EastMediterraneanSea);
            RedSea.AddNeighbor(IndianOcean);
            RedSea.AddNeighbor(WestIndianOcean);

            RioDeOro.AddNeighbor(FrenchWestAfricaSea);
            RioDeOro.AddNeighbor(FrenchWestAfrica);

            FrenchWestAfrica.AddNeighbor(FrenchEquatorialAfrica);
            FrenchWestAfrica.AddNeighbor(FrenchWestAfricaSea);

            FrenchWestAfricaSea.AddNeighbor(SpanishAtlantic);
            FrenchWestAfricaSea.AddNeighbor(BelgianCongoSea);

            FrenchEquatorialAfrica.AddNeighbor(BelgianCongo);
            FrenchEquatorialAfrica.AddNeighbor(BelgianCongoSea);

            BelgianCongo.AddNeighbor(BelgianCongoSea);
            BelgianCongo.AddNeighbor(KenyaRhodesia);
            BelgianCongo.AddNeighbor(Angola);

            BelgianCongoSea.AddNeighbor(SouthAtlantic);
            BelgianCongoSea.AddNeighbor(AngolaSea);

            KenyaRhodesia.AddNeighbor(MadagascarSea);
            KenyaRhodesia.AddNeighbor(Mozambique);
            KenyaRhodesia.AddNeighbor(SouthAfrica);
            KenyaRhodesia.AddNeighbor(Angola);

            Mozambique.AddNeighbor(MadagascarSea);
            Mozambique.AddNeighbor(SouthAfrica);

            Angola.AddNeighbor(AngolaSea);
            Angola.AddNeighbor(SouthAfrica);

            AngolaSea.AddNeighbor(SouthAtlantic);
            AngolaSea.AddNeighbor(FarSouthAtlantic);
            AngolaSea.AddNeighbor(SouthAfricaSea);

            SouthAfrica.AddNeighbor(SouthAfricaSea);
            SouthAfrica.AddNeighbor(AngolaSea);

            SouthAfricaSea.AddNeighbor(MadagascarSea);
            SouthAfricaSea.AddNeighbor(SouthWestIndianOcean);

            Madagascar.AddNeighbor(MadagascarSea);
            Madagascar.AddNeighbor(SouthAfricaSea);
            Madagascar.AddNeighbor(WestIndianOcean);
            Madagascar.AddNeighbor(SouthWestIndianOcean);

            MadagascarSea.AddNeighbor(RedSea);
            MadagascarSea.AddNeighbor(WestIndianOcean);

            WestIndianOcean.AddNeighbor(EastIndianOcean);
            WestIndianOcean.AddNeighbor(IndianOcean);
            WestIndianOcean.AddNeighbor(SouthWestIndianOcean);
            WestIndianOcean.AddNeighbor(SouthEastIndianOcean);

            EastIndianOcean.AddNeighbor(IndianOcean);
            EastIndianOcean.AddNeighbor(WestAustraliaSea);
            EastIndianOcean.AddNeighbor(EastIndiesSea);
            EastIndianOcean.AddNeighbor(SouthEastIndianOcean);
            EastIndianOcean.AddNeighbor(SouthAustraliaSea);

            IndianOcean.AddNeighbor(SouthChinaSea);
            EastIndianOcean.AddNeighbor(EastIndiesSea);

            EastIndies.AddNeighbor(EastIndiesSea);

            EastIndiesSea.AddNeighbor(SouthChinaSea);
            EastIndiesSea.AddNeighbor(EastIndianOcean);
            EastIndiesSea.AddNeighbor(IndianOcean);
            EastIndiesSea.AddNeighbor(WestAustraliaSea);
            EastIndiesSea.AddNeighbor(EastAustraliaSea);
            EastIndiesSea.AddNeighbor(BorneoCelebsSea);

            BorneoCelebes.AddNeighbor(BorneoCelebsSea);

            BorneoCelebsSea.AddNeighbor(SouthChinaSea);
            BorneoCelebsSea.AddNeighbor(PhilipineIslandsSea);
            BorneoCelebsSea.AddNeighbor(CarolineIslandsSea);
            BorneoCelebsSea.AddNeighbor(NewGuineaSea);
            BorneoCelebsSea.AddNeighbor(EastAustraliaSea);

            PhilipineIslands.AddNeighbor(PhilipineIslandsSea);

            PhilipineIslandsSea.AddNeighbor(KwangtungSea);
            PhilipineIslandsSea.AddNeighbor(OkinawaSea);
            PhilipineIslandsSea.AddNeighbor(CarolineIslandsSea);
            PhilipineIslandsSea.AddNeighbor(SouthChinaSea);

            NewGuinea.AddNeighbor(NewGuineaSea);

            NewGuineaSea.AddNeighbor(CarolineIslandsSea);
            NewGuineaSea.AddNeighbor(SolomonIslandsSea);
            NewGuineaSea.AddNeighbor(EastAustraliaSea);

            CarolineIslands.AddNeighbor(CarolineIslandsSea);

            CarolineIslandsSea.AddNeighbor(OkinawaSea);
            CarolineIslandsSea.AddNeighbor(WakeIslandSea);
            CarolineIslandsSea.AddNeighbor(SolomonIslandsSea);
            
            Okinawa.AddNeighbor(OkinawaSea);

            OkinawaSea.AddNeighbor(SeaOfJapan);
            OkinawaSea.AddNeighbor(WakeIslandSea);

            WakeIsland.AddNeighbor(WakeIslandSea);

            WakeIslandSea.AddNeighbor(SeaOfJapan);
            WakeIslandSea.AddNeighbor(NorthPacificOcean);
            WakeIslandSea.AddNeighbor(HawaiianIslandsSea);
            WakeIslandSea.AddNeighbor(SolomonIslandsSea);

            SolomonIslands.AddNeighbor(SolomonIslandsSea);

            SolomonIslandsSea.AddNeighbor(SouthPacificOcean);
            SolomonIslandsSea.AddNeighbor(NewZealandSea);
            SolomonIslandsSea.AddNeighbor(EastAustraliaSea);
            SolomonIslandsSea.AddNeighbor(HawaiianIslandsSea);

            Australia.AddNeighbor(WestAustraliaSea);
            Australia.AddNeighbor(EastAustraliaSea);
            Australia.AddNeighbor(SouthAustraliaSea);

            WestAustraliaSea.AddNeighbor(EastIndiesSea);
            WestAustraliaSea.AddNeighbor(EastAustraliaSea);
            WestAustraliaSea.AddNeighbor(SouthAustraliaSea);

            SouthAustraliaSea.AddNeighbor(EastAustraliaSea);
            SouthAustraliaSea.AddNeighbor(SouthEastIndianOcean);
            SouthAustraliaSea.AddNeighbor(NewZealandSea);

            NewZealand.AddNeighbor(NewZealandSea);

            NewZealandSea.AddNeighbor(EastAustraliaSea);
            NewZealandSea.AddNeighbor(SouthAustraliaSea);
            NewZealandSea.AddNeighbor(SouthPacificOcean);
            
            NewZealandSea.AddNeighbor(FarSouthPacificOcean);

            HawaiianIslands.AddNeighbor(HawaiianIslandsSea);

            HawaiianIslandsSea.AddNeighbor(NorthPacificOcean);
            HawaiianIslandsSea.AddNeighbor(MidwayIslandSea);
            HawaiianIslandsSea.AddNeighbor(WesternUsaSea);
            HawaiianIslandsSea.AddNeighbor(WestMexicoSea);
            HawaiianIslandsSea.AddNeighbor(SouthPacificOcean);

            MidwayIsland.AddNeighbor(MidwayIslandSea);

            MidwayIslandSea.AddNeighbor(NorthPacificOcean);
            MidwayIslandSea.AddNeighbor(WesternUsaSea);
            MidwayIslandSea.AddNeighbor(BeringStrait);
            MidwayIslandSea.AddNeighbor(WesternCanadaSea);


            Alaska.AddNeighbor(BeringStrait);
            Alaska.AddNeighbor(WesternCanadaSea);
            Alaska.AddNeighbor(WesternCanada);

            WesternCanada.AddNeighbor(WesternCanadaSea);
            WesternCanada.AddNeighbor(WesternUsa);
            WesternCanada.AddNeighbor(WesternUsaSea);
            WesternCanada.AddNeighbor(EasternCanada);

            WesternUsa.AddNeighbor(WesternUsaSea);
            WesternUsa.AddNeighbor(Mexico);
            WesternUsa.AddNeighbor(EasternUsa);
            WesternUsa.AddNeighbor(GulfOfMexico);

            WestMexicoSea.AddNeighbor(MidwayIslandSea);
            WestMexicoSea.AddNeighbor(WesternCanadaSea);
            WestMexicoSea.AddNeighbor(HawaiianIslandsSea);

            Mexico.AddNeighbor(GulfOfMexico);
            Mexico.AddNeighbor(WestMexicoSea);

            WestMexicoSea.AddNeighbor(WesternUsaSea);
            WestMexicoSea.AddNeighbor(HawaiianIslandsSea);
            WestMexicoSea.AddNeighbor(SouthPacificOcean);
            WestMexicoSea.AddNeighbor(SouthEastPacificOcean);

            SouthPacificOcean.AddNeighbor(SouthEastPacificOcean);
            SouthPacificOcean.AddNeighbor(FarSouthPacificOcean);
        
            SouthEastPacificOcean.AddNeighbor(PeruSea);
            SouthEastPacificOcean.AddNeighbor(FarSouthPacificOcean);

            EasternCanada.AddNeighbor(EasternCanadaSea);
            EasternCanada.AddNeighbor(EasternUsa);
            
            EasternUsa.AddNeighbor(EasternUsaSea);

            WestIndies.AddNeighbor(CaribbeanSea);
            
            Panama.AddNeighbor(CaribbeanSea);
            Panama.AddNeighbor(VenezuelaColumbia);
            Panama.AddNeighbor(Mexico);

            CaribbeanSea.AddNeighbor(AtlanticOcean);
            CaribbeanSea.AddNeighbor(NorthBrazilSea);
            CaribbeanSea.AddNeighbor(PeruSea);
            CaribbeanSea.AddNeighbor(WestMexicoSea);

            VenezuelaColumbia.AddNeighbor(CaribbeanSea);
            VenezuelaColumbia.AddNeighbor(Brazil);
            VenezuelaColumbia.AddNeighbor(Peru);

            Brazil.AddNeighbor(Peru);
            Brazil.AddNeighbor(ArgentinaChile);
            Brazil.AddNeighbor(NorthBrazilSea);
            Brazil.AddNeighbor(SouthBrazilSea);

            SouthBrazilSea.AddNeighbor(NorthBrazilSea);
            SouthBrazilSea.AddNeighbor(FrenchWestAfricaSea);
            SouthBrazilSea.AddNeighbor(BelgianCongoSea);
            SouthBrazilSea.AddNeighbor(SouthAtlantic);

            NorthBrazilSea.AddNeighbor(CaribbeanSea);
            NorthBrazilSea.AddNeighbor(AtlanticOcean);
            NorthBrazilSea.AddNeighbor(FrenchWestAfricaSea);

            Peru.AddNeighbor(PeruSea);
            Peru.AddNeighbor(ArgentinaChile);

            PeruSea.AddNeighbor(SouthArgentinaSea);
            PeruSea.AddNeighbor(SouthEastPacificOcean);

            ArgentinaChile.AddNeighbor(EastArgentinaSea);
            ArgentinaChile.AddNeighbor(PeruSea);
            ArgentinaChile.AddNeighbor(SouthArgentinaSea);

            SouthArgentinaSea.AddNeighbor(SouthEastPacificOcean);
            SouthArgentinaSea.AddNeighbor(EastArgentinaSea);
            SouthArgentinaSea.AddNeighbor(SouthAtlantic);
            SouthArgentinaSea.AddNeighbor(FarSouthAtlantic);

            EastArgentinaSea.AddNeighbor(SouthBrazilSea);
            EastArgentinaSea.AddNeighbor(SouthAtlantic);
            
            #endregion

            // the indices
            TerritoryById = new Territory[id];
            TerritoryByName = new Dictionary<string, Territory>();
            foreach (var t in GetAllTerritories())
            {
                TerritoryById[t.Id] = t;
                TerritoryByName.Add(t.Name, t);
            }
        }

       
    }

    public class SeaTerritory : Territory
    {
        public SeaTerritory(int id, string name) : base(id, name)
        {
        }
    }

    public class CanalTerritory : SeaTerritory
    {
        public CanalTerritory(int id, string name) : base(id, name)
        {
        }
    }

    public class LandTerritory : Territory
    {
        public LandTerritory(int id, string name, int manufacturingPoints)
            : base(id, name)
        {
            ManufacturingPoints = manufacturingPoints;
        }

        
    }

    public class NeutralTerritory : LandTerritory
    {
        public NeutralTerritory(int id, string name) : base(id, name, 0)
        {
        }
    }

    public class CapitalTerritory : LandTerritory
    {
        public CapitalTerritory(int id, string name, int manufacturingPoints)
            : base(id, name, manufacturingPoints)
        {
        }
    }
}