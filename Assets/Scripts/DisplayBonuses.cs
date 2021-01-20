using UnityEngine;
using UnityEngine.UI;

namespace RollaBall
{
    public sealed class DisplayBonuses
    {
        private Text _textPoints;

        public DisplayBonuses()
        {
            _textPoints = Object.FindObjectOfType<Text>();
        }

        public void Display(int value)
        {
            _textPoints.text = $"Вы набрали: {value}";
        }
    }
}


