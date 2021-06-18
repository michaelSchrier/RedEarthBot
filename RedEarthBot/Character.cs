using System;
using System.Collections.Generic;
using System.Text;
using RedEarthBot.Models;
using DSharpPlus.Entities;

namespace RedEarthBot
{
    public class Character
    {
        public CharName CharName { get; }
        public Dictionary<string, MoveData> Moves { get; }
        public List<CodeData> Codes { get; } 
        public string FaceURL { get; }
        public DiscordColor Color { get; }

        public Character(CharName _name, Dictionary<string, MoveData> _moves, List<CodeData> _codes, DiscordColor _color, string _faceURL)
        {
            CharName = _name;
            Moves = _moves;
            Codes = _codes;
            Color = _color;
            FaceURL = _faceURL;
        }
    }
}
