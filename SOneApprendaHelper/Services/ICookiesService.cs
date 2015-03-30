using System;
using System.Web;

namespace SOneApprendaHelper.Services
{
    public interface ICookiesService
    {
        T Get<T>(HttpCookieCollection cookies, string key);

        void Set<T>(HttpCookieCollection cookies, string key, T value, DateTime expires);
    }
}