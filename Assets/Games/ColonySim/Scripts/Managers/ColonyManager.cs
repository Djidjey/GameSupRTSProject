using System;
using TMPro;
using UnityEngine;

namespace CS
{
    public class ColonyManager : MonoBehaviour
    {
        [SerializeField] private GameObject _prefabDefenseBuilding;
        [SerializeField] private GameObject _prefabAttackBuilding;
        [SerializeField] private GameObject _prefabProductionBuilding;
        
        private void Start()
        {
            
        }

        private void Update()
        {
            
        }

        public void CreateBuilding(GridTile tile, BuildingType buildingType)
        {
            GameObject instance;
            switch (buildingType)
            {
                case BuildingType.Defense:
                    instance = Instantiate(_prefabDefenseBuilding);
                    break;
                case BuildingType.Attack:
                    instance = Instantiate(_prefabAttackBuilding);
                    break;
                case BuildingType.Production:
                    instance = Instantiate(_prefabProductionBuilding);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(buildingType), buildingType, null);
            }
            
            instance.transform.position = tile.transform.position;
        }
    }
}
