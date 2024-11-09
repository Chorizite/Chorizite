using System;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

[Generator]
public sealed partial class ChoriziteSourceGenerator : IIncrementalGenerator {
    public void Initialize(IncrementalGeneratorInitializationContext context) {
        var eventProvider = context.SyntaxProvider
            .CreateSyntaxProvider(
                predicate: static (syntax, cancellationToken) => syntax.IsKind(SyntaxKind.EventFieldDeclaration),
                transform: static (ctx, cancellationToken) => (EventFieldDeclarationSyntax)ctx.Node)
            .WithTrackingName("Syntax");

        var assemblyNameProvider = context.CompilationProvider
            .Select((compilation, cancellationToken) => compilation.AssemblyName)
            .WithTrackingName("AssemblyName");

        var valueProvider = eventProvider.Combine(assemblyNameProvider);

        context.RegisterSourceOutput(valueProvider, (spc, valueProvider) => {
            (var node, var assemblyName) = (valueProvider.Left, valueProvider.Right);
            Log($"Node: {node.ToFullString()} {CreateDiagnostic(node)}");
            spc.ReportDiagnostic(CreateDiagnostic(node));
        });
    }

    private void Log(string v) {
#pragma warning disable RS1035 // Do not use APIs banned for analyzers
        System.IO.File.AppendAllText("log.txt", $"{v}{Environment.NewLine}");
#pragma warning restore RS1035 // Do not use APIs banned for analyzers
    }

    static Diagnostic CreateDiagnostic(EventFieldDeclarationSyntax syntax) {
        var descriptor = new DiagnosticDescriptor(
            id: "TEST01",
            title: "A test diagnostic",
            messageFormat: "A description about the problem",
            category: "tests",
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        return Diagnostic.Create(descriptor, syntax.GetLocation());
    }

}