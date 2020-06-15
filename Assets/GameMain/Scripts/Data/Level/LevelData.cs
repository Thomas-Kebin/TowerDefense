﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Data;
using GameFramework.DataTable;
using UnityGameFramework.Runtime;

namespace Flower
{
    public sealed class LevelData
    {
        private DRLevel dRLevel;
        private SceneData sceneData;
        private string name;
        private string description;

        public int Id
        {
            get
            {
                return dRLevel.Id;
            }
        }

        public string Name
        {
            get
            {
                return GameEntry.Localization.GetString(dRLevel.NameId);
            }
        }

        public string Description
        {
            get
            {
                return GameEntry.Localization.GetString(dRLevel.DescriptionId);
            }
        }

        public SceneData SceneData
        {
            get
            {
                return sceneData;
            }
        }

        public LevelData(DRLevel dRLevel, SceneData sceneData)
        {
            this.dRLevel = dRLevel;
            this.sceneData = sceneData;
        }
    }
}
