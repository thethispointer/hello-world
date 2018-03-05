using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerController : MonoBehaviour {
    public float speed = 2; //slow will change in editor IDE GUI
    private Animator anim;
    private bool playerMoving;
    private Vector2 lastMove;
 
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
   
    // Update is called once per frame
    void Update () {
        playerMoving = false;
        Vector3 pos = transform.position;
        pos.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        pos.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position = pos;
 
        if (Input.GetAxisRaw("Horizontal") > 0.5f)
        {
            playerMoving = true;
            lastMove.x = 1;
        }
        if (Input.GetAxisRaw("Horizontal") < 0.5f)
        {
            playerMoving = true;
            lastMove.x = -1;
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f)
        {
            playerMoving = true;
            lastMove.y = 1;
        }
        if (Input.GetAxisRaw("Vertical") < 0.5f)
        {
            playerMoving = true;
            lastMove.y = -1;
        }
 
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastX", lastMove.x);
        anim.SetFloat("LastY", lastMove.y);
    }
}