using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public Enemy enemyData;
    public GameObject dropPrefab;
    // Current Stats
    float currMoveSpeed;
    float currHealth;
    float currDamage;
    float dropChance = 0.45f;
    // Start is called before the first frame update
    void Awake()
    {
        currMoveSpeed = enemyData.MoveSpeed;
        currHealth = enemyData.MaxHealth;
        currDamage = enemyData.Damage;
    }

    // Update is called once per frame
    public void TakeDamage(float dmg)
    {
        currHealth -= dmg;
        if (currHealth <= 0){
            Kill();
        }
    }
    public void Kill(){
        if (dropPrefab != null && Random.value <= dropChance){
            Instantiate(dropPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
