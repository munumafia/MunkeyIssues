using System.Collections.Generic;
using MunkeyIssues.Api.Models.Resources;

namespace MunkeyIssues.Api.Extensions
{
    public static class LinkDictionaryExtensions
    {
        public static void AddLink(this IDictionary<string, HypermediaLink> dict, string name, string href, bool templated = false)
        {
            dict[name] = new HypermediaLink
            {
                Href = href,
                Templated = templated
            };
        }

        public static void AddSelf(this IDictionary<string, HypermediaLink> dict, string href, bool templated = false)
        {
            dict.AddLink("self", href, templated);
        }
    }
}