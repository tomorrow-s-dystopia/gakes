using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    public float DistanceVertical = 0f;
    public float DistanceHorziontal = 0f;
    public float totalDistance = 0f;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    void LateUpdate()
    {
        DistanceHorziontal = target.transform.position.x - transform.position.x -0.5f;
        DistanceVertical = target.transform.position.y - transform.position.y;
        totalDistance = Mathf.Sqrt(Mathf.Pow(DistanceHorziontal, 2) + Mathf.Pow(DistanceVertical, 2));
    }
}
