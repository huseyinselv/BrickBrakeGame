
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PaddleController : MonoBehaviour
{


    [SerializeField]
    float speed;

    [SerializeField]
    float leftTarget,rightTarget;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if (gameManager.gameOver)
            return;
            
        
        //Start moving
        float h = UnityEngine.Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right*h*Time.deltaTime*speed);
       
        //Sýnýrlandýrma yapýldý
        Vector2 temp = transform.position;
        temp.x=Mathf.Clamp(temp.x, leftTarget, rightTarget);
        transform.position = temp;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "LiveUpBall")
        {
            gameManager.UpdateLives(1);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "scoreUpBall")
        {
            gameManager.UpdateScore(10);
            Destroy(other.gameObject);
        }
    }
}

