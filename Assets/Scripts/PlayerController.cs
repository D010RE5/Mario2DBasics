using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody2D rb;
    private Animator anime;
    [SerializeField]
    private float jumpForce;
    private bool facing;
    private float moveHorizontal;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }

    private void Update() {

        movePlayer();
        anime.SetBool("run", true);

        Debug.Log(facing);
        if(moveHorizontal>0 && facing)
        {
                ChangeFace();
        }
        if(moveHorizontal<0 && !facing)
        {
                ChangeFace();
        }
        if(moveHorizontal == 0)
        {
            anime.SetBool("run", false);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            GoUp();
            anime.SetTrigger("jump");
        }
        
    }

    private void movePlayer()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveHorizontal * speed * Time.deltaTime, rb.velocity.y);
    }
    private void GoUp()
    {
        rb.AddForce(Vector2.up * jumpForce);
    }

    private void ChangeFace()
    {
        facing = !facing;
        Vector2 change = gameObject.transform.localScale;
        change.x *= -1;
        transform.localScale = change;
    }
}
