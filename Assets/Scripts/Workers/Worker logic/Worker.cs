using System;
using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.AI;

namespace PavleM.RDI.RTS
{
    public abstract class Worker : MonoBehaviour
    {
        private NavMeshAgent agent;
        public float deltaDistanceFromTarget = 0.1f;

        public Transform workLocation;
        public Transform stockpileLocation;
        private Vector3 destination;

        [HideInInspector] public string stashItem; // Šta dostavlja u stockpile
        [HideInInspector] public int stashQuantity; // Koliko

        private IWorkerState workerState;

        public AudioSource workingSound;
        public AudioSource stashingSound;

        #region Cached states
        public readonly WorkerWorkingState workerWorkingState = new WorkerWorkingState();
        public readonly WorkerStashingState workerStashingState = new WorkerStashingState();
        public readonly WorkerWalkingState workerWalkingState = new WorkerWalkingState();
        #endregion

        public GameObject workingIndicator; // loading gif, TODO: da ga automatski kreira nego da ga nameštam u editoru
        // ili zapravo samo prefab da napravim

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            SetDestination(workLocation.position);
            SetWorkerState(workerWalkingState);
        }

        public void SetDestination(Vector3 destination)
            => this.destination = destination;

        public void GoToDestination()
            => agent.SetDestination(destination);

        public bool IsAtWorkplace()
            => destination.Equals(workLocation.position);

        public bool IsAtStockpile()
            => destination.Equals(stockpileLocation.position);

        public void SetWorkerState(IWorkerState newState)
        {
            workerState = newState;
            workerState.OnEnter(this);
        }

        public bool CloseEnoughToDestination()
            => DistanceFrom(destination) < deltaDistanceFromTarget;

        private float DistanceFrom(Vector3 target)
            => Vector3.Distance(transform.position, target);

        private void Update()
            => workerState.Update(this);

    }
}
