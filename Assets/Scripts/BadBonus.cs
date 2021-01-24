using UnityEngine;
using System;
using Random = UnityEngine.Random;

namespace RollaBall
{
    public sealed class BadBonus : InteractiveObject, IFly, IRotation
    {

        private float _lengthFly;
        private float _speedRotation;
        public delegate void CaughtPlayerChange(object value);
        private event EventHandler<CaughtPlayerEventArgs> _caughtPlayerChange;
        public event EventHandler<CaughtPlayerEventArgs> CaughtPlayer
        {
            add
            {
                _caughtPlayerChange += value;
            }
            remove
            {
                _caughtPlayerChange -= value;
            }
        }
        // private PlayerChanges _playerChange;

        private void Awake() 
        {
            _lengthFly = Random.Range(1.0f, 5.0f);
            _speedRotation = Random.Range(10.0f, 50.0f);
            
            //_playerChange = FindObjectOfType<PlayerChanges>();
        }

        protected override void Interaction()
        {
            //_playerChange.Die();
            _caughtPlayerChange?.Invoke(this, new CaughtPlayerEventArgs(_color));
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFly),
                transform.localPosition.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation),
                Space.World);
        }
    }
}


