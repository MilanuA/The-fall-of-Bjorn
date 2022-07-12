using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public bool GotKey = false;

    public BoxCollider2D Key;
    public GameObject KeyRender;

    // Start is called before the first frame update
    void Start()
    {

    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GotKey = true;
            Key.enabled = false;
            Destroy(KeyRender);
        }
        if (col.gameObject.tag == "Player2")
        {
            GotKey = true;
            Key.enabled = false;
            Destroy(KeyRender);
        }
        if (col.gameObject.tag == "Player3")
        {
            GotKey = true;
            Key.enabled = false;
            Destroy(KeyRender);
        }

    }
}
