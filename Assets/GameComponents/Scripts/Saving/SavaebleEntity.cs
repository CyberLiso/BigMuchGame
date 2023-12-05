using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;


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
        return null;
    }

    public void RestoreState(object state)
    {
        print("Hallo");
    }

    private void Update()
    {
        if (Application.IsPlaying(gameObject)) return;
        if (gameObject.scene.path == "") return;
        SerializedObject serializedObject = new SerializedObject(this);
        SerializedProperty property = serializedObject.FindProperty("uniqueIdentifier");
        if(property.stringValue == "")
        {
            property.stringValue = System.Guid.NewGuid().ToString();
            serializedObject.ApplyModifiedProperties();
        }
    }
}
