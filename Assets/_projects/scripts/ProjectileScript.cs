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
    bool DestroyedNaturally = false;
    bool CanHit = false;

    private void Start()
    {
        RB = (Rigidbody)gameObject.GetComponent("Rigidbody");
    }

    public int Lifetime = 50;
    public IEnumerator Fire(Vector3 PlayerLookDirection,string TagToKill,float Yforce)
    {
        TargetTag = TagToKill;
        CanHit = true;
        RB.velocity = (PlayerLookDirection * Speed) + new Vector3(0, Yforce, 0); //Extra upwards force
        while (Lifetime > 0)
        {
            Lifetime -= 1;
            yield return new WaitForSeconds(0.1f);
        }
        if (DestroyedNaturally == false)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (CanHit == true)
        {
            if (collision.gameObject.tag == "Enemy" && TargetTag == "Enemy")
            {
                EnemyHealthManager EHM = (EnemyHealthManager)collision.GetComponent("EnemyHealthManager");
                EHM.TakeDamage(Damage, transform.position, DoesKnockback, KnockbackForce);
                Destroy(gameObject);
                DestroyedNaturally = true;
            }
            else if (collision.gameObject.tag == "Player" && TargetTag == "Player")
            {
                PlayerHealthManager HM = (PlayerHealthManager)collision.GetComponent("PlayerHealthManager");
                HM.TakeDamage(Damage, transform.position, DoesKnockback);
                Destroy(gameObject);
                DestroyedNaturally = true;
            }
            else if (collision.gameObject.tag != "Snowball")
            {
                if (TargetTag == "Player" && collision.gameObject.tag != "Enemy")
                {
                    Destroy(gameObject);
                    DestroyedNaturally = true;
                }
                else if (TargetTag == "Enemy" && collision.gameObject.tag != "Player")
                {
                    Destroy(gameObject);
                    DestroyedNaturally = true;
                }
            }
        }
    }
}
