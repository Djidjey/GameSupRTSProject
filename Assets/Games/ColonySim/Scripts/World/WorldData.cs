using UnityEngine;

namespace CS
{
    [CreateAssetMenu(fileName = "World Data", menuName = "Scriptable Objects/CS/World Data", order = 0)]
    public class WorldData : ScriptableObject
    {
        [SerializeField] private int _worldGridWidth;
        [SerializeField] private int _worldGridHeight;
        
        public  int WorldGridWidth => _worldGridWidth;
        public int WorldGridHeight => _worldGridHeight;
    }
}