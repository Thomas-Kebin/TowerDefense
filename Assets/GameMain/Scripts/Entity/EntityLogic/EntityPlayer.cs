﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower.Data;

namespace Flower
{
    public class EntityPlayer : EntityLogicEx
    {
        public ParticleSystem chargeEffect;
        public ParticleSystem demagedEffect;

        private DataPlayer dataPlayer;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            dataPlayer = GameEntry.Data.GetData<DataPlayer>();
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);


        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);

            dataPlayer = null;
        }

        void OnTriggerEnter(Collider other)
        {
            var entityEnemy = other.GetComponent<EntityBaseEnemy>();
            if (entityEnemy == null)
            {
                return;
            }

            Charge();
            StartCoroutine(Damage(entityEnemy));
        }

        private void Charge()
        {
            if (chargeEffect != null)
                chargeEffect.Play();
        }

        private IEnumerator Damage(EntityBaseEnemy enemy)
        {
            yield return new WaitForSeconds(1);

            if (demagedEffect != null)
                demagedEffect.Play();

            if (enemy != null)
                enemy.AfterAttack();

            dataPlayer.Damage();
        }

    }
}

