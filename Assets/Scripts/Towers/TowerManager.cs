using UnityEngine;

namespace GS
{
    public class TowerManager : MonoBehaviour
    {
        [SerializeField] private GameObject _towerPrefab;
        
        public void BuildTower(Vector3 buildPosition)
        {
            Instantiate(_towerPrefab, buildPosition, Quaternion.identity);
        }       
    }
}
