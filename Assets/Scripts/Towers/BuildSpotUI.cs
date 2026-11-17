using UnityEngine;
using UnityEngine.UI;

namespace GS
{
    
    public class BuildSpotUI : MonoBehaviour
    {
        [SerializeField] private Button _buttonTower1;
        [SerializeField] private Button _buttonTower2;
        [SerializeField] private Button _buttonTower3;

        private BuildSpot _buildSpot;
        
        private void Awake()
        {
            _buttonTower1.onClick.AddListener(OnButtonClicked);
            _buttonTower2.onClick.AddListener(OnButtonClicked);
            _buttonTower3.onClick.AddListener(OnButtonClicked);
        }

        public void Init(BuildSpot buildSpot)
        {
            _buildSpot = buildSpot;
        }

        private void OnButtonClicked()
        {
            TowerManager towerManager = FindAnyObjectByType<TowerManager>();
            towerManager.BuildTower(_buildSpot);
            Close();
        }

        public void Close()
        {
            Destroy(gameObject);
        }
    }
}
