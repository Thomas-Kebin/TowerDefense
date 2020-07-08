﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Data;
using GameFramework.DataTable;
using UnityGameFramework.Runtime;

namespace Flower.Data
{
    public class EnemyData
    {
        private DREnemy dREnemy;

        public int Id
        {
            get
            {
                return dREnemy.Id;
            }
        }

        public string NameId
        {
            get
            {
                return GameEntry.Localization.GetString(dREnemy.NameId);
            }
        }

        public int EntityId
        {
            get
            {
                return dREnemy.EntityId;
            }
        }

        public float MaxHP
        {
            get
            {
                return dREnemy.MaxHP;
            }
        }

        public float Speed
        {
            get
            {
                return dREnemy.Speed;
            }
        }

        public EnemyData(DREnemy dREnemy)
        {
            this.dREnemy = dREnemy;
        }

    }
}

