using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Cabal.Core.Shared.Model
{
    [DataContract]
    public class GetBoardStateRequest
    {
        public GetBoardStateRequest()
        {
        }

        public GetBoardStateRequest(string authToken, int gameId)
        {
            AuthToken = authToken;
            GameId = gameId;
        }

        [DataMember]
        public string AuthToken { get; set; }
        [DataMember]
        public int GameId { get; set;}
    }
}
