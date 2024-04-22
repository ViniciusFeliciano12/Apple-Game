using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float moveTime;
    public float Speed;

    private bool dirRight = true;
    private float timer;
    // Update is called once per frame
    void Update()
    {
        if (dirRight)
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }else
        {
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
        }

        timer += Time.deltaTime;

        if (timer > moveTime)
        {
            dirRight = !dirRight;
            timer = 0f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
           
            GameController.instance.ShowGameOver();
        }
    }

}
