using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Farmer : MonoBehaviour
{
    public NavMeshAgent agent;

    public float deltaDistanceFromTarget;

    public Transform farmLocation;
    public Transform stockpileLocation;

    public Vector3 destination;
    private IFarmerState farmerState;
    public string farmerStateString = "";

    public readonly FarmerWorkingState farmerWorkingState = new FarmerWorkingState();
    public readonly FarmerStashingState farmerStashingState = new FarmerStashingState();
    public readonly FarmerWalkingState farmerWalkingState = new FarmerWalkingState();

    public GameObject workingIndicator; // loading gif

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        SetFarmerDestination(farmLocation.position);
        SetFarmerState(farmerWalkingState);
    }

    public void SetFarmerDestination(Vector3 destination)
        => this.destination = destination;

    public void SetFarmerState(IFarmerState newState)
    {
        farmerState = newState;
        farmerState.OnEnter(this);
        farmerStateString = farmerState.ToString();
    }

    public void GoToDestination()
    {
        agent.SetDestination(destination);
    }

    public bool CloseEnoughToDestination()
        => DistanceFrom(destination) < deltaDistanceFromTarget;

    private float DistanceFrom(Vector3 target)
        => Vector3.Distance(transform.position, target);

    private void Update()
    {
        farmerState.Update(this);
    }
}
