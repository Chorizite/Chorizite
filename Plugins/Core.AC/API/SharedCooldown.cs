using Chorizite.ACProtocol.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.AC.API {
    /// <summary>
    /// Item use cooldowns
    /// </summary>
    public class SharedCooldown {
        /// <summary>
        /// The full layered id of this cooldown
        /// </summary>
        public LayeredSpellId LayeredId { get; set; }

        /// <summary>
        /// The shared id of this cooldown. Get an objects SharedCooldownId with IntId.SharedCooldown
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The id of the world object that triggered this cooldown
        /// </summary>
        public uint ObjectId { get; set; }

        /// <summary>
        /// The time in seconds that the cooldown has been active before we heard about
        /// it from the server.
        /// </summary>
        public double StartTime { get; set; }

        /// <summary>
        /// The total duration in seconds this cooldown should last for
        /// </summary>
        public double Duration { get; set; }

        /// <summary>
        /// The datetime that the client recieved this cooldown from the server.
        /// </summary>
        public DateTime ClientReceivedAt { get; set; }

        /// <summary>
        /// The datetime this cooldown will expire. All times are in UTC.
        /// Formula is: (Duration &lt; 0) ? DateTime.MaxValue : ClientReceivedAt + TimeSpan.FromSeconds(Duration) - TimeSpan.FromSeconds(StartTime)
        /// </summary>
        [JsonIgnore]
        public DateTime ExpiresAt => (Duration < 0) ? DateTime.MaxValue : ClientReceivedAt + TimeSpan.FromSeconds(Duration) - TimeSpan.FromSeconds(StartTime);

        public SharedCooldown() { }

        internal SharedCooldown(LayeredSpellId layeredId, uint objectId, double duration, double startTime) {
            Id = (int)(layeredId.Id << 20 >> 20);
            LayeredId = layeredId;
            ObjectId = objectId;
            ClientReceivedAt = DateTime.UtcNow;
            Duration = duration;
            StartTime = startTime;
        }

        internal static SharedCooldown FromMessage(Chorizite.ACProtocol.Types.Enchantment enchantmentData) {
            return new SharedCooldown(enchantmentData.Id, enchantmentData.CasterId, enchantmentData.Duration, enchantmentData.StartTime);
        }
    }
}
