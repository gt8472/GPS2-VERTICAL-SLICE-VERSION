using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Material JiangShiMaterial;
    public float speed = 10;
    //int DownSpeed = 2;//for enemy fall down speed
    public float hp = 150;//enemy damage
    private float totalHp;
    private Slider hpSlider;
    private Transform[] positions;
    private int index = 0;
    public int EarnMoney = 10;
    //public float dieTimer = 0.1f;
    //public float continueDieTimer;
    //public float startDietimer = 0.0f;


    void Start()
    {
        totalHp = hp;
        positions = Waypoints.positions;
        hpSlider = GetComponentInChildren<Slider>();
        //continueDieTimer = startDietimer;
    }

    void Update()
    {
        Facing();
        Move();
    }

    void Facing()
    {
        Vector3 dir = positions[index].position - transform.position;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        transform.LookAt(positions[index].position);

    }

    void Move()
    {
        if (index > positions.Length - 1) return;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (Vector3.Distance(positions[index].position, transform.position) < 0.8f)
        {
            index++;
        }
        if (index > positions.Length - 1)
        {
            ReachDestination();
        }
    }

    void ReachDestination()//Link with improve founction 01(EnemySpawner) - When Enemy arrive at end point
    {
        PlayerStats.Lives--;
        GameObject.Destroy(this.gameObject);
    }

    void OnDestroy()//Link with improve founction 01(EnemySpawner) - When Enemy been destory
    {
        EnemySpawner.CountEnemyAlive--;
    }

    public void TakeDamage(float damage)//This is take damage, just “int damage” in the bullet script
    {
        if (hp <= 0) return;
        hp -= damage;
        hpSlider.value = (float)hp / totalHp;
        if (hp <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        PlayerStats.Money += EarnMoney;
        //transform.Translate(Vector3.up * 90 * DownSpeed * Time.deltaTime);
        GameObject.Destroy(this.gameObject);
        //StartCoroutine(WaitDie());
    }

    /*IEnumerator WaitDie()
    {
        /*foreach (Wave enemyPrefab in jiangshi)
        {
            continueDieTimer += (0.1f + 0.5f) * Time.deltaTime;
            JiangShiMaterial.SetFloat("_DissolveThreshold", continueDieTimer);
            //continueDieTimer += dieTimer * Time.deltaTime;   dieTimer* Time.deltaTime    
            yield return 0;
        }*/
        //yield return new WaitForSecondsRealtime(1);
        //GameObject.Destroy(this.gameObject);
        //continueDieTimer = startDietimer; 

        /*while (continueDieTimer >= 1)
        {
            yield return new WaitForSecondsRealtime(2);
            GameObject.Destroy(this.gameObject);
        }*/

        //JiangShiMaterial.SetFloat("_DissolveThreshold", continueDieTimer);//still doing tins
        //JiangShiMaterial.SetFloat("_DissolveThreshold", 0.8f);

        /*else if (continueDieTimer >= 1)
        {
            yield return new WaitForSecondsRealtime(2);
            GameObject.Destroy(this.gameObject);
        }*/

    //}
}
