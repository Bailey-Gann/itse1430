using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaileyGann.AdventureGame
{
    
        public class Player
        {
            public Player ()
            {
                RoomNum = 1;
            }    

            public int RoomNum
            {
                get { return _roomNum; }
                set { _roomNum = value; }
            }
            private int _roomNum;


            public void MoveTo ( int roomNumber )
            {
                RoomNum = roomNumber;
            }

        public int[] getRoomChoices ()
        {
            int[] list;
            if (_roomNum == 1)
            {
                list = new int[] { 2, 4 };
            } else if (_roomNum == 2)
            {
                list = new int[] { 1, 3, 5 };
            } else if (_roomNum == 3)
            {
                list = new int[] { 2, 6 };
            } else if (_roomNum == 4)
            {
                list = new int[] { 1, 5, 7 };
            } else if (_roomNum == 5)
            {
                list = new int[] { 2, 4, 6, 8 };
            } else if (_roomNum == 6)
            {
                list = new int[] { 3, 5, 9 };
            } else if (_roomNum == 7)
            {
                list = new int[] { 4, 8 };
            } else if (_roomNum == 8)
            {
                list = new int[] { 7, 5, 9 };
            } else if (_roomNum == 9)
            {
                list = new int[] { 6, 8 };

            } else
            {
                list = new int[] { _roomNum };
            }

            return list;
        }
    }
    
}
