using UnityEngine;

public interface IFarmerState
{
    public void OnEnter(Farmer context);

    public void Update(Farmer context);
}
