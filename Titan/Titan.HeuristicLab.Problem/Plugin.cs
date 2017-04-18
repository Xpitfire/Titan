using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeuristicLab.PluginInfrastructure;

namespace Titan.HeuristicLab.Problem
{
    [Plugin("Titan.HeuristicLab.Problem", "Provides a external problem representation for Deep Learning", "1.0.0.0")]
    [PluginFile("Titan.HeuristicLab.Problem-1.0.dll", PluginFileType.Assembly)]
    [PluginDependency("HeuristicLab.Collections", "3.3")]
    [PluginDependency("HeuristicLab.Common", "3.3")]
    [PluginDependency("HeuristicLab.Common.Resources", "3.3")]
    [PluginDependency("HeuristicLab.Core", "3.3")]
    [PluginDependency("HeuristicLab.Data", "3.3")]
    [PluginDependency("HeuristicLab.Operators", "3.3")]
    [PluginDependency("HeuristicLab.Optimization", "3.3")]
    [PluginDependency("HeuristicLab.Optimization.Operators", "3.3")]
    [PluginDependency("HeuristicLab.Parameters", "3.3")]
    [PluginDependency("HeuristicLab.Persistence", "3.3")]
    [PluginDependency("HeuristicLab.Encodings.SymbolicExpressionTreeEncoding", "3.4")]
    [PluginDependency("HeuristicLab.Problems.ExternalEvaluation", "3.4")]
    [PluginDependency("HeuristicLab.Problems.Instances", "3.3")]
    [PluginDependency("HeuristicLab.Random", "3.3")]
    public class Plugin : PluginBase { }
}
