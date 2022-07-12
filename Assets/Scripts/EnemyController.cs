using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Player Transform")]
    private Animator anim;
    private Transform player;
    private EnemyFollow EF;

    [Header("Useless stuff")]
    public bool isFlipped = false;
    public float FollowRange = 3f;
    private Rigidbody2D rb;
    public int Dmg = 1;
    public float cooldown = 1;
    public float cooldowntimer;
    public bool Attack = false;
    public CapsuleCollider2D EnemyAttackCollider;
    

    [Header("Player Health")]
    public Health Player1Health;
    public Health Player2Health;
    public Health Player3Health;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

     // player = GameObject.FindGameObjectWithTag("Player").transform;

        Player1Health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        Player2Health = GameObject.FindGameObjectWithTag("Player2").GetComponent<Health>();
        Player3Health = GameObject.FindGameObjectWithTag("Player3").GetComponent<Health>();

        EF = GetComponent<Animator>().GetBehaviour<EnemyFollow>();
    }

    // Update is called once per frame


    void Update()
    {
        if (cooldowntimer > 0)
        {
            Attack = false;
            cooldowntimer -= Time.deltaTime;
        }

        if (cooldowntimer < 0)
        {
            cooldowntimer = 0;
        }
        if (cooldowntimer == 0)
        {
            Attack = true;
            EnemyAttackCollider.size = new Vector2(0.1522528f, 0.32f);
            EF.speed = 2.5f;
        }
    }

  /*  public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > 0 && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < 0 && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    } */

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("FollowZone", true);
            EF.player = GameObject.FindGameObjectWithTag("Player").transform;
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if (other.gameObject.tag == "Player2")
        {
            anim.SetBool("FollowZone", true);
            EF.player = GameObject.FindGameObjectWithTag("Player2").transform;
            player = GameObject.FindGameObjectWithTag("Player2").transform;
        }
        if (other.gameObject.tag == "Player3")
        {
            anim.SetBool("FollowZone", true);
            EF.player = GameObject.FindGameObjectWithTag("Player3").transform;
            player = GameObject.FindGameObjectWithTag("Player3").transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("FollowZone", false);
        }
        if (other.gameObject.tag == "Player2")
        {
            anim.SetBool("FollowZone", false);
        }
        if (other.gameObject.tag == "Player3")
        {
            anim.SetBool("FollowZone", false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && Attack == true)
        {
            Player1Health.TakeDamage(Dmg);
            anim.SetTrigger("Attack");
            EF.speed = 0.5f;
            cooldowntimer = cooldown;
            EnemyAttackCollider.size = new Vector2(0.09f, 0.32f);
        }
        if (other.gameObject.tag == "Player2" && Attack == true)
        {
            Player2Health.TakeDamage(Dmg);
            anim.SetTrigger("Attack");
            EnemyAttackCollider.size = new Vector2(0.09f, 0.32f);
            cooldowntimer = cooldown;
            EF.speed = 0.5f;
        }
        if (other.gameObject.tag == "Player3" && Attack == true)
        {
            Player3Health.TakeDamage(Dmg);
            anim.SetTrigger("Attack");
            cooldowntimer = cooldown;
            EnemyAttackCollider.size = new Vector2(0.09f, 0.32f);
            EF.speed = 0.5f;
        }

        if (other.gameObject.tag == "BOX")
        {
            Destroy(other.gameObject);
            anim.SetTrigger("Attack");

        }
    }

    
}
