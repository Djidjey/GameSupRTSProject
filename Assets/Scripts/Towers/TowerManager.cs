using UnityEngine;
using UnityEngine.Events;

namespace GS
{
    public class TowerManager : MonoBehaviour
    {
        [SerializeField] private GameObject _towerPrefab;

        /// <summary>
        /// Callback when a new tower is built, return the build spot
        /// </summary>
        public UnityEvent<BuildSpot> _towerBuilt;
        
        public void BuildTower(BuildSpot buildSpot)
        {
            Instantiate(_towerPrefab, buildSpot.transform.position, Quaternion.identity);

            _towerBuilt.Invoke(buildSpot);
        }       
    }
}
