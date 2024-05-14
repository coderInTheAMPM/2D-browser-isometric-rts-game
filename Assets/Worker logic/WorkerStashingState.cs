using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

namespace PavleM.RDI.RTS
{
    public class WorkerStashingState : IWorkerState
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

            if (IsStashingDone())
                OnStashingFinished(context);
        }

        private bool IsStashingDone()
            => (time > 3);

        private void OnStashingFinished(Worker context)
        {
            context.workingIndicator.SetActive(false);
            context.SetDestination(context.workLocation.position);
            context.SetWorkerState(context.workerWalkingState);
        }
    }
}
