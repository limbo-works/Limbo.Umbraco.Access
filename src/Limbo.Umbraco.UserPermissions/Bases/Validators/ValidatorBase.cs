using Umbraco.Core.Logging;
using Umbraco.Core.Models.Membership;
using Umbraco.Web;

namespace Limbo.Umbraco.UserPermissions.Bases.Validators {
    public class ValidatorBase {
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;
        private readonly ILogger _logger;

        public ValidatorBase(IUmbracoContextAccessor umbracoContextAccessor, ILogger logger) {
            _umbracoContextAccessor = umbracoContextAccessor;
            _logger = logger;
        }

        protected IUser GetCurrentUser() {
            if(_umbracoContextAccessor == null || _umbracoContextAccessor.UmbracoContext == null || _umbracoContextAccessor.UmbracoContext.Security == null) {
                _logger.Warn(typeof(ValidatorBase), "User not found");
                return null;
            }
            return _umbracoContextAccessor.UmbracoContext.Security.CurrentUser;
        }
    }
}