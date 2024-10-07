using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Antopia {
    public class RandomGraphGenerator : MonoBehaviour{
        [SerializeField] private GraphSettingSO m_GraphSetting;

        private class TempNode {
            public GraphNode node;
            public int remainEdges;
        }

        public Graph MakeGraph() {
            TempNode[,] tempNodeMatrix = new TempNode[m_GraphSetting.xGridSize, m_GraphSetting.yGridSize];
            List<GraphEdge> tempEdges = new List<GraphEdge>();

            int id = 0;
            for(int xGridIndex = 0; xGridIndex < m_GraphSetting.xGridSize; xGridIndex++) {
                for(int yGridIndex = 0; yGridIndex < m_GraphSetting.yGridSize; yGridIndex++) {
                    //Update ID
                    id++;

                    bool isHome = xGridIndex == 0 && yGridIndex == 0;
                    //Get random world position.
                    float xOuterPosition = xGridIndex * m_GraphSetting.bigGridDistance;
                    float yOuterPosition = yGridIndex * m_GraphSetting.bigGridDistance;

                    float paddingOffset = (m_GraphSetting.bigGridDistance - m_GraphSetting.smallGridDistance) / 2;

                    float xInnerPosition = xOuterPosition + paddingOffset;
                    float yInnerPosition = yOuterPosition + paddingOffset;

                    float xInnerCellOuterBound = xInnerPosition + m_GraphSetting.smallGridDistance;
                    float yInnerCellOuterBound = yInnerPosition + m_GraphSetting.smallGridDistance;


                    //Random World Position.
                    float xRandom = Random.Range(xInnerPosition, xInnerCellOuterBound);
                    float yRandom = Random.Range(yInnerPosition, yInnerCellOuterBound);

                    Vector3 randomWorldPosition = new Vector3(xRandom, yRandom, 0);

                    GraphNode node = new GraphNode(id, randomWorldPosition, isHome);
                    TempNode tempNode = new TempNode() {
                        node = node,
                        remainEdges = Random.Range(m_GraphSetting.minEdgePerNode, m_GraphSetting.maxEdgePerNode + 1)
                    };
                    tempNodeMatrix[xGridIndex, yGridIndex] = tempNode;
                }
            }

            //Fill out edges.
            for(int _ = 0; _ < m_GraphSetting.maxEdgePerNode; _++) {
                for(int x = 0; x < m_GraphSetting.xGridSize; x++) {
                    for(int y = 0; y < m_GraphSetting.yGridSize; y++) {

                        TempNode selfCell = tempNodeMatrix[x, y];
                        if (selfCell.remainEdges == 0) {
                            continue;//Skip, because can't add edges.
                        }

                        List<TempNode> tempNodesToChooseFrom = new List<TempNode>();

                        //Right temp node
                        if(x + 1 < m_GraphSetting.xGridSize && tempNodeMatrix[x + 1, y].remainEdges > 0) {
                            tempNodesToChooseFrom.Add(tempNodeMatrix[x + 1, y]);
                        }

                        //Up temp node
                        if (y + 1 < m_GraphSetting.yGridSize && tempNodeMatrix[x, y + 1].remainEdges > 0) {
                            tempNodesToChooseFrom.Add(tempNodeMatrix[x, y + 1]);
                        }

                        //Up right node
                        if (x + 1 < m_GraphSetting.xGridSize && y + 1 < m_GraphSetting.yGridSize && tempNodeMatrix[x + 1, y + 1].remainEdges > 0) {
                            tempNodesToChooseFrom.Add(tempNodeMatrix[x + 1, y + 1]);
                        }

                        if(tempNodesToChooseFrom.Count == 0) {
                            continue; //Skip.
                        }

                        //Make new edge
                        int randomIndex = Random.Range(0, tempNodesToChooseFrom.Count);
                        TempNode tempNodeToAdd = tempNodesToChooseFrom[randomIndex];

                        selfCell.remainEdges--;
                        tempNodeToAdd.remainEdges--;
                        GraphEdge newEdge = new GraphEdge(selfCell.node, tempNodeToAdd.node);
                        tempEdges.Add(newEdge);


                    }

                }


            }

            //Filter invalid nodes and edges.





            HashSet<GraphNode> nodes = new HashSet<GraphNode>();
            HashSet<GraphEdge> edges = new HashSet<GraphEdge>();

            //Filter invalid nodes and edges.

            
            for (int x = 0; x < m_GraphSetting.xGridSize; x++) {
                for (int y = 0; y < m_GraphSetting.yGridSize; y++) {
                    TempNode tempNode = tempNodeMatrix[x, y];
                    if (tempNode.remainEdges == 0) {
                        //nodes.Add(tempNode.node);
                    }

                    //Set food or enemy.
                    int randomNum = Random.Range(0, 100);

                    if(randomNum < m_GraphSetting.hasFoodProbability) {
                        tempNode.node.food = RandomSetFood();
                    }else if(randomNum < m_GraphSetting.hasFoodProbability + m_GraphSetting.hasEnemyProbability) {
                        tempNode.node.SetEnemy(RandomSelectAnEnemy());
                    }

                    
                    nodes.Add(tempNode.node);

                }
            }

            foreach(var tempEdge in tempEdges) {
                if(tempEdge.nodes.IsSubsetOf(nodes)) {
                    //edges.Add(tempEdge);
                }

                edges.Add(tempEdge);
            }
            


             return new Graph(nodes, edges);
        }


        private int RandomSetFood() {
            

            int foodAmount = Random.Range(m_GraphSetting.minFood, m_GraphSetting.maxFood);

            return foodAmount;
        }

        private EnemySO RandomSelectAnEnemy() {
            int randomIndex = Random.Range(0, m_GraphSetting.enemySOs.Count);

            return m_GraphSetting.enemySOs[randomIndex];
        }


        
       
    }

}

