using System;
using System.Collections.Generic;
using System.Linq;

namespace BaileyGann.AdventureGame.Memory
{
    public class MemoryCharacterRoster : CharacterRoster
    {
        protected override Character AddCore(Character character)
        {
            character.Id = _id++;
            _characters.Add(character.Copy());
            return character;
        }

        protected override void DeleteCore ( int id)
        {
            foreach(var item in _characters)
            {
                if(item.Id == id)
                {
                    _characters.Remove(item);
                    return;
                };
            };
        }

        protected override Character GetCore ( int id )
        {
            return FindById(id)?.Copy();
        }

        protected override IEnumerable<Character> GetAllCore ()
        {
            //foreach (var character in _characters)
            //    yield return character.Copy();
            return _characters.Select(x => x.Copy());
        }

        protected override void UpdateCore ( int id, Character character )
        {
            var existing = FindById(id);
            existing.CopyFrom(character);
        }





        #region Helper functions
        protected override Character FindByName ( string name )
        {
            //Approach 1
            //foreach (var character in _characters)
            //    if (String.Equals(character.Name, name, StringComparison.CurrentCultureIgnoreCase))
            //        return character;
            //return null;

            //Approach 2
            //return _characters.FirstOrDefault(x => String.Equals(x.Name, name, StringComparison.CurrentCultureIgnoreCase));

            //Approach 3
            return (from m in _characters
                    where String.Equals(m.Name, name, StringComparison.CurrentCultureIgnoreCase)
                    select m).FirstOrDefault();

            }

        private Character FindById ( int id )
        {
            return _characters.FirstOrDefault(x => x.Id == id);
        }

        #endregion

        private int _id = 1;
        private readonly List<Character> _characters = new List<Character>();
    }
}
