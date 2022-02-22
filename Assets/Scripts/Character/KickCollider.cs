using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickCollider : MonoBehaviour
{
    public GameObject bulletReboundPrefab;
    public Transform positionToInstantiate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BasicBullet"))
        {
            Destroy(other.gameObject);
            var rebound = (GameObject)Instantiate(bulletReboundPrefab, positionToInstantiate.position, positionToInstantiate.rotation);
        }
    }
}
