using System;

namespace BaileyGann.AdventureGame
{
    class Room
    {
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _name;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private int _id;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private string _description;
    }

    class World
    {
        public string[] rooms;

        public string WorldDescription
        {
            get { return _wDescription; }
        }
        private string _wDescription = "\nWelcome to Hydrexel!\nA land of magic, dragons, war and sometimes peace, many who enter die.\n";

        //TODO: Implement 9 rooms
        //Room '0' in array is starting room
    }

    class Player
    {
        public int RoomNum
        {
            get { return _roomNum; }
            set { _roomNum = value; }
        }
        private int _roomNum;
    }
}
