using UnityEngine;
using UnityEngine.InputSystem;

namespace GS
{
    public enum BuildSpotState
    {
        Free, 
        Occupied
    }

    public class BuildSpot : MonoBehaviour
    {
        [SerializeField] private GameObject _view;
        
        private BuildSpotState _state;
        private Vector3 _initialScale;
        
        public BuildSpotState State => _state;
        
        private void Awake()
        {
            _state = BuildSpotState.Free;
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
        
        public void SetOccupied()
        {
            _state = BuildSpotState.Occupied;
        }
    }
}