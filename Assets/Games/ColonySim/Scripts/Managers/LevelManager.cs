using UnityEngine;

namespace CS
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private ColonyManager _colonyManager;
        
        private static LevelManager _instance;
        public static LevelManager Instance => _instance;
        
        public ColonyManager ColonyManager => _colonyManager;
        
        private void Awake()
        {
            _instance = this;
        }
        
        private void Start()
        {
            
        }

        private void Update()
        {
            
        }
    }
}
