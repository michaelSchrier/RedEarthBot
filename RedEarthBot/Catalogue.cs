using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RedEarthBot.Models;
using System.Net;
using System.Linq;
using DSharpPlus.Entities;

namespace RedEarthBot
{
    public static class Catalogue
    {
        public static Dictionary<CharName, Character> characters = new Dictionary<CharName, Character>();
        public static List<CodeData> characterCodes = new List<CodeData>();

        public static void InitializeCatalogue()
        {
            characterCodes = LoadCodes();

            var tessa = CreateTessa();
            var leo = CreateLeo();
            var mai = CreateMai();
            var kenji = CreateKenji();

            Dictionary<CharName, Character> newCharacters = new Dictionary<CharName, Character>();
            newCharacters.Add(tessa.CharName, tessa);
            newCharacters.Add(leo.CharName, leo);
            newCharacters.Add(mai.CharName, mai);
            newCharacters.Add(kenji.CharName, kenji);

            characters = newCharacters;
        }

        public static Character CreateTessa()
        {
            var moveURL = "http://gsx2json.com/api?id=1WPdOmlmGeN7VU5qxJfdZECHOnGPfBLS0d_HwTfGD9bU&sheet=1";
            var faceURL = "https://wiki.gbl.gg/images/b/b8/RE_Tessa.PNG";
            return new Character(CharName.Tessa, LoadMoves(moveURL), GetCharacterCodes(CharName.Tessa), DiscordColor.Purple, faceURL);
        }

        public static Character CreateLeo()
        {
            var moveURL = "http://gsx2json.com/api?id=1WPdOmlmGeN7VU5qxJfdZECHOnGPfBLS0d_HwTfGD9bU&sheet=2";
            var faceURL = "https://wiki.gbl.gg/images/a/a2/RE_Leo.PNG";

            return new Character(CharName.Leo, LoadMoves(moveURL), GetCharacterCodes(CharName.Leo), DiscordColor.Orange, faceURL);
        }

        public static Character CreateMai()
        {
            var moveURL = "http://gsx2json.com/api?id=1WPdOmlmGeN7VU5qxJfdZECHOnGPfBLS0d_HwTfGD9bU&sheet=3";
            var faceURL = "https://wiki.gbl.gg/images/f/f2/RE_Mai_Ling.PNG";

            return new Character(CharName.MaiLing, LoadMoves(moveURL), GetCharacterCodes(CharName.MaiLing), DiscordColor.Red, faceURL);;
        }

        public static Character CreateKenji()
        {
            var moveURL = "http://gsx2json.com/api?id=1WPdOmlmGeN7VU5qxJfdZECHOnGPfBLS0d_HwTfGD9bU&sheet=4";
            var faceURL = "https://wiki.gbl.gg/images/7/78/RE_Kenji.PNG";

            return new Character(CharName.Kenji, LoadMoves(moveURL), GetCharacterCodes(CharName.Kenji), DiscordColor.Blue, faceURL);
        }

        private static Dictionary<string, MoveData> LoadMoves(string url)
        {
            using WebClient wc = new WebClient();
            var moveJson = wc.DownloadString(url);
            List<JToken> results = JObject.Parse(moveJson)["rows"].Children().ToList();

            Dictionary<string, MoveData> searchResults = new Dictionary<string, MoveData>();
            MoveType currentType = MoveType.Normals;
            foreach (JToken result in results)
            {
                var moveResult = result.ToObject<MoveData>();

                if (moveResult.MoveName == "Normals")
                {
                    currentType = MoveType.Normals;
                    continue;
                }
                else if (moveResult.MoveName == "Supers")
                {
                    currentType = MoveType.Supers;
                    continue;
                }
                else if (moveResult.MoveName == "Specials")
                {
                    currentType = MoveType.Specials;
                    continue;
                }
                else if (moveResult.MoveName == "Misc")
                {
                    currentType = MoveType.Misc;
                    continue;
                }

                moveResult.moveType = currentType;
                searchResults.Add(moveResult.MoveName, moveResult);
            }

            return searchResults;
        }

        public static List<CodeData> LoadCodes()
        {
            using WebClient wc = new WebClient();
            var moveJson = wc.DownloadString("http://gsx2json.com/api?id=1WPdOmlmGeN7VU5qxJfdZECHOnGPfBLS0d_HwTfGD9bU&sheet=5");
            List<JToken> results = JObject.Parse(moveJson)["rows"].Children().ToList();

            List<CodeData> codes = new List<CodeData>();
            foreach (JToken result in results)
            {
                var moveResult = result.ToObject<CodeData>();
                if (!string.IsNullOrEmpty(moveResult.Character))
                {
                    codes.Add(moveResult);
                }
            }

            return codes;
        }

        public static List<CodeData> GetCharacterCodes(CharName charName)
        {
            List<CodeData> charCodes = new List<CodeData>();
            foreach (var code in characterCodes)
            {
                var name = code.Character.Replace(" ", string.Empty);
                if (string.Equals(charName.ToString(), name, StringComparison.CurrentCultureIgnoreCase))
                {
                    charCodes.Add(code);
                }
            }

            return charCodes;
        }
    }

    public enum CharName
    {
        Tessa,
        Leo,
        MaiLing,
        Kenji
    }
}
