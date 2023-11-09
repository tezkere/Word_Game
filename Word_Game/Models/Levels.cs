using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace Word_Game.Models
{
    public class Levels
    {
        private static readonly string filePath = "levels.json";

        public static List<Level> GetLevels()
        {
            var directory = Path.Combine(Environment.CurrentDirectory, filePath);
            string abc = File.ReadAllText(directory);
            var levels = JsonSerializer.Deserialize<List<Level>>(abc);
            return levels;
        }
    }

    public class Level
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
