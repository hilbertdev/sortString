﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace sortString.Library
{
    public class sortString
    {
        public static string GetValue(string input)
        {
            if (input.Length == 0)
            {
                return "Please Enter A String";
            }
            else
            {
                var regexItem = new Regex(@"[^0-9a-zA-Z]+");
                string removedSpecials = Regex.Replace(input, regexItem.ToString(), String.Empty);
                string finalForm = removedSpecials.ToLower();
                char temp;
                char[] characters = finalForm.ToCharArray();
                for(int i = 1; i < characters.Length; i++)
                {
                    for(int ix = 0; ix < characters.Length - 1; ix++)
                    {
                        if(characters[ix] > characters[ix + 1])
                        {
                            temp = characters[ix];
                            characters[ix] = characters[ix + 1];
                            characters[ix + 1] = temp;
                        }
                    }
                }
                string str = new string(characters);
                return str;
            }

        }
    }
}
