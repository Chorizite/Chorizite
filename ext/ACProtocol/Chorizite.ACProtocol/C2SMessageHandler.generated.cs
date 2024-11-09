using System;
using System.IO;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Messages.C2S;
using Chorizite.ACProtocol.Messages.C2S.Actions;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol;
using Chorizite.Common;

namespace Chorizite.ACProtocol {
    public class C2SMessageHandler {
        /// <summary>
        /// Fired for every valid parsed Message
        /// </summary>
        public event EventHandler<C2SMessageEventArgs>? OnMessage {
            add { _OnMessage.Subscribe(value); }
            remove { _OnMessage.Unsubscribe(value); }
        }
        private readonly WeakEvent<C2SMessageEventArgs> _OnMessage = new();

        /// <summary>
        /// Fired for every valid parsed GameAction
        /// </summary>
        public event EventHandler<GameActionEventArgs>? OnGameAction {
            add { _OnGameAction.Subscribe(value); }
            remove { _OnGameAction.Unsubscribe(value); }
        }
        private readonly WeakEvent<GameActionEventArgs> _OnGameAction = new();

        /// <summary>
        /// Fired when an unknown Message type was encountered 
        /// </summary>
        public event EventHandler<UnknownMessageEventArgs>? OnUnknownMessage {
            add { _OnUnknownMessage.Subscribe(value); }
            remove { _OnUnknownMessage.Unsubscribe(value); }
        }
        private readonly WeakEvent<UnknownMessageEventArgs> _OnUnknownMessage = new();

        /// <summary>
        /// Fired on Message type 0xF653 Login_LogOffCharacter. Instructs the client to return to 2D mode - the character list.
        /// </summary>
        public event EventHandler<Login_LogOffCharacter>? OnLogin_LogOffCharacter {
            add { _OnLogin_LogOffCharacter.Subscribe(value); }
            remove { _OnLogin_LogOffCharacter.Unsubscribe(value); }
        }
        private readonly WeakEvent<Login_LogOffCharacter> _OnLogin_LogOffCharacter = new();
    
        /// <summary>
        /// Fired on Message type 0xF655 Character_CharacterDelete. Mark a character for deletetion.
        /// </summary>
        public event EventHandler<Character_CharacterDelete>? OnCharacter_CharacterDelete {
            add { _OnCharacter_CharacterDelete.Subscribe(value); }
            remove { _OnCharacter_CharacterDelete.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_CharacterDelete> _OnCharacter_CharacterDelete = new();
    
        /// <summary>
        /// Fired on Message type 0xF656 Character_SendCharGenResult. Character creation result
        /// </summary>
        public event EventHandler<Character_SendCharGenResult>? OnCharacter_SendCharGenResult {
            add { _OnCharacter_SendCharGenResult.Subscribe(value); }
            remove { _OnCharacter_SendCharGenResult.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_SendCharGenResult> _OnCharacter_SendCharGenResult = new();
    
        /// <summary>
        /// Fired on Message type 0xF657 Login_SendEnterWorld. The character to log in.
        /// </summary>
        public event EventHandler<Login_SendEnterWorld>? OnLogin_SendEnterWorld {
            add { _OnLogin_SendEnterWorld.Subscribe(value); }
            remove { _OnLogin_SendEnterWorld.Unsubscribe(value); }
        }
        private readonly WeakEvent<Login_SendEnterWorld> _OnLogin_SendEnterWorld = new();
    
        /// <summary>
        /// Fired on Message type 0xF6EA Object_SendForceObjdesc. Asks server for a new object description
        /// </summary>
        public event EventHandler<Object_SendForceObjdesc>? OnObject_SendForceObjdesc {
            add { _OnObject_SendForceObjdesc.Subscribe(value); }
            remove { _OnObject_SendForceObjdesc.Unsubscribe(value); }
        }
        private readonly WeakEvent<Object_SendForceObjdesc> _OnObject_SendForceObjdesc = new();
    
        /// <summary>
        /// Fired on Message type 0xF7C8 Login_SendEnterWorldRequest. The user has clicked 'Enter'. This message does not contain the Id of the character logging on; that comes later.
        /// </summary>
        public event EventHandler<Login_SendEnterWorldRequest>? OnLogin_SendEnterWorldRequest {
            add { _OnLogin_SendEnterWorldRequest.Subscribe(value); }
            remove { _OnLogin_SendEnterWorldRequest.Unsubscribe(value); }
        }
        private readonly WeakEvent<Login_SendEnterWorldRequest> _OnLogin_SendEnterWorldRequest = new();
    
        /// <summary>
        /// Fired on Message type 0xF7CC Admin_SendAdminGetServerVersion. Sent if player is an PSR, I assume it displays the server version number
        /// </summary>
        public event EventHandler<Admin_SendAdminGetServerVersion>? OnAdmin_SendAdminGetServerVersion {
            add { _OnAdmin_SendAdminGetServerVersion.Subscribe(value); }
            remove { _OnAdmin_SendAdminGetServerVersion.Unsubscribe(value); }
        }
        private readonly WeakEvent<Admin_SendAdminGetServerVersion> _OnAdmin_SendAdminGetServerVersion = new();
    
        /// <summary>
        /// Fired on Message type 0xF7CD Social_SendFriendsCommand. Seems to be a legacy friends command, /friends old, for when Jan 2006 event changed the friends list
        /// </summary>
        public event EventHandler<Social_SendFriendsCommand>? OnSocial_SendFriendsCommand {
            add { _OnSocial_SendFriendsCommand.Subscribe(value); }
            remove { _OnSocial_SendFriendsCommand.Unsubscribe(value); }
        }
        private readonly WeakEvent<Social_SendFriendsCommand> _OnSocial_SendFriendsCommand = new();
    
        /// <summary>
        /// Fired on Message type 0xF7D9 Admin_SendAdminRestoreCharacter. Admin command to restore a character
        /// </summary>
        public event EventHandler<Admin_SendAdminRestoreCharacter>? OnAdmin_SendAdminRestoreCharacter {
            add { _OnAdmin_SendAdminRestoreCharacter.Subscribe(value); }
            remove { _OnAdmin_SendAdminRestoreCharacter.Unsubscribe(value); }
        }
        private readonly WeakEvent<Admin_SendAdminRestoreCharacter> _OnAdmin_SendAdminRestoreCharacter = new();
    
        /// <summary>
        /// Fired on Message type 0xF7DE Communication_TurbineChat. Send or receive a message using Turbine Chat.
        /// </summary>
        public event EventHandler<Communication_TurbineChat>? OnCommunication_TurbineChat {
            add { _OnCommunication_TurbineChat.Subscribe(value); }
            remove { _OnCommunication_TurbineChat.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_TurbineChat> _OnCommunication_TurbineChat = new();
    
        /// <summary>
        /// Fired on Message type 0xF7E3 DDD_RequestDataMessage. DDD request for data
        /// </summary>
        public event EventHandler<DDD_RequestDataMessage>? OnDDD_RequestDataMessage {
            add { _OnDDD_RequestDataMessage.Subscribe(value); }
            remove { _OnDDD_RequestDataMessage.Unsubscribe(value); }
        }
        private readonly WeakEvent<DDD_RequestDataMessage> _OnDDD_RequestDataMessage = new();
    
        /// <summary>
        /// Fired on Message type 0xF7E6 DDD_InterrogationResponseMessage. TODO
        /// </summary>
        public event EventHandler<DDD_InterrogationResponseMessage>? OnDDD_InterrogationResponseMessage {
            add { _OnDDD_InterrogationResponseMessage.Subscribe(value); }
            remove { _OnDDD_InterrogationResponseMessage.Unsubscribe(value); }
        }
        private readonly WeakEvent<DDD_InterrogationResponseMessage> _OnDDD_InterrogationResponseMessage = new();
    
        /// <summary>
        /// Fired on Message type 0xF7EB DDD_EndDDDMessage. Ends DDD message update
        /// </summary>
        public event EventHandler<DDD_EndDDDMessage>? OnDDD_EndDDDMessage {
            add { _OnDDD_EndDDDMessage.Subscribe(value); }
            remove { _OnDDD_EndDDDMessage.Unsubscribe(value); }
        }
        private readonly WeakEvent<DDD_EndDDDMessage> _OnDDD_EndDDDMessage = new();
    
        /// <summary>
        /// Fired on Message type 0xF7EA DDD_OnEndDDD. Ends DDD update
        /// </summary>
        public event EventHandler<DDD_OnEndDDD>? OnDDD_OnEndDDD {
            add { _OnDDD_OnEndDDD.Subscribe(value); }
            remove { _OnDDD_OnEndDDD.Unsubscribe(value); }
        }
        private readonly WeakEvent<DDD_OnEndDDD> _OnDDD_OnEndDDD = new();
    
        /// <summary>
        /// Fired on Message type 0xF7B1 Ordered_GameAction. Ordered game action
        /// </summary>
        public event EventHandler<Ordered_GameAction>? OnOrdered_GameAction {
            add { _OnOrdered_GameAction.Subscribe(value); }
            remove { _OnOrdered_GameAction.Unsubscribe(value); }
        }
        private readonly WeakEvent<Ordered_GameAction> _OnOrdered_GameAction = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0005 Character_PlayerOptionChangedEvent. Set a single character option.
        /// </summary>
        public event EventHandler<Character_PlayerOptionChangedEvent>? OnCharacter_PlayerOptionChangedEvent {
            add { _OnCharacter_PlayerOptionChangedEvent.Subscribe(value); }
            remove { _OnCharacter_PlayerOptionChangedEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_PlayerOptionChangedEvent> _OnCharacter_PlayerOptionChangedEvent = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0008 Combat_TargetedMeleeAttack. Starts a melee attack against a target
        /// </summary>
        public event EventHandler<Combat_TargetedMeleeAttack>? OnCombat_TargetedMeleeAttack {
            add { _OnCombat_TargetedMeleeAttack.Subscribe(value); }
            remove { _OnCombat_TargetedMeleeAttack.Unsubscribe(value); }
        }
        private readonly WeakEvent<Combat_TargetedMeleeAttack> _OnCombat_TargetedMeleeAttack = new();
    
        /// <summary>
        /// Fired on GameAction type 0x000A Combat_TargetedMissileAttack. Starts a missle attack against a target
        /// </summary>
        public event EventHandler<Combat_TargetedMissileAttack>? OnCombat_TargetedMissileAttack {
            add { _OnCombat_TargetedMissileAttack.Subscribe(value); }
            remove { _OnCombat_TargetedMissileAttack.Unsubscribe(value); }
        }
        private readonly WeakEvent<Combat_TargetedMissileAttack> _OnCombat_TargetedMissileAttack = new();
    
        /// <summary>
        /// Fired on GameAction type 0x000F Communication_SetAFKMode. Set AFK mode.
        /// </summary>
        public event EventHandler<Communication_SetAFKMode>? OnCommunication_SetAFKMode {
            add { _OnCommunication_SetAFKMode.Subscribe(value); }
            remove { _OnCommunication_SetAFKMode.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_SetAFKMode> _OnCommunication_SetAFKMode = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0010 Communication_SetAFKMessage. Set AFK message.
        /// </summary>
        public event EventHandler<Communication_SetAFKMessage>? OnCommunication_SetAFKMessage {
            add { _OnCommunication_SetAFKMessage.Subscribe(value); }
            remove { _OnCommunication_SetAFKMessage.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_SetAFKMessage> _OnCommunication_SetAFKMessage = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0015 Communication_Talk. Talking
        /// </summary>
        public event EventHandler<Communication_Talk>? OnCommunication_Talk {
            add { _OnCommunication_Talk.Subscribe(value); }
            remove { _OnCommunication_Talk.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_Talk> _OnCommunication_Talk = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0017 Social_RemoveFriend. Removes a friend
        /// </summary>
        public event EventHandler<Social_RemoveFriend>? OnSocial_RemoveFriend {
            add { _OnSocial_RemoveFriend.Subscribe(value); }
            remove { _OnSocial_RemoveFriend.Unsubscribe(value); }
        }
        private readonly WeakEvent<Social_RemoveFriend> _OnSocial_RemoveFriend = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0018 Social_AddFriend. Adds a friend
        /// </summary>
        public event EventHandler<Social_AddFriend>? OnSocial_AddFriend {
            add { _OnSocial_AddFriend.Subscribe(value); }
            remove { _OnSocial_AddFriend.Unsubscribe(value); }
        }
        private readonly WeakEvent<Social_AddFriend> _OnSocial_AddFriend = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0019 Inventory_PutItemInContainer. Store an item in a container.
        /// </summary>
        public event EventHandler<Inventory_PutItemInContainer>? OnInventory_PutItemInContainer {
            add { _OnInventory_PutItemInContainer.Subscribe(value); }
            remove { _OnInventory_PutItemInContainer.Unsubscribe(value); }
        }
        private readonly WeakEvent<Inventory_PutItemInContainer> _OnInventory_PutItemInContainer = new();
    
        /// <summary>
        /// Fired on GameAction type 0x001A Inventory_GetAndWieldItem. Gets and weilds an item.
        /// </summary>
        public event EventHandler<Inventory_GetAndWieldItem>? OnInventory_GetAndWieldItem {
            add { _OnInventory_GetAndWieldItem.Subscribe(value); }
            remove { _OnInventory_GetAndWieldItem.Unsubscribe(value); }
        }
        private readonly WeakEvent<Inventory_GetAndWieldItem> _OnInventory_GetAndWieldItem = new();
    
        /// <summary>
        /// Fired on GameAction type 0x001B Inventory_DropItem. Drop an item.
        /// </summary>
        public event EventHandler<Inventory_DropItem>? OnInventory_DropItem {
            add { _OnInventory_DropItem.Subscribe(value); }
            remove { _OnInventory_DropItem.Unsubscribe(value); }
        }
        private readonly WeakEvent<Inventory_DropItem> _OnInventory_DropItem = new();
    
        /// <summary>
        /// Fired on GameAction type 0x001D Allegiance_SwearAllegiance. Swear allegiance
        /// </summary>
        public event EventHandler<Allegiance_SwearAllegiance>? OnAllegiance_SwearAllegiance {
            add { _OnAllegiance_SwearAllegiance.Subscribe(value); }
            remove { _OnAllegiance_SwearAllegiance.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_SwearAllegiance> _OnAllegiance_SwearAllegiance = new();
    
        /// <summary>
        /// Fired on GameAction type 0x001E Allegiance_BreakAllegiance. Break allegiance
        /// </summary>
        public event EventHandler<Allegiance_BreakAllegiance>? OnAllegiance_BreakAllegiance {
            add { _OnAllegiance_BreakAllegiance.Subscribe(value); }
            remove { _OnAllegiance_BreakAllegiance.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_BreakAllegiance> _OnAllegiance_BreakAllegiance = new();
    
        /// <summary>
        /// Fired on GameAction type 0x001F Allegiance_UpdateRequest. Allegiance update request
        /// </summary>
        public event EventHandler<Allegiance_UpdateRequest>? OnAllegiance_UpdateRequest {
            add { _OnAllegiance_UpdateRequest.Subscribe(value); }
            remove { _OnAllegiance_UpdateRequest.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_UpdateRequest> _OnAllegiance_UpdateRequest = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0025 Social_ClearFriends. Clears friend list
        /// </summary>
        public event EventHandler<Social_ClearFriends>? OnSocial_ClearFriends {
            add { _OnSocial_ClearFriends.Subscribe(value); }
            remove { _OnSocial_ClearFriends.Unsubscribe(value); }
        }
        private readonly WeakEvent<Social_ClearFriends> _OnSocial_ClearFriends = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0026 Character_TeleToPKLArena. Teleport to the PKLite Arena
        /// </summary>
        public event EventHandler<Character_TeleToPKLArena>? OnCharacter_TeleToPKLArena {
            add { _OnCharacter_TeleToPKLArena.Subscribe(value); }
            remove { _OnCharacter_TeleToPKLArena.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_TeleToPKLArena> _OnCharacter_TeleToPKLArena = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0027 Character_TeleToPKArena. Teleport to the PK Arena
        /// </summary>
        public event EventHandler<Character_TeleToPKArena>? OnCharacter_TeleToPKArena {
            add { _OnCharacter_TeleToPKArena.Subscribe(value); }
            remove { _OnCharacter_TeleToPKArena.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_TeleToPKArena> _OnCharacter_TeleToPKArena = new();
    
        /// <summary>
        /// Fired on GameAction type 0x002C Social_SetDisplayCharacterTitle. Sets a character's display title
        /// </summary>
        public event EventHandler<Social_SetDisplayCharacterTitle>? OnSocial_SetDisplayCharacterTitle {
            add { _OnSocial_SetDisplayCharacterTitle.Subscribe(value); }
            remove { _OnSocial_SetDisplayCharacterTitle.Unsubscribe(value); }
        }
        private readonly WeakEvent<Social_SetDisplayCharacterTitle> _OnSocial_SetDisplayCharacterTitle = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0030 Allegiance_QueryAllegianceName. Query the allegiance name
        /// </summary>
        public event EventHandler<Allegiance_QueryAllegianceName>? OnAllegiance_QueryAllegianceName {
            add { _OnAllegiance_QueryAllegianceName.Subscribe(value); }
            remove { _OnAllegiance_QueryAllegianceName.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_QueryAllegianceName> _OnAllegiance_QueryAllegianceName = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0031 Allegiance_ClearAllegianceName. Clears the allegiance name
        /// </summary>
        public event EventHandler<Allegiance_ClearAllegianceName>? OnAllegiance_ClearAllegianceName {
            add { _OnAllegiance_ClearAllegianceName.Subscribe(value); }
            remove { _OnAllegiance_ClearAllegianceName.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_ClearAllegianceName> _OnAllegiance_ClearAllegianceName = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0032 Communication_TalkDirect. Direct message by Id
        /// </summary>
        public event EventHandler<Communication_TalkDirect>? OnCommunication_TalkDirect {
            add { _OnCommunication_TalkDirect.Subscribe(value); }
            remove { _OnCommunication_TalkDirect.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_TalkDirect> _OnCommunication_TalkDirect = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0033 Allegiance_SetAllegianceName. Sets the allegiance name
        /// </summary>
        public event EventHandler<Allegiance_SetAllegianceName>? OnAllegiance_SetAllegianceName {
            add { _OnAllegiance_SetAllegianceName.Subscribe(value); }
            remove { _OnAllegiance_SetAllegianceName.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_SetAllegianceName> _OnAllegiance_SetAllegianceName = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0035 Inventory_UseWithTargetEvent. Attempt to use an item with a target.
        /// </summary>
        public event EventHandler<Inventory_UseWithTargetEvent>? OnInventory_UseWithTargetEvent {
            add { _OnInventory_UseWithTargetEvent.Subscribe(value); }
            remove { _OnInventory_UseWithTargetEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Inventory_UseWithTargetEvent> _OnInventory_UseWithTargetEvent = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0036 Inventory_UseEvent. Attempt to use an item.
        /// </summary>
        public event EventHandler<Inventory_UseEvent>? OnInventory_UseEvent {
            add { _OnInventory_UseEvent.Subscribe(value); }
            remove { _OnInventory_UseEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Inventory_UseEvent> _OnInventory_UseEvent = new();
    
        /// <summary>
        /// Fired on GameAction type 0x003B Allegiance_SetAllegianceOfficer. Sets an allegiance officer
        /// </summary>
        public event EventHandler<Allegiance_SetAllegianceOfficer>? OnAllegiance_SetAllegianceOfficer {
            add { _OnAllegiance_SetAllegianceOfficer.Subscribe(value); }
            remove { _OnAllegiance_SetAllegianceOfficer.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_SetAllegianceOfficer> _OnAllegiance_SetAllegianceOfficer = new();
    
        /// <summary>
        /// Fired on GameAction type 0x003C Allegiance_SetAllegianceOfficerTitle. Sets an allegiance officer title for a given level
        /// </summary>
        public event EventHandler<Allegiance_SetAllegianceOfficerTitle>? OnAllegiance_SetAllegianceOfficerTitle {
            add { _OnAllegiance_SetAllegianceOfficerTitle.Subscribe(value); }
            remove { _OnAllegiance_SetAllegianceOfficerTitle.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_SetAllegianceOfficerTitle> _OnAllegiance_SetAllegianceOfficerTitle = new();
    
        /// <summary>
        /// Fired on GameAction type 0x003D Allegiance_ListAllegianceOfficerTitles. List the allegiance officer titles
        /// </summary>
        public event EventHandler<Allegiance_ListAllegianceOfficerTitles>? OnAllegiance_ListAllegianceOfficerTitles {
            add { _OnAllegiance_ListAllegianceOfficerTitles.Subscribe(value); }
            remove { _OnAllegiance_ListAllegianceOfficerTitles.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_ListAllegianceOfficerTitles> _OnAllegiance_ListAllegianceOfficerTitles = new();
    
        /// <summary>
        /// Fired on GameAction type 0x003E Allegiance_ClearAllegianceOfficerTitles. Clears the allegiance officer titles
        /// </summary>
        public event EventHandler<Allegiance_ClearAllegianceOfficerTitles>? OnAllegiance_ClearAllegianceOfficerTitles {
            add { _OnAllegiance_ClearAllegianceOfficerTitles.Subscribe(value); }
            remove { _OnAllegiance_ClearAllegianceOfficerTitles.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_ClearAllegianceOfficerTitles> _OnAllegiance_ClearAllegianceOfficerTitles = new();
    
        /// <summary>
        /// Fired on GameAction type 0x003F Allegiance_DoAllegianceLockAction. Perform the allegiance lock action
        /// </summary>
        public event EventHandler<Allegiance_DoAllegianceLockAction>? OnAllegiance_DoAllegianceLockAction {
            add { _OnAllegiance_DoAllegianceLockAction.Subscribe(value); }
            remove { _OnAllegiance_DoAllegianceLockAction.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_DoAllegianceLockAction> _OnAllegiance_DoAllegianceLockAction = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0040 Allegiance_SetAllegianceApprovedVassal. Sets a person as an approved vassal
        /// </summary>
        public event EventHandler<Allegiance_SetAllegianceApprovedVassal>? OnAllegiance_SetAllegianceApprovedVassal {
            add { _OnAllegiance_SetAllegianceApprovedVassal.Subscribe(value); }
            remove { _OnAllegiance_SetAllegianceApprovedVassal.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_SetAllegianceApprovedVassal> _OnAllegiance_SetAllegianceApprovedVassal = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0041 Allegiance_AllegianceChatGag. Gags a person in allegiance chat
        /// </summary>
        public event EventHandler<Allegiance_AllegianceChatGag>? OnAllegiance_AllegianceChatGag {
            add { _OnAllegiance_AllegianceChatGag.Subscribe(value); }
            remove { _OnAllegiance_AllegianceChatGag.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_AllegianceChatGag> _OnAllegiance_AllegianceChatGag = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0042 Allegiance_DoAllegianceHouseAction. Perform the allegiance house action
        /// </summary>
        public event EventHandler<Allegiance_DoAllegianceHouseAction>? OnAllegiance_DoAllegianceHouseAction {
            add { _OnAllegiance_DoAllegianceHouseAction.Subscribe(value); }
            remove { _OnAllegiance_DoAllegianceHouseAction.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_DoAllegianceHouseAction> _OnAllegiance_DoAllegianceHouseAction = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0044 Train_TrainAttribute2nd. Spend XP to raise a vital.
        /// </summary>
        public event EventHandler<Train_TrainAttribute2nd>? OnTrain_TrainAttribute2nd {
            add { _OnTrain_TrainAttribute2nd.Subscribe(value); }
            remove { _OnTrain_TrainAttribute2nd.Unsubscribe(value); }
        }
        private readonly WeakEvent<Train_TrainAttribute2nd> _OnTrain_TrainAttribute2nd = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0045 Train_TrainAttribute. Spend XP to raise an attribute.
        /// </summary>
        public event EventHandler<Train_TrainAttribute>? OnTrain_TrainAttribute {
            add { _OnTrain_TrainAttribute.Subscribe(value); }
            remove { _OnTrain_TrainAttribute.Unsubscribe(value); }
        }
        private readonly WeakEvent<Train_TrainAttribute> _OnTrain_TrainAttribute = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0046 Train_TrainSkill. Spend XP to raise a skill.
        /// </summary>
        public event EventHandler<Train_TrainSkill>? OnTrain_TrainSkill {
            add { _OnTrain_TrainSkill.Subscribe(value); }
            remove { _OnTrain_TrainSkill.Unsubscribe(value); }
        }
        private readonly WeakEvent<Train_TrainSkill> _OnTrain_TrainSkill = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0047 Train_TrainSkillAdvancementClass. Spend skill credits to train a skill.
        /// </summary>
        public event EventHandler<Train_TrainSkillAdvancementClass>? OnTrain_TrainSkillAdvancementClass {
            add { _OnTrain_TrainSkillAdvancementClass.Subscribe(value); }
            remove { _OnTrain_TrainSkillAdvancementClass.Unsubscribe(value); }
        }
        private readonly WeakEvent<Train_TrainSkillAdvancementClass> _OnTrain_TrainSkillAdvancementClass = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0048 Magic_CastUntargetedSpell. Cast a spell with no target.
        /// </summary>
        public event EventHandler<Magic_CastUntargetedSpell>? OnMagic_CastUntargetedSpell {
            add { _OnMagic_CastUntargetedSpell.Subscribe(value); }
            remove { _OnMagic_CastUntargetedSpell.Unsubscribe(value); }
        }
        private readonly WeakEvent<Magic_CastUntargetedSpell> _OnMagic_CastUntargetedSpell = new();
    
        /// <summary>
        /// Fired on GameAction type 0x004A Magic_CastTargetedSpell. Cast a spell on a target
        /// </summary>
        public event EventHandler<Magic_CastTargetedSpell>? OnMagic_CastTargetedSpell {
            add { _OnMagic_CastTargetedSpell.Subscribe(value); }
            remove { _OnMagic_CastTargetedSpell.Unsubscribe(value); }
        }
        private readonly WeakEvent<Magic_CastTargetedSpell> _OnMagic_CastTargetedSpell = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0053 Combat_ChangeCombatMode. Changes the combat mode
        /// </summary>
        public event EventHandler<Combat_ChangeCombatMode>? OnCombat_ChangeCombatMode {
            add { _OnCombat_ChangeCombatMode.Subscribe(value); }
            remove { _OnCombat_ChangeCombatMode.Unsubscribe(value); }
        }
        private readonly WeakEvent<Combat_ChangeCombatMode> _OnCombat_ChangeCombatMode = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0054 Inventory_StackableMerge. Merges one stack with another
        /// </summary>
        public event EventHandler<Inventory_StackableMerge>? OnInventory_StackableMerge {
            add { _OnInventory_StackableMerge.Subscribe(value); }
            remove { _OnInventory_StackableMerge.Unsubscribe(value); }
        }
        private readonly WeakEvent<Inventory_StackableMerge> _OnInventory_StackableMerge = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0055 Inventory_StackableSplitToContainer. Split a stack and place it into a container
        /// </summary>
        public event EventHandler<Inventory_StackableSplitToContainer>? OnInventory_StackableSplitToContainer {
            add { _OnInventory_StackableSplitToContainer.Subscribe(value); }
            remove { _OnInventory_StackableSplitToContainer.Unsubscribe(value); }
        }
        private readonly WeakEvent<Inventory_StackableSplitToContainer> _OnInventory_StackableSplitToContainer = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0056 Inventory_StackableSplitTo3D. Split a stack and place it into the world
        /// </summary>
        public event EventHandler<Inventory_StackableSplitTo3D>? OnInventory_StackableSplitTo3D {
            add { _OnInventory_StackableSplitTo3D.Subscribe(value); }
            remove { _OnInventory_StackableSplitTo3D.Unsubscribe(value); }
        }
        private readonly WeakEvent<Inventory_StackableSplitTo3D> _OnInventory_StackableSplitTo3D = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0058 Communication_ModifyCharacterSquelch. Changes an account squelch
        /// </summary>
        public event EventHandler<Communication_ModifyCharacterSquelch>? OnCommunication_ModifyCharacterSquelch {
            add { _OnCommunication_ModifyCharacterSquelch.Subscribe(value); }
            remove { _OnCommunication_ModifyCharacterSquelch.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_ModifyCharacterSquelch> _OnCommunication_ModifyCharacterSquelch = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0059 Communication_ModifyAccountSquelch. Changes an account squelch
        /// </summary>
        public event EventHandler<Communication_ModifyAccountSquelch>? OnCommunication_ModifyAccountSquelch {
            add { _OnCommunication_ModifyAccountSquelch.Subscribe(value); }
            remove { _OnCommunication_ModifyAccountSquelch.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_ModifyAccountSquelch> _OnCommunication_ModifyAccountSquelch = new();
    
        /// <summary>
        /// Fired on GameAction type 0x005B Communication_ModifyGlobalSquelch. Changes the global filters, /filter -type as well as /chat and /notell
        /// </summary>
        public event EventHandler<Communication_ModifyGlobalSquelch>? OnCommunication_ModifyGlobalSquelch {
            add { _OnCommunication_ModifyGlobalSquelch.Subscribe(value); }
            remove { _OnCommunication_ModifyGlobalSquelch.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_ModifyGlobalSquelch> _OnCommunication_ModifyGlobalSquelch = new();
    
        /// <summary>
        /// Fired on GameAction type 0x005D Communication_TalkDirectByName. Direct message by name
        /// </summary>
        public event EventHandler<Communication_TalkDirectByName>? OnCommunication_TalkDirectByName {
            add { _OnCommunication_TalkDirectByName.Subscribe(value); }
            remove { _OnCommunication_TalkDirectByName.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_TalkDirectByName> _OnCommunication_TalkDirectByName = new();
    
        /// <summary>
        /// Fired on GameAction type 0x005F Vendor_Buy. Buy from a vendor
        /// </summary>
        public event EventHandler<Vendor_Buy>? OnVendor_Buy {
            add { _OnVendor_Buy.Subscribe(value); }
            remove { _OnVendor_Buy.Unsubscribe(value); }
        }
        private readonly WeakEvent<Vendor_Buy> _OnVendor_Buy = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0060 Vendor_Sell. Sell to a vendor
        /// </summary>
        public event EventHandler<Vendor_Sell>? OnVendor_Sell {
            add { _OnVendor_Sell.Subscribe(value); }
            remove { _OnVendor_Sell.Unsubscribe(value); }
        }
        private readonly WeakEvent<Vendor_Sell> _OnVendor_Sell = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0063 Character_TeleToLifestone. Teleport to your lifestone. (/lifestone)
        /// </summary>
        public event EventHandler<Character_TeleToLifestone>? OnCharacter_TeleToLifestone {
            add { _OnCharacter_TeleToLifestone.Subscribe(value); }
            remove { _OnCharacter_TeleToLifestone.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_TeleToLifestone> _OnCharacter_TeleToLifestone = new();
    
        /// <summary>
        /// Fired on GameAction type 0x00A1 Character_LoginCompleteNotification. The client is ready for the character to materialize after portalling or logging on.
        /// </summary>
        public event EventHandler<Character_LoginCompleteNotification>? OnCharacter_LoginCompleteNotification {
            add { _OnCharacter_LoginCompleteNotification.Subscribe(value); }
            remove { _OnCharacter_LoginCompleteNotification.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_LoginCompleteNotification> _OnCharacter_LoginCompleteNotification = new();
    
        /// <summary>
        /// Fired on GameAction type 0x00A2 Fellowship_Create. Create a fellowship
        /// </summary>
        public event EventHandler<Fellowship_Create>? OnFellowship_Create {
            add { _OnFellowship_Create.Subscribe(value); }
            remove { _OnFellowship_Create.Unsubscribe(value); }
        }
        private readonly WeakEvent<Fellowship_Create> _OnFellowship_Create = new();
    
        /// <summary>
        /// Fired on GameAction type 0x00A3 Fellowship_Quit. Quit the fellowship
        /// </summary>
        public event EventHandler<Fellowship_Quit>? OnFellowship_Quit {
            add { _OnFellowship_Quit.Subscribe(value); }
            remove { _OnFellowship_Quit.Unsubscribe(value); }
        }
        private readonly WeakEvent<Fellowship_Quit> _OnFellowship_Quit = new();
    
        /// <summary>
        /// Fired on GameAction type 0x00A4 Fellowship_Dismiss. Dismiss a player from the fellowship
        /// </summary>
        public event EventHandler<Fellowship_Dismiss>? OnFellowship_Dismiss {
            add { _OnFellowship_Dismiss.Subscribe(value); }
            remove { _OnFellowship_Dismiss.Unsubscribe(value); }
        }
        private readonly WeakEvent<Fellowship_Dismiss> _OnFellowship_Dismiss = new();
    
        /// <summary>
        /// Fired on GameAction type 0x00A5 Fellowship_Recruit. Recruit a player to the fellowship
        /// </summary>
        public event EventHandler<Fellowship_Recruit>? OnFellowship_Recruit {
            add { _OnFellowship_Recruit.Subscribe(value); }
            remove { _OnFellowship_Recruit.Unsubscribe(value); }
        }
        private readonly WeakEvent<Fellowship_Recruit> _OnFellowship_Recruit = new();
    
        /// <summary>
        /// Fired on GameAction type 0x00A6 Fellowship_UpdateRequest. Update request
        /// </summary>
        public event EventHandler<Fellowship_UpdateRequest>? OnFellowship_UpdateRequest {
            add { _OnFellowship_UpdateRequest.Subscribe(value); }
            remove { _OnFellowship_UpdateRequest.Unsubscribe(value); }
        }
        private readonly WeakEvent<Fellowship_UpdateRequest> _OnFellowship_UpdateRequest = new();
    
        /// <summary>
        /// Fired on GameAction type 0x00AA Writing_BookAddPage. Request update to book data (seems to be sent after failed add page)
        /// </summary>
        public event EventHandler<Writing_BookAddPage>? OnWriting_BookAddPage {
            add { _OnWriting_BookAddPage.Subscribe(value); }
            remove { _OnWriting_BookAddPage.Unsubscribe(value); }
        }
        private readonly WeakEvent<Writing_BookAddPage> _OnWriting_BookAddPage = new();
    
        /// <summary>
        /// Fired on GameAction type 0x00AB Writing_BookModifyPage. Updates a page in a book
        /// </summary>
        public event EventHandler<Writing_BookModifyPage>? OnWriting_BookModifyPage {
            add { _OnWriting_BookModifyPage.Subscribe(value); }
            remove { _OnWriting_BookModifyPage.Unsubscribe(value); }
        }
        private readonly WeakEvent<Writing_BookModifyPage> _OnWriting_BookModifyPage = new();
    
        /// <summary>
        /// Fired on GameAction type 0x00AC Writing_BookData. Add a page to a book
        /// </summary>
        public event EventHandler<Writing_BookData>? OnWriting_BookData {
            add { _OnWriting_BookData.Subscribe(value); }
            remove { _OnWriting_BookData.Unsubscribe(value); }
        }
        private readonly WeakEvent<Writing_BookData> _OnWriting_BookData = new();
    
        /// <summary>
        /// Fired on GameAction type 0x00AD Writing_BookDeletePage. Removes a page from a book
        /// </summary>
        public event EventHandler<Writing_BookDeletePage>? OnWriting_BookDeletePage {
            add { _OnWriting_BookDeletePage.Subscribe(value); }
            remove { _OnWriting_BookDeletePage.Unsubscribe(value); }
        }
        private readonly WeakEvent<Writing_BookDeletePage> _OnWriting_BookDeletePage = new();
    
        /// <summary>
        /// Fired on GameAction type 0x00AE Writing_BookPageData. Requests data for a page in a book
        /// </summary>
        public event EventHandler<Writing_BookPageData>? OnWriting_BookPageData {
            add { _OnWriting_BookPageData.Subscribe(value); }
            remove { _OnWriting_BookPageData.Unsubscribe(value); }
        }
        private readonly WeakEvent<Writing_BookPageData> _OnWriting_BookPageData = new();
    
        /// <summary>
        /// Fired on GameAction type 0x00BF Writing_SetInscription. Sets the inscription on an object
        /// </summary>
        public event EventHandler<Writing_SetInscription>? OnWriting_SetInscription {
            add { _OnWriting_SetInscription.Subscribe(value); }
            remove { _OnWriting_SetInscription.Unsubscribe(value); }
        }
        private readonly WeakEvent<Writing_SetInscription> _OnWriting_SetInscription = new();
    
        /// <summary>
        /// Fired on GameAction type 0x00C8 Item_Appraise. Appraise something
        /// </summary>
        public event EventHandler<Item_Appraise>? OnItem_Appraise {
            add { _OnItem_Appraise.Subscribe(value); }
            remove { _OnItem_Appraise.Unsubscribe(value); }
        }
        private readonly WeakEvent<Item_Appraise> _OnItem_Appraise = new();
    
        /// <summary>
        /// Fired on GameAction type 0x00CD Inventory_GiveObjectRequest. Give an item to someone.
        /// </summary>
        public event EventHandler<Inventory_GiveObjectRequest>? OnInventory_GiveObjectRequest {
            add { _OnInventory_GiveObjectRequest.Subscribe(value); }
            remove { _OnInventory_GiveObjectRequest.Unsubscribe(value); }
        }
        private readonly WeakEvent<Inventory_GiveObjectRequest> _OnInventory_GiveObjectRequest = new();
    
        /// <summary>
        /// Fired on GameAction type 0x00D6 Advocate_Teleport. Advocate Teleport
        /// </summary>
        public event EventHandler<Advocate_Teleport>? OnAdvocate_Teleport {
            add { _OnAdvocate_Teleport.Subscribe(value); }
            remove { _OnAdvocate_Teleport.Unsubscribe(value); }
        }
        private readonly WeakEvent<Advocate_Teleport> _OnAdvocate_Teleport = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0140 Character_AbuseLogRequest. Sends an abuse report.
        /// </summary>
        public event EventHandler<Character_AbuseLogRequest>? OnCharacter_AbuseLogRequest {
            add { _OnCharacter_AbuseLogRequest.Subscribe(value); }
            remove { _OnCharacter_AbuseLogRequest.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_AbuseLogRequest> _OnCharacter_AbuseLogRequest = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0145 Communication_AddToChannel. Joins a chat channel
        /// </summary>
        public event EventHandler<Communication_AddToChannel>? OnCommunication_AddToChannel {
            add { _OnCommunication_AddToChannel.Subscribe(value); }
            remove { _OnCommunication_AddToChannel.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_AddToChannel> _OnCommunication_AddToChannel = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0146 Communication_RemoveFromChannel. Leaves a chat channel
        /// </summary>
        public event EventHandler<Communication_RemoveFromChannel>? OnCommunication_RemoveFromChannel {
            add { _OnCommunication_RemoveFromChannel.Subscribe(value); }
            remove { _OnCommunication_RemoveFromChannel.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_RemoveFromChannel> _OnCommunication_RemoveFromChannel = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0147 Communication_ChannelBroadcast. Sends a message to a chat channel
        /// </summary>
        public event EventHandler<Communication_ChannelBroadcast>? OnCommunication_ChannelBroadcast {
            add { _OnCommunication_ChannelBroadcast.Subscribe(value); }
            remove { _OnCommunication_ChannelBroadcast.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_ChannelBroadcast> _OnCommunication_ChannelBroadcast = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0148 Communication_ChannelList. 
        /// </summary>
        public event EventHandler<Communication_ChannelList>? OnCommunication_ChannelList {
            add { _OnCommunication_ChannelList.Subscribe(value); }
            remove { _OnCommunication_ChannelList.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_ChannelList> _OnCommunication_ChannelList = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0149 Communication_ChannelIndex. Requests a channel index
        /// </summary>
        public event EventHandler<Communication_ChannelIndex>? OnCommunication_ChannelIndex {
            add { _OnCommunication_ChannelIndex.Subscribe(value); }
            remove { _OnCommunication_ChannelIndex.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_ChannelIndex> _OnCommunication_ChannelIndex = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0195 Inventory_NoLongerViewingContents. Stop viewing the contents of a container
        /// </summary>
        public event EventHandler<Inventory_NoLongerViewingContents>? OnInventory_NoLongerViewingContents {
            add { _OnInventory_NoLongerViewingContents.Subscribe(value); }
            remove { _OnInventory_NoLongerViewingContents.Unsubscribe(value); }
        }
        private readonly WeakEvent<Inventory_NoLongerViewingContents> _OnInventory_NoLongerViewingContents = new();
    
        /// <summary>
        /// Fired on GameAction type 0x019B Inventory_StackableSplitToWield. Splits an item to a wield location.
        /// </summary>
        public event EventHandler<Inventory_StackableSplitToWield>? OnInventory_StackableSplitToWield {
            add { _OnInventory_StackableSplitToWield.Subscribe(value); }
            remove { _OnInventory_StackableSplitToWield.Unsubscribe(value); }
        }
        private readonly WeakEvent<Inventory_StackableSplitToWield> _OnInventory_StackableSplitToWield = new();
    
        /// <summary>
        /// Fired on GameAction type 0x019C Character_AddShortCut. Add an item to the shortcut bar.
        /// </summary>
        public event EventHandler<Character_AddShortCut>? OnCharacter_AddShortCut {
            add { _OnCharacter_AddShortCut.Subscribe(value); }
            remove { _OnCharacter_AddShortCut.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_AddShortCut> _OnCharacter_AddShortCut = new();
    
        /// <summary>
        /// Fired on GameAction type 0x019D Character_RemoveShortCut. Remove an item from the shortcut bar.
        /// </summary>
        public event EventHandler<Character_RemoveShortCut>? OnCharacter_RemoveShortCut {
            add { _OnCharacter_RemoveShortCut.Subscribe(value); }
            remove { _OnCharacter_RemoveShortCut.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_RemoveShortCut> _OnCharacter_RemoveShortCut = new();
    
        /// <summary>
        /// Fired on GameAction type 0x01A1 Character_CharacterOptionsEvent. Set multiple character options.
        /// </summary>
        public event EventHandler<Character_CharacterOptionsEvent>? OnCharacter_CharacterOptionsEvent {
            add { _OnCharacter_CharacterOptionsEvent.Subscribe(value); }
            remove { _OnCharacter_CharacterOptionsEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_CharacterOptionsEvent> _OnCharacter_CharacterOptionsEvent = new();
    
        /// <summary>
        /// Fired on GameAction type 0x01A8 Magic_RemoveSpell. Removes a spell from the spell book
        /// </summary>
        public event EventHandler<Magic_RemoveSpell>? OnMagic_RemoveSpell {
            add { _OnMagic_RemoveSpell.Subscribe(value); }
            remove { _OnMagic_RemoveSpell.Unsubscribe(value); }
        }
        private readonly WeakEvent<Magic_RemoveSpell> _OnMagic_RemoveSpell = new();
    
        /// <summary>
        /// Fired on GameAction type 0x01B7 Combat_CancelAttack. Cancels an attack
        /// </summary>
        public event EventHandler<Combat_CancelAttack>? OnCombat_CancelAttack {
            add { _OnCombat_CancelAttack.Subscribe(value); }
            remove { _OnCombat_CancelAttack.Unsubscribe(value); }
        }
        private readonly WeakEvent<Combat_CancelAttack> _OnCombat_CancelAttack = new();
    
        /// <summary>
        /// Fired on GameAction type 0x01BF Combat_QueryHealth. Query's a creatures health
        /// </summary>
        public event EventHandler<Combat_QueryHealth>? OnCombat_QueryHealth {
            add { _OnCombat_QueryHealth.Subscribe(value); }
            remove { _OnCombat_QueryHealth.Unsubscribe(value); }
        }
        private readonly WeakEvent<Combat_QueryHealth> _OnCombat_QueryHealth = new();
    
        /// <summary>
        /// Fired on GameAction type 0x01C2 Character_QueryAge. Query a character's age
        /// </summary>
        public event EventHandler<Character_QueryAge>? OnCharacter_QueryAge {
            add { _OnCharacter_QueryAge.Subscribe(value); }
            remove { _OnCharacter_QueryAge.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_QueryAge> _OnCharacter_QueryAge = new();
    
        /// <summary>
        /// Fired on GameAction type 0x01C4 Character_QueryBirth. Query a character's birth day
        /// </summary>
        public event EventHandler<Character_QueryBirth>? OnCharacter_QueryBirth {
            add { _OnCharacter_QueryBirth.Subscribe(value); }
            remove { _OnCharacter_QueryBirth.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_QueryBirth> _OnCharacter_QueryBirth = new();
    
        /// <summary>
        /// Fired on GameAction type 0x01DF Communication_Emote. Emote message
        /// </summary>
        public event EventHandler<Communication_Emote>? OnCommunication_Emote {
            add { _OnCommunication_Emote.Subscribe(value); }
            remove { _OnCommunication_Emote.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_Emote> _OnCommunication_Emote = new();
    
        /// <summary>
        /// Fired on GameAction type 0x01E1 Communication_SoulEmote. Soul emote message
        /// </summary>
        public event EventHandler<Communication_SoulEmote>? OnCommunication_SoulEmote {
            add { _OnCommunication_SoulEmote.Subscribe(value); }
            remove { _OnCommunication_SoulEmote.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_SoulEmote> _OnCommunication_SoulEmote = new();
    
        /// <summary>
        /// Fired on GameAction type 0x01E3 Character_AddSpellFavorite. Add a spell to a spell bar.
        /// </summary>
        public event EventHandler<Character_AddSpellFavorite>? OnCharacter_AddSpellFavorite {
            add { _OnCharacter_AddSpellFavorite.Subscribe(value); }
            remove { _OnCharacter_AddSpellFavorite.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_AddSpellFavorite> _OnCharacter_AddSpellFavorite = new();
    
        /// <summary>
        /// Fired on GameAction type 0x01E4 Character_RemoveSpellFavorite. Remove a spell from a spell bar.
        /// </summary>
        public event EventHandler<Character_RemoveSpellFavorite>? OnCharacter_RemoveSpellFavorite {
            add { _OnCharacter_RemoveSpellFavorite.Subscribe(value); }
            remove { _OnCharacter_RemoveSpellFavorite.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_RemoveSpellFavorite> _OnCharacter_RemoveSpellFavorite = new();
    
        /// <summary>
        /// Fired on GameAction type 0x01E9 Character_RequestPing. Request a ping
        /// </summary>
        public event EventHandler<Character_RequestPing>? OnCharacter_RequestPing {
            add { _OnCharacter_RequestPing.Subscribe(value); }
            remove { _OnCharacter_RequestPing.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_RequestPing> _OnCharacter_RequestPing = new();
    
        /// <summary>
        /// Fired on GameAction type 0x01F6 Trade_OpenTradeNegotiations. Starts trading with another player.
        /// </summary>
        public event EventHandler<Trade_OpenTradeNegotiations>? OnTrade_OpenTradeNegotiations {
            add { _OnTrade_OpenTradeNegotiations.Subscribe(value); }
            remove { _OnTrade_OpenTradeNegotiations.Unsubscribe(value); }
        }
        private readonly WeakEvent<Trade_OpenTradeNegotiations> _OnTrade_OpenTradeNegotiations = new();
    
        /// <summary>
        /// Fired on GameAction type 0x01F7 Trade_CloseTradeNegotiations. Ends trading, when trade window is closed?
        /// </summary>
        public event EventHandler<Trade_CloseTradeNegotiations>? OnTrade_CloseTradeNegotiations {
            add { _OnTrade_CloseTradeNegotiations.Subscribe(value); }
            remove { _OnTrade_CloseTradeNegotiations.Unsubscribe(value); }
        }
        private readonly WeakEvent<Trade_CloseTradeNegotiations> _OnTrade_CloseTradeNegotiations = new();
    
        /// <summary>
        /// Fired on GameAction type 0x01F8 Trade_AddToTrade. Adds an object to the trade.
        /// </summary>
        public event EventHandler<Trade_AddToTrade>? OnTrade_AddToTrade {
            add { _OnTrade_AddToTrade.Subscribe(value); }
            remove { _OnTrade_AddToTrade.Unsubscribe(value); }
        }
        private readonly WeakEvent<Trade_AddToTrade> _OnTrade_AddToTrade = new();
    
        /// <summary>
        /// Fired on GameAction type 0x01FA Trade_AcceptTrade. Accepts a trade.
        /// </summary>
        public event EventHandler<Trade_AcceptTrade>? OnTrade_AcceptTrade {
            add { _OnTrade_AcceptTrade.Subscribe(value); }
            remove { _OnTrade_AcceptTrade.Unsubscribe(value); }
        }
        private readonly WeakEvent<Trade_AcceptTrade> _OnTrade_AcceptTrade = new();
    
        /// <summary>
        /// Fired on GameAction type 0x01FB Trade_DeclineTrade. Declines a trade, when cancel is clicked?
        /// </summary>
        public event EventHandler<Trade_DeclineTrade>? OnTrade_DeclineTrade {
            add { _OnTrade_DeclineTrade.Subscribe(value); }
            remove { _OnTrade_DeclineTrade.Unsubscribe(value); }
        }
        private readonly WeakEvent<Trade_DeclineTrade> _OnTrade_DeclineTrade = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0204 Trade_ResetTrade. Resets the trade, when clear all is clicked?
        /// </summary>
        public event EventHandler<Trade_ResetTrade>? OnTrade_ResetTrade {
            add { _OnTrade_ResetTrade.Subscribe(value); }
            remove { _OnTrade_ResetTrade.Unsubscribe(value); }
        }
        private readonly WeakEvent<Trade_ResetTrade> _OnTrade_ResetTrade = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0216 Character_ClearPlayerConsentList. Clears the player's corpse looting consent list, /consent clear
        /// </summary>
        public event EventHandler<Character_ClearPlayerConsentList>? OnCharacter_ClearPlayerConsentList {
            add { _OnCharacter_ClearPlayerConsentList.Subscribe(value); }
            remove { _OnCharacter_ClearPlayerConsentList.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_ClearPlayerConsentList> _OnCharacter_ClearPlayerConsentList = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0217 Character_DisplayPlayerConsentList. Display the player's corpse looting consent list, /consent who 
        /// </summary>
        public event EventHandler<Character_DisplayPlayerConsentList>? OnCharacter_DisplayPlayerConsentList {
            add { _OnCharacter_DisplayPlayerConsentList.Subscribe(value); }
            remove { _OnCharacter_DisplayPlayerConsentList.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_DisplayPlayerConsentList> _OnCharacter_DisplayPlayerConsentList = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0218 Character_RemoveFromPlayerConsentList. Remove your corpse looting permission for the given player, /consent remove 
        /// </summary>
        public event EventHandler<Character_RemoveFromPlayerConsentList>? OnCharacter_RemoveFromPlayerConsentList {
            add { _OnCharacter_RemoveFromPlayerConsentList.Subscribe(value); }
            remove { _OnCharacter_RemoveFromPlayerConsentList.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_RemoveFromPlayerConsentList> _OnCharacter_RemoveFromPlayerConsentList = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0219 Character_AddPlayerPermission. Grants a player corpse looting permission, /permit add
        /// </summary>
        public event EventHandler<Character_AddPlayerPermission>? OnCharacter_AddPlayerPermission {
            add { _OnCharacter_AddPlayerPermission.Subscribe(value); }
            remove { _OnCharacter_AddPlayerPermission.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_AddPlayerPermission> _OnCharacter_AddPlayerPermission = new();
    
        /// <summary>
        /// Fired on GameAction type 0x021C House_BuyHouse. Buy a house
        /// </summary>
        public event EventHandler<House_BuyHouse>? OnHouse_BuyHouse {
            add { _OnHouse_BuyHouse.Subscribe(value); }
            remove { _OnHouse_BuyHouse.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_BuyHouse> _OnHouse_BuyHouse = new();
    
        /// <summary>
        /// Fired on GameAction type 0x021E House_QueryHouse. Query your house info, during signin
        /// </summary>
        public event EventHandler<House_QueryHouse>? OnHouse_QueryHouse {
            add { _OnHouse_QueryHouse.Subscribe(value); }
            remove { _OnHouse_QueryHouse.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_QueryHouse> _OnHouse_QueryHouse = new();
    
        /// <summary>
        /// Fired on GameAction type 0x021F House_AbandonHouse. Abandons your house
        /// </summary>
        public event EventHandler<House_AbandonHouse>? OnHouse_AbandonHouse {
            add { _OnHouse_AbandonHouse.Subscribe(value); }
            remove { _OnHouse_AbandonHouse.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_AbandonHouse> _OnHouse_AbandonHouse = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0220 Character_RemovePlayerPermission. Revokes a player's corpse looting permission, /permit remove
        /// </summary>
        public event EventHandler<Character_RemovePlayerPermission>? OnCharacter_RemovePlayerPermission {
            add { _OnCharacter_RemovePlayerPermission.Subscribe(value); }
            remove { _OnCharacter_RemovePlayerPermission.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_RemovePlayerPermission> _OnCharacter_RemovePlayerPermission = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0221 House_RentHouse. Pay rent for a house
        /// </summary>
        public event EventHandler<House_RentHouse>? OnHouse_RentHouse {
            add { _OnHouse_RentHouse.Subscribe(value); }
            remove { _OnHouse_RentHouse.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_RentHouse> _OnHouse_RentHouse = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0224 Character_SetDesiredComponentLevel. Sets a new fill complevel for a component
        /// </summary>
        public event EventHandler<Character_SetDesiredComponentLevel>? OnCharacter_SetDesiredComponentLevel {
            add { _OnCharacter_SetDesiredComponentLevel.Subscribe(value); }
            remove { _OnCharacter_SetDesiredComponentLevel.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_SetDesiredComponentLevel> _OnCharacter_SetDesiredComponentLevel = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0245 House_AddPermanentGuest. Adds a guest to your house guest list
        /// </summary>
        public event EventHandler<House_AddPermanentGuest>? OnHouse_AddPermanentGuest {
            add { _OnHouse_AddPermanentGuest.Subscribe(value); }
            remove { _OnHouse_AddPermanentGuest.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_AddPermanentGuest> _OnHouse_AddPermanentGuest = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0246 House_RemovePermanentGuest. Removes a specific player from your house guest list, /house guest remove
        /// </summary>
        public event EventHandler<House_RemovePermanentGuest>? OnHouse_RemovePermanentGuest {
            add { _OnHouse_RemovePermanentGuest.Subscribe(value); }
            remove { _OnHouse_RemovePermanentGuest.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_RemovePermanentGuest> _OnHouse_RemovePermanentGuest = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0247 House_SetOpenHouseStatus. Sets your house open status
        /// </summary>
        public event EventHandler<House_SetOpenHouseStatus>? OnHouse_SetOpenHouseStatus {
            add { _OnHouse_SetOpenHouseStatus.Subscribe(value); }
            remove { _OnHouse_SetOpenHouseStatus.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_SetOpenHouseStatus> _OnHouse_SetOpenHouseStatus = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0249 House_ChangeStoragePermission. Changes a specific players storage permission, /house storage add/remove
        /// </summary>
        public event EventHandler<House_ChangeStoragePermission>? OnHouse_ChangeStoragePermission {
            add { _OnHouse_ChangeStoragePermission.Subscribe(value); }
            remove { _OnHouse_ChangeStoragePermission.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_ChangeStoragePermission> _OnHouse_ChangeStoragePermission = new();
    
        /// <summary>
        /// Fired on GameAction type 0x024A House_BootSpecificHouseGuest. Boots a specific player from your house /house boot
        /// </summary>
        public event EventHandler<House_BootSpecificHouseGuest>? OnHouse_BootSpecificHouseGuest {
            add { _OnHouse_BootSpecificHouseGuest.Subscribe(value); }
            remove { _OnHouse_BootSpecificHouseGuest.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_BootSpecificHouseGuest> _OnHouse_BootSpecificHouseGuest = new();
    
        /// <summary>
        /// Fired on GameAction type 0x024C House_RemoveAllStoragePermission. Removes all storage permissions, /house storage remove_all
        /// </summary>
        public event EventHandler<House_RemoveAllStoragePermission>? OnHouse_RemoveAllStoragePermission {
            add { _OnHouse_RemoveAllStoragePermission.Subscribe(value); }
            remove { _OnHouse_RemoveAllStoragePermission.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_RemoveAllStoragePermission> _OnHouse_RemoveAllStoragePermission = new();
    
        /// <summary>
        /// Fired on GameAction type 0x024D House_RequestFullGuestList. Requests your full guest list, /house guest list
        /// </summary>
        public event EventHandler<House_RequestFullGuestList>? OnHouse_RequestFullGuestList {
            add { _OnHouse_RequestFullGuestList.Subscribe(value); }
            remove { _OnHouse_RequestFullGuestList.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_RequestFullGuestList> _OnHouse_RequestFullGuestList = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0254 Allegiance_SetMotd. Sets the allegiance message of the day, /allegiance motd set
        /// </summary>
        public event EventHandler<Allegiance_SetMotd>? OnAllegiance_SetMotd {
            add { _OnAllegiance_SetMotd.Subscribe(value); }
            remove { _OnAllegiance_SetMotd.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_SetMotd> _OnAllegiance_SetMotd = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0255 Allegiance_QueryMotd. Query the motd, /allegiance motd
        /// </summary>
        public event EventHandler<Allegiance_QueryMotd>? OnAllegiance_QueryMotd {
            add { _OnAllegiance_QueryMotd.Subscribe(value); }
            remove { _OnAllegiance_QueryMotd.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_QueryMotd> _OnAllegiance_QueryMotd = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0256 Allegiance_ClearMotd. Clear the motd, /allegiance motd clear
        /// </summary>
        public event EventHandler<Allegiance_ClearMotd>? OnAllegiance_ClearMotd {
            add { _OnAllegiance_ClearMotd.Subscribe(value); }
            remove { _OnAllegiance_ClearMotd.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_ClearMotd> _OnAllegiance_ClearMotd = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0258 House_QueryLord. Gets SlumLord info, sent after getting a failed house transaction
        /// </summary>
        public event EventHandler<House_QueryLord>? OnHouse_QueryLord {
            add { _OnHouse_QueryLord.Subscribe(value); }
            remove { _OnHouse_QueryLord.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_QueryLord> _OnHouse_QueryLord = new();
    
        /// <summary>
        /// Fired on GameAction type 0x025C House_AddAllStoragePermission. Adds all to your storage permissions, /house storage add -all
        /// </summary>
        public event EventHandler<House_AddAllStoragePermission>? OnHouse_AddAllStoragePermission {
            add { _OnHouse_AddAllStoragePermission.Subscribe(value); }
            remove { _OnHouse_AddAllStoragePermission.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_AddAllStoragePermission> _OnHouse_AddAllStoragePermission = new();
    
        /// <summary>
        /// Fired on GameAction type 0x025E House_RemoveAllPermanentGuests. Removes all guests, /house guest remove_all
        /// </summary>
        public event EventHandler<House_RemoveAllPermanentGuests>? OnHouse_RemoveAllPermanentGuests {
            add { _OnHouse_RemoveAllPermanentGuests.Subscribe(value); }
            remove { _OnHouse_RemoveAllPermanentGuests.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_RemoveAllPermanentGuests> _OnHouse_RemoveAllPermanentGuests = new();
    
        /// <summary>
        /// Fired on GameAction type 0x025F House_BootEveryone. Boot everyone from your house, /house boot -all
        /// </summary>
        public event EventHandler<House_BootEveryone>? OnHouse_BootEveryone {
            add { _OnHouse_BootEveryone.Subscribe(value); }
            remove { _OnHouse_BootEveryone.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_BootEveryone> _OnHouse_BootEveryone = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0262 House_TeleToHouse. Teleports you to your house, /house recall
        /// </summary>
        public event EventHandler<House_TeleToHouse>? OnHouse_TeleToHouse {
            add { _OnHouse_TeleToHouse.Subscribe(value); }
            remove { _OnHouse_TeleToHouse.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_TeleToHouse> _OnHouse_TeleToHouse = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0263 Item_QueryItemMana. Queries an item's mana
        /// </summary>
        public event EventHandler<Item_QueryItemMana>? OnItem_QueryItemMana {
            add { _OnItem_QueryItemMana.Subscribe(value); }
            remove { _OnItem_QueryItemMana.Unsubscribe(value); }
        }
        private readonly WeakEvent<Item_QueryItemMana> _OnItem_QueryItemMana = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0266 House_SetHooksVisibility. Modify whether house hooks are visibile or not, /house hooks on/off
        /// </summary>
        public event EventHandler<House_SetHooksVisibility>? OnHouse_SetHooksVisibility {
            add { _OnHouse_SetHooksVisibility.Subscribe(value); }
            remove { _OnHouse_SetHooksVisibility.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_SetHooksVisibility> _OnHouse_SetHooksVisibility = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0267 House_ModifyAllegianceGuestPermission. Modify whether allegiance members are guests, /house guest add_allegiance/remove_allegiance
        /// </summary>
        public event EventHandler<House_ModifyAllegianceGuestPermission>? OnHouse_ModifyAllegianceGuestPermission {
            add { _OnHouse_ModifyAllegianceGuestPermission.Subscribe(value); }
            remove { _OnHouse_ModifyAllegianceGuestPermission.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_ModifyAllegianceGuestPermission> _OnHouse_ModifyAllegianceGuestPermission = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0268 House_ModifyAllegianceStoragePermission. Modify whether allegiance members can access storage, /house storage add_allegiance/remove_allegiance
        /// </summary>
        public event EventHandler<House_ModifyAllegianceStoragePermission>? OnHouse_ModifyAllegianceStoragePermission {
            add { _OnHouse_ModifyAllegianceStoragePermission.Subscribe(value); }
            remove { _OnHouse_ModifyAllegianceStoragePermission.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_ModifyAllegianceStoragePermission> _OnHouse_ModifyAllegianceStoragePermission = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0269 Game_Join. Joins a chess game
        /// </summary>
        public event EventHandler<Game_Join>? OnGame_Join {
            add { _OnGame_Join.Subscribe(value); }
            remove { _OnGame_Join.Unsubscribe(value); }
        }
        private readonly WeakEvent<Game_Join> _OnGame_Join = new();
    
        /// <summary>
        /// Fired on GameAction type 0x026A Game_Quit. Quits a chess game
        /// </summary>
        public event EventHandler<Game_Quit>? OnGame_Quit {
            add { _OnGame_Quit.Subscribe(value); }
            remove { _OnGame_Quit.Unsubscribe(value); }
        }
        private readonly WeakEvent<Game_Quit> _OnGame_Quit = new();
    
        /// <summary>
        /// Fired on GameAction type 0x026B Game_Move. Makes a chess move
        /// </summary>
        public event EventHandler<Game_Move>? OnGame_Move {
            add { _OnGame_Move.Subscribe(value); }
            remove { _OnGame_Move.Unsubscribe(value); }
        }
        private readonly WeakEvent<Game_Move> _OnGame_Move = new();
    
        /// <summary>
        /// Fired on GameAction type 0x026D Game_MovePass. Skip a move?
        /// </summary>
        public event EventHandler<Game_MovePass>? OnGame_MovePass {
            add { _OnGame_MovePass.Subscribe(value); }
            remove { _OnGame_MovePass.Unsubscribe(value); }
        }
        private readonly WeakEvent<Game_MovePass> _OnGame_MovePass = new();
    
        /// <summary>
        /// Fired on GameAction type 0x026E Game_Stalemate. Offer or confirm stalemate
        /// </summary>
        public event EventHandler<Game_Stalemate>? OnGame_Stalemate {
            add { _OnGame_Stalemate.Subscribe(value); }
            remove { _OnGame_Stalemate.Unsubscribe(value); }
        }
        private readonly WeakEvent<Game_Stalemate> _OnGame_Stalemate = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0270 House_ListAvailableHouses. Lists available house /house available
        /// </summary>
        public event EventHandler<House_ListAvailableHouses>? OnHouse_ListAvailableHouses {
            add { _OnHouse_ListAvailableHouses.Subscribe(value); }
            remove { _OnHouse_ListAvailableHouses.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_ListAvailableHouses> _OnHouse_ListAvailableHouses = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0275 Character_ConfirmationResponse. Confirms a dialog
        /// </summary>
        public event EventHandler<Character_ConfirmationResponse>? OnCharacter_ConfirmationResponse {
            add { _OnCharacter_ConfirmationResponse.Subscribe(value); }
            remove { _OnCharacter_ConfirmationResponse.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_ConfirmationResponse> _OnCharacter_ConfirmationResponse = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0277 Allegiance_BreakAllegianceBoot. Boots a player from the allegiance, optionally all characters on their account
        /// </summary>
        public event EventHandler<Allegiance_BreakAllegianceBoot>? OnAllegiance_BreakAllegianceBoot {
            add { _OnAllegiance_BreakAllegianceBoot.Subscribe(value); }
            remove { _OnAllegiance_BreakAllegianceBoot.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_BreakAllegianceBoot> _OnAllegiance_BreakAllegianceBoot = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0278 House_TeleToMansion. Teleports player to their allegiance housing, /house mansion_recall
        /// </summary>
        public event EventHandler<House_TeleToMansion>? OnHouse_TeleToMansion {
            add { _OnHouse_TeleToMansion.Subscribe(value); }
            remove { _OnHouse_TeleToMansion.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_TeleToMansion> _OnHouse_TeleToMansion = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0279 Character_Suicide. Player is commiting suicide
        /// </summary>
        public event EventHandler<Character_Suicide>? OnCharacter_Suicide {
            add { _OnCharacter_Suicide.Subscribe(value); }
            remove { _OnCharacter_Suicide.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_Suicide> _OnCharacter_Suicide = new();
    
        /// <summary>
        /// Fired on GameAction type 0x027B Allegiance_AllegianceInfoRequest. Request allegiance info for a player
        /// </summary>
        public event EventHandler<Allegiance_AllegianceInfoRequest>? OnAllegiance_AllegianceInfoRequest {
            add { _OnAllegiance_AllegianceInfoRequest.Subscribe(value); }
            remove { _OnAllegiance_AllegianceInfoRequest.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_AllegianceInfoRequest> _OnAllegiance_AllegianceInfoRequest = new();
    
        /// <summary>
        /// Fired on GameAction type 0x027D Inventory_CreateTinkeringTool. Salvages items
        /// </summary>
        public event EventHandler<Inventory_CreateTinkeringTool>? OnInventory_CreateTinkeringTool {
            add { _OnInventory_CreateTinkeringTool.Subscribe(value); }
            remove { _OnInventory_CreateTinkeringTool.Unsubscribe(value); }
        }
        private readonly WeakEvent<Inventory_CreateTinkeringTool> _OnInventory_CreateTinkeringTool = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0286 Character_SpellbookFilterEvent. Changes the spell book filter
        /// </summary>
        public event EventHandler<Character_SpellbookFilterEvent>? OnCharacter_SpellbookFilterEvent {
            add { _OnCharacter_SpellbookFilterEvent.Subscribe(value); }
            remove { _OnCharacter_SpellbookFilterEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_SpellbookFilterEvent> _OnCharacter_SpellbookFilterEvent = new();
    
        /// <summary>
        /// Fired on GameAction type 0x028D Character_TeleToMarketplace. Teleport to the marketplace
        /// </summary>
        public event EventHandler<Character_TeleToMarketplace>? OnCharacter_TeleToMarketplace {
            add { _OnCharacter_TeleToMarketplace.Subscribe(value); }
            remove { _OnCharacter_TeleToMarketplace.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_TeleToMarketplace> _OnCharacter_TeleToMarketplace = new();
    
        /// <summary>
        /// Fired on GameAction type 0x028F Character_EnterPKLite. Enter PKLite mode
        /// </summary>
        public event EventHandler<Character_EnterPKLite>? OnCharacter_EnterPKLite {
            add { _OnCharacter_EnterPKLite.Subscribe(value); }
            remove { _OnCharacter_EnterPKLite.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_EnterPKLite> _OnCharacter_EnterPKLite = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0290 Fellowship_AssignNewLeader. Fellowship Assign a new leader
        /// </summary>
        public event EventHandler<Fellowship_AssignNewLeader>? OnFellowship_AssignNewLeader {
            add { _OnFellowship_AssignNewLeader.Subscribe(value); }
            remove { _OnFellowship_AssignNewLeader.Unsubscribe(value); }
        }
        private readonly WeakEvent<Fellowship_AssignNewLeader> _OnFellowship_AssignNewLeader = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0291 Fellowship_ChangeFellowOpeness. Fellowship Change openness
        /// </summary>
        public event EventHandler<Fellowship_ChangeFellowOpeness>? OnFellowship_ChangeFellowOpeness {
            add { _OnFellowship_ChangeFellowOpeness.Subscribe(value); }
            remove { _OnFellowship_ChangeFellowOpeness.Unsubscribe(value); }
        }
        private readonly WeakEvent<Fellowship_ChangeFellowOpeness> _OnFellowship_ChangeFellowOpeness = new();
    
        /// <summary>
        /// Fired on GameAction type 0x02A0 Allegiance_AllegianceChatBoot. Boots a player from the allegiance chat
        /// </summary>
        public event EventHandler<Allegiance_AllegianceChatBoot>? OnAllegiance_AllegianceChatBoot {
            add { _OnAllegiance_AllegianceChatBoot.Subscribe(value); }
            remove { _OnAllegiance_AllegianceChatBoot.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_AllegianceChatBoot> _OnAllegiance_AllegianceChatBoot = new();
    
        /// <summary>
        /// Fired on GameAction type 0x02A1 Allegiance_AddAllegianceBan. Bans a player from the allegiance
        /// </summary>
        public event EventHandler<Allegiance_AddAllegianceBan>? OnAllegiance_AddAllegianceBan {
            add { _OnAllegiance_AddAllegianceBan.Subscribe(value); }
            remove { _OnAllegiance_AddAllegianceBan.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_AddAllegianceBan> _OnAllegiance_AddAllegianceBan = new();
    
        /// <summary>
        /// Fired on GameAction type 0x02A2 Allegiance_RemoveAllegianceBan. Removes a player ban from the allegiance
        /// </summary>
        public event EventHandler<Allegiance_RemoveAllegianceBan>? OnAllegiance_RemoveAllegianceBan {
            add { _OnAllegiance_RemoveAllegianceBan.Subscribe(value); }
            remove { _OnAllegiance_RemoveAllegianceBan.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_RemoveAllegianceBan> _OnAllegiance_RemoveAllegianceBan = new();
    
        /// <summary>
        /// Fired on GameAction type 0x02A3 Allegiance_ListAllegianceBans. Display allegiance bans
        /// </summary>
        public event EventHandler<Allegiance_ListAllegianceBans>? OnAllegiance_ListAllegianceBans {
            add { _OnAllegiance_ListAllegianceBans.Subscribe(value); }
            remove { _OnAllegiance_ListAllegianceBans.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_ListAllegianceBans> _OnAllegiance_ListAllegianceBans = new();
    
        /// <summary>
        /// Fired on GameAction type 0x02A5 Allegiance_RemoveAllegianceOfficer. Removes an allegiance officer
        /// </summary>
        public event EventHandler<Allegiance_RemoveAllegianceOfficer>? OnAllegiance_RemoveAllegianceOfficer {
            add { _OnAllegiance_RemoveAllegianceOfficer.Subscribe(value); }
            remove { _OnAllegiance_RemoveAllegianceOfficer.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_RemoveAllegianceOfficer> _OnAllegiance_RemoveAllegianceOfficer = new();
    
        /// <summary>
        /// Fired on GameAction type 0x02A6 Allegiance_ListAllegianceOfficers. List allegiance officers
        /// </summary>
        public event EventHandler<Allegiance_ListAllegianceOfficers>? OnAllegiance_ListAllegianceOfficers {
            add { _OnAllegiance_ListAllegianceOfficers.Subscribe(value); }
            remove { _OnAllegiance_ListAllegianceOfficers.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_ListAllegianceOfficers> _OnAllegiance_ListAllegianceOfficers = new();
    
        /// <summary>
        /// Fired on GameAction type 0x02A7 Allegiance_ClearAllegianceOfficers. Clear allegiance officers
        /// </summary>
        public event EventHandler<Allegiance_ClearAllegianceOfficers>? OnAllegiance_ClearAllegianceOfficers {
            add { _OnAllegiance_ClearAllegianceOfficers.Subscribe(value); }
            remove { _OnAllegiance_ClearAllegianceOfficers.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_ClearAllegianceOfficers> _OnAllegiance_ClearAllegianceOfficers = new();
    
        /// <summary>
        /// Fired on GameAction type 0x02AB Allegiance_RecallAllegianceHometown. Recalls to players allegiance hometown
        /// </summary>
        public event EventHandler<Allegiance_RecallAllegianceHometown>? OnAllegiance_RecallAllegianceHometown {
            add { _OnAllegiance_RecallAllegianceHometown.Subscribe(value); }
            remove { _OnAllegiance_RecallAllegianceHometown.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_RecallAllegianceHometown> _OnAllegiance_RecallAllegianceHometown = new();
    
        /// <summary>
        /// Fired on GameAction type 0x02AF Admin_QueryPluginListResponse. Admin Returns a plugin list response
        /// </summary>
        public event EventHandler<Admin_QueryPluginListResponse>? OnAdmin_QueryPluginListResponse {
            add { _OnAdmin_QueryPluginListResponse.Subscribe(value); }
            remove { _OnAdmin_QueryPluginListResponse.Unsubscribe(value); }
        }
        private readonly WeakEvent<Admin_QueryPluginListResponse> _OnAdmin_QueryPluginListResponse = new();
    
        /// <summary>
        /// Fired on GameAction type 0x02B2 Admin_QueryPluginResponse. Admin Returns plugin info
        /// </summary>
        public event EventHandler<Admin_QueryPluginResponse>? OnAdmin_QueryPluginResponse {
            add { _OnAdmin_QueryPluginResponse.Subscribe(value); }
            remove { _OnAdmin_QueryPluginResponse.Unsubscribe(value); }
        }
        private readonly WeakEvent<Admin_QueryPluginResponse> _OnAdmin_QueryPluginResponse = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0311 Character_FinishBarber. Completes the barber interaction
        /// </summary>
        public event EventHandler<Character_FinishBarber>? OnCharacter_FinishBarber {
            add { _OnCharacter_FinishBarber.Subscribe(value); }
            remove { _OnCharacter_FinishBarber.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_FinishBarber> _OnCharacter_FinishBarber = new();
    
        /// <summary>
        /// Fired on GameAction type 0x0316 Social_AbandonContract. Abandons a contract
        /// </summary>
        public event EventHandler<Social_AbandonContract>? OnSocial_AbandonContract {
            add { _OnSocial_AbandonContract.Subscribe(value); }
            remove { _OnSocial_AbandonContract.Unsubscribe(value); }
        }
        private readonly WeakEvent<Social_AbandonContract> _OnSocial_AbandonContract = new();
    
        /// <summary>
        /// Fired on GameAction type 0xF61B Movement_Jump. Performs a jump
        /// </summary>
        public event EventHandler<Movement_Jump>? OnMovement_Jump {
            add { _OnMovement_Jump.Subscribe(value); }
            remove { _OnMovement_Jump.Unsubscribe(value); }
        }
        private readonly WeakEvent<Movement_Jump> _OnMovement_Jump = new();
    
        /// <summary>
        /// Fired on GameAction type 0xF61C Movement_MoveToState. Move to state data
        /// </summary>
        public event EventHandler<Movement_MoveToState>? OnMovement_MoveToState {
            add { _OnMovement_MoveToState.Subscribe(value); }
            remove { _OnMovement_MoveToState.Unsubscribe(value); }
        }
        private readonly WeakEvent<Movement_MoveToState> _OnMovement_MoveToState = new();
    
        /// <summary>
        /// Fired on GameAction type 0xF61E Movement_DoMovementCommand. Performs a movement based on input
        /// </summary>
        public event EventHandler<Movement_DoMovementCommand>? OnMovement_DoMovementCommand {
            add { _OnMovement_DoMovementCommand.Subscribe(value); }
            remove { _OnMovement_DoMovementCommand.Unsubscribe(value); }
        }
        private readonly WeakEvent<Movement_DoMovementCommand> _OnMovement_DoMovementCommand = new();
    
        /// <summary>
        /// Fired on GameAction type 0xF661 Movement_StopMovementCommand. Stops a movement
        /// </summary>
        public event EventHandler<Movement_StopMovementCommand>? OnMovement_StopMovementCommand {
            add { _OnMovement_StopMovementCommand.Subscribe(value); }
            remove { _OnMovement_StopMovementCommand.Unsubscribe(value); }
        }
        private readonly WeakEvent<Movement_StopMovementCommand> _OnMovement_StopMovementCommand = new();
    
        /// <summary>
        /// Fired on GameAction type 0xF752 Movement_AutonomyLevel. Sets an autonomy level
        /// </summary>
        public event EventHandler<Movement_AutonomyLevel>? OnMovement_AutonomyLevel {
            add { _OnMovement_AutonomyLevel.Subscribe(value); }
            remove { _OnMovement_AutonomyLevel.Unsubscribe(value); }
        }
        private readonly WeakEvent<Movement_AutonomyLevel> _OnMovement_AutonomyLevel = new();
    
        /// <summary>
        /// Fired on GameAction type 0xF753 Movement_AutonomousPosition. Sends an autonomous position
        /// </summary>
        public event EventHandler<Movement_AutonomousPosition>? OnMovement_AutonomousPosition {
            add { _OnMovement_AutonomousPosition.Subscribe(value); }
            remove { _OnMovement_AutonomousPosition.Unsubscribe(value); }
        }
        private readonly WeakEvent<Movement_AutonomousPosition> _OnMovement_AutonomousPosition = new();
    
        /// <summary>
        /// Fired on GameAction type 0xF7C9 Movement_Jump_NonAutonomous. Performs a non autonomous jump
        /// </summary>
        public event EventHandler<Movement_Jump_NonAutonomous>? OnMovement_Jump_NonAutonomous {
            add { _OnMovement_Jump_NonAutonomous.Subscribe(value); }
            remove { _OnMovement_Jump_NonAutonomous.Unsubscribe(value); }
        }
        private readonly WeakEvent<Movement_Jump_NonAutonomous> _OnMovement_Jump_NonAutonomous = new();
    
            public ACC2SMessage? ProcessC2SMessage(BinaryReader reader) {
                var opcode = (C2SMessageType)reader.ReadUInt32();
    
                switch (opcode) {
                    case (C2SMessageType)0xF7B1: // Value indicating this Message has a sequencing header
                        var _sequence = reader.ReadUInt32(); // Currently unused
                        var actionType = (GameActionType)reader.ReadUInt32();
                        reader.BaseStream.Position -= sizeof(uint) * 2;
    
                        switch(actionType) {
                            case GameActionType.Character_PlayerOptionChangedEvent:
                                var data_Character_PlayerOptionChangedEvent = new Character_PlayerOptionChangedEvent();
                                data_Character_PlayerOptionChangedEvent.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_PlayerOptionChangedEvent));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_PlayerOptionChangedEvent);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_PlayerOptionChangedEvent));
                                _OnCharacter_PlayerOptionChangedEvent?.Invoke(this, data_Character_PlayerOptionChangedEvent);
                                return data_Character_PlayerOptionChangedEvent;
                            case GameActionType.Combat_TargetedMeleeAttack:
                                var data_Combat_TargetedMeleeAttack = new Combat_TargetedMeleeAttack();
                                data_Combat_TargetedMeleeAttack.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Combat_TargetedMeleeAttack));
                                _OnOrdered_GameAction?.Invoke(this,  data_Combat_TargetedMeleeAttack);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Combat_TargetedMeleeAttack));
                                _OnCombat_TargetedMeleeAttack?.Invoke(this, data_Combat_TargetedMeleeAttack);
                                return data_Combat_TargetedMeleeAttack;
                            case GameActionType.Combat_TargetedMissileAttack:
                                var data_Combat_TargetedMissileAttack = new Combat_TargetedMissileAttack();
                                data_Combat_TargetedMissileAttack.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Combat_TargetedMissileAttack));
                                _OnOrdered_GameAction?.Invoke(this,  data_Combat_TargetedMissileAttack);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Combat_TargetedMissileAttack));
                                _OnCombat_TargetedMissileAttack?.Invoke(this, data_Combat_TargetedMissileAttack);
                                return data_Combat_TargetedMissileAttack;
                            case GameActionType.Communication_SetAFKMode:
                                var data_Communication_SetAFKMode = new Communication_SetAFKMode();
                                data_Communication_SetAFKMode.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_SetAFKMode));
                                _OnOrdered_GameAction?.Invoke(this,  data_Communication_SetAFKMode);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_SetAFKMode));
                                _OnCommunication_SetAFKMode?.Invoke(this, data_Communication_SetAFKMode);
                                return data_Communication_SetAFKMode;
                            case GameActionType.Communication_SetAFKMessage:
                                var data_Communication_SetAFKMessage = new Communication_SetAFKMessage();
                                data_Communication_SetAFKMessage.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_SetAFKMessage));
                                _OnOrdered_GameAction?.Invoke(this,  data_Communication_SetAFKMessage);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_SetAFKMessage));
                                _OnCommunication_SetAFKMessage?.Invoke(this, data_Communication_SetAFKMessage);
                                return data_Communication_SetAFKMessage;
                            case GameActionType.Communication_Talk:
                                var data_Communication_Talk = new Communication_Talk();
                                data_Communication_Talk.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_Talk));
                                _OnOrdered_GameAction?.Invoke(this,  data_Communication_Talk);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_Talk));
                                _OnCommunication_Talk?.Invoke(this, data_Communication_Talk);
                                return data_Communication_Talk;
                            case GameActionType.Social_RemoveFriend:
                                var data_Social_RemoveFriend = new Social_RemoveFriend();
                                data_Social_RemoveFriend.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Social_RemoveFriend));
                                _OnOrdered_GameAction?.Invoke(this,  data_Social_RemoveFriend);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Social_RemoveFriend));
                                _OnSocial_RemoveFriend?.Invoke(this, data_Social_RemoveFriend);
                                return data_Social_RemoveFriend;
                            case GameActionType.Social_AddFriend:
                                var data_Social_AddFriend = new Social_AddFriend();
                                data_Social_AddFriend.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Social_AddFriend));
                                _OnOrdered_GameAction?.Invoke(this,  data_Social_AddFriend);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Social_AddFriend));
                                _OnSocial_AddFriend?.Invoke(this, data_Social_AddFriend);
                                return data_Social_AddFriend;
                            case GameActionType.Inventory_PutItemInContainer:
                                var data_Inventory_PutItemInContainer = new Inventory_PutItemInContainer();
                                data_Inventory_PutItemInContainer.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Inventory_PutItemInContainer));
                                _OnOrdered_GameAction?.Invoke(this,  data_Inventory_PutItemInContainer);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Inventory_PutItemInContainer));
                                _OnInventory_PutItemInContainer?.Invoke(this, data_Inventory_PutItemInContainer);
                                return data_Inventory_PutItemInContainer;
                            case GameActionType.Inventory_GetAndWieldItem:
                                var data_Inventory_GetAndWieldItem = new Inventory_GetAndWieldItem();
                                data_Inventory_GetAndWieldItem.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Inventory_GetAndWieldItem));
                                _OnOrdered_GameAction?.Invoke(this,  data_Inventory_GetAndWieldItem);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Inventory_GetAndWieldItem));
                                _OnInventory_GetAndWieldItem?.Invoke(this, data_Inventory_GetAndWieldItem);
                                return data_Inventory_GetAndWieldItem;
                            case GameActionType.Inventory_DropItem:
                                var data_Inventory_DropItem = new Inventory_DropItem();
                                data_Inventory_DropItem.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Inventory_DropItem));
                                _OnOrdered_GameAction?.Invoke(this,  data_Inventory_DropItem);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Inventory_DropItem));
                                _OnInventory_DropItem?.Invoke(this, data_Inventory_DropItem);
                                return data_Inventory_DropItem;
                            case GameActionType.Allegiance_SwearAllegiance:
                                var data_Allegiance_SwearAllegiance = new Allegiance_SwearAllegiance();
                                data_Allegiance_SwearAllegiance.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_SwearAllegiance));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_SwearAllegiance);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_SwearAllegiance));
                                _OnAllegiance_SwearAllegiance?.Invoke(this, data_Allegiance_SwearAllegiance);
                                return data_Allegiance_SwearAllegiance;
                            case GameActionType.Allegiance_BreakAllegiance:
                                var data_Allegiance_BreakAllegiance = new Allegiance_BreakAllegiance();
                                data_Allegiance_BreakAllegiance.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_BreakAllegiance));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_BreakAllegiance);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_BreakAllegiance));
                                _OnAllegiance_BreakAllegiance?.Invoke(this, data_Allegiance_BreakAllegiance);
                                return data_Allegiance_BreakAllegiance;
                            case GameActionType.Allegiance_UpdateRequest:
                                var data_Allegiance_UpdateRequest = new Allegiance_UpdateRequest();
                                data_Allegiance_UpdateRequest.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_UpdateRequest));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_UpdateRequest);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_UpdateRequest));
                                _OnAllegiance_UpdateRequest?.Invoke(this, data_Allegiance_UpdateRequest);
                                return data_Allegiance_UpdateRequest;
                            case GameActionType.Social_ClearFriends:
                                var data_Social_ClearFriends = new Social_ClearFriends();
                                data_Social_ClearFriends.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Social_ClearFriends));
                                _OnOrdered_GameAction?.Invoke(this,  data_Social_ClearFriends);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Social_ClearFriends));
                                _OnSocial_ClearFriends?.Invoke(this, data_Social_ClearFriends);
                                return data_Social_ClearFriends;
                            case GameActionType.Character_TeleToPKLArena:
                                var data_Character_TeleToPKLArena = new Character_TeleToPKLArena();
                                data_Character_TeleToPKLArena.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_TeleToPKLArena));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_TeleToPKLArena);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_TeleToPKLArena));
                                _OnCharacter_TeleToPKLArena?.Invoke(this, data_Character_TeleToPKLArena);
                                return data_Character_TeleToPKLArena;
                            case GameActionType.Character_TeleToPKArena:
                                var data_Character_TeleToPKArena = new Character_TeleToPKArena();
                                data_Character_TeleToPKArena.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_TeleToPKArena));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_TeleToPKArena);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_TeleToPKArena));
                                _OnCharacter_TeleToPKArena?.Invoke(this, data_Character_TeleToPKArena);
                                return data_Character_TeleToPKArena;
                            case GameActionType.Social_SetDisplayCharacterTitle:
                                var data_Social_SetDisplayCharacterTitle = new Social_SetDisplayCharacterTitle();
                                data_Social_SetDisplayCharacterTitle.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Social_SetDisplayCharacterTitle));
                                _OnOrdered_GameAction?.Invoke(this,  data_Social_SetDisplayCharacterTitle);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Social_SetDisplayCharacterTitle));
                                _OnSocial_SetDisplayCharacterTitle?.Invoke(this, data_Social_SetDisplayCharacterTitle);
                                return data_Social_SetDisplayCharacterTitle;
                            case GameActionType.Allegiance_QueryAllegianceName:
                                var data_Allegiance_QueryAllegianceName = new Allegiance_QueryAllegianceName();
                                data_Allegiance_QueryAllegianceName.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_QueryAllegianceName));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_QueryAllegianceName);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_QueryAllegianceName));
                                _OnAllegiance_QueryAllegianceName?.Invoke(this, data_Allegiance_QueryAllegianceName);
                                return data_Allegiance_QueryAllegianceName;
                            case GameActionType.Allegiance_ClearAllegianceName:
                                var data_Allegiance_ClearAllegianceName = new Allegiance_ClearAllegianceName();
                                data_Allegiance_ClearAllegianceName.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_ClearAllegianceName));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_ClearAllegianceName);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_ClearAllegianceName));
                                _OnAllegiance_ClearAllegianceName?.Invoke(this, data_Allegiance_ClearAllegianceName);
                                return data_Allegiance_ClearAllegianceName;
                            case GameActionType.Communication_TalkDirect:
                                var data_Communication_TalkDirect = new Communication_TalkDirect();
                                data_Communication_TalkDirect.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_TalkDirect));
                                _OnOrdered_GameAction?.Invoke(this,  data_Communication_TalkDirect);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_TalkDirect));
                                _OnCommunication_TalkDirect?.Invoke(this, data_Communication_TalkDirect);
                                return data_Communication_TalkDirect;
                            case GameActionType.Allegiance_SetAllegianceName:
                                var data_Allegiance_SetAllegianceName = new Allegiance_SetAllegianceName();
                                data_Allegiance_SetAllegianceName.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_SetAllegianceName));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_SetAllegianceName);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_SetAllegianceName));
                                _OnAllegiance_SetAllegianceName?.Invoke(this, data_Allegiance_SetAllegianceName);
                                return data_Allegiance_SetAllegianceName;
                            case GameActionType.Inventory_UseWithTargetEvent:
                                var data_Inventory_UseWithTargetEvent = new Inventory_UseWithTargetEvent();
                                data_Inventory_UseWithTargetEvent.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Inventory_UseWithTargetEvent));
                                _OnOrdered_GameAction?.Invoke(this,  data_Inventory_UseWithTargetEvent);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Inventory_UseWithTargetEvent));
                                _OnInventory_UseWithTargetEvent?.Invoke(this, data_Inventory_UseWithTargetEvent);
                                return data_Inventory_UseWithTargetEvent;
                            case GameActionType.Inventory_UseEvent:
                                var data_Inventory_UseEvent = new Inventory_UseEvent();
                                data_Inventory_UseEvent.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Inventory_UseEvent));
                                _OnOrdered_GameAction?.Invoke(this,  data_Inventory_UseEvent);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Inventory_UseEvent));
                                _OnInventory_UseEvent?.Invoke(this, data_Inventory_UseEvent);
                                return data_Inventory_UseEvent;
                            case GameActionType.Allegiance_SetAllegianceOfficer:
                                var data_Allegiance_SetAllegianceOfficer = new Allegiance_SetAllegianceOfficer();
                                data_Allegiance_SetAllegianceOfficer.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_SetAllegianceOfficer));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_SetAllegianceOfficer);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_SetAllegianceOfficer));
                                _OnAllegiance_SetAllegianceOfficer?.Invoke(this, data_Allegiance_SetAllegianceOfficer);
                                return data_Allegiance_SetAllegianceOfficer;
                            case GameActionType.Allegiance_SetAllegianceOfficerTitle:
                                var data_Allegiance_SetAllegianceOfficerTitle = new Allegiance_SetAllegianceOfficerTitle();
                                data_Allegiance_SetAllegianceOfficerTitle.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_SetAllegianceOfficerTitle));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_SetAllegianceOfficerTitle);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_SetAllegianceOfficerTitle));
                                _OnAllegiance_SetAllegianceOfficerTitle?.Invoke(this, data_Allegiance_SetAllegianceOfficerTitle);
                                return data_Allegiance_SetAllegianceOfficerTitle;
                            case GameActionType.Allegiance_ListAllegianceOfficerTitles:
                                var data_Allegiance_ListAllegianceOfficerTitles = new Allegiance_ListAllegianceOfficerTitles();
                                data_Allegiance_ListAllegianceOfficerTitles.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_ListAllegianceOfficerTitles));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_ListAllegianceOfficerTitles);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_ListAllegianceOfficerTitles));
                                _OnAllegiance_ListAllegianceOfficerTitles?.Invoke(this, data_Allegiance_ListAllegianceOfficerTitles);
                                return data_Allegiance_ListAllegianceOfficerTitles;
                            case GameActionType.Allegiance_ClearAllegianceOfficerTitles:
                                var data_Allegiance_ClearAllegianceOfficerTitles = new Allegiance_ClearAllegianceOfficerTitles();
                                data_Allegiance_ClearAllegianceOfficerTitles.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_ClearAllegianceOfficerTitles));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_ClearAllegianceOfficerTitles);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_ClearAllegianceOfficerTitles));
                                _OnAllegiance_ClearAllegianceOfficerTitles?.Invoke(this, data_Allegiance_ClearAllegianceOfficerTitles);
                                return data_Allegiance_ClearAllegianceOfficerTitles;
                            case GameActionType.Allegiance_DoAllegianceLockAction:
                                var data_Allegiance_DoAllegianceLockAction = new Allegiance_DoAllegianceLockAction();
                                data_Allegiance_DoAllegianceLockAction.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_DoAllegianceLockAction));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_DoAllegianceLockAction);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_DoAllegianceLockAction));
                                _OnAllegiance_DoAllegianceLockAction?.Invoke(this, data_Allegiance_DoAllegianceLockAction);
                                return data_Allegiance_DoAllegianceLockAction;
                            case GameActionType.Allegiance_SetAllegianceApprovedVassal:
                                var data_Allegiance_SetAllegianceApprovedVassal = new Allegiance_SetAllegianceApprovedVassal();
                                data_Allegiance_SetAllegianceApprovedVassal.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_SetAllegianceApprovedVassal));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_SetAllegianceApprovedVassal);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_SetAllegianceApprovedVassal));
                                _OnAllegiance_SetAllegianceApprovedVassal?.Invoke(this, data_Allegiance_SetAllegianceApprovedVassal);
                                return data_Allegiance_SetAllegianceApprovedVassal;
                            case GameActionType.Allegiance_AllegianceChatGag:
                                var data_Allegiance_AllegianceChatGag = new Allegiance_AllegianceChatGag();
                                data_Allegiance_AllegianceChatGag.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_AllegianceChatGag));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_AllegianceChatGag);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_AllegianceChatGag));
                                _OnAllegiance_AllegianceChatGag?.Invoke(this, data_Allegiance_AllegianceChatGag);
                                return data_Allegiance_AllegianceChatGag;
                            case GameActionType.Allegiance_DoAllegianceHouseAction:
                                var data_Allegiance_DoAllegianceHouseAction = new Allegiance_DoAllegianceHouseAction();
                                data_Allegiance_DoAllegianceHouseAction.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_DoAllegianceHouseAction));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_DoAllegianceHouseAction);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_DoAllegianceHouseAction));
                                _OnAllegiance_DoAllegianceHouseAction?.Invoke(this, data_Allegiance_DoAllegianceHouseAction);
                                return data_Allegiance_DoAllegianceHouseAction;
                            case GameActionType.Train_TrainAttribute2nd:
                                var data_Train_TrainAttribute2nd = new Train_TrainAttribute2nd();
                                data_Train_TrainAttribute2nd.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Train_TrainAttribute2nd));
                                _OnOrdered_GameAction?.Invoke(this,  data_Train_TrainAttribute2nd);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Train_TrainAttribute2nd));
                                _OnTrain_TrainAttribute2nd?.Invoke(this, data_Train_TrainAttribute2nd);
                                return data_Train_TrainAttribute2nd;
                            case GameActionType.Train_TrainAttribute:
                                var data_Train_TrainAttribute = new Train_TrainAttribute();
                                data_Train_TrainAttribute.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Train_TrainAttribute));
                                _OnOrdered_GameAction?.Invoke(this,  data_Train_TrainAttribute);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Train_TrainAttribute));
                                _OnTrain_TrainAttribute?.Invoke(this, data_Train_TrainAttribute);
                                return data_Train_TrainAttribute;
                            case GameActionType.Train_TrainSkill:
                                var data_Train_TrainSkill = new Train_TrainSkill();
                                data_Train_TrainSkill.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Train_TrainSkill));
                                _OnOrdered_GameAction?.Invoke(this,  data_Train_TrainSkill);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Train_TrainSkill));
                                _OnTrain_TrainSkill?.Invoke(this, data_Train_TrainSkill);
                                return data_Train_TrainSkill;
                            case GameActionType.Train_TrainSkillAdvancementClass:
                                var data_Train_TrainSkillAdvancementClass = new Train_TrainSkillAdvancementClass();
                                data_Train_TrainSkillAdvancementClass.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Train_TrainSkillAdvancementClass));
                                _OnOrdered_GameAction?.Invoke(this,  data_Train_TrainSkillAdvancementClass);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Train_TrainSkillAdvancementClass));
                                _OnTrain_TrainSkillAdvancementClass?.Invoke(this, data_Train_TrainSkillAdvancementClass);
                                return data_Train_TrainSkillAdvancementClass;
                            case GameActionType.Magic_CastUntargetedSpell:
                                var data_Magic_CastUntargetedSpell = new Magic_CastUntargetedSpell();
                                data_Magic_CastUntargetedSpell.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Magic_CastUntargetedSpell));
                                _OnOrdered_GameAction?.Invoke(this,  data_Magic_CastUntargetedSpell);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Magic_CastUntargetedSpell));
                                _OnMagic_CastUntargetedSpell?.Invoke(this, data_Magic_CastUntargetedSpell);
                                return data_Magic_CastUntargetedSpell;
                            case GameActionType.Magic_CastTargetedSpell:
                                var data_Magic_CastTargetedSpell = new Magic_CastTargetedSpell();
                                data_Magic_CastTargetedSpell.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Magic_CastTargetedSpell));
                                _OnOrdered_GameAction?.Invoke(this,  data_Magic_CastTargetedSpell);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Magic_CastTargetedSpell));
                                _OnMagic_CastTargetedSpell?.Invoke(this, data_Magic_CastTargetedSpell);
                                return data_Magic_CastTargetedSpell;
                            case GameActionType.Combat_ChangeCombatMode:
                                var data_Combat_ChangeCombatMode = new Combat_ChangeCombatMode();
                                data_Combat_ChangeCombatMode.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Combat_ChangeCombatMode));
                                _OnOrdered_GameAction?.Invoke(this,  data_Combat_ChangeCombatMode);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Combat_ChangeCombatMode));
                                _OnCombat_ChangeCombatMode?.Invoke(this, data_Combat_ChangeCombatMode);
                                return data_Combat_ChangeCombatMode;
                            case GameActionType.Inventory_StackableMerge:
                                var data_Inventory_StackableMerge = new Inventory_StackableMerge();
                                data_Inventory_StackableMerge.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Inventory_StackableMerge));
                                _OnOrdered_GameAction?.Invoke(this,  data_Inventory_StackableMerge);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Inventory_StackableMerge));
                                _OnInventory_StackableMerge?.Invoke(this, data_Inventory_StackableMerge);
                                return data_Inventory_StackableMerge;
                            case GameActionType.Inventory_StackableSplitToContainer:
                                var data_Inventory_StackableSplitToContainer = new Inventory_StackableSplitToContainer();
                                data_Inventory_StackableSplitToContainer.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Inventory_StackableSplitToContainer));
                                _OnOrdered_GameAction?.Invoke(this,  data_Inventory_StackableSplitToContainer);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Inventory_StackableSplitToContainer));
                                _OnInventory_StackableSplitToContainer?.Invoke(this, data_Inventory_StackableSplitToContainer);
                                return data_Inventory_StackableSplitToContainer;
                            case GameActionType.Inventory_StackableSplitTo3D:
                                var data_Inventory_StackableSplitTo3D = new Inventory_StackableSplitTo3D();
                                data_Inventory_StackableSplitTo3D.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Inventory_StackableSplitTo3D));
                                _OnOrdered_GameAction?.Invoke(this,  data_Inventory_StackableSplitTo3D);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Inventory_StackableSplitTo3D));
                                _OnInventory_StackableSplitTo3D?.Invoke(this, data_Inventory_StackableSplitTo3D);
                                return data_Inventory_StackableSplitTo3D;
                            case GameActionType.Communication_ModifyCharacterSquelch:
                                var data_Communication_ModifyCharacterSquelch = new Communication_ModifyCharacterSquelch();
                                data_Communication_ModifyCharacterSquelch.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_ModifyCharacterSquelch));
                                _OnOrdered_GameAction?.Invoke(this,  data_Communication_ModifyCharacterSquelch);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_ModifyCharacterSquelch));
                                _OnCommunication_ModifyCharacterSquelch?.Invoke(this, data_Communication_ModifyCharacterSquelch);
                                return data_Communication_ModifyCharacterSquelch;
                            case GameActionType.Communication_ModifyAccountSquelch:
                                var data_Communication_ModifyAccountSquelch = new Communication_ModifyAccountSquelch();
                                data_Communication_ModifyAccountSquelch.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_ModifyAccountSquelch));
                                _OnOrdered_GameAction?.Invoke(this,  data_Communication_ModifyAccountSquelch);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_ModifyAccountSquelch));
                                _OnCommunication_ModifyAccountSquelch?.Invoke(this, data_Communication_ModifyAccountSquelch);
                                return data_Communication_ModifyAccountSquelch;
                            case GameActionType.Communication_ModifyGlobalSquelch:
                                var data_Communication_ModifyGlobalSquelch = new Communication_ModifyGlobalSquelch();
                                data_Communication_ModifyGlobalSquelch.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_ModifyGlobalSquelch));
                                _OnOrdered_GameAction?.Invoke(this,  data_Communication_ModifyGlobalSquelch);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_ModifyGlobalSquelch));
                                _OnCommunication_ModifyGlobalSquelch?.Invoke(this, data_Communication_ModifyGlobalSquelch);
                                return data_Communication_ModifyGlobalSquelch;
                            case GameActionType.Communication_TalkDirectByName:
                                var data_Communication_TalkDirectByName = new Communication_TalkDirectByName();
                                data_Communication_TalkDirectByName.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_TalkDirectByName));
                                _OnOrdered_GameAction?.Invoke(this,  data_Communication_TalkDirectByName);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_TalkDirectByName));
                                _OnCommunication_TalkDirectByName?.Invoke(this, data_Communication_TalkDirectByName);
                                return data_Communication_TalkDirectByName;
                            case GameActionType.Vendor_Buy:
                                var data_Vendor_Buy = new Vendor_Buy();
                                data_Vendor_Buy.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Vendor_Buy));
                                _OnOrdered_GameAction?.Invoke(this,  data_Vendor_Buy);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Vendor_Buy));
                                _OnVendor_Buy?.Invoke(this, data_Vendor_Buy);
                                return data_Vendor_Buy;
                            case GameActionType.Vendor_Sell:
                                var data_Vendor_Sell = new Vendor_Sell();
                                data_Vendor_Sell.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Vendor_Sell));
                                _OnOrdered_GameAction?.Invoke(this,  data_Vendor_Sell);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Vendor_Sell));
                                _OnVendor_Sell?.Invoke(this, data_Vendor_Sell);
                                return data_Vendor_Sell;
                            case GameActionType.Character_TeleToLifestone:
                                var data_Character_TeleToLifestone = new Character_TeleToLifestone();
                                data_Character_TeleToLifestone.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_TeleToLifestone));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_TeleToLifestone);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_TeleToLifestone));
                                _OnCharacter_TeleToLifestone?.Invoke(this, data_Character_TeleToLifestone);
                                return data_Character_TeleToLifestone;
                            case GameActionType.Character_LoginCompleteNotification:
                                var data_Character_LoginCompleteNotification = new Character_LoginCompleteNotification();
                                data_Character_LoginCompleteNotification.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_LoginCompleteNotification));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_LoginCompleteNotification);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_LoginCompleteNotification));
                                _OnCharacter_LoginCompleteNotification?.Invoke(this, data_Character_LoginCompleteNotification);
                                return data_Character_LoginCompleteNotification;
                            case GameActionType.Fellowship_Create:
                                var data_Fellowship_Create = new Fellowship_Create();
                                data_Fellowship_Create.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Fellowship_Create));
                                _OnOrdered_GameAction?.Invoke(this,  data_Fellowship_Create);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Fellowship_Create));
                                _OnFellowship_Create?.Invoke(this, data_Fellowship_Create);
                                return data_Fellowship_Create;
                            case GameActionType.Fellowship_Quit:
                                var data_Fellowship_Quit = new Fellowship_Quit();
                                data_Fellowship_Quit.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Fellowship_Quit));
                                _OnOrdered_GameAction?.Invoke(this,  data_Fellowship_Quit);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Fellowship_Quit));
                                _OnFellowship_Quit?.Invoke(this, data_Fellowship_Quit);
                                return data_Fellowship_Quit;
                            case GameActionType.Fellowship_Dismiss:
                                var data_Fellowship_Dismiss = new Fellowship_Dismiss();
                                data_Fellowship_Dismiss.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Fellowship_Dismiss));
                                _OnOrdered_GameAction?.Invoke(this,  data_Fellowship_Dismiss);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Fellowship_Dismiss));
                                _OnFellowship_Dismiss?.Invoke(this, data_Fellowship_Dismiss);
                                return data_Fellowship_Dismiss;
                            case GameActionType.Fellowship_Recruit:
                                var data_Fellowship_Recruit = new Fellowship_Recruit();
                                data_Fellowship_Recruit.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Fellowship_Recruit));
                                _OnOrdered_GameAction?.Invoke(this,  data_Fellowship_Recruit);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Fellowship_Recruit));
                                _OnFellowship_Recruit?.Invoke(this, data_Fellowship_Recruit);
                                return data_Fellowship_Recruit;
                            case GameActionType.Fellowship_UpdateRequest:
                                var data_Fellowship_UpdateRequest = new Fellowship_UpdateRequest();
                                data_Fellowship_UpdateRequest.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Fellowship_UpdateRequest));
                                _OnOrdered_GameAction?.Invoke(this,  data_Fellowship_UpdateRequest);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Fellowship_UpdateRequest));
                                _OnFellowship_UpdateRequest?.Invoke(this, data_Fellowship_UpdateRequest);
                                return data_Fellowship_UpdateRequest;
                            case GameActionType.Writing_BookAddPage:
                                var data_Writing_BookAddPage = new Writing_BookAddPage();
                                data_Writing_BookAddPage.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Writing_BookAddPage));
                                _OnOrdered_GameAction?.Invoke(this,  data_Writing_BookAddPage);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Writing_BookAddPage));
                                _OnWriting_BookAddPage?.Invoke(this, data_Writing_BookAddPage);
                                return data_Writing_BookAddPage;
                            case GameActionType.Writing_BookModifyPage:
                                var data_Writing_BookModifyPage = new Writing_BookModifyPage();
                                data_Writing_BookModifyPage.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Writing_BookModifyPage));
                                _OnOrdered_GameAction?.Invoke(this,  data_Writing_BookModifyPage);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Writing_BookModifyPage));
                                _OnWriting_BookModifyPage?.Invoke(this, data_Writing_BookModifyPage);
                                return data_Writing_BookModifyPage;
                            case GameActionType.Writing_BookData:
                                var data_Writing_BookData = new Writing_BookData();
                                data_Writing_BookData.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Writing_BookData));
                                _OnOrdered_GameAction?.Invoke(this,  data_Writing_BookData);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Writing_BookData));
                                _OnWriting_BookData?.Invoke(this, data_Writing_BookData);
                                return data_Writing_BookData;
                            case GameActionType.Writing_BookDeletePage:
                                var data_Writing_BookDeletePage = new Writing_BookDeletePage();
                                data_Writing_BookDeletePage.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Writing_BookDeletePage));
                                _OnOrdered_GameAction?.Invoke(this,  data_Writing_BookDeletePage);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Writing_BookDeletePage));
                                _OnWriting_BookDeletePage?.Invoke(this, data_Writing_BookDeletePage);
                                return data_Writing_BookDeletePage;
                            case GameActionType.Writing_BookPageData:
                                var data_Writing_BookPageData = new Writing_BookPageData();
                                data_Writing_BookPageData.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Writing_BookPageData));
                                _OnOrdered_GameAction?.Invoke(this,  data_Writing_BookPageData);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Writing_BookPageData));
                                _OnWriting_BookPageData?.Invoke(this, data_Writing_BookPageData);
                                return data_Writing_BookPageData;
                            case GameActionType.Writing_SetInscription:
                                var data_Writing_SetInscription = new Writing_SetInscription();
                                data_Writing_SetInscription.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Writing_SetInscription));
                                _OnOrdered_GameAction?.Invoke(this,  data_Writing_SetInscription);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Writing_SetInscription));
                                _OnWriting_SetInscription?.Invoke(this, data_Writing_SetInscription);
                                return data_Writing_SetInscription;
                            case GameActionType.Item_Appraise:
                                var data_Item_Appraise = new Item_Appraise();
                                data_Item_Appraise.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Item_Appraise));
                                _OnOrdered_GameAction?.Invoke(this,  data_Item_Appraise);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Item_Appraise));
                                _OnItem_Appraise?.Invoke(this, data_Item_Appraise);
                                return data_Item_Appraise;
                            case GameActionType.Inventory_GiveObjectRequest:
                                var data_Inventory_GiveObjectRequest = new Inventory_GiveObjectRequest();
                                data_Inventory_GiveObjectRequest.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Inventory_GiveObjectRequest));
                                _OnOrdered_GameAction?.Invoke(this,  data_Inventory_GiveObjectRequest);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Inventory_GiveObjectRequest));
                                _OnInventory_GiveObjectRequest?.Invoke(this, data_Inventory_GiveObjectRequest);
                                return data_Inventory_GiveObjectRequest;
                            case GameActionType.Advocate_Teleport:
                                var data_Advocate_Teleport = new Advocate_Teleport();
                                data_Advocate_Teleport.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Advocate_Teleport));
                                _OnOrdered_GameAction?.Invoke(this,  data_Advocate_Teleport);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Advocate_Teleport));
                                _OnAdvocate_Teleport?.Invoke(this, data_Advocate_Teleport);
                                return data_Advocate_Teleport;
                            case GameActionType.Character_AbuseLogRequest:
                                var data_Character_AbuseLogRequest = new Character_AbuseLogRequest();
                                data_Character_AbuseLogRequest.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_AbuseLogRequest));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_AbuseLogRequest);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_AbuseLogRequest));
                                _OnCharacter_AbuseLogRequest?.Invoke(this, data_Character_AbuseLogRequest);
                                return data_Character_AbuseLogRequest;
                            case GameActionType.Communication_AddToChannel:
                                var data_Communication_AddToChannel = new Communication_AddToChannel();
                                data_Communication_AddToChannel.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_AddToChannel));
                                _OnOrdered_GameAction?.Invoke(this,  data_Communication_AddToChannel);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_AddToChannel));
                                _OnCommunication_AddToChannel?.Invoke(this, data_Communication_AddToChannel);
                                return data_Communication_AddToChannel;
                            case GameActionType.Communication_RemoveFromChannel:
                                var data_Communication_RemoveFromChannel = new Communication_RemoveFromChannel();
                                data_Communication_RemoveFromChannel.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_RemoveFromChannel));
                                _OnOrdered_GameAction?.Invoke(this,  data_Communication_RemoveFromChannel);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_RemoveFromChannel));
                                _OnCommunication_RemoveFromChannel?.Invoke(this, data_Communication_RemoveFromChannel);
                                return data_Communication_RemoveFromChannel;
                            case GameActionType.Communication_ChannelBroadcast:
                                var data_Communication_ChannelBroadcast = new Communication_ChannelBroadcast();
                                data_Communication_ChannelBroadcast.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_ChannelBroadcast));
                                _OnOrdered_GameAction?.Invoke(this,  data_Communication_ChannelBroadcast);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_ChannelBroadcast));
                                _OnCommunication_ChannelBroadcast?.Invoke(this, data_Communication_ChannelBroadcast);
                                return data_Communication_ChannelBroadcast;
                            case GameActionType.Communication_ChannelList:
                                var data_Communication_ChannelList = new Communication_ChannelList();
                                data_Communication_ChannelList.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_ChannelList));
                                _OnOrdered_GameAction?.Invoke(this,  data_Communication_ChannelList);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_ChannelList));
                                _OnCommunication_ChannelList?.Invoke(this, data_Communication_ChannelList);
                                return data_Communication_ChannelList;
                            case GameActionType.Communication_ChannelIndex:
                                var data_Communication_ChannelIndex = new Communication_ChannelIndex();
                                data_Communication_ChannelIndex.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_ChannelIndex));
                                _OnOrdered_GameAction?.Invoke(this,  data_Communication_ChannelIndex);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_ChannelIndex));
                                _OnCommunication_ChannelIndex?.Invoke(this, data_Communication_ChannelIndex);
                                return data_Communication_ChannelIndex;
                            case GameActionType.Inventory_NoLongerViewingContents:
                                var data_Inventory_NoLongerViewingContents = new Inventory_NoLongerViewingContents();
                                data_Inventory_NoLongerViewingContents.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Inventory_NoLongerViewingContents));
                                _OnOrdered_GameAction?.Invoke(this,  data_Inventory_NoLongerViewingContents);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Inventory_NoLongerViewingContents));
                                _OnInventory_NoLongerViewingContents?.Invoke(this, data_Inventory_NoLongerViewingContents);
                                return data_Inventory_NoLongerViewingContents;
                            case GameActionType.Inventory_StackableSplitToWield:
                                var data_Inventory_StackableSplitToWield = new Inventory_StackableSplitToWield();
                                data_Inventory_StackableSplitToWield.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Inventory_StackableSplitToWield));
                                _OnOrdered_GameAction?.Invoke(this,  data_Inventory_StackableSplitToWield);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Inventory_StackableSplitToWield));
                                _OnInventory_StackableSplitToWield?.Invoke(this, data_Inventory_StackableSplitToWield);
                                return data_Inventory_StackableSplitToWield;
                            case GameActionType.Character_AddShortCut:
                                var data_Character_AddShortCut = new Character_AddShortCut();
                                data_Character_AddShortCut.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_AddShortCut));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_AddShortCut);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_AddShortCut));
                                _OnCharacter_AddShortCut?.Invoke(this, data_Character_AddShortCut);
                                return data_Character_AddShortCut;
                            case GameActionType.Character_RemoveShortCut:
                                var data_Character_RemoveShortCut = new Character_RemoveShortCut();
                                data_Character_RemoveShortCut.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_RemoveShortCut));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_RemoveShortCut);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_RemoveShortCut));
                                _OnCharacter_RemoveShortCut?.Invoke(this, data_Character_RemoveShortCut);
                                return data_Character_RemoveShortCut;
                            case GameActionType.Character_CharacterOptionsEvent:
                                var data_Character_CharacterOptionsEvent = new Character_CharacterOptionsEvent();
                                data_Character_CharacterOptionsEvent.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_CharacterOptionsEvent));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_CharacterOptionsEvent);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_CharacterOptionsEvent));
                                _OnCharacter_CharacterOptionsEvent?.Invoke(this, data_Character_CharacterOptionsEvent);
                                return data_Character_CharacterOptionsEvent;
                            case GameActionType.Magic_RemoveSpell:
                                var data_Magic_RemoveSpell = new Magic_RemoveSpell();
                                data_Magic_RemoveSpell.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Magic_RemoveSpell));
                                _OnOrdered_GameAction?.Invoke(this,  data_Magic_RemoveSpell);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Magic_RemoveSpell));
                                _OnMagic_RemoveSpell?.Invoke(this, data_Magic_RemoveSpell);
                                return data_Magic_RemoveSpell;
                            case GameActionType.Combat_CancelAttack:
                                var data_Combat_CancelAttack = new Combat_CancelAttack();
                                data_Combat_CancelAttack.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Combat_CancelAttack));
                                _OnOrdered_GameAction?.Invoke(this,  data_Combat_CancelAttack);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Combat_CancelAttack));
                                _OnCombat_CancelAttack?.Invoke(this, data_Combat_CancelAttack);
                                return data_Combat_CancelAttack;
                            case GameActionType.Combat_QueryHealth:
                                var data_Combat_QueryHealth = new Combat_QueryHealth();
                                data_Combat_QueryHealth.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Combat_QueryHealth));
                                _OnOrdered_GameAction?.Invoke(this,  data_Combat_QueryHealth);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Combat_QueryHealth));
                                _OnCombat_QueryHealth?.Invoke(this, data_Combat_QueryHealth);
                                return data_Combat_QueryHealth;
                            case GameActionType.Character_QueryAge:
                                var data_Character_QueryAge = new Character_QueryAge();
                                data_Character_QueryAge.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_QueryAge));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_QueryAge);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_QueryAge));
                                _OnCharacter_QueryAge?.Invoke(this, data_Character_QueryAge);
                                return data_Character_QueryAge;
                            case GameActionType.Character_QueryBirth:
                                var data_Character_QueryBirth = new Character_QueryBirth();
                                data_Character_QueryBirth.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_QueryBirth));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_QueryBirth);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_QueryBirth));
                                _OnCharacter_QueryBirth?.Invoke(this, data_Character_QueryBirth);
                                return data_Character_QueryBirth;
                            case GameActionType.Communication_Emote:
                                var data_Communication_Emote = new Communication_Emote();
                                data_Communication_Emote.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_Emote));
                                _OnOrdered_GameAction?.Invoke(this,  data_Communication_Emote);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_Emote));
                                _OnCommunication_Emote?.Invoke(this, data_Communication_Emote);
                                return data_Communication_Emote;
                            case GameActionType.Communication_SoulEmote:
                                var data_Communication_SoulEmote = new Communication_SoulEmote();
                                data_Communication_SoulEmote.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_SoulEmote));
                                _OnOrdered_GameAction?.Invoke(this,  data_Communication_SoulEmote);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_SoulEmote));
                                _OnCommunication_SoulEmote?.Invoke(this, data_Communication_SoulEmote);
                                return data_Communication_SoulEmote;
                            case GameActionType.Character_AddSpellFavorite:
                                var data_Character_AddSpellFavorite = new Character_AddSpellFavorite();
                                data_Character_AddSpellFavorite.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_AddSpellFavorite));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_AddSpellFavorite);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_AddSpellFavorite));
                                _OnCharacter_AddSpellFavorite?.Invoke(this, data_Character_AddSpellFavorite);
                                return data_Character_AddSpellFavorite;
                            case GameActionType.Character_RemoveSpellFavorite:
                                var data_Character_RemoveSpellFavorite = new Character_RemoveSpellFavorite();
                                data_Character_RemoveSpellFavorite.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_RemoveSpellFavorite));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_RemoveSpellFavorite);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_RemoveSpellFavorite));
                                _OnCharacter_RemoveSpellFavorite?.Invoke(this, data_Character_RemoveSpellFavorite);
                                return data_Character_RemoveSpellFavorite;
                            case GameActionType.Character_RequestPing:
                                var data_Character_RequestPing = new Character_RequestPing();
                                data_Character_RequestPing.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_RequestPing));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_RequestPing);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_RequestPing));
                                _OnCharacter_RequestPing?.Invoke(this, data_Character_RequestPing);
                                return data_Character_RequestPing;
                            case GameActionType.Trade_OpenTradeNegotiations:
                                var data_Trade_OpenTradeNegotiations = new Trade_OpenTradeNegotiations();
                                data_Trade_OpenTradeNegotiations.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Trade_OpenTradeNegotiations));
                                _OnOrdered_GameAction?.Invoke(this,  data_Trade_OpenTradeNegotiations);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Trade_OpenTradeNegotiations));
                                _OnTrade_OpenTradeNegotiations?.Invoke(this, data_Trade_OpenTradeNegotiations);
                                return data_Trade_OpenTradeNegotiations;
                            case GameActionType.Trade_CloseTradeNegotiations:
                                var data_Trade_CloseTradeNegotiations = new Trade_CloseTradeNegotiations();
                                data_Trade_CloseTradeNegotiations.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Trade_CloseTradeNegotiations));
                                _OnOrdered_GameAction?.Invoke(this,  data_Trade_CloseTradeNegotiations);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Trade_CloseTradeNegotiations));
                                _OnTrade_CloseTradeNegotiations?.Invoke(this, data_Trade_CloseTradeNegotiations);
                                return data_Trade_CloseTradeNegotiations;
                            case GameActionType.Trade_AddToTrade:
                                var data_Trade_AddToTrade = new Trade_AddToTrade();
                                data_Trade_AddToTrade.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Trade_AddToTrade));
                                _OnOrdered_GameAction?.Invoke(this,  data_Trade_AddToTrade);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Trade_AddToTrade));
                                _OnTrade_AddToTrade?.Invoke(this, data_Trade_AddToTrade);
                                return data_Trade_AddToTrade;
                            case GameActionType.Trade_AcceptTrade:
                                var data_Trade_AcceptTrade = new Trade_AcceptTrade();
                                data_Trade_AcceptTrade.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Trade_AcceptTrade));
                                _OnOrdered_GameAction?.Invoke(this,  data_Trade_AcceptTrade);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Trade_AcceptTrade));
                                _OnTrade_AcceptTrade?.Invoke(this, data_Trade_AcceptTrade);
                                return data_Trade_AcceptTrade;
                            case GameActionType.Trade_DeclineTrade:
                                var data_Trade_DeclineTrade = new Trade_DeclineTrade();
                                data_Trade_DeclineTrade.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Trade_DeclineTrade));
                                _OnOrdered_GameAction?.Invoke(this,  data_Trade_DeclineTrade);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Trade_DeclineTrade));
                                _OnTrade_DeclineTrade?.Invoke(this, data_Trade_DeclineTrade);
                                return data_Trade_DeclineTrade;
                            case GameActionType.Trade_ResetTrade:
                                var data_Trade_ResetTrade = new Trade_ResetTrade();
                                data_Trade_ResetTrade.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Trade_ResetTrade));
                                _OnOrdered_GameAction?.Invoke(this,  data_Trade_ResetTrade);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Trade_ResetTrade));
                                _OnTrade_ResetTrade?.Invoke(this, data_Trade_ResetTrade);
                                return data_Trade_ResetTrade;
                            case GameActionType.Character_ClearPlayerConsentList:
                                var data_Character_ClearPlayerConsentList = new Character_ClearPlayerConsentList();
                                data_Character_ClearPlayerConsentList.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_ClearPlayerConsentList));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_ClearPlayerConsentList);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_ClearPlayerConsentList));
                                _OnCharacter_ClearPlayerConsentList?.Invoke(this, data_Character_ClearPlayerConsentList);
                                return data_Character_ClearPlayerConsentList;
                            case GameActionType.Character_DisplayPlayerConsentList:
                                var data_Character_DisplayPlayerConsentList = new Character_DisplayPlayerConsentList();
                                data_Character_DisplayPlayerConsentList.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_DisplayPlayerConsentList));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_DisplayPlayerConsentList);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_DisplayPlayerConsentList));
                                _OnCharacter_DisplayPlayerConsentList?.Invoke(this, data_Character_DisplayPlayerConsentList);
                                return data_Character_DisplayPlayerConsentList;
                            case GameActionType.Character_RemoveFromPlayerConsentList:
                                var data_Character_RemoveFromPlayerConsentList = new Character_RemoveFromPlayerConsentList();
                                data_Character_RemoveFromPlayerConsentList.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_RemoveFromPlayerConsentList));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_RemoveFromPlayerConsentList);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_RemoveFromPlayerConsentList));
                                _OnCharacter_RemoveFromPlayerConsentList?.Invoke(this, data_Character_RemoveFromPlayerConsentList);
                                return data_Character_RemoveFromPlayerConsentList;
                            case GameActionType.Character_AddPlayerPermission:
                                var data_Character_AddPlayerPermission = new Character_AddPlayerPermission();
                                data_Character_AddPlayerPermission.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_AddPlayerPermission));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_AddPlayerPermission);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_AddPlayerPermission));
                                _OnCharacter_AddPlayerPermission?.Invoke(this, data_Character_AddPlayerPermission);
                                return data_Character_AddPlayerPermission;
                            case GameActionType.House_BuyHouse:
                                var data_House_BuyHouse = new House_BuyHouse();
                                data_House_BuyHouse.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_BuyHouse));
                                _OnOrdered_GameAction?.Invoke(this,  data_House_BuyHouse);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_BuyHouse));
                                _OnHouse_BuyHouse?.Invoke(this, data_House_BuyHouse);
                                return data_House_BuyHouse;
                            case GameActionType.House_QueryHouse:
                                var data_House_QueryHouse = new House_QueryHouse();
                                data_House_QueryHouse.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_QueryHouse));
                                _OnOrdered_GameAction?.Invoke(this,  data_House_QueryHouse);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_QueryHouse));
                                _OnHouse_QueryHouse?.Invoke(this, data_House_QueryHouse);
                                return data_House_QueryHouse;
                            case GameActionType.House_AbandonHouse:
                                var data_House_AbandonHouse = new House_AbandonHouse();
                                data_House_AbandonHouse.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_AbandonHouse));
                                _OnOrdered_GameAction?.Invoke(this,  data_House_AbandonHouse);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_AbandonHouse));
                                _OnHouse_AbandonHouse?.Invoke(this, data_House_AbandonHouse);
                                return data_House_AbandonHouse;
                            case GameActionType.Character_RemovePlayerPermission:
                                var data_Character_RemovePlayerPermission = new Character_RemovePlayerPermission();
                                data_Character_RemovePlayerPermission.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_RemovePlayerPermission));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_RemovePlayerPermission);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_RemovePlayerPermission));
                                _OnCharacter_RemovePlayerPermission?.Invoke(this, data_Character_RemovePlayerPermission);
                                return data_Character_RemovePlayerPermission;
                            case GameActionType.House_RentHouse:
                                var data_House_RentHouse = new House_RentHouse();
                                data_House_RentHouse.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_RentHouse));
                                _OnOrdered_GameAction?.Invoke(this,  data_House_RentHouse);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_RentHouse));
                                _OnHouse_RentHouse?.Invoke(this, data_House_RentHouse);
                                return data_House_RentHouse;
                            case GameActionType.Character_SetDesiredComponentLevel:
                                var data_Character_SetDesiredComponentLevel = new Character_SetDesiredComponentLevel();
                                data_Character_SetDesiredComponentLevel.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_SetDesiredComponentLevel));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_SetDesiredComponentLevel);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_SetDesiredComponentLevel));
                                _OnCharacter_SetDesiredComponentLevel?.Invoke(this, data_Character_SetDesiredComponentLevel);
                                return data_Character_SetDesiredComponentLevel;
                            case GameActionType.House_AddPermanentGuest:
                                var data_House_AddPermanentGuest = new House_AddPermanentGuest();
                                data_House_AddPermanentGuest.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_AddPermanentGuest));
                                _OnOrdered_GameAction?.Invoke(this,  data_House_AddPermanentGuest);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_AddPermanentGuest));
                                _OnHouse_AddPermanentGuest?.Invoke(this, data_House_AddPermanentGuest);
                                return data_House_AddPermanentGuest;
                            case GameActionType.House_RemovePermanentGuest:
                                var data_House_RemovePermanentGuest = new House_RemovePermanentGuest();
                                data_House_RemovePermanentGuest.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_RemovePermanentGuest));
                                _OnOrdered_GameAction?.Invoke(this,  data_House_RemovePermanentGuest);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_RemovePermanentGuest));
                                _OnHouse_RemovePermanentGuest?.Invoke(this, data_House_RemovePermanentGuest);
                                return data_House_RemovePermanentGuest;
                            case GameActionType.House_SetOpenHouseStatus:
                                var data_House_SetOpenHouseStatus = new House_SetOpenHouseStatus();
                                data_House_SetOpenHouseStatus.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_SetOpenHouseStatus));
                                _OnOrdered_GameAction?.Invoke(this,  data_House_SetOpenHouseStatus);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_SetOpenHouseStatus));
                                _OnHouse_SetOpenHouseStatus?.Invoke(this, data_House_SetOpenHouseStatus);
                                return data_House_SetOpenHouseStatus;
                            case GameActionType.House_ChangeStoragePermission:
                                var data_House_ChangeStoragePermission = new House_ChangeStoragePermission();
                                data_House_ChangeStoragePermission.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_ChangeStoragePermission));
                                _OnOrdered_GameAction?.Invoke(this,  data_House_ChangeStoragePermission);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_ChangeStoragePermission));
                                _OnHouse_ChangeStoragePermission?.Invoke(this, data_House_ChangeStoragePermission);
                                return data_House_ChangeStoragePermission;
                            case GameActionType.House_BootSpecificHouseGuest:
                                var data_House_BootSpecificHouseGuest = new House_BootSpecificHouseGuest();
                                data_House_BootSpecificHouseGuest.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_BootSpecificHouseGuest));
                                _OnOrdered_GameAction?.Invoke(this,  data_House_BootSpecificHouseGuest);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_BootSpecificHouseGuest));
                                _OnHouse_BootSpecificHouseGuest?.Invoke(this, data_House_BootSpecificHouseGuest);
                                return data_House_BootSpecificHouseGuest;
                            case GameActionType.House_RemoveAllStoragePermission:
                                var data_House_RemoveAllStoragePermission = new House_RemoveAllStoragePermission();
                                data_House_RemoveAllStoragePermission.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_RemoveAllStoragePermission));
                                _OnOrdered_GameAction?.Invoke(this,  data_House_RemoveAllStoragePermission);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_RemoveAllStoragePermission));
                                _OnHouse_RemoveAllStoragePermission?.Invoke(this, data_House_RemoveAllStoragePermission);
                                return data_House_RemoveAllStoragePermission;
                            case GameActionType.House_RequestFullGuestList:
                                var data_House_RequestFullGuestList = new House_RequestFullGuestList();
                                data_House_RequestFullGuestList.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_RequestFullGuestList));
                                _OnOrdered_GameAction?.Invoke(this,  data_House_RequestFullGuestList);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_RequestFullGuestList));
                                _OnHouse_RequestFullGuestList?.Invoke(this, data_House_RequestFullGuestList);
                                return data_House_RequestFullGuestList;
                            case GameActionType.Allegiance_SetMotd:
                                var data_Allegiance_SetMotd = new Allegiance_SetMotd();
                                data_Allegiance_SetMotd.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_SetMotd));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_SetMotd);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_SetMotd));
                                _OnAllegiance_SetMotd?.Invoke(this, data_Allegiance_SetMotd);
                                return data_Allegiance_SetMotd;
                            case GameActionType.Allegiance_QueryMotd:
                                var data_Allegiance_QueryMotd = new Allegiance_QueryMotd();
                                data_Allegiance_QueryMotd.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_QueryMotd));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_QueryMotd);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_QueryMotd));
                                _OnAllegiance_QueryMotd?.Invoke(this, data_Allegiance_QueryMotd);
                                return data_Allegiance_QueryMotd;
                            case GameActionType.Allegiance_ClearMotd:
                                var data_Allegiance_ClearMotd = new Allegiance_ClearMotd();
                                data_Allegiance_ClearMotd.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_ClearMotd));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_ClearMotd);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_ClearMotd));
                                _OnAllegiance_ClearMotd?.Invoke(this, data_Allegiance_ClearMotd);
                                return data_Allegiance_ClearMotd;
                            case GameActionType.House_QueryLord:
                                var data_House_QueryLord = new House_QueryLord();
                                data_House_QueryLord.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_QueryLord));
                                _OnOrdered_GameAction?.Invoke(this,  data_House_QueryLord);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_QueryLord));
                                _OnHouse_QueryLord?.Invoke(this, data_House_QueryLord);
                                return data_House_QueryLord;
                            case GameActionType.House_AddAllStoragePermission:
                                var data_House_AddAllStoragePermission = new House_AddAllStoragePermission();
                                data_House_AddAllStoragePermission.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_AddAllStoragePermission));
                                _OnOrdered_GameAction?.Invoke(this,  data_House_AddAllStoragePermission);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_AddAllStoragePermission));
                                _OnHouse_AddAllStoragePermission?.Invoke(this, data_House_AddAllStoragePermission);
                                return data_House_AddAllStoragePermission;
                            case GameActionType.House_RemoveAllPermanentGuests:
                                var data_House_RemoveAllPermanentGuests = new House_RemoveAllPermanentGuests();
                                data_House_RemoveAllPermanentGuests.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_RemoveAllPermanentGuests));
                                _OnOrdered_GameAction?.Invoke(this,  data_House_RemoveAllPermanentGuests);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_RemoveAllPermanentGuests));
                                _OnHouse_RemoveAllPermanentGuests?.Invoke(this, data_House_RemoveAllPermanentGuests);
                                return data_House_RemoveAllPermanentGuests;
                            case GameActionType.House_BootEveryone:
                                var data_House_BootEveryone = new House_BootEveryone();
                                data_House_BootEveryone.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_BootEveryone));
                                _OnOrdered_GameAction?.Invoke(this,  data_House_BootEveryone);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_BootEveryone));
                                _OnHouse_BootEveryone?.Invoke(this, data_House_BootEveryone);
                                return data_House_BootEveryone;
                            case GameActionType.House_TeleToHouse:
                                var data_House_TeleToHouse = new House_TeleToHouse();
                                data_House_TeleToHouse.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_TeleToHouse));
                                _OnOrdered_GameAction?.Invoke(this,  data_House_TeleToHouse);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_TeleToHouse));
                                _OnHouse_TeleToHouse?.Invoke(this, data_House_TeleToHouse);
                                return data_House_TeleToHouse;
                            case GameActionType.Item_QueryItemMana:
                                var data_Item_QueryItemMana = new Item_QueryItemMana();
                                data_Item_QueryItemMana.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Item_QueryItemMana));
                                _OnOrdered_GameAction?.Invoke(this,  data_Item_QueryItemMana);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Item_QueryItemMana));
                                _OnItem_QueryItemMana?.Invoke(this, data_Item_QueryItemMana);
                                return data_Item_QueryItemMana;
                            case GameActionType.House_SetHooksVisibility:
                                var data_House_SetHooksVisibility = new House_SetHooksVisibility();
                                data_House_SetHooksVisibility.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_SetHooksVisibility));
                                _OnOrdered_GameAction?.Invoke(this,  data_House_SetHooksVisibility);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_SetHooksVisibility));
                                _OnHouse_SetHooksVisibility?.Invoke(this, data_House_SetHooksVisibility);
                                return data_House_SetHooksVisibility;
                            case GameActionType.House_ModifyAllegianceGuestPermission:
                                var data_House_ModifyAllegianceGuestPermission = new House_ModifyAllegianceGuestPermission();
                                data_House_ModifyAllegianceGuestPermission.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_ModifyAllegianceGuestPermission));
                                _OnOrdered_GameAction?.Invoke(this,  data_House_ModifyAllegianceGuestPermission);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_ModifyAllegianceGuestPermission));
                                _OnHouse_ModifyAllegianceGuestPermission?.Invoke(this, data_House_ModifyAllegianceGuestPermission);
                                return data_House_ModifyAllegianceGuestPermission;
                            case GameActionType.House_ModifyAllegianceStoragePermission:
                                var data_House_ModifyAllegianceStoragePermission = new House_ModifyAllegianceStoragePermission();
                                data_House_ModifyAllegianceStoragePermission.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_ModifyAllegianceStoragePermission));
                                _OnOrdered_GameAction?.Invoke(this,  data_House_ModifyAllegianceStoragePermission);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_ModifyAllegianceStoragePermission));
                                _OnHouse_ModifyAllegianceStoragePermission?.Invoke(this, data_House_ModifyAllegianceStoragePermission);
                                return data_House_ModifyAllegianceStoragePermission;
                            case GameActionType.Game_Join:
                                var data_Game_Join = new Game_Join();
                                data_Game_Join.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Game_Join));
                                _OnOrdered_GameAction?.Invoke(this,  data_Game_Join);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Game_Join));
                                _OnGame_Join?.Invoke(this, data_Game_Join);
                                return data_Game_Join;
                            case GameActionType.Game_Quit:
                                var data_Game_Quit = new Game_Quit();
                                data_Game_Quit.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Game_Quit));
                                _OnOrdered_GameAction?.Invoke(this,  data_Game_Quit);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Game_Quit));
                                _OnGame_Quit?.Invoke(this, data_Game_Quit);
                                return data_Game_Quit;
                            case GameActionType.Game_Move:
                                var data_Game_Move = new Game_Move();
                                data_Game_Move.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Game_Move));
                                _OnOrdered_GameAction?.Invoke(this,  data_Game_Move);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Game_Move));
                                _OnGame_Move?.Invoke(this, data_Game_Move);
                                return data_Game_Move;
                            case GameActionType.Game_MovePass:
                                var data_Game_MovePass = new Game_MovePass();
                                data_Game_MovePass.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Game_MovePass));
                                _OnOrdered_GameAction?.Invoke(this,  data_Game_MovePass);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Game_MovePass));
                                _OnGame_MovePass?.Invoke(this, data_Game_MovePass);
                                return data_Game_MovePass;
                            case GameActionType.Game_Stalemate:
                                var data_Game_Stalemate = new Game_Stalemate();
                                data_Game_Stalemate.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Game_Stalemate));
                                _OnOrdered_GameAction?.Invoke(this,  data_Game_Stalemate);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Game_Stalemate));
                                _OnGame_Stalemate?.Invoke(this, data_Game_Stalemate);
                                return data_Game_Stalemate;
                            case GameActionType.House_ListAvailableHouses:
                                var data_House_ListAvailableHouses = new House_ListAvailableHouses();
                                data_House_ListAvailableHouses.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_ListAvailableHouses));
                                _OnOrdered_GameAction?.Invoke(this,  data_House_ListAvailableHouses);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_ListAvailableHouses));
                                _OnHouse_ListAvailableHouses?.Invoke(this, data_House_ListAvailableHouses);
                                return data_House_ListAvailableHouses;
                            case GameActionType.Character_ConfirmationResponse:
                                var data_Character_ConfirmationResponse = new Character_ConfirmationResponse();
                                data_Character_ConfirmationResponse.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_ConfirmationResponse));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_ConfirmationResponse);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_ConfirmationResponse));
                                _OnCharacter_ConfirmationResponse?.Invoke(this, data_Character_ConfirmationResponse);
                                return data_Character_ConfirmationResponse;
                            case GameActionType.Allegiance_BreakAllegianceBoot:
                                var data_Allegiance_BreakAllegianceBoot = new Allegiance_BreakAllegianceBoot();
                                data_Allegiance_BreakAllegianceBoot.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_BreakAllegianceBoot));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_BreakAllegianceBoot);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_BreakAllegianceBoot));
                                _OnAllegiance_BreakAllegianceBoot?.Invoke(this, data_Allegiance_BreakAllegianceBoot);
                                return data_Allegiance_BreakAllegianceBoot;
                            case GameActionType.House_TeleToMansion:
                                var data_House_TeleToMansion = new House_TeleToMansion();
                                data_House_TeleToMansion.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_TeleToMansion));
                                _OnOrdered_GameAction?.Invoke(this,  data_House_TeleToMansion);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_TeleToMansion));
                                _OnHouse_TeleToMansion?.Invoke(this, data_House_TeleToMansion);
                                return data_House_TeleToMansion;
                            case GameActionType.Character_Suicide:
                                var data_Character_Suicide = new Character_Suicide();
                                data_Character_Suicide.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_Suicide));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_Suicide);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_Suicide));
                                _OnCharacter_Suicide?.Invoke(this, data_Character_Suicide);
                                return data_Character_Suicide;
                            case GameActionType.Allegiance_AllegianceInfoRequest:
                                var data_Allegiance_AllegianceInfoRequest = new Allegiance_AllegianceInfoRequest();
                                data_Allegiance_AllegianceInfoRequest.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_AllegianceInfoRequest));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_AllegianceInfoRequest);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_AllegianceInfoRequest));
                                _OnAllegiance_AllegianceInfoRequest?.Invoke(this, data_Allegiance_AllegianceInfoRequest);
                                return data_Allegiance_AllegianceInfoRequest;
                            case GameActionType.Inventory_CreateTinkeringTool:
                                var data_Inventory_CreateTinkeringTool = new Inventory_CreateTinkeringTool();
                                data_Inventory_CreateTinkeringTool.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Inventory_CreateTinkeringTool));
                                _OnOrdered_GameAction?.Invoke(this,  data_Inventory_CreateTinkeringTool);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Inventory_CreateTinkeringTool));
                                _OnInventory_CreateTinkeringTool?.Invoke(this, data_Inventory_CreateTinkeringTool);
                                return data_Inventory_CreateTinkeringTool;
                            case GameActionType.Character_SpellbookFilterEvent:
                                var data_Character_SpellbookFilterEvent = new Character_SpellbookFilterEvent();
                                data_Character_SpellbookFilterEvent.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_SpellbookFilterEvent));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_SpellbookFilterEvent);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_SpellbookFilterEvent));
                                _OnCharacter_SpellbookFilterEvent?.Invoke(this, data_Character_SpellbookFilterEvent);
                                return data_Character_SpellbookFilterEvent;
                            case GameActionType.Character_TeleToMarketplace:
                                var data_Character_TeleToMarketplace = new Character_TeleToMarketplace();
                                data_Character_TeleToMarketplace.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_TeleToMarketplace));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_TeleToMarketplace);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_TeleToMarketplace));
                                _OnCharacter_TeleToMarketplace?.Invoke(this, data_Character_TeleToMarketplace);
                                return data_Character_TeleToMarketplace;
                            case GameActionType.Character_EnterPKLite:
                                var data_Character_EnterPKLite = new Character_EnterPKLite();
                                data_Character_EnterPKLite.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_EnterPKLite));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_EnterPKLite);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_EnterPKLite));
                                _OnCharacter_EnterPKLite?.Invoke(this, data_Character_EnterPKLite);
                                return data_Character_EnterPKLite;
                            case GameActionType.Fellowship_AssignNewLeader:
                                var data_Fellowship_AssignNewLeader = new Fellowship_AssignNewLeader();
                                data_Fellowship_AssignNewLeader.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Fellowship_AssignNewLeader));
                                _OnOrdered_GameAction?.Invoke(this,  data_Fellowship_AssignNewLeader);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Fellowship_AssignNewLeader));
                                _OnFellowship_AssignNewLeader?.Invoke(this, data_Fellowship_AssignNewLeader);
                                return data_Fellowship_AssignNewLeader;
                            case GameActionType.Fellowship_ChangeFellowOpeness:
                                var data_Fellowship_ChangeFellowOpeness = new Fellowship_ChangeFellowOpeness();
                                data_Fellowship_ChangeFellowOpeness.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Fellowship_ChangeFellowOpeness));
                                _OnOrdered_GameAction?.Invoke(this,  data_Fellowship_ChangeFellowOpeness);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Fellowship_ChangeFellowOpeness));
                                _OnFellowship_ChangeFellowOpeness?.Invoke(this, data_Fellowship_ChangeFellowOpeness);
                                return data_Fellowship_ChangeFellowOpeness;
                            case GameActionType.Allegiance_AllegianceChatBoot:
                                var data_Allegiance_AllegianceChatBoot = new Allegiance_AllegianceChatBoot();
                                data_Allegiance_AllegianceChatBoot.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_AllegianceChatBoot));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_AllegianceChatBoot);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_AllegianceChatBoot));
                                _OnAllegiance_AllegianceChatBoot?.Invoke(this, data_Allegiance_AllegianceChatBoot);
                                return data_Allegiance_AllegianceChatBoot;
                            case GameActionType.Allegiance_AddAllegianceBan:
                                var data_Allegiance_AddAllegianceBan = new Allegiance_AddAllegianceBan();
                                data_Allegiance_AddAllegianceBan.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_AddAllegianceBan));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_AddAllegianceBan);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_AddAllegianceBan));
                                _OnAllegiance_AddAllegianceBan?.Invoke(this, data_Allegiance_AddAllegianceBan);
                                return data_Allegiance_AddAllegianceBan;
                            case GameActionType.Allegiance_RemoveAllegianceBan:
                                var data_Allegiance_RemoveAllegianceBan = new Allegiance_RemoveAllegianceBan();
                                data_Allegiance_RemoveAllegianceBan.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_RemoveAllegianceBan));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_RemoveAllegianceBan);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_RemoveAllegianceBan));
                                _OnAllegiance_RemoveAllegianceBan?.Invoke(this, data_Allegiance_RemoveAllegianceBan);
                                return data_Allegiance_RemoveAllegianceBan;
                            case GameActionType.Allegiance_ListAllegianceBans:
                                var data_Allegiance_ListAllegianceBans = new Allegiance_ListAllegianceBans();
                                data_Allegiance_ListAllegianceBans.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_ListAllegianceBans));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_ListAllegianceBans);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_ListAllegianceBans));
                                _OnAllegiance_ListAllegianceBans?.Invoke(this, data_Allegiance_ListAllegianceBans);
                                return data_Allegiance_ListAllegianceBans;
                            case GameActionType.Allegiance_RemoveAllegianceOfficer:
                                var data_Allegiance_RemoveAllegianceOfficer = new Allegiance_RemoveAllegianceOfficer();
                                data_Allegiance_RemoveAllegianceOfficer.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_RemoveAllegianceOfficer));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_RemoveAllegianceOfficer);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_RemoveAllegianceOfficer));
                                _OnAllegiance_RemoveAllegianceOfficer?.Invoke(this, data_Allegiance_RemoveAllegianceOfficer);
                                return data_Allegiance_RemoveAllegianceOfficer;
                            case GameActionType.Allegiance_ListAllegianceOfficers:
                                var data_Allegiance_ListAllegianceOfficers = new Allegiance_ListAllegianceOfficers();
                                data_Allegiance_ListAllegianceOfficers.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_ListAllegianceOfficers));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_ListAllegianceOfficers);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_ListAllegianceOfficers));
                                _OnAllegiance_ListAllegianceOfficers?.Invoke(this, data_Allegiance_ListAllegianceOfficers);
                                return data_Allegiance_ListAllegianceOfficers;
                            case GameActionType.Allegiance_ClearAllegianceOfficers:
                                var data_Allegiance_ClearAllegianceOfficers = new Allegiance_ClearAllegianceOfficers();
                                data_Allegiance_ClearAllegianceOfficers.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_ClearAllegianceOfficers));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_ClearAllegianceOfficers);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_ClearAllegianceOfficers));
                                _OnAllegiance_ClearAllegianceOfficers?.Invoke(this, data_Allegiance_ClearAllegianceOfficers);
                                return data_Allegiance_ClearAllegianceOfficers;
                            case GameActionType.Allegiance_RecallAllegianceHometown:
                                var data_Allegiance_RecallAllegianceHometown = new Allegiance_RecallAllegianceHometown();
                                data_Allegiance_RecallAllegianceHometown.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_RecallAllegianceHometown));
                                _OnOrdered_GameAction?.Invoke(this,  data_Allegiance_RecallAllegianceHometown);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_RecallAllegianceHometown));
                                _OnAllegiance_RecallAllegianceHometown?.Invoke(this, data_Allegiance_RecallAllegianceHometown);
                                return data_Allegiance_RecallAllegianceHometown;
                            case GameActionType.Admin_QueryPluginListResponse:
                                var data_Admin_QueryPluginListResponse = new Admin_QueryPluginListResponse();
                                data_Admin_QueryPluginListResponse.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Admin_QueryPluginListResponse));
                                _OnOrdered_GameAction?.Invoke(this,  data_Admin_QueryPluginListResponse);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Admin_QueryPluginListResponse));
                                _OnAdmin_QueryPluginListResponse?.Invoke(this, data_Admin_QueryPluginListResponse);
                                return data_Admin_QueryPluginListResponse;
                            case GameActionType.Admin_QueryPluginResponse:
                                var data_Admin_QueryPluginResponse = new Admin_QueryPluginResponse();
                                data_Admin_QueryPluginResponse.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Admin_QueryPluginResponse));
                                _OnOrdered_GameAction?.Invoke(this,  data_Admin_QueryPluginResponse);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Admin_QueryPluginResponse));
                                _OnAdmin_QueryPluginResponse?.Invoke(this, data_Admin_QueryPluginResponse);
                                return data_Admin_QueryPluginResponse;
                            case GameActionType.Character_FinishBarber:
                                var data_Character_FinishBarber = new Character_FinishBarber();
                                data_Character_FinishBarber.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_FinishBarber));
                                _OnOrdered_GameAction?.Invoke(this,  data_Character_FinishBarber);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_FinishBarber));
                                _OnCharacter_FinishBarber?.Invoke(this, data_Character_FinishBarber);
                                return data_Character_FinishBarber;
                            case GameActionType.Social_AbandonContract:
                                var data_Social_AbandonContract = new Social_AbandonContract();
                                data_Social_AbandonContract.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Social_AbandonContract));
                                _OnOrdered_GameAction?.Invoke(this,  data_Social_AbandonContract);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Social_AbandonContract));
                                _OnSocial_AbandonContract?.Invoke(this, data_Social_AbandonContract);
                                return data_Social_AbandonContract;
                            case GameActionType.Movement_Jump:
                                var data_Movement_Jump = new Movement_Jump();
                                data_Movement_Jump.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Movement_Jump));
                                _OnOrdered_GameAction?.Invoke(this,  data_Movement_Jump);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Movement_Jump));
                                _OnMovement_Jump?.Invoke(this, data_Movement_Jump);
                                return data_Movement_Jump;
                            case GameActionType.Movement_MoveToState:
                                var data_Movement_MoveToState = new Movement_MoveToState();
                                data_Movement_MoveToState.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Movement_MoveToState));
                                _OnOrdered_GameAction?.Invoke(this,  data_Movement_MoveToState);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Movement_MoveToState));
                                _OnMovement_MoveToState?.Invoke(this, data_Movement_MoveToState);
                                return data_Movement_MoveToState;
                            case GameActionType.Movement_DoMovementCommand:
                                var data_Movement_DoMovementCommand = new Movement_DoMovementCommand();
                                data_Movement_DoMovementCommand.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Movement_DoMovementCommand));
                                _OnOrdered_GameAction?.Invoke(this,  data_Movement_DoMovementCommand);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Movement_DoMovementCommand));
                                _OnMovement_DoMovementCommand?.Invoke(this, data_Movement_DoMovementCommand);
                                return data_Movement_DoMovementCommand;
                            case GameActionType.Movement_StopMovementCommand:
                                var data_Movement_StopMovementCommand = new Movement_StopMovementCommand();
                                data_Movement_StopMovementCommand.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Movement_StopMovementCommand));
                                _OnOrdered_GameAction?.Invoke(this,  data_Movement_StopMovementCommand);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Movement_StopMovementCommand));
                                _OnMovement_StopMovementCommand?.Invoke(this, data_Movement_StopMovementCommand);
                                return data_Movement_StopMovementCommand;
                            case GameActionType.Movement_AutonomyLevel:
                                var data_Movement_AutonomyLevel = new Movement_AutonomyLevel();
                                data_Movement_AutonomyLevel.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Movement_AutonomyLevel));
                                _OnOrdered_GameAction?.Invoke(this,  data_Movement_AutonomyLevel);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Movement_AutonomyLevel));
                                _OnMovement_AutonomyLevel?.Invoke(this, data_Movement_AutonomyLevel);
                                return data_Movement_AutonomyLevel;
                            case GameActionType.Movement_AutonomousPosition:
                                var data_Movement_AutonomousPosition = new Movement_AutonomousPosition();
                                data_Movement_AutonomousPosition.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Movement_AutonomousPosition));
                                _OnOrdered_GameAction?.Invoke(this,  data_Movement_AutonomousPosition);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Movement_AutonomousPosition));
                                _OnMovement_AutonomousPosition?.Invoke(this, data_Movement_AutonomousPosition);
                                return data_Movement_AutonomousPosition;
                            case GameActionType.Movement_Jump_NonAutonomous:
                                var data_Movement_Jump_NonAutonomous = new Movement_Jump_NonAutonomous();
                                data_Movement_Jump_NonAutonomous.Read(reader);
                                _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Movement_Jump_NonAutonomous));
                                _OnOrdered_GameAction?.Invoke(this,  data_Movement_Jump_NonAutonomous);
                                _OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Movement_Jump_NonAutonomous));
                                _OnMovement_Jump_NonAutonomous?.Invoke(this, data_Movement_Jump_NonAutonomous);
                                return data_Movement_Jump_NonAutonomous;
                        }
                        return null; // end 0xF7B1
    
                    case C2SMessageType.Login_LogOffCharacter:
                        var data_Login_LogOffCharacter = new Login_LogOffCharacter();
                        data_Login_LogOffCharacter.Read(reader);
                        _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Login_LogOffCharacter));
                        _OnLogin_LogOffCharacter?.Invoke(this, data_Login_LogOffCharacter);
                        return data_Login_LogOffCharacter;
    
                    case C2SMessageType.Character_CharacterDelete:
                        var data_Character_CharacterDelete = new Character_CharacterDelete();
                        data_Character_CharacterDelete.Read(reader);
                        _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_CharacterDelete));
                        _OnCharacter_CharacterDelete?.Invoke(this, data_Character_CharacterDelete);
                        return data_Character_CharacterDelete;
    
                    case C2SMessageType.Character_SendCharGenResult:
                        var data_Character_SendCharGenResult = new Character_SendCharGenResult();
                        data_Character_SendCharGenResult.Read(reader);
                        _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_SendCharGenResult));
                        _OnCharacter_SendCharGenResult?.Invoke(this, data_Character_SendCharGenResult);
                        return data_Character_SendCharGenResult;
    
                    case C2SMessageType.Login_SendEnterWorld:
                        var data_Login_SendEnterWorld = new Login_SendEnterWorld();
                        data_Login_SendEnterWorld.Read(reader);
                        _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Login_SendEnterWorld));
                        _OnLogin_SendEnterWorld?.Invoke(this, data_Login_SendEnterWorld);
                        return data_Login_SendEnterWorld;
    
                    case C2SMessageType.Object_SendForceObjdesc:
                        var data_Object_SendForceObjdesc = new Object_SendForceObjdesc();
                        data_Object_SendForceObjdesc.Read(reader);
                        _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Object_SendForceObjdesc));
                        _OnObject_SendForceObjdesc?.Invoke(this, data_Object_SendForceObjdesc);
                        return data_Object_SendForceObjdesc;
    
                    case C2SMessageType.Login_SendEnterWorldRequest:
                        var data_Login_SendEnterWorldRequest = new Login_SendEnterWorldRequest();
                        data_Login_SendEnterWorldRequest.Read(reader);
                        _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Login_SendEnterWorldRequest));
                        _OnLogin_SendEnterWorldRequest?.Invoke(this, data_Login_SendEnterWorldRequest);
                        return data_Login_SendEnterWorldRequest;
    
                    case C2SMessageType.Admin_SendAdminGetServerVersion:
                        var data_Admin_SendAdminGetServerVersion = new Admin_SendAdminGetServerVersion();
                        data_Admin_SendAdminGetServerVersion.Read(reader);
                        _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Admin_SendAdminGetServerVersion));
                        _OnAdmin_SendAdminGetServerVersion?.Invoke(this, data_Admin_SendAdminGetServerVersion);
                        return data_Admin_SendAdminGetServerVersion;
    
                    case C2SMessageType.Social_SendFriendsCommand:
                        var data_Social_SendFriendsCommand = new Social_SendFriendsCommand();
                        data_Social_SendFriendsCommand.Read(reader);
                        _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Social_SendFriendsCommand));
                        _OnSocial_SendFriendsCommand?.Invoke(this, data_Social_SendFriendsCommand);
                        return data_Social_SendFriendsCommand;
    
                    case C2SMessageType.Admin_SendAdminRestoreCharacter:
                        var data_Admin_SendAdminRestoreCharacter = new Admin_SendAdminRestoreCharacter();
                        data_Admin_SendAdminRestoreCharacter.Read(reader);
                        _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Admin_SendAdminRestoreCharacter));
                        _OnAdmin_SendAdminRestoreCharacter?.Invoke(this, data_Admin_SendAdminRestoreCharacter);
                        return data_Admin_SendAdminRestoreCharacter;
    
                    case C2SMessageType.Communication_TurbineChat:
                        var data_Communication_TurbineChat = new Communication_TurbineChat();
                        data_Communication_TurbineChat.Read(reader);
                        _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_TurbineChat));
                        _OnCommunication_TurbineChat?.Invoke(this, data_Communication_TurbineChat);
                        return data_Communication_TurbineChat;
    
                    case C2SMessageType.DDD_RequestDataMessage:
                        var data_DDD_RequestDataMessage = new DDD_RequestDataMessage();
                        data_DDD_RequestDataMessage.Read(reader);
                        _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_DDD_RequestDataMessage));
                        _OnDDD_RequestDataMessage?.Invoke(this, data_DDD_RequestDataMessage);
                        return data_DDD_RequestDataMessage;
    
                    case C2SMessageType.DDD_InterrogationResponseMessage:
                        var data_DDD_InterrogationResponseMessage = new DDD_InterrogationResponseMessage();
                        data_DDD_InterrogationResponseMessage.Read(reader);
                        _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_DDD_InterrogationResponseMessage));
                        _OnDDD_InterrogationResponseMessage?.Invoke(this, data_DDD_InterrogationResponseMessage);
                        return data_DDD_InterrogationResponseMessage;
    
                    case C2SMessageType.DDD_EndDDDMessage:
                        var data_DDD_EndDDDMessage = new DDD_EndDDDMessage();
                        data_DDD_EndDDDMessage.Read(reader);
                        _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_DDD_EndDDDMessage));
                        _OnDDD_EndDDDMessage?.Invoke(this, data_DDD_EndDDDMessage);
                        return data_DDD_EndDDDMessage;
    
                    case C2SMessageType.DDD_OnEndDDD:
                        var data_DDD_OnEndDDD = new DDD_OnEndDDD();
                        data_DDD_OnEndDDD.Read(reader);
                        _OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_DDD_OnEndDDD));
                        _OnDDD_OnEndDDD?.Invoke(this, data_DDD_OnEndDDD);
                        return data_DDD_OnEndDDD;
    
                default:
                    var rawData = reader.ReadBytes((int)(reader.BaseStream.Length - reader.BaseStream.Position));
                    _OnUnknownMessage?.Invoke(this, new UnknownMessageEventArgs(MessageDirection.ClientToServer, (uint)opcode, rawData));
                    return null;
            }
        }
    }
}

        