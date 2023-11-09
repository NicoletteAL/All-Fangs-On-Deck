using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged_Enemy_Anim_Switcher : MonoBehaviour
{
    public Animator skellyAnimate;

    public string maintenant = "Skelly_Legs_Idle";

    // Start is called before the first frame update
    void Start()
    {
        next_Animation_For_Skelly("Skelly_Legs_Idle");
      
    }

    public void next_Animation_For_Skelly(string moving, float v = 1)
    {

       skellyAnimate.speed = v;




        if (maintenant == moving)
        {
            return;
        }

        maintenant = moving;

        skellyAnimate.Play(moving);
       

    }

}
