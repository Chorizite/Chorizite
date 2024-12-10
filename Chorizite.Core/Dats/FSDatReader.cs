using DatReaderWriter;
using DatReaderWriter.DBObjs;
using DatReaderWriter.Lib.IO;
using DatReaderWriter.Lib.IO.BlockAllocators;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Dats {
    internal class FSDatReader : IDatReaderInterface {
        private string _datPath;
        private SpellTable _spellTable;
        private SkillTable _skillTable;
        private VitalTable _vitalTable;
        private readonly ILogger _log;
        private readonly IChoriziteConfig _config;

        public PortalDatabase Portal { get; private set; }
        public CellDatabase Cell { get; private set; }

        public SpellTable SpellTable {
            get {
                if (_spellTable is null) {
                    _spellTable = Portal.SpellTable;
                }
                return _spellTable;
            }
        }

        public SkillTable SkillTable {
            get {
                if (_skillTable is null) {
                    _skillTable = Portal.SkillTable;
                }
                return _skillTable;
            }
        }

        public VitalTable VitalTable {
            get {
                if (_vitalTable is null) {
                    _vitalTable = Portal.VitalTable;
                }
                return _vitalTable;
            }
        }

        public FSDatReader(ILogger<FSDatReader> log) {
            _log = log;
        }

        public bool Init(string datPath) {
            _datPath = datPath;

            Portal = new PortalDatabase(options => {
            }, new StreamBlockAllocator(new DatReaderWriter.Options.DatDatabaseOptions() {
                FilePath = System.IO.Path.Combine(datPath, $"client_Portal.dat")
            }));

            Cell = new CellDatabase(options => {
            }, new StreamBlockAllocator(new DatReaderWriter.Options.DatDatabaseOptions() {
                FilePath = System.IO.Path.Combine(datPath, $"client_cell_1.dat")
            }));

            return true;
        }

        public T? Get<T>(uint fileId) where T : IDBObj {
            return Portal.TryReadFile<T>(fileId, out T? result) ? result : default;
        }

        public bool TryGet<T>(uint fileId, out T? result) where T : IDBObj {
            result = Get<T>(fileId);
            return result is not null;
        }
    }
}
