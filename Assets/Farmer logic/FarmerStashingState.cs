using UnityEngine;

public class FarmerStashingState : IFarmerState
{
    float time;

    public void OnEnter(Farmer context)
    {
        Debug.Log("skladistim");
        time = 0;
    }

    public void Update(Farmer context)
    {
        time += Time.deltaTime;

        if (time > 3) // Gotov
        {
            context.SetFarmerDestination(context.farmLocation.position);
            context.SetFarmerState(context.farmerWalkingState);
        }
    }
}
