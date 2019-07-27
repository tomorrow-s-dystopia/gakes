using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageSystem : DamageSystem
{
    private PlayerStatus status;

    private AudioSource[] sounds;
    private int reduceDamage = 0;
    void Start()
    {
        status = GetComponent<PlayerStatus>();
        sounds = GetComponents<AudioSource>();
    }
    public override int CalculateDamage(int damage)
    {
        if (status.isBlocking && damage > 0) sounds[6].Play();
        return Mathf.Max(damage - reduceDamage, 0);
    }

    void Update()
    {
        reduceDamage = status.isBlocking ? 10 : 0;
       
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            sounds[3].Play();
        }

        if(Input.GetKeyUp(KeyCode.LeftShift)){
            sounds[4].Play();
        }
    }
}
