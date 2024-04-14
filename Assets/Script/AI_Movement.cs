using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Movement : MonoBehaviour
{

    Animator animator;

    public float movespeed = 5f;

    Vector3 stopPosition;

    float walkTime;
    public float walkCounter;
    float waitTime;
    public float waitCounter;

    float WalkDirection;

    public bool isWalking;
    public bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();


        //So that all the prefabs don't move/stop at the same time
        walkTime = Random.Range(3, 6);
        waitTime = Random.Range(5, 7);

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if(isWalking)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isRunning", false);
            animator.SetBool("isIdle", false);

            walkCounter -= Time.deltaTime;

            transform.localRotation = Quaternion.Euler(0, WalkDirection, 0);
            transform.position += transform.forward * movespeed * Time.deltaTime;


            if(walkCounter <= 0)
            {
                stopPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                isWalking = false;
                //stop movement
                transform.position = stopPosition;
                animator.SetBool("isWalking", false);
                animator.SetBool("isIdle", true);
                //reset the waitCounter
                waitCounter = waitTime;
            }
        }
        if (isRunning)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", true);
            animator.SetBool("isIdle", false);

            walkCounter -= Time.deltaTime;

            transform.localRotation = Quaternion.Euler(0, WalkDirection, 0);
            transform.position += transform.forward * movespeed * Time.deltaTime * 1.25f;


            if (walkCounter <= 0)
            {
                stopPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                isRunning = false;
                //stop movement
                transform.position = stopPosition;
                animator.SetBool("isRunning", false);
                animator.SetBool("isIdle", true);
                //reset the waitCounter
                waitCounter = waitTime;
            }
        }
        if (!isRunning && !isWalking) 
        {
            waitCounter -= Time.deltaTime;

            if(waitCounter <= 0)
            {
                ChooseDirection();
            }
        }

    }

    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 360);

        if (Random.Range(0,2) == 0)
        {
            isWalking = true;
        }
        else
        {
            isRunning = true;
        }
        walkCounter = walkTime;
    }
}
