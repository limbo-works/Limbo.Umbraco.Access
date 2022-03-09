using System;
using Limbo.Umbraco.UserPermissions.Rules.Constants;
using Umbraco.Core.Events;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace Limbo.Umbraco.UserPermissions.Rules.Components {
    public class RulesComponentBase {
        private readonly ILocalizationService _localizationService;
        private readonly IProfilingLogger _logger;
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;

        public RulesComponentBase(IUmbracoContextAccessor umbracoContextAccessor, IProfilingLogger logger, ILocalizationService localizationService) {
            _umbracoContextAccessor = umbracoContextAccessor;
            _logger = logger;
            _localizationService = localizationService;
        }

        protected void CheckActionValid(Func<bool> action, CancellableObjectEventArgs e) {
            if (action != null) {
                if (!action.Invoke()) {
                    GetTranslatedMessages(out string category, out string message);
                    e.CancelOperation(new EventMessage(category, message, EventMessageType.Error));
                }
            }
        }

        protected void CheckActionValid(Func<bool> action, CancellableEventArgs e) {
            if (action != null) {
                if (!action.Invoke()) {
                    GetTranslatedMessages(out string category, out string message);
                    e.CancelOperation(new EventMessage(category, message, EventMessageType.Error));
                }
            }
        }

        protected void GetTranslatedMessages(out string category, out string message) {
            category = RuleConstants.DefaultErrorCategory;
            message = RuleConstants.DefaultErrorMessage;
            try {
                var currentUser = _umbracoContextAccessor.UmbracoContext.Security.CurrentUser;
                var languageId = _localizationService.GetLanguageIdByIsoCode(currentUser.Language);
                if (languageId != null) {
                    var categoryItem = _localizationService.GetDictionaryItemByKey(RuleConstants.ErrorCategoryKey);
                    if (categoryItem != null) {
                        category = categoryItem.GetTranslatedValue(languageId.GetValueOrDefault());
                    }
                    var messageItem = _localizationService.GetDictionaryItemByKey(RuleConstants.ErrorMessageKey);
                    if (messageItem != null) {
                        message = messageItem.GetTranslatedValue(languageId.GetValueOrDefault());
                    }
                }
            } catch (Exception ex) {
                _logger.Warn<ContentRulesComponent>(ex, "Error getting dictionary items");
            }
        }
    }
}