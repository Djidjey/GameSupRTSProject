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

        private void Start()
        {
            Generate();
        }

        private void Generate()
        {
            // Create tile
            _tiles = new GridTile[_worldData.WorldGridWidth * _worldData.WorldGridHeight];
            
            for (int x = 0; x < _worldData.WorldGridWidth; x++)
            {
                for (int y = 0; y < _worldData.WorldGridHeight; y++)
                {
                    Vector3 position = new Vector3(x * 1.1f, 0, y * 1.1f);
                    
                    GridTile instance = Instantiate(_tilePrefab, position, Quaternion.identity);
                    instance.transform.parent = _rootObjectForWorldBuilding.transform;
                    int index = y * _worldData.WorldGridWidth + x;
                    _tiles[index] = instance;

                    StartCoroutine(instance.SpawnAnimation(index * _delaySpawnTileAnimationInSeconds));
                }
            }
        }
    }
}