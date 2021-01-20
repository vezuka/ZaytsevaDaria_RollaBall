using UnityEngine;

namespace RollaBall
{
    public class HighSpeedBonus : InteractiveObject, IFly, IRotation
    {
        [SerializeField] private float _bonusTime = 5.0f;

        private float _lengthFly;
        private float _speedRotation;
        private PlayerChanges _playerChange;


        private void Awake()
        {
            _lengthFly = Random.Range(1.0f, 5.0f);
            _speedRotation = Random.Range(10.0f, 50.0f);
            _playerChange = FindObjectOfType<PlayerChanges>();
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

        protected override void Interaction()
        {
            _playerChange.HighSpeed(_bonusTime);
        }
    }
}



