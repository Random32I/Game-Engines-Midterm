using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    [SerializeField] int ID;
    [SerializeField] SingletonEnemy singleton;
    [SerializeField] GameObject player;

    private void Update()
    {
        if (Mathf.Round(player.transform.position.x) == transform.position.x)
        {
            PlayerBelow();
        }
    }

    //Observer Design Pattern
    public void OnHit()
    {
        singleton.UpdateEnemy(health, ID);
    }

    //Observer Design Pattern
    void PlayerBelow()
    {
        singleton.NotifyPlayerBelow(ID);
    }
}
