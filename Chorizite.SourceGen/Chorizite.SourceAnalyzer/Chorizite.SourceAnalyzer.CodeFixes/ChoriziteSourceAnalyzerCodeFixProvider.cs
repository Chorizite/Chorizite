using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Rename;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chorizite.SourceAnalyzer {
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(ChoriziteSourceAnalyzerCodeFixProvider)), Shared]
    public class ChoriziteSourceAnalyzerCodeFixProvider : CodeFixProvider {
        public sealed override ImmutableArray<string> FixableDiagnosticIds => ChoriziteSourceAnalyzer.DiagnosticIds;

        public sealed override FixAllProvider GetFixAllProvider() {
            // See https://github.com/dotnet/roslyn/blob/main/docs/analyzers/FixAllProvider.md for more information on Fix All Providers
            return WellKnownFixAllProviders.BatchFixer;
        }

        public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context) {
            var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);

            // TODO: Replace the following code with your own analysis, generating a CodeAction for each fix to suggest
            foreach (var diagnostic in context.Diagnostics) {
                var diagnosticSpan = diagnostic.Location.SourceSpan;

                // Find the type declaration identified by the diagnostic.
                var declaration = root.FindToken(diagnosticSpan.Start).Parent.AncestorsAndSelf().OfType<EventFieldDeclarationSyntax>().First();

                // Register a code action that will invoke the fix.
                context.RegisterCodeFix(
                    CodeAction.Create(
                        title: "Convert to WeakEvent<TEventArgs>",
                        createChangedDocument: c => ConvertToWeakEvent(context.Document, declaration, c),
                        equivalenceKey: "Convert to WeakEvent<TEventArgs>"),
                    diagnostic);
            }
        }

        private async Task<Document> ConvertToWeakEvent(Document document, EventFieldDeclarationSyntax typeDecl, CancellationToken cancellationToken) {

            var eventType = typeDecl.Declaration.Type.GetText().ToString().Trim();
            var isNullable = eventType.EndsWith("?");
            if (eventType.StartsWith("EventHandler<")) {
                eventType = eventType.Substring(13, eventType.Length - (isNullable ? 15 : 14));
            }
            var name = typeDecl.DescendantNodes()
                .FirstOrDefault(t => t.IsKind(SyntaxKind.VariableDeclarator))
                .ChildTokens()
                .FirstOrDefault(c => c.IsKind(SyntaxKind.IdentifierToken)).Text;

            var oldRoot = await document.GetSyntaxRootAsync(cancellationToken);

            var identifier = SyntaxFactory.ParseTypeName($"WeakEvent<{eventType}>");
            var objectCreationExpression = SyntaxFactory.ObjectCreationExpression(identifier, SyntaxFactory.ArgumentList(), null);
            var equalsValueClause = SyntaxFactory.EqualsValueClause(objectCreationExpression)
                .WithoutTrailingTrivia()
                .WithoutLeadingTrivia();

            var newEventProp = SyntaxFactory
                .PropertyDeclaration(SyntaxFactory.ParseTypeName($"WeakEvent<{eventType}>{(isNullable ? "?" : "")}"), name)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddAccessorListAccessors(SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)))
                .WithInitializer(equalsValueClause)
                .WithoutTrailingTrivia()
                .WithoutLeadingTrivia()
                .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));

            var usings = oldRoot
                .DescendantNodes()
                .OfType<UsingDirectiveSyntax>()
                .ToList();

            var compilationUnitSyntax = (CompilationUnitSyntax)(oldRoot);
            compilationUnitSyntax = compilationUnitSyntax?.ReplaceNode(typeDecl, newEventProp);
            if (!usings.Any(u => u.Name.ToString() == "Chorizite.Common")) {
                if (usings.Count > 0) {
                    compilationUnitSyntax = compilationUnitSyntax?.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("Chorizite.Common")).WithTrailingTrivia(usings.Last().GetTrailingTrivia()).WithLeadingTrivia(usings.Last().GetLeadingTrivia()));
                }
                else {
                    compilationUnitSyntax = compilationUnitSyntax?.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("Chorizite.Common")));
                }
            }

            return document.WithSyntaxRoot(compilationUnitSyntax);
        }
    }
}
