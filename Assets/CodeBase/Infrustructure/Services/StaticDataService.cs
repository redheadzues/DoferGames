﻿using Assets.CodeBase.Infrustructure.StaticData;
using Assets.CodeBase.Plants;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.CodeBase.Infrustructure.Services
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<PlantType, PlantStaticData> _plants;
        private Dictionary<PlantType, GardenCellData> _gardenCells;
        private Dictionary<string, SceneStaticData> _sceneData;


        public void Load()
        {
            _plants = Resources.LoadAll<PlantStaticData>("PlantStaticData").ToDictionary(x => x.PlantType, x => x);
            _sceneData = Resources.LoadAll<SceneStaticData>("SceneStaticData").ToDictionary(x => x.SceneKey, x => x);
            _gardenCells = new Dictionary<PlantType, GardenCellData>();
            Resources.Load<GardenCellStaticData>("SceneStaticData/GardenCellData").GardenCellsData.ForEach(x => _gardenCells.Add(x.PlantType, x));
        }

        public PlantStaticData GetPlantData(PlantType plantType) =>
            _plants.TryGetValue(plantType, out PlantStaticData plantStaticData) ? plantStaticData : null;

        public GardenCellData GetGardenCell(PlantType plantType) => 
            _gardenCells.TryGetValue(plantType, out GardenCellData gardenCell) ? gardenCell : null;

        public SceneStaticData GetSceneData()
        {
            string sceneName = SceneManager.GetActiveScene().name;

            return _sceneData.TryGetValue(sceneName, out SceneStaticData sceneData) ? sceneData : null;
        }
    }
}
