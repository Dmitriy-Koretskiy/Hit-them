using System;
using System.Collections.Generic;

namespace Hit_them
{
    public class Info
    {
        public string Name{ get; set; }
        public int Score{ get; set; }
        public LevelType Level { get; set; }
        public string Date{ get; set; }
        
        // стандартный конструктор без параметров

        public Info()
        { }

        public Info(string nameinter, int scoreinter, LevelType level, string dateinter)
        {
            Name = nameinter;
            Score = scoreinter;
            Level = level;
            Date = dateinter;
            
        }
    }
   

    
    public enum LevelType
    {
        Easy,
        Normal,
        Hard,
    }

    public enum Conditions
    {
        Empty,
        Heg,
        Bev
    };

    public class Gameplay
    {
        public static List<Info> Base = new List<Info>();
        public static int UserScore = 0;
        public static LevelType Level;
        public static string Username = "";
        public static Conditions[] Place = new Conditions[9];

        public static void Generation()
        {
            var d = new Random();
            int temp = d.Next(0, 9); // place
            int temp1 = d.Next(0, 2); // shape
            for (int i = 0; i < 9; i++)
            {
                if (i == temp)
                {
                    if (temp1 == 0 || Level == LevelType.Easy)
                        Place[i] = Conditions.Bev;
                    else
                        Place[i] = Conditions.Heg;
                }
                else
                {
                    Place[i] = Conditions.Empty;
                }
            }
        }
    }
}
