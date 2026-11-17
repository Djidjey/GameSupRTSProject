using UnityEngine;

namespace CS
{
    public class LevelManager : MonoBehaviour
    {
        // Fields
        [Header("Managers")]
        [SerializeField] private ColonyManager _colonyManager;
        [SerializeField] private EnemyManager _enemyManager;
        
        [Header("Settings")]
        [SerializeField] private int _initialCurrencyAmount;
        
        // Singleton
        private static LevelManager _instance;
        public static LevelManager Instance => _instance;
        
        // Currency
        private int _currentCurrencyAmount;
        
        // Properties
        public ColonyManager ColonyManager => _colonyManager;
        public EnemyManager EnemyManager => _enemyManager;
        
        private void Awake()
        {
            _instance = this;
        }

        private void Start()
        {
            AddCurrency(_initialCurrencyAmount);
        }
        
        public bool HasEnoughCurrency(int amount)
        {
            return _currentCurrencyAmount >= amount;
        }

        public void AddCurrency(int amount)
        {
            _currentCurrencyAmount += amount;
            MainMenu.Instance.UpdateCurrencyAmount(_currentCurrencyAmount);
        }

        public void TakeCurrency(int amount)
        {
            _currentCurrencyAmount -= amount;
            MainMenu.Instance.UpdateCurrencyAmount(_currentCurrencyAmount);
        }
    }
}
