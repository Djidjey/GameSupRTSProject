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
        
        private State _state;
        private Vector3 _initialScale;
        
        private void Awake()
        {
            _state = State.Free;
            _initialScale = gameObject.transform.localScale;
        }

        public void Highlight()
        { 
            transform.localScale = _initialScale * 1.5f;
        }

        public void StopHighlight()
        {
            transform.localScale = _initialScale;
        }
    }
}