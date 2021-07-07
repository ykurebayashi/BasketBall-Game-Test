using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public     Rigidbody   rb;

    public  float   moveSpeed;

    private float   xInput;
    private float   zInput;

    public  float   jumpForce;

    public Animator    anim;

    public  GameObject ball;

    public  GameObject  locationBall;

    public  GameObject  theMainBall;

    public  Text    pointsText;

    public  float   score;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Shoot();
        pointsText.text = score.ToString();
    }

    private void    FixedUpdate(){
        Move();
    }

    private void    Move(){
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        rb.AddForce(new Vector3 (xInput, 0, zInput) * moveSpeed);
    }

    private void    Jump(){
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(new Vector3(0, jumpForce, 0));
        }
    }

    private void    Shoot(){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            anim.SetBool("Shooting", true);
            theMainBall.SetActive(false);
            StartCoroutine(CoroutineShoot());
            StartCoroutine(CoroutineShoot2());
        }
    }

    IEnumerator CoroutineShoot(){
        yield return    new WaitForSeconds(2f);
        anim.SetBool("Shooting", false);
        StartCoroutine(CoroutineWaitForBall());
    }

    IEnumerator CoroutineShoot2(){
        yield return    new WaitForSeconds(1.5f);
        Instantiate(ball, locationBall.transform.position, Quaternion.identity);
    }

        IEnumerator CoroutineWaitForBall(){
            yield return    new WaitForSeconds(0.5f);
            theMainBall.SetActive(true);
        }
}
