using ACClientLib.DatReaderWriter;
using ACClientLib.DatReaderWriter.IO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicHat.Core.Dats {
    internal class FSDatReader : IDatReaderInterface {
        private string _datPath;
        private readonly ILogger _log;

        public DatDatabaseReader PortalDat { get; private set; }

        public FSDatReader(ILogger<FSDatReader> log) {
            _log = log;
        }

        public bool Init(string datPath) {
            _datPath = datPath;

            PortalDat = new DatDatabaseReader(options => {
                options.FilePath = System.IO.Path.Combine(datPath, $"client_Portal.dat");
            });

            return true;
        }

        public T? Get<T>(uint fileId) where T : IUnpackable {
            return PortalDat.TryReadFile<T>(fileId, out T? result) ? result : default;
        }

        public bool TryGet<T>(uint fileId, out T? result) where T : IUnpackable {
            result = Get<T>(fileId);
            return result is not null;
        }
    }
}
