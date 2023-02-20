using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Components
{
    public class HealthComponent : MonoBehaviour
    {
        #region Properties

        [field : SerializeField]
        public int MaxHealth
        {
            get;
            set;
        }

        public int CurrentHealth
        {
            get;
            set;
        }

        public bool CanTakeDamage
        {
            get;
            set;
        } = true;

        #endregion


        #region Mono Behaviours

        public void Start()
        {
            CurrentHealth = MaxHealth;
        }

        #endregion


        #region Public Methods

        public void TakeDamage(int amount)
        {
            if (CanTakeDamage)
            {
                CurrentHealth -= amount;
                if (CurrentHealth == 0)
                {
                    Die();
                }
                StartCoroutine("IFrames");
            }
        }

        #endregion


        #region Private Methods

        private void Die()
        {
            Destroy(gameObject);
        }

        #endregion


        #region Coroutines

        IEnumerator IFrames()
        {
            CanTakeDamage = false;
            yield return new WaitForSeconds(0.5f);
            CanTakeDamage = true;
        }

        #endregion

    }
}
