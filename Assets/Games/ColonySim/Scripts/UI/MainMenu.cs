using UnityEngine;

namespace CS
{
    public class MainMenu : MonoBehaviour
    {
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
    }
}
