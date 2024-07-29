using System.Collections;
using UnityEngine;

namespace _ShootingRange.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Target : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private float _timeToDelay;

        private int _health;
        private Vector3 _startPosition;
        private Quaternion _startRotation;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _health = _maxHealth;
            _rigidbody = GetComponent<Rigidbody>();            
            _startPosition = transform.position;
            _startRotation = transform.rotation;
        }

        public void TakeDamage(int damage)
        {
            if (_health > damage)
            {
                _health -= damage;
                Debug.Log("You damaged aim on " + damage + " damage");
                Debug.Log("The aim remained " + _health + " health");
            }
            else
            {
                _health -= _health;
                _rigidbody.isKinematic = false;
                _rigidbody.useGravity = true;
                StartCoroutine(SpawnNewAim(_timeToDelay));
            }
        }

        private IEnumerator SpawnNewAim(float delay)
        {
            yield return new WaitForSeconds(delay);
            Debug.Log("Couroutine worked after 2 seconds");
            _rigidbody.useGravity = false;
            var newBody = Instantiate(gameObject,_startPosition,_startRotation);
            newBody.GetComponent<Rigidbody>().isKinematic = true;
            Destroy(gameObject);
            _health = _maxHealth;
            Debug.Log("New GO created");
        }

    }

}
