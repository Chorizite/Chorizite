using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Chorizite.SourceGen.Tests
{
    [TestClass]
    [UsesVerify]
    public partial class ChoriziteSourceGeneratorTests {
        [TestMethod]
        public void Test() {
            var compilation = CSharpCompilation.Create("TestProject",
                new[] { CSharpSyntaxTree.ParseText("struct Test { }") },
                Basic.Reference.Assemblies.Net80.References.All,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            var generator = new ChoriziteSourceGenerator();
            var sourceGenerator = generator.AsSourceGenerator();

            // trackIncrementalGeneratorSteps allows to report info about each step of the generator
            GeneratorDriver driver = CSharpGeneratorDriver.Create(
                generators: new ISourceGenerator[] { sourceGenerator },
                driverOptions: new GeneratorDriverOptions(default, trackIncrementalGeneratorSteps: true));

            // Run the generator
            driver = driver.RunGenerators(compilation);

            // Update the compilation and rerun the generator
            compilation = compilation.AddSyntaxTrees(CSharpSyntaxTree.ParseText("// dummy"));
            driver = driver.RunGenerators(compilation);

            // Assert the driver doesn't recompute the output
            var result = driver.GetRunResult().Results.Single();
            var allOutputs = result.TrackedOutputSteps.SelectMany(outputStep => outputStep.Value).SelectMany(output => output.Outputs);

            foreach (var output in allOutputs) {
                Assert.AreEqual(IncrementalStepRunReason.Cached, output.Reason);
            }

            // Assert the driver use the cached result from AssemblyName and Syntax
            var assemblyNameOutputs = result.TrackedSteps["AssemblyName"].Single().Outputs;
            foreach (var output in assemblyNameOutputs) {
                Assert.AreEqual(IncrementalStepRunReason.Unchanged, output.Reason);
            }

            var syntaxOutputs = result.TrackedSteps["Syntax"].Single().Outputs;
            foreach (var output in syntaxOutputs) {
                Assert.AreEqual(IncrementalStepRunReason.Unchanged, output.Reason);
            }
        }

        [TestMethod]
        public Task AnotherTest() {
            // The source code to test
            var source = @"class Test { }";

            // Pass the source code to our helper and snapshot test the output
            return TestHelper.Verify(source);
        }

        [TestMethod]
        public Task CreateDiagnosticErrorOnPublicEvents() {
            // The source code to test
            var source = @"class Test {
                public event EventHandler<Eventargs> TestEvent;
            }";

            // Pass the source code to our helper and snapshot test the output
            return TestHelper.Verify(source);
        }
    }
}