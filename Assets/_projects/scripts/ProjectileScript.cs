using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public int Speed;
    public int Damage;
    public int KnockbackForce;
    public bool DoesKnockback;
    Rigidbody RB;

    private void Start()
    {
        RB = (Rigidbody)gameObject.GetComponent("Rigidbody");
    }

    public void Fire(Vector3 PlayerLookDirection)
    {
        RB.velocity = (PlayerLookDirection * Speed) + new Vector3(0, 1f, 0); //Extra upwards force
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyHealthManager EHM = (EnemyHealthManager)collision.GetComponent("EnemyHealthManager");
            EHM.TakeDamage(Damage, transform.position, DoesKnockback, KnockbackForce);
            Destroy(gameObject);
        }
        if (collision.gameObject.layer != 3 && collision.gameObject.layer != 6)
        {
            Destroy(gameObject);
        }
    }
}
