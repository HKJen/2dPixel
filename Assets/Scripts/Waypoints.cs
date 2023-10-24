using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypoint;
    [SerializeField] private float speed = 2f;

    void Start()
    {
        
    }

    void Update()
    {
        if(Vector2.Distance(waypoints[currentWaypoint].transform.position, transform.position) < 0.1f) {
            currentWaypoint ++;
            if(currentWaypoint >= waypoints.Length) {
                currentWaypoint = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * speed);
    }
}
