using UnityEngine;
using UnityEditor;

public class NewEditorScript1 : ScriptableObject
{
    public int life = 100;
    [MenuItem("Tools/MyTool/Do It in C#")]
    static void DoIt()
    {
        EditorUtility.DisplayDialog("MyTool", "Do It in C# !", "OK", "");
    }
}