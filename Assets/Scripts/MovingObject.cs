using Unity.Mathematics;
using UnityEngine;

namespace GS
{
    public enum MovementType
    {
        Line,
        PingPong,
        Sinusoidal,
    }
    
    public class MovingObject : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private MovementType _movementType;
        
        private Vector3 _startPosition;
        
        private void Start()
        {
            _startPosition = transform.position;
        }

        private void Update()
        {
            if (_movementType == MovementType.Line)
            {
                transform.position = transform.position + Vector3.left * _speed * Time.deltaTime; 
            }

            if (_movementType == MovementType.PingPong)
            {
                transform.position = _startPosition + (Mathf.PingPong(Time.time, 5) - 2.5f) * Vector3.up * _speed;
            }

            if (_movementType == MovementType.Sinusoidal)
            {
                transform.position += ((Mathf.Sin(Time.time) * Vector3.up) +
                                       (Vector3.left)) * _speed * Time.deltaTime;
            }
        }
    }
}
