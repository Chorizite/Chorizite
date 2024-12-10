using Chorizite.ACProtocol.Types;
using Chorizite.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Core.AC.API {
    public class PhysicsDescription {
        public uint ObjectId { get; set; }

        public PhysicsDescriptionFlag Flags { get; set; }

        public Vector3 Acceleration { get; set; } = new Vector3();
        public Vector3 Omega { get; set; } = new Vector3();
        public Vector3 Velocity { get; set; } = new Vector3();

        public uint DefaultScript { get; set; }

        public float DefaultScriptIntensity { get; set; }

        public ushort ObjectPositionSequence { get; set; }

        public ushort ObjectStateSequence { get; set; }

        public ushort ObjectVectorSequence { get; set; }

        public ushort ObjectTeleportSequence { get; set; }

        public ushort ObjectServerControlSequence { get; set; }

        public ushort ObjectForcePositionSequence { get; set; }

        public ushort ObjectVisualDescSequence { get; set; }

        public ushort ObjectInstanceSequence { get; set; }

        public ushort ObjectMovementSequence { get; set; }

        public uint PhysicsScriptTableID { get; set; }

        public IEnumerable<byte> Bytes { get; set; } = new List<byte>();

        public bool Autonomous { get; set; }

        public uint AnimationFrame { get; set; }

        public Position Position { get; set; }

        public uint MotionTableId { get; set; }

        public uint SoundTableId { get; set; }

        public uint MovementByteCount { get; set; }

        public uint SetupTableId { get; set; }

        public uint LocationId { get; set; }

        public uint NumChildren { get; set; }

        //internal List<PhysicsChild> _Children { get; } = new List<PhysicsChild>();
        //public IEnumerable<IPhysicsChild> Children => (IEnumerable<IPhysicsChild>)_Children;

        public float Scale { get; set; }

        public float Friction { get; set; }

        public float Elasticity { get; set; }

        public float Translucency { get; set; }

        public uint Parent { get; set; }

        public PhysicsState State { get; set; }
    }
}
