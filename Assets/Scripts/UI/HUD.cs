using TMPro;
using UnityEngine;

namespace GS
{
    public class HUD : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private TMP_Text _currentEnemyCount;

        private int _enemyCount = 0;

        public void IncreaseEnemyCount()
        {
            _enemyCount++;
            UpdateEnemyCountText();
        }
        
        public void DecreaseEnemyCount()
        {
            _enemyCount--;
            UpdateEnemyCountText();
        }

        private void UpdateEnemyCountText()
        {
            _currentEnemyCount.text = "EnemyCount = " + _enemyCount;
        }
    }
}
