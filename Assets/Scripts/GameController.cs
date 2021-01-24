using System;
using UnityEngine;
using UnityEngine.UI;

namespace RollaBall
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        // private InteractiveObject[] _interactiveObjects;
        public Text GameOverText;
        private ListInteractableObject _interactiveObjects;
        private PlayerChanges _playerChanges;
        private DisplayEndGame _displayEndGame;

        private void Awake()
        {
            _interactiveObjects = new ListInteractableObject();
            _playerChanges = FindObjectOfType<PlayerChanges>();
            _displayEndGame = new DisplayEndGame(GameOverText);
            
            foreach (var item in _interactiveObjects)
            {
                if (item is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer += _displayEndGame.GameOver;
                    badBonus.CaughtPlayer += CaughtPlayer;
                }
            }

        }

        private void Update()
        {
            for (var i=0; i < _interactiveObjects.Count; i++ )
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }

                if (interactiveObject is IFly fly)
                {
                    fly.Fly();
                }

                if (interactiveObject is IFlicker flicker)
                {
                    flicker.Flicker();
                }

                if(interactiveObject is IRotation rotation)
                {
                    rotation.Rotation();
                }                
            }

            if (_playerChanges.Timers.Count != 0)
            {
                _playerChanges.UpdateTick();
            }
        }

        private void CaughtPlayer(object value, CaughtPlayerEventArgs args)
        {
            Time.timeScale = 0.0f;
        }

        public void Dispose()
        {
            foreach (var item in _interactiveObjects)
            {
                if (item is InteractiveObject interactiveObject)
                {
                    if (item is BadBonus badBonus)
                    {
                        badBonus.CaughtPlayer -= CaughtPlayer;
                        badBonus.CaughtPlayer -= _displayEndGame.GameOver;
                    }

                    Destroy(interactiveObject.gameObject);
                }
            }
        }

    }
}


