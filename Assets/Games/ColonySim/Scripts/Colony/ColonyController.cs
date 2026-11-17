using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace CS
{
    public enum BuildingType
    {
        Defense,
        Attack,
        Production,
        MainBase
    }
    
    public class ColonyController : MonoBehaviour
    {
        private enum State
        {
            Idle,
            CreateBuilding
        }
        
        [SerializeField] private InputActionReference _clickInputActionReference;
        
        private GridTile _detectedTile;
        private GridTile _selectedTile;
        private State _state;
        private bool _buildingCreationExecuted = false;
        
        private void Start()
        {
            _state = State.Idle;
        }

        private void Update()
        {
            bool isPointerOverUI = IsPointerOverUI();
            
            switch (_state)
            {
                case State.Idle:
                    // Detect Tile
                    if (!TryDetectTile(out GridTile newDetectedTile))
                    {
                        return;
                    }

                    if (newDetectedTile != _detectedTile)
                    {
                        _detectedTile?.StopHighlight();
                        _detectedTile = newDetectedTile;
                        _detectedTile.Highlight();
                    }
            
                    // Highlight tile
                    _detectedTile.Highlight();
            
                    if (_clickInputActionReference.action.WasPerformedThisFrame())
                    {
                        // Click world to build
                        MainMenu.Instance.UICreateBuildingUI.Open(_detectedTile.transform.position, OnBuildingTypeSelected);
                        _state = State.CreateBuilding;
                        _selectedTile = _detectedTile;
                        _detectedTile = null;
                    }
                    break;
                case State.CreateBuilding:
                    _selectedTile.Highlight();
                    
                    if (_buildingCreationExecuted || 
                        (!isPointerOverUI && _clickInputActionReference.action.WasPerformedThisFrame()))
                    {
                        MainMenu.Instance.UICreateBuildingUI.Close();
                        _state = State.Idle;
                        _selectedTile = null;
                        _buildingCreationExecuted = false;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void OnBuildingTypeSelected(BuildingType type)
        {
            LevelManager.Instance.ColonyManager.CreateBuilding(_selectedTile, type);

            _buildingCreationExecuted = true;
        }
        
        private bool IsPointerOverUI()
        {
            return EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();
        }

        private bool TryDetectTile(out GridTile tile)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                return hit.collider.TryGetComponent(out tile);
            }

            tile = null;
            return false;
        }
    }
}
