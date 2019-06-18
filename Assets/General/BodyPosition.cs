using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPosition : MonoBehaviour
{
    private Collider2D bodyCollider;
    // Start is called before the first frame update
    void Start()
    {
        bodyCollider = GetComponent<Collider2D>();
    }

    public void flip()
    {
        bodyCollider.offset = new Vector2(-bodyCollider.offset.x, bodyCollider.offset.y);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
