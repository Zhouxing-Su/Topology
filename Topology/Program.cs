using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Topology {
    class Program {
        static void Main(string[] args) {
            Zjc.Network net = Json.load<Zjc.Network>(@"D:\workspace\web\TopologyVisualization\json\rand.json");
            Json.save(@"D:\workspace\web\TopologyVisualization\json\3.json", net.visualize());
        }
    }
}
