using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Saving;

namespace RPG.Core
{
    public class SavableWrapping : MonoBehaviour
    {
        const string saveFileName = "Save";
        // Start is called before the first frame update
        void Start()
        {

        }
        private void Awake()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                LoadSaveFile();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                ResaveSaveFile();
            }
        }

        public void ResaveSaveFile()
        {
            print("haallo");
            GetComponent<SavingSystem>().Save(saveFileName);
        }

        public void LoadSaveFile()
        {
            print("byye");
            GetComponent<SavingSystem>().Load(saveFileName);
        }
    }
}