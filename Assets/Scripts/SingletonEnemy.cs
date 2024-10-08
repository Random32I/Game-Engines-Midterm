using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SingletonEnemy : MonoBehaviour
{
    //Singleton Design Pattern

    [SerializeField] GameObject[] enemies = new GameObject[8];

    int direction = 1;
    bool moved;
    bool shot;
    [SerializeField] Bullet bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Floor(Time.timeSinceLevelLoad * 100) / 100 % 2 == 0 && moved == false)
        {
            transform.position += Vector3.right * direction;
            if (transform.position.x >= 6 || transform.position.x <= -6)
            {
                transform.position -= Vector3.up;
                direction *= -1;
            }

            moved = true;
            shot = false;
        }
        else
        {
            moved = false;
            
        }
    }

    public void UpdateEnemy(int health, int ID)
    {
        if (health == 1)
        {
            Destroy(enemies[ID]);
        }
        else
        {
            enemies[ID].GetComponent<SpriteRenderer>().color = Color.blue;
            enemies[ID].GetComponent<Enemy>().health--;
        }
    }

    public void NotifyPlayerBelow(int ID)
    {
        if (!shot)
        {
            shot = true;
            bullet.Shoot(4, -1, true, enemies[ID].transform.position);
        }
    }
}
