using System;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;

namespace backend.Code.Utils {

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class QueryStringConstraintAttribute: ActionMethodSelectorAttribute {

        private string Name { get; set; }
        private bool Present { get; set; }

        public QueryStringConstraintAttribute(string name, bool present) {
            this.Name = name;
            this.Present = present;
        }

        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action) {
            var value = routeContext.HttpContext.Request.Query[this.Name];
            if (this.Present) {
                return !String.IsNullOrEmpty(value);
            }

            return String.IsNullOrEmpty(value);
        }
    }
}
