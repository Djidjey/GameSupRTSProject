using System.Collections;
using UnityEngine;

namespace CS
{
    public class GridTile : MonoBehaviour
    {
        [SerializeField] private float _spawnAnimationDuration;
        
        private Vector3 _initialScale;
        
        private void Awake()
        {
            _initialScale = transform.localScale;
        }
        
        private void Update()
        {
            
        }
        
        public IEnumerator SpawnAnimation(float timeBeforeAnimationStartInSeconds)
        {
            transform.localScale = Vector3.zero;

            yield return new WaitForSeconds(timeBeforeAnimationStartInSeconds);
            
            float timer = 0;
            while (timer < _spawnAnimationDuration)
            {
                transform.localScale = _initialScale * timer / _spawnAnimationDuration;
                timer += Time.deltaTime;
                yield return null;
            }
            
            transform.localScale = _initialScale;
        }

        public void Highlight()
        {
            transform.localScale = _initialScale * 1.1f;
        }

        public void StopHighlight()
        {
            transform.localScale = _initialScale;
        }
    }
}