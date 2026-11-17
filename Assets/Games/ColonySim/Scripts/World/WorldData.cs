using UnityEngine;

namespace CS
{
    [CreateAssetMenu(fileName = "World Data", menuName = "Scriptable Objects/CS/World Data", order = 0)]
    public class WorldData : ScriptableObject
    {
        [Header("World Size")]
        [SerializeField] private int _worldGridWidth;
        [SerializeField] private int _worldGridHeight;

        [Header("Enemy Spawn Point")] 
        [SerializeField] private int _spawnPointCount;
        
        public  int WorldGridWidth => _worldGridWidth;
        public int WorldGridHeight => _worldGridHeight;
        public int SpawnPointCount => _spawnPointCount;
    }
}