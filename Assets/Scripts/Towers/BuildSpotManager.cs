using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GS
{
    public class BuildSpotManager : MonoBehaviour
    {
        private List<BuildSpot> _buildSpots;

        private BuildSpot _highlightedBuildSpot;
        
        private void Start()
        {
            _buildSpots = GetComponentsInChildren<BuildSpot>().ToList();
        }

        private void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Pointer.current.position.ReadValue());
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

            // transform.localScale = _initialScale;
            bool hasHit = Physics.Raycast(ray, out RaycastHit hit);
            if (hasHit)
            {
                foreach (BuildSpot buildSpot in _buildSpots)
                {
                    if (hit.collider.gameObject == buildSpot.gameObject)
                    {
                        _highlightedBuildSpot?.StopHighlight();

                        _highlightedBuildSpot = buildSpot;
                        _highlightedBuildSpot.Highlight();
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
