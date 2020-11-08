using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsProject.Common
{
    public static class InputValidator
    {
        public static bool IsPositiveInteger(string input)
        {
            int result;
            try
            {
                result = Int32.Parse(input);
                return result > 0;
            }
            catch (Exception)
            {
                //TODO Logginng
            }
            return false;
        }

        public static bool IsInitialCommpassValid(char letter)
        {
            return Constanst.initialCompass.Contains(letter);
        }

        public static bool IsInitialCommpassValid(string letter)
        {
            if (string.IsNullOrEmpty(letter))
                return false;

            var letterArry = letter.ToCharArray();

            if (letterArry.Count() > 1)
                return false;

            return Constanst.initialCompass.Contains(letterArry[0]);
        }

        public static bool IsDirectiveListValid(string letters)
        {
            if (string.IsNullOrEmpty(letters))
                return false;

            var letterArry = letters.ToCharArray();

            foreach (var item in letterArry)
            {
                if (!Constanst.Directives.Contains(item))
                    return false;
            }

            return true;
        }

        public static bool IsCompassDegreeValid(int compassDegree)
        {
            return Constanst.Compass.Contains(compassDegree);
        }
    }
}
