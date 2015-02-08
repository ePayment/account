using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Common.Utilities
{
    public static class Compare
    {
    public static bool MatchWildcardString(String pattern, String input)
    {
        if (String.Compare(pattern, input) != 0)
        {
            if (String.IsNullOrEmpty(input))
            {
                if (!String.IsNullOrEmpty(pattern.Trim(new Char[1] {'*'})))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (pattern.Length == 0)
            {
                return false;
            }
            else if (pattern[0] == '?')
            {
                return MatchWildcardString(pattern.Substring(1), input.Substring(1));
            }
            else if (pattern[pattern.Length - 1] == '?')
            {
                return MatchWildcardString(pattern.Substring(0, pattern.Length - 1),
                                           input.Substring(0, input.Length - 1));
            }
            else if (pattern[0] == '*')
            {
                if (!MatchWildcardString(pattern.Substring(1), input))
                {
                    return MatchWildcardString(pattern, input.Substring(1));
                }
                else
                {
                    return true;
                }
            }
            else if (pattern[pattern.Length - 1] == '*')
            {
                if (!MatchWildcardString(pattern.Substring(0, pattern.Length - 1), input))
                {
                    return MatchWildcardString(pattern, input.Substring(0, input.Length - 1));
                }
                else
                {
                    return true;
                }
            }
            else if (pattern[0] == input[0])
            {
                return MatchWildcardString(pattern.Substring(1), input.Substring(1));
            }
        }
        else
        {
            return true;
        }
        return false;
    }
    }
}
