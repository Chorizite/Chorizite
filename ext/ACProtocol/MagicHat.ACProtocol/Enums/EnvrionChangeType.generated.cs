//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//
//                                                            //
//                          WARNING                           //
//                                                            //
//           DO NOT MAKE LOCAL CHANGES TO THIS FILE           //
//               EDIT THE .tt TEMPLATE INSTEAD                //
//                                                            //
//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//


using System;
namespace MagicHat.ACProtocol.Enums {
    /// <summary>
    /// The EnvrionChangeType identifies the environment option set.
    /// </summary>
    public enum EnvrionChangeType : uint {
        /// <summary>
        /// Removes all overrides
        /// </summary>
        Clear = 0x00,

        /// <summary>
        /// Sets Red Fog
        /// </summary>
        RedFog = 0x01,

        /// <summary>
        /// Sets Blue Fog
        /// </summary>
        BlueFog = 0x02,

        /// <summary>
        /// Sets White Fog
        /// </summary>
        WhiteFog = 0x03,

        /// <summary>
        /// Sets Green Fog
        /// </summary>
        GreenFog = 0x04,

        /// <summary>
        /// Sets Black Fog
        /// </summary>
        BlackFog = 0x05,

        /// <summary>
        /// Sets Black Fog
        /// </summary>
        BlackFog2 = 0x06,

        /// <summary>
        /// Play Roar Sound
        /// </summary>
        RoarSound = 0x65,

        /// <summary>
        /// Play Bell Sound
        /// </summary>
        BellSound = 0x66,

        /// <summary>
        /// Play Chant1 Sound
        /// </summary>
        Chant1Sound = 0x67,

        /// <summary>
        /// Play Chant2 Sound
        /// </summary>
        Chant2Sound = 0x68,

        /// <summary>
        /// Play DarkWhispers1 Sound
        /// </summary>
        DarkWhispers1Sound = 0x69,

        /// <summary>
        /// Play DarkWhispers2 Sound
        /// </summary>
        DarkWhispers2Sound = 0x6A,

        /// <summary>
        /// Play DarkLaugh Sound
        /// </summary>
        DarkLaughSound = 0x6B,

        /// <summary>
        /// Play DarkWind Sound
        /// </summary>
        DarkWindSound = 0x6C,

        /// <summary>
        /// Play DarkSpeech Sound
        /// </summary>
        DarkSpeechSound = 0x6D,

        /// <summary>
        /// Play Drums Sound
        /// </summary>
        DrumsSound = 0x6E,

        /// <summary>
        /// Play GhostSpeak Sound
        /// </summary>
        GhostSpeakSound = 0x6F,

        /// <summary>
        /// Play Breathing Sound
        /// </summary>
        BreathingSound = 0x70,

        /// <summary>
        /// Play Howl Sound
        /// </summary>
        HowlSound = 0x71,

        /// <summary>
        /// Play LostSouls Sound
        /// </summary>
        LostSoulsSound = 0x72,

        /// <summary>
        /// Play Squeal Sound
        /// </summary>
        SquealSound = 0x75,

        /// <summary>
        /// Play Thunder1 Sound
        /// </summary>
        Thunder1Sound = 0x76,

        /// <summary>
        /// Play Thunder2 Sound
        /// </summary>
        Thunder2Sound = 0x77,

        /// <summary>
        /// Play Thunder3 Sound
        /// </summary>
        Thunder3Sound = 0x78,

        /// <summary>
        /// Play Thunder4 Sound
        /// </summary>
        Thunder4Sound = 0x79,

        /// <summary>
        /// Play Thunder5 Sound
        /// </summary>
        Thunder5Sound = 0x7A,

        /// <summary>
        /// Play Thunder6 Sound
        /// </summary>
        Thunder6Sound = 0x7B,

    };
}
