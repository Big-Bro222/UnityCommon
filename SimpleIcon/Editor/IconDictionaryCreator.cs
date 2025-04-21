using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
namespace SimpleFolderIcon.Editor
{
    public class IconDictionaryCreator : AssetPostprocessor
    {
        private const string AssetsPath = "SimpleIcon/Icons";
        internal static Dictionary<string, Texture> IconDictionary;

        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            if (!ContainsIconAsset(importedAssets) &&
                !ContainsIconAsset(deletedAssets) &&
                !ContainsIconAsset(movedAssets) &&
                !ContainsIconAsset(movedFromAssetPaths))
            {
                return;
            }

            BuildIconDictionary();
            
        }

        private static bool ContainsIconAsset(string[] assets)
        {
            foreach (string str in assets)
            {
                Debug.Log(UnityCommonConfig.CommonPacakgePath+"/"+AssetsPath);
                if (ReplaceSeparatorChar(Path.GetDirectoryName(str)) == UnityCommonConfig.CommonPacakgePath+"/"+AssetsPath)
                {
                    return true;
                }
            }
            return false;
        }

        private static string ReplaceSeparatorChar(string path)
        {
            return path.Replace("\\", "/");
        }

        internal static void BuildIconDictionary()
        {
            var dictionary = new Dictionary<string, Texture>();
            var dir = new DirectoryInfo(Application.dataPath.Replace("Assets","") +UnityCommonConfig.CommonPacakgePath+ "/" + AssetsPath);
            Debug.Log(dir);
            FileInfo[] info = dir.GetFiles("*.png");
            foreach(FileInfo f in info)
            {
                var texture = (Texture)AssetDatabase.LoadAssetAtPath($"{UnityCommonConfig.CommonPacakgePath}/{AssetsPath}/{f.Name}", typeof(Texture2D));
                dictionary.Add(Path.GetFileNameWithoutExtension(f.Name),texture);
            }
            //Potential Scriptableobject fuction, disabled to optimize editor experience.
            // FileInfo[] infoSO = dir.GetFiles("*.asset");
            // foreach (FileInfo f in infoSO) 
            // {
            //     var folderIconSO = (FolderIconSO)AssetDatabase.LoadAssetAtPath($"Assets/{AssetsPath}/{f.Name}", typeof(FolderIconSO));
            //
            //     if (folderIconSO != null) 
            //     {
            //         var texture = (Texture)folderIconSO.icon;
            //
            //         foreach (string folderName in folderIconSO.folderNames) 
            //         {
            //             if (folderName != null) 
            //             {
            //                 // dictionary.TryAdd(folderName, texture);
            //                 dictionary.Add(folderName, texture);
            //             }
            //         }
            //     }
            // }
            
            IconDictionary = dictionary;
        }
    }
}
