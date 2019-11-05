using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 50;
    private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float expRadius = 0f;
    [SerializeField] private GameObject impactEffect;


    public void Chase(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            if (target.GetComponent<Enemy>() == true)
            {
                HitTarget();
                target.GetComponent<Enemy>().TakeDamage(damage);
            }
            else if (target.GetComponent<EnemyRight>() == true)
            {
                HitTargetRight();
                target.GetComponent<EnemyRight>().TakeDamage(damage);
            }

            Die();
            return;
        }

        /*if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            target.GetComponent<EnemyRight>().TakeDamage(damage);
            Die();
            return;
        }*/

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        transform.LookAt(target);

    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        if (expRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        //Destroy(target.gameObject);
        //PlayerStats.Money += EarnMoney;
        Destroy(gameObject);
    }

    void HitTargetRight()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        if (expRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        //Destroy(target.gameObject);
        //PlayerStats.Money += EarnMoney;
        Destroy(gameObject);
        /*GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        if (expRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        //Destroy(target.gameObject);
        Destroy(gameObject);*/
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, expRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        //Destroy(enemy.gameObject);
        Enemy e = enemy.GetComponent<Enemy>();

        if(e != null)
        {
            e.TakeDamage(damage);
        }
    }

    void Die()
    {
        GameObject.Destroy(this.gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, expRadius);
    }
}
