using UnityEngine;
using UnityEngine.AI;

namespace PavleM.SI.PrebivalisteS3
{
    public class TroopMovement
    {
        private Transform transform;
        private Collider collider;
        public NavMeshAgent agent;
        private NavMeshPath path;

        public Vector3 Destination { get; private set; }

        private float speed;

        public float atDestinationDelta = 0.5f;

        public TroopMovement(Transform transform, NavMeshAgent agent, Collider collider, float speed)
        {
            this.transform = transform;
            this.collider = collider;
            this.agent = agent;
            path = new NavMeshPath();
            this.speed = speed;

            Destination = transform.position;

            RemoveTroopCollision();

            agent.updateRotation = false;
        }

        private void RemoveTroopCollision()
        {
            collider.isTrigger = true;
            agent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
        }

        public void SetDestination(Vector3 destination)
            => this.Destination = destination;

        public bool IsAtDestination()
            => (Vector3.Distance(transform.position, Destination) < atDestinationDelta); // TODO: Ovo ne treba biti ovako fiksno
           
        public void SetDestinationToPosition()
            => Destination = transform.position;

        public bool IsNotAtDestination()
            => !IsAtDestination();

        public void MoveTo(Vector3 destination) // TODO: Pre nisam primao parametar, nego koristio Destination, da li je ovo bolje?
        {
            if (CanAgentGetTo(destination))
            {
                Destination = destination; /// Kako bih mogao da pratim da li je stigao ili ne

                Face(destination); // TODO: da bi ovo bilo bolje, verovatno bi bilo bolje awaitovati da se Face završi pa onda ići ka destinaciji
                agent.SetDestination(destination);
            }
            else
                Debug.Log("There is no way!"); // TODO: zameniti sa glasom
        }

        public bool CanAgentGetTo(Vector3 destination)
        {
            agent.CalculatePath(destination, path);

            return (path.status == NavMeshPathStatus.PathComplete);
        }

        public void Face(Vector3 targetPos)
        {
            // Vektor od naše pozicije do targeta, ovim smerom se računa
            Vector3 lookVector = targetPos - transform.position;
            // Pomeraj će biti isključivo na XZ osi / ravni
            lookVector.y = 0; 

            // U slučaju da je već kod targeta ovo će stvoriti lookVector = Vector3.zero
            // što stvara probleme pri konverziji u Quaternion tip
            if (lookVector.Equals(Vector3.zero)) 
                return;

            var interpolationCoefficient = 0.5f;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookVector), interpolationCoefficient);
        }

        public bool IsFacingDestination()
        {
            var angleToDestination = Vector2.Angle(transform.position, Destination);
            return angleToDestination < 5;
        }
    }
}
