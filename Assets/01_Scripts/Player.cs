using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    private Rigidbody2D playerRb;

    private Vector2 moveinput;
    private Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() //lo mejor para inputs 
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveinput = new Vector2(moveX, moveY).normalized;

        playerAnimator.SetFloat("Horizontal", moveX);
        playerAnimator.SetFloat("Vertical", moveY);
        playerAnimator.SetFloat("Speed", moveinput.sqrMagnitude);
    }

    private void FixedUpdate() // lo mejor para toda la actualizacion en base a la fisica 
    {
        playerRb.MovePosition(playerRb.position + moveinput * speed * Time.fixedDeltaTime);
    }
}

