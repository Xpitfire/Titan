using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeuristicLab.PluginInfrastructure;

namespace Titan.HeuristicLab.Problem
{
    [Plugin("HeuristicLab.Titan.Problem", "Provides a external problem representation for Deep Learning", "1.0.0.0")]
    [PluginFile("HeuristicLab.Titan.Problem-1.0.dll", PluginFileType.Assembly)]
    [PluginDependency("HeuristicLab.Collections", "3.3")]
    [PluginDependency("HeuristicLab.Common", "3.3")]
    [PluginDependency("HeuristicLab.Core", "3.3")]
    [PluginDependency("HeuristicLab.Data", "3.3")]
    [PluginDependency("HeuristicLab.Optimization", "3.3")]
    [PluginDependency("HeuristicLab.Parameters", "3.3")]
    [PluginDependency("HeuristicLab.Persistence", "3.3")]
    [PluginDependency("HeuristicLab.Encodings.SymbolicExpressionTreeEncoding", "3.4")]
    public class Plugin : PluginBase { }
}
