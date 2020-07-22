﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Flower
{
    public interface ILauncher
    {

        void Launch(EntityBaseEnemy enemy, int projectileEntityId, Type projectileType, float damage, Vector3 origin, Transform firingPoint);

        void Launch(EntityBaseEnemy enemy, int projectileEntityId, Type projectileType, float damage, Vector3 origin, Transform[] firingPoints);

        void Launch(List<EntityBaseEnemy> enemies, int projectileEntityId, Type projectileType, float damage, Vector3 origin, Transform[] firingPoints);
    }
}
