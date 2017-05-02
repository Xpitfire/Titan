using Titan.Core.Graph;
using Titan.Core.Graph.Vertex;
using Titan.Model;

namespace Titan.Plugin.Caffe.CodeGen
{
    public partial class CaffeScriptSolverTemplate
    {
        public Network Network { get; set; }
        public Model.Model Model { get; set; }
    }
}
