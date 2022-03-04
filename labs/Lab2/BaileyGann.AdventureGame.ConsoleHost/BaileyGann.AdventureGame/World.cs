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
        public string getName(int id)
        {
            return _roomNames[id -1];
        }

        #region stringArray fields
        string[] _roomNames = { "The Great Hall", "The Dwarven Kitchen", "The Arcane Library",
            "The Dungeons", "Dragon Hatchery", "The Courtyard",
            "The Ruined Tower", "The Hearth", "The Gardens" };

        string[] _roomDescriptions = { "A large hallway enlaid with gold. Two stairways are visible, as well as one statue with a missing left arm.", 
                "A kitchen with shortened ceilings, heavy stone tables, and short stocky people working over ovens and pots. \nThe sweet aroma of fresh meat and warm bread greets you."
          , "A room 6 floors high, with books covering most every wall and even the air. \nYes, the books can fly. \nYou duck as you walk in the door to avoid being smashed by an encyclopedia.",
         "Stinky, damp, moldy... \nIs that a dead body? Gross. \nNo one wants to be down here, yet here you came. You probably want to leave...", 
         "A very moist, very hot, very large room occupied by one very protective female dragon and her three eggs. I don't care how brave you are, I suggest leaving if you value your head.",
         "An open space with green trees, colorful flowers, a small pond complete wih fountain in the center. Birds are constantly seen in and around this yard.", 
         "The oldest part of the castle... \nSupposedly haunted by the late Lord Danzu turned vampire, \n\tthough no one is brave enough to spend the night in this creepy, chilly tower. \n\t\tIs that shadow moving???",
          "A large but cozy room. The center is occupied by a fire pit, tending always by a servant or two. \nPeople gather in this room in the evening when the night is cold.",
          "The tomato gardens were planted by the late Lord Danzu's daughter, though she is gone. \nFor fear of his spirit haunting the castle, the servants keep the garden pristine and healthy."};
        #endregion
    }
}
