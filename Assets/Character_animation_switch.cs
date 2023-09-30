using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_animation_switch : MonoBehaviour
{
    public Animator princeAnimate;

    public string maintenant = "Standing_There";

    // Start is called before the first frame update
    void Start()
    {
        next_Animation_For_Prince("Standing_There");
    }

    public void next_Animation_For_Prince(string moving, float v = 1)
    {
        
        princeAnimate.speed = v;
        
        if(maintenant == moving)
        {
            return;
        }

        maintenant = moving;

        princeAnimate.Play(moving);
        
    }
 
}
