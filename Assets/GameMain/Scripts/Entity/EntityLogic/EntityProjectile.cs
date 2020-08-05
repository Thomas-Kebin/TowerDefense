﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Flower
{
    public class EntityProjectile : EntityLogicEx, IPause
    {
        [Range(0, 1)]
        public float chanceToSpawnCollisionPrefab = 1.0f;
        public int collisionParticlesEntityId;

        protected EntityDataProjectile entityDataProjectile;

        protected bool pause;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            entityDataProjectile = userData as EntityDataProjectile;

            if (entityDataProjectile == null)
            {
                Log.Error("Entity EntityProjectile '{0}' entity data invaild.", Id);
                return;
            }
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
        }

        protected void SpawnCollisionParticles()
        {
            if (collisionParticlesEntityId <= 0 || UnityEngine.Random.value > chanceToSpawnCollisionPrefab)
            {
                return;
            }

            GameEntry.Event.Fire(this, ShowEntityInLevelEventArgs.Create(
                collisionParticlesEntityId,
                typeof(EntityParticleAutoHide),
                null,
                EntityData.Create(entityDataProjectile.EntityEnemy.transform.position + entityDataProjectile.EntityEnemy.EntityDataEnemy.EnemyData.ApplyEffectOffset,
                transform.rotation)));
        }

        public virtual void Pause()
        {
            pause = true;
        }

        public virtual void Resume()
        {
            pause = false;
        }
    }

}
