using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    public bool KnockbackOnHurt;
    public float CooldownTime;
    public int Damage;
    PlayerHealthManager HM;
    EnemyMovementChase EM;
    bool Cooldown = false;

    void Awake()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        HM = (PlayerHealthManager)Player.GetComponent("PlayerHealthManager");
        EM = (EnemyMovementChase)gameObject.GetComponent("EnemyMovementChase");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (Cooldown == false)
            {
                EM.CanMove = false;
                StartCoroutine(Wait(CooldownTime));
                HM.TakeDamage(Damage, transform.position, KnockbackOnHurt);
            }
        }
    }

    IEnumerator Wait(float Time)
    {
        Cooldown = true;
        yield return new WaitForSeconds(Time);
        Cooldown = false;
        EM.CanMove = true;
    }
}
