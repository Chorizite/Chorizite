using FontStashSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render {
    public interface IFontRenderer : IFontStashRenderer2 {
        public void Flush();
    }
}
