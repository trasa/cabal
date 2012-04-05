using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Cabal.Core.Shared.Model
{
    [DataContract]
    public class GetTerritoryStateRequest
    {
        public GetTerritoryStateRequest()
        {
        }

        public GetTerritoryStateRequest(string authToken, int gameId, int territoryId)
        {
            AuthToken = authToken;
            GameId = gameId;
            TerritoryId = territoryId;
        }


        [DataMember]
        public string AuthToken { get; set;}

        [DataMember]
        public int GameId { get; set; }
        
        [DataMember]
        public int TerritoryId { get; set; }
    }
}
