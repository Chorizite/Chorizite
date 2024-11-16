using DatReaderWriter;
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
        private readonly ILogger _log;
        private readonly IChoriziteConfig _config;

        public DatDatabase PortalDat { get; private set; }

        public FSDatReader(ILogger<FSDatReader> log) {
            _log = log;
        }

        public bool Init(string datPath) {
            _datPath = datPath;

            PortalDat = new DatDatabase(options => {
            }, new StreamBlockAllocator(new DatReaderWriter.Options.DatDatabaseOptions() {
                FilePath = System.IO.Path.Combine(datPath, $"client_Portal.dat")
            }));

            return true;
        }

        public T? Get<T>(uint fileId) where T : IDBObj {
            return PortalDat.TryReadFile<T>(fileId, out T? result) ? result : default;
        }

        public bool TryGet<T>(uint fileId, out T? result) where T : IDBObj {
            result = Get<T>(fileId);
            return result is not null;
        }
    }
}
