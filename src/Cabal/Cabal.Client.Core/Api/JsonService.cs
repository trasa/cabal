
namespace Cabal.Client.Core.Api
{
    public abstract class JsonService
    {
        // TODO belongs in a config file
        protected string ServerUrl {get { return "http://localhost:16180";}}


        protected WebClientProxy<TResult> GetClient<TResult>(string controllerAction)
        {
            // TODO change to building a Url object instead
            if (!controllerAction.StartsWith("/"))
                controllerAction = "/" + controllerAction;
            return new WebClientProxy<TResult>(ServerUrl + controllerAction);
        }
    }
}
