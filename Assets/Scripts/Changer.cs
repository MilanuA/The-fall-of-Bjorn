using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Changer : MonoBehaviour
{
    [Header("PlayerMovement")]
    public FitPlayer Player1;
    public FighterPlayer Player2;
    public TorchPlayer Player3;

    public Image ActivePointPlayer1;
    public Image ActivePointPlayer2;
    public Image ActivePointPlayer3;

    public Rigidbody2D FitRB;
    public Rigidbody2D FightRB;
    public Rigidbody2D TorchRB;
    //    [Header("PlayerAI")]
    //  public PlayerAI Player111;
    //  public PlayerAI Player222;
    //   public PlayerAI Player333;

    public bool bol = true;
    private void Start()
    {
        Player1.enabled = true;
        Player2.enabled = false;
        Player3.enabled = false;

        ActivePointPlayer1.color = Color.red;
        ActivePointPlayer2.color = Color.grey;
        ActivePointPlayer3.color = Color.grey;

        FitRB.bodyType = RigidbodyType2D.Dynamic;
        FightRB.bodyType = RigidbodyType2D.Static;
        TorchRB.bodyType = RigidbodyType2D.Static;

    }

    private void Update()
    {
        #region If everyone is alive
        if (Player1 != null && Player2 != null && Player3 != null)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Player1.enabled = true;
                Player2.enabled = false;
                Player3.enabled = false;
                //   Player111.enabled = false;
                //   Player222.enabled = true;
                //   Player333.enabled = true;
                //   Player111.transform.rotation = Quaternion.identity;
                //   Player222.Player = GameObject.FindGameObjectWithTag("Player").transform;
                //   Player333.Player = GameObject.FindGameObjectWithTag("Player").transform;
                ActivePointPlayer1.color = Color.red;
                ActivePointPlayer2.color = Color.grey;
                ActivePointPlayer3.color = Color.grey;

                FitRB.bodyType = RigidbodyType2D.Dynamic;
                FightRB.bodyType = RigidbodyType2D.Static;
                TorchRB.bodyType = RigidbodyType2D.Static;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Player1.enabled = false;
                Player2.enabled = true;
                Player3.enabled = false;
                //    Player111.enabled = true;
                //    Player222.enabled = false;
                //    Player333.enabled = true;
                //    Player222.transform.rotation = Quaternion.identity;
                //    Player111.Player = GameObject.FindGameObjectWithTag("Player2").transform;
                //   Player333.Player = GameObject.FindGameObjectWithTag("Player2").transform;
                ActivePointPlayer1.color = Color.grey;
                ActivePointPlayer2.color = Color.red;
                ActivePointPlayer3.color = Color.grey;

                FitRB.bodyType = RigidbodyType2D.Static;
                FightRB.bodyType = RigidbodyType2D.Dynamic;
                TorchRB.bodyType = RigidbodyType2D.Static;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Player1.enabled = false;
                Player2.enabled = false;
                Player3.enabled = true;
                //   Player111.enabled = true;
                //   Player222.enabled = true;
                //   Player333.enabled = false;
                //   Player333.transform.rotation = Quaternion.identity;
                //   Player111.Player = GameObject.FindGameObjectWithTag("Player3").transform;
                //  Player222.Player = GameObject.FindGameObjectWithTag("Player3").transform;
                ActivePointPlayer1.color = Color.grey;
                ActivePointPlayer2.color = Color.grey;
                ActivePointPlayer3.color = Color.red;

                FitRB.bodyType = RigidbodyType2D.Static;
                FightRB.bodyType = RigidbodyType2D.Static;
                TorchRB.bodyType = RigidbodyType2D.Dynamic;
            }

        }

        #endregion

        #region If player1 is dead and the rest is alive
        if (Player1 == null && Player2 != null && Player3 != null)
        {
            /* if (bol)
             {
                 Player2.enabled = true;
                 Player3.enabled = false;
                 ActivePointPlayer2.color = Color.red;
                 ActivePointPlayer3.color = Color.grey;

                 FightRB.bodyType = RigidbodyType2D.Dynamic;
                 TorchRB.bodyType = RigidbodyType2D.Static;


             }

             if (Input.GetKeyDown(KeyCode.Alpha2))
             {
                 bol = false;
                 Player2.enabled = true;
                 Player3.enabled = false;
                 ActivePointPlayer2.color = Color.red;
                 ActivePointPlayer3.color = Color.grey;

                 FightRB.bodyType = RigidbodyType2D.Dynamic;
                 TorchRB.bodyType = RigidbodyType2D.Static;


             }

             if (Input.GetKeyDown(KeyCode.Alpha3))
             {
                 bol = false;
                 Player2.enabled = false;
                 Player3.enabled = true;
                 /*  Player222.enabled = true;
                   Player333.enabled = false;
                   Player333.transform.rotation = Quaternion.identity;
                   Player222.Player = GameObject.FindGameObjectWithTag("Player3").transform; 
                 ActivePointPlayer2.color = Color.grey;
                 ActivePointPlayer3.color = Color.red;

                 FightRB.bodyType = RigidbodyType2D.Static;
                 TorchRB.bodyType = RigidbodyType2D.Dynamic;
             } */
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        #endregion

        #region If player1 is dead, player2 is dead and the player3 is alive 
        if (Player1 == null && Player2 == null && Player3 != null)
        {
            /* Player3.enabled = true;
             //  Player333.enabled = false;
             //  Player333.transform.rotation = Quaternion.identity;
             ActivePointPlayer3.color = Color.red;
             TorchRB.bodyType = RigidbodyType2D.Dynamic; */
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        #endregion

        #region If Player1 is alive, Player2 is dead and Player3 is alive
        if (Player1 != null && Player2 == null && Player3 != null)
        {
           /* if (bol)
            {
                Player1.enabled = true;
                Player3.enabled = false;

                ActivePointPlayer1.color = Color.red;
                ActivePointPlayer3.color = Color.grey;

                FitRB.bodyType = RigidbodyType2D.Dynamic;
                TorchRB.bodyType = RigidbodyType2D.Static;
            }
           

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                bol = false;
                Player1.enabled = true;
                Player3.enabled = false;
                
                ActivePointPlayer1.color = Color.red;
                ActivePointPlayer3.color = Color.grey;

                FitRB.bodyType = RigidbodyType2D.Dynamic;
                TorchRB.bodyType = RigidbodyType2D.Static;
                Debug.Log("Alfa1");
            }
           

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                bol = false;
                Player1.enabled = false;
                Player3.enabled = true;
                ActivePointPlayer1.color = Color.grey;

                ActivePointPlayer3.color = Color.red;
                
                FitRB.bodyType = RigidbodyType2D.Static;
                TorchRB.bodyType = RigidbodyType2D.Dynamic;
                Debug.Log("Alfa3"); 

            } */
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        #endregion

        #region If Player1 is dead, Player2 is alive and Player3 is dead
        if (Player1 == null && Player2 != null && Player3 == null)
        {
            /*  Player2.enabled = true;
              //  Player222.enabled = false;
              // Player222.transform.rotation = Quaternion.identity;
              ActivePointPlayer2.color = Color.red;
              FightRB.bodyType = RigidbodyType2D.Dynamic; */

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        #endregion

        #region If Player1 is alive, Player2 is alive and Player3 is dead
        if (Player1 != null && Player2 != null && Player3 == null)
        {
           /* if (bol)
            {
                Player1.enabled = true;
                Player2.enabled = false;
                ActivePointPlayer1.color = Color.red;
                ActivePointPlayer2.color = Color.grey;
                FitRB.bodyType = RigidbodyType2D.Dynamic;
                FightRB.bodyType = RigidbodyType2D.Static; 
            }
           
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                bol = false;
                Player1.enabled = true;
                Player2.enabled = false;               
                ActivePointPlayer1.color = Color.red;
                ActivePointPlayer2.color = Color.grey;
                FitRB.bodyType = RigidbodyType2D.Dynamic;
                FightRB.bodyType = RigidbodyType2D.Static;
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                bol = false;
                Player1.enabled = false;
                Player2.enabled = true;               
                ActivePointPlayer1.color = Color.grey;
                ActivePointPlayer2.color = Color.red;
                FitRB.bodyType = RigidbodyType2D.Static;
                FightRB.bodyType = RigidbodyType2D.Dynamic;
            }
            */


        }

        #endregion

        #region If Player1 is alive, Player2 is dead and Player3 is dead
        if (Player1 != null && Player2 == null && Player3 == null)
        {    
             /*   Player1.enabled = true;
            //   Player111.enabled = false;               
            //  Player111.transform.rotation = Quaternion.identity;
            ActivePointPlayer1.color = Color.red;
            FitRB.bodyType = RigidbodyType2D.Dynamic; */
        }
        #endregion

        #region If everyone is dead
        if(Player1 == null && Player2 == null && Player3 == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        #endregion
    }

 
}
 