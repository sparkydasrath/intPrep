using System;
using System.Collections.Generic;
using System.Linq;

namespace Backtracking
{
    public class RestoreIpAddresses
    {
        /*
         93. Restore IP Addresses https://leetcode.com/problems/restore-ip-addresses/
        Medium

        Given a string containing only digits, restore it by returning all possible valid IP address combinations.

        Example:

        Input: "25525511135"
        Output: ["255.255.11.135", "255.255.111.35"]

         */

        private readonly List<string> results = new List<string>();

        public List<string> RestoreIpAddressesImpl(string s)
        {
            /*
             The idea is to pick 1, then 2, then 3 chars at a time
             A subsection is only valid if it is less than or equal to 255

            We know we need to have 4 dots as well, so may need to keep track of that

             */
            List<string> accumulator = new List<string>();
            RestoreIpAddressesDfs(s, accumulator);
            return results;
        }

        private bool IsIpValid(List<string> ipList)
        {
            int?[] converted = new int?[ipList.Count];

            for (int i = 0; i < converted.Length; i++)
            {
                if (ipList[i].StartsWith("0") && ipList[i].Length > 1)
                {
                    converted[i] = null;
                    continue;
                }
                converted[i] = Convert.ToInt32(ipList[i]);
            }

            if (converted.Any(c => c > 255 || c == null)) return false;
            return true;
        }

        private void RestoreIpAddressesDfs(string ip, List<string> accumulator)
        {
            if (accumulator.Count == 4 && ip.Length != 0) return; // this is bad path so backtrack

            if (accumulator.Count == 4 && ip.Length == 0)
            {
                if (IsIpValid(accumulator))
                {
                    results.Add(string.Join(".", accumulator));
                    return;
                }
            }

            if (ip.Length >= 1)
            {
                accumulator.Add(ip.Substring(0, 1)); // take one char
                // recurse without the first char
                RestoreIpAddressesDfs(ip.Substring(1), new List<string>(accumulator));
                // remove the last added char
                accumulator.RemoveAt(accumulator.Count - 1);
            }

            if (ip.Length >= 2)
            {
                accumulator.Add(ip.Substring(0, 2)); // take one char
                // recurse without the first char
                RestoreIpAddressesDfs(ip.Substring(2), new List<string>(accumulator));
                // remove the last added char
                accumulator.RemoveAt(accumulator.Count - 1);
            }

            if (ip.Length >= 3)
            {
                accumulator.Add(ip.Substring(0, 3)); // take one char
                // recurse without the first char
                RestoreIpAddressesDfs(ip.Substring(3), new List<string>(accumulator));
                // remove the last added char
                accumulator.RemoveAt(accumulator.Count - 1);
            }
        }
    }
}