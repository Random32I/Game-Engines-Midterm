using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rig;
    [SerializeField] Bullet bullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rig.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        bullet.Shoot(4, 1, false, transform.position);
    }


}
