using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaileyGann.AdventureGame.Memory
{
    public interface ICharacterRoster
    {
        string Add ( Character character );
        string Delete ( int id );
        Character Get ( int id );
        IEnumerable<Character> GetAll ();
        string Update ( int id, Character character );
    }
}
