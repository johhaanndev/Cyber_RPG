using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttackColliders : MonoBehaviour
{
    public GameObject colliders;
    public GameObject reboundBulletPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BasicBullet"))
        {
            var bulletPrefab = (GameObject)Instantiate(reboundBulletPrefab, other.transform.position, transform.rotation);
            Destroy(other.gameObject);
        }
    }
}
