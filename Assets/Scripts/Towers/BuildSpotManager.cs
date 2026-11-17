using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
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
            FindAnyObjectByType<TowerManager>()._towerBuilt += OnTowerBuilt;
        }

        private void OnDestroy()
        {
            FindAnyObjectByType<TowerManager>()._towerBuilt -= OnTowerBuilt;
        }

        private void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Pointer.current.position.ReadValue());

            bool hasClickMouse = InputSystem.actions.FindAction("Attack").WasPressedThisFrame();

            bool hasHit = Physics.Raycast(ray, out RaycastHit hit);
            if (hasHit)
            {
                bool hasHitTower = false;
                foreach (BuildSpot buildSpot in _buildSpots)
                {
                    if (hit.collider.gameObject == buildSpot.gameObject)
                    {
                        hasHitTower = true;
                        
                        // Highlight
                        _highlightedBuildSpot?.StopHighlight();

                        _highlightedBuildSpot = buildSpot;
                        _highlightedBuildSpot.Highlight();
                        
                        // Click
                        if (buildSpot.State == BuildSpotState.Free && hasClickMouse)
                        {
                            if (_uiBuildSpotInstance != null)
                            {
                                TryCloseUI();
                            }
                            
                            _uiBuildSpotInstance = Instantiate(_uiBuildSpotPrefab, _highlightedBuildSpot.transform);
                            _uiBuildSpotInstance.Init(_highlightedBuildSpot);
                        }
                    }
                }

                if (!hasHitTower && hasClickMouse)
                {
                    TryCloseUI();
                }
            }
            else
            {
                _highlightedBuildSpot?.StopHighlight();
                _highlightedBuildSpot = null;
                
                if (hasClickMouse && !EventSystem.current.currentSelectedGameObject)
                {
                    TryCloseUI();
                }
            }
        }

        private bool TryCloseUI()
        {
            if (_uiBuildSpotInstance == null) return false;
            
            _uiBuildSpotInstance.Close();
            return true;
        }

        private void OnTowerBuilt(BuildSpot buildSpot)
        {
            buildSpot.SetOccupied();
        }
    }
}
