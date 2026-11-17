using UnityEngine;

namespace CS
{
    public class WorldBuilder : MonoBehaviour
    {
        [SerializeField] private WorldData _worldData;
        [SerializeField] private GridTile _tilePrefab;
        [SerializeField] private float _delaySpawnTileAnimationInSeconds;
        [SerializeField] private GameObject _rootObjectForWorldBuilding;

        private GridTile[] _tiles;
        private EnemyManager _enemyManager;
        private ColonyManager _colonyManager;

        private void Start()
        {
            _enemyManager = LevelManager.Instance.EnemyManager;
            _colonyManager = LevelManager.Instance.ColonyManager;
            
            Generate();
        }

        private void Generate()
        {
            // Create tile
            _tiles = new GridTile[_worldData.WorldGridWidth * _worldData.WorldGridHeight];
            
            for (int coordX = 0; coordX < _worldData.WorldGridWidth; coordX++)
            {
                for (int coordY = 0; coordY < _worldData.WorldGridHeight; coordY++)
                {
                    Vector3 position = new Vector3(coordX * 1.1f, 0, coordY * 1.1f);
                    
                    GridTile instance = Instantiate(_tilePrefab, position, Quaternion.identity);
                    instance.transform.parent = _rootObjectForWorldBuilding.transform;
                    
                    int index = CoordToIndex(coordX, coordY);
                    _tiles[index] = instance;

                    StartCoroutine(instance.SpawnAnimation(index * _delaySpawnTileAnimationInSeconds));
                }
            }
            
            // Spawn main base
            GridTile centerTile = GetTileAtCoord((int)(_worldData.WorldGridWidth / 2f), (int)(_worldData.WorldGridHeight / 2f));
            _colonyManager.CreateBuilding(centerTile, BuildingType.MainBase);
            
            // Select random tile for enemy spawn point
            for (int i = 0; i < _worldData.SpawnPointCount; i++)
            {
                GridTile spawnEnemyTile = _tiles[Random.Range(0, _tiles.Length)];
                _enemyManager.CreateEnemySpawner(spawnEnemyTile);
            }
        }

        private GridTile GetTileAtCoord(int coordX, int coordY)
        {
            return _tiles[CoordToIndex(coordX, coordY)];
        }

        private int CoordToIndex(int coordX, int coordY)
        {
            return coordY * _worldData.WorldGridWidth + coordX;
        }
    }
}