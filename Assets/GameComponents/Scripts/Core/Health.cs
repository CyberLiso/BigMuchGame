using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Saving;

namespace RPG.Core
{


    public class Health : MonoBehaviour, ISaveable
    { 
        [Range(0, 1000)] [SerializeField] float MaxHealth = 100f;
        public float currentHealth;
        private Animator animator;
        public bool IsDead { get;private set;}

        public void TakeDamage(float damage)
        {
            currentHealth = Mathf.Max(currentHealth - damage, 0);
            print(currentHealth);
            if (currentHealth == 0 && !IsDead)
            {
                Death();
            }
        }

        public void Death()
        {
            if (IsDead) return;
            animator.SetTrigger("Die");
            IsDead = true;
            GetComponent<ActionSchedular>().CancelCurrentAction();
        }
        // Start is called before the first frame update
        void Start()
        {
            currentHealth = MaxHealth;
            animator = GetComponent<Animator>();
        }

        public object CaptureState()
        {
            return currentHealth;
        }

        public void RestoreState(object state)
        {
           float SaveableHealth = (float) state;
           currentHealth = SaveableHealth;
            if (currentHealth == 0)
            {
                Death();
            }
        }
    }
}
