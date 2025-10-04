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
        private readonly DatCollection _datCollection;
        private SpellTable? _spellTable;
        private SpellComponentTable? _spellComponentTable;
        private SkillTable? _skillTable;
        private VitalTable? _vitalTable;
        private readonly ILogger _log;

        public PortalDatabase Portal => _datCollection.Portal;
        public PortalDatabase HighRes => _datCollection.HighRes;
        public CellDatabase Cell => _datCollection.Cell;
        public LocalDatabase Local => _datCollection.Local;

        public SpellTable SpellTable {
            get {
                if (_spellTable is null) {
                    if (Portal.SpellTable is null) {
                        throw new Exception("Unable to load SpellTable from dat!");
                    }
                    _spellTable = Portal.SpellTable;
                }
                return _spellTable;
            }
        }

        public SpellComponentTable SpellComponentTable {
            get {
                if (_spellComponentTable is null) {
                    if (Portal.SpellComponentTable is null) {
                        throw new Exception("Unable to load SpellComponentTable from dat!");
                    }
                    _spellComponentTable = Portal.SpellComponentTable;
                }
                return _spellComponentTable;
            }
        }

        public SkillTable SkillTable {
            get {
                if (_skillTable is null) {
                    if (Portal.SkillTable is null) {
                        throw new Exception("Unable to load SkillTable from dat!");
                    }
                    _skillTable = Portal.SkillTable;
                }
                return _skillTable;
            }
        }

        public VitalTable VitalTable {
            get {
                if (_vitalTable is null) {
                    if (Portal.VitalTable is null) {
                        throw new Exception("Unable to load VitalTable from dat!");
                    }
                    _vitalTable = Portal.VitalTable;
                }
                return _vitalTable;
            }
        }

        public FSDatReader(string datPath, ILogger<FSDatReader> log) {
            _log = log;
            _datPath = datPath;

            _datCollection = new DatCollection(datPath);
        }

        public T? Get<T>(uint fileId) where T : IDBObj {
            return _datCollection.Get<T>(fileId);
        }

        public bool TryGet<T>(uint fileId, out T? result) where T : IDBObj {
            result = Get<T>(fileId);
            return result is not null;
        }
    }
}
