using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Components {

    public class AttackPlayerComponent : MonoBehaviour
    {

        #region Serialized Fields

        [SerializeField]
        private int damage;

        #endregion


        #region Collision Checks

        private void OnCollisionEnter2D(Collision2D collision)
        {
            HealthComponent healthComponent = collision.gameObject.GetComponent<HealthComponent>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(damage);
            }
        }
        #endregion
    }

}
