using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamage
{
    public Transform target;
    public Transform weapon;
    public float shootDistance = 10f;
    public float shootInterval = 2f;
    float shootTime;
    float distanceToTarget;

    public int life = 5;

    void Start()
    {
        shootTime = shootInterval;
    }

    public bool DoDamage(int vld, bool isPlayer)
    {
        Debug.Log("HE RECIBIDO DAÑO = " + vld + "isPlayer = " + isPlayer );
        if(isPlayer == true)
        {
            life -= vld;
            if(life <= 0)
            {
                Die();
            }
            return true;
        }
        return false;
    }

    void Die()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posNoRot = new Vector3(target.position.x, 0.0f, target.position.z);
        transform.LookAt(posNoRot);

        distanceToTarget = Vector3.Distance(transform.position, target.position);
        ShootControl();
    }

    void ShootControl()
    {
        shootTime -= Time.deltaTime;
        if(shootTime < 0)
        {
            if(distanceToTarget < shootDistance)
            {
                shootTime = shootInterval;
                GameObject bullet = ObjectPollingManager.instance.GetBullet(false);
                bullet.transform.position = weapon.position;
                bullet.transform.LookAt(target.position);
            }
        }
    }
}
