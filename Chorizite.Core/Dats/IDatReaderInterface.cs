using Chorizite.Core.Net;
using DatReaderWriter;
using DatReaderWriter.DBObjs;
using DatReaderWriter.Lib.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Dats {
    /// <summary>
    /// Interface for reading dat files
    /// </summary>
    public interface IDatReaderInterface {
        /// <summary>
        /// The portal database
        /// </summary>
        public PortalDatabase Portal { get; }

        /// <summary>
        /// The cell database
        /// </summary>
        public CellDatabase Cell { get; }

        /// <summary>
        /// The spell table
        /// </summary>
        SpellTable SpellTable { get; }

        /// <summary>
        /// The skill table
        /// </summary>
        SkillTable SkillTable { get; }

        /// <summary>
        /// The vital table
        /// </summary>
        VitalTable VitalTable { get; }

        /// <summary>
        /// Get a dat file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileId"></param>
        /// <returns></returns>
        T? Get<T>(uint fileId) where T : IDBObj;

        /// <summary>
        /// Try to get a dat file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileId"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        bool TryGet<T>(uint fileId, out T? result) where T : IDBObj;
    }
}
