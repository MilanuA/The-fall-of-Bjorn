using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{

    //        Player = GameObject.FindGameObjectWithTag("Player").transform;

    public Transform Player;
    public float speed = 2f;
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {

        //rotate to look at the player
        transform.LookAt(Player.position);
        transform.Rotate(new Vector2(0, -90), Space.Self);//correcting the original rotation
        transform.rotation = Quaternion.Euler(0, transform.localEulerAngles.y, 0);



        //move towards the player
        if (Vector3.Distance(transform.position, Player.position) > 1f)
        {//move if distance from target is greater than 1
           
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            

        }

        if(speed == 2)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }
        

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            speed = 0;
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            speed = 2;
            
        }
    }


}
