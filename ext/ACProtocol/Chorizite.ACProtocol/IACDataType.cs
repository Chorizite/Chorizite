using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Chorizite.ACProtocol.Extensions;

namespace Chorizite.ACProtocol.Types {
    public interface IACDataType {
        /// <summary>
        /// Populates this data type instance from a BinaryReader buffer
        /// </summary>
        /// <param name="reader">BinaryReader instance to read from</param>
        void Read(BinaryReader reader);

        /// <summary>
        /// Dump this data type instance to a binary writer
        /// </summary>
        /// <param name="writer">BinaryWriter instance to write to</param>
        void Write(BinaryWriter writer);
    }


	/// <summary>
	/// List which is packable for network
	/// </summary>
	public class PList<T> : IACDataType {
		/// <summary>
		/// Number of items in the list
		/// </summary>
		public uint Count;

		/// <summary>
		/// Holds the actual list data
		/// </summary>
		public List<T> Items { get; set; } = new List<T>();

		/// <summary>
		/// Reads instance data from a binary reader
		/// </summary>
		public void Read(BinaryReader reader) {
			Count = reader.ReadUInt32();
			for (var i = 0; i < Count; i++) {
				Items.Add(reader.ReadItem<T>());
			}
		}
		public void Write(BinaryWriter writer) {
			writer.Write((uint)Items.Count);
			for (var i = 0; i < Items.Count; i++) {
				writer.WriteItem<T>(Items[i]);
			}
		}
	}

	/// <summary>
	/// List which is packable for network
	/// </summary>
	public class PSmartArray<T> : IACDataType {
		/// <summary>
		/// Number of items in the list
		/// </summary>
		public uint Count;

		/// <summary>
		/// Holds the actual array data
		/// </summary>
		public List<T> Items { get; set; } = new List<T>();

		/// <summary>
		/// Reads instance data from a binary reader
		/// </summary>
		public void Read(BinaryReader reader) {
			Count = reader.ReadUInt32();
			for (var i = 0; i < Count; i++) {
				Items.Add(reader.ReadItem<T>());
			}
		}
		public void Write(BinaryWriter writer) {
			writer.Write((uint)Items.Count);
			for (var i = 0; i < Items.Count; i++) {
				writer.WriteItem<T>(Items[i]);
			}
		}
	}
}
