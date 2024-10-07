using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    public class AntSoldier :AntWorker 
    {
        [SerializeField] private AntSoldierSettingSO m_Setting;

        private GraphNode m_Node;
        private Action m_OnComplete;
        private float m_NextAttackTime;
        private bool m_IsAttacking;
        public void AttackAt(GraphNode node, Action onComplete) {
            m_Node = node;
            m_OnComplete = onComplete;

            m_IsAttacking = true;
            m_NextAttackTime = m_Setting.attackSpeed;

            transform.position += node.gotoPositionOffset;
        }


        protected override void Update() {
            base.Update();

            if (!m_IsAttacking) {

                return;
            }
            //Attack finish ?
            if (!m_Node.hasEnemy) {
                m_OnComplete();
                m_IsAttacking = false;
                return;
            }

            //Do attack
            m_NextAttackTime -= Time.deltaTime;
            if(m_NextAttackTime <= 0) {
                m_NextAttackTime = m_Setting.attackSpeed;
                DoOneAttack();

            }

        }

        private void DoOneAttack() {
            Debug.Log("Do one attack");
            m_Node.AttackEnemy(m_Setting.attackDamage);

            //Take damage.
            int randomNum = UnityEngine.Random.Range(0, 100);
            if(randomNum < m_Setting.probabilityToDieAtEachAttack) {
                Debug.Log("Ant soldier die");
                AntColony.instance.AntDie(this);
            }

        }

    }
}
