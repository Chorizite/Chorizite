using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VerifyCS = Chorizite.SourceAnalyzer.Test.CSharpCodeFixVerifier<
    Chorizite.SourceAnalyzer.ChoriziteSourceAnalyzer,
    Chorizite.SourceAnalyzer.ChoriziteSourceAnalyzerCodeFixProvider>;

namespace Chorizite.SourceAnalyzer.Test
{
    [TestClass]
    public class ChoriziteSourceAnalyzerUnitTest
    {
        //No diagnostics expected to show up
        [TestMethod]
        public async Task EmptyCodeHasEmptyDiagnostics()
        {
            var test = @"";

            await VerifyCS.VerifyAnalyzerAsync(test);
        }

        [TestMethod]
        public async Task CodeFixDoesntAddDuplicateUsing()
        {
            var test = @"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Chorizite.Common;

namespace ConsoleApplication1
{
    public class MyClass
    {
        public event EventHandler<EventArgs> {|#0:OnMyEvent|};
    }
}";

            var fixtest = @"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Chorizite.Common;

namespace ConsoleApplication1
{
    public class MyClass
    {
        public WeakEvent<EventArgs> OnMyEvent { get; } = new WeakEvent<EventArgs>();
    }
}";

            var expected = new DiagnosticResult[] {
                VerifyCS.Diagnostic(ChoriziteSourceAnalyzer.WeakEventRule).WithLocation(0).WithArguments("OnMyEvent")
            };

            await VerifyCS.VerifyCodeFixAsync(test, expected, fixtest);
        }

        [TestMethod]
        public async Task SingleEventHasSingleDiagnostic()
        {
            var test = @"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApplication1
{
    public class MyClass
    {
        public event EventHandler<EventArgs> {|#0:OnMyEvent|};
    }
}";

            var fixtest = @"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Chorizite.Common;

namespace ConsoleApplication1
{
    public class MyClass
    {
        public WeakEvent<EventArgs> OnMyEvent { get; } = new WeakEvent<EventArgs>();
    }
}";

            var expected = new DiagnosticResult[] {
                VerifyCS.Diagnostic(ChoriziteSourceAnalyzer.WeakEventRule).WithLocation(0).WithArguments("OnMyEvent")
            };

            await VerifyCS.VerifyCodeFixAsync(test, expected, fixtest);
        }

        [TestMethod]
        public async Task WillDiagnoseMultipleEvents()
        {
            var test = @"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApplication1
{
    public class MyClass
    {
        public event EventHandler<EventArgs> {|#0:OnMyEvent|};
        public event EventHandler<EventArgs> {|#1:OnMyEvent2|};
    }
}";

            var fixtest = @"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Chorizite.Common;

namespace ConsoleApplication1
{
    public class MyClass
    {
        public WeakEvent<EventArgs> OnMyEvent { get; } = new WeakEvent<EventArgs>();
        public WeakEvent<EventArgs> OnMyEvent2 { get; } = new WeakEvent<EventArgs>();
    }
}";

            var expected = new DiagnosticResult[] {
                VerifyCS.Diagnostic(ChoriziteSourceAnalyzer.WeakEventRule).WithLocation(0).WithArguments("OnMyEvent"),
                VerifyCS.Diagnostic(ChoriziteSourceAnalyzer.WeakEventRule).WithLocation(1).WithArguments("OnMyEvent2")
            };

            await VerifyCS.VerifyCodeFixAsync(test, expected, fixtest);
        }

        [TestMethod]
        public async Task NonPublicEventsAreIgnored()
        {
            var test = @"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApplication1
{
    public class MyClass
    {
        internal event EventHandler<EventArgs> {|#0:OnMyEvent|};
    }
}";

            var fixtest = @"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApplication1
{
    public class MyClass
    {
        internal event EventHandler<EventArgs> OnMyEvent;
    }
}";

            var expected = new DiagnosticResult[] {};
            await VerifyCS.VerifyCodeFixAsync(test, expected, fixtest);
        }

        [TestMethod]
        public async Task NonPublicClassesAreIgnored()
        {
            var test = @"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApplication1
{
    internal class MyClass
    {
        public event EventHandler<EventArgs> {|#0:OnMyEvent|};
    }
}";

            var fixtest = @"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApplication1
{
    internal class MyClass
    {
        public event EventHandler<EventArgs> OnMyEvent;
    }
}";

            var expected = new DiagnosticResult[] {};

            await VerifyCS.VerifyCodeFixAsync(test, expected, fixtest);
        }

        [TestMethod]
        public async Task SingleNullableEventHasSingleDiagnostic()
        {
            var test = @"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApplication1
{
    public class MyClass
    {
        public event EventHandler<EventArgs>? {|#0:OnMyEvent|};
    }
}";

            var fixtest = @"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Chorizite.Common;

namespace ConsoleApplication1
{
    public class MyClass
    {
        public WeakEvent<EventArgs>? OnMyEvent { get; } = new WeakEvent<EventArgs>();
    }
}";

            var expected = new DiagnosticResult[] {
                VerifyCS.Diagnostic(ChoriziteSourceAnalyzer.WeakEventRule).WithLocation(0).WithArguments("OnMyEvent")
            };

            await VerifyCS.VerifyCodeFixAsync(test, expected, fixtest, true);
        }
    }
}
