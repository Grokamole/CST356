using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CST356Lab1.Models
{
    public class Person
    {
        public Person(String characterName, String playerName, String characterClass)
        {
            CharacterName  = characterName;
            PlayerName     = playerName;
            CharacterClass = characterClass;
        }
        public String CharacterName;
        public String PlayerName;
        public String CharacterClass;
        public uint Level        = 1;
        public uint Strength     = 9;
        public uint Dexterity    = 9;
        public uint Constitution = 9;
        public uint Intelligence = 9;
        public uint Wisdom       = 9;
        public uint Charisma     = 9;
    }
}
