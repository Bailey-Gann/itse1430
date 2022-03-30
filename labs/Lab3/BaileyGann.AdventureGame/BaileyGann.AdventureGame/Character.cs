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
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }
        


        public string Validate ()
        {
            int x = 0;
            int y = 0;
            int z = 0;
            string output = "";

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
                default: y = 2; break;
            };

            
                if ((Strength > 100 || Strength < 0) ||
                (Dexterity > 100 || Dexterity < 0) ||
                (Constitution > 100 || Constitution < 0) || 
                (Intelligence > 100 || Intelligence < 0)|| (Charisma > 100 || Charisma < 0))
                  {
                      z = 3;
                    }
                    
            

            if (x != 0)
                output = "Please choose a valid Profession\n";
            if (y != 0)
                output += "Please choose a valid Race\n";
            if (z != 0)
                output+= "Please ensure all Attributes are between 0 and 100\n";

            return output;
        }

        public override string ToString ()
        {
            return Name;
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
