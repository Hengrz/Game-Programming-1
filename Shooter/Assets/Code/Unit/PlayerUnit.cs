using System;
using UnityEngine;

namespace TAMKShooter
{
    public class PlayerUnit : UnitBase
    {

        public enum UnitType
        {
            None = 0, 
            Fast = 1,
            Balanced = 2,
            Heavy = 3
        }

        public override int ProjectileLayer
        {
            get
            { return LayerMask.NameToLayer("PlayerProjectile"); }
        }

        protected override void Die()
        {
            // TODO: Handle dying properly!
            gameObject.SetActive(false);
        }

        protected void Update()
        {
            float moveVertical = Input.GetAxis("Vertical");
            float moveHorizontal = Input.GetAxis("Horizontal");

            Vector3 input = new Vector3(moveHorizontal, 0, moveVertical);

            Mover.MoveToDirection(input);

            bool shoot = Input.GetButton("Shoot");
            if (shoot)
            {
                Weapons.Shoot(ProjectileLayer);
            }
        }
    }
}
