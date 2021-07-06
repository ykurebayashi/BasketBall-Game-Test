using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballAction : MonoBehaviour
{
    private Rigidbody   rbBall;
    // Start is called before the first frame update

    void    Awake(){
        rbBall = GetComponent<Rigidbody>();

    }
    void Start()
    {
        rbBall.AddForce(new Vector3(0, 300, 300));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
