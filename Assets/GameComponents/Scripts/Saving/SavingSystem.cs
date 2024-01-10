using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace RPG.Saving
{
    public class SavingSystem : MonoBehaviour
    {
        public void Save(string saveFile)
        {
            string path = GetSaveFilePath(saveFile);
            using (FileStream file = File.Open(path, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(file, CaptureState());
            }

                Debug.Log("Saving to... " + path);
        }
        public void Load(string saveFile)
        {
            string path = GetSaveFilePath(saveFile);
            using (FileStream file = File.Open(path, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                RestoreState(formatter.Deserialize(file));
            }

            Debug.Log("Loading... " + path);
        }

        public object CaptureState()
        {
            Dictionary<string, object> state = new Dictionary<string, object>();
            foreach(SavaebleEntity entety in FindObjectsOfType<SavaebleEntity>())
            {
                state[entety.GetUniqueIdentifier()] = entety.CaptureState();
            }
            return state;
        }
        
        public void RestoreState(object state)
        {
            Dictionary<string, object> stateRestored = (Dictionary<string, object>)state;
            foreach (SavaebleEntity entety in FindObjectsOfType<SavaebleEntity>())
            {
                entety.RestoreState(stateRestored[entety.GetUniqueIdentifier()]);
            }
        }
        private string GetSaveFilePath(string saveFile)
        {
            return Path.Combine(Application.persistentDataPath, saveFile + ".sav");
        }
    }
}
