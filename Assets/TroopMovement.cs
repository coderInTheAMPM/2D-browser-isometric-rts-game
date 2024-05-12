using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

public class TroopMovement : MonoBehaviour
{
    public NavMeshAgent agent;

    // public Tilemap groundTilemap;
    
    public float deltaDistanceFromTarget;

    private Vector3 destination;

    void Start()
    {
        destination = transform.position;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        if (DidRightClick())
            HandleMouseClick();

        if (Vector3.Distance(transform.position, destination) > deltaDistanceFromTarget)
            agent.SetDestination(destination);
        //transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

    }

    private bool DidRightClick()
        => Input.GetMouseButtonDown(1);

    private void HandleMouseClick()
    {
        var mouseClickPositionScreenXY = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        var mouseClickPositionWorld = Camera.main.ScreenToWorldPoint(mouseClickPositionScreenXY);
        mouseClickPositionWorld.z = 0;

        destination = mouseClickPositionWorld;

        //var clickedGridPosition = groundTilemap.WorldToCell(mouseClickPositionWorld);
    }
}
