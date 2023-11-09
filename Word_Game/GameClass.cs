
using System.Linq;
using System.Collections.Generic;
using Word_Game.Models;

namespace Word_Game
{
    public class GameClass
    {
        private char Empty => '-';

        public Level Level { get; set; }        

        public string Line { get; set; }

        public bool IsSuccess = false;

        public GameClass(Level level)
        {
            this.Level = level;
            CreateTheLine();
        }

        private void CreateTheLine()
        {
            for (int i = 0; i < Level.Answer.Length; i++) { Line += Empty; }
        }

        public void CheckTheAnswer(char key)
        {
            List<int> indices = Level.Answer.ToLower().Select((x, index) => new { x, index })
                                .Where(letter => letter.x.Equals(key))
                                .Select(letter => letter.index).ToList();
            var arrayLine = Line.ToCharArray();

            indices.ForEach(x => arrayLine[x] = key);

            Line = new string(arrayLine);

            IsSuccess = !(Line.ToLower().Equals(Level.Answer.ToLower()));
        }
    }
}
