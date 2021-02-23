﻿using System.Collections.Generic;

namespace Backtrace.Unity.Common
{
    /// <summary>
    /// Extensions method to dictionary data structure
    /// </summary>
    internal static class DictionaryExtensions
    {
        /// <summary>
        /// Merge two dictionaries
        /// If there is any key conflict value from source dictionary is taken
        /// </summary>
        /// <param name="source">Source dictionary (dictionary from report)</param>
        /// <param name="toMerge">merged dictionary (</param>
        /// <returns>Merged dictionary</returns>
        internal static Dictionary<string, string> Merge(
            this Dictionary<string, string> source, Dictionary<string, string> toMerge)
        {
            if(source == null && toMerge == null)
            {
                return new Dictionary<string, string>();
            }

            if (source == null)
            {
                source = new Dictionary<string, string>();
            }
            if (toMerge == null)
            {
                toMerge = new Dictionary<string, string>();
            }
            var result = new Dictionary<string, string>(source);
            foreach (var record in toMerge)
            {
                if (!result.ContainsKey(record.Key))
                {
                    result.Add(record.Key, record.Value);
                }
            }

            return result;
        }
    }
}
