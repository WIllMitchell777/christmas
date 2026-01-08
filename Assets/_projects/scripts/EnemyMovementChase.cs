using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementChase : MonoBehaviour
{
    public float AggroRange;
    public float Speed;
    public float JumpPower;
    public bool CanMove;

    public Transform GroundChecker;
    public Transform WallChecker;
    System.Random RNG = new();
    Rigidbody RB;
    void Start()
    {
        RB = (Rigidbody)gameObject.GetComponent("Rigidbody");
    }

    void Update()
    {
        if (CanMove == true)
        {
            Collider[] colliders = Physics.OverlapBox(gameObject.transform.position, new Vector3(AggroRange, AggroRange, AggroRange));
            bool Found = false;
            GameObject PlayerObject = null;
            foreach (Collider collider in colliders)
            {
                if (collider.tag == "Player")
                {
                    Found = true;
                    PlayerObject = collider.gameObject;
                    break;
                }
            }
            if (Found == true)
            {
                var lookPos = PlayerObject.transform.position - transform.position;
                lookPos.y = 0;
                transform.rotation = Quaternion.LookRotation(lookPos);
                RB.velocity = new Vector3(transform.forward.x * Speed, RB.velocity.y, transform.forward.z * Speed);
                CheckJump();
            }
            else
            {
                RB.velocity = new Vector3(0, RB.velocity.y, 0);
            }
        }
    }

    private void CheckJump()
    {
        Collider[] colliders = Physics.OverlapBox(GroundChecker.position, GroundChecker.localScale);
        bool Found = false;
        foreach (Collider collider in colliders)
        {
            if (collider.tag != "Enemy" && collider.tag != "Snowball" && collider.tag != "Player")
            {
                Found = true;
                break;
            }
        }
        if (Found == true)
        {
            Collider[] colliders2 = Physics.OverlapBox(WallChecker.position, WallChecker.localScale);
            bool Found2 = false;
            foreach (Collider collider in colliders2)
            {
                if (collider.tag != "Enemy" && collider.tag != "Snowball" && collider.tag != "Player")
                {
                    Found2 = true;
                    break;
                }
            }
            if (Found2 == true)
            {
                RB.velocity = new Vector3(RB.velocity.x, JumpPower, RB.velocity.z);
            }
        }
    }
}
