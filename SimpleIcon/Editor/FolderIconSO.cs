using System;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleFolderIcon.Editor 
{
    //[CreateAssetMenu()]
    /// <summary>
    /// Obsolete method <see cref="IconDictionaryCreator"/>
    /// </summary>
    [Obsolete("The scriptable object logic was disable to optimize editor experience")]
    public class FolderIconSO : ScriptableObject {

        public Texture2D icon;
        public List<string> folderNames;

        public void OnValidate() {
            IconDictionaryCreator.BuildIconDictionary();
        }
    }
}

