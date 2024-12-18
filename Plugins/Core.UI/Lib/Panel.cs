﻿using ACUI.Lib.RmlUi;
using Core.UI.Lib;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.Lib {
    /// <summary>
    /// Represents a panel in the UI. Multiple panels can be loaded and displayed at the same time.
    /// </summary>
    public class Panel : UIDocument {

        public bool IsGhost { get; set; }

        internal Panel(string name, string filename, Context context, ACSystemInterface rmlSystemInterface, ILogger log) : base(name, filename, context, rmlSystemInterface, log) {

        }

        internal Panel(string name, string rmlContents, Context context, ACSystemInterface rmlSystemInterface, ILogger log, bool isSource) : base(name, rmlContents, context, rmlSystemInterface, log, isSource) {

        }

        public void BringToFront() {
            ScriptableDocument?.PullToFront();
        }
    }
}
