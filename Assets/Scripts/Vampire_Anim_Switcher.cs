using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire_Anim_Switcher : MonoBehaviour
{
    public Animator vampireAnimate;

    public string maintenant = "Vampire_Idle_Legs";

    // Start is called before the first frame update
    void Start()
    {
        next_Animation_For_Vamp("Vampire_Idle_Arms");
        next_Animation_For_Vamp("Vampire_Idle_Legs");
    }

    public void next_Animation_For_Vamp(string moving, float v = 1)
    {

       vampireAnimate.speed = v;


        if (maintenant == moving)
        {
            return;
        }

        maintenant = moving;

        vampireAnimate.Play(moving);
       
    }

}
