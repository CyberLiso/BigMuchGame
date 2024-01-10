using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RPG.Core
{


    public class Health : MonoBehaviour
    {
        [Range(0, 1000)] [SerializeField] float MaxHealth = 100f;
        public float currentHealth;
        private static bool hasBeenSaved;
        private Animator animator;
        public bool IsDead { get; private set; }

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
            IsDead = true;
            GetComponent<ActionSchedular>().CancelCurrentAction();
            StartCoroutine(RunAnimationAfterSceneHasLoaded());
        }
        // Start is called before the first frame update
        public IEnumerator RunAnimationAfterSceneHasLoaded()
        {
            yield return new WaitForSeconds(0.01f);
            animator.SetTrigger("Death");
        }
        void Start()
        {
<<<<<<< HEAD
            if (!hasBeenSaved)
            {
                currentHealth = MaxHealth; 
                hasBeenSaved = true;
            }
=======
            currentHealth = MaxHealth;
>>>>>>> parent of 38ab555 (Changes)
            animator = GetComponent<Animator>();
        }
    }
}
