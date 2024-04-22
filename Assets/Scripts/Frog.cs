using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;
    private BoxCollider2D box;
    private CircleCollider2D circle;

    public float speed;
    public Transform rightCol;
    public Transform leftCol;

    public Transform headCol;
    private bool colliding;
    public LayerMask layer;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        circle = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);

        if (colliding){
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed *= -1f;
        }
    }

    bool playerDestroyed = false;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player"){
            float height = col.contacts[0].point.y - headCol.position.y;

            if (height > 0 && !playerDestroyed){
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                speed = 0;
                box.enabled = false;
                circle.enabled = false;
                anim.SetTrigger("die");
                Destroy(gameObject, 0.33f);
            }else{
                playerDestroyed = true;
                GameController.instance.ShowGameOver();
                Destroy(col.gameObject);
            }
        }
    }   
}
