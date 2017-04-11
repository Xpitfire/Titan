using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Titan.Test
{
    [TestClass]
    public class SyntaxTest
    {
        //private static readonly Network Network = Network("Demo");
        
        //[TestMethod]
        //public void TestNodeClone()
        //{
        //    var network = Network("Demo", NetworkParameter())
        //        .AddLayer(InputLayer (name: "train", dimensionData: DimensionData.Default, labelData: LabelData.Empty));
        //    Assert.IsNotNull(network);
        //}

        //[TestMethod]
        //public void TestCodeGen()
        //{
        //    var codeGenInstance = InstanceFactory.CodeGenInstance;
        //    var gen = codeGenInstance.Generate(Network);
        //    Assert.IsNotNull(gen?.Text);
        //    Debug.WriteLine(gen.Text);
        //}

        //[TestMethod]
        //public void TestImmutableClone()
        //{
        //    var networkParam = NetworkParameter();
        //    var trainLayer = InputLayer(name: "train");
        //    var network = Network("Demo", networkParam)
        //        .AddLayer(ConvolutionalLayer(name: "conv1", input: "train"))
        //        .AddLayer(PoolingLayer(name: "pool1"))
        //        .AddLayer(ConvolutionalLayer(name: "conv2", input: "conv1"));

        //    Assert.IsNotNull(network.Layers);
        //    Console.WriteLine(InstanceFactory.CodeGenInstance.Generate(network).Text);
        //}

        //[TestMethod]
        //public void TestFindChild()
        //{
        //    var node = Network.FindLayerByName("conv3");
        //    Assert.IsNotNull(node);
        //}


    }
}
