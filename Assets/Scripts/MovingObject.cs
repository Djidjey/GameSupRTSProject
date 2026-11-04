using UnityEngine;

namespace GS
{
    public class MovingObject : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        private void Start()
        {
            
        }

        private void Update()
        {
            int a = 4 + 10;
            transform.position = transform.position + Vector3.left * _speed * Time.deltaTime; 
        }
    }
}
