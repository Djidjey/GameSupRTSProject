using System;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class ColonyManager : MonoBehaviour
    {
        [SerializeField] private Building _prefabDefenseBuilding;
        [SerializeField] private Building _prefabAttackBuilding;
        [SerializeField] private Building _prefabProductionBuilding;
        [SerializeField] private Building _prefabMainBase;
        
        private List<Building> _buildings = new();
        private Building _mainBaseBuilding;
        
        public Building MainBaseBuilding => _mainBaseBuilding;
        
        
        private void Start()
        {
            
        }

        private void Update()
        {
            
        }

        public void CreateBuilding(GridTile tile, BuildingType buildingType)
        {
            Building instance = null;
            switch (buildingType)
            {
                case BuildingType.Defense:
                    if (LevelManager.Instance.HasEnoughCurrency(_prefabDefenseBuilding.CurrencyCost))
                    {
                        LevelManager.Instance.TakeCurrency(_prefabDefenseBuilding.CurrencyCost);
                        instance = Instantiate(_prefabDefenseBuilding);
                    }
                    break;
                case BuildingType.Attack:
                    if (LevelManager.Instance.HasEnoughCurrency(_prefabAttackBuilding.CurrencyCost))
                    {
                        LevelManager.Instance.TakeCurrency(_prefabAttackBuilding.CurrencyCost);
                        instance = Instantiate(_prefabAttackBuilding);
                    }
                    break;
                case BuildingType.Production:
                    if (LevelManager.Instance.HasEnoughCurrency(_prefabProductionBuilding.CurrencyCost))
                    {
                        LevelManager.Instance.TakeCurrency(_prefabProductionBuilding.CurrencyCost);
                        instance = Instantiate(_prefabProductionBuilding);
                    }
                    break;
                case BuildingType.MainBase:
                    if (LevelManager.Instance.HasEnoughCurrency(_prefabMainBase.CurrencyCost))
                    {
                        LevelManager.Instance.TakeCurrency(_prefabMainBase.CurrencyCost);
                        instance = Instantiate(_prefabMainBase);
                    }
                    _mainBaseBuilding = instance;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(buildingType), buildingType, null);
            }

            if (instance != null)
            {
                instance.transform.position = tile.transform.position;
                StartCoroutine(instance.SpawnAnimation(0.0f));
                _buildings.Add(instance);
            }
        }
    }
}
