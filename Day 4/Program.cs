using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("Input.txt");
            var passportInput = input.Split(new[] {Environment.NewLine + Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            List<Passport> passports = ParseToPassports(passportInput);
            Part1(passports);
            Part2(passports);
        }

        private static void Part1(List<Passport> passports)
        {
            var validPassports = passports.Count(passport => passport.IsValidPart1());
        
            Console.WriteLine(validPassports);
        }

        private static void Part2(List<Passport> passports)
        {
            var validPassports = passports.Count(passport => passport.IsValid());
            
            Console.WriteLine(validPassports);
        }
        
        
        
        private static List<Passport> ParseToPassports(string[] input)
        {
            List<Passport> passports = new List<Passport>();

            foreach (var passportString in input)
            {
                Passport passport = new Passport();
                
                var oneLine = passportString.Replace(System.Environment.NewLine, " ");
                var values = oneLine.Split(" ");
                foreach (var value in values)
                {
                    SetPassportValue(passport,value);
                }
                passports.Add(passport);
            }
            return passports;
        }


        private static void SetPassportValue(Passport passport, string input)
        {
            var entry = input.Split(":");
            if (entry.Length < 2) return;
            var identifier = entry[0];
            var value = entry[1];

            if (identifier == "byr")
            {
                passport.Byr = int.Parse(value);
            }

            else if (identifier == "iyr")
            {
                passport.Iyr = int.Parse(value);
            }

            else if (identifier == "eyr")
            {
                passport.Eyr = int.Parse(value);
            }

            else if (identifier == "hgt")
            {
                passport.Hgt = value;
            }

            else if (identifier == "hcl")
            {
                passport.Hcl = value;
            }

            else if (identifier == "ecl")
            {
                passport.Ecl = value; 
            }

            else if (identifier == "pid")
            {
                passport.Pid = value;
            }

            else if (identifier == "cid")
            {
                passport.Cid = value;
            }
        }
    }
}