using UnityEditor;
using UnityEngine;

public static class UnityCommonConfig
{
    public const string EditorPrefsKey = "SubModuleRootFolder";
    private static string _commonpackageRootPath = "Assets";
    static UnityCommonConfig()
    {
        if (EditorPrefs.HasKey(EditorPrefsKey))
        {
            _commonpackageRootPath = EditorPrefs.GetString(EditorPrefsKey);
        }
    }
    public static string CommonPacakgePath
    {
        get { return _commonpackageRootPath; }
        set { _commonpackageRootPath = value; }
    }
}
