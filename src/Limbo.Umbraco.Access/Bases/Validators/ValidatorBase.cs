using Umbraco.Core.Models.Membership;
using Umbraco.Web;

namespace Limbo.Umbraco.Access.Bases.Validators {
    public class ValidatorBase {
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;

        public ValidatorBase(IUmbracoContextAccessor umbracoContextAccessor) {
            _umbracoContextAccessor = umbracoContextAccessor;
        }

        protected IUser GetCurrentUser() {
            return _umbracoContextAccessor.UmbracoContext.Security.CurrentUser;
        }
    }
}