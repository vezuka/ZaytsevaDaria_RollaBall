using System;
using System.Collections;

namespace RollaBall
{
    public sealed class ListInteractableObject : IEnumerator, IEnumerable
    {
        private InteractiveObject[] _interactiveObjects;
        private int _index = -1;
        private InteractiveObject _current;

        public ListInteractableObject()
        {
            _interactiveObjects = UnityEngine.Object.FindObjectsOfType<InteractiveObject>();
            Array.Sort(_interactiveObjects);
        }

        public int Count => _interactiveObjects.Length;

        public InteractiveObject this[int index]
        {
            get => _interactiveObjects[index];
            set => _interactiveObjects[index] = value;
        }

        public bool MoveNext()
        {
            if (_index == _interactiveObjects.Length - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset() => _index = -1;

        public object Current => _interactiveObjects[_index];

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}