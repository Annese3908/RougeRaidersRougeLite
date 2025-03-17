using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy enemyData;
    // Data for enemy
   protected float currCooldown;
   protected float currDamage;

    // Start is called before the first frame update
    void Awake(){
        currDamage = enemyData.Damage;
    }
    protected virtual void Start()
    {
        currCooldown = 0.45f;
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        currCooldown -= Time.deltaTime;
        if (currCooldown <= 0f){
            Attack();
        }
    }
   protected virtual void Attack(){
        currCooldown = 0.45f;
   }
    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (currCooldown <= 0f)
        {
            if (col.CompareTag("Player"))
            {
                PlayerStats player = col.GetComponent<PlayerStats>();
                if (player != null)
                {
                    player.TakeDamage(currDamage); // Apply damage to the player
                }
            }
        }
    }
}

