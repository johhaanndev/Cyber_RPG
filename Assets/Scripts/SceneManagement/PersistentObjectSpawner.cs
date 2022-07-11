using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.SceneManagement
{
    public class PersistentObjectSpawner : MonoBehaviour
    {
        [SerializeField] GameObject persistenObjectPrefab;

        private static bool hasSpawned;

        private void Awake()
        {
            if (hasSpawned)
                return;

            SpawnPersistentObjects();

            hasSpawned = true;
        }

        private void SpawnPersistentObjects()
        {
            GameObject persistantObject = Instantiate(persistenObjectPrefab);
            DontDestroyOnLoad(persistantObject);
        }
    }
}
