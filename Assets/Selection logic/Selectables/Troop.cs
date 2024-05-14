using UnityEngine;
using UnityEngine.AI;

namespace PavleM.RDI.RTS
{
    [RequireComponent(typeof(HealthBar))]
    public class Troop : MonoBehaviour, Selectable
    {
        private int team = 1;
        public int Team { get => team; set { team = value; } }

        public int health = 100; // privremeno public za testiranje
        
        public int Health { get => health; set { health = value; } } // TODO: možda prebaciti ovo i rangeove i posebnu klasu?

        public TroopMovement movement;
        public HealthBar healthBar;

        private void Start()
        {
            movement = new TroopMovement(transform, GetComponent<NavMeshAgent>());
            
            healthBar = GetComponent<HealthBar>();
        }

        public void OnSelect() { healthBar.Show(); }

        public void OnDeselect() { healthBar.Hide(); }
    }
}
