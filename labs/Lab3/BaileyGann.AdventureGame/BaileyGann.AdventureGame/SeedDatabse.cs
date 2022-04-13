using System;

using BaileyGann.AdventureGame.Memory;

namespace BaileyGann.AdventureGame
{
    public static class SeedDatabase
    {
        public static void Seed( this ICharacterRoster database )
        {
            database.Add(new Character() {
                Name = "Danzu",
                Proffesion = "Fighter",
                Race = "Phantom",
                Strength = 100,
                Constitution = 100,
                Dexterity = 100,
                Intelligence = 100,
                Charisma = 100
            });
        }
    }
}
