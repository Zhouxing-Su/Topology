using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Topology {
    class Program {
        static void Main(string[] args) {
            string networkPath = @"D:\workspace\web\TopologyVisualization\json\Grid.v5e8d1r8.json";
            string visualizationPath = @"D:\workspace\web\TopologyVisualization\json\4.json";

            Zjc.Network net = Json.load<Zjc.Network>(networkPath);
            Json.save(visualizationPath, net.visualize());
        }
    }
}
