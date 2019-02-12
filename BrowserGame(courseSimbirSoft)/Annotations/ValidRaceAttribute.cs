using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserGame_courseSimbirSoft_.Annotations
{
    public class ValidRaceAttribute : ValidationAttribute
    {
        private string[] myRaces;
        public ValidRaceAttribute(string[] races)
        {
            myRaces = races;
        }
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string strval = value.ToString();
                for (int i=0; i<myRaces.Length; i++)
                {
                    if (strval == myRaces[i])
                        return true;
                }
            }
            return false;
        }
    }
}
