using TMPro;
using UnityEngine;

namespace CS
{
    public class MainMenu : MonoBehaviour
    {
        [Header("Static menu")] 
        [SerializeField] private TextMeshProUGUI _currencyAmountText;
        
        [Header("Sub Menu")]
        [SerializeField] private CreateBuildingUI _uiCreateBuilding;
        
        
        public CreateBuildingUI UICreateBuildingUI => _uiCreateBuilding;

        private static MainMenu _instance;
        public static MainMenu Instance => _instance;

        private void Awake()
        {
            _instance = this;
        }
        
        private void Start()
        {
            _uiCreateBuilding.Init(GetComponent<Canvas>());
        }

        private void Update()
        {
            
        }
        
        public void UpdateCurrencyAmount(int amount)
        {
            _currencyAmountText.text = amount.ToString();
        }
    }
}
