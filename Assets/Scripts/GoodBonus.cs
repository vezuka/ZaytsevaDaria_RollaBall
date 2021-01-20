using UnityEngine;

namespace RollaBall
{
    public sealed class GoodBonus : InteractiveObject, IFly, IFlicker
    {
        private Material _material;
        private float _lengthFly;

        private DisplayBonuses _displayBonuses;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFly = Random.Range(1.0f, 5.0f);

            _displayBonuses = new DisplayBonuses();
        }
        protected override void Interaction()
        {
            _displayBonuses.Display(5);
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFly),
                transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r,
                _material.color.g,
                Mathf.PingPong(Time.time, 1.0f));
        }
    }
}


