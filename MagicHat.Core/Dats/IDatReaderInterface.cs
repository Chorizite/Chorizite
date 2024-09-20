using ACClientLib.DatReaderWriter.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicHat.Core.Dats {
    public interface IDatReaderInterface
    {
        T? Get<T>(uint fileId) where T : IUnpackable;
        bool TryGet<T>(uint fileId, out T? result) where T : IUnpackable;
        bool Init(string datPath);
    }
}
