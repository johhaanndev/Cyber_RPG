using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonDevelopmentStage : MonoBehaviour
{
    public Vector3 rotation;

    public List<Transform> spawners;

    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(SpawnKickBullets));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }

    private IEnumerator SpawnKickBullets()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            foreach (var spawn in spawners)
            {
                var bullet = (GameObject)Instantiate(bulletPrefab, spawn.position, spawn.rotation);
            }
        }
    }
}
