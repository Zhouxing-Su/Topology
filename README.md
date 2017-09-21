# 拓扑图可视化

基于 [D3v4.js](https://github.com/d3/d3) 及其示例 [Curved Links](https://bl.ocks.org/mbostock/4600693) 的拓扑图可视化工具.

## 基本功能

| 实现情况 | 功能                                       |
| ---- | ---------------------------------------- |
| [x]  | 设置节点标签                                   |
| [x]  | 设置节点标签颜色                                 |
| [x]  | 设置节点大小                                   |
| [x]  | 设置节点颜色                                   |
| [x]  | 设置节点透明度                                  |
| [x]  | 设置节点形状                                   |
| [x]  | 设置链路参考长度                                 |
| [x]  | 设置链路宽度 (粗细)                              |
| [x]  | 设置链路颜色                                   |
| [x]  | 设置链路透明度                                  |
| [x]  | 设置链路线型                                   |
| [x]  | 两点间多条不重合的链路                              |
| [x]  | 切换节点标签显示隐藏                               |
| [x]  | 智能拖拽 (点击鼠标选中离点击位置最近的节点)                  |
| [x]  | 缩放拓扑                                     |
| [ ]  | 缩放拓扑但不改变节点大小链路粗细与标签字号                    |
| [x]  | 切换拓扑图                                    |
| [x]  | 手动停止迭代固定拓扑                               |
| [x]  | 将当前节点分布保存为几何图 (保存节点坐标)                   |
| [x]  | 将当前节点分布导出为图片                             |
| [ ]  | 保证缩放比例为 100% 时节点不超出边界                    |
| [ ]  | 自动调参或者允许用户手动调参获取更好的显示效果                  |
| [ ]  | 启发式初始解生成 (使用**贪心规则**或**用户给定坐标**确定初始节点分布) |
| [ ]  | 拓扑图完全相同时快速切换解向量显示                        |
| [ ]  | 拓扑图同构时快速切换解向量显示                          |


## 使用方法

配置好 web 服务器后, 在浏览器地址栏输入 `$(address):$(port)[/index.html]?$(file).json` 访问.
其中 `$(address)` 是服务器的 IP 地址或域名, `$(port)` 是端口, `$(file)` 是输入文件名, 使用数字命名可以使用方向键翻页.

示例
- http://suzhouxing.coding.me/Demo/NetworkVisualization.RSA/index.html?0.json
- http://127.0.0.1?0.json
- http://127.0.0.1:8080?0.json

由于安全原因, chrome 等浏览器禁止 js 读写本地文件, 需要在启动时添加 `--allow-file-access-from-files` 参数才能不搭建 web 服务器使用该工具.


## 输入文件格式

输入文件为 json 格式, 有详尽的配置控制节点和链路的样式.
具体定义参考 `generator` 分支的 `TopologyVisualization.cs` 文件, 使用时将 `TopologyVisualization` 类序列化成 json 格式即可.

```c#
namespace Topology {
    public class TopologyVisualization {
        public class Node {
            public enum Shape { Circle, Cross, Diamond, Square, Star, Triangle, Wye }

            public int id;
            public string label;
            public string labelcolor;
            public int radius;
            public int color;
            public double opacity;
            public Shape shape;
        }


        public class Link {
            public enum Style { Solid, DenseDotted, SparseDashed, DenseDashed, SparseDotted, DottedDash }

            public int id;
            public string source;
            public string target;
            public int length;
            public int width;
            public int color;
            public double opacity;
            public Style style;
        }


        public Node[] nodes;
        public Link[] links;
    }
}
```
