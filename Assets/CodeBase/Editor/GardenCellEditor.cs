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

          
            GUI.backgroundColor = Color.green;

            if (GUILayout.Button("Collect Plant Point", GUILayout.Height(40)))
                gardenCell.PlantPoints = gardenCell.transform.GetComponentsInChildren<PlantPoint>().ToList();
        }

    }
}
