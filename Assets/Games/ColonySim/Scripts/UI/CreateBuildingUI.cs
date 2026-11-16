using System;
using UnityEngine;
using UnityEngine.UI;

namespace CS
{
    public class CreateBuildingUI : MonoBehaviour
    {
        [SerializeField] private Button _createDefenseButton;
        [SerializeField] private Button _createAttackButton;
        [SerializeField] private Button _createProductionButton;
        
        private Canvas _canvas;
        
        private void Start()
        {
            Close();
        }

        public void Init(Canvas canvas)
        {
            _canvas = canvas;
        }
        
        public void Open(Vector3 worldPosition, Action<BuildingType> onBuildingTypeSelected)
        {
            gameObject.SetActive(true);
            Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, worldPosition);

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvas.transform as RectTransform, 
                screenPoint, 
                null, 
                out var localPoint
            );

            transform.GetComponent<RectTransform>().anchoredPosition = localPoint;
            
            _createDefenseButton.onClick.AddListener(() => onBuildingTypeSelected(BuildingType.Defense));
            _createAttackButton.onClick.AddListener(() => onBuildingTypeSelected(BuildingType.Attack));
            _createProductionButton.onClick.AddListener(() => onBuildingTypeSelected(BuildingType.Production));
        }

        public void Close()
        {
            gameObject.SetActive(false);
            
            _createDefenseButton.onClick.RemoveAllListeners();
            _createAttackButton.onClick.RemoveAllListeners();
            _createProductionButton.onClick.RemoveAllListeners();
        }
    }
}