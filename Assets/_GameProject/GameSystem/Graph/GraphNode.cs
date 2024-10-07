
using System;
using UnityEngine;

namespace Antopia {

    public class GraphNode : IEquatable<GraphNode> {
        public event EventHandler OnExplored;
        public event EventHandler OnFoodUpdate;
        public event EventHandler OnEnemyDead;

        public int id { get; private set; }

        public Vector3 worldPosition { get; private set; }

        public bool isHome { get; private set; }

        public bool isExplored { get; private set; }

        public int food { get; set; }

        public bool hasFood { get { return food > 0; } }


        public EnemySO enemy { get; private set; }

        public bool hasEnemy { get { return enemy != null; } }
        public int remainEnemyHp { get; private set; }

        public Vector3 gotoPositionOffset { get {
                if (hasEnemy) {
                    return new Vector3(-1, -1, 0) * 0.5f;
                }

                return Vector3.zero;

            } 
        }
        public GraphNode(int id, Vector3 worldPosition, bool isHome) {
            this.id = id;
            this.worldPosition = worldPosition;
            this.isHome = isHome;

            if (isHome) {
                MarkAsExplored();
            }

        }

        public void SetEnemy(EnemySO enemy) {
            this.enemy = enemy;
            remainEnemyHp = enemy.maxHp;

            
        }

        public void AttackEnemy(int damageAmount) {
            remainEnemyHp -= damageAmount;

            if(remainEnemyHp <= 0) {
                //Enemy is dead.
                remainEnemyHp = 0;
                food = enemy.food;
                enemy = null;

                OnFoodUpdate?.Invoke(this, EventArgs.Empty);
                OnEnemyDead?.Invoke(this, EventArgs.Empty);
            }

            WinManager.instance.CheckWin();
        }


        public int TryGetAsMuchFoodAsPossible(int requestAmount) {
            if(food >= requestAmount) {
                food -= requestAmount;
                return requestAmount;
            } else {
                int getFood = food;
                food = 0;
                return getFood;
            }
        }

        public bool TryExplore() {
            if (!hasEnemy) {
                return true;//Explore success.
            }

            int randomNum = UnityEngine.Random.Range(0, 100);
            if(randomNum < enemy.chanceToBeFound) {
                return true;
            }

            return false;
        }

        public void MarkAsExplored() {
            isExplored = true;
            WinManager.instance.CheckWin();
            OnExplored?.Invoke(this, EventArgs.Empty);
        }

        public override bool Equals(object obj) {
            return obj is GraphNode otherNode &&
                        id == otherNode.id;
        }
        public bool Equals(GraphNode other) {
            return id == other.id;
        }

        public static bool operator ==(GraphNode nodeA, GraphNode nodeB) {
            return nodeA.id == nodeB.id;
        }

        public static bool operator !=(GraphNode nodeA, GraphNode nodeB) {
            return !(nodeA == nodeB);
        }

        public override int GetHashCode() {
            return HashCode.Combine(id);
        }

        public override string ToString() {
            return id.ToString();
        }

        

    }
}
