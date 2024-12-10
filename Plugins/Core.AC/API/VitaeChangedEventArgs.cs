using System;

namespace Core.AC.API {
    public class VitaeChangedEventArgs : EventArgs {
        /// <summary>
        /// Your character's current vitae.
        /// 1 = no vitea, 0.95 = 5% vitae
        /// </summary>
        public float Vitae;

        /// <summary>
        /// Your character's old vitae
        /// 1 = no vitea, 0.95 = 5% vitae
        /// </summary>
        public float OldVitae;

        internal VitaeChangedEventArgs(float vitae, float oldVitae) {
            Vitae = vitae;
            OldVitae = oldVitae;
        }
    }
}