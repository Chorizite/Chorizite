
using System;
using System.IO;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Messages.S2C;
using Chorizite.ACProtocol.Messages.S2C.Events;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol;

namespace Chorizite.ACProtocol {

    public class S2CMessageHandler {
        /// <summary>
        /// Fired for every valid parsed Message
        /// </summary>
        public event EventHandler<S2CMessageEventArgs>? OnMessage;

        /// <summary>
        /// Fired for every valid parsed GameEvent
        /// </summary>
        public event EventHandler<GameEventEventArgs>? OnGameEvent;

        /// <summary>
        /// Fired when an unknown Message type was encountered 
        /// </summary>
        public event EventHandler<UnknownMessageEventArgs>? OnUnknownMessage;

        /// <summary>
        /// Fired on Message type 0x0024 Item_ServerSaysRemove. Sent every time an object you are aware of ceases to exist. Merely running out of range does not generate this message - in that case, the client just automatically stops tracking it after receiving no updates for a while (which I presume is a very short while).
        /// </summary>
        public event EventHandler<Item_ServerSaysRemove>? OnItem_ServerSaysRemove;
    
        /// <summary>
        /// Fired on Message type 0x00A0 Character_ServerSaysAttemptFailed. Failure to give an item
        /// </summary>
        public event EventHandler<Character_ServerSaysAttemptFailed>? OnCharacter_ServerSaysAttemptFailed;
    
        /// <summary>
        /// Fired on Message type 0x0197 Item_UpdateStackSize. For stackable items, this changes the number of items in the stack.
        /// </summary>
        public event EventHandler<Item_UpdateStackSize>? OnItem_UpdateStackSize;
    
        /// <summary>
        /// Fired on Message type 0x019E Combat_HandlePlayerDeathEvent. A Player Kill occurred nearby (also sent for suicides).
        /// </summary>
        public event EventHandler<Combat_HandlePlayerDeathEvent>? OnCombat_HandlePlayerDeathEvent;
    
        /// <summary>
        /// Fired on Message type 0x01D1 Qualities_PrivateRemoveIntEvent. Remove an int property from the character
        /// </summary>
        public event EventHandler<Qualities_PrivateRemoveIntEvent>? OnQualities_PrivateRemoveIntEvent;
    
        /// <summary>
        /// Fired on Message type 0x01D2 Qualities_RemoveIntEvent. Remove an int property from an object
        /// </summary>
        public event EventHandler<Qualities_RemoveIntEvent>? OnQualities_RemoveIntEvent;
    
        /// <summary>
        /// Fired on Message type 0x01D3 Qualities_PrivateRemoveBoolEvent. Remove a bool property from the charactert
        /// </summary>
        public event EventHandler<Qualities_PrivateRemoveBoolEvent>? OnQualities_PrivateRemoveBoolEvent;
    
        /// <summary>
        /// Fired on Message type 0x01D4 Qualities_RemoveBoolEvent. Remove a bool property from an object
        /// </summary>
        public event EventHandler<Qualities_RemoveBoolEvent>? OnQualities_RemoveBoolEvent;
    
        /// <summary>
        /// Fired on Message type 0x01D5 Qualities_PrivateRemoveFloatEvent. Remove a float property from the character
        /// </summary>
        public event EventHandler<Qualities_PrivateRemoveFloatEvent>? OnQualities_PrivateRemoveFloatEvent;
    
        /// <summary>
        /// Fired on Message type 0x01D6 Qualities_RemoveFloatEvent. Remove a float property from an object
        /// </summary>
        public event EventHandler<Qualities_RemoveFloatEvent>? OnQualities_RemoveFloatEvent;
    
        /// <summary>
        /// Fired on Message type 0x01D7 Qualities_PrivateRemoveStringEvent. Remove a string property from the character
        /// </summary>
        public event EventHandler<Qualities_PrivateRemoveStringEvent>? OnQualities_PrivateRemoveStringEvent;
    
        /// <summary>
        /// Fired on Message type 0x01D8 Qualities_RemoveStringEvent. Remove a string property from an object
        /// </summary>
        public event EventHandler<Qualities_RemoveStringEvent>? OnQualities_RemoveStringEvent;
    
        /// <summary>
        /// Fired on Message type 0x01D9 Qualities_PrivateRemoveDataIdEvent. Remove an dataId property from the character
        /// </summary>
        public event EventHandler<Qualities_PrivateRemoveDataIdEvent>? OnQualities_PrivateRemoveDataIdEvent;
    
        /// <summary>
        /// Fired on Message type 0x01DA Qualities_RemoveDataIdEvent. Remove an dataId property from an object
        /// </summary>
        public event EventHandler<Qualities_RemoveDataIdEvent>? OnQualities_RemoveDataIdEvent;
    
        /// <summary>
        /// Fired on Message type 0x01DB Qualities_PrivateRemoveInstanceIdEvent. Remove an instanceId property from the character
        /// </summary>
        public event EventHandler<Qualities_PrivateRemoveInstanceIdEvent>? OnQualities_PrivateRemoveInstanceIdEvent;
    
        /// <summary>
        /// Fired on Message type 0x01DC Qualities_RemoveInstanceIdEvent. Remove an instanceId property from an object
        /// </summary>
        public event EventHandler<Qualities_RemoveInstanceIdEvent>? OnQualities_RemoveInstanceIdEvent;
    
        /// <summary>
        /// Fired on Message type 0x01DD Qualities_PrivateRemovePositionEvent. Remove a position property from the character
        /// </summary>
        public event EventHandler<Qualities_PrivateRemovePositionEvent>? OnQualities_PrivateRemovePositionEvent;
    
        /// <summary>
        /// Fired on Message type 0x01DE Qualities_RemovePositionEvent. Remove a position property from an object
        /// </summary>
        public event EventHandler<Qualities_RemovePositionEvent>? OnQualities_RemovePositionEvent;
    
        /// <summary>
        /// Fired on Message type 0x02B8 Qualities_PrivateRemoveInt64Event. Remove an int64 property from the character
        /// </summary>
        public event EventHandler<Qualities_PrivateRemoveInt64Event>? OnQualities_PrivateRemoveInt64Event;
    
        /// <summary>
        /// Fired on Message type 0x02B9 Qualities_RemoveInt64Event. Remove an int64 property from an object
        /// </summary>
        public event EventHandler<Qualities_RemoveInt64Event>? OnQualities_RemoveInt64Event;
    
        /// <summary>
        /// Fired on Message type 0x02CD Qualities_PrivateUpdateInt. Set or update a Character Int property value
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateInt>? OnQualities_PrivateUpdateInt;
    
        /// <summary>
        /// Fired on Message type 0x02CE Qualities_UpdateInt. Set or update an Object Int property value
        /// </summary>
        public event EventHandler<Qualities_UpdateInt>? OnQualities_UpdateInt;
    
        /// <summary>
        /// Fired on Message type 0x02CF Qualities_PrivateUpdateInt64. Set or update a Character Int64 property value
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateInt64>? OnQualities_PrivateUpdateInt64;
    
        /// <summary>
        /// Fired on Message type 0x02D0 Qualities_UpdateInt64. Set or update a Character Int64 property value
        /// </summary>
        public event EventHandler<Qualities_UpdateInt64>? OnQualities_UpdateInt64;
    
        /// <summary>
        /// Fired on Message type 0x02D1 Qualities_PrivateUpdateBool. Set or update a Character Boolean property value
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateBool>? OnQualities_PrivateUpdateBool;
    
        /// <summary>
        /// Fired on Message type 0x02D2 Qualities_UpdateBool. Set or update an Object Boolean property value
        /// </summary>
        public event EventHandler<Qualities_UpdateBool>? OnQualities_UpdateBool;
    
        /// <summary>
        /// Fired on Message type 0x02D3 Qualities_PrivateUpdateFloat. Set or update an Object float property value
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateFloat>? OnQualities_PrivateUpdateFloat;
    
        /// <summary>
        /// Fired on Message type 0x02D4 Qualities_UpdateFloat. Set or update an Object float property value
        /// </summary>
        public event EventHandler<Qualities_UpdateFloat>? OnQualities_UpdateFloat;
    
        /// <summary>
        /// Fired on Message type 0x02D5 Qualities_PrivateUpdateString. Set or update an Object String property value
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateString>? OnQualities_PrivateUpdateString;
    
        /// <summary>
        /// Fired on Message type 0x02D6 Qualities_UpdateString. Set or update an Object String property value
        /// </summary>
        public event EventHandler<Qualities_UpdateString>? OnQualities_UpdateString;
    
        /// <summary>
        /// Fired on Message type 0x02D7 Qualities_PrivateUpdateDataId. Set or update an Object DId property value
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateDataId>? OnQualities_PrivateUpdateDataId;
    
        /// <summary>
        /// Fired on Message type 0x02D8 Qualities_UpdateDataId. Set or update an Object DId property value
        /// </summary>
        public event EventHandler<Qualities_UpdateDataId>? OnQualities_UpdateDataId;
    
        /// <summary>
        /// Fired on Message type 0x02D9 Qualities_PrivateUpdateInstanceId. Set or update a IId property value
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateInstanceId>? OnQualities_PrivateUpdateInstanceId;
    
        /// <summary>
        /// Fired on Message type 0x02DA Qualities_UpdateInstanceId. Set or update an Object IId property value
        /// </summary>
        public event EventHandler<Qualities_UpdateInstanceId>? OnQualities_UpdateInstanceId;
    
        /// <summary>
        /// Fired on Message type 0x02DB Qualities_PrivateUpdatePosition. Set or update a Character Position property value
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdatePosition>? OnQualities_PrivateUpdatePosition;
    
        /// <summary>
        /// Fired on Message type 0x02DC Qualities_UpdatePosition. Set or update a Character Position property value
        /// </summary>
        public event EventHandler<Qualities_UpdatePosition>? OnQualities_UpdatePosition;
    
        /// <summary>
        /// Fired on Message type 0x02DD Qualities_PrivateUpdateSkill. Set or update a Character Skill value
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateSkill>? OnQualities_PrivateUpdateSkill;
    
        /// <summary>
        /// Fired on Message type 0x02DE Qualities_UpdateSkill. Set or update a Character Skill value
        /// </summary>
        public event EventHandler<Qualities_UpdateSkill>? OnQualities_UpdateSkill;
    
        /// <summary>
        /// Fired on Message type 0x02DF Qualities_PrivateUpdateSkillLevel. Set or update a Character Skill Level
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateSkillLevel>? OnQualities_PrivateUpdateSkillLevel;
    
        /// <summary>
        /// Fired on Message type 0x02E0 Qualities_UpdateSkillLevel. Set or update a Character Skill Level
        /// </summary>
        public event EventHandler<Qualities_UpdateSkillLevel>? OnQualities_UpdateSkillLevel;
    
        /// <summary>
        /// Fired on Message type 0x02E1 Qualities_PrivateUpdateSkillAC. Set or update a Character Skill state
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateSkillAC>? OnQualities_PrivateUpdateSkillAC;
    
        /// <summary>
        /// Fired on Message type 0x02E2 Qualities_UpdateSkillAC. Set or update a Character Skill state
        /// </summary>
        public event EventHandler<Qualities_UpdateSkillAC>? OnQualities_UpdateSkillAC;
    
        /// <summary>
        /// Fired on Message type 0x02E3 Qualities_PrivateUpdateAttribute. Set or update a Character Attribute value
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateAttribute>? OnQualities_PrivateUpdateAttribute;
    
        /// <summary>
        /// Fired on Message type 0x02E4 Qualities_UpdateAttribute. Set or update a Character Attribute value
        /// </summary>
        public event EventHandler<Qualities_UpdateAttribute>? OnQualities_UpdateAttribute;
    
        /// <summary>
        /// Fired on Message type 0x02E5 Qualities_PrivateUpdateAttributeLevel. Set or update a Character Attribute Level
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateAttributeLevel>? OnQualities_PrivateUpdateAttributeLevel;
    
        /// <summary>
        /// Fired on Message type 0x02E6 Qualities_UpdateAttributeLevel. Set or update a Character Attribute Level
        /// </summary>
        public event EventHandler<Qualities_UpdateAttributeLevel>? OnQualities_UpdateAttributeLevel;
    
        /// <summary>
        /// Fired on Message type 0x02E7 Qualities_PrivateUpdateAttribute2nd. Set or update a Character Vital value
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateAttribute2nd>? OnQualities_PrivateUpdateAttribute2nd;
    
        /// <summary>
        /// Fired on Message type 0x02E8 Qualities_UpdateAttribute2nd. Set or update a Character Vital value
        /// </summary>
        public event EventHandler<Qualities_UpdateAttribute2nd>? OnQualities_UpdateAttribute2nd;
    
        /// <summary>
        /// Fired on Message type 0x02E9 Qualities_PrivateUpdateAttribute2ndLevel. Set or update a Character Vital value
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateAttribute2ndLevel>? OnQualities_PrivateUpdateAttribute2ndLevel;
    
        /// <summary>
        /// Fired on Message type 0x02EA Qualities_UpdateAttribute2ndLevel. Set or update a Character Vital value
        /// </summary>
        public event EventHandler<Qualities_UpdateAttribute2ndLevel>? OnQualities_UpdateAttribute2ndLevel;
    
        /// <summary>
        /// Fired on Message type 0x01E0 Communication_HearEmote. Indirect '/e' text.
        /// </summary>
        public event EventHandler<Communication_HearEmote>? OnCommunication_HearEmote;
    
        /// <summary>
        /// Fired on Message type 0x01E2 Communication_HearSoulEmote. Contains the text associated with an emote action.
        /// </summary>
        public event EventHandler<Communication_HearSoulEmote>? OnCommunication_HearSoulEmote;
    
        /// <summary>
        /// Fired on Message type 0x02BB Communication_HearSpeech. A message to be displayed in the chat window, spoken by a nearby player, NPC or creature
        /// </summary>
        public event EventHandler<Communication_HearSpeech>? OnCommunication_HearSpeech;
    
        /// <summary>
        /// Fired on Message type 0x02BC Communication_HearRangedSpeech. A message to be displayed in the chat window, spoken by a nearby player, NPC or creature
        /// </summary>
        public event EventHandler<Communication_HearRangedSpeech>? OnCommunication_HearRangedSpeech;
    
        /// <summary>
        /// Fired on Message type 0xEA60 Admin_Environs. This appears to be an admin command to change the environment (light, fog, sounds, colors)
        /// </summary>
        public event EventHandler<Admin_Environs>? OnAdmin_Environs;
    
        /// <summary>
        /// Fired on Message type 0xF619 Movement_PositionAndMovementEvent. Sets both the position and movement, such as when materializing at a lifestone
        /// </summary>
        public event EventHandler<Movement_PositionAndMovementEvent>? OnMovement_PositionAndMovementEvent;
    
        /// <summary>
        /// Fired on Message type 0xF625 Item_ObjDescEvent. Sent whenever a character changes their clothes. It contains the entire description of what their wearing (and possibly their facial features as well). This message is only sent for changes, when the character is first created, the body of this message is included inside the creation message.
        /// </summary>
        public event EventHandler<Item_ObjDescEvent>? OnItem_ObjDescEvent;
    
        /// <summary>
        /// Fired on Message type 0xF630 Character_SetPlayerVisualDesc. Sets the player visual desc, TODO confirm this
        /// </summary>
        public event EventHandler<Character_SetPlayerVisualDesc>? OnCharacter_SetPlayerVisualDesc;
    
        /// <summary>
        /// Fired on Message type 0xF643 Character_CharGenVerificationResponse. Character creation screen initilised.
        /// </summary>
        public event EventHandler<Character_CharGenVerificationResponse>? OnCharacter_CharGenVerificationResponse;
    
        /// <summary>
        /// Fired on Message type 0xF651 Login_AwaitingSubscriptionExpiration. Sent when your subsciption is about to expire
        /// </summary>
        public event EventHandler<Login_AwaitingSubscriptionExpiration>? OnLogin_AwaitingSubscriptionExpiration;
    
        /// <summary>
        /// Fired on Message type 0xF653 Login_LogOffCharacter. Instructs the client to return to 2D mode - the character list.
        /// </summary>
        public event EventHandler<Login_LogOffCharacter>? OnLogin_LogOffCharacter;
    
        /// <summary>
        /// Fired on Message type 0xF655 Character_CharacterDelete. A character was marked for deletetion.
        /// </summary>
        public event EventHandler<Character_CharacterDelete>? OnCharacter_CharacterDelete;
    
        /// <summary>
        /// Fired on Message type 0xF658 Login_LoginCharacterSet. The list of characters on the current account.
        /// </summary>
        public event EventHandler<Login_LoginCharacterSet>? OnLogin_LoginCharacterSet;
    
        /// <summary>
        /// Fired on Message type 0xF659 Character_CharacterError. Failure to log in
        /// </summary>
        public event EventHandler<Character_CharacterError>? OnCharacter_CharacterError;
    
        /// <summary>
        /// Fired on Message type 0xF745 Item_CreateObject. Create an object somewhere in the world
        /// </summary>
        public event EventHandler<Item_CreateObject>? OnItem_CreateObject;
    
        /// <summary>
        /// Fired on Message type 0xF746 Login_CreatePlayer. Login of player
        /// </summary>
        public event EventHandler<Login_CreatePlayer>? OnLogin_CreatePlayer;
    
        /// <summary>
        /// Fired on Message type 0xF747 Item_DeleteObject. Sent whenever an object is being deleted from the scene.
        /// </summary>
        public event EventHandler<Item_DeleteObject>? OnItem_DeleteObject;
    
        /// <summary>
        /// Fired on Message type 0xF748 Movement_PositionEvent. Sets the position/motion of an object
        /// </summary>
        public event EventHandler<Movement_PositionEvent>? OnMovement_PositionEvent;
    
        /// <summary>
        /// Fired on Message type 0xF749 Item_ParentEvent. Sets the parent for an object, eg. equipting an object.
        /// </summary>
        public event EventHandler<Item_ParentEvent>? OnItem_ParentEvent;
    
        /// <summary>
        /// Fired on Message type 0xF74A Inventory_PickupEvent. Sent when picking up an object
        /// </summary>
        public event EventHandler<Inventory_PickupEvent>? OnInventory_PickupEvent;
    
        /// <summary>
        /// Fired on Message type 0xF74B Item_SetState. Set's the current state of the object. Client appears to only process the following state changes post creation: NoDraw, LightingOn, Hidden
        /// </summary>
        public event EventHandler<Item_SetState>? OnItem_SetState;
    
        /// <summary>
        /// Fired on Message type 0xF74C Movement_SetObjectMovement. These are animations. Whenever a human, monster or object moves - one of these little messages is sent. Even idle emotes (like head scratching and nodding) are sent in this manner.
        /// </summary>
        public event EventHandler<Movement_SetObjectMovement>? OnMovement_SetObjectMovement;
    
        /// <summary>
        /// Fired on Message type 0xF74E Movement_VectorUpdate. Changes an objects vector, for things like jumping
        /// </summary>
        public event EventHandler<Movement_VectorUpdate>? OnMovement_VectorUpdate;
    
        /// <summary>
        /// Fired on Message type 0xF750 Effects_SoundEvent. Applies a sound effect.
        /// </summary>
        public event EventHandler<Effects_SoundEvent>? OnEffects_SoundEvent;
    
        /// <summary>
        /// Fired on Message type 0xF751 Effects_PlayerTeleport. Instructs the client to show the portal graphic.
        /// </summary>
        public event EventHandler<Effects_PlayerTeleport>? OnEffects_PlayerTeleport;
    
        /// <summary>
        /// Fired on Message type 0xF754 Effects_PlayScriptId. Instructs the client to play a script. (Not seen so far, maybe prefered PlayScriptType)
        /// </summary>
        public event EventHandler<Effects_PlayScriptId>? OnEffects_PlayScriptId;
    
        /// <summary>
        /// Fired on Message type 0xF755 Effects_PlayScriptType. Applies an effect with visual and sound by providing the type to be looked up in the Physics Script Table
        /// </summary>
        public event EventHandler<Effects_PlayScriptType>? OnEffects_PlayScriptType;
    
        /// <summary>
        /// Fired on Message type 0xF7C1 Login_AccountBanned. Account has been banned
        /// </summary>
        public event EventHandler<Login_AccountBanned>? OnLogin_AccountBanned;
    
        /// <summary>
        /// Fired on Message type 0xF7CA Admin_ReceiveAccountData. Admin Receive Account Data
        /// </summary>
        public event EventHandler<Admin_ReceiveAccountData>? OnAdmin_ReceiveAccountData;
    
        /// <summary>
        /// Fired on Message type 0xF7CB Admin_ReceivePlayerData. Admin Receive Player Data
        /// </summary>
        public event EventHandler<Admin_ReceivePlayerData>? OnAdmin_ReceivePlayerData;
    
        /// <summary>
        /// Fired on Message type 0xF7DB Item_UpdateObject. Update an existing object's data.
        /// </summary>
        public event EventHandler<Item_UpdateObject>? OnItem_UpdateObject;
    
        /// <summary>
        /// Fired on Message type 0xF7DC Login_AccountBooted. Account has been booted
        /// </summary>
        public event EventHandler<Login_AccountBooted>? OnLogin_AccountBooted;
    
        /// <summary>
        /// Fired on Message type 0xF7DE Communication_TurbineChat. Send or receive a message using Turbine Chat.
        /// </summary>
        public event EventHandler<Communication_TurbineChat>? OnCommunication_TurbineChat;
    
        /// <summary>
        /// Fired on Message type 0xF7DF Login_EnterGame_ServerReady. Switch from the character display to the game display.
        /// </summary>
        public event EventHandler<Login_EnterGame_ServerReady>? OnLogin_EnterGame_ServerReady;
    
        /// <summary>
        /// Fired on Message type 0xF7E0 Communication_TextboxString. Display a message in the chat window.
        /// </summary>
        public event EventHandler<Communication_TextboxString>? OnCommunication_TextboxString;
    
        /// <summary>
        /// Fired on Message type 0xF7E1 Login_WorldInfo. The name of the current world.
        /// </summary>
        public event EventHandler<Login_WorldInfo>? OnLogin_WorldInfo;
    
        /// <summary>
        /// Fired on Message type 0xF7E2 DDD_DataMessage. Add or update a dat file Resource.
        /// </summary>
        public event EventHandler<DDD_DataMessage>? OnDDD_DataMessage;
    
        /// <summary>
        /// Fired on Message type 0xF7E4 DDD_ErrorMessage. DDD error
        /// </summary>
        public event EventHandler<DDD_ErrorMessage>? OnDDD_ErrorMessage;
    
        /// <summary>
        /// Fired on Message type 0xF7E7 DDD_BeginDDDMessage. A list of dat files that need to be patched
        /// </summary>
        public event EventHandler<DDD_BeginDDDMessage>? OnDDD_BeginDDDMessage;
    
        /// <summary>
        /// Fired on Message type 0xF7E5 DDD_InterrogationMessage. Add or update a dat file Resource.
        /// </summary>
        public event EventHandler<DDD_InterrogationMessage>? OnDDD_InterrogationMessage;
    
        /// <summary>
        /// Fired on Message type 0xF7EA DDD_OnEndDDD. Ends DDD update
        /// </summary>
        public event EventHandler<DDD_OnEndDDD>? OnDDD_OnEndDDD;
    
        /// <summary>
        /// Fired on Message type 0xF7B0 Ordered_GameEvent. Ordered game event
        /// </summary>
        public event EventHandler<Ordered_GameEvent>? OnOrdered_GameEvent;
    
        /// <summary>
        /// Fired on GameEvent type 0x0003 Allegiance_AllegianceUpdateAborted. Allegiance update cancelled
        /// </summary>
        public event EventHandler<Allegiance_AllegianceUpdateAborted>? OnAllegiance_AllegianceUpdateAborted;
    
        /// <summary>
        /// Fired on GameEvent type 0x0004 Communication_PopUpString. Display a message in a popup message window.
        /// </summary>
        public event EventHandler<Communication_PopUpString>? OnCommunication_PopUpString;
    
        /// <summary>
        /// Fired on GameEvent type 0x0013 Login_PlayerDescription. Information describing your character.
        /// </summary>
        public event EventHandler<Login_PlayerDescription>? OnLogin_PlayerDescription;
    
        /// <summary>
        /// Fired on GameEvent type 0x0020 Allegiance_AllegianceUpdate. Returns info related to your monarch, patron and vassals.
        /// </summary>
        public event EventHandler<Allegiance_AllegianceUpdate>? OnAllegiance_AllegianceUpdate;
    
        /// <summary>
        /// Fired on GameEvent type 0x0021 Social_FriendsUpdate. Friends list update
        /// </summary>
        public event EventHandler<Social_FriendsUpdate>? OnSocial_FriendsUpdate;
    
        /// <summary>
        /// Fired on GameEvent type 0x0022 Item_ServerSaysContainId. Store an item in a container.
        /// </summary>
        public event EventHandler<Item_ServerSaysContainId>? OnItem_ServerSaysContainId;
    
        /// <summary>
        /// Fired on GameEvent type 0x0023 Item_WearItem. Equip an item.
        /// </summary>
        public event EventHandler<Item_WearItem>? OnItem_WearItem;
    
        /// <summary>
        /// Fired on GameEvent type 0x0029 Social_CharacterTitleTable. Titles for the current character.
        /// </summary>
        public event EventHandler<Social_CharacterTitleTable>? OnSocial_CharacterTitleTable;
    
        /// <summary>
        /// Fired on GameEvent type 0x002B Social_AddOrSetCharacterTitle. Set a title for the current character.
        /// </summary>
        public event EventHandler<Social_AddOrSetCharacterTitle>? OnSocial_AddOrSetCharacterTitle;
    
        /// <summary>
        /// Fired on GameEvent type 0x0052 Item_StopViewingObjectContents. Close Container - Only sent when explicitly closed
        /// </summary>
        public event EventHandler<Item_StopViewingObjectContents>? OnItem_StopViewingObjectContents;
    
        /// <summary>
        /// Fired on GameEvent type 0x0062 Vendor_VendorInfo. Open the buy/sell panel for a merchant.
        /// </summary>
        public event EventHandler<Vendor_VendorInfo>? OnVendor_VendorInfo;
    
        /// <summary>
        /// Fired on GameEvent type 0x0075 Character_StartBarber. Opens barber UI
        /// </summary>
        public event EventHandler<Character_StartBarber>? OnCharacter_StartBarber;
    
        /// <summary>
        /// Fired on GameEvent type 0x00A3 Fellowship_Quit. Member left fellowship
        /// </summary>
        public event EventHandler<Fellowship_Quit>? OnFellowship_Quit;
    
        /// <summary>
        /// Fired on GameEvent type 0x00A4 Fellowship_Dismiss. Member dismissed from fellowship
        /// </summary>
        public event EventHandler<Fellowship_Dismiss>? OnFellowship_Dismiss;
    
        /// <summary>
        /// Fired on GameEvent type 0x00B4 Writing_BookOpen. Sent when you first open a book, contains the entire table of contents.
        /// </summary>
        public event EventHandler<Writing_BookOpen>? OnWriting_BookOpen;
    
        /// <summary>
        /// Fired on GameEvent type 0x00B6 Writing_BookAddPageResponse. Response to an attempt to add a page to a book.
        /// </summary>
        public event EventHandler<Writing_BookAddPageResponse>? OnWriting_BookAddPageResponse;
    
        /// <summary>
        /// Fired on GameEvent type 0x00B7 Writing_BookDeletePageResponse. Response to an attempt to delete a page from a book.
        /// </summary>
        public event EventHandler<Writing_BookDeletePageResponse>? OnWriting_BookDeletePageResponse;
    
        /// <summary>
        /// Fired on GameEvent type 0x00B8 Writing_BookPageDataResponse. Contains the text of a single page of a book, parchment or sign.
        /// </summary>
        public event EventHandler<Writing_BookPageDataResponse>? OnWriting_BookPageDataResponse;
    
        /// <summary>
        /// Fired on GameEvent type 0x00C3 Item_GetInscriptionResponse. Get Inscription Response, doesn't seem to be really used by client
        /// </summary>
        public event EventHandler<Item_GetInscriptionResponse>? OnItem_GetInscriptionResponse;
    
        /// <summary>
        /// Fired on GameEvent type 0x00C9 Item_SetAppraiseInfo. The result of an attempt to assess an item or creature.
        /// </summary>
        public event EventHandler<Item_SetAppraiseInfo>? OnItem_SetAppraiseInfo;
    
        /// <summary>
        /// Fired on GameEvent type 0x0147 Communication_ChannelBroadcast. ChannelBroadcast: Group Chat
        /// </summary>
        public event EventHandler<Communication_ChannelBroadcast>? OnCommunication_ChannelBroadcast;
    
        /// <summary>
        /// Fired on GameEvent type 0x0148 Communication_ChannelList. ChannelList: Provides list of characters listening to a channel, I assume in response to a command
        /// </summary>
        public event EventHandler<Communication_ChannelList>? OnCommunication_ChannelList;
    
        /// <summary>
        /// Fired on GameEvent type 0x0149 Communication_ChannelIndex. ChannelIndex: Provides list of channels available to the player, I assume in response to a command
        /// </summary>
        public event EventHandler<Communication_ChannelIndex>? OnCommunication_ChannelIndex;
    
        /// <summary>
        /// Fired on GameEvent type 0x0196 Item_OnViewContents. Set Pack Contents
        /// </summary>
        public event EventHandler<Item_OnViewContents>? OnItem_OnViewContents;
    
        /// <summary>
        /// Fired on GameEvent type 0x019A Item_ServerSaysMoveItem. ServerSaysMoveItem: Removes an item from inventory (when you place it on the ground or give it away)
        /// </summary>
        public event EventHandler<Item_ServerSaysMoveItem>? OnItem_ServerSaysMoveItem;
    
        /// <summary>
        /// Fired on GameEvent type 0x01A7 Combat_HandleAttackDoneEvent. HandleAttackDoneEvent: Melee attack completed
        /// </summary>
        public event EventHandler<Combat_HandleAttackDoneEvent>? OnCombat_HandleAttackDoneEvent;
    
        /// <summary>
        /// Fired on GameEvent type 0x01A8 Magic_RemoveSpell. RemoveSpell: Delete a spell from your spellbook.
        /// </summary>
        public event EventHandler<Magic_RemoveSpell>? OnMagic_RemoveSpell;
    
        /// <summary>
        /// Fired on GameEvent type 0x01AC Combat_HandleVictimNotificationEventSelf. You just died.
        /// </summary>
        public event EventHandler<Combat_HandleVictimNotificationEventSelf>? OnCombat_HandleVictimNotificationEventSelf;
    
        /// <summary>
        /// Fired on GameEvent type 0x01AD Combat_HandleVictimNotificationEventOther. Message for a death, something you killed or your own death message.
        /// </summary>
        public event EventHandler<Combat_HandleVictimNotificationEventOther>? OnCombat_HandleVictimNotificationEventOther;
    
        /// <summary>
        /// Fired on GameEvent type 0x01B1 Combat_HandleAttackerNotificationEvent. HandleAttackerNotificationEvent: You have hit your target with a melee attack.
        /// </summary>
        public event EventHandler<Combat_HandleAttackerNotificationEvent>? OnCombat_HandleAttackerNotificationEvent;
    
        /// <summary>
        /// Fired on GameEvent type 0x01B2 Combat_HandleDefenderNotificationEvent. HandleDefenderNotificationEvent: You have been hit by a creature's melee attack.
        /// </summary>
        public event EventHandler<Combat_HandleDefenderNotificationEvent>? OnCombat_HandleDefenderNotificationEvent;
    
        /// <summary>
        /// Fired on GameEvent type 0x01B3 Combat_HandleEvasionAttackerNotificationEvent. HandleEvasionAttackerNotificationEvent: Your target has evaded your melee attack.
        /// </summary>
        public event EventHandler<Combat_HandleEvasionAttackerNotificationEvent>? OnCombat_HandleEvasionAttackerNotificationEvent;
    
        /// <summary>
        /// Fired on GameEvent type 0x01B4 Combat_HandleEvasionDefenderNotificationEvent. HandleEvasionDefenderNotificationEvent: You have evaded a creature's melee attack.
        /// </summary>
        public event EventHandler<Combat_HandleEvasionDefenderNotificationEvent>? OnCombat_HandleEvasionDefenderNotificationEvent;
    
        /// <summary>
        /// Fired on GameEvent type 0x01B8 Combat_HandleCommenceAttackEvent. HandleCommenceAttackEvent: Start melee attack
        /// </summary>
        public event EventHandler<Combat_HandleCommenceAttackEvent>? OnCombat_HandleCommenceAttackEvent;
    
        /// <summary>
        /// Fired on GameEvent type 0x01C0 Combat_QueryHealthResponse. QueryHealthResponse: Update a creature's health bar.
        /// </summary>
        public event EventHandler<Combat_QueryHealthResponse>? OnCombat_QueryHealthResponse;
    
        /// <summary>
        /// Fired on GameEvent type 0x01C3 Character_QueryAgeResponse. QueryAgeResponse: happens when you do /age in the game
        /// </summary>
        public event EventHandler<Character_QueryAgeResponse>? OnCharacter_QueryAgeResponse;
    
        /// <summary>
        /// Fired on GameEvent type 0x01C7 Item_UseDone. UseDone: Ready. Previous action complete
        /// </summary>
        public event EventHandler<Item_UseDone>? OnItem_UseDone;
    
        /// <summary>
        /// Fired on GameEvent type 0x01C8 Allegiance_AllegianceUpdateDone. Allegiance update finished
        /// </summary>
        public event EventHandler<Allegiance_AllegianceUpdateDone>? OnAllegiance_AllegianceUpdateDone;
    
        /// <summary>
        /// Fired on GameEvent type 0x01C9 Fellowship_FellowUpdateDone. Fellow update is done
        /// </summary>
        public event EventHandler<Fellowship_FellowUpdateDone>? OnFellowship_FellowUpdateDone;
    
        /// <summary>
        /// Fired on GameEvent type 0x01CA Fellowship_FellowStatsDone. Fellow stats are done
        /// </summary>
        public event EventHandler<Fellowship_FellowStatsDone>? OnFellowship_FellowStatsDone;
    
        /// <summary>
        /// Fired on GameEvent type 0x01CB Item_AppraiseDone. Close Assess Panel
        /// </summary>
        public event EventHandler<Item_AppraiseDone>? OnItem_AppraiseDone;
    
        /// <summary>
        /// Fired on GameEvent type 0x01EA Character_ReturnPing. Ping Reply
        /// </summary>
        public event EventHandler<Character_ReturnPing>? OnCharacter_ReturnPing;
    
        /// <summary>
        /// Fired on GameEvent type 0x01F4 Communication_SetSquelchDB. Squelch and Filter List
        /// </summary>
        public event EventHandler<Communication_SetSquelchDB>? OnCommunication_SetSquelchDB;
    
        /// <summary>
        /// Fired on GameEvent type 0x01FD Trade_RegisterTrade. RegisterTrade: Send to begin a trade and display the trade window
        /// </summary>
        public event EventHandler<Trade_RegisterTrade>? OnTrade_RegisterTrade;
    
        /// <summary>
        /// Fired on GameEvent type 0x01FE Trade_OpenTrade. OpenTrade: Open trade window
        /// </summary>
        public event EventHandler<Trade_OpenTrade>? OnTrade_OpenTrade;
    
        /// <summary>
        /// Fired on GameEvent type 0x01FF Trade_CloseTrade. CloseTrade: End trading
        /// </summary>
        public event EventHandler<Trade_CloseTrade>? OnTrade_CloseTrade;
    
        /// <summary>
        /// Fired on GameEvent type 0x0200 Trade_AddToTrade. RemoveFromTrade: Item was removed from trade window
        /// </summary>
        public event EventHandler<Trade_AddToTrade>? OnTrade_AddToTrade;
    
        /// <summary>
        /// Fired on GameEvent type 0x0201 Trade_RemoveFromTrade. Removes an item from the trade window, not sure if this is used still?
        /// </summary>
        public event EventHandler<Trade_RemoveFromTrade>? OnTrade_RemoveFromTrade;
    
        /// <summary>
        /// Fired on GameEvent type 0x0202 Trade_AcceptTrade. AcceptTrade: The trade was accepted
        /// </summary>
        public event EventHandler<Trade_AcceptTrade>? OnTrade_AcceptTrade;
    
        /// <summary>
        /// Fired on GameEvent type 0x0203 Trade_DeclineTrade. DeclineTrade: The trade was declined
        /// </summary>
        public event EventHandler<Trade_DeclineTrade>? OnTrade_DeclineTrade;
    
        /// <summary>
        /// Fired on GameEvent type 0x0205 Trade_ResetTrade. ResetTrade: The trade window was reset
        /// </summary>
        public event EventHandler<Trade_ResetTrade>? OnTrade_ResetTrade;
    
        /// <summary>
        /// Fired on GameEvent type 0x0207 Trade_TradeFailure. TradeFailure: Failure to add a trade item
        /// </summary>
        public event EventHandler<Trade_TradeFailure>? OnTrade_TradeFailure;
    
        /// <summary>
        /// Fired on GameEvent type 0x0208 Trade_ClearTradeAcceptance. ClearTradeAcceptance: Failure to complete a trade
        /// </summary>
        public event EventHandler<Trade_ClearTradeAcceptance>? OnTrade_ClearTradeAcceptance;
    
        /// <summary>
        /// Fired on GameEvent type 0x021D House_HouseProfile. Buy a dwelling or pay maintenance
        /// </summary>
        public event EventHandler<House_HouseProfile>? OnHouse_HouseProfile;
    
        /// <summary>
        /// Fired on GameEvent type 0x0225 House_HouseData. House panel information for owners.
        /// </summary>
        public event EventHandler<House_HouseData>? OnHouse_HouseData;
    
        /// <summary>
        /// Fired on GameEvent type 0x0226 House_HouseStatus. House Data
        /// </summary>
        public event EventHandler<House_HouseStatus>? OnHouse_HouseStatus;
    
        /// <summary>
        /// Fired on GameEvent type 0x0227 House_UpdateRentTime. Update Rent Time
        /// </summary>
        public event EventHandler<House_UpdateRentTime>? OnHouse_UpdateRentTime;
    
        /// <summary>
        /// Fired on GameEvent type 0x0228 House_UpdateRentPayment. Update Rent Payment
        /// </summary>
        public event EventHandler<House_UpdateRentPayment>? OnHouse_UpdateRentPayment;
    
        /// <summary>
        /// Fired on GameEvent type 0x0248 House_UpdateRestrictions. Update Restrictions
        /// </summary>
        public event EventHandler<House_UpdateRestrictions>? OnHouse_UpdateRestrictions;
    
        /// <summary>
        /// Fired on GameEvent type 0x0257 House_UpdateHAR. House Guest List
        /// </summary>
        public event EventHandler<House_UpdateHAR>? OnHouse_UpdateHAR;
    
        /// <summary>
        /// Fired on GameEvent type 0x0259 House_HouseTransaction. House Profile
        /// </summary>
        public event EventHandler<House_HouseTransaction>? OnHouse_HouseTransaction;
    
        /// <summary>
        /// Fired on GameEvent type 0x0264 Item_QueryItemManaResponse. Update an item's mana bar.
        /// </summary>
        public event EventHandler<Item_QueryItemManaResponse>? OnItem_QueryItemManaResponse;
    
        /// <summary>
        /// Fired on GameEvent type 0x0271 House_AvailableHouses. Display a list of available dwellings in the chat window.
        /// </summary>
        public event EventHandler<House_AvailableHouses>? OnHouse_AvailableHouses;
    
        /// <summary>
        /// Fired on GameEvent type 0x0274 Character_ConfirmationRequest. Display a confirmation panel.
        /// </summary>
        public event EventHandler<Character_ConfirmationRequest>? OnCharacter_ConfirmationRequest;
    
        /// <summary>
        /// Fired on GameEvent type 0x0276 Character_ConfirmationDone. Confirmation done
        /// </summary>
        public event EventHandler<Character_ConfirmationDone>? OnCharacter_ConfirmationDone;
    
        /// <summary>
        /// Fired on GameEvent type 0x027A Allegiance_AllegianceLoginNotificationEvent. Display an allegiance login/logout message in the chat window.
        /// </summary>
        public event EventHandler<Allegiance_AllegianceLoginNotificationEvent>? OnAllegiance_AllegianceLoginNotificationEvent;
    
        /// <summary>
        /// Fired on GameEvent type 0x027C Allegiance_AllegianceInfoResponseEvent. Returns data for a player's allegiance information
        /// </summary>
        public event EventHandler<Allegiance_AllegianceInfoResponseEvent>? OnAllegiance_AllegianceInfoResponseEvent;
    
        /// <summary>
        /// Fired on GameEvent type 0x0281 Game_JoinGameResponse. Joining game response
        /// </summary>
        public event EventHandler<Game_JoinGameResponse>? OnGame_JoinGameResponse;
    
        /// <summary>
        /// Fired on GameEvent type 0x0282 Game_StartGame. Start game
        /// </summary>
        public event EventHandler<Game_StartGame>? OnGame_StartGame;
    
        /// <summary>
        /// Fired on GameEvent type 0x0283 Game_MoveResponse. Move response
        /// </summary>
        public event EventHandler<Game_MoveResponse>? OnGame_MoveResponse;
    
        /// <summary>
        /// Fired on GameEvent type 0x0284 Game_OpponentTurn. Opponent Turn
        /// </summary>
        public event EventHandler<Game_OpponentTurn>? OnGame_OpponentTurn;
    
        /// <summary>
        /// Fired on GameEvent type 0x0285 Game_OpponentStalemateState. Opponent Stalemate State
        /// </summary>
        public event EventHandler<Game_OpponentStalemateState>? OnGame_OpponentStalemateState;
    
        /// <summary>
        /// Fired on GameEvent type 0x028A Communication_WeenieError. Display a status message in the chat window.
        /// </summary>
        public event EventHandler<Communication_WeenieError>? OnCommunication_WeenieError;
    
        /// <summary>
        /// Fired on GameEvent type 0x028B Communication_WeenieErrorWithString. Display a parameterized status message in the chat window.
        /// </summary>
        public event EventHandler<Communication_WeenieErrorWithString>? OnCommunication_WeenieErrorWithString;
    
        /// <summary>
        /// Fired on GameEvent type 0x028C Game_GameOver. End of Chess game
        /// </summary>
        public event EventHandler<Game_GameOver>? OnGame_GameOver;
    
        /// <summary>
        /// Fired on GameEvent type 0x0295 Communication_ChatRoomTracker. Set Turbine Chat channel numbers.
        /// </summary>
        public event EventHandler<Communication_ChatRoomTracker>? OnCommunication_ChatRoomTracker;
    
        /// <summary>
        /// Fired on GameEvent type 0x02AE Admin_QueryPluginList. TODO: QueryPluginList
        /// </summary>
        public event EventHandler<Admin_QueryPluginList>? OnAdmin_QueryPluginList;
    
        /// <summary>
        /// Fired on GameEvent type 0x02B1 Admin_QueryPlugin. TODO: QueryPlugin
        /// </summary>
        public event EventHandler<Admin_QueryPlugin>? OnAdmin_QueryPlugin;
    
        /// <summary>
        /// Fired on GameEvent type 0x02B3 Admin_QueryPluginResponse2. TODO: QueryPluginResponse
        /// </summary>
        public event EventHandler<Admin_QueryPluginResponse2>? OnAdmin_QueryPluginResponse2;
    
        /// <summary>
        /// Fired on GameEvent type 0x02B4 Inventory_SalvageOperationsResultData. Salvage operation results
        /// </summary>
        public event EventHandler<Inventory_SalvageOperationsResultData>? OnInventory_SalvageOperationsResultData;
    
        /// <summary>
        /// Fired on GameEvent type 0x02BD Communication_HearDirectSpeech. Someone has sent you a @tell.
        /// </summary>
        public event EventHandler<Communication_HearDirectSpeech>? OnCommunication_HearDirectSpeech;
    
        /// <summary>
        /// Fired on GameEvent type 0x02BE Fellowship_FullUpdate. Create or join a fellowship
        /// </summary>
        public event EventHandler<Fellowship_FullUpdate>? OnFellowship_FullUpdate;
    
        /// <summary>
        /// Fired on GameEvent type 0x02BF Fellowship_Disband. Disband your fellowship.
        /// </summary>
        public event EventHandler<Fellowship_Disband>? OnFellowship_Disband;
    
        /// <summary>
        /// Fired on GameEvent type 0x02C0 Fellowship_UpdateFellow. Add/Update a member to your fellowship.
        /// </summary>
        public event EventHandler<Fellowship_UpdateFellow>? OnFellowship_UpdateFellow;
    
        /// <summary>
        /// Fired on GameEvent type 0x02C1 Magic_UpdateSpell. Add a spell to your spellbook.
        /// </summary>
        public event EventHandler<Magic_UpdateSpell>? OnMagic_UpdateSpell;
    
        /// <summary>
        /// Fired on GameEvent type 0x02C2 Magic_UpdateEnchantment. Apply an enchantment to your character.
        /// </summary>
        public event EventHandler<Magic_UpdateEnchantment>? OnMagic_UpdateEnchantment;
    
        /// <summary>
        /// Fired on GameEvent type 0x02C3 Magic_RemoveEnchantment. Remove an enchantment from your character.
        /// </summary>
        public event EventHandler<Magic_RemoveEnchantment>? OnMagic_RemoveEnchantment;
    
        /// <summary>
        /// Fired on GameEvent type 0x02C4 Magic_UpdateMultipleEnchantments. Update multiple enchantments from your character.
        /// </summary>
        public event EventHandler<Magic_UpdateMultipleEnchantments>? OnMagic_UpdateMultipleEnchantments;
    
        /// <summary>
        /// Fired on GameEvent type 0x02C5 Magic_RemoveMultipleEnchantments. Remove multiple enchantments from your character.
        /// </summary>
        public event EventHandler<Magic_RemoveMultipleEnchantments>? OnMagic_RemoveMultipleEnchantments;
    
        /// <summary>
        /// Fired on GameEvent type 0x02C6 Magic_PurgeEnchantments. Silently remove all enchantments from your character, e.g. when you die (no message in the chat window).
        /// </summary>
        public event EventHandler<Magic_PurgeEnchantments>? OnMagic_PurgeEnchantments;
    
        /// <summary>
        /// Fired on GameEvent type 0x02C7 Magic_DispelEnchantment. Silently remove An enchantment from your character.
        /// </summary>
        public event EventHandler<Magic_DispelEnchantment>? OnMagic_DispelEnchantment;
    
        /// <summary>
        /// Fired on GameEvent type 0x02C8 Magic_DispelMultipleEnchantments. Silently remove multiple enchantments from your character (no message in the chat window).
        /// </summary>
        public event EventHandler<Magic_DispelMultipleEnchantments>? OnMagic_DispelMultipleEnchantments;
    
        /// <summary>
        /// Fired on GameEvent type 0x02C9 Misc_PortalStormBrewing. A portal storm is brewing.
        /// </summary>
        public event EventHandler<Misc_PortalStormBrewing>? OnMisc_PortalStormBrewing;
    
        /// <summary>
        /// Fired on GameEvent type 0x02CA Misc_PortalStormImminent. A portal storm is imminent.
        /// </summary>
        public event EventHandler<Misc_PortalStormImminent>? OnMisc_PortalStormImminent;
    
        /// <summary>
        /// Fired on GameEvent type 0x02CB Misc_PortalStorm. You have been portal stormed.
        /// </summary>
        public event EventHandler<Misc_PortalStorm>? OnMisc_PortalStorm;
    
        /// <summary>
        /// Fired on GameEvent type 0x02CC Misc_PortalStormSubsided. The portal storm has subsided.
        /// </summary>
        public event EventHandler<Misc_PortalStormSubsided>? OnMisc_PortalStormSubsided;
    
        /// <summary>
        /// Fired on GameEvent type 0x02EB Communication_TransientString. Display a status message on the Action Viewscreen (the red text overlaid on the 3D area).
        /// </summary>
        public event EventHandler<Communication_TransientString>? OnCommunication_TransientString;
    
        /// <summary>
        /// Fired on GameEvent type 0x0312 Magic_PurgeBadEnchantments. Remove all bad enchantments from your character.
        /// </summary>
        public event EventHandler<Magic_PurgeBadEnchantments>? OnMagic_PurgeBadEnchantments;
    
        /// <summary>
        /// Fired on GameEvent type 0x0314 Social_SendClientContractTrackerTable. Sends all contract data
        /// </summary>
        public event EventHandler<Social_SendClientContractTrackerTable>? OnSocial_SendClientContractTrackerTable;
    
        /// <summary>
        /// Fired on GameEvent type 0x0315 Social_SendClientContractTracker. Updates a contract data
        /// </summary>
        public event EventHandler<Social_SendClientContractTracker>? OnSocial_SendClientContractTracker;
    
        public ACS2CMessage? ProcessS2CMessage(BinaryReader reader) {
            var opcode = (S2CMessageType)reader.ReadUInt32();
    
            switch (opcode) {
                case (S2CMessageType)0xF7B0: // Value indicating this message has a sequencing header
                    var _objectId = reader.ReadUInt32(); // Current unused
                    var _sequence = reader.ReadUInt32(); // Currently unused
                    var eventType = (GameEventType)reader.ReadUInt32();
                    reader.BaseStream.Position -= sizeof(uint) * 3;
                    switch(eventType) {
                        case GameEventType.Allegiance_AllegianceUpdateAborted:
                            var data_Allegiance_AllegianceUpdateAborted = new Allegiance_AllegianceUpdateAborted();
                            data_Allegiance_AllegianceUpdateAborted.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Allegiance_AllegianceUpdateAborted));
                            OnOrdered_GameEvent?.Invoke(this,  data_Allegiance_AllegianceUpdateAborted);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Allegiance_AllegianceUpdateAborted));
                            OnAllegiance_AllegianceUpdateAborted?.Invoke(this, data_Allegiance_AllegianceUpdateAborted);
                            return data_Allegiance_AllegianceUpdateAborted;
        
                        case GameEventType.Communication_PopUpString:
                            var data_Communication_PopUpString = new Communication_PopUpString();
                            data_Communication_PopUpString.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_PopUpString));
                            OnOrdered_GameEvent?.Invoke(this,  data_Communication_PopUpString);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Communication_PopUpString));
                            OnCommunication_PopUpString?.Invoke(this, data_Communication_PopUpString);
                            return data_Communication_PopUpString;
        
                        case GameEventType.Login_PlayerDescription:
                            var data_Login_PlayerDescription = new Login_PlayerDescription();
                            data_Login_PlayerDescription.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Login_PlayerDescription));
                            OnOrdered_GameEvent?.Invoke(this,  data_Login_PlayerDescription);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Login_PlayerDescription));
                            OnLogin_PlayerDescription?.Invoke(this, data_Login_PlayerDescription);
                            return data_Login_PlayerDescription;
        
                        case GameEventType.Allegiance_AllegianceUpdate:
                            var data_Allegiance_AllegianceUpdate = new Allegiance_AllegianceUpdate();
                            data_Allegiance_AllegianceUpdate.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Allegiance_AllegianceUpdate));
                            OnOrdered_GameEvent?.Invoke(this,  data_Allegiance_AllegianceUpdate);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Allegiance_AllegianceUpdate));
                            OnAllegiance_AllegianceUpdate?.Invoke(this, data_Allegiance_AllegianceUpdate);
                            return data_Allegiance_AllegianceUpdate;
        
                        case GameEventType.Social_FriendsUpdate:
                            var data_Social_FriendsUpdate = new Social_FriendsUpdate();
                            data_Social_FriendsUpdate.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Social_FriendsUpdate));
                            OnOrdered_GameEvent?.Invoke(this,  data_Social_FriendsUpdate);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Social_FriendsUpdate));
                            OnSocial_FriendsUpdate?.Invoke(this, data_Social_FriendsUpdate);
                            return data_Social_FriendsUpdate;
        
                        case GameEventType.Item_ServerSaysContainId:
                            var data_Item_ServerSaysContainId = new Item_ServerSaysContainId();
                            data_Item_ServerSaysContainId.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_ServerSaysContainId));
                            OnOrdered_GameEvent?.Invoke(this,  data_Item_ServerSaysContainId);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Item_ServerSaysContainId));
                            OnItem_ServerSaysContainId?.Invoke(this, data_Item_ServerSaysContainId);
                            return data_Item_ServerSaysContainId;
        
                        case GameEventType.Item_WearItem:
                            var data_Item_WearItem = new Item_WearItem();
                            data_Item_WearItem.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_WearItem));
                            OnOrdered_GameEvent?.Invoke(this,  data_Item_WearItem);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Item_WearItem));
                            OnItem_WearItem?.Invoke(this, data_Item_WearItem);
                            return data_Item_WearItem;
        
                        case GameEventType.Social_CharacterTitleTable:
                            var data_Social_CharacterTitleTable = new Social_CharacterTitleTable();
                            data_Social_CharacterTitleTable.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Social_CharacterTitleTable));
                            OnOrdered_GameEvent?.Invoke(this,  data_Social_CharacterTitleTable);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Social_CharacterTitleTable));
                            OnSocial_CharacterTitleTable?.Invoke(this, data_Social_CharacterTitleTable);
                            return data_Social_CharacterTitleTable;
        
                        case GameEventType.Social_AddOrSetCharacterTitle:
                            var data_Social_AddOrSetCharacterTitle = new Social_AddOrSetCharacterTitle();
                            data_Social_AddOrSetCharacterTitle.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Social_AddOrSetCharacterTitle));
                            OnOrdered_GameEvent?.Invoke(this,  data_Social_AddOrSetCharacterTitle);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Social_AddOrSetCharacterTitle));
                            OnSocial_AddOrSetCharacterTitle?.Invoke(this, data_Social_AddOrSetCharacterTitle);
                            return data_Social_AddOrSetCharacterTitle;
        
                        case GameEventType.Item_StopViewingObjectContents:
                            var data_Item_StopViewingObjectContents = new Item_StopViewingObjectContents();
                            data_Item_StopViewingObjectContents.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_StopViewingObjectContents));
                            OnOrdered_GameEvent?.Invoke(this,  data_Item_StopViewingObjectContents);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Item_StopViewingObjectContents));
                            OnItem_StopViewingObjectContents?.Invoke(this, data_Item_StopViewingObjectContents);
                            return data_Item_StopViewingObjectContents;
        
                        case GameEventType.Vendor_VendorInfo:
                            var data_Vendor_VendorInfo = new Vendor_VendorInfo();
                            data_Vendor_VendorInfo.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Vendor_VendorInfo));
                            OnOrdered_GameEvent?.Invoke(this,  data_Vendor_VendorInfo);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Vendor_VendorInfo));
                            OnVendor_VendorInfo?.Invoke(this, data_Vendor_VendorInfo);
                            return data_Vendor_VendorInfo;
        
                        case GameEventType.Character_StartBarber:
                            var data_Character_StartBarber = new Character_StartBarber();
                            data_Character_StartBarber.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Character_StartBarber));
                            OnOrdered_GameEvent?.Invoke(this,  data_Character_StartBarber);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Character_StartBarber));
                            OnCharacter_StartBarber?.Invoke(this, data_Character_StartBarber);
                            return data_Character_StartBarber;
        
                        case GameEventType.Fellowship_Quit:
                            var data_Fellowship_Quit = new Fellowship_Quit();
                            data_Fellowship_Quit.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Fellowship_Quit));
                            OnOrdered_GameEvent?.Invoke(this,  data_Fellowship_Quit);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Fellowship_Quit));
                            OnFellowship_Quit?.Invoke(this, data_Fellowship_Quit);
                            return data_Fellowship_Quit;
        
                        case GameEventType.Fellowship_Dismiss:
                            var data_Fellowship_Dismiss = new Fellowship_Dismiss();
                            data_Fellowship_Dismiss.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Fellowship_Dismiss));
                            OnOrdered_GameEvent?.Invoke(this,  data_Fellowship_Dismiss);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Fellowship_Dismiss));
                            OnFellowship_Dismiss?.Invoke(this, data_Fellowship_Dismiss);
                            return data_Fellowship_Dismiss;
        
                        case GameEventType.Writing_BookOpen:
                            var data_Writing_BookOpen = new Writing_BookOpen();
                            data_Writing_BookOpen.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Writing_BookOpen));
                            OnOrdered_GameEvent?.Invoke(this,  data_Writing_BookOpen);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Writing_BookOpen));
                            OnWriting_BookOpen?.Invoke(this, data_Writing_BookOpen);
                            return data_Writing_BookOpen;
        
                        case GameEventType.Writing_BookAddPageResponse:
                            var data_Writing_BookAddPageResponse = new Writing_BookAddPageResponse();
                            data_Writing_BookAddPageResponse.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Writing_BookAddPageResponse));
                            OnOrdered_GameEvent?.Invoke(this,  data_Writing_BookAddPageResponse);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Writing_BookAddPageResponse));
                            OnWriting_BookAddPageResponse?.Invoke(this, data_Writing_BookAddPageResponse);
                            return data_Writing_BookAddPageResponse;
        
                        case GameEventType.Writing_BookDeletePageResponse:
                            var data_Writing_BookDeletePageResponse = new Writing_BookDeletePageResponse();
                            data_Writing_BookDeletePageResponse.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Writing_BookDeletePageResponse));
                            OnOrdered_GameEvent?.Invoke(this,  data_Writing_BookDeletePageResponse);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Writing_BookDeletePageResponse));
                            OnWriting_BookDeletePageResponse?.Invoke(this, data_Writing_BookDeletePageResponse);
                            return data_Writing_BookDeletePageResponse;
        
                        case GameEventType.Writing_BookPageDataResponse:
                            var data_Writing_BookPageDataResponse = new Writing_BookPageDataResponse();
                            data_Writing_BookPageDataResponse.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Writing_BookPageDataResponse));
                            OnOrdered_GameEvent?.Invoke(this,  data_Writing_BookPageDataResponse);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Writing_BookPageDataResponse));
                            OnWriting_BookPageDataResponse?.Invoke(this, data_Writing_BookPageDataResponse);
                            return data_Writing_BookPageDataResponse;
        
                        case GameEventType.Item_GetInscriptionResponse:
                            var data_Item_GetInscriptionResponse = new Item_GetInscriptionResponse();
                            data_Item_GetInscriptionResponse.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_GetInscriptionResponse));
                            OnOrdered_GameEvent?.Invoke(this,  data_Item_GetInscriptionResponse);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Item_GetInscriptionResponse));
                            OnItem_GetInscriptionResponse?.Invoke(this, data_Item_GetInscriptionResponse);
                            return data_Item_GetInscriptionResponse;
        
                        case GameEventType.Item_SetAppraiseInfo:
                            var data_Item_SetAppraiseInfo = new Item_SetAppraiseInfo();
                            data_Item_SetAppraiseInfo.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_SetAppraiseInfo));
                            OnOrdered_GameEvent?.Invoke(this,  data_Item_SetAppraiseInfo);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Item_SetAppraiseInfo));
                            OnItem_SetAppraiseInfo?.Invoke(this, data_Item_SetAppraiseInfo);
                            return data_Item_SetAppraiseInfo;
        
                        case GameEventType.Communication_ChannelBroadcast:
                            var data_Communication_ChannelBroadcast = new Communication_ChannelBroadcast();
                            data_Communication_ChannelBroadcast.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_ChannelBroadcast));
                            OnOrdered_GameEvent?.Invoke(this,  data_Communication_ChannelBroadcast);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Communication_ChannelBroadcast));
                            OnCommunication_ChannelBroadcast?.Invoke(this, data_Communication_ChannelBroadcast);
                            return data_Communication_ChannelBroadcast;
        
                        case GameEventType.Communication_ChannelList:
                            var data_Communication_ChannelList = new Communication_ChannelList();
                            data_Communication_ChannelList.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_ChannelList));
                            OnOrdered_GameEvent?.Invoke(this,  data_Communication_ChannelList);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Communication_ChannelList));
                            OnCommunication_ChannelList?.Invoke(this, data_Communication_ChannelList);
                            return data_Communication_ChannelList;
        
                        case GameEventType.Communication_ChannelIndex:
                            var data_Communication_ChannelIndex = new Communication_ChannelIndex();
                            data_Communication_ChannelIndex.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_ChannelIndex));
                            OnOrdered_GameEvent?.Invoke(this,  data_Communication_ChannelIndex);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Communication_ChannelIndex));
                            OnCommunication_ChannelIndex?.Invoke(this, data_Communication_ChannelIndex);
                            return data_Communication_ChannelIndex;
        
                        case GameEventType.Item_OnViewContents:
                            var data_Item_OnViewContents = new Item_OnViewContents();
                            data_Item_OnViewContents.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_OnViewContents));
                            OnOrdered_GameEvent?.Invoke(this,  data_Item_OnViewContents);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Item_OnViewContents));
                            OnItem_OnViewContents?.Invoke(this, data_Item_OnViewContents);
                            return data_Item_OnViewContents;
        
                        case GameEventType.Item_ServerSaysMoveItem:
                            var data_Item_ServerSaysMoveItem = new Item_ServerSaysMoveItem();
                            data_Item_ServerSaysMoveItem.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_ServerSaysMoveItem));
                            OnOrdered_GameEvent?.Invoke(this,  data_Item_ServerSaysMoveItem);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Item_ServerSaysMoveItem));
                            OnItem_ServerSaysMoveItem?.Invoke(this, data_Item_ServerSaysMoveItem);
                            return data_Item_ServerSaysMoveItem;
        
                        case GameEventType.Combat_HandleAttackDoneEvent:
                            var data_Combat_HandleAttackDoneEvent = new Combat_HandleAttackDoneEvent();
                            data_Combat_HandleAttackDoneEvent.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Combat_HandleAttackDoneEvent));
                            OnOrdered_GameEvent?.Invoke(this,  data_Combat_HandleAttackDoneEvent);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Combat_HandleAttackDoneEvent));
                            OnCombat_HandleAttackDoneEvent?.Invoke(this, data_Combat_HandleAttackDoneEvent);
                            return data_Combat_HandleAttackDoneEvent;
        
                        case GameEventType.Magic_RemoveSpell:
                            var data_Magic_RemoveSpell = new Magic_RemoveSpell();
                            data_Magic_RemoveSpell.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Magic_RemoveSpell));
                            OnOrdered_GameEvent?.Invoke(this,  data_Magic_RemoveSpell);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Magic_RemoveSpell));
                            OnMagic_RemoveSpell?.Invoke(this, data_Magic_RemoveSpell);
                            return data_Magic_RemoveSpell;
        
                        case GameEventType.Combat_HandleVictimNotificationEventSelf:
                            var data_Combat_HandleVictimNotificationEventSelf = new Combat_HandleVictimNotificationEventSelf();
                            data_Combat_HandleVictimNotificationEventSelf.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Combat_HandleVictimNotificationEventSelf));
                            OnOrdered_GameEvent?.Invoke(this,  data_Combat_HandleVictimNotificationEventSelf);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Combat_HandleVictimNotificationEventSelf));
                            OnCombat_HandleVictimNotificationEventSelf?.Invoke(this, data_Combat_HandleVictimNotificationEventSelf);
                            return data_Combat_HandleVictimNotificationEventSelf;
        
                        case GameEventType.Combat_HandleVictimNotificationEventOther:
                            var data_Combat_HandleVictimNotificationEventOther = new Combat_HandleVictimNotificationEventOther();
                            data_Combat_HandleVictimNotificationEventOther.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Combat_HandleVictimNotificationEventOther));
                            OnOrdered_GameEvent?.Invoke(this,  data_Combat_HandleVictimNotificationEventOther);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Combat_HandleVictimNotificationEventOther));
                            OnCombat_HandleVictimNotificationEventOther?.Invoke(this, data_Combat_HandleVictimNotificationEventOther);
                            return data_Combat_HandleVictimNotificationEventOther;
        
                        case GameEventType.Combat_HandleAttackerNotificationEvent:
                            var data_Combat_HandleAttackerNotificationEvent = new Combat_HandleAttackerNotificationEvent();
                            data_Combat_HandleAttackerNotificationEvent.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Combat_HandleAttackerNotificationEvent));
                            OnOrdered_GameEvent?.Invoke(this,  data_Combat_HandleAttackerNotificationEvent);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Combat_HandleAttackerNotificationEvent));
                            OnCombat_HandleAttackerNotificationEvent?.Invoke(this, data_Combat_HandleAttackerNotificationEvent);
                            return data_Combat_HandleAttackerNotificationEvent;
        
                        case GameEventType.Combat_HandleDefenderNotificationEvent:
                            var data_Combat_HandleDefenderNotificationEvent = new Combat_HandleDefenderNotificationEvent();
                            data_Combat_HandleDefenderNotificationEvent.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Combat_HandleDefenderNotificationEvent));
                            OnOrdered_GameEvent?.Invoke(this,  data_Combat_HandleDefenderNotificationEvent);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Combat_HandleDefenderNotificationEvent));
                            OnCombat_HandleDefenderNotificationEvent?.Invoke(this, data_Combat_HandleDefenderNotificationEvent);
                            return data_Combat_HandleDefenderNotificationEvent;
        
                        case GameEventType.Combat_HandleEvasionAttackerNotificationEvent:
                            var data_Combat_HandleEvasionAttackerNotificationEvent = new Combat_HandleEvasionAttackerNotificationEvent();
                            data_Combat_HandleEvasionAttackerNotificationEvent.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Combat_HandleEvasionAttackerNotificationEvent));
                            OnOrdered_GameEvent?.Invoke(this,  data_Combat_HandleEvasionAttackerNotificationEvent);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Combat_HandleEvasionAttackerNotificationEvent));
                            OnCombat_HandleEvasionAttackerNotificationEvent?.Invoke(this, data_Combat_HandleEvasionAttackerNotificationEvent);
                            return data_Combat_HandleEvasionAttackerNotificationEvent;
        
                        case GameEventType.Combat_HandleEvasionDefenderNotificationEvent:
                            var data_Combat_HandleEvasionDefenderNotificationEvent = new Combat_HandleEvasionDefenderNotificationEvent();
                            data_Combat_HandleEvasionDefenderNotificationEvent.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Combat_HandleEvasionDefenderNotificationEvent));
                            OnOrdered_GameEvent?.Invoke(this,  data_Combat_HandleEvasionDefenderNotificationEvent);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Combat_HandleEvasionDefenderNotificationEvent));
                            OnCombat_HandleEvasionDefenderNotificationEvent?.Invoke(this, data_Combat_HandleEvasionDefenderNotificationEvent);
                            return data_Combat_HandleEvasionDefenderNotificationEvent;
        
                        case GameEventType.Combat_HandleCommenceAttackEvent:
                            var data_Combat_HandleCommenceAttackEvent = new Combat_HandleCommenceAttackEvent();
                            data_Combat_HandleCommenceAttackEvent.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Combat_HandleCommenceAttackEvent));
                            OnOrdered_GameEvent?.Invoke(this,  data_Combat_HandleCommenceAttackEvent);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Combat_HandleCommenceAttackEvent));
                            OnCombat_HandleCommenceAttackEvent?.Invoke(this, data_Combat_HandleCommenceAttackEvent);
                            return data_Combat_HandleCommenceAttackEvent;
        
                        case GameEventType.Combat_QueryHealthResponse:
                            var data_Combat_QueryHealthResponse = new Combat_QueryHealthResponse();
                            data_Combat_QueryHealthResponse.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Combat_QueryHealthResponse));
                            OnOrdered_GameEvent?.Invoke(this,  data_Combat_QueryHealthResponse);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Combat_QueryHealthResponse));
                            OnCombat_QueryHealthResponse?.Invoke(this, data_Combat_QueryHealthResponse);
                            return data_Combat_QueryHealthResponse;
        
                        case GameEventType.Character_QueryAgeResponse:
                            var data_Character_QueryAgeResponse = new Character_QueryAgeResponse();
                            data_Character_QueryAgeResponse.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Character_QueryAgeResponse));
                            OnOrdered_GameEvent?.Invoke(this,  data_Character_QueryAgeResponse);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Character_QueryAgeResponse));
                            OnCharacter_QueryAgeResponse?.Invoke(this, data_Character_QueryAgeResponse);
                            return data_Character_QueryAgeResponse;
        
                        case GameEventType.Item_UseDone:
                            var data_Item_UseDone = new Item_UseDone();
                            data_Item_UseDone.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_UseDone));
                            OnOrdered_GameEvent?.Invoke(this,  data_Item_UseDone);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Item_UseDone));
                            OnItem_UseDone?.Invoke(this, data_Item_UseDone);
                            return data_Item_UseDone;
        
                        case GameEventType.Allegiance_AllegianceUpdateDone:
                            var data_Allegiance_AllegianceUpdateDone = new Allegiance_AllegianceUpdateDone();
                            data_Allegiance_AllegianceUpdateDone.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Allegiance_AllegianceUpdateDone));
                            OnOrdered_GameEvent?.Invoke(this,  data_Allegiance_AllegianceUpdateDone);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Allegiance_AllegianceUpdateDone));
                            OnAllegiance_AllegianceUpdateDone?.Invoke(this, data_Allegiance_AllegianceUpdateDone);
                            return data_Allegiance_AllegianceUpdateDone;
        
                        case GameEventType.Fellowship_FellowUpdateDone:
                            var data_Fellowship_FellowUpdateDone = new Fellowship_FellowUpdateDone();
                            data_Fellowship_FellowUpdateDone.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Fellowship_FellowUpdateDone));
                            OnOrdered_GameEvent?.Invoke(this,  data_Fellowship_FellowUpdateDone);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Fellowship_FellowUpdateDone));
                            OnFellowship_FellowUpdateDone?.Invoke(this, data_Fellowship_FellowUpdateDone);
                            return data_Fellowship_FellowUpdateDone;
        
                        case GameEventType.Fellowship_FellowStatsDone:
                            var data_Fellowship_FellowStatsDone = new Fellowship_FellowStatsDone();
                            data_Fellowship_FellowStatsDone.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Fellowship_FellowStatsDone));
                            OnOrdered_GameEvent?.Invoke(this,  data_Fellowship_FellowStatsDone);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Fellowship_FellowStatsDone));
                            OnFellowship_FellowStatsDone?.Invoke(this, data_Fellowship_FellowStatsDone);
                            return data_Fellowship_FellowStatsDone;
        
                        case GameEventType.Item_AppraiseDone:
                            var data_Item_AppraiseDone = new Item_AppraiseDone();
                            data_Item_AppraiseDone.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_AppraiseDone));
                            OnOrdered_GameEvent?.Invoke(this,  data_Item_AppraiseDone);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Item_AppraiseDone));
                            OnItem_AppraiseDone?.Invoke(this, data_Item_AppraiseDone);
                            return data_Item_AppraiseDone;
        
                        case GameEventType.Character_ReturnPing:
                            var data_Character_ReturnPing = new Character_ReturnPing();
                            data_Character_ReturnPing.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Character_ReturnPing));
                            OnOrdered_GameEvent?.Invoke(this,  data_Character_ReturnPing);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Character_ReturnPing));
                            OnCharacter_ReturnPing?.Invoke(this, data_Character_ReturnPing);
                            return data_Character_ReturnPing;
        
                        case GameEventType.Communication_SetSquelchDB:
                            var data_Communication_SetSquelchDB = new Communication_SetSquelchDB();
                            data_Communication_SetSquelchDB.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_SetSquelchDB));
                            OnOrdered_GameEvent?.Invoke(this,  data_Communication_SetSquelchDB);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Communication_SetSquelchDB));
                            OnCommunication_SetSquelchDB?.Invoke(this, data_Communication_SetSquelchDB);
                            return data_Communication_SetSquelchDB;
        
                        case GameEventType.Trade_RegisterTrade:
                            var data_Trade_RegisterTrade = new Trade_RegisterTrade();
                            data_Trade_RegisterTrade.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Trade_RegisterTrade));
                            OnOrdered_GameEvent?.Invoke(this,  data_Trade_RegisterTrade);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Trade_RegisterTrade));
                            OnTrade_RegisterTrade?.Invoke(this, data_Trade_RegisterTrade);
                            return data_Trade_RegisterTrade;
        
                        case GameEventType.Trade_OpenTrade:
                            var data_Trade_OpenTrade = new Trade_OpenTrade();
                            data_Trade_OpenTrade.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Trade_OpenTrade));
                            OnOrdered_GameEvent?.Invoke(this,  data_Trade_OpenTrade);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Trade_OpenTrade));
                            OnTrade_OpenTrade?.Invoke(this, data_Trade_OpenTrade);
                            return data_Trade_OpenTrade;
        
                        case GameEventType.Trade_CloseTrade:
                            var data_Trade_CloseTrade = new Trade_CloseTrade();
                            data_Trade_CloseTrade.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Trade_CloseTrade));
                            OnOrdered_GameEvent?.Invoke(this,  data_Trade_CloseTrade);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Trade_CloseTrade));
                            OnTrade_CloseTrade?.Invoke(this, data_Trade_CloseTrade);
                            return data_Trade_CloseTrade;
        
                        case GameEventType.Trade_AddToTrade:
                            var data_Trade_AddToTrade = new Trade_AddToTrade();
                            data_Trade_AddToTrade.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Trade_AddToTrade));
                            OnOrdered_GameEvent?.Invoke(this,  data_Trade_AddToTrade);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Trade_AddToTrade));
                            OnTrade_AddToTrade?.Invoke(this, data_Trade_AddToTrade);
                            return data_Trade_AddToTrade;
        
                        case GameEventType.Trade_RemoveFromTrade:
                            var data_Trade_RemoveFromTrade = new Trade_RemoveFromTrade();
                            data_Trade_RemoveFromTrade.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Trade_RemoveFromTrade));
                            OnOrdered_GameEvent?.Invoke(this,  data_Trade_RemoveFromTrade);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Trade_RemoveFromTrade));
                            OnTrade_RemoveFromTrade?.Invoke(this, data_Trade_RemoveFromTrade);
                            return data_Trade_RemoveFromTrade;
        
                        case GameEventType.Trade_AcceptTrade:
                            var data_Trade_AcceptTrade = new Trade_AcceptTrade();
                            data_Trade_AcceptTrade.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Trade_AcceptTrade));
                            OnOrdered_GameEvent?.Invoke(this,  data_Trade_AcceptTrade);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Trade_AcceptTrade));
                            OnTrade_AcceptTrade?.Invoke(this, data_Trade_AcceptTrade);
                            return data_Trade_AcceptTrade;
        
                        case GameEventType.Trade_DeclineTrade:
                            var data_Trade_DeclineTrade = new Trade_DeclineTrade();
                            data_Trade_DeclineTrade.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Trade_DeclineTrade));
                            OnOrdered_GameEvent?.Invoke(this,  data_Trade_DeclineTrade);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Trade_DeclineTrade));
                            OnTrade_DeclineTrade?.Invoke(this, data_Trade_DeclineTrade);
                            return data_Trade_DeclineTrade;
        
                        case GameEventType.Trade_ResetTrade:
                            var data_Trade_ResetTrade = new Trade_ResetTrade();
                            data_Trade_ResetTrade.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Trade_ResetTrade));
                            OnOrdered_GameEvent?.Invoke(this,  data_Trade_ResetTrade);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Trade_ResetTrade));
                            OnTrade_ResetTrade?.Invoke(this, data_Trade_ResetTrade);
                            return data_Trade_ResetTrade;
        
                        case GameEventType.Trade_TradeFailure:
                            var data_Trade_TradeFailure = new Trade_TradeFailure();
                            data_Trade_TradeFailure.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Trade_TradeFailure));
                            OnOrdered_GameEvent?.Invoke(this,  data_Trade_TradeFailure);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Trade_TradeFailure));
                            OnTrade_TradeFailure?.Invoke(this, data_Trade_TradeFailure);
                            return data_Trade_TradeFailure;
        
                        case GameEventType.Trade_ClearTradeAcceptance:
                            var data_Trade_ClearTradeAcceptance = new Trade_ClearTradeAcceptance();
                            data_Trade_ClearTradeAcceptance.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Trade_ClearTradeAcceptance));
                            OnOrdered_GameEvent?.Invoke(this,  data_Trade_ClearTradeAcceptance);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Trade_ClearTradeAcceptance));
                            OnTrade_ClearTradeAcceptance?.Invoke(this, data_Trade_ClearTradeAcceptance);
                            return data_Trade_ClearTradeAcceptance;
        
                        case GameEventType.House_HouseProfile:
                            var data_House_HouseProfile = new House_HouseProfile();
                            data_House_HouseProfile.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_House_HouseProfile));
                            OnOrdered_GameEvent?.Invoke(this,  data_House_HouseProfile);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_House_HouseProfile));
                            OnHouse_HouseProfile?.Invoke(this, data_House_HouseProfile);
                            return data_House_HouseProfile;
        
                        case GameEventType.House_HouseData:
                            var data_House_HouseData = new House_HouseData();
                            data_House_HouseData.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_House_HouseData));
                            OnOrdered_GameEvent?.Invoke(this,  data_House_HouseData);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_House_HouseData));
                            OnHouse_HouseData?.Invoke(this, data_House_HouseData);
                            return data_House_HouseData;
        
                        case GameEventType.House_HouseStatus:
                            var data_House_HouseStatus = new House_HouseStatus();
                            data_House_HouseStatus.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_House_HouseStatus));
                            OnOrdered_GameEvent?.Invoke(this,  data_House_HouseStatus);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_House_HouseStatus));
                            OnHouse_HouseStatus?.Invoke(this, data_House_HouseStatus);
                            return data_House_HouseStatus;
        
                        case GameEventType.House_UpdateRentTime:
                            var data_House_UpdateRentTime = new House_UpdateRentTime();
                            data_House_UpdateRentTime.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_House_UpdateRentTime));
                            OnOrdered_GameEvent?.Invoke(this,  data_House_UpdateRentTime);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_House_UpdateRentTime));
                            OnHouse_UpdateRentTime?.Invoke(this, data_House_UpdateRentTime);
                            return data_House_UpdateRentTime;
        
                        case GameEventType.House_UpdateRentPayment:
                            var data_House_UpdateRentPayment = new House_UpdateRentPayment();
                            data_House_UpdateRentPayment.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_House_UpdateRentPayment));
                            OnOrdered_GameEvent?.Invoke(this,  data_House_UpdateRentPayment);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_House_UpdateRentPayment));
                            OnHouse_UpdateRentPayment?.Invoke(this, data_House_UpdateRentPayment);
                            return data_House_UpdateRentPayment;
        
                        case GameEventType.House_UpdateRestrictions:
                            var data_House_UpdateRestrictions = new House_UpdateRestrictions();
                            data_House_UpdateRestrictions.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_House_UpdateRestrictions));
                            OnOrdered_GameEvent?.Invoke(this,  data_House_UpdateRestrictions);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_House_UpdateRestrictions));
                            OnHouse_UpdateRestrictions?.Invoke(this, data_House_UpdateRestrictions);
                            return data_House_UpdateRestrictions;
        
                        case GameEventType.House_UpdateHAR:
                            var data_House_UpdateHAR = new House_UpdateHAR();
                            data_House_UpdateHAR.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_House_UpdateHAR));
                            OnOrdered_GameEvent?.Invoke(this,  data_House_UpdateHAR);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_House_UpdateHAR));
                            OnHouse_UpdateHAR?.Invoke(this, data_House_UpdateHAR);
                            return data_House_UpdateHAR;
        
                        case GameEventType.House_HouseTransaction:
                            var data_House_HouseTransaction = new House_HouseTransaction();
                            data_House_HouseTransaction.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_House_HouseTransaction));
                            OnOrdered_GameEvent?.Invoke(this,  data_House_HouseTransaction);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_House_HouseTransaction));
                            OnHouse_HouseTransaction?.Invoke(this, data_House_HouseTransaction);
                            return data_House_HouseTransaction;
        
                        case GameEventType.Item_QueryItemManaResponse:
                            var data_Item_QueryItemManaResponse = new Item_QueryItemManaResponse();
                            data_Item_QueryItemManaResponse.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_QueryItemManaResponse));
                            OnOrdered_GameEvent?.Invoke(this,  data_Item_QueryItemManaResponse);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Item_QueryItemManaResponse));
                            OnItem_QueryItemManaResponse?.Invoke(this, data_Item_QueryItemManaResponse);
                            return data_Item_QueryItemManaResponse;
        
                        case GameEventType.House_AvailableHouses:
                            var data_House_AvailableHouses = new House_AvailableHouses();
                            data_House_AvailableHouses.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_House_AvailableHouses));
                            OnOrdered_GameEvent?.Invoke(this,  data_House_AvailableHouses);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_House_AvailableHouses));
                            OnHouse_AvailableHouses?.Invoke(this, data_House_AvailableHouses);
                            return data_House_AvailableHouses;
        
                        case GameEventType.Character_ConfirmationRequest:
                            var data_Character_ConfirmationRequest = new Character_ConfirmationRequest();
                            data_Character_ConfirmationRequest.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Character_ConfirmationRequest));
                            OnOrdered_GameEvent?.Invoke(this,  data_Character_ConfirmationRequest);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Character_ConfirmationRequest));
                            OnCharacter_ConfirmationRequest?.Invoke(this, data_Character_ConfirmationRequest);
                            return data_Character_ConfirmationRequest;
        
                        case GameEventType.Character_ConfirmationDone:
                            var data_Character_ConfirmationDone = new Character_ConfirmationDone();
                            data_Character_ConfirmationDone.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Character_ConfirmationDone));
                            OnOrdered_GameEvent?.Invoke(this,  data_Character_ConfirmationDone);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Character_ConfirmationDone));
                            OnCharacter_ConfirmationDone?.Invoke(this, data_Character_ConfirmationDone);
                            return data_Character_ConfirmationDone;
        
                        case GameEventType.Allegiance_AllegianceLoginNotificationEvent:
                            var data_Allegiance_AllegianceLoginNotificationEvent = new Allegiance_AllegianceLoginNotificationEvent();
                            data_Allegiance_AllegianceLoginNotificationEvent.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Allegiance_AllegianceLoginNotificationEvent));
                            OnOrdered_GameEvent?.Invoke(this,  data_Allegiance_AllegianceLoginNotificationEvent);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Allegiance_AllegianceLoginNotificationEvent));
                            OnAllegiance_AllegianceLoginNotificationEvent?.Invoke(this, data_Allegiance_AllegianceLoginNotificationEvent);
                            return data_Allegiance_AllegianceLoginNotificationEvent;
        
                        case GameEventType.Allegiance_AllegianceInfoResponseEvent:
                            var data_Allegiance_AllegianceInfoResponseEvent = new Allegiance_AllegianceInfoResponseEvent();
                            data_Allegiance_AllegianceInfoResponseEvent.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Allegiance_AllegianceInfoResponseEvent));
                            OnOrdered_GameEvent?.Invoke(this,  data_Allegiance_AllegianceInfoResponseEvent);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Allegiance_AllegianceInfoResponseEvent));
                            OnAllegiance_AllegianceInfoResponseEvent?.Invoke(this, data_Allegiance_AllegianceInfoResponseEvent);
                            return data_Allegiance_AllegianceInfoResponseEvent;
        
                        case GameEventType.Game_JoinGameResponse:
                            var data_Game_JoinGameResponse = new Game_JoinGameResponse();
                            data_Game_JoinGameResponse.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Game_JoinGameResponse));
                            OnOrdered_GameEvent?.Invoke(this,  data_Game_JoinGameResponse);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Game_JoinGameResponse));
                            OnGame_JoinGameResponse?.Invoke(this, data_Game_JoinGameResponse);
                            return data_Game_JoinGameResponse;
        
                        case GameEventType.Game_StartGame:
                            var data_Game_StartGame = new Game_StartGame();
                            data_Game_StartGame.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Game_StartGame));
                            OnOrdered_GameEvent?.Invoke(this,  data_Game_StartGame);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Game_StartGame));
                            OnGame_StartGame?.Invoke(this, data_Game_StartGame);
                            return data_Game_StartGame;
        
                        case GameEventType.Game_MoveResponse:
                            var data_Game_MoveResponse = new Game_MoveResponse();
                            data_Game_MoveResponse.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Game_MoveResponse));
                            OnOrdered_GameEvent?.Invoke(this,  data_Game_MoveResponse);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Game_MoveResponse));
                            OnGame_MoveResponse?.Invoke(this, data_Game_MoveResponse);
                            return data_Game_MoveResponse;
        
                        case GameEventType.Game_OpponentTurn:
                            var data_Game_OpponentTurn = new Game_OpponentTurn();
                            data_Game_OpponentTurn.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Game_OpponentTurn));
                            OnOrdered_GameEvent?.Invoke(this,  data_Game_OpponentTurn);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Game_OpponentTurn));
                            OnGame_OpponentTurn?.Invoke(this, data_Game_OpponentTurn);
                            return data_Game_OpponentTurn;
        
                        case GameEventType.Game_OpponentStalemateState:
                            var data_Game_OpponentStalemateState = new Game_OpponentStalemateState();
                            data_Game_OpponentStalemateState.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Game_OpponentStalemateState));
                            OnOrdered_GameEvent?.Invoke(this,  data_Game_OpponentStalemateState);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Game_OpponentStalemateState));
                            OnGame_OpponentStalemateState?.Invoke(this, data_Game_OpponentStalemateState);
                            return data_Game_OpponentStalemateState;
        
                        case GameEventType.Communication_WeenieError:
                            var data_Communication_WeenieError = new Communication_WeenieError();
                            data_Communication_WeenieError.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_WeenieError));
                            OnOrdered_GameEvent?.Invoke(this,  data_Communication_WeenieError);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Communication_WeenieError));
                            OnCommunication_WeenieError?.Invoke(this, data_Communication_WeenieError);
                            return data_Communication_WeenieError;
        
                        case GameEventType.Communication_WeenieErrorWithString:
                            var data_Communication_WeenieErrorWithString = new Communication_WeenieErrorWithString();
                            data_Communication_WeenieErrorWithString.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_WeenieErrorWithString));
                            OnOrdered_GameEvent?.Invoke(this,  data_Communication_WeenieErrorWithString);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Communication_WeenieErrorWithString));
                            OnCommunication_WeenieErrorWithString?.Invoke(this, data_Communication_WeenieErrorWithString);
                            return data_Communication_WeenieErrorWithString;
        
                        case GameEventType.Game_GameOver:
                            var data_Game_GameOver = new Game_GameOver();
                            data_Game_GameOver.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Game_GameOver));
                            OnOrdered_GameEvent?.Invoke(this,  data_Game_GameOver);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Game_GameOver));
                            OnGame_GameOver?.Invoke(this, data_Game_GameOver);
                            return data_Game_GameOver;
        
                        case GameEventType.Communication_ChatRoomTracker:
                            var data_Communication_ChatRoomTracker = new Communication_ChatRoomTracker();
                            data_Communication_ChatRoomTracker.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_ChatRoomTracker));
                            OnOrdered_GameEvent?.Invoke(this,  data_Communication_ChatRoomTracker);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Communication_ChatRoomTracker));
                            OnCommunication_ChatRoomTracker?.Invoke(this, data_Communication_ChatRoomTracker);
                            return data_Communication_ChatRoomTracker;
        
                        case GameEventType.Admin_QueryPluginList:
                            var data_Admin_QueryPluginList = new Admin_QueryPluginList();
                            data_Admin_QueryPluginList.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Admin_QueryPluginList));
                            OnOrdered_GameEvent?.Invoke(this,  data_Admin_QueryPluginList);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Admin_QueryPluginList));
                            OnAdmin_QueryPluginList?.Invoke(this, data_Admin_QueryPluginList);
                            return data_Admin_QueryPluginList;
        
                        case GameEventType.Admin_QueryPlugin:
                            var data_Admin_QueryPlugin = new Admin_QueryPlugin();
                            data_Admin_QueryPlugin.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Admin_QueryPlugin));
                            OnOrdered_GameEvent?.Invoke(this,  data_Admin_QueryPlugin);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Admin_QueryPlugin));
                            OnAdmin_QueryPlugin?.Invoke(this, data_Admin_QueryPlugin);
                            return data_Admin_QueryPlugin;
        
                        case GameEventType.Admin_QueryPluginResponse2:
                            var data_Admin_QueryPluginResponse2 = new Admin_QueryPluginResponse2();
                            data_Admin_QueryPluginResponse2.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Admin_QueryPluginResponse2));
                            OnOrdered_GameEvent?.Invoke(this,  data_Admin_QueryPluginResponse2);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Admin_QueryPluginResponse2));
                            OnAdmin_QueryPluginResponse2?.Invoke(this, data_Admin_QueryPluginResponse2);
                            return data_Admin_QueryPluginResponse2;
        
                        case GameEventType.Inventory_SalvageOperationsResultData:
                            var data_Inventory_SalvageOperationsResultData = new Inventory_SalvageOperationsResultData();
                            data_Inventory_SalvageOperationsResultData.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Inventory_SalvageOperationsResultData));
                            OnOrdered_GameEvent?.Invoke(this,  data_Inventory_SalvageOperationsResultData);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Inventory_SalvageOperationsResultData));
                            OnInventory_SalvageOperationsResultData?.Invoke(this, data_Inventory_SalvageOperationsResultData);
                            return data_Inventory_SalvageOperationsResultData;
        
                        case GameEventType.Communication_HearDirectSpeech:
                            var data_Communication_HearDirectSpeech = new Communication_HearDirectSpeech();
                            data_Communication_HearDirectSpeech.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_HearDirectSpeech));
                            OnOrdered_GameEvent?.Invoke(this,  data_Communication_HearDirectSpeech);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Communication_HearDirectSpeech));
                            OnCommunication_HearDirectSpeech?.Invoke(this, data_Communication_HearDirectSpeech);
                            return data_Communication_HearDirectSpeech;
        
                        case GameEventType.Fellowship_FullUpdate:
                            var data_Fellowship_FullUpdate = new Fellowship_FullUpdate();
                            data_Fellowship_FullUpdate.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Fellowship_FullUpdate));
                            OnOrdered_GameEvent?.Invoke(this,  data_Fellowship_FullUpdate);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Fellowship_FullUpdate));
                            OnFellowship_FullUpdate?.Invoke(this, data_Fellowship_FullUpdate);
                            return data_Fellowship_FullUpdate;
        
                        case GameEventType.Fellowship_Disband:
                            var data_Fellowship_Disband = new Fellowship_Disband();
                            data_Fellowship_Disband.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Fellowship_Disband));
                            OnOrdered_GameEvent?.Invoke(this,  data_Fellowship_Disband);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Fellowship_Disband));
                            OnFellowship_Disband?.Invoke(this, data_Fellowship_Disband);
                            return data_Fellowship_Disband;
        
                        case GameEventType.Fellowship_UpdateFellow:
                            var data_Fellowship_UpdateFellow = new Fellowship_UpdateFellow();
                            data_Fellowship_UpdateFellow.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Fellowship_UpdateFellow));
                            OnOrdered_GameEvent?.Invoke(this,  data_Fellowship_UpdateFellow);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Fellowship_UpdateFellow));
                            OnFellowship_UpdateFellow?.Invoke(this, data_Fellowship_UpdateFellow);
                            return data_Fellowship_UpdateFellow;
        
                        case GameEventType.Magic_UpdateSpell:
                            var data_Magic_UpdateSpell = new Magic_UpdateSpell();
                            data_Magic_UpdateSpell.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Magic_UpdateSpell));
                            OnOrdered_GameEvent?.Invoke(this,  data_Magic_UpdateSpell);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Magic_UpdateSpell));
                            OnMagic_UpdateSpell?.Invoke(this, data_Magic_UpdateSpell);
                            return data_Magic_UpdateSpell;
        
                        case GameEventType.Magic_UpdateEnchantment:
                            var data_Magic_UpdateEnchantment = new Magic_UpdateEnchantment();
                            data_Magic_UpdateEnchantment.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Magic_UpdateEnchantment));
                            OnOrdered_GameEvent?.Invoke(this,  data_Magic_UpdateEnchantment);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Magic_UpdateEnchantment));
                            OnMagic_UpdateEnchantment?.Invoke(this, data_Magic_UpdateEnchantment);
                            return data_Magic_UpdateEnchantment;
        
                        case GameEventType.Magic_RemoveEnchantment:
                            var data_Magic_RemoveEnchantment = new Magic_RemoveEnchantment();
                            data_Magic_RemoveEnchantment.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Magic_RemoveEnchantment));
                            OnOrdered_GameEvent?.Invoke(this,  data_Magic_RemoveEnchantment);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Magic_RemoveEnchantment));
                            OnMagic_RemoveEnchantment?.Invoke(this, data_Magic_RemoveEnchantment);
                            return data_Magic_RemoveEnchantment;
        
                        case GameEventType.Magic_UpdateMultipleEnchantments:
                            var data_Magic_UpdateMultipleEnchantments = new Magic_UpdateMultipleEnchantments();
                            data_Magic_UpdateMultipleEnchantments.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Magic_UpdateMultipleEnchantments));
                            OnOrdered_GameEvent?.Invoke(this,  data_Magic_UpdateMultipleEnchantments);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Magic_UpdateMultipleEnchantments));
                            OnMagic_UpdateMultipleEnchantments?.Invoke(this, data_Magic_UpdateMultipleEnchantments);
                            return data_Magic_UpdateMultipleEnchantments;
        
                        case GameEventType.Magic_RemoveMultipleEnchantments:
                            var data_Magic_RemoveMultipleEnchantments = new Magic_RemoveMultipleEnchantments();
                            data_Magic_RemoveMultipleEnchantments.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Magic_RemoveMultipleEnchantments));
                            OnOrdered_GameEvent?.Invoke(this,  data_Magic_RemoveMultipleEnchantments);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Magic_RemoveMultipleEnchantments));
                            OnMagic_RemoveMultipleEnchantments?.Invoke(this, data_Magic_RemoveMultipleEnchantments);
                            return data_Magic_RemoveMultipleEnchantments;
        
                        case GameEventType.Magic_PurgeEnchantments:
                            var data_Magic_PurgeEnchantments = new Magic_PurgeEnchantments();
                            data_Magic_PurgeEnchantments.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Magic_PurgeEnchantments));
                            OnOrdered_GameEvent?.Invoke(this,  data_Magic_PurgeEnchantments);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Magic_PurgeEnchantments));
                            OnMagic_PurgeEnchantments?.Invoke(this, data_Magic_PurgeEnchantments);
                            return data_Magic_PurgeEnchantments;
        
                        case GameEventType.Magic_DispelEnchantment:
                            var data_Magic_DispelEnchantment = new Magic_DispelEnchantment();
                            data_Magic_DispelEnchantment.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Magic_DispelEnchantment));
                            OnOrdered_GameEvent?.Invoke(this,  data_Magic_DispelEnchantment);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Magic_DispelEnchantment));
                            OnMagic_DispelEnchantment?.Invoke(this, data_Magic_DispelEnchantment);
                            return data_Magic_DispelEnchantment;
        
                        case GameEventType.Magic_DispelMultipleEnchantments:
                            var data_Magic_DispelMultipleEnchantments = new Magic_DispelMultipleEnchantments();
                            data_Magic_DispelMultipleEnchantments.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Magic_DispelMultipleEnchantments));
                            OnOrdered_GameEvent?.Invoke(this,  data_Magic_DispelMultipleEnchantments);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Magic_DispelMultipleEnchantments));
                            OnMagic_DispelMultipleEnchantments?.Invoke(this, data_Magic_DispelMultipleEnchantments);
                            return data_Magic_DispelMultipleEnchantments;
        
                        case GameEventType.Misc_PortalStormBrewing:
                            var data_Misc_PortalStormBrewing = new Misc_PortalStormBrewing();
                            data_Misc_PortalStormBrewing.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Misc_PortalStormBrewing));
                            OnOrdered_GameEvent?.Invoke(this,  data_Misc_PortalStormBrewing);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Misc_PortalStormBrewing));
                            OnMisc_PortalStormBrewing?.Invoke(this, data_Misc_PortalStormBrewing);
                            return data_Misc_PortalStormBrewing;
        
                        case GameEventType.Misc_PortalStormImminent:
                            var data_Misc_PortalStormImminent = new Misc_PortalStormImminent();
                            data_Misc_PortalStormImminent.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Misc_PortalStormImminent));
                            OnOrdered_GameEvent?.Invoke(this,  data_Misc_PortalStormImminent);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Misc_PortalStormImminent));
                            OnMisc_PortalStormImminent?.Invoke(this, data_Misc_PortalStormImminent);
                            return data_Misc_PortalStormImminent;
        
                        case GameEventType.Misc_PortalStorm:
                            var data_Misc_PortalStorm = new Misc_PortalStorm();
                            data_Misc_PortalStorm.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Misc_PortalStorm));
                            OnOrdered_GameEvent?.Invoke(this,  data_Misc_PortalStorm);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Misc_PortalStorm));
                            OnMisc_PortalStorm?.Invoke(this, data_Misc_PortalStorm);
                            return data_Misc_PortalStorm;
        
                        case GameEventType.Misc_PortalStormSubsided:
                            var data_Misc_PortalStormSubsided = new Misc_PortalStormSubsided();
                            data_Misc_PortalStormSubsided.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Misc_PortalStormSubsided));
                            OnOrdered_GameEvent?.Invoke(this,  data_Misc_PortalStormSubsided);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Misc_PortalStormSubsided));
                            OnMisc_PortalStormSubsided?.Invoke(this, data_Misc_PortalStormSubsided);
                            return data_Misc_PortalStormSubsided;
        
                        case GameEventType.Communication_TransientString:
                            var data_Communication_TransientString = new Communication_TransientString();
                            data_Communication_TransientString.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_TransientString));
                            OnOrdered_GameEvent?.Invoke(this,  data_Communication_TransientString);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Communication_TransientString));
                            OnCommunication_TransientString?.Invoke(this, data_Communication_TransientString);
                            return data_Communication_TransientString;
        
                        case GameEventType.Magic_PurgeBadEnchantments:
                            var data_Magic_PurgeBadEnchantments = new Magic_PurgeBadEnchantments();
                            data_Magic_PurgeBadEnchantments.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Magic_PurgeBadEnchantments));
                            OnOrdered_GameEvent?.Invoke(this,  data_Magic_PurgeBadEnchantments);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Magic_PurgeBadEnchantments));
                            OnMagic_PurgeBadEnchantments?.Invoke(this, data_Magic_PurgeBadEnchantments);
                            return data_Magic_PurgeBadEnchantments;
        
                        case GameEventType.Social_SendClientContractTrackerTable:
                            var data_Social_SendClientContractTrackerTable = new Social_SendClientContractTrackerTable();
                            data_Social_SendClientContractTrackerTable.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Social_SendClientContractTrackerTable));
                            OnOrdered_GameEvent?.Invoke(this,  data_Social_SendClientContractTrackerTable);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Social_SendClientContractTrackerTable));
                            OnSocial_SendClientContractTrackerTable?.Invoke(this, data_Social_SendClientContractTrackerTable);
                            return data_Social_SendClientContractTrackerTable;
        
                        case GameEventType.Social_SendClientContractTracker:
                            var data_Social_SendClientContractTracker = new Social_SendClientContractTracker();
                            data_Social_SendClientContractTracker.Read(reader);
                            OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Social_SendClientContractTracker));
                            OnOrdered_GameEvent?.Invoke(this,  data_Social_SendClientContractTracker);
                            OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Social_SendClientContractTracker));
                            OnSocial_SendClientContractTracker?.Invoke(this, data_Social_SendClientContractTracker);
                            return data_Social_SendClientContractTracker;
        
                        }
                        return null;// end 0xF7B0
    
                    case S2CMessageType.Item_ServerSaysRemove:
                        var data_Item_ServerSaysRemove = new Item_ServerSaysRemove();
                        data_Item_ServerSaysRemove.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_ServerSaysRemove));
                        OnItem_ServerSaysRemove?.Invoke(this, data_Item_ServerSaysRemove);
                        return data_Item_ServerSaysRemove;
    
                    case S2CMessageType.Character_ServerSaysAttemptFailed:
                        var data_Character_ServerSaysAttemptFailed = new Character_ServerSaysAttemptFailed();
                        data_Character_ServerSaysAttemptFailed.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Character_ServerSaysAttemptFailed));
                        OnCharacter_ServerSaysAttemptFailed?.Invoke(this, data_Character_ServerSaysAttemptFailed);
                        return data_Character_ServerSaysAttemptFailed;
    
                    case S2CMessageType.Item_UpdateStackSize:
                        var data_Item_UpdateStackSize = new Item_UpdateStackSize();
                        data_Item_UpdateStackSize.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_UpdateStackSize));
                        OnItem_UpdateStackSize?.Invoke(this, data_Item_UpdateStackSize);
                        return data_Item_UpdateStackSize;
    
                    case S2CMessageType.Combat_HandlePlayerDeathEvent:
                        var data_Combat_HandlePlayerDeathEvent = new Combat_HandlePlayerDeathEvent();
                        data_Combat_HandlePlayerDeathEvent.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Combat_HandlePlayerDeathEvent));
                        OnCombat_HandlePlayerDeathEvent?.Invoke(this, data_Combat_HandlePlayerDeathEvent);
                        return data_Combat_HandlePlayerDeathEvent;
    
                    case S2CMessageType.Qualities_PrivateRemoveIntEvent:
                        var data_Qualities_PrivateRemoveIntEvent = new Qualities_PrivateRemoveIntEvent();
                        data_Qualities_PrivateRemoveIntEvent.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateRemoveIntEvent));
                        OnQualities_PrivateRemoveIntEvent?.Invoke(this, data_Qualities_PrivateRemoveIntEvent);
                        return data_Qualities_PrivateRemoveIntEvent;
    
                    case S2CMessageType.Qualities_RemoveIntEvent:
                        var data_Qualities_RemoveIntEvent = new Qualities_RemoveIntEvent();
                        data_Qualities_RemoveIntEvent.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_RemoveIntEvent));
                        OnQualities_RemoveIntEvent?.Invoke(this, data_Qualities_RemoveIntEvent);
                        return data_Qualities_RemoveIntEvent;
    
                    case S2CMessageType.Qualities_PrivateRemoveBoolEvent:
                        var data_Qualities_PrivateRemoveBoolEvent = new Qualities_PrivateRemoveBoolEvent();
                        data_Qualities_PrivateRemoveBoolEvent.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateRemoveBoolEvent));
                        OnQualities_PrivateRemoveBoolEvent?.Invoke(this, data_Qualities_PrivateRemoveBoolEvent);
                        return data_Qualities_PrivateRemoveBoolEvent;
    
                    case S2CMessageType.Qualities_RemoveBoolEvent:
                        var data_Qualities_RemoveBoolEvent = new Qualities_RemoveBoolEvent();
                        data_Qualities_RemoveBoolEvent.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_RemoveBoolEvent));
                        OnQualities_RemoveBoolEvent?.Invoke(this, data_Qualities_RemoveBoolEvent);
                        return data_Qualities_RemoveBoolEvent;
    
                    case S2CMessageType.Qualities_PrivateRemoveFloatEvent:
                        var data_Qualities_PrivateRemoveFloatEvent = new Qualities_PrivateRemoveFloatEvent();
                        data_Qualities_PrivateRemoveFloatEvent.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateRemoveFloatEvent));
                        OnQualities_PrivateRemoveFloatEvent?.Invoke(this, data_Qualities_PrivateRemoveFloatEvent);
                        return data_Qualities_PrivateRemoveFloatEvent;
    
                    case S2CMessageType.Qualities_RemoveFloatEvent:
                        var data_Qualities_RemoveFloatEvent = new Qualities_RemoveFloatEvent();
                        data_Qualities_RemoveFloatEvent.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_RemoveFloatEvent));
                        OnQualities_RemoveFloatEvent?.Invoke(this, data_Qualities_RemoveFloatEvent);
                        return data_Qualities_RemoveFloatEvent;
    
                    case S2CMessageType.Qualities_PrivateRemoveStringEvent:
                        var data_Qualities_PrivateRemoveStringEvent = new Qualities_PrivateRemoveStringEvent();
                        data_Qualities_PrivateRemoveStringEvent.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateRemoveStringEvent));
                        OnQualities_PrivateRemoveStringEvent?.Invoke(this, data_Qualities_PrivateRemoveStringEvent);
                        return data_Qualities_PrivateRemoveStringEvent;
    
                    case S2CMessageType.Qualities_RemoveStringEvent:
                        var data_Qualities_RemoveStringEvent = new Qualities_RemoveStringEvent();
                        data_Qualities_RemoveStringEvent.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_RemoveStringEvent));
                        OnQualities_RemoveStringEvent?.Invoke(this, data_Qualities_RemoveStringEvent);
                        return data_Qualities_RemoveStringEvent;
    
                    case S2CMessageType.Qualities_PrivateRemoveDataIdEvent:
                        var data_Qualities_PrivateRemoveDataIdEvent = new Qualities_PrivateRemoveDataIdEvent();
                        data_Qualities_PrivateRemoveDataIdEvent.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateRemoveDataIdEvent));
                        OnQualities_PrivateRemoveDataIdEvent?.Invoke(this, data_Qualities_PrivateRemoveDataIdEvent);
                        return data_Qualities_PrivateRemoveDataIdEvent;
    
                    case S2CMessageType.Qualities_RemoveDataIdEvent:
                        var data_Qualities_RemoveDataIdEvent = new Qualities_RemoveDataIdEvent();
                        data_Qualities_RemoveDataIdEvent.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_RemoveDataIdEvent));
                        OnQualities_RemoveDataIdEvent?.Invoke(this, data_Qualities_RemoveDataIdEvent);
                        return data_Qualities_RemoveDataIdEvent;
    
                    case S2CMessageType.Qualities_PrivateRemoveInstanceIdEvent:
                        var data_Qualities_PrivateRemoveInstanceIdEvent = new Qualities_PrivateRemoveInstanceIdEvent();
                        data_Qualities_PrivateRemoveInstanceIdEvent.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateRemoveInstanceIdEvent));
                        OnQualities_PrivateRemoveInstanceIdEvent?.Invoke(this, data_Qualities_PrivateRemoveInstanceIdEvent);
                        return data_Qualities_PrivateRemoveInstanceIdEvent;
    
                    case S2CMessageType.Qualities_RemoveInstanceIdEvent:
                        var data_Qualities_RemoveInstanceIdEvent = new Qualities_RemoveInstanceIdEvent();
                        data_Qualities_RemoveInstanceIdEvent.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_RemoveInstanceIdEvent));
                        OnQualities_RemoveInstanceIdEvent?.Invoke(this, data_Qualities_RemoveInstanceIdEvent);
                        return data_Qualities_RemoveInstanceIdEvent;
    
                    case S2CMessageType.Qualities_PrivateRemovePositionEvent:
                        var data_Qualities_PrivateRemovePositionEvent = new Qualities_PrivateRemovePositionEvent();
                        data_Qualities_PrivateRemovePositionEvent.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateRemovePositionEvent));
                        OnQualities_PrivateRemovePositionEvent?.Invoke(this, data_Qualities_PrivateRemovePositionEvent);
                        return data_Qualities_PrivateRemovePositionEvent;
    
                    case S2CMessageType.Qualities_RemovePositionEvent:
                        var data_Qualities_RemovePositionEvent = new Qualities_RemovePositionEvent();
                        data_Qualities_RemovePositionEvent.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_RemovePositionEvent));
                        OnQualities_RemovePositionEvent?.Invoke(this, data_Qualities_RemovePositionEvent);
                        return data_Qualities_RemovePositionEvent;
    
                    case S2CMessageType.Qualities_PrivateRemoveInt64Event:
                        var data_Qualities_PrivateRemoveInt64Event = new Qualities_PrivateRemoveInt64Event();
                        data_Qualities_PrivateRemoveInt64Event.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateRemoveInt64Event));
                        OnQualities_PrivateRemoveInt64Event?.Invoke(this, data_Qualities_PrivateRemoveInt64Event);
                        return data_Qualities_PrivateRemoveInt64Event;
    
                    case S2CMessageType.Qualities_RemoveInt64Event:
                        var data_Qualities_RemoveInt64Event = new Qualities_RemoveInt64Event();
                        data_Qualities_RemoveInt64Event.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_RemoveInt64Event));
                        OnQualities_RemoveInt64Event?.Invoke(this, data_Qualities_RemoveInt64Event);
                        return data_Qualities_RemoveInt64Event;
    
                    case S2CMessageType.Qualities_PrivateUpdateInt:
                        var data_Qualities_PrivateUpdateInt = new Qualities_PrivateUpdateInt();
                        data_Qualities_PrivateUpdateInt.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateInt));
                        OnQualities_PrivateUpdateInt?.Invoke(this, data_Qualities_PrivateUpdateInt);
                        return data_Qualities_PrivateUpdateInt;
    
                    case S2CMessageType.Qualities_UpdateInt:
                        var data_Qualities_UpdateInt = new Qualities_UpdateInt();
                        data_Qualities_UpdateInt.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateInt));
                        OnQualities_UpdateInt?.Invoke(this, data_Qualities_UpdateInt);
                        return data_Qualities_UpdateInt;
    
                    case S2CMessageType.Qualities_PrivateUpdateInt64:
                        var data_Qualities_PrivateUpdateInt64 = new Qualities_PrivateUpdateInt64();
                        data_Qualities_PrivateUpdateInt64.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateInt64));
                        OnQualities_PrivateUpdateInt64?.Invoke(this, data_Qualities_PrivateUpdateInt64);
                        return data_Qualities_PrivateUpdateInt64;
    
                    case S2CMessageType.Qualities_UpdateInt64:
                        var data_Qualities_UpdateInt64 = new Qualities_UpdateInt64();
                        data_Qualities_UpdateInt64.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateInt64));
                        OnQualities_UpdateInt64?.Invoke(this, data_Qualities_UpdateInt64);
                        return data_Qualities_UpdateInt64;
    
                    case S2CMessageType.Qualities_PrivateUpdateBool:
                        var data_Qualities_PrivateUpdateBool = new Qualities_PrivateUpdateBool();
                        data_Qualities_PrivateUpdateBool.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateBool));
                        OnQualities_PrivateUpdateBool?.Invoke(this, data_Qualities_PrivateUpdateBool);
                        return data_Qualities_PrivateUpdateBool;
    
                    case S2CMessageType.Qualities_UpdateBool:
                        var data_Qualities_UpdateBool = new Qualities_UpdateBool();
                        data_Qualities_UpdateBool.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateBool));
                        OnQualities_UpdateBool?.Invoke(this, data_Qualities_UpdateBool);
                        return data_Qualities_UpdateBool;
    
                    case S2CMessageType.Qualities_PrivateUpdateFloat:
                        var data_Qualities_PrivateUpdateFloat = new Qualities_PrivateUpdateFloat();
                        data_Qualities_PrivateUpdateFloat.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateFloat));
                        OnQualities_PrivateUpdateFloat?.Invoke(this, data_Qualities_PrivateUpdateFloat);
                        return data_Qualities_PrivateUpdateFloat;
    
                    case S2CMessageType.Qualities_UpdateFloat:
                        var data_Qualities_UpdateFloat = new Qualities_UpdateFloat();
                        data_Qualities_UpdateFloat.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateFloat));
                        OnQualities_UpdateFloat?.Invoke(this, data_Qualities_UpdateFloat);
                        return data_Qualities_UpdateFloat;
    
                    case S2CMessageType.Qualities_PrivateUpdateString:
                        var data_Qualities_PrivateUpdateString = new Qualities_PrivateUpdateString();
                        data_Qualities_PrivateUpdateString.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateString));
                        OnQualities_PrivateUpdateString?.Invoke(this, data_Qualities_PrivateUpdateString);
                        return data_Qualities_PrivateUpdateString;
    
                    case S2CMessageType.Qualities_UpdateString:
                        var data_Qualities_UpdateString = new Qualities_UpdateString();
                        data_Qualities_UpdateString.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateString));
                        OnQualities_UpdateString?.Invoke(this, data_Qualities_UpdateString);
                        return data_Qualities_UpdateString;
    
                    case S2CMessageType.Qualities_PrivateUpdateDataId:
                        var data_Qualities_PrivateUpdateDataId = new Qualities_PrivateUpdateDataId();
                        data_Qualities_PrivateUpdateDataId.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateDataId));
                        OnQualities_PrivateUpdateDataId?.Invoke(this, data_Qualities_PrivateUpdateDataId);
                        return data_Qualities_PrivateUpdateDataId;
    
                    case S2CMessageType.Qualities_UpdateDataId:
                        var data_Qualities_UpdateDataId = new Qualities_UpdateDataId();
                        data_Qualities_UpdateDataId.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateDataId));
                        OnQualities_UpdateDataId?.Invoke(this, data_Qualities_UpdateDataId);
                        return data_Qualities_UpdateDataId;
    
                    case S2CMessageType.Qualities_PrivateUpdateInstanceId:
                        var data_Qualities_PrivateUpdateInstanceId = new Qualities_PrivateUpdateInstanceId();
                        data_Qualities_PrivateUpdateInstanceId.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateInstanceId));
                        OnQualities_PrivateUpdateInstanceId?.Invoke(this, data_Qualities_PrivateUpdateInstanceId);
                        return data_Qualities_PrivateUpdateInstanceId;
    
                    case S2CMessageType.Qualities_UpdateInstanceId:
                        var data_Qualities_UpdateInstanceId = new Qualities_UpdateInstanceId();
                        data_Qualities_UpdateInstanceId.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateInstanceId));
                        OnQualities_UpdateInstanceId?.Invoke(this, data_Qualities_UpdateInstanceId);
                        return data_Qualities_UpdateInstanceId;
    
                    case S2CMessageType.Qualities_PrivateUpdatePosition:
                        var data_Qualities_PrivateUpdatePosition = new Qualities_PrivateUpdatePosition();
                        data_Qualities_PrivateUpdatePosition.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdatePosition));
                        OnQualities_PrivateUpdatePosition?.Invoke(this, data_Qualities_PrivateUpdatePosition);
                        return data_Qualities_PrivateUpdatePosition;
    
                    case S2CMessageType.Qualities_UpdatePosition:
                        var data_Qualities_UpdatePosition = new Qualities_UpdatePosition();
                        data_Qualities_UpdatePosition.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdatePosition));
                        OnQualities_UpdatePosition?.Invoke(this, data_Qualities_UpdatePosition);
                        return data_Qualities_UpdatePosition;
    
                    case S2CMessageType.Qualities_PrivateUpdateSkill:
                        var data_Qualities_PrivateUpdateSkill = new Qualities_PrivateUpdateSkill();
                        data_Qualities_PrivateUpdateSkill.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateSkill));
                        OnQualities_PrivateUpdateSkill?.Invoke(this, data_Qualities_PrivateUpdateSkill);
                        return data_Qualities_PrivateUpdateSkill;
    
                    case S2CMessageType.Qualities_UpdateSkill:
                        var data_Qualities_UpdateSkill = new Qualities_UpdateSkill();
                        data_Qualities_UpdateSkill.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateSkill));
                        OnQualities_UpdateSkill?.Invoke(this, data_Qualities_UpdateSkill);
                        return data_Qualities_UpdateSkill;
    
                    case S2CMessageType.Qualities_PrivateUpdateSkillLevel:
                        var data_Qualities_PrivateUpdateSkillLevel = new Qualities_PrivateUpdateSkillLevel();
                        data_Qualities_PrivateUpdateSkillLevel.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateSkillLevel));
                        OnQualities_PrivateUpdateSkillLevel?.Invoke(this, data_Qualities_PrivateUpdateSkillLevel);
                        return data_Qualities_PrivateUpdateSkillLevel;
    
                    case S2CMessageType.Qualities_UpdateSkillLevel:
                        var data_Qualities_UpdateSkillLevel = new Qualities_UpdateSkillLevel();
                        data_Qualities_UpdateSkillLevel.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateSkillLevel));
                        OnQualities_UpdateSkillLevel?.Invoke(this, data_Qualities_UpdateSkillLevel);
                        return data_Qualities_UpdateSkillLevel;
    
                    case S2CMessageType.Qualities_PrivateUpdateSkillAC:
                        var data_Qualities_PrivateUpdateSkillAC = new Qualities_PrivateUpdateSkillAC();
                        data_Qualities_PrivateUpdateSkillAC.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateSkillAC));
                        OnQualities_PrivateUpdateSkillAC?.Invoke(this, data_Qualities_PrivateUpdateSkillAC);
                        return data_Qualities_PrivateUpdateSkillAC;
    
                    case S2CMessageType.Qualities_UpdateSkillAC:
                        var data_Qualities_UpdateSkillAC = new Qualities_UpdateSkillAC();
                        data_Qualities_UpdateSkillAC.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateSkillAC));
                        OnQualities_UpdateSkillAC?.Invoke(this, data_Qualities_UpdateSkillAC);
                        return data_Qualities_UpdateSkillAC;
    
                    case S2CMessageType.Qualities_PrivateUpdateAttribute:
                        var data_Qualities_PrivateUpdateAttribute = new Qualities_PrivateUpdateAttribute();
                        data_Qualities_PrivateUpdateAttribute.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateAttribute));
                        OnQualities_PrivateUpdateAttribute?.Invoke(this, data_Qualities_PrivateUpdateAttribute);
                        return data_Qualities_PrivateUpdateAttribute;
    
                    case S2CMessageType.Qualities_UpdateAttribute:
                        var data_Qualities_UpdateAttribute = new Qualities_UpdateAttribute();
                        data_Qualities_UpdateAttribute.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateAttribute));
                        OnQualities_UpdateAttribute?.Invoke(this, data_Qualities_UpdateAttribute);
                        return data_Qualities_UpdateAttribute;
    
                    case S2CMessageType.Qualities_PrivateUpdateAttributeLevel:
                        var data_Qualities_PrivateUpdateAttributeLevel = new Qualities_PrivateUpdateAttributeLevel();
                        data_Qualities_PrivateUpdateAttributeLevel.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateAttributeLevel));
                        OnQualities_PrivateUpdateAttributeLevel?.Invoke(this, data_Qualities_PrivateUpdateAttributeLevel);
                        return data_Qualities_PrivateUpdateAttributeLevel;
    
                    case S2CMessageType.Qualities_UpdateAttributeLevel:
                        var data_Qualities_UpdateAttributeLevel = new Qualities_UpdateAttributeLevel();
                        data_Qualities_UpdateAttributeLevel.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateAttributeLevel));
                        OnQualities_UpdateAttributeLevel?.Invoke(this, data_Qualities_UpdateAttributeLevel);
                        return data_Qualities_UpdateAttributeLevel;
    
                    case S2CMessageType.Qualities_PrivateUpdateAttribute2nd:
                        var data_Qualities_PrivateUpdateAttribute2nd = new Qualities_PrivateUpdateAttribute2nd();
                        data_Qualities_PrivateUpdateAttribute2nd.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateAttribute2nd));
                        OnQualities_PrivateUpdateAttribute2nd?.Invoke(this, data_Qualities_PrivateUpdateAttribute2nd);
                        return data_Qualities_PrivateUpdateAttribute2nd;
    
                    case S2CMessageType.Qualities_UpdateAttribute2nd:
                        var data_Qualities_UpdateAttribute2nd = new Qualities_UpdateAttribute2nd();
                        data_Qualities_UpdateAttribute2nd.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateAttribute2nd));
                        OnQualities_UpdateAttribute2nd?.Invoke(this, data_Qualities_UpdateAttribute2nd);
                        return data_Qualities_UpdateAttribute2nd;
    
                    case S2CMessageType.Qualities_PrivateUpdateAttribute2ndLevel:
                        var data_Qualities_PrivateUpdateAttribute2ndLevel = new Qualities_PrivateUpdateAttribute2ndLevel();
                        data_Qualities_PrivateUpdateAttribute2ndLevel.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateAttribute2ndLevel));
                        OnQualities_PrivateUpdateAttribute2ndLevel?.Invoke(this, data_Qualities_PrivateUpdateAttribute2ndLevel);
                        return data_Qualities_PrivateUpdateAttribute2ndLevel;
    
                    case S2CMessageType.Qualities_UpdateAttribute2ndLevel:
                        var data_Qualities_UpdateAttribute2ndLevel = new Qualities_UpdateAttribute2ndLevel();
                        data_Qualities_UpdateAttribute2ndLevel.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateAttribute2ndLevel));
                        OnQualities_UpdateAttribute2ndLevel?.Invoke(this, data_Qualities_UpdateAttribute2ndLevel);
                        return data_Qualities_UpdateAttribute2ndLevel;
    
                    case S2CMessageType.Communication_HearEmote:
                        var data_Communication_HearEmote = new Communication_HearEmote();
                        data_Communication_HearEmote.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_HearEmote));
                        OnCommunication_HearEmote?.Invoke(this, data_Communication_HearEmote);
                        return data_Communication_HearEmote;
    
                    case S2CMessageType.Communication_HearSoulEmote:
                        var data_Communication_HearSoulEmote = new Communication_HearSoulEmote();
                        data_Communication_HearSoulEmote.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_HearSoulEmote));
                        OnCommunication_HearSoulEmote?.Invoke(this, data_Communication_HearSoulEmote);
                        return data_Communication_HearSoulEmote;
    
                    case S2CMessageType.Communication_HearSpeech:
                        var data_Communication_HearSpeech = new Communication_HearSpeech();
                        data_Communication_HearSpeech.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_HearSpeech));
                        OnCommunication_HearSpeech?.Invoke(this, data_Communication_HearSpeech);
                        return data_Communication_HearSpeech;
    
                    case S2CMessageType.Communication_HearRangedSpeech:
                        var data_Communication_HearRangedSpeech = new Communication_HearRangedSpeech();
                        data_Communication_HearRangedSpeech.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_HearRangedSpeech));
                        OnCommunication_HearRangedSpeech?.Invoke(this, data_Communication_HearRangedSpeech);
                        return data_Communication_HearRangedSpeech;
    
                    case S2CMessageType.Admin_Environs:
                        var data_Admin_Environs = new Admin_Environs();
                        data_Admin_Environs.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Admin_Environs));
                        OnAdmin_Environs?.Invoke(this, data_Admin_Environs);
                        return data_Admin_Environs;
    
                    case S2CMessageType.Movement_PositionAndMovementEvent:
                        var data_Movement_PositionAndMovementEvent = new Movement_PositionAndMovementEvent();
                        data_Movement_PositionAndMovementEvent.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Movement_PositionAndMovementEvent));
                        OnMovement_PositionAndMovementEvent?.Invoke(this, data_Movement_PositionAndMovementEvent);
                        return data_Movement_PositionAndMovementEvent;
    
                    case S2CMessageType.Item_ObjDescEvent:
                        var data_Item_ObjDescEvent = new Item_ObjDescEvent();
                        data_Item_ObjDescEvent.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_ObjDescEvent));
                        OnItem_ObjDescEvent?.Invoke(this, data_Item_ObjDescEvent);
                        return data_Item_ObjDescEvent;
    
                    case S2CMessageType.Character_SetPlayerVisualDesc:
                        var data_Character_SetPlayerVisualDesc = new Character_SetPlayerVisualDesc();
                        data_Character_SetPlayerVisualDesc.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Character_SetPlayerVisualDesc));
                        OnCharacter_SetPlayerVisualDesc?.Invoke(this, data_Character_SetPlayerVisualDesc);
                        return data_Character_SetPlayerVisualDesc;
    
                    case S2CMessageType.Character_CharGenVerificationResponse:
                        var data_Character_CharGenVerificationResponse = new Character_CharGenVerificationResponse();
                        data_Character_CharGenVerificationResponse.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Character_CharGenVerificationResponse));
                        OnCharacter_CharGenVerificationResponse?.Invoke(this, data_Character_CharGenVerificationResponse);
                        return data_Character_CharGenVerificationResponse;
    
                    case S2CMessageType.Login_AwaitingSubscriptionExpiration:
                        var data_Login_AwaitingSubscriptionExpiration = new Login_AwaitingSubscriptionExpiration();
                        data_Login_AwaitingSubscriptionExpiration.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Login_AwaitingSubscriptionExpiration));
                        OnLogin_AwaitingSubscriptionExpiration?.Invoke(this, data_Login_AwaitingSubscriptionExpiration);
                        return data_Login_AwaitingSubscriptionExpiration;
    
                    case S2CMessageType.Login_LogOffCharacter:
                        var data_Login_LogOffCharacter = new Login_LogOffCharacter();
                        data_Login_LogOffCharacter.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Login_LogOffCharacter));
                        OnLogin_LogOffCharacter?.Invoke(this, data_Login_LogOffCharacter);
                        return data_Login_LogOffCharacter;
    
                    case S2CMessageType.Character_CharacterDelete:
                        var data_Character_CharacterDelete = new Character_CharacterDelete();
                        data_Character_CharacterDelete.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Character_CharacterDelete));
                        OnCharacter_CharacterDelete?.Invoke(this, data_Character_CharacterDelete);
                        return data_Character_CharacterDelete;
    
                    case S2CMessageType.Login_LoginCharacterSet:
                        var data_Login_LoginCharacterSet = new Login_LoginCharacterSet();
                        data_Login_LoginCharacterSet.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Login_LoginCharacterSet));
                        OnLogin_LoginCharacterSet?.Invoke(this, data_Login_LoginCharacterSet);
                        return data_Login_LoginCharacterSet;
    
                    case S2CMessageType.Character_CharacterError:
                        var data_Character_CharacterError = new Character_CharacterError();
                        data_Character_CharacterError.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Character_CharacterError));
                        OnCharacter_CharacterError?.Invoke(this, data_Character_CharacterError);
                        return data_Character_CharacterError;
    
                    case S2CMessageType.Item_CreateObject:
                        var data_Item_CreateObject = new Item_CreateObject();
                        data_Item_CreateObject.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_CreateObject));
                        OnItem_CreateObject?.Invoke(this, data_Item_CreateObject);
                        return data_Item_CreateObject;
    
                    case S2CMessageType.Login_CreatePlayer:
                        var data_Login_CreatePlayer = new Login_CreatePlayer();
                        data_Login_CreatePlayer.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Login_CreatePlayer));
                        OnLogin_CreatePlayer?.Invoke(this, data_Login_CreatePlayer);
                        return data_Login_CreatePlayer;
    
                    case S2CMessageType.Item_DeleteObject:
                        var data_Item_DeleteObject = new Item_DeleteObject();
                        data_Item_DeleteObject.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_DeleteObject));
                        OnItem_DeleteObject?.Invoke(this, data_Item_DeleteObject);
                        return data_Item_DeleteObject;
    
                    case S2CMessageType.Movement_PositionEvent:
                        var data_Movement_PositionEvent = new Movement_PositionEvent();
                        data_Movement_PositionEvent.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Movement_PositionEvent));
                        OnMovement_PositionEvent?.Invoke(this, data_Movement_PositionEvent);
                        return data_Movement_PositionEvent;
    
                    case S2CMessageType.Item_ParentEvent:
                        var data_Item_ParentEvent = new Item_ParentEvent();
                        data_Item_ParentEvent.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_ParentEvent));
                        OnItem_ParentEvent?.Invoke(this, data_Item_ParentEvent);
                        return data_Item_ParentEvent;
    
                    case S2CMessageType.Inventory_PickupEvent:
                        var data_Inventory_PickupEvent = new Inventory_PickupEvent();
                        data_Inventory_PickupEvent.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Inventory_PickupEvent));
                        OnInventory_PickupEvent?.Invoke(this, data_Inventory_PickupEvent);
                        return data_Inventory_PickupEvent;
    
                    case S2CMessageType.Item_SetState:
                        var data_Item_SetState = new Item_SetState();
                        data_Item_SetState.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_SetState));
                        OnItem_SetState?.Invoke(this, data_Item_SetState);
                        return data_Item_SetState;
    
                    case S2CMessageType.Movement_SetObjectMovement:
                        var data_Movement_SetObjectMovement = new Movement_SetObjectMovement();
                        data_Movement_SetObjectMovement.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Movement_SetObjectMovement));
                        OnMovement_SetObjectMovement?.Invoke(this, data_Movement_SetObjectMovement);
                        return data_Movement_SetObjectMovement;
    
                    case S2CMessageType.Movement_VectorUpdate:
                        var data_Movement_VectorUpdate = new Movement_VectorUpdate();
                        data_Movement_VectorUpdate.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Movement_VectorUpdate));
                        OnMovement_VectorUpdate?.Invoke(this, data_Movement_VectorUpdate);
                        return data_Movement_VectorUpdate;
    
                    case S2CMessageType.Effects_SoundEvent:
                        var data_Effects_SoundEvent = new Effects_SoundEvent();
                        data_Effects_SoundEvent.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Effects_SoundEvent));
                        OnEffects_SoundEvent?.Invoke(this, data_Effects_SoundEvent);
                        return data_Effects_SoundEvent;
    
                    case S2CMessageType.Effects_PlayerTeleport:
                        var data_Effects_PlayerTeleport = new Effects_PlayerTeleport();
                        data_Effects_PlayerTeleport.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Effects_PlayerTeleport));
                        OnEffects_PlayerTeleport?.Invoke(this, data_Effects_PlayerTeleport);
                        return data_Effects_PlayerTeleport;
    
                    case S2CMessageType.Effects_PlayScriptId:
                        var data_Effects_PlayScriptId = new Effects_PlayScriptId();
                        data_Effects_PlayScriptId.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Effects_PlayScriptId));
                        OnEffects_PlayScriptId?.Invoke(this, data_Effects_PlayScriptId);
                        return data_Effects_PlayScriptId;
    
                    case S2CMessageType.Effects_PlayScriptType:
                        var data_Effects_PlayScriptType = new Effects_PlayScriptType();
                        data_Effects_PlayScriptType.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Effects_PlayScriptType));
                        OnEffects_PlayScriptType?.Invoke(this, data_Effects_PlayScriptType);
                        return data_Effects_PlayScriptType;
    
                    case S2CMessageType.Login_AccountBanned:
                        var data_Login_AccountBanned = new Login_AccountBanned();
                        data_Login_AccountBanned.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Login_AccountBanned));
                        OnLogin_AccountBanned?.Invoke(this, data_Login_AccountBanned);
                        return data_Login_AccountBanned;
    
                    case S2CMessageType.Admin_ReceiveAccountData:
                        var data_Admin_ReceiveAccountData = new Admin_ReceiveAccountData();
                        data_Admin_ReceiveAccountData.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Admin_ReceiveAccountData));
                        OnAdmin_ReceiveAccountData?.Invoke(this, data_Admin_ReceiveAccountData);
                        return data_Admin_ReceiveAccountData;
    
                    case S2CMessageType.Admin_ReceivePlayerData:
                        var data_Admin_ReceivePlayerData = new Admin_ReceivePlayerData();
                        data_Admin_ReceivePlayerData.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Admin_ReceivePlayerData));
                        OnAdmin_ReceivePlayerData?.Invoke(this, data_Admin_ReceivePlayerData);
                        return data_Admin_ReceivePlayerData;
    
                    case S2CMessageType.Item_UpdateObject:
                        var data_Item_UpdateObject = new Item_UpdateObject();
                        data_Item_UpdateObject.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_UpdateObject));
                        OnItem_UpdateObject?.Invoke(this, data_Item_UpdateObject);
                        return data_Item_UpdateObject;
    
                    case S2CMessageType.Login_AccountBooted:
                        var data_Login_AccountBooted = new Login_AccountBooted();
                        data_Login_AccountBooted.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Login_AccountBooted));
                        OnLogin_AccountBooted?.Invoke(this, data_Login_AccountBooted);
                        return data_Login_AccountBooted;
    
                    case S2CMessageType.Communication_TurbineChat:
                        var data_Communication_TurbineChat = new Communication_TurbineChat();
                        data_Communication_TurbineChat.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_TurbineChat));
                        OnCommunication_TurbineChat?.Invoke(this, data_Communication_TurbineChat);
                        return data_Communication_TurbineChat;
    
                    case S2CMessageType.Login_EnterGame_ServerReady:
                        var data_Login_EnterGame_ServerReady = new Login_EnterGame_ServerReady();
                        data_Login_EnterGame_ServerReady.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Login_EnterGame_ServerReady));
                        OnLogin_EnterGame_ServerReady?.Invoke(this, data_Login_EnterGame_ServerReady);
                        return data_Login_EnterGame_ServerReady;
    
                    case S2CMessageType.Communication_TextboxString:
                        var data_Communication_TextboxString = new Communication_TextboxString();
                        data_Communication_TextboxString.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_TextboxString));
                        OnCommunication_TextboxString?.Invoke(this, data_Communication_TextboxString);
                        return data_Communication_TextboxString;
    
                    case S2CMessageType.Login_WorldInfo:
                        var data_Login_WorldInfo = new Login_WorldInfo();
                        data_Login_WorldInfo.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Login_WorldInfo));
                        OnLogin_WorldInfo?.Invoke(this, data_Login_WorldInfo);
                        return data_Login_WorldInfo;
    
                    case S2CMessageType.DDD_DataMessage:
                        var data_DDD_DataMessage = new DDD_DataMessage();
                        data_DDD_DataMessage.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_DDD_DataMessage));
                        OnDDD_DataMessage?.Invoke(this, data_DDD_DataMessage);
                        return data_DDD_DataMessage;
    
                    case S2CMessageType.DDD_ErrorMessage:
                        var data_DDD_ErrorMessage = new DDD_ErrorMessage();
                        data_DDD_ErrorMessage.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_DDD_ErrorMessage));
                        OnDDD_ErrorMessage?.Invoke(this, data_DDD_ErrorMessage);
                        return data_DDD_ErrorMessage;
    
                    case S2CMessageType.DDD_BeginDDDMessage:
                        var data_DDD_BeginDDDMessage = new DDD_BeginDDDMessage();
                        data_DDD_BeginDDDMessage.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_DDD_BeginDDDMessage));
                        OnDDD_BeginDDDMessage?.Invoke(this, data_DDD_BeginDDDMessage);
                        return data_DDD_BeginDDDMessage;
    
                    case S2CMessageType.DDD_InterrogationMessage:
                        var data_DDD_InterrogationMessage = new DDD_InterrogationMessage();
                        data_DDD_InterrogationMessage.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_DDD_InterrogationMessage));
                        OnDDD_InterrogationMessage?.Invoke(this, data_DDD_InterrogationMessage);
                        return data_DDD_InterrogationMessage;
    
                    case S2CMessageType.DDD_OnEndDDD:
                        var data_DDD_OnEndDDD = new DDD_OnEndDDD();
                        data_DDD_OnEndDDD.Read(reader);
                        OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_DDD_OnEndDDD));
                        OnDDD_OnEndDDD?.Invoke(this, data_DDD_OnEndDDD);
                        return data_DDD_OnEndDDD;
    
                default:
                    var rawData = reader.ReadBytes((int)(reader.BaseStream.Length - reader.BaseStream.Position));
                    OnUnknownMessage?.Invoke(this, new UnknownMessageEventArgs(MessageDirection.ServerToClient, (uint)opcode, rawData));
                    return null;
            }
        }
    }
}
