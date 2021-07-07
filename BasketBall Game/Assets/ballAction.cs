using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballAction : MonoBehaviour
{
    private Rigidbody   rbBall;

    public  GameObject player;
    // Start is called before the first frame update

    void    Awake(){
        rbBall = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(CoroutineShoot3());
    }
    void Start()
    {
        rbBall.AddForce(new Vector3(0, 300, 300));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void        OnCollisionEnter (Collision collision){
        if(collision.gameObject.tag == "Scored"){
            Destroy(gameObject);
            player.GetComponent<PlayerMovement>().score ++;
        }
    }

    IEnumerator CoroutineShoot3(){
        yield return    new WaitForSeconds(6);
        Destroy(gameObject);
    }
}
