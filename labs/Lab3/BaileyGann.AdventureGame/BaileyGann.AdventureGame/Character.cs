using System;

namespace BaileyGann.AdventureGame
{
    public class Character
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Proffesion {
          get  { return _profession; }
          set { _profession = value.ToUpper(); }
        }
        private string _profession;
        public string Race
        {
            get { return _race; }
            set { _race = value.ToUpper(); }
        }
        private string _race;
        public double[] Attributes { get; set; }


        public string Validate ()
        {
            int x = 0;

            if (String.IsNullOrEmpty(Name))
                return $"A name is required.";

            switch (Proffesion)
            {
                case "WIZARD":; break;
                case "FIGHTER":; break;
                case "WARLOCK":; break;
                case "ROGUE":; break;
                case "DRUID":; break;
                default: x = 1; break;
            };

            switch (Race)
            {
                case "VAMPIRE":; break;
                case "HUMAN"  :; break;
                case "PIXIE"  :; break;
                case "ELF"    :; break;
                case "PHANTOM":; break;
                default: x = 2; break;
            };

            for(int i = 0; i < 5; i++)
            {
                if (Attributes[i] > 100 || Attributes[i] < 0)
                    x = 3;
            }

            switch (x)
            {
                case 1:; return $"Please choose a valid Profession";
                case 2:; return $"Please choose a valid Race";
                case 3:; return $"All Attributes must be between 0 and 100";
                default:; return null;
            }
        }
    }
     //Story_1 : Complete
     //Story_2
     //Story_3
     //Story_4
     //Story_5
     //Story_6
     //Story_7
     //Story_8
     //Story_9

}
