using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPosition : MonoBehaviour
{
    private PolygonCollider2D bodyCollider;
    // Start is called before the first frame update
    void Start()
    {
        bodyCollider = GetComponent<PolygonCollider2D>();
    }

    public void flip()
    {
        var points = new List<Vector2>();
        foreach(Vector2 point in bodyCollider.points){
            points.Add(new Vector2(-point.x,point.y));
        }
        bodyCollider.SetPath(0,points.ToArray());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
