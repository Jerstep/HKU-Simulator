using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformingPlayer : MonoBehaviour
{
    //groundcheck
    public bool onGround;
    //jump
    float jumpheight = 6;
    public float moveSpeed;

    //rigidbody
    private Rigidbody2D RigidPlayer;
    Animator anim;

    public GameObject platformingSection;

    //bullet timing
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    public GameObject bulletPrefab;
    public Transform firePos1, firePos2;
    public float lastMove;

    // Start is called before the first frame update
    void Start()
    {
        RigidPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //left right
        if (Input.GetAxisRaw("Horizontal") > 0.5f  || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal")* moveSpeed * Time.deltaTime , 0, 0));
            RigidPlayer.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, RigidPlayer.velocity.y);
            lastMove = Input.GetAxisRaw("Horizontal");
        }

        //up down
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f )
        {
            if (onGround)
            {
                //transform.Translate(new Vector3(0, Input.GetAxisRaw("Vertical")* moveSpeed * Time.deltaTime , 0));
                RigidPlayer.velocity = new Vector2(RigidPlayer.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
                onGround = false;
                //lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }
        }
        //stop moving man wtf
        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            RigidPlayer.velocity = new Vector2(0f, RigidPlayer.velocity.y);
        }


        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if(lastMove < -0.1f)
            {
                Instantiate(bulletPrefab, firePos2.position, firePos2.rotation);
            }
            else
            {
                Instantiate(bulletPrefab, firePos1.position, firePos1.rotation);
            }
            
            
            //anim.SetBool("Fire", true);
        }

        //tell animator to do
        /*anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("Moving", Moving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
        */
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Ground")
        {
            onGround = true;
        }

        if (col.tag == "Enemy")
        {
            
        }

        if (col.tag == "EndPoint")
        {
            platformingSection.SetActive(false);
        }
    }
}
