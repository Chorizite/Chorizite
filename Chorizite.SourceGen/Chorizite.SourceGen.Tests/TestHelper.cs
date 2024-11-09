using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.SourceGen.Tests
{
    public static class TestHelper
    {
        public static Task Verify(string source)
        {
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(source);
            IEnumerable<PortableExecutableReference> references = [
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location)
            ];

            CSharpCompilation compilation = CSharpCompilation.Create(
                assemblyName: "Tests",
                syntaxTrees: new[] { syntaxTree },
                references: references);

            var generator = new ChoriziteSourceGenerator();

            GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);

            driver = driver.RunGenerators(compilation);

            return Verifier
                .Verify(driver)
                .UseDirectory("Snapshots");
        }
    }
}
