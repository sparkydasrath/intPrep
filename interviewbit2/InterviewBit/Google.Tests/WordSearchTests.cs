using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;

namespace Google.Tests
{
    [TestFixture]
    public class WordSearchTests
    {
        [Test]
        public void ShouldReturnListOfExistingWords()
        {
            char[,] board = new char[4, 4];
            board[0, 0] = 'o';
            board[0, 1] = 'a';
            board[0, 2] = 'a';
            board[0, 3] = 'n';
            board[1, 0] = 'e';
            board[1, 1] = 't';
            board[1, 2] = 'a';
            board[1, 3] = 'e';
            board[2, 0] = 'i';
            board[2, 1] = 'h';
            board[2, 2] = 'k';
            board[2, 3] = 'r';
            board[3, 0] = 'i';
            board[3, 1] = 'f';
            board[3, 2] = 'l';
            board[3, 3] = 'v';

            WordSearch2 w = new WordSearch2();
            string[] words = { "oath", "pea", "eat", "rain" };
            IList<string> result = w.FindWords(board, words);
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void ShouldReturnTrueIfWordExists()
        {
            char[,] board = new char[3, 4];
            board[0, 0] = 'a';
            board[0, 1] = 'b';
            board[0, 2] = 'c';
            board[0, 3] = 'e';
            board[1, 0] = 's';
            board[1, 1] = 'f';
            board[1, 2] = 'c';
            board[1, 3] = 's';
            board[2, 0] = 'a';
            board[2, 1] = 'd';
            board[2, 2] = 'e';
            board[2, 3] = 'e';

            WordSearch1 w = new WordSearch1();
            bool result = w.Exist(board, "see");
            Assert.IsTrue(result);
        }
    }
}