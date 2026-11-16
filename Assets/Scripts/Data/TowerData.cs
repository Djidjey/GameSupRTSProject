using UnityEngine;

namespace GS
{
    public enum TowerTargetingMode
    {
        FirstOnPath,
        ClosestOnPath
    }
    
    [CreateAssetMenu(fileName = "TowerData", menuName = "Scriptable Objects/TowerData")]
    public class TowerData : ScriptableObject
    {
        [SerializeField] private int _cost;
        [SerializeField] private float _range;
        [SerializeField] private float _ratePerSeconds;
        [SerializeField] private TowerTargetingMode _towerTargetingMode;
        [SerializeField] private int _damage;

        public int Cost => _cost;
        public float Range => _range;
        public float RatePerSeconds => _ratePerSeconds;
        public TowerTargetingMode TowerTargetingMode => _towerTargetingMode;
        public int Damage => _damage;
    }
}
