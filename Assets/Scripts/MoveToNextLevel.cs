using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/* SUBSCRIBING TO MY YOUTUBE CHANNEL: 'VIN CODES' WILL HELP WITH MORE VIDEOS AND CODE SHARING IN THE FUTURE :) THANK YOU */

public class MoveToNextLevel : MonoBehaviour
{
    public int nextSceneLoad;
    public Animator FadeScreenAniamtor;

    public bool player1entre = false;
    public bool player2entre = false;
    public bool player3entre = false;

    public bool UseKey = false;

    public KeyManager KM;

    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void Update()
    {
        if(UseKey == true)
        {
            if (player1entre == true && player2entre == true && player3entre == true && KM.GotKey == true)
            {

                if (SceneManager.GetActiveScene().buildIndex == 9)
                {
                    StartCoroutine(firstif());
                }
                else
                {
                    StartCoroutine(secondif());
                    if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                    {
                        PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                    }
                }
            }
        }
        else if (UseKey == false)
        {
            if (player1entre == true && player2entre == true && player3entre == true)
            {

                if (SceneManager.GetActiveScene().buildIndex == 9)
                {
                    StartCoroutine(firstif());
                }
                else
                {
                    StartCoroutine(secondif());
                    if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                    {
                        PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                    }
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            player1entre = true;
        }
        if (other.gameObject.tag == "Player2")
        {
            player2entre = true;
        }
        if (other.gameObject.tag == "Player3")
        {
            player3entre = true;
        }

    }

    IEnumerator firstif()
    {
        Debug.Log("Death Started");
        FadeScreenAniamtor.SetTrigger("Fade");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
    IEnumerator secondif()
    {
        Debug.Log("De Started");
        FadeScreenAniamtor.SetTrigger("Fade");
        yield return new WaitForSeconds(1);
        PlayerPrefs.SetInt("levelAt", nextSceneLoad);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
