using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaileyGann.AdventureGame
{
    public class World
    {
        #region fields
        Room[] _rooms = new Room[9];

        public string WorldDescription
        {
            get { return _wDescription; }
        }
        private string _wDescription = "\nWelcome to Hydrexel!\nA land of magic, dragons, war and sometimes peace.\nYou find yourself in a castle," +
            " in a large hall. Two key stairways" +
            "are visible. Good luck...\n";
        #endregion


        
        public World ()
        {
            
        }


        //Implement 9 rooms
        //    Room '0' in array is starting room
        //    Set room IDs
        //    Set room names
        //    Set room descriptions
        public void CreateRooms ()
        {
            for (int i = 0; i < 9; i++)
            {
                _rooms[i] = new Room();
                _rooms[i].Id = i + 1;
                _rooms[i].Name = _roomNames[i];
                _rooms[i].Description = _roomDescriptions[i];
            }
        }

        public string getDescription(int id )
        {
            return _roomDescriptions[id - 1];
        }

        #region stringArray fields
        string[] _roomNames = { "The Great Hall", "The Dwarven Kitchen", "The Arcane Library", "The Dungeons", "Dragon Hatchery", "The Courtyard",
            "The Ruined Tower", "The Hearth", "The Gardens" };

        string[] _roomDescriptions = { "A large hallway enlaid with gold. Two stairways are visible, as well as one statue with a missing left arm.", 
                "A kitchen with shortened ceilings, heavy stone tables, and short stocky people working over ovens and pots. The sweet aroma of fresh meat and warm bread greets you."
          , "A room 6 floors high, with books covering most every wall and even the air. Yes, the books can fly. You duck as you walk in the door to avoid being smashed by an encyclopedia.",
         "Stinky, damp, moldy... is that a dead body? Gross. No one wants to be down here, yet here you came. You probably want to leave...", 
         "A very moist, very large room occupied by one very protective female dragon and her three eggs. I don't care how brave you are, I suggest leaving if you value your head.",
         "", 
         "",
          "",
          ""};
        #endregion
    }
}
