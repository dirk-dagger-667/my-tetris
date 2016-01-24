namespace Tetris.HighScore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using Tetris.HighScore.Contracts;

    public class HighScoreSaver : IHighScoreSaver
    {
        private const string DuplicateNamesMsg = "Cannot have duplicate names";

        public void SaveHightScore(string playerName, int score, string filePath)
        {
            XDocument doc = XDocument.Load(filePath);

            XElement newPlayer = new XElement(
                "player",
                new XElement("name", playerName),
                new XElement("score", score.ToString()));

            var allPlayers = this.LoadHighScore(filePath);

            if (allPlayers.ContainsKey(playerName))
            {
                var currentPlayer = doc.Element("players")
                                        .Elements("player")
                                        .Where(e => e.Element("name").Value == playerName)
                                        .Single();

                currentPlayer.Element("score").Value = score.ToString();
            }
            else
            {
                doc.Element("players").Add(newPlayer);
            }

            doc.Save(filePath);
        }

        public IDictionary<string, int> LoadHighScore(string filePath)
        {
            XDocument xmlDoc = XDocument.Load(filePath);
            var players = xmlDoc.Descendants("player");
            StringBuilder result = new StringBuilder();

            var playersByName = new Dictionary<string, int>();

            foreach (var player in players)
            {
                if (playersByName.ContainsKey(player.Element("name").Value))
                {
                    throw new ArgumentException(DuplicateNamesMsg);
                }

                int currentPlayerScore = int.Parse(player.Element("score").Value);

                playersByName.Add(player.Element("name").Value, currentPlayerScore);
            }

            return playersByName.OrderByDescending(x => x.Value).ToDictionary(y => y.Key, y => y.Value);
        }
    }
}
