using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day_4
{
    public class Passport
    {
        public int Byr { get; set; }     //Birth year
        public int Iyr { get; set; }     //Issue year
        public int Eyr { get; set; }     //Expiration year
        public string Hgt { get; set; }  //Height
        public string Hcl { get; set; }  //Hair Color
        public string Ecl { get; set; }  //Eye Color
        public string Pid { get; set; }     //Passport ID
        public string Cid { get; set; }     //Country ID
        
        
        public bool IsValidPart1()
        {
            if (Byr == 0) return false;
            if (Iyr == 0) return false;
            if (Eyr == 0) return false;
            if (Pid == null) return false;
            if (Hgt == null) return false;
            if (Hcl == null) return false;
            if (Ecl == null) return false;

            return true;
        }

        public bool IsValid()
        {
            if (Byr < 1920 || Byr > 2002) return false;
            if (Iyr < 2010 || Iyr > 2020) return false;
            if (Eyr < 2020 || Eyr > 2030) return false;
            if (Pid == null || Pid.Length != 9) return false;

            if (!HasValidHeight()) return false;
            if (!HasValidEyeColor()) return false;
            if (!HasValidHairColor()) return false;

            return true;
        }

        private bool HasValidHeight()
        {
            if (Hgt == null) return false;
            var type = Regex.Match(Hgt, @"\D+").Groups[0].Value;
            var num = int.Parse(Regex.Match(Hgt, @"(\w+)(\d+)").Groups[0].Value);

            if (type == "cm")
            {
                if (num >= 150 && num <= 193)
                {
                    return true;
                }
                return false;
            }

            if (type == "in")
            {
                if (num >= 59 && num <= 76)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        private bool HasValidEyeColor()
        {
            if (Ecl == "amb" || 
                Ecl == "blu" || 
                Ecl == "brn" || 
                Ecl == "gry" || 
                Ecl == "grn" || 
                Ecl == "hzl" ||
                Ecl == "oth")
            {
                return true;
            }
            return false;
        }

        private bool HasValidHairColor()
        {
            if (Hcl == null) return false;
            if (Hcl[0] != '#') return false;
            if (Hcl.Length != 7) return false;
            var colorID = Hcl.Substring(1);
            
            return Regex.IsMatch(colorID, @"\A\b[0-9a-f]+\b\Z");
        }
    }
}