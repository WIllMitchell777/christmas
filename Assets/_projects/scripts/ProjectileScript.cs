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
    string TargetTag;

    private void Start()
    {
        RB = (Rigidbody)gameObject.GetComponent("Rigidbody");
    }

    public int Lifetime = 50;
    public IEnumerator Fire(Vector3 PlayerLookDirection,string TagToKill)
    {
        TargetTag = TagToKill;
        RB.velocity = (PlayerLookDirection * Speed) + new Vector3(0, 0f, 0); //Extra upwards force
        while (Lifetime > 0)
        {
            Lifetime -= 1;
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == TargetTag)
        {
            EnemyHealthManager EHM = (EnemyHealthManager)collision.GetComponent("EnemyHealthManager");
            EHM.TakeDamage(Damage, transform.position, DoesKnockback, KnockbackForce);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
