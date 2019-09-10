using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiddlewareExample.Validator
{
    public class Validate
    {
        public static bool IsStringContainsOnlyLetters(string value)
        {
            return Regex.IsMatch(value, @"^[a-zA-Z]+$");
        }
        public static bool IsIdPositiveNumber(int id)
        {
            return id > 0;
        }
    }
}
