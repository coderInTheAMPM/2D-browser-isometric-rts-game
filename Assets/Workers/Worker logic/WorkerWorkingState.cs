using UnityEngine;

namespace PavleM.RDI.RTS
{
    public class WorkerWorkingState : IWorkerState
    {
        float time;

        public void OnEnter(Worker context)
        {
            context.workingIndicator.SetActive(true);
            time = 0;
        }

        public void Update(Worker context)
        {
            time += Time.deltaTime;

            if (IsWorkDone())
                OnWorkFinished(context);
        }

        private bool IsWorkDone()
            => (time > 3);

        private void OnWorkFinished(Worker context)
        {
            context.workingIndicator.SetActive(false);
            context.SetDestination(context.stockpileLocation.position);
            context.SetWorkerState(context.workerWalkingState);
        }
    }
}
