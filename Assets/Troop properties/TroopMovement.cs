using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

namespace PavleM.RDI.RTS
{
    public class TroopMovement
    {
        private Transform transform;
        public NavMeshAgent agent;
        private NavMeshPath path;

        public float atDestinationDelta = 0.5f;

        public TroopMovement(Transform transform, NavMeshAgent agent)
        {
            this.transform = transform;

            this.agent = agent;
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            path = new NavMeshPath();
        }

        public void SetDestination(Vector3 destination)
            => agent.destination = destination;

        public bool IsAtDestination()
            => (Vector3.Distance(transform.position, agent.destination) < atDestinationDelta);

        public bool IsNotAtDestination()
            => !IsAtDestination();

        public void MoveTo(Vector3 destination)
        {
            if (CanAgentGetTo(destination))
                agent.SetDestination(destination);
            else
                Debug.Log("There is no way!"); // TODO: zameniti sa glasom
        }

        public bool CanAgentGetTo(Vector3 destination)
        {
            agent.CalculatePath(destination, path);

            return (path.status == NavMeshPathStatus.PathComplete);
        }
    }
}
