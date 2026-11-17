using UnityEngine;
using UnityEngine.InputSystem;

namespace GS
{

    public class BuildSpot : MonoBehaviour
    {
        private enum State
        {
            Free, 
            Occupied
        }

        [SerializeField] private GameObject _view;
        
        private State _state;
        private Vector3 _initialScale;
        
        private void Awake()
        {
            _state = State.Free;
            _initialScale = _view.transform.localScale;
        }

        public void Highlight()
        { 
            _view.transform.localScale = _initialScale * 1.5f;
        }

        public void StopHighlight()
        {
            _view.transform.localScale = _initialScale;
        }
    }
}