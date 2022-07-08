using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace Game.Cinematics
{
    public class CinematicTrigger : MonoBehaviour
    {
        private const string PlayerTag = "Player";

        private bool alreadyTriggered = false;

        private void OnTriggerEnter(Collider other)
        {
            if (!alreadyTriggered && other.CompareTag(PlayerTag))
            {
                GetComponent<PlayableDirector>().Play();
                alreadyTriggered = true;
            }
        }
    }
}
