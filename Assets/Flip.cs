using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public SpriteRenderer sr;
    private float movementSpeed = 3.0f;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // bool flipped = movement.x<0;
        //this.transform.rotation = Quaternion.Euler(new Vector3(flipped ? 180f: 0f,0f, 0f));
    }

   /**  private void FixedUpdate()
    {
       if(movement != Vector2.zero)
        {
            var xMovement = movement.x *movementSpeed*Time.deltaTime;
            this.transform.Translate(new Vector3(xMovement,0), Space.World);
        }
    }*/
    
}
