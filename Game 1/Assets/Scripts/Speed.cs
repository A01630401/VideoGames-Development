using UnityEngine;
using UnityEditor;

public class Speed : ScriptableObject
{
    public static int speed = 5;

    [MenuItem("Tools/MyTool/Do It in C#")]
    static void DoIt()
    {
        EditorUtility.DisplayDialog("MyTool", "Do It in C# !", "OK", "");
    }
}