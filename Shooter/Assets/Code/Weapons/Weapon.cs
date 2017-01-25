﻿using UnityEngine;
using TAMKShooter.Utility;
using TAMKShooter.Systems;
using ProjectileType = TAMKShooter.Projectile.ProjectileType;


namespace TAMKShooter
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private ProjectileType _projectileType;

        public void Shoot(int projectileLayer)
        {
            Projectile projectile = GetProjectile();
            if(projectile != null)
            {
                projectile.gameObject.SetLayer(projectileLayer);
                projectile.Shoot(transform.forward);
            }
        }

        private Projectile GetProjectile()
        {
            Projectile projectilePrefab = Global.Instance.Prefabs.GetProjectileByType(_projectileType);
            if (projectilePrefab != null)
            {
                Projectile projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
                return projectile;
            }
            return null;
        }
    }
}
