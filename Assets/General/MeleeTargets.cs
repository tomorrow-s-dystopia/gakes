using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTargets : MonoBehaviour
{
    public List<HealthSystem> targets;
    // Start is called before the first frame update
    void Start()
    {
        targets = new List<HealthSystem>();
    }

    public void addTarget(Collider2D target){
        HealthSystem targetHealth = target.GetComponent<HealthSystem>();
        targets.Add(targetHealth);
    }

    public void removeTarget(Collider2D target){
        HealthSystem targetHealth = target.GetComponent<HealthSystem>();
        targets.Remove(targetHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
