using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    bool hurtPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 5 || transform.position.y <= -5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Enemy" && hurtPlayer == false)
        {
            collision.GetComponent<Enemy>().OnHit();
            Destroy(gameObject);
        }
        else if (collision.name == "Player" && hurtPlayer == true)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    //Command Design Pattern
    public void Shoot(float speed, int direction, bool damagePlayer, Vector3 startPos)
    {
        GameObject newBullet = Instantiate(gameObject);
        newBullet.name = "Bullet";
        newBullet.transform.position = startPos;
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed * direction);
        newBullet.GetComponent<Bullet>().hurtPlayer = damagePlayer;
    }
}
