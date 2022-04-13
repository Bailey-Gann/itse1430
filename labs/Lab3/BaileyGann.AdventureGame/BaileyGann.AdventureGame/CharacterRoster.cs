using System;
using System.Collections.Generic;

using BaileyGann.AdventureGame.Memory;

namespace BaileyGann.AdventureGame
{
    public abstract class CharacterRoster : ICharacterRoster
    {
        public string Add ( Character character )
        {
            //TODO: Validate
            if (character == null)
                return "Movie cannot be null";

            if (!ObjectValidator.TryValidateObject(character, out var errors))
                return "Character is invalid";

            //Title must be unique
            var existing = FindByName(character.Name);
            if (existing != null)
                return "Movie must be unique";

            //Add
            var newCharacter = AddCore(character);
            character.Id = newCharacter.Id;            
            return "";
        }

        protected abstract Character AddCore ( Character character );

        public string Delete ( int id)
        {
            if (id <= 0)
                return "ID must be > 0";
            DeleteCore(id);
            return "";
        }

        protected abstract void DeleteCore ( int id );

        public Character Get ( int id )
        {
            if (id <= 0)
                return null;

            return GetCore(id);
        }

        protected abstract Character GetCore ( int id);

        public IEnumerable<Character> GetAll()
        {
            return GetAllCore();
        }
        protected abstract IEnumerable<Character> GetAllCore ();

        public string Update( int id, Character character)
        {
            if (id <= 0)
                return "Id must be greater than or equal to 0";
            if (character == null)
                return "Character cannot be null";

            if (!ObjectValidator.TryValidateObject(character, out var errors))
                return "Character is invalid";

            var existing = FindByName(character.Name);
            if (existing != null && existing.Id != id)
                return "Character must be unique";

            existing = GetCore(id);
            if (existing == null)
                return "Character does not exist";

            UpdateCore(id, character);
            return "";
        }

        protected abstract void UpdateCore ( int id, Character character );
        protected abstract Character FindByName ( string name );
    }
}
