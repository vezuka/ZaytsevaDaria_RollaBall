using System;
using UnityEngine;

namespace RollaBall
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        private InteractiveObject[] _interactiveObjects;
        private PlayerChanges _playerChanges;

        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
            _playerChanges = FindObjectOfType<PlayerChanges>();
            Debug.Log(_playerChanges);
        }

        private void Update()
        {
            for (var i=0; i < _interactiveObjects.Length; i++ )
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

        public void Dispose()
        {
            foreach (var o in _interactiveObjects)
            {
                Destroy(o.gameObject);
            }
        }

    }
}


