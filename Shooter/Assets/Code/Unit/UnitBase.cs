﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TAMKShooter.Utility;

namespace TAMKShooter
{

    public abstract class UnitBase : MonoBehaviour
    {
        #region Properties
        public IHealth Health { get; protected set; }
        public IMover Mover { get; protected set; }
        public WeaponController Weapons { get; protected set; }
        #endregion

        #region Unity messages
        protected virtual void Awake()
        {
            InitRequiredComponents();
        }


        #endregion

        #region Public interface
        public void TakeDamage(int amount)
        {
            if (Health.TakeDamage(amount))
            {
                Die();
            }
        }
        #endregion

        #region Abstracts
        protected abstract void Die();
        public abstract int ProjectileLayer { get; }
        #endregion

        private void InitRequiredComponents()
        {
            Health = gameObject.GetOrAddComponent<Health>();
            Mover = gameObject.GetOrAddComponent<Mover>();
            Weapons = gameObject.GetComponentInChildren<WeaponController>();
        }
    }
}
