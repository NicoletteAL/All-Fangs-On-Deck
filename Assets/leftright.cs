using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftright : MonoBehaviour
{

    private Rigidbody2D body;
    private SpriteRenderer SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
       body = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        body.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        SpriteRenderer.flipX = body.velocity.x < 0f;
    }
}
