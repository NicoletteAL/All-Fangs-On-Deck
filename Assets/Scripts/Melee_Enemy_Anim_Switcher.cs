using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Enemy_Anim_Switcher : MonoBehaviour
{
    public Animator zombieAnimate;

    public string maintenant = "Zombie_Idle_Legs";

    // Start is called before the first frame update
    void Start()
    {
        next_Animation_For_Zombie("Zombie_Idle_Legs");
       // next_Animation_For_Zombie("Zombie_Idle_Arms");
    }

    public void next_Animation_For_Zombie(string moving, float v = 1)
    {

       zombieAnimate.speed = v;




        if (maintenant == moving)
        {
            return;
        }

        maintenant = moving;

        zombieAnimate.Play(moving);
       

    }

}
