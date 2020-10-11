using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ArtShop.Framework.Common
{
     public static class ServiceFactory
    {
        public static THelper Get<THelper>()
        {
            if (HttpContext.Current == null)
                return DependencyResolver.Current.GetService<THelper>();

            var key = string.Concat("factory-", typeof(THelper).Name);
            if (HttpContext.Current.Items.Contains(key))
                return (THelper)HttpContext.Current.Items[key];

            var resolvedService = DependencyResolver.Current.GetService<THelper>();
            HttpContext.Current.Items.Add(key, resolvedService);
            return (THelper)HttpContext.Current.Items[key];
        }
    }
}
