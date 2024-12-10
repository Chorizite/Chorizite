using DatReaderWriter;
using DatReaderWriter.DBObjs;
using DatReaderWriter.Lib.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Dats {
    public interface IDatReaderInterface
    {
        public PortalDatabase Portal { get; }
        public CellDatabase Cell { get; }
        SpellTable SpellTable { get; }
        SkillTable SkillTable { get; }
        VitalTable VitalTable { get; }

        T? Get<T>(uint fileId) where T : IDBObj;
        bool TryGet<T>(uint fileId, out T? result) where T : IDBObj;
        bool Init(string datPath);
    }
}
