﻿using System;
using System.Collections.Generic;

namespace EtlExample.Refactor
{
    public static class Extensions
    {
        public static string ChangeFirstLetterToLower(this string input)
        {
            var chars = input.ToCharArray();
            chars[0] = char.ToLower(chars[0]);
            return new string(chars);
        }

        public static KeyValuePair<TKey, TValue> ChangeValue<TKey, TValue>(this KeyValuePair<TKey, TValue> item, Func<TValue, TValue> provideNewValue)
        {
            var oldValue = item.Value;
            var newValue = provideNewValue(oldValue);
            return new KeyValuePair<TKey, TValue>(item.Key, newValue);
        }
    }
}