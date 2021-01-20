using UnityEngine;

namespace RollaBall
{
    public class CameraController : MonoBehaviour
    {
        public Player Player;
        private Vector3 _offset;
        private void Start()
        {
            _offset = transform.position - Player.transform.position;
        }

        // Update is called once per frame
        private void LateUpdate()
        {
            if (Player)
            { 
                transform.position = Player.transform.position + _offset;
            }
        }
    }
}


