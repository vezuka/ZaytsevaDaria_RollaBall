using UnityEngine;
using UnityEngine.UI;

namespace RollaBall
{
    public class DisplayEndGame
    {
        private Text _endGameText;

        public DisplayEndGame(Text endGameText)
        { 
            _endGameText = endGameText;
            _endGameText.text = string.Empty;
        }

        public void GameOver(object value, CaughtPlayerEventArgs args)
        {
            _endGameText.text = $"Player is dead. The killer is {((BadBonus)value).name}. Color: {args.Color}";
        }
    }
}


