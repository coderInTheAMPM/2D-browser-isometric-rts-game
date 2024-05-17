namespace PavleM.RDI.RTS
{
    public class WorkerWalkingState : IWorkerState
    {
        public void OnEnter(Worker context)
            => context.GoToDestination();

        public void Update(Worker context)
        {
            if (context.CloseEnoughToDestination())
            {
                if (context.IsAtWorkplace())
                    context.SetWorkerState(context.workerWorkingState);

                if (context.IsAtStockpile())
                    context.SetWorkerState(context.workerStashingState);
            }
        }
    }
}
