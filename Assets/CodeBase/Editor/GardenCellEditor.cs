using Assets.CodeBase.Plants;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Assets.CodeBase.Editor
{
    [CustomEditor(typeof(GardenCell))]
    public class GardenCellEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GardenCell gardenCell = (GardenCell)target;

            if (GUILayout.Button("Collect Plant Point"))
                gardenCell.plantPoints = gardenCell.transform.GetComponentsInChildren<PlantPoint>().ToList();

            EditorUtility.SetDirty(target);
        }

    }
}
