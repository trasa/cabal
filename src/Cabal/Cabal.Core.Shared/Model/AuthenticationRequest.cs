
using System.Runtime.Serialization;

namespace Cabal.Core.Shared.Model
{
    [DataContract]
    public class AuthenticationRequest
    {
        public AuthenticationRequest()
        {
            
        }

        public AuthenticationRequest(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        [DataMember]
        public string UserName { get; set; }
        
        [DataMember]
        public string Password { get; set; }
    }
}
