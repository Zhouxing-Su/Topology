using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace Topology {
    [DataContract]
    public class Topology : IVisualizable {
        public TopologyVisualization visualize() {
            throw new NotImplementedException();
        }
    }


    namespace Zjc {
        [DataContract]
        public class Network : IVisualizable {
            public TopologyVisualization visualize() {
                TopologyVisualization tpv = new TopologyVisualization();

                int n = 0;
                tpv.nodes = new TopologyVisualization.Node[Nodes.Length + Relay.Length];
                for (; n < Nodes.Length; ++n) {
                    tpv.nodes[n] = new TopologyVisualization.Node();
                    TopologyVisualization.Node node = tpv.nodes[n];
                    node.id = Nodes[n].id;
                    node.label = node.id.ToString();
                    node.labelcolor = "black";
                    node.radius = 2; //Nodes[n].cost;
                    node.color = 0;
                    node.opacity = 1;
                    if ((node.id == Source) || (node.id == Target)) {
                        node.shape = TopologyVisualization.Node.Shape.Star;
                    } else {
                        node.shape = TopologyVisualization.Node.Shape.Circle;
                    }
                }
                for (int i = 0; i < Relay.Length; ++n, ++i) {
                    tpv.nodes[n] = new TopologyVisualization.Node();
                    TopologyVisualization.Node node = tpv.nodes[n];
                    node.id = Relay[i].id;
                    node.label = node.id.ToString();
                    node.labelcolor = "black";
                    node.radius = 2; //Relay[i].cost;
                    node.color = 1;
                    node.opacity = 1;
                    if ((node.id == Source) || (node.id == Target)) {
                        node.shape = TopologyVisualization.Node.Shape.Star;
                    } else {
                        node.shape = TopologyVisualization.Node.Shape.Circle;
                    }
                }

                tpv.links = new TopologyVisualization.Link[Edges.Length];
                for (int i = 0; i < Edges.Length; ++i) {
                    tpv.links[i] = new TopologyVisualization.Link();
                    TopologyVisualization.Link link = tpv.links[i];
                    Edge edge = Edges[i];
                    link.id = edge.id;
                    link.source = edge.src.ToString();
                    link.target = edge.dst.ToString();
                    link.length = edge.cost;
                    link.width = edge.consumption;
                    link.color = 2;
                    link.opacity = 1;
                    link.style = 0;
                }

                return tpv;
            }

            [DataMember]
            public string Name;
            [DataMember]
            public int Capacity;
            [DataMember]
            public int Source;
            [DataMember]
            public int Target;
            [DataMember]
            public Node[] Nodes;
            [DataMember]
            public Relay[] Relay;
            [DataMember]
            public Edge[] Edges;
        }


        [DataContract]
        public class Node {
            [DataMember]
            public int id;
            [DataMember]
            public int cost;
        }


        [DataContract]
        public class Relay : Node { }


        [DataContract]
        public class Edge {
            [DataMember]
            public int id;
            [DataMember]
            public int src;
            [DataMember]
            public int dst;
            [DataMember]
            public int cost;
            [DataMember]
            public int consumption;
        }
    }
}
