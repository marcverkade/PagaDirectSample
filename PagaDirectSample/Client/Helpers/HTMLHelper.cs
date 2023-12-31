﻿using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace PagaDirect.Client.Helpers
{
    public static class HTMLHelper
    {
        /// <summary>
        /// Checks if an URl is valid
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsValidUrl(string url)
        {
            Uri? uriResult;
            bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            return result;
        }
    }
}
