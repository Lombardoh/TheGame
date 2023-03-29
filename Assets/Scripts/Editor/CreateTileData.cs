using UnityEditor;
using System.IO;
using UnityEngine;

public class CreateTileData{
  [MenuItem("Assets/Create/TileData")]
  public static void MakeTileData(){
    string name = "TileData";
    TileData asset = ScriptableObject.CreateInstance<TileData>();
    AssetDatabase.CreateAsset(asset, string.Format("Assets/ScriptableObjects/{0}.asset", name));
    AssetDatabase.SaveAssets();
    EditorUtility.FocusProjectWindow();
    Selection.activeObject = asset;
  }
}

