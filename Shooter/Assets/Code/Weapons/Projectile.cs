using UnityEngine;

namespace TAMKShooter
{

    public class Projectile : MonoBehaviour
    {
        public enum ProjectileType
        {
            None = 0,
            Laser = 1,
            Explosive = 2,
            Missile = 3,
        }

        #region Unity fields
        [SerializeField]
        private float _shootingForce;
        [SerializeField]
        private int _damage;
        [SerializeField]
        private ProjectileType _projectileType;
        #endregion

        private Rigidbody _rigidbody;

        public ProjectileType Type { get { return _projectileType; } }

        protected virtual void Awake ()
        {
            _rigidbody = GetComponent<Rigidbody>();
        } 

        protected void OnCollisionEnter (Collision collision)
        {   
            // Collision, Projectile hit something

            IHealth damageReceiver = collision.gameObject.GetComponentInChildren<IHealth>();
            if(damageReceiver != null)
            {   
                // Colliding object can take damae
                damageReceiver.TakeDamage(_damage);

                // TODO: Instantiate effect
                // TODO: Add sound effect

                Destroy(gameObject);
            }
        }

        protected void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Destroyer"))
            {
                Destroy(gameObject);
            }

        }

        public void Shoot(Vector3 direction)
        {
            _rigidbody.AddForce(direction * _shootingForce, ForceMode.Impulse);
        }
    }
}
