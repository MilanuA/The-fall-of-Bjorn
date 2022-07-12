using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ingameUI : MonoBehaviour
{
    public GameObject FadeScreen;
    public Animator FadeScreenAniamtor;
    public float time;

    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void RestartGame()
    {
        StartCoroutine(Death());
    }
    IEnumerator Death()
    {
        Debug.Log("Death Started");
        FadeScreenAniamtor.SetTrigger("Fade");
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Death Ended");
    }

}
