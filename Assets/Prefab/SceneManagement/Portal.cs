using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Platformer.Saving;

namespace Platformer.Scene
{
    public class Portal : MonoBehaviour
    {
        bool triggerPortal = false;
        SavingWrapper system = null;
        private void Awake()
        {
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            triggerPortal = true;
            StartCoroutine(Transition());
        }


        IEnumerator Transition()
        {
            DontDestroyOnLoad(gameObject);
            Capture();
            yield return SceneManager.LoadSceneAsync("Prototype2");
            Restore();
            Destroy(gameObject);
        }

        private void Capture()
        {
            system = FindObjectOfType<SavingWrapper>();
            system.removeListener();
        }

        private void Restore()
        {
            system = FindObjectOfType<SavingWrapper>();
            system.addListener();
        }

    }
}