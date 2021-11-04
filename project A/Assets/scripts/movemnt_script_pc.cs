using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class movemnt_script_pc : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    private enum State { idle, run, jump,falling};
    private State state = State.idle;
    private Collider2D coll;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpforce = 10f;
    [SerializeField] private int diamondsmall = 0;
    [SerializeField] private Text diamondText;




    // Start is called before the first frame update
    void Start()
    {
     
    rb = GetComponent<Rigidbody2D>(); 
    anim = GetComponent<Animator>(); 
    coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float hDirection = Input.GetAxis("Horizontal");
       

        if (hDirection > 0)
        {
            rb.velocity = new Vector2(speed, 0);
           transform.localScale = new Vector2(1, 1);

        }
       else if (hDirection < 0)
        {
            rb.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(-1, 1);

        }
        else
        {

        }

   if (Input.GetKeyDown("space") && coll.IsTouchingLayers(Ground))

        {
          Debug.Log("entered");
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
          state = State.jump;
        }
     

    VelocityState();
    anim.SetInteger("State", (int)state);



    }


private void OnTriggerEnter2D(Collider2D collision)
{
  if(collision.tag == "diamondsmall")
  
  {
   Destroy(collision.gameObject);
  diamondsmall += 1;
  diamondText.text = diamondsmall.ToString();
    }
}
private void OnCollisionEnter2D(Collision2D other)
{
  if (other.gameObject.tag == "Enemy" && state == State.falling)
  {
     Destroy(other.gameObject); 
  }
}



    private void VelocityState()
{
  if (state == State.jump)
{
  if(rb.velocity.y < .1f)
{
  state = State.falling;
}
}
else if(state == State.falling)
{
  if(coll.IsTouchingLayers(Ground))
{
  state = State.idle;
}
}

else if (Mathf.Abs(rb.velocity.x) > 2f)
{
  state = State.run;
}
else
{
    state = State.idle;
}

}
}
                                                                                                                      