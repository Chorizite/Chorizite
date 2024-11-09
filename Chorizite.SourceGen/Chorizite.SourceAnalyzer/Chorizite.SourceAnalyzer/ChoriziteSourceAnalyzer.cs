using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;

namespace Chorizite.SourceAnalyzer {
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ChoriziteSourceAnalyzer : DiagnosticAnalyzer {
        public static readonly DiagnosticDescriptor WeakEventRule = new DiagnosticDescriptor(
            "CZ0001", "Public events should use WeakEvent<TEventArgs>",
            "Event '{0}' should use WeakEvent<TEventArgs>", "Naming",
            DiagnosticSeverity.Error, isEnabledByDefault: true,
            description: "All public events should use WeakEvent<TEventArgs>"
        );

        public static ImmutableArray<DiagnosticDescriptor> AllDiagnostics => ImmutableArray.Create(WeakEventRule);
        public static ImmutableArray<string> DiagnosticIds => ImmutableArray.Create(AllDiagnostics.Select(d => d.Id).ToArray());

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => AllDiagnostics;

        public override void Initialize(AnalysisContext context) {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.ReportDiagnostics);
            context.EnableConcurrentExecution();

            // TODO: Consider registering other actions that act on syntax instead of or in addition to symbols
            // See https://github.com/dotnet/roslyn/blob/main/docs/analyzers/Analyzer%20Actions%20Semantics.md for more information
            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.Event);
        }

        private static void AnalyzeSymbol(SymbolAnalysisContext context) {
            // TODO: Replace the following code with your own analysis, generating Diagnostic objects for any issues you find
            var namedTypeSymbol = (IEventSymbol)context.Symbol;

            // we only care about public events
            if (namedTypeSymbol.DeclaredAccessibility != Accessibility.Public) {
                return;
            }

            // we only care about events in public classes
            if (namedTypeSymbol.ContainingType.DeclaredAccessibility != Accessibility.Public) {
                return;
            }

            // For all such symbols, produce a diagnostic.
            var diagnostic = Diagnostic.Create(WeakEventRule, namedTypeSymbol.Locations[0], namedTypeSymbol.Name);

            context.ReportDiagnostic(diagnostic);
        }
    }
}
