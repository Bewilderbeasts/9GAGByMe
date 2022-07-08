using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Extensions
{
    public static class StringExtenstions
    {
        public static bool Empty(this string value)
            => string.IsNullOrWhiteSpace(value);
    }
}

