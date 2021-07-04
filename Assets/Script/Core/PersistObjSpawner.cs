using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Core
{
    public class PersistObjSpawner : MonoBehaviour
    {
        [SerializeField] GameObject PersistObjPrefab = null;
        private void Awake() {
            if(GameObject.FindWithTag("PersistentObject") == null){
                GameObject persistObj = Instantiate(PersistObjPrefab);
                DontDestroyOnLoad(persistObj);
            }
        }
    }
}