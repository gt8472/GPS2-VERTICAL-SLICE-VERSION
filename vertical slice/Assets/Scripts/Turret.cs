
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;
    private EnemyRight targetEnemyRight;

    [Header("Setup Unity")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform partToRotate;
    [SerializeField] private string enemyTag = "Enemy";
    public bool isActivated = false;

    [Header("Stats")]
    [SerializeField] private float range = 15f;   
    [SerializeField] private float turningSpeed;
    [SerializeField] private float fireRate;
    private float fireCountdown = 0f;
    public bool useLaser = false;
    [SerializeField] private int oriDamageOverTime = 30;
    [SerializeField] private int increasedDamage = 5;
    public LineRenderer lineRenderer;
    public float curDamageOverTime;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        curDamageOverTime = oriDamageOverTime;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject Enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, Enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = Enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
            targetEnemyRight = nearestEnemy.GetComponent<EnemyRight>();
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
        {
            /*if(useLaser)
            {
                if(lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                }
            }*/
            return;
        }

        lockingTarget();
        
        
        if(useLaser)
        {
            if(isActivated == true)
            Laser(); 
            else
            {
                lineRenderer.enabled = false;
            }
        }

        else
        {
            if (fireCountdown <= 0f && isActivated == true)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
            isActivated = false;
        }

    }

    void lockingTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turningSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    void Laser()
    {     

        curDamageOverTime += increasedDamage * Time.deltaTime;

        if (target.GetComponent<Enemy>() == true)
        {
            target.GetComponent<Enemy>().TakeDamage(curDamageOverTime * Time.deltaTime);
        }
        else if (target.GetComponent<EnemyRight>() == true)
        {
            target.GetComponent<EnemyRight>().TakeDamage(curDamageOverTime * Time.deltaTime);
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
        if (isActivated == true && !lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
        }


        isActivated = false;

       
    }

    void Shoot()
    {
        GameObject bulletObject = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletObject.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Chase(target);
        }
    }

    void rocketShoot()
    {
        GameObject bulletObject = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletObject.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Chase(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void Activateturret()
    {
        isActivated = true;
    }
}
