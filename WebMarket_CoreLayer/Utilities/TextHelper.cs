﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket_CoreLayer.Utilities
{
    public static class TextHelper
    {
        public static string ToSlug(this string value)
        {
            return value.Trim().ToLower()
                .Replace("~", "")
                .Replace("@", "")
                .Replace("#", "")
                .Replace("$", "")
                .Replace("%", "")
                .Replace("^", "")
                .Replace("&", "")
                .Replace("*", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("+", "")
                .Replace(" ", "-")
                .Replace(">", "")
                .Replace("<", "")
                .Replace(@"\", "")
                .Replace("/", "");
        }

        //public static string ConvertHtmlToText(this string text)
        //{
        //    return Regex.Replace(text, "<.*?>", " ")
        //        .Replace(":&nbsp;", " ");
        //}
    }
}
