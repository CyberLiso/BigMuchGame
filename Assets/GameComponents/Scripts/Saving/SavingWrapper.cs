using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Saving
{
    public class SavingWrapper : MonoBehaviour
    {
        const string saveFile = "Save";

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                GetComponent<SavingSystem>().Save(saveFile);
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                GetComponent<SavingSystem>().Load(saveFile);
            }
        }
    }
}

