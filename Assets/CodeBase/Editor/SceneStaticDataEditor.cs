using Assets.CodeBase.Infrustructure.StaticData;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.CodeBase.Editor
{
    [CustomEditor(typeof(SceneStaticData))]
    public class SceneStaticDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            SceneStaticData sceneData = (SceneStaticData)target;

            if (GUILayout.Button("Collect Scene Data"))
            {
                sceneData.SceneGardenCells =
                    FindObjectsOfType<GardenCellMarker>()
                    .Select(x => new SceneGardenCell(x.transform.position, x.PlantType))
                    .ToList();

                sceneData.SceneKey = SceneManager.GetActiveScene().name;
            }

            if (GUILayout.Button("Rename like Scene"))
            {
                AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(sceneData), SceneManager.GetActiveScene().name + "SceneStaticData");
            }


            EditorUtility.SetDirty(target);
        }
    }
}
