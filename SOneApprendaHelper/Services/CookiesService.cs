using System;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SOneApprendaHelper.Services
{
    public class CookiesService
    {
        public T Get<T>(HttpCookieCollection cookies, string key) where T : new()
        {
            if (cookies.AllKeys.Contains(key))
            {
                var cookie = cookies[key];
                if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
                {
                    return JsonConvert.DeserializeObject<T>(cookie.Value);
                }
            }

            return new T();
        }

        public void Set<T>(HttpCookieCollection cookies, string key, T value, DateTime expires)
        {
            var data = JsonConvert.SerializeObject(value);
            var cookie = new HttpCookie(key, data) { Expires = expires };
            cookies.Add(cookie);
        }
    }
}