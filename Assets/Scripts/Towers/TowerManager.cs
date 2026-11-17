using System;
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
        public Action<BuildSpot> _towerBuilt;
        
        public void BuildTower(BuildSpot buildSpot)
        {
            if (buildSpot.State == BuildSpotState.Occupied) return;
            
            Instantiate(_towerPrefab, buildSpot.transform.position, Quaternion.identity);

            _towerBuilt.Invoke(buildSpot);
        }       
    }
}
