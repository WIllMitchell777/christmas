using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public int Speed;
    public Vector3 Direction;
    public int PlayerLookY;
    Rigidbody RB;

    private void Start()
    {
        RB = (Rigidbody)gameObject.GetComponent("Rigidbody");
    }

    public void Fire()
    {
        RB.velocity = (Direction * Speed) + new Vector3(0, 1.5f, 0);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyHealthManager EHM = (EnemyHealthManager)collision.GetComponent("EnemyHealthManager");
            //EHM.TakeDamage(15, transform.position, true);
            Destroy(gameObject);
        }
        if (collision.gameObject.layer != 3 && collision.gameObject.layer != 6)
        {
            Destroy(gameObject);
        }
    }
}
