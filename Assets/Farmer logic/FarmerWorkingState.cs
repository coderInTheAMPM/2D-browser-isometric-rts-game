using UnityEngine;

public class FarmerWorkingState : IFarmerState
{
    float time;

    public void OnEnter(Farmer context)
    {
        Debug.Log("radim");
        time = 0;
    }

    public void Update(Farmer context) 
    {
        time += Time.deltaTime;

        if(time > 3) // Gotov
        {
            context.SetFarmerDestination(context.stockpileLocation.position);
            context.SetFarmerState(context.farmerWalkingState);
        }
    }
}
