using UnityEngine;
using UnityEngine.AI;

namespace PavleM.RDI.RTS
{
    [RequireComponent(typeof(HealthBar))]
    public class Troop : MonoBehaviour, Selectable
    {
        public int team = 1;
        public int Team { get => team; set { team = value; } }

        public int health = 100; // privremeno public za testiranje
        
        public int Health { get => health; set { health = value; } } // TODO: možda prebaciti ovo i rangeove i posebnu klasu?

        public TroopMovement movement;
        public HealthBar healthBar;

        public bool isFighting = false;
        public AudioSource deathSound;

        private void Start()
        {
            movement = new TroopMovement(transform, GetComponent<NavMeshAgent>());
            
            healthBar = GetComponent<HealthBar>();
        }

        private void Update()
        {
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        public void OnSelect() { healthBar.Show(); }

        public void OnDeselect() { healthBar.Hide(); }
    }
}
