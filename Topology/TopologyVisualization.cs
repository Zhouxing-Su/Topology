using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace Topology {
    public interface IVisualizable {
        TopologyVisualization visualize();
    }


    [DataContract]
    public class TopologyVisualization {
        [DataContract]
        public class Node {
            public enum Shape { Circle, Cross, Diamond, Square, Star, Triangle, Wye }

            [DataMember]
            public int id;
            [DataMember]
            public string label;
            [DataMember]
            public string labelcolor; // TODO[szx][2]: use integer id to pick colors from pre-defined palette.
            [DataMember]
            public int radius;
            [DataMember]
            public int color;
            [DataMember]
            public double opacity;
            [DataMember]
            public Shape shape;
        }


        [DataContract]
        public class Link {
            public enum Style { Solid, DenseDotted, SparseDashed, DenseDashed, SparseDotted, DottedDash }

            [DataMember]
            public int id;
            [DataMember]
            public string source; // TODO[szx][1]: use integer id as index.
            [DataMember]
            public string target; // TODO[szx][1]: use integer id as index.
            [DataMember]
            public int length;
            [DataMember]
            public int width;
            [DataMember]
            public int color;
            [DataMember]
            public double opacity;
            [DataMember]
            public Style style;
        }


        [DataMember]
        public Node[] nodes;
        [DataMember]
        public Link[] links;
    }
}
