using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody fizik;
    float horizontal = 0;
    float vertical = 0;
    public float hiz;
    public float maxX;
    public float minX;
    public float minZ;
    public float maxZ;
    public float egim;
    float fireTime = 0;
    public float firePastTime;
    public GameObject bullet;
    public Transform whereBullet;
    Vector3 vec;
    void Start()
    {
        fizik = GetComponent<Rigidbody>();

    }
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time>fireTime)
        {
            fireTime = Time.time + firePastTime;
            Instantiate(bullet, whereBullet.position, bullet.transform.rotation);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        vec = new Vector3(horizontal, 0, vertical);

        fizik.velocity = vec*hiz;

        fizik.position = new Vector3
        (
            Mathf.Clamp(fizik.position.x,minX,maxX),
            0.0f,
            Mathf.Clamp(fizik.position.z,minZ,maxZ)

        );

        fizik.rotation = Quaternion.Euler(0, 0, fizik.velocity.x*-egim);
    }
}
