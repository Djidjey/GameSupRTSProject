using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GS
{
    public class BuildSpotManager : MonoBehaviour
    {
        [SerializeField] private BuildSpotUI _uiBuildSpotPrefab;
        
        private List<BuildSpot> _buildSpots;

        private BuildSpot _highlightedBuildSpot;
        private BuildSpotUI _uiBuildSpotInstance;
        
        private void Start()
        {
            _buildSpots = GetComponentsInChildren<BuildSpot>().ToList();
        }

        private void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Pointer.current.position.ReadValue());

            bool hasHit = Physics.Raycast(ray, out RaycastHit hit);
            if (hasHit)
            {
                foreach (BuildSpot buildSpot in _buildSpots)
                {
                    if (hit.collider.gameObject == buildSpot.gameObject)
                    {
                        // Highlight
                        _highlightedBuildSpot?.StopHighlight();

                        _highlightedBuildSpot = buildSpot;
                        _highlightedBuildSpot.Highlight();
                        
                        // Click
                        if (InputSystem.actions.FindAction("Attack").WasPressedThisFrame())
                        {
                            if (_uiBuildSpotInstance != null)
                            {
                                Destroy(_uiBuildSpotInstance);
                            }
                            
                            _uiBuildSpotInstance = Instantiate(_uiBuildSpotPrefab, _highlightedBuildSpot.transform);
                            _uiBuildSpotInstance.Init(_highlightedBuildSpot.transform.position);
                        }
                    }
                }
            }
            else
            {
                _highlightedBuildSpot?.StopHighlight();
                _highlightedBuildSpot = null;
            }
        }
    }
}
