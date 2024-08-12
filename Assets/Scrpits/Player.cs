using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public float walk_speed, walkback_speed, oldwalk_speed, run_speed, rotate_speed;
    public bool walking;
    public Transform playerTrans;


    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRigid.velocity = transform.forward * walk_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerRigid.velocity = -transform.forward * walkback_speed * Time.deltaTime;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("walk");
            playerAnim.ResetTrigger("idle");
            walking = true;
            //steps1.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.ResetTrigger("walk");
            playerAnim.SetTrigger("idle");
            walking = false;
            //steps1.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("walkback");
            playerAnim.ResetTrigger("idle");
            //steps1.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.ResetTrigger("walkback");
            playerAnim.SetTrigger("idle");
            //steps1.SetActive(false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerTrans.Rotate(0, -rotate_speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(0, rotate_speed * Time.deltaTime, 0);
        }
        if (walking == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                //steps1.SetActive(false);
                //steps2.SetActive(true);
                walk_speed = walk_speed + run_speed;
                playerAnim.SetTrigger("run");
                playerAnim.ResetTrigger("walk");
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                //steps1.SetActive(true);
                //steps2.SetActive(false);
                walk_speed = oldwalk_speed;
                playerAnim.ResetTrigger("run");
                playerAnim.SetTrigger("walk");
            }
        }
    }
}