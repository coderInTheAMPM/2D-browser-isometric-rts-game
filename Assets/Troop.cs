using UnityEngine;
using UnityEngine.AI;

namespace PavleM.SI.PrebivalisteS3
{
    [RequireComponent(typeof(HealthBar))]
    public class Troop : MonoBehaviour, Selectable
    {
        public Transform targetLocation = null; // null | protivnik | empty gameobject na mapi gde treba da ide

        /// Kad je u daljini od 0.01f od targeta, stigao je do targeta
        /*public static readonly float targetReachedDeltaDistance = 0.01f; // TODO: gizmos?
*/
        private int team = 1;
        public int Team { get => team; set { team = value; } }

        public int health = 100; // privremeno public za testiranje
        /// Ovaj property ne proverava da li je health pao ispod nule, i time uništava trupu, to odgovornost 
        /// je prebačena u DyingTroopState.cs
        public int Health { get => health; set { health = value; } } // TODO: možda prebaciti ovo i rangeove i posebnu klasu?

        public static LayerMask troopLayerMask;

        /*private TroopState currentTroopState;*/

        /*public TroopMovement movement;*/
        /*public new TroopAnimation animation;*/
        public HealthBar healthBar;

        /*[SerializeField] private float speed = 10;*/

        // Note: Takođe sam u ovoj klasi držao polje za generalni range, shortRange, requirecomp za navagent i collider,
        // postavljao sam team color ovde (mogo bi to u zasebnoj klasi)

        /*#region Cached troop states
        public readonly IdleTroopState idleState = new IdleTroopState();
        public readonly MovingTroopState movingState = new MovingTroopState();
        public readonly AttackingTroopState attackingState = new AttackingTroopState();
        public readonly DyingTroopState dyingState = new DyingTroopState();
        #endregion*/

        private void Start()
        {
            //movement = new TroopMovement(transform, GetComponent<NavMeshAgent>(), GetComponent<Collider>(), speed);
            /*animation = new TroopAnimation(GetComponent<Animator>());*/

            troopLayerMask = LayerMask.GetMask("Troop");
            healthBar = GetComponent<HealthBar>();

            /*SetState(idleState);*/
        }

        /*public void SetState(TroopState state)
        {
            currentTroopState?.OnStateExit(this);
            currentTroopState = state;
            currentTroopState.OnStateEnter(this);
        }*/

        // Logika prikazivanja ikonice ove trupe u hotbaru treba da bude zavisna od sadržaja u selection containeru
        public void OnSelect() 
            => healthBar.Show();

        public void OnDeselect()
            => healthBar.Hide();

        /// FixedUpdate umesto Update jer ne mora baš svaki frame
        /*private void FixedUpdate() 
            => currentTroopState.EveryFrame(this);*/
    }
}
