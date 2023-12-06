using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;


namespace RPG.Saving
{
    [ExecuteAlways]
    public class SavaebleEntity : MonoBehaviour
    {
        [SerializeField] string uniqueIdentifier = "";
        public string GetUniqueIdentifier()
        {
            return uniqueIdentifier;
        }

        public object CaptureState()
        {
            return new SavaebleVector3(transform.position);
        }

        public void RestoreState(object state)
        {
            RestorePlayerPostion(state);
        }

        private void RestorePlayerPostion(object state)
        {
            GetComponent<ActionSchedular>().CancelCurrentAction();
            GetComponent<NavMeshAgent>().enabled = false;
            SavaebleVector3 savedPosition = (SavaebleVector3)state;
            transform.position = savedPosition.ToVector3();
            GetComponent<NavMeshAgent>().enabled = true;
        }


        //#if UNITY_EDITOR
        private void Update()
        {
            if (Application.IsPlaying(gameObject)) return;
            if (string.IsNullOrEmpty(gameObject.scene.path)) return;
            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty property = serializedObject.FindProperty("uniqueIdentifier");
            if (string.IsNullOrEmpty(property.stringValue))
            {
                property.stringValue = System.Guid.NewGuid().ToString();
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}
   // #endif
