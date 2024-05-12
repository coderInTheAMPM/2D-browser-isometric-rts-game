using UnityEngine;

public class FarmerWalkingState : IFarmerState
{
    public void OnEnter(Farmer context)
    {
        context.GoToDestination();
    }

    public void Update(Farmer context)
    {
        if (context.CloseEnoughToDestination())
        {
            if (context.destination.Equals(context.farmLocation.position))
                context.SetFarmerState(context.farmerWorkingState);

            if (context.destination.Equals(context.stockpileLocation.position))
                context.SetFarmerState(context.farmerStashingState);
        }
    }
}
