using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaileyGann.AdventureGame
{
    public class Character : IValidatableObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Proffesion {
            get { return _profession; }
            set { _profession = value.ToUpper(); }
        }
        private string _profession;
        public string Race
        {
            get { return _race; }
            set { _race = value.ToUpper(); }
        }
        private string _race;
        public int Strength { get; set; } = 50;
        public int Dexterity { get; set; } = 50;
        public int Constitution { get; set; } = 50;
        public int Intelligence { get; set; } = 50;
        public int Charisma { get; set; } = 50;
        public int Id {get; set; }
        


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
            return $"{Name}, {Id}";
        }

        public Character Copy ()
        {
            return new Character() {
                Id = Id,
                Name = Name,
                Description = Description,
                Proffesion = Proffesion,
                Race = Race,
                Strength = Strength,
                Dexterity = Dexterity,
                Constitution = Constitution,
                Intelligence = Intelligence,
                Charisma = Charisma,
            };
        }

        public void CopyFrom( Character source )
        {
            Name = source.Name;
            Description = source.Description;
            Race = source.Race;
            Proffesion = source.Proffesion;
            Description = source.Description;
            Strength = source.Strength;
            Dexterity = source.Dexterity;
            Intelligence = source.Intelligence;
            Charisma = source.Charisma;
            Constitution = source.Constitution;
        }

        public IEnumerable<ValidationResult> Validate (ValidationContext validationContext)
        {
            if (String.IsNullOrEmpty(Name))
                yield return new ValidationResult("Name is required", new[] { nameof(Name) });
            if (String.IsNullOrEmpty(Race))
                yield return new ValidationResult("Race is required", new[] { nameof(Race) });
            if(String.IsNullOrEmpty(Proffesion))
                yield return new ValidationResult("Profession is required", new[] { nameof(Proffesion) });

            if (Strength > 100 || Strength < 1)
                yield return new ValidationResult("Attributes must be less than 101 and greater than 0", new[] { nameof(Strength) });

            if (Dexterity > 100 || Dexterity < 1)
                yield return new ValidationResult("Attributes must be less than 101 and greater than 0", new[] { nameof(Dexterity) });

            if (Constitution > 100 || Constitution < 1)
                yield return new ValidationResult("Attributes must be less than 101 and greater than 0", new[] { nameof(Constitution) });

            if (Intelligence > 100 || Intelligence < 1)
                yield return new ValidationResult("Attributes must be less than 101 and greater than 0", new[] { nameof(Intelligence) });

            if (Charisma > 100 || Charisma < 1)
                yield return new ValidationResult("Attributes must be less than 101 and greater than 0", new[] { nameof(Charisma) });
        }
    }
     

}
