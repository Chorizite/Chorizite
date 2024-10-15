//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//
//                                                            //
//                          WARNING                           //
//                                                            //
//           DO NOT MAKE LOCAL CHANGES TO THIS FILE           //
//               EDIT THE .tt TEMPLATE INSTEAD                //
//                                                            //
//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//


using System;
namespace Chorizite.ACProtocol.Enums {
    /// <summary>
    /// The PropertyPosition identifies a specific Character or Object position property.
    /// </summary>
    public enum PropertyPosition : uint {
        /// <summary>
        /// Current Position
        /// </summary>
        Location = 1,

        /// <summary>
        /// May be used to store where we are headed when we teleport (?)
        /// </summary>
        Destination = 2,

        /// <summary>
        /// Where will we pop into the world (?)
        /// </summary>
        Instantiation = 3,

        /// <summary>
        /// Last Lifestone Used? (@ls)? | @home | @save | @recall
        /// </summary>
        Sanctuary = 4,

        /// <summary>
        /// This is the home, starting, or base position of an object. It&#39;s usually the position the object first spawned in at.
        /// </summary>
        Home = 5,

        /// <summary>
        /// The need to research
        /// </summary>
        ActivationMove = 6,

        /// <summary>
        /// The the position of target.
        /// </summary>
        Target = 7,

        /// <summary>
        /// Primary Portal Recall | Summon Primary Portal | Primary Portal Tie
        /// </summary>
        LinkedPortalOne = 8,

        /// <summary>
        /// Portal Recall (Last Used Portal that can be recalled to)
        /// </summary>
        LastPortal = 9,

        /// <summary>
        /// The portal storm - need research - maybe where you were portaled from or to - to does not seem likely to me.
        /// </summary>
        PortalStorm = 10,

        /// <summary>
        /// The crash and turn - I can&#39;t wait to find out.
        /// </summary>
        CrashAndTurn = 11,

        /// <summary>
        /// We are tracking what the portal ties are - could this be the physical location of the portal you summoned?   More research needed.
        /// </summary>
        PortalSummonLoc = 12,

        /// <summary>
        /// That little spot you get sent to just outside the barrier when the slum lord evicts you (??)
        /// </summary>
        HouseBoot = 13,

        /// <summary>
        /// The last outside death. --- boy would I love to extend this to cover deaths in dungeons as well.
        /// </summary>
        LastOutsideDeath = 14,

        /// <summary>
        /// The linked lifestone - Lifestone Recall | Lifestone Tie
        /// </summary>
        LinkedLifestone = 15,

        /// <summary>
        /// Secondary Portal Recall | Summon Secondary Portal | Secondary Portal Tie
        /// </summary>
        LinkedPortalTwo = 16,

        /// <summary>
        /// Admin Quick Recall Position 1
        /// </summary>
        Save1 = 17,

        /// <summary>
        /// Admin Quick Recall Position 2
        /// </summary>
        Save2 = 18,

        /// <summary>
        /// Admin Quick Recall Position 3
        /// </summary>
        Save3 = 19,

        /// <summary>
        /// Admin Quick Recall Position 4
        /// </summary>
        Save4 = 20,

        /// <summary>
        /// Admin Quick Recall Position 5
        /// </summary>
        Save5 = 21,

        /// <summary>
        /// Admin Quick Recall Position 6
        /// </summary>
        Save6 = 22,

        /// <summary>
        /// Admin Quick Recall Position 7
        /// </summary>
        Save7 = 23,

        /// <summary>
        /// Admin Quick Recall Position 8
        /// </summary>
        Save8 = 24,

        /// <summary>
        /// Admin Quick Recall Position 9
        /// </summary>
        Save9 = 25,

        /// <summary>
        /// Position data is relative to Location
        /// </summary>
        RelativeDestination = 26,

        /// <summary>
        /// Admin - Position to return player to when using @telereturn which is where a character was at time of admin using @teletome
        /// </summary>
        TeleportedCharacter = 27,

    };
}
