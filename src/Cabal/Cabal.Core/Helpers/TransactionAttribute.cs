using System.Web.Mvc;
using Blackfin.Core.NHibernate;
using NHibernate;
using StructureMap;

namespace Cabal.Core.Helpers
{
    public class TransactionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ObjectFactory.GetInstance<NHibernateSession>().Current.BeginTransaction();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ISession session = ObjectFactory.GetInstance<NHibernateSession>().Current;

            if (filterContext.Exception == null && session.Transaction.IsActive)
            {
                session.Transaction.Commit();
            }
        }
    }
}
