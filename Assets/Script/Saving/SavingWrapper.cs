using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;

namespace Platformer.Saving
{
    public class SavingWrapper : MonoBehaviour
    {
        const string defaultSaveFile = "save";

        #region Event subscription
        private void OnEnable()
        {
            addListener();
        }

        private void OnDisable()
        {
            removeListener();
        }

        public void addListener()
        {
        }

        public void removeListener()
        {
        }

        #endregion

        private void Save()
        {
            GetComponent<SavingSystem>().Save(defaultSaveFile);
        }

        private void Load()
        {
            GetComponent<SavingSystem>().Load(defaultSaveFile);
        }
    }
}