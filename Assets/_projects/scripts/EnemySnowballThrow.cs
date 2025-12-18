using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySnowballThrow : MonoBehaviour
{
    public float Yoffset;
    public float Yforce;
    public float Cooldown;
    public bool ThrowsSnowballs;
    public GameObject SnowballPrefab;
    EnemyMovementChase EM;

    IEnumerator Start()
    {
        EM = (EnemyMovementChase)gameObject.GetComponent("EnemyMovementChase");
        float AggroRange = EM.AggroRange;
        if (ThrowsSnowballs)
        {
            while (true)
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
                    StartCoroutine(Attack());
                }
                yield return new WaitForSeconds(Cooldown);
            }
        }
        yield return 0;
    }

    IEnumerator Attack()
    {
        ////////////spawn snowball////////////
        GameObject NewProjectile = Instantiate(SnowballPrefab);
        NewProjectile.transform.position = gameObject.transform.position + new Vector3(0, Yoffset, 0) + (gameObject.transform.forward);
        NewProjectile.transform.rotation = gameObject.transform.rotation;
        yield return 0;
        ProjectileScript NewProjectileScript = (ProjectileScript)NewProjectile.GetComponent("ProjectileScript");
        StartCoroutine(NewProjectileScript.Fire(gameObject.transform.forward,"Player",Yforce));
        ///////////////////////////////////
    }
}
