using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int health = 1;   
    public int numOfHearths = 1;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Update is called once per frame
    void Update()
    {

        if (health > numOfHearths)
        {
            health = numOfHearths;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;

            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearths)
            {
                hearts[i].enabled = true;

            }
            else
            {
                hearts[i].enabled = false;
            }
        }


    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;

        if(health == 0)
        {
            Destroy(this.gameObject);
        }
        
    }
}
