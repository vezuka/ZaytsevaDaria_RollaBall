using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;

namespace RollaBall
{
    public class PlayerChanges : MonoBehaviour
    {
        [SerializeField] private float _lowSpeed = 1.0f;
        [SerializeField] private float _highSpeed = 15.0f;

        private Timer _timer;
        public List<Timer> Timers = new List<Timer>();
        private Player _player;
        

        private void Start()
        {
            _player = GetComponent<Player>();
        }

        public void UpdateTick()
        {
            if (Timers.Count !=0)
            {
                for (int i = 0; i < Timers.Count; i++)
                {
                    Timers[i].IsTimeOver();
                    if (!Timers[i].IsOn)
                    {
                        StopEffect(Timers[i]);
                        i = 0;
                    }
                }
            }
        }
       
        public void LowSpeed(float time)
        {
            AddTimer();
            _timer.Init(time);
            _player.CurrentSpeed = _lowSpeed;
            Log($"Player speed: {_player.CurrentSpeed}");
        }

        public void HighSpeed(float time)
        {
            AddTimer();
            _timer.Init(time);
            _player.CurrentSpeed = _highSpeed;
            Log($"Player speed: {_player.CurrentSpeed}");
        }


        public void AddTimer()
        {
            _timer = new Timer();
            Timers.Add(_timer);
        }

        private void StopEffect(Timer timer)
        {
            timer.Reset();
            Timers.Remove(timer);
            _player.CurrentSpeed = _player.NormalSpeed;
            Log($"Player speed: {_player.CurrentSpeed}");
            

        }

        public void Die()
        {
            Destroy(gameObject);
            Log("Player is dead");
            Time.timeScale = 0;
        }


    }
}


