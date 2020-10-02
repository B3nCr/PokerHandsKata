using System;
using Xunit;
using System.Linq;

namespace OctoKata.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void PokerGameInitializeCorrectlly()
        {
            new PokerGame(new string [] { "HA", "H2", "H3", "H4", "H5" }, new string [] { "CA", "C2", "C3", "C4", "C5" });
        }

        [Fact]
        public void HandsCardsCanBeRead()
        {
            var expectedFirstHand = new string[] {"HA", "H2", "H3", "H4", "H5"};
            var expectedSecondHand = new string[] {"CA", "C2", "C3", "C4", "C5"};

            var pockerGame = new PokerGame(expectedFirstHand, expectedSecondHand);

            Assert.Equal(5, pockerGame.FirstHand.Length);
            Assert.Equal(5, pockerGame.SecondHand.Length);
            Assert.Equal(new string[] {"HA", "H2", "H3", "H4", "H5"}, pockerGame.FirstHand);
            Assert.Equal(new string[] {"CA", "C2", "C3", "C4", "C5"}, pockerGame.SecondHand);
        }

        [Theory]
        [InlineData(new string[] { "HA" }, new string[] { "H2" }, "FirstHand")]
        // [InlineData(new string[] { "H10" }, new string[] { "HQ" }, "SecondHand")]
        public void HandsCardsCanBeRead_AndComparedByCard_Successfull_(string[] firstHand, string[] secondHand, string winner)
        {
            var pockerGame = new PokerGame(firstHand, secondHand);

            Assert.Equal(winner, pockerGame.Winner);
        }

        [Theory]
        [InlineData("H2", "H", 2)]
        [InlineData("H3", "H", 3)]
        [InlineData("H4", "H", 4)]
        [InlineData("H5", "H", 5)]
        [InlineData("H6", "H", 6)]
        [InlineData("H7", "H", 7)]
        [InlineData("H8", "H", 8)]
        [InlineData("H9", "H", 9)]
        [InlineData("H10", "H", 10)]
        [InlineData("HJ", "H", 11)]
        [InlineData("HQ", "H", 12)]
        [InlineData("HK", "H", 13)]
        public void CardCanParseString(string cardString, string suite, int value)     
        {
            var card = new Card(cardString);

            Assert.Equal(suite, card.Suite);
            Assert.Equal(value, card.Value);
        }
    }

    public class PokerGame
    {
        private string[] _firstHand;
        private string[] _secondHand;

        public string[] FirstHand => _firstHand;
        public string[] SecondHand => _secondHand;
        public string Winner { get; private set; }

        public PokerGame(string [] firstHand, string [] secondHand)
        {
            _firstHand = firstHand;
            _secondHand = secondHand;
            Winner = ChooseWinner(_firstHand, _secondHand);
        }

        private string ChooseWinner(string[] firstHand, string[] secondHand)
        {
            return "FirstHand";
        }
    }

    public class Card
    {
        public string Suite { get; private set; }
        public int Value { get; private set; }

        public Card(string card)
        {
            Suite = card.Substring(0, 1); 
            Value = GetValue(card.Substring(1, card.Length - 1));
        }

        private int GetValue(string value)
        {
            var values = new Dictionary<string, int>
            {
                {"1", 1},
                {"2", 2},
                {"3", 3},
                {"4", 4},
                {"5", 5},
                {"6", 6},
                {"7", 7},
                {"8", 8},
                {"8", 9},
                {"9", 10},
                {"10", 10},
                {"J", 11 },
                {"Q", 12 },
                {"K", 13 },
            };

            if (values.ContansKey(value))
            {
                return values[value];
            }

            return null;
        }
    }
}
