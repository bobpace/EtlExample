using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EtlExample.Refactor
{
    public static class Extensions
    {
        public static string ChangeFirstLetterToLower(this string input)
        {
            if (input == null) return null;
            var chars = input.ToCharArray();
            chars[0] = char.ToLower(chars[0]);
            return new string(chars);
        }

        public static KeyValuePair<TKey, TValue> ChangeValue<TKey, TValue>(this KeyValuePair<TKey, TValue> item, Func<TValue, TValue> provideNewValue)
        {
            Debug.WriteLine("changing value");
            var oldValue = item.Value;
            var newValue = provideNewValue(oldValue);
            return new KeyValuePair<TKey, TValue>(item.Key, newValue);
        }
    }
}