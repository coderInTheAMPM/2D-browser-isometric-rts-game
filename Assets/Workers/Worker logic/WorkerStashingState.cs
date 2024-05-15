using UnityEngine;

namespace PavleM.RDI.RTS
{
    public class WorkerStashingState : IWorkerState
    {
        float time;

        public void OnEnter(Worker context)
        {
            context.workingIndicator.SetActive(true);
            time = 0;
            context.stashingSound.Play();
        }

        public void Update(Worker context)
        {
            time += Time.deltaTime;

            if (IsStashingDone())
                OnStashingFinished(context);
        }

        private bool IsStashingDone()
            => (time > 3);

        private void OnStashingFinished(Worker context)
        {
            if (context.stashItem.Equals("wood"))
                PlayerInventory.instance.wood += context.stashQuantity;
            else if (context.stashItem.Equals("food"))
                PlayerInventory.instance.food += context.stashQuantity;

            context.workingIndicator.SetActive(false);
            context.SetDestination(context.workLocation.position);
            context.SetWorkerState(context.workerWalkingState);
        }
    }
}
