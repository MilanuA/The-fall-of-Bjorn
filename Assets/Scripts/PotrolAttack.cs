using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotrolAttack : MonoBehaviour
{
    public float cooldown = 1;
    public float cooldowntimer;
    public bool Attack = false;
    public Rigidbody2D ParentRB;
    private int Dmg = 1;

    [Header("Player Health")]
    public Health Player1Health;
    public Health Player2Health;
    public Health Player3Health;

    void Start()
    {
        Player1Health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        Player2Health = GameObject.FindGameObjectWithTag("Player2").GetComponent<Health>();
        Player3Health = GameObject.FindGameObjectWithTag("Player3").GetComponent<Health>();
    }
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
            
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && Attack == true)
        {
            Player1Health.TakeDamage(Dmg);
            cooldowntimer = cooldown;
        }
        if (other.gameObject.tag == "Player2" && Attack == true)
        {
            Player2Health.TakeDamage(Dmg);
            cooldowntimer = cooldown;
        }
        if (other.gameObject.tag == "Player3" && Attack == true)
        {
            Player3Health.TakeDamage(Dmg);
            cooldowntimer = cooldown;
        }

        if (other.gameObject.tag == "BOX")
        {
            Destroy(other.gameObject);
        }
    }

}


