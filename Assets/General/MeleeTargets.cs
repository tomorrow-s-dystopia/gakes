using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTargets : MonoBehaviour
{
    public List<HealthSystem> Targets;
    // Start is called before the first frame update
    void Start()
    {
        Targets = new List<HealthSystem>();
    }

    public void AddTarget(Collider2D target){
        HealthSystem targetHealth = target.GetComponent<HealthSystem>();
        Targets.Add(targetHealth);
    }

    public void RemoveTarget(Collider2D target){
        HealthSystem targetHealth = target.GetComponent<HealthSystem>();
        Targets.Remove(targetHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
