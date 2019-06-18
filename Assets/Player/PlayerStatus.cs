using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public bool isDead;
    public bool isBlocking;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<HealthSystem>().DecreaseHealth(13);
        }
    }
}
