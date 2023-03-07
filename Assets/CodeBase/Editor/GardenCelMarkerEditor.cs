using Assets.CodeBase.Infrustructure.StaticData;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Assets.CodeBase.Editor
{
    [CustomEditor(typeof(GardenCellMarker))]
    public class GardenCelMarkerEditor : UnityEditor.Editor
    {
        private const string Garden = "Garden";

        private void OnEnable()
        {
            GardenCellMarker marker = (GardenCellMarker)target;

            GameObject garden = GameObject.FindGameObjectWithTag(Garden);

            if (garden == null)
            {
                garden = new GameObject(Garden);
                garden.tag = Garden;
            }

            marker.transform.SetParent(garden.transform);
        } 
        

        [DrawGizmo(GizmoType.NonSelected | GizmoType.Active | GizmoType.Pickable | GizmoType.InSelectionHierarchy)]
        public static void RenderCustomGizmo(GardenCellMarker gardenCell, GizmoType gizmoType)
        {
            GardenCellStaticData staticData = AssetDatabase.LoadAssetAtPath("Assets/Resources/SceneStaticData/GardenCellData.asset", typeof(GardenCellStaticData)) as GardenCellStaticData;
            GardenCellData _cellData = staticData.GardenCellsData.FirstOrDefault(x => x.PlantType == gardenCell.PlantType);
            Vector3 sizeCollider = _cellData.CellTemplate.GetComponent<BoxCollider>().size;

            Vector3 size = new Vector3(_cellData.CellTemplate.transform.localScale.x * sizeCollider.x, 1, _cellData.CellTemplate.transform.localScale.z * sizeCollider.z);


            BoxGizmo(gardenCell.transform, Color.yellow, size);
        }

        private static void BoxGizmo(Transform transform, Color color, Vector3 size)
        {
            Gizmos.color = color;
            Vector3 position = transform.position;
            Gizmos.DrawCube(position, size);
        }
    }
}
