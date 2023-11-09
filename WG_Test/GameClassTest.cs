using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Word_Game.Models;

namespace WG_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCaseSource(nameof(LevelsForTheCase))]
        public void CreateTheLineCheck(Level lvl)
        {
            Word_Game.GameClass gm = new Word_Game.GameClass(lvl);
            Assert.That(gm.Line.Length, Is.EqualTo(gm.Level.Answer.Length));
        }

        [TestCaseSource(nameof(LevelsWithChar))]
        public void CheckTheAnswerGivenKey(Level lvl, char key, bool expected)
        {
            Word_Game.GameClass gm = new Word_Game.GameClass(lvl);

            gm.CheckTheAnswer(key);

            bool result = gm.Line.Any(x => x.Equals(key));

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(LevelsWithAnswerCheckGivenChar))]
        public void CheckTheAnswerGivenArray(Level lvl, char[] keys, bool expected)
        {
            Word_Game.GameClass gm = new Word_Game.GameClass(lvl);

            foreach (var key in keys)
            {
                gm.CheckTheAnswer(key);
            }

            bool result = gm.Level.Answer.ToLower().Equals(gm.Line.ToLower());

            Assert.That(result, Is.EqualTo(expected));
        }


        public static IEnumerable<Level> LevelsForTheCase()
        {
            yield return new Level() { Question = "Name", Answer = "Hikmet" };
            yield return new Level() { Question = "What are you doing", Answer = "Working" };
            yield return new Level() { Question = "What are the dogs do", Answer = "Barking" };
        }

        public static char[] RandomChars() { return new char[] { 'm', 'k', 'e', 'a', 'b', 'c', 'i', 'h', 't', 'r' }; }

        public static IEnumerable LevelsWithChar()
        {
            yield return new object[] { new Level() { Question = "Name", Answer = "Hikmet" }, 'h', true };
            yield return new object[] { new Level() { Question = "What are you doing", Answer = "Working" }, 'h', false };
            yield return new object[] { new Level() { Question = "What are the dogs do", Answer = "Barking" }, 'k', true };
        }

        public static IEnumerable LevelsWithAnswerCheckGivenChar()
        {
            yield return new object[] { new Level() { Question = "Name", Answer = "Hikmet" }, new char[] { 'm', 'k', 'e', 'a', 'b', 'c', 'i', 'h', 't', 'r' }, true };
            yield return new object[] { new Level() { Question = "Name", Answer = "Hikmet" }, new char[] { 'm', 'k', 'e', 'a', 'b', 'c', 'j', 'h', 't', 'r' }, false };

        }
    }
}