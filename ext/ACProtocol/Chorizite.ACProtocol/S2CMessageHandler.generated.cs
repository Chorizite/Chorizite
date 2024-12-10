
using System;
using System.IO;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Messages.S2C;
using Chorizite.ACProtocol.Messages.S2C.Events;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol;
using Chorizite.Common;
using Chorizite.Common.Enums;

namespace Chorizite.ACProtocol {

    public class S2CMessageHandler {
        /// <summary>
        /// Fired for every valid parsed Message
        /// </summary>
        public event EventHandler<S2CMessageEventArgs>? OnMessage {
            add { _OnMessage.Subscribe(value); }
            remove { _OnMessage.Unsubscribe(value); }
        }
        private readonly WeakEvent<S2CMessageEventArgs> _OnMessage = new();

        /// <summary>
        /// Fired for every valid parsed GameEvent
        /// </summary>
        public event EventHandler<GameEventEventArgs>? OnGameEvent {
            add { _OnGameEvent.Subscribe(value); }
            remove { _OnGameEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<GameEventEventArgs> _OnGameEvent = new();

        /// <summary>
        /// Fired when an unknown Message type was encountered 
        /// </summary>
        public event EventHandler<UnknownMessageEventArgs>? OnUnknownMessage {
            add { _OnUnknownMessage.Subscribe(value); }
            remove { _OnUnknownMessage.Unsubscribe(value); }
        }
        private readonly WeakEvent<UnknownMessageEventArgs> _OnUnknownMessage = new();

        /// <summary>
        /// Fired on Message type 0x0024 Item_ServerSaysRemove. Sent every time an object you are aware of ceases to exist. Merely running out of range does not generate this message - in that case, the client just automatically stops tracking it after receiving no updates for a while (which I presume is a very short while).
        /// </summary>
        public event EventHandler<Item_ServerSaysRemove>? OnItem_ServerSaysRemove {
            add { _OnItem_ServerSaysRemove.Subscribe(value); }
            remove { _OnItem_ServerSaysRemove.Unsubscribe(value); }
        }
        private readonly WeakEvent<Item_ServerSaysRemove> _OnItem_ServerSaysRemove = new();
    
        /// <summary>
        /// Fired on Message type 0x00A0 Character_ServerSaysAttemptFailed. Failure to give an item
        /// </summary>
        public event EventHandler<Character_ServerSaysAttemptFailed>? OnCharacter_ServerSaysAttemptFailed {
            add { _OnCharacter_ServerSaysAttemptFailed.Subscribe(value); }
            remove { _OnCharacter_ServerSaysAttemptFailed.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_ServerSaysAttemptFailed> _OnCharacter_ServerSaysAttemptFailed = new();
    
        /// <summary>
        /// Fired on Message type 0x0197 Item_UpdateStackSize. For stackable items, this changes the number of items in the stack.
        /// </summary>
        public event EventHandler<Item_UpdateStackSize>? OnItem_UpdateStackSize {
            add { _OnItem_UpdateStackSize.Subscribe(value); }
            remove { _OnItem_UpdateStackSize.Unsubscribe(value); }
        }
        private readonly WeakEvent<Item_UpdateStackSize> _OnItem_UpdateStackSize = new();
    
        /// <summary>
        /// Fired on Message type 0x019E Combat_HandlePlayerDeathEvent. A Player Kill occurred nearby (also sent for suicides).
        /// </summary>
        public event EventHandler<Combat_HandlePlayerDeathEvent>? OnCombat_HandlePlayerDeathEvent {
            add { _OnCombat_HandlePlayerDeathEvent.Subscribe(value); }
            remove { _OnCombat_HandlePlayerDeathEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Combat_HandlePlayerDeathEvent> _OnCombat_HandlePlayerDeathEvent = new();
    
        /// <summary>
        /// Fired on Message type 0x01D1 Qualities_PrivateRemoveIntEvent. Remove an int property from the character
        /// </summary>
        public event EventHandler<Qualities_PrivateRemoveIntEvent>? OnQualities_PrivateRemoveIntEvent {
            add { _OnQualities_PrivateRemoveIntEvent.Subscribe(value); }
            remove { _OnQualities_PrivateRemoveIntEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_PrivateRemoveIntEvent> _OnQualities_PrivateRemoveIntEvent = new();
    
        /// <summary>
        /// Fired on Message type 0x01D2 Qualities_RemoveIntEvent. Remove an int property from an object
        /// </summary>
        public event EventHandler<Qualities_RemoveIntEvent>? OnQualities_RemoveIntEvent {
            add { _OnQualities_RemoveIntEvent.Subscribe(value); }
            remove { _OnQualities_RemoveIntEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_RemoveIntEvent> _OnQualities_RemoveIntEvent = new();
    
        /// <summary>
        /// Fired on Message type 0x01D3 Qualities_PrivateRemoveBoolEvent. Remove a bool property from the charactert
        /// </summary>
        public event EventHandler<Qualities_PrivateRemoveBoolEvent>? OnQualities_PrivateRemoveBoolEvent {
            add { _OnQualities_PrivateRemoveBoolEvent.Subscribe(value); }
            remove { _OnQualities_PrivateRemoveBoolEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_PrivateRemoveBoolEvent> _OnQualities_PrivateRemoveBoolEvent = new();
    
        /// <summary>
        /// Fired on Message type 0x01D4 Qualities_RemoveBoolEvent. Remove a bool property from an object
        /// </summary>
        public event EventHandler<Qualities_RemoveBoolEvent>? OnQualities_RemoveBoolEvent {
            add { _OnQualities_RemoveBoolEvent.Subscribe(value); }
            remove { _OnQualities_RemoveBoolEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_RemoveBoolEvent> _OnQualities_RemoveBoolEvent = new();
    
        /// <summary>
        /// Fired on Message type 0x01D5 Qualities_PrivateRemoveFloatEvent. Remove a float property from the character
        /// </summary>
        public event EventHandler<Qualities_PrivateRemoveFloatEvent>? OnQualities_PrivateRemoveFloatEvent {
            add { _OnQualities_PrivateRemoveFloatEvent.Subscribe(value); }
            remove { _OnQualities_PrivateRemoveFloatEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_PrivateRemoveFloatEvent> _OnQualities_PrivateRemoveFloatEvent = new();
    
        /// <summary>
        /// Fired on Message type 0x01D6 Qualities_RemoveFloatEvent. Remove a float property from an object
        /// </summary>
        public event EventHandler<Qualities_RemoveFloatEvent>? OnQualities_RemoveFloatEvent {
            add { _OnQualities_RemoveFloatEvent.Subscribe(value); }
            remove { _OnQualities_RemoveFloatEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_RemoveFloatEvent> _OnQualities_RemoveFloatEvent = new();
    
        /// <summary>
        /// Fired on Message type 0x01D7 Qualities_PrivateRemoveStringEvent. Remove a string property from the character
        /// </summary>
        public event EventHandler<Qualities_PrivateRemoveStringEvent>? OnQualities_PrivateRemoveStringEvent {
            add { _OnQualities_PrivateRemoveStringEvent.Subscribe(value); }
            remove { _OnQualities_PrivateRemoveStringEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_PrivateRemoveStringEvent> _OnQualities_PrivateRemoveStringEvent = new();
    
        /// <summary>
        /// Fired on Message type 0x01D8 Qualities_RemoveStringEvent. Remove a string property from an object
        /// </summary>
        public event EventHandler<Qualities_RemoveStringEvent>? OnQualities_RemoveStringEvent {
            add { _OnQualities_RemoveStringEvent.Subscribe(value); }
            remove { _OnQualities_RemoveStringEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_RemoveStringEvent> _OnQualities_RemoveStringEvent = new();
    
        /// <summary>
        /// Fired on Message type 0x01D9 Qualities_PrivateRemoveDataIdEvent. Remove an dataId property from the character
        /// </summary>
        public event EventHandler<Qualities_PrivateRemoveDataIdEvent>? OnQualities_PrivateRemoveDataIdEvent {
            add { _OnQualities_PrivateRemoveDataIdEvent.Subscribe(value); }
            remove { _OnQualities_PrivateRemoveDataIdEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_PrivateRemoveDataIdEvent> _OnQualities_PrivateRemoveDataIdEvent = new();
    
        /// <summary>
        /// Fired on Message type 0x01DA Qualities_RemoveDataIdEvent. Remove an dataId property from an object
        /// </summary>
        public event EventHandler<Qualities_RemoveDataIdEvent>? OnQualities_RemoveDataIdEvent {
            add { _OnQualities_RemoveDataIdEvent.Subscribe(value); }
            remove { _OnQualities_RemoveDataIdEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_RemoveDataIdEvent> _OnQualities_RemoveDataIdEvent = new();
    
        /// <summary>
        /// Fired on Message type 0x01DB Qualities_PrivateRemoveInstanceIdEvent. Remove an instanceId property from the character
        /// </summary>
        public event EventHandler<Qualities_PrivateRemoveInstanceIdEvent>? OnQualities_PrivateRemoveInstanceIdEvent {
            add { _OnQualities_PrivateRemoveInstanceIdEvent.Subscribe(value); }
            remove { _OnQualities_PrivateRemoveInstanceIdEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_PrivateRemoveInstanceIdEvent> _OnQualities_PrivateRemoveInstanceIdEvent = new();
    
        /// <summary>
        /// Fired on Message type 0x01DC Qualities_RemoveInstanceIdEvent. Remove an instanceId property from an object
        /// </summary>
        public event EventHandler<Qualities_RemoveInstanceIdEvent>? OnQualities_RemoveInstanceIdEvent {
            add { _OnQualities_RemoveInstanceIdEvent.Subscribe(value); }
            remove { _OnQualities_RemoveInstanceIdEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_RemoveInstanceIdEvent> _OnQualities_RemoveInstanceIdEvent = new();
    
        /// <summary>
        /// Fired on Message type 0x01DD Qualities_PrivateRemovePositionEvent. Remove a position property from the character
        /// </summary>
        public event EventHandler<Qualities_PrivateRemovePositionEvent>? OnQualities_PrivateRemovePositionEvent {
            add { _OnQualities_PrivateRemovePositionEvent.Subscribe(value); }
            remove { _OnQualities_PrivateRemovePositionEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_PrivateRemovePositionEvent> _OnQualities_PrivateRemovePositionEvent = new();
    
        /// <summary>
        /// Fired on Message type 0x01DE Qualities_RemovePositionEvent. Remove a position property from an object
        /// </summary>
        public event EventHandler<Qualities_RemovePositionEvent>? OnQualities_RemovePositionEvent {
            add { _OnQualities_RemovePositionEvent.Subscribe(value); }
            remove { _OnQualities_RemovePositionEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_RemovePositionEvent> _OnQualities_RemovePositionEvent = new();
    
        /// <summary>
        /// Fired on Message type 0x02B8 Qualities_PrivateRemoveInt64Event. Remove an int64 property from the character
        /// </summary>
        public event EventHandler<Qualities_PrivateRemoveInt64Event>? OnQualities_PrivateRemoveInt64Event {
            add { _OnQualities_PrivateRemoveInt64Event.Subscribe(value); }
            remove { _OnQualities_PrivateRemoveInt64Event.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_PrivateRemoveInt64Event> _OnQualities_PrivateRemoveInt64Event = new();
    
        /// <summary>
        /// Fired on Message type 0x02B9 Qualities_RemoveInt64Event. Remove an int64 property from an object
        /// </summary>
        public event EventHandler<Qualities_RemoveInt64Event>? OnQualities_RemoveInt64Event {
            add { _OnQualities_RemoveInt64Event.Subscribe(value); }
            remove { _OnQualities_RemoveInt64Event.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_RemoveInt64Event> _OnQualities_RemoveInt64Event = new();
    
        /// <summary>
        /// Fired on Message type 0x02CD Qualities_PrivateUpdateInt. Set or update a Character Int property value
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateInt>? OnQualities_PrivateUpdateInt {
            add { _OnQualities_PrivateUpdateInt.Subscribe(value); }
            remove { _OnQualities_PrivateUpdateInt.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_PrivateUpdateInt> _OnQualities_PrivateUpdateInt = new();
    
        /// <summary>
        /// Fired on Message type 0x02CE Qualities_UpdateInt. Set or update an Object Int property value
        /// </summary>
        public event EventHandler<Qualities_UpdateInt>? OnQualities_UpdateInt {
            add { _OnQualities_UpdateInt.Subscribe(value); }
            remove { _OnQualities_UpdateInt.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_UpdateInt> _OnQualities_UpdateInt = new();
    
        /// <summary>
        /// Fired on Message type 0x02CF Qualities_PrivateUpdateInt64. Set or update a Character Int64 property value
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateInt64>? OnQualities_PrivateUpdateInt64 {
            add { _OnQualities_PrivateUpdateInt64.Subscribe(value); }
            remove { _OnQualities_PrivateUpdateInt64.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_PrivateUpdateInt64> _OnQualities_PrivateUpdateInt64 = new();
    
        /// <summary>
        /// Fired on Message type 0x02D0 Qualities_UpdateInt64. Set or update a Character Int64 property value
        /// </summary>
        public event EventHandler<Qualities_UpdateInt64>? OnQualities_UpdateInt64 {
            add { _OnQualities_UpdateInt64.Subscribe(value); }
            remove { _OnQualities_UpdateInt64.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_UpdateInt64> _OnQualities_UpdateInt64 = new();
    
        /// <summary>
        /// Fired on Message type 0x02D1 Qualities_PrivateUpdateBool. Set or update a Character Boolean property value
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateBool>? OnQualities_PrivateUpdateBool {
            add { _OnQualities_PrivateUpdateBool.Subscribe(value); }
            remove { _OnQualities_PrivateUpdateBool.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_PrivateUpdateBool> _OnQualities_PrivateUpdateBool = new();
    
        /// <summary>
        /// Fired on Message type 0x02D2 Qualities_UpdateBool. Set or update an Object Boolean property value
        /// </summary>
        public event EventHandler<Qualities_UpdateBool>? OnQualities_UpdateBool {
            add { _OnQualities_UpdateBool.Subscribe(value); }
            remove { _OnQualities_UpdateBool.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_UpdateBool> _OnQualities_UpdateBool = new();
    
        /// <summary>
        /// Fired on Message type 0x02D3 Qualities_PrivateUpdateFloat. Set or update an Object float property value
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateFloat>? OnQualities_PrivateUpdateFloat {
            add { _OnQualities_PrivateUpdateFloat.Subscribe(value); }
            remove { _OnQualities_PrivateUpdateFloat.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_PrivateUpdateFloat> _OnQualities_PrivateUpdateFloat = new();
    
        /// <summary>
        /// Fired on Message type 0x02D4 Qualities_UpdateFloat. Set or update an Object float property value
        /// </summary>
        public event EventHandler<Qualities_UpdateFloat>? OnQualities_UpdateFloat {
            add { _OnQualities_UpdateFloat.Subscribe(value); }
            remove { _OnQualities_UpdateFloat.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_UpdateFloat> _OnQualities_UpdateFloat = new();
    
        /// <summary>
        /// Fired on Message type 0x02D5 Qualities_PrivateUpdateString. Set or update an Object String property value
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateString>? OnQualities_PrivateUpdateString {
            add { _OnQualities_PrivateUpdateString.Subscribe(value); }
            remove { _OnQualities_PrivateUpdateString.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_PrivateUpdateString> _OnQualities_PrivateUpdateString = new();
    
        /// <summary>
        /// Fired on Message type 0x02D6 Qualities_UpdateString. Set or update an Object String property value
        /// </summary>
        public event EventHandler<Qualities_UpdateString>? OnQualities_UpdateString {
            add { _OnQualities_UpdateString.Subscribe(value); }
            remove { _OnQualities_UpdateString.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_UpdateString> _OnQualities_UpdateString = new();
    
        /// <summary>
        /// Fired on Message type 0x02D7 Qualities_PrivateUpdateDataId. Set or update an Object DId property value
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateDataId>? OnQualities_PrivateUpdateDataId {
            add { _OnQualities_PrivateUpdateDataId.Subscribe(value); }
            remove { _OnQualities_PrivateUpdateDataId.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_PrivateUpdateDataId> _OnQualities_PrivateUpdateDataId = new();
    
        /// <summary>
        /// Fired on Message type 0x02D8 Qualities_UpdateDataId. Set or update an Object DId property value
        /// </summary>
        public event EventHandler<Qualities_UpdateDataId>? OnQualities_UpdateDataId {
            add { _OnQualities_UpdateDataId.Subscribe(value); }
            remove { _OnQualities_UpdateDataId.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_UpdateDataId> _OnQualities_UpdateDataId = new();
    
        /// <summary>
        /// Fired on Message type 0x02D9 Qualities_PrivateUpdateInstanceId. Set or update a IId property value
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateInstanceId>? OnQualities_PrivateUpdateInstanceId {
            add { _OnQualities_PrivateUpdateInstanceId.Subscribe(value); }
            remove { _OnQualities_PrivateUpdateInstanceId.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_PrivateUpdateInstanceId> _OnQualities_PrivateUpdateInstanceId = new();
    
        /// <summary>
        /// Fired on Message type 0x02DA Qualities_UpdateInstanceId. Set or update an Object IId property value
        /// </summary>
        public event EventHandler<Qualities_UpdateInstanceId>? OnQualities_UpdateInstanceId {
            add { _OnQualities_UpdateInstanceId.Subscribe(value); }
            remove { _OnQualities_UpdateInstanceId.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_UpdateInstanceId> _OnQualities_UpdateInstanceId = new();
    
        /// <summary>
        /// Fired on Message type 0x02DB Qualities_PrivateUpdatePosition. Set or update a Character Position property value
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdatePosition>? OnQualities_PrivateUpdatePosition {
            add { _OnQualities_PrivateUpdatePosition.Subscribe(value); }
            remove { _OnQualities_PrivateUpdatePosition.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_PrivateUpdatePosition> _OnQualities_PrivateUpdatePosition = new();
    
        /// <summary>
        /// Fired on Message type 0x02DC Qualities_UpdatePosition. Set or update a Character Position property value
        /// </summary>
        public event EventHandler<Qualities_UpdatePosition>? OnQualities_UpdatePosition {
            add { _OnQualities_UpdatePosition.Subscribe(value); }
            remove { _OnQualities_UpdatePosition.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_UpdatePosition> _OnQualities_UpdatePosition = new();
    
        /// <summary>
        /// Fired on Message type 0x02DD Qualities_PrivateUpdateSkill. Set or update a Character Skill value
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateSkill>? OnQualities_PrivateUpdateSkill {
            add { _OnQualities_PrivateUpdateSkill.Subscribe(value); }
            remove { _OnQualities_PrivateUpdateSkill.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_PrivateUpdateSkill> _OnQualities_PrivateUpdateSkill = new();
    
        /// <summary>
        /// Fired on Message type 0x02DE Qualities_UpdateSkill. Set or update a Character Skill value
        /// </summary>
        public event EventHandler<Qualities_UpdateSkill>? OnQualities_UpdateSkill {
            add { _OnQualities_UpdateSkill.Subscribe(value); }
            remove { _OnQualities_UpdateSkill.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_UpdateSkill> _OnQualities_UpdateSkill = new();
    
        /// <summary>
        /// Fired on Message type 0x02DF Qualities_PrivateUpdateSkillLevel. Set or update a Character Skill Level
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateSkillLevel>? OnQualities_PrivateUpdateSkillLevel {
            add { _OnQualities_PrivateUpdateSkillLevel.Subscribe(value); }
            remove { _OnQualities_PrivateUpdateSkillLevel.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_PrivateUpdateSkillLevel> _OnQualities_PrivateUpdateSkillLevel = new();
    
        /// <summary>
        /// Fired on Message type 0x02E0 Qualities_UpdateSkillLevel. Set or update a Character Skill Level
        /// </summary>
        public event EventHandler<Qualities_UpdateSkillLevel>? OnQualities_UpdateSkillLevel {
            add { _OnQualities_UpdateSkillLevel.Subscribe(value); }
            remove { _OnQualities_UpdateSkillLevel.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_UpdateSkillLevel> _OnQualities_UpdateSkillLevel = new();
    
        /// <summary>
        /// Fired on Message type 0x02E1 Qualities_PrivateUpdateSkillAC. Set or update a Character Skill state
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateSkillAC>? OnQualities_PrivateUpdateSkillAC {
            add { _OnQualities_PrivateUpdateSkillAC.Subscribe(value); }
            remove { _OnQualities_PrivateUpdateSkillAC.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_PrivateUpdateSkillAC> _OnQualities_PrivateUpdateSkillAC = new();
    
        /// <summary>
        /// Fired on Message type 0x02E2 Qualities_UpdateSkillAC. Set or update a Character Skill state
        /// </summary>
        public event EventHandler<Qualities_UpdateSkillAC>? OnQualities_UpdateSkillAC {
            add { _OnQualities_UpdateSkillAC.Subscribe(value); }
            remove { _OnQualities_UpdateSkillAC.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_UpdateSkillAC> _OnQualities_UpdateSkillAC = new();
    
        /// <summary>
        /// Fired on Message type 0x02E3 Qualities_PrivateUpdateAttribute. Set or update a Character Attribute value
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateAttribute>? OnQualities_PrivateUpdateAttribute {
            add { _OnQualities_PrivateUpdateAttribute.Subscribe(value); }
            remove { _OnQualities_PrivateUpdateAttribute.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_PrivateUpdateAttribute> _OnQualities_PrivateUpdateAttribute = new();
    
        /// <summary>
        /// Fired on Message type 0x02E4 Qualities_UpdateAttribute. Set or update a Character Attribute value
        /// </summary>
        public event EventHandler<Qualities_UpdateAttribute>? OnQualities_UpdateAttribute {
            add { _OnQualities_UpdateAttribute.Subscribe(value); }
            remove { _OnQualities_UpdateAttribute.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_UpdateAttribute> _OnQualities_UpdateAttribute = new();
    
        /// <summary>
        /// Fired on Message type 0x02E5 Qualities_PrivateUpdateAttributeLevel. Set or update a Character Attribute Level
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateAttributeLevel>? OnQualities_PrivateUpdateAttributeLevel {
            add { _OnQualities_PrivateUpdateAttributeLevel.Subscribe(value); }
            remove { _OnQualities_PrivateUpdateAttributeLevel.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_PrivateUpdateAttributeLevel> _OnQualities_PrivateUpdateAttributeLevel = new();
    
        /// <summary>
        /// Fired on Message type 0x02E6 Qualities_UpdateAttributeLevel. Set or update a Character Attribute Level
        /// </summary>
        public event EventHandler<Qualities_UpdateAttributeLevel>? OnQualities_UpdateAttributeLevel {
            add { _OnQualities_UpdateAttributeLevel.Subscribe(value); }
            remove { _OnQualities_UpdateAttributeLevel.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_UpdateAttributeLevel> _OnQualities_UpdateAttributeLevel = new();
    
        /// <summary>
        /// Fired on Message type 0x02E7 Qualities_PrivateUpdateAttribute2nd. Set or update a Character Vital value
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateAttribute2nd>? OnQualities_PrivateUpdateAttribute2nd {
            add { _OnQualities_PrivateUpdateAttribute2nd.Subscribe(value); }
            remove { _OnQualities_PrivateUpdateAttribute2nd.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_PrivateUpdateAttribute2nd> _OnQualities_PrivateUpdateAttribute2nd = new();
    
        /// <summary>
        /// Fired on Message type 0x02E8 Qualities_UpdateAttribute2nd. Set or update a Character Vital value
        /// </summary>
        public event EventHandler<Qualities_UpdateAttribute2nd>? OnQualities_UpdateAttribute2nd {
            add { _OnQualities_UpdateAttribute2nd.Subscribe(value); }
            remove { _OnQualities_UpdateAttribute2nd.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_UpdateAttribute2nd> _OnQualities_UpdateAttribute2nd = new();
    
        /// <summary>
        /// Fired on Message type 0x02E9 Qualities_PrivateUpdateAttribute2ndLevel. Set or update a Character Vital value
        /// </summary>
        public event EventHandler<Qualities_PrivateUpdateAttribute2ndLevel>? OnQualities_PrivateUpdateAttribute2ndLevel {
            add { _OnQualities_PrivateUpdateAttribute2ndLevel.Subscribe(value); }
            remove { _OnQualities_PrivateUpdateAttribute2ndLevel.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_PrivateUpdateAttribute2ndLevel> _OnQualities_PrivateUpdateAttribute2ndLevel = new();
    
        /// <summary>
        /// Fired on Message type 0x02EA Qualities_UpdateAttribute2ndLevel. Set or update a Character Vital value
        /// </summary>
        public event EventHandler<Qualities_UpdateAttribute2ndLevel>? OnQualities_UpdateAttribute2ndLevel {
            add { _OnQualities_UpdateAttribute2ndLevel.Subscribe(value); }
            remove { _OnQualities_UpdateAttribute2ndLevel.Unsubscribe(value); }
        }
        private readonly WeakEvent<Qualities_UpdateAttribute2ndLevel> _OnQualities_UpdateAttribute2ndLevel = new();
    
        /// <summary>
        /// Fired on Message type 0x01E0 Communication_HearEmote. Indirect '/e' text.
        /// </summary>
        public event EventHandler<Communication_HearEmote>? OnCommunication_HearEmote {
            add { _OnCommunication_HearEmote.Subscribe(value); }
            remove { _OnCommunication_HearEmote.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_HearEmote> _OnCommunication_HearEmote = new();
    
        /// <summary>
        /// Fired on Message type 0x01E2 Communication_HearSoulEmote. Contains the text associated with an emote action.
        /// </summary>
        public event EventHandler<Communication_HearSoulEmote>? OnCommunication_HearSoulEmote {
            add { _OnCommunication_HearSoulEmote.Subscribe(value); }
            remove { _OnCommunication_HearSoulEmote.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_HearSoulEmote> _OnCommunication_HearSoulEmote = new();
    
        /// <summary>
        /// Fired on Message type 0x02BB Communication_HearSpeech. A message to be displayed in the chat window, spoken by a nearby player, NPC or creature
        /// </summary>
        public event EventHandler<Communication_HearSpeech>? OnCommunication_HearSpeech {
            add { _OnCommunication_HearSpeech.Subscribe(value); }
            remove { _OnCommunication_HearSpeech.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_HearSpeech> _OnCommunication_HearSpeech = new();
    
        /// <summary>
        /// Fired on Message type 0x02BC Communication_HearRangedSpeech. A message to be displayed in the chat window, spoken by a nearby player, NPC or creature
        /// </summary>
        public event EventHandler<Communication_HearRangedSpeech>? OnCommunication_HearRangedSpeech {
            add { _OnCommunication_HearRangedSpeech.Subscribe(value); }
            remove { _OnCommunication_HearRangedSpeech.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_HearRangedSpeech> _OnCommunication_HearRangedSpeech = new();
    
        /// <summary>
        /// Fired on Message type 0xEA60 Admin_Environs. This appears to be an admin command to change the environment (light, fog, sounds, colors)
        /// </summary>
        public event EventHandler<Admin_Environs>? OnAdmin_Environs {
            add { _OnAdmin_Environs.Subscribe(value); }
            remove { _OnAdmin_Environs.Unsubscribe(value); }
        }
        private readonly WeakEvent<Admin_Environs> _OnAdmin_Environs = new();
    
        /// <summary>
        /// Fired on Message type 0xF619 Movement_PositionAndMovementEvent. Sets both the position and movement, such as when materializing at a lifestone
        /// </summary>
        public event EventHandler<Movement_PositionAndMovementEvent>? OnMovement_PositionAndMovementEvent {
            add { _OnMovement_PositionAndMovementEvent.Subscribe(value); }
            remove { _OnMovement_PositionAndMovementEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Movement_PositionAndMovementEvent> _OnMovement_PositionAndMovementEvent = new();
    
        /// <summary>
        /// Fired on Message type 0xF625 Item_ObjDescEvent. Sent whenever a character changes their clothes. It contains the entire description of what their wearing (and possibly their facial features as well). This message is only sent for changes, when the character is first created, the body of this message is included inside the creation message.
        /// </summary>
        public event EventHandler<Item_ObjDescEvent>? OnItem_ObjDescEvent {
            add { _OnItem_ObjDescEvent.Subscribe(value); }
            remove { _OnItem_ObjDescEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Item_ObjDescEvent> _OnItem_ObjDescEvent = new();
    
        /// <summary>
        /// Fired on Message type 0xF630 Character_SetPlayerVisualDesc. Sets the player visual desc, TODO confirm this
        /// </summary>
        public event EventHandler<Character_SetPlayerVisualDesc>? OnCharacter_SetPlayerVisualDesc {
            add { _OnCharacter_SetPlayerVisualDesc.Subscribe(value); }
            remove { _OnCharacter_SetPlayerVisualDesc.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_SetPlayerVisualDesc> _OnCharacter_SetPlayerVisualDesc = new();
    
        /// <summary>
        /// Fired on Message type 0xF643 Character_CharGenVerificationResponse. Character creation screen initilised.
        /// </summary>
        public event EventHandler<Character_CharGenVerificationResponse>? OnCharacter_CharGenVerificationResponse {
            add { _OnCharacter_CharGenVerificationResponse.Subscribe(value); }
            remove { _OnCharacter_CharGenVerificationResponse.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_CharGenVerificationResponse> _OnCharacter_CharGenVerificationResponse = new();
    
        /// <summary>
        /// Fired on Message type 0xF651 Login_AwaitingSubscriptionExpiration. Sent when your subsciption is about to expire
        /// </summary>
        public event EventHandler<Login_AwaitingSubscriptionExpiration>? OnLogin_AwaitingSubscriptionExpiration {
            add { _OnLogin_AwaitingSubscriptionExpiration.Subscribe(value); }
            remove { _OnLogin_AwaitingSubscriptionExpiration.Unsubscribe(value); }
        }
        private readonly WeakEvent<Login_AwaitingSubscriptionExpiration> _OnLogin_AwaitingSubscriptionExpiration = new();
    
        /// <summary>
        /// Fired on Message type 0xF653 Login_LogOffCharacter. Instructs the client to return to 2D mode - the character list.
        /// </summary>
        public event EventHandler<Login_LogOffCharacter>? OnLogin_LogOffCharacter {
            add { _OnLogin_LogOffCharacter.Subscribe(value); }
            remove { _OnLogin_LogOffCharacter.Unsubscribe(value); }
        }
        private readonly WeakEvent<Login_LogOffCharacter> _OnLogin_LogOffCharacter = new();
    
        /// <summary>
        /// Fired on Message type 0xF655 Character_CharacterDelete. A character was marked for deletetion.
        /// </summary>
        public event EventHandler<Character_CharacterDelete>? OnCharacter_CharacterDelete {
            add { _OnCharacter_CharacterDelete.Subscribe(value); }
            remove { _OnCharacter_CharacterDelete.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_CharacterDelete> _OnCharacter_CharacterDelete = new();
    
        /// <summary>
        /// Fired on Message type 0xF658 Login_LoginCharacterSet. The list of characters on the current account.
        /// </summary>
        public event EventHandler<Login_LoginCharacterSet>? OnLogin_LoginCharacterSet {
            add { _OnLogin_LoginCharacterSet.Subscribe(value); }
            remove { _OnLogin_LoginCharacterSet.Unsubscribe(value); }
        }
        private readonly WeakEvent<Login_LoginCharacterSet> _OnLogin_LoginCharacterSet = new();
    
        /// <summary>
        /// Fired on Message type 0xF659 Character_CharacterError. Failure to log in
        /// </summary>
        public event EventHandler<Character_CharacterError>? OnCharacter_CharacterError {
            add { _OnCharacter_CharacterError.Subscribe(value); }
            remove { _OnCharacter_CharacterError.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_CharacterError> _OnCharacter_CharacterError = new();
    
        /// <summary>
        /// Fired on Message type 0xF745 Item_CreateObject. Create an object somewhere in the world
        /// </summary>
        public event EventHandler<Item_CreateObject>? OnItem_CreateObject {
            add { _OnItem_CreateObject.Subscribe(value); }
            remove { _OnItem_CreateObject.Unsubscribe(value); }
        }
        private readonly WeakEvent<Item_CreateObject> _OnItem_CreateObject = new();
    
        /// <summary>
        /// Fired on Message type 0xF746 Login_CreatePlayer. Login of player
        /// </summary>
        public event EventHandler<Login_CreatePlayer>? OnLogin_CreatePlayer {
            add { _OnLogin_CreatePlayer.Subscribe(value); }
            remove { _OnLogin_CreatePlayer.Unsubscribe(value); }
        }
        private readonly WeakEvent<Login_CreatePlayer> _OnLogin_CreatePlayer = new();
    
        /// <summary>
        /// Fired on Message type 0xF747 Item_DeleteObject. Sent whenever an object is being deleted from the scene.
        /// </summary>
        public event EventHandler<Item_DeleteObject>? OnItem_DeleteObject {
            add { _OnItem_DeleteObject.Subscribe(value); }
            remove { _OnItem_DeleteObject.Unsubscribe(value); }
        }
        private readonly WeakEvent<Item_DeleteObject> _OnItem_DeleteObject = new();
    
        /// <summary>
        /// Fired on Message type 0xF748 Movement_PositionEvent. Sets the position/motion of an object
        /// </summary>
        public event EventHandler<Movement_PositionEvent>? OnMovement_PositionEvent {
            add { _OnMovement_PositionEvent.Subscribe(value); }
            remove { _OnMovement_PositionEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Movement_PositionEvent> _OnMovement_PositionEvent = new();
    
        /// <summary>
        /// Fired on Message type 0xF749 Item_ParentEvent. Sets the parent for an object, eg. equipting an object.
        /// </summary>
        public event EventHandler<Item_ParentEvent>? OnItem_ParentEvent {
            add { _OnItem_ParentEvent.Subscribe(value); }
            remove { _OnItem_ParentEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Item_ParentEvent> _OnItem_ParentEvent = new();
    
        /// <summary>
        /// Fired on Message type 0xF74A Inventory_PickupEvent. Sent when picking up an object
        /// </summary>
        public event EventHandler<Inventory_PickupEvent>? OnInventory_PickupEvent {
            add { _OnInventory_PickupEvent.Subscribe(value); }
            remove { _OnInventory_PickupEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Inventory_PickupEvent> _OnInventory_PickupEvent = new();
    
        /// <summary>
        /// Fired on Message type 0xF74B Item_SetState. Set's the current state of the object. Client appears to only process the following state changes post creation: NoDraw, LightingOn, Hidden
        /// </summary>
        public event EventHandler<Item_SetState>? OnItem_SetState {
            add { _OnItem_SetState.Subscribe(value); }
            remove { _OnItem_SetState.Unsubscribe(value); }
        }
        private readonly WeakEvent<Item_SetState> _OnItem_SetState = new();
    
        /// <summary>
        /// Fired on Message type 0xF74C Movement_SetObjectMovement. These are animations. Whenever a human, monster or object moves - one of these little messages is sent. Even idle emotes (like head scratching and nodding) are sent in this manner.
        /// </summary>
        public event EventHandler<Movement_SetObjectMovement>? OnMovement_SetObjectMovement {
            add { _OnMovement_SetObjectMovement.Subscribe(value); }
            remove { _OnMovement_SetObjectMovement.Unsubscribe(value); }
        }
        private readonly WeakEvent<Movement_SetObjectMovement> _OnMovement_SetObjectMovement = new();
    
        /// <summary>
        /// Fired on Message type 0xF74E Movement_VectorUpdate. Changes an objects vector, for things like jumping
        /// </summary>
        public event EventHandler<Movement_VectorUpdate>? OnMovement_VectorUpdate {
            add { _OnMovement_VectorUpdate.Subscribe(value); }
            remove { _OnMovement_VectorUpdate.Unsubscribe(value); }
        }
        private readonly WeakEvent<Movement_VectorUpdate> _OnMovement_VectorUpdate = new();
    
        /// <summary>
        /// Fired on Message type 0xF750 Effects_SoundEvent. Applies a sound effect.
        /// </summary>
        public event EventHandler<Effects_SoundEvent>? OnEffects_SoundEvent {
            add { _OnEffects_SoundEvent.Subscribe(value); }
            remove { _OnEffects_SoundEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Effects_SoundEvent> _OnEffects_SoundEvent = new();
    
        /// <summary>
        /// Fired on Message type 0xF751 Effects_PlayerTeleport. Instructs the client to show the portal graphic.
        /// </summary>
        public event EventHandler<Effects_PlayerTeleport>? OnEffects_PlayerTeleport {
            add { _OnEffects_PlayerTeleport.Subscribe(value); }
            remove { _OnEffects_PlayerTeleport.Unsubscribe(value); }
        }
        private readonly WeakEvent<Effects_PlayerTeleport> _OnEffects_PlayerTeleport = new();
    
        /// <summary>
        /// Fired on Message type 0xF754 Effects_PlayScriptId. Instructs the client to play a script. (Not seen so far, maybe prefered PlayScriptType)
        /// </summary>
        public event EventHandler<Effects_PlayScriptId>? OnEffects_PlayScriptId {
            add { _OnEffects_PlayScriptId.Subscribe(value); }
            remove { _OnEffects_PlayScriptId.Unsubscribe(value); }
        }
        private readonly WeakEvent<Effects_PlayScriptId> _OnEffects_PlayScriptId = new();
    
        /// <summary>
        /// Fired on Message type 0xF755 Effects_PlayScriptType. Applies an effect with visual and sound by providing the type to be looked up in the Physics Script Table
        /// </summary>
        public event EventHandler<Effects_PlayScriptType>? OnEffects_PlayScriptType {
            add { _OnEffects_PlayScriptType.Subscribe(value); }
            remove { _OnEffects_PlayScriptType.Unsubscribe(value); }
        }
        private readonly WeakEvent<Effects_PlayScriptType> _OnEffects_PlayScriptType = new();
    
        /// <summary>
        /// Fired on Message type 0xF7C1 Login_AccountBanned. Account has been banned
        /// </summary>
        public event EventHandler<Login_AccountBanned>? OnLogin_AccountBanned {
            add { _OnLogin_AccountBanned.Subscribe(value); }
            remove { _OnLogin_AccountBanned.Unsubscribe(value); }
        }
        private readonly WeakEvent<Login_AccountBanned> _OnLogin_AccountBanned = new();
    
        /// <summary>
        /// Fired on Message type 0xF7CA Admin_ReceiveAccountData. Admin Receive Account Data
        /// </summary>
        public event EventHandler<Admin_ReceiveAccountData>? OnAdmin_ReceiveAccountData {
            add { _OnAdmin_ReceiveAccountData.Subscribe(value); }
            remove { _OnAdmin_ReceiveAccountData.Unsubscribe(value); }
        }
        private readonly WeakEvent<Admin_ReceiveAccountData> _OnAdmin_ReceiveAccountData = new();
    
        /// <summary>
        /// Fired on Message type 0xF7CB Admin_ReceivePlayerData. Admin Receive Player Data
        /// </summary>
        public event EventHandler<Admin_ReceivePlayerData>? OnAdmin_ReceivePlayerData {
            add { _OnAdmin_ReceivePlayerData.Subscribe(value); }
            remove { _OnAdmin_ReceivePlayerData.Unsubscribe(value); }
        }
        private readonly WeakEvent<Admin_ReceivePlayerData> _OnAdmin_ReceivePlayerData = new();
    
        /// <summary>
        /// Fired on Message type 0xF7DB Item_UpdateObject. Update an existing object's data.
        /// </summary>
        public event EventHandler<Item_UpdateObject>? OnItem_UpdateObject {
            add { _OnItem_UpdateObject.Subscribe(value); }
            remove { _OnItem_UpdateObject.Unsubscribe(value); }
        }
        private readonly WeakEvent<Item_UpdateObject> _OnItem_UpdateObject = new();
    
        /// <summary>
        /// Fired on Message type 0xF7DC Login_AccountBooted. Account has been booted
        /// </summary>
        public event EventHandler<Login_AccountBooted>? OnLogin_AccountBooted {
            add { _OnLogin_AccountBooted.Subscribe(value); }
            remove { _OnLogin_AccountBooted.Unsubscribe(value); }
        }
        private readonly WeakEvent<Login_AccountBooted> _OnLogin_AccountBooted = new();
    
        /// <summary>
        /// Fired on Message type 0xF7DE Communication_TurbineChat. Send or receive a message using Turbine Chat.
        /// </summary>
        public event EventHandler<Communication_TurbineChat>? OnCommunication_TurbineChat {
            add { _OnCommunication_TurbineChat.Subscribe(value); }
            remove { _OnCommunication_TurbineChat.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_TurbineChat> _OnCommunication_TurbineChat = new();
    
        /// <summary>
        /// Fired on Message type 0xF7DF Login_EnterGame_ServerReady. Switch from the character display to the game display.
        /// </summary>
        public event EventHandler<Login_EnterGame_ServerReady>? OnLogin_EnterGame_ServerReady {
            add { _OnLogin_EnterGame_ServerReady.Subscribe(value); }
            remove { _OnLogin_EnterGame_ServerReady.Unsubscribe(value); }
        }
        private readonly WeakEvent<Login_EnterGame_ServerReady> _OnLogin_EnterGame_ServerReady = new();
    
        /// <summary>
        /// Fired on Message type 0xF7E0 Communication_TextboxString. Display a message in the chat window.
        /// </summary>
        public event EventHandler<Communication_TextboxString>? OnCommunication_TextboxString {
            add { _OnCommunication_TextboxString.Subscribe(value); }
            remove { _OnCommunication_TextboxString.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_TextboxString> _OnCommunication_TextboxString = new();
    
        /// <summary>
        /// Fired on Message type 0xF7E1 Login_WorldInfo. The name of the current world.
        /// </summary>
        public event EventHandler<Login_WorldInfo>? OnLogin_WorldInfo {
            add { _OnLogin_WorldInfo.Subscribe(value); }
            remove { _OnLogin_WorldInfo.Unsubscribe(value); }
        }
        private readonly WeakEvent<Login_WorldInfo> _OnLogin_WorldInfo = new();
    
        /// <summary>
        /// Fired on Message type 0xF7E2 DDD_DataMessage. Add or update a dat file Resource.
        /// </summary>
        public event EventHandler<DDD_DataMessage>? OnDDD_DataMessage {
            add { _OnDDD_DataMessage.Subscribe(value); }
            remove { _OnDDD_DataMessage.Unsubscribe(value); }
        }
        private readonly WeakEvent<DDD_DataMessage> _OnDDD_DataMessage = new();
    
        /// <summary>
        /// Fired on Message type 0xF7E4 DDD_ErrorMessage. DDD error
        /// </summary>
        public event EventHandler<DDD_ErrorMessage>? OnDDD_ErrorMessage {
            add { _OnDDD_ErrorMessage.Subscribe(value); }
            remove { _OnDDD_ErrorMessage.Unsubscribe(value); }
        }
        private readonly WeakEvent<DDD_ErrorMessage> _OnDDD_ErrorMessage = new();
    
        /// <summary>
        /// Fired on Message type 0xF7E7 DDD_BeginDDDMessage. A list of dat files that need to be patched
        /// </summary>
        public event EventHandler<DDD_BeginDDDMessage>? OnDDD_BeginDDDMessage {
            add { _OnDDD_BeginDDDMessage.Subscribe(value); }
            remove { _OnDDD_BeginDDDMessage.Unsubscribe(value); }
        }
        private readonly WeakEvent<DDD_BeginDDDMessage> _OnDDD_BeginDDDMessage = new();
    
        /// <summary>
        /// Fired on Message type 0xF7E5 DDD_InterrogationMessage. Add or update a dat file Resource.
        /// </summary>
        public event EventHandler<DDD_InterrogationMessage>? OnDDD_InterrogationMessage {
            add { _OnDDD_InterrogationMessage.Subscribe(value); }
            remove { _OnDDD_InterrogationMessage.Unsubscribe(value); }
        }
        private readonly WeakEvent<DDD_InterrogationMessage> _OnDDD_InterrogationMessage = new();
    
        /// <summary>
        /// Fired on Message type 0xF7EA DDD_OnEndDDD. Ends DDD update
        /// </summary>
        public event EventHandler<DDD_OnEndDDD>? OnDDD_OnEndDDD {
            add { _OnDDD_OnEndDDD.Subscribe(value); }
            remove { _OnDDD_OnEndDDD.Unsubscribe(value); }
        }
        private readonly WeakEvent<DDD_OnEndDDD> _OnDDD_OnEndDDD = new();
    
        /// <summary>
        /// Fired on Message type 0xF7B0 Ordered_GameEvent. Ordered game event
        /// </summary>
        public event EventHandler<Ordered_GameEvent>? OnOrdered_GameEvent {
            add { _OnOrdered_GameEvent.Subscribe(value); }
            remove { _OnOrdered_GameEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Ordered_GameEvent> _OnOrdered_GameEvent = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0003 Allegiance_AllegianceUpdateAborted. Allegiance update cancelled
        /// </summary>
        public event EventHandler<Allegiance_AllegianceUpdateAborted>? OnAllegiance_AllegianceUpdateAborted {
            add { _OnAllegiance_AllegianceUpdateAborted.Subscribe(value); }
            remove { _OnAllegiance_AllegianceUpdateAborted.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_AllegianceUpdateAborted> _OnAllegiance_AllegianceUpdateAborted = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0004 Communication_PopUpString. Display a message in a popup message window.
        /// </summary>
        public event EventHandler<Communication_PopUpString>? OnCommunication_PopUpString {
            add { _OnCommunication_PopUpString.Subscribe(value); }
            remove { _OnCommunication_PopUpString.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_PopUpString> _OnCommunication_PopUpString = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0013 Login_PlayerDescription. Information describing your character.
        /// </summary>
        public event EventHandler<Login_PlayerDescription>? OnLogin_PlayerDescription {
            add { _OnLogin_PlayerDescription.Subscribe(value); }
            remove { _OnLogin_PlayerDescription.Unsubscribe(value); }
        }
        private readonly WeakEvent<Login_PlayerDescription> _OnLogin_PlayerDescription = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0020 Allegiance_AllegianceUpdate. Returns info related to your monarch, patron and vassals.
        /// </summary>
        public event EventHandler<Allegiance_AllegianceUpdate>? OnAllegiance_AllegianceUpdate {
            add { _OnAllegiance_AllegianceUpdate.Subscribe(value); }
            remove { _OnAllegiance_AllegianceUpdate.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_AllegianceUpdate> _OnAllegiance_AllegianceUpdate = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0021 Social_FriendsUpdate. Friends list update
        /// </summary>
        public event EventHandler<Social_FriendsUpdate>? OnSocial_FriendsUpdate {
            add { _OnSocial_FriendsUpdate.Subscribe(value); }
            remove { _OnSocial_FriendsUpdate.Unsubscribe(value); }
        }
        private readonly WeakEvent<Social_FriendsUpdate> _OnSocial_FriendsUpdate = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0022 Item_ServerSaysContainId. Store an item in a container.
        /// </summary>
        public event EventHandler<Item_ServerSaysContainId>? OnItem_ServerSaysContainId {
            add { _OnItem_ServerSaysContainId.Subscribe(value); }
            remove { _OnItem_ServerSaysContainId.Unsubscribe(value); }
        }
        private readonly WeakEvent<Item_ServerSaysContainId> _OnItem_ServerSaysContainId = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0023 Item_WearItem. Equip an item.
        /// </summary>
        public event EventHandler<Item_WearItem>? OnItem_WearItem {
            add { _OnItem_WearItem.Subscribe(value); }
            remove { _OnItem_WearItem.Unsubscribe(value); }
        }
        private readonly WeakEvent<Item_WearItem> _OnItem_WearItem = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0029 Social_CharacterTitleTable. Titles for the current character.
        /// </summary>
        public event EventHandler<Social_CharacterTitleTable>? OnSocial_CharacterTitleTable {
            add { _OnSocial_CharacterTitleTable.Subscribe(value); }
            remove { _OnSocial_CharacterTitleTable.Unsubscribe(value); }
        }
        private readonly WeakEvent<Social_CharacterTitleTable> _OnSocial_CharacterTitleTable = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x002B Social_AddOrSetCharacterTitle. Set a title for the current character.
        /// </summary>
        public event EventHandler<Social_AddOrSetCharacterTitle>? OnSocial_AddOrSetCharacterTitle {
            add { _OnSocial_AddOrSetCharacterTitle.Subscribe(value); }
            remove { _OnSocial_AddOrSetCharacterTitle.Unsubscribe(value); }
        }
        private readonly WeakEvent<Social_AddOrSetCharacterTitle> _OnSocial_AddOrSetCharacterTitle = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0052 Item_StopViewingObjectContents. Close Container - Only sent when explicitly closed
        /// </summary>
        public event EventHandler<Item_StopViewingObjectContents>? OnItem_StopViewingObjectContents {
            add { _OnItem_StopViewingObjectContents.Subscribe(value); }
            remove { _OnItem_StopViewingObjectContents.Unsubscribe(value); }
        }
        private readonly WeakEvent<Item_StopViewingObjectContents> _OnItem_StopViewingObjectContents = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0062 Vendor_VendorInfo. Open the buy/sell panel for a merchant.
        /// </summary>
        public event EventHandler<Vendor_VendorInfo>? OnVendor_VendorInfo {
            add { _OnVendor_VendorInfo.Subscribe(value); }
            remove { _OnVendor_VendorInfo.Unsubscribe(value); }
        }
        private readonly WeakEvent<Vendor_VendorInfo> _OnVendor_VendorInfo = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0075 Character_StartBarber. Opens barber UI
        /// </summary>
        public event EventHandler<Character_StartBarber>? OnCharacter_StartBarber {
            add { _OnCharacter_StartBarber.Subscribe(value); }
            remove { _OnCharacter_StartBarber.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_StartBarber> _OnCharacter_StartBarber = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x00A3 Fellowship_Quit. Member left fellowship
        /// </summary>
        public event EventHandler<Fellowship_Quit>? OnFellowship_Quit {
            add { _OnFellowship_Quit.Subscribe(value); }
            remove { _OnFellowship_Quit.Unsubscribe(value); }
        }
        private readonly WeakEvent<Fellowship_Quit> _OnFellowship_Quit = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x00A4 Fellowship_Dismiss. Member dismissed from fellowship
        /// </summary>
        public event EventHandler<Fellowship_Dismiss>? OnFellowship_Dismiss {
            add { _OnFellowship_Dismiss.Subscribe(value); }
            remove { _OnFellowship_Dismiss.Unsubscribe(value); }
        }
        private readonly WeakEvent<Fellowship_Dismiss> _OnFellowship_Dismiss = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x00B4 Writing_BookOpen. Sent when you first open a book, contains the entire table of contents.
        /// </summary>
        public event EventHandler<Writing_BookOpen>? OnWriting_BookOpen {
            add { _OnWriting_BookOpen.Subscribe(value); }
            remove { _OnWriting_BookOpen.Unsubscribe(value); }
        }
        private readonly WeakEvent<Writing_BookOpen> _OnWriting_BookOpen = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x00B6 Writing_BookAddPageResponse. Response to an attempt to add a page to a book.
        /// </summary>
        public event EventHandler<Writing_BookAddPageResponse>? OnWriting_BookAddPageResponse {
            add { _OnWriting_BookAddPageResponse.Subscribe(value); }
            remove { _OnWriting_BookAddPageResponse.Unsubscribe(value); }
        }
        private readonly WeakEvent<Writing_BookAddPageResponse> _OnWriting_BookAddPageResponse = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x00B7 Writing_BookDeletePageResponse. Response to an attempt to delete a page from a book.
        /// </summary>
        public event EventHandler<Writing_BookDeletePageResponse>? OnWriting_BookDeletePageResponse {
            add { _OnWriting_BookDeletePageResponse.Subscribe(value); }
            remove { _OnWriting_BookDeletePageResponse.Unsubscribe(value); }
        }
        private readonly WeakEvent<Writing_BookDeletePageResponse> _OnWriting_BookDeletePageResponse = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x00B8 Writing_BookPageDataResponse. Contains the text of a single page of a book, parchment or sign.
        /// </summary>
        public event EventHandler<Writing_BookPageDataResponse>? OnWriting_BookPageDataResponse {
            add { _OnWriting_BookPageDataResponse.Subscribe(value); }
            remove { _OnWriting_BookPageDataResponse.Unsubscribe(value); }
        }
        private readonly WeakEvent<Writing_BookPageDataResponse> _OnWriting_BookPageDataResponse = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x00C3 Item_GetInscriptionResponse. Get Inscription Response, doesn't seem to be really used by client
        /// </summary>
        public event EventHandler<Item_GetInscriptionResponse>? OnItem_GetInscriptionResponse {
            add { _OnItem_GetInscriptionResponse.Subscribe(value); }
            remove { _OnItem_GetInscriptionResponse.Unsubscribe(value); }
        }
        private readonly WeakEvent<Item_GetInscriptionResponse> _OnItem_GetInscriptionResponse = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x00C9 Item_SetAppraiseInfo. The result of an attempt to assess an item or creature.
        /// </summary>
        public event EventHandler<Item_SetAppraiseInfo>? OnItem_SetAppraiseInfo {
            add { _OnItem_SetAppraiseInfo.Subscribe(value); }
            remove { _OnItem_SetAppraiseInfo.Unsubscribe(value); }
        }
        private readonly WeakEvent<Item_SetAppraiseInfo> _OnItem_SetAppraiseInfo = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0147 Communication_ChannelBroadcast. ChannelBroadcast: Group Chat
        /// </summary>
        public event EventHandler<Communication_ChannelBroadcast>? OnCommunication_ChannelBroadcast {
            add { _OnCommunication_ChannelBroadcast.Subscribe(value); }
            remove { _OnCommunication_ChannelBroadcast.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_ChannelBroadcast> _OnCommunication_ChannelBroadcast = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0148 Communication_ChannelList. ChannelList: Provides list of characters listening to a channel, I assume in response to a command
        /// </summary>
        public event EventHandler<Communication_ChannelList>? OnCommunication_ChannelList {
            add { _OnCommunication_ChannelList.Subscribe(value); }
            remove { _OnCommunication_ChannelList.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_ChannelList> _OnCommunication_ChannelList = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0149 Communication_ChannelIndex. ChannelIndex: Provides list of channels available to the player, I assume in response to a command
        /// </summary>
        public event EventHandler<Communication_ChannelIndex>? OnCommunication_ChannelIndex {
            add { _OnCommunication_ChannelIndex.Subscribe(value); }
            remove { _OnCommunication_ChannelIndex.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_ChannelIndex> _OnCommunication_ChannelIndex = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0196 Item_OnViewContents. Set Pack Contents
        /// </summary>
        public event EventHandler<Item_OnViewContents>? OnItem_OnViewContents {
            add { _OnItem_OnViewContents.Subscribe(value); }
            remove { _OnItem_OnViewContents.Unsubscribe(value); }
        }
        private readonly WeakEvent<Item_OnViewContents> _OnItem_OnViewContents = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x019A Item_ServerSaysMoveItem. ServerSaysMoveItem: Removes an item from inventory (when you place it on the ground or give it away)
        /// </summary>
        public event EventHandler<Item_ServerSaysMoveItem>? OnItem_ServerSaysMoveItem {
            add { _OnItem_ServerSaysMoveItem.Subscribe(value); }
            remove { _OnItem_ServerSaysMoveItem.Unsubscribe(value); }
        }
        private readonly WeakEvent<Item_ServerSaysMoveItem> _OnItem_ServerSaysMoveItem = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x01A7 Combat_HandleAttackDoneEvent. HandleAttackDoneEvent: Melee attack completed
        /// </summary>
        public event EventHandler<Combat_HandleAttackDoneEvent>? OnCombat_HandleAttackDoneEvent {
            add { _OnCombat_HandleAttackDoneEvent.Subscribe(value); }
            remove { _OnCombat_HandleAttackDoneEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Combat_HandleAttackDoneEvent> _OnCombat_HandleAttackDoneEvent = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x01A8 Magic_RemoveSpell. RemoveSpell: Delete a spell from your spellbook.
        /// </summary>
        public event EventHandler<Magic_RemoveSpell>? OnMagic_RemoveSpell {
            add { _OnMagic_RemoveSpell.Subscribe(value); }
            remove { _OnMagic_RemoveSpell.Unsubscribe(value); }
        }
        private readonly WeakEvent<Magic_RemoveSpell> _OnMagic_RemoveSpell = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x01AC Combat_HandleVictimNotificationEventSelf. You just died.
        /// </summary>
        public event EventHandler<Combat_HandleVictimNotificationEventSelf>? OnCombat_HandleVictimNotificationEventSelf {
            add { _OnCombat_HandleVictimNotificationEventSelf.Subscribe(value); }
            remove { _OnCombat_HandleVictimNotificationEventSelf.Unsubscribe(value); }
        }
        private readonly WeakEvent<Combat_HandleVictimNotificationEventSelf> _OnCombat_HandleVictimNotificationEventSelf = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x01AD Combat_HandleVictimNotificationEventOther. Message for a death, something you killed or your own death message.
        /// </summary>
        public event EventHandler<Combat_HandleVictimNotificationEventOther>? OnCombat_HandleVictimNotificationEventOther {
            add { _OnCombat_HandleVictimNotificationEventOther.Subscribe(value); }
            remove { _OnCombat_HandleVictimNotificationEventOther.Unsubscribe(value); }
        }
        private readonly WeakEvent<Combat_HandleVictimNotificationEventOther> _OnCombat_HandleVictimNotificationEventOther = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x01B1 Combat_HandleAttackerNotificationEvent. HandleAttackerNotificationEvent: You have hit your target with a melee attack.
        /// </summary>
        public event EventHandler<Combat_HandleAttackerNotificationEvent>? OnCombat_HandleAttackerNotificationEvent {
            add { _OnCombat_HandleAttackerNotificationEvent.Subscribe(value); }
            remove { _OnCombat_HandleAttackerNotificationEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Combat_HandleAttackerNotificationEvent> _OnCombat_HandleAttackerNotificationEvent = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x01B2 Combat_HandleDefenderNotificationEvent. HandleDefenderNotificationEvent: You have been hit by a creature's melee attack.
        /// </summary>
        public event EventHandler<Combat_HandleDefenderNotificationEvent>? OnCombat_HandleDefenderNotificationEvent {
            add { _OnCombat_HandleDefenderNotificationEvent.Subscribe(value); }
            remove { _OnCombat_HandleDefenderNotificationEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Combat_HandleDefenderNotificationEvent> _OnCombat_HandleDefenderNotificationEvent = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x01B3 Combat_HandleEvasionAttackerNotificationEvent. HandleEvasionAttackerNotificationEvent: Your target has evaded your melee attack.
        /// </summary>
        public event EventHandler<Combat_HandleEvasionAttackerNotificationEvent>? OnCombat_HandleEvasionAttackerNotificationEvent {
            add { _OnCombat_HandleEvasionAttackerNotificationEvent.Subscribe(value); }
            remove { _OnCombat_HandleEvasionAttackerNotificationEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Combat_HandleEvasionAttackerNotificationEvent> _OnCombat_HandleEvasionAttackerNotificationEvent = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x01B4 Combat_HandleEvasionDefenderNotificationEvent. HandleEvasionDefenderNotificationEvent: You have evaded a creature's melee attack.
        /// </summary>
        public event EventHandler<Combat_HandleEvasionDefenderNotificationEvent>? OnCombat_HandleEvasionDefenderNotificationEvent {
            add { _OnCombat_HandleEvasionDefenderNotificationEvent.Subscribe(value); }
            remove { _OnCombat_HandleEvasionDefenderNotificationEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Combat_HandleEvasionDefenderNotificationEvent> _OnCombat_HandleEvasionDefenderNotificationEvent = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x01B8 Combat_HandleCommenceAttackEvent. HandleCommenceAttackEvent: Start melee attack
        /// </summary>
        public event EventHandler<Combat_HandleCommenceAttackEvent>? OnCombat_HandleCommenceAttackEvent {
            add { _OnCombat_HandleCommenceAttackEvent.Subscribe(value); }
            remove { _OnCombat_HandleCommenceAttackEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Combat_HandleCommenceAttackEvent> _OnCombat_HandleCommenceAttackEvent = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x01C0 Combat_QueryHealthResponse. QueryHealthResponse: Update a creature's health bar.
        /// </summary>
        public event EventHandler<Combat_QueryHealthResponse>? OnCombat_QueryHealthResponse {
            add { _OnCombat_QueryHealthResponse.Subscribe(value); }
            remove { _OnCombat_QueryHealthResponse.Unsubscribe(value); }
        }
        private readonly WeakEvent<Combat_QueryHealthResponse> _OnCombat_QueryHealthResponse = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x01C3 Character_QueryAgeResponse. QueryAgeResponse: happens when you do /age in the game
        /// </summary>
        public event EventHandler<Character_QueryAgeResponse>? OnCharacter_QueryAgeResponse {
            add { _OnCharacter_QueryAgeResponse.Subscribe(value); }
            remove { _OnCharacter_QueryAgeResponse.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_QueryAgeResponse> _OnCharacter_QueryAgeResponse = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x01C7 Item_UseDone. UseDone: Ready. Previous action complete
        /// </summary>
        public event EventHandler<Item_UseDone>? OnItem_UseDone {
            add { _OnItem_UseDone.Subscribe(value); }
            remove { _OnItem_UseDone.Unsubscribe(value); }
        }
        private readonly WeakEvent<Item_UseDone> _OnItem_UseDone = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x01C8 Allegiance_AllegianceUpdateDone. Allegiance update finished
        /// </summary>
        public event EventHandler<Allegiance_AllegianceUpdateDone>? OnAllegiance_AllegianceUpdateDone {
            add { _OnAllegiance_AllegianceUpdateDone.Subscribe(value); }
            remove { _OnAllegiance_AllegianceUpdateDone.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_AllegianceUpdateDone> _OnAllegiance_AllegianceUpdateDone = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x01C9 Fellowship_FellowUpdateDone. Fellow update is done
        /// </summary>
        public event EventHandler<Fellowship_FellowUpdateDone>? OnFellowship_FellowUpdateDone {
            add { _OnFellowship_FellowUpdateDone.Subscribe(value); }
            remove { _OnFellowship_FellowUpdateDone.Unsubscribe(value); }
        }
        private readonly WeakEvent<Fellowship_FellowUpdateDone> _OnFellowship_FellowUpdateDone = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x01CA Fellowship_FellowStatsDone. Fellow stats are done
        /// </summary>
        public event EventHandler<Fellowship_FellowStatsDone>? OnFellowship_FellowStatsDone {
            add { _OnFellowship_FellowStatsDone.Subscribe(value); }
            remove { _OnFellowship_FellowStatsDone.Unsubscribe(value); }
        }
        private readonly WeakEvent<Fellowship_FellowStatsDone> _OnFellowship_FellowStatsDone = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x01CB Item_AppraiseDone. Close Assess Panel
        /// </summary>
        public event EventHandler<Item_AppraiseDone>? OnItem_AppraiseDone {
            add { _OnItem_AppraiseDone.Subscribe(value); }
            remove { _OnItem_AppraiseDone.Unsubscribe(value); }
        }
        private readonly WeakEvent<Item_AppraiseDone> _OnItem_AppraiseDone = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x01EA Character_ReturnPing. Ping Reply
        /// </summary>
        public event EventHandler<Character_ReturnPing>? OnCharacter_ReturnPing {
            add { _OnCharacter_ReturnPing.Subscribe(value); }
            remove { _OnCharacter_ReturnPing.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_ReturnPing> _OnCharacter_ReturnPing = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x01F4 Communication_SetSquelchDB. Squelch and Filter List
        /// </summary>
        public event EventHandler<Communication_SetSquelchDB>? OnCommunication_SetSquelchDB {
            add { _OnCommunication_SetSquelchDB.Subscribe(value); }
            remove { _OnCommunication_SetSquelchDB.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_SetSquelchDB> _OnCommunication_SetSquelchDB = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x01FD Trade_RegisterTrade. RegisterTrade: Send to begin a trade and display the trade window
        /// </summary>
        public event EventHandler<Trade_RegisterTrade>? OnTrade_RegisterTrade {
            add { _OnTrade_RegisterTrade.Subscribe(value); }
            remove { _OnTrade_RegisterTrade.Unsubscribe(value); }
        }
        private readonly WeakEvent<Trade_RegisterTrade> _OnTrade_RegisterTrade = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x01FE Trade_OpenTrade. OpenTrade: Open trade window
        /// </summary>
        public event EventHandler<Trade_OpenTrade>? OnTrade_OpenTrade {
            add { _OnTrade_OpenTrade.Subscribe(value); }
            remove { _OnTrade_OpenTrade.Unsubscribe(value); }
        }
        private readonly WeakEvent<Trade_OpenTrade> _OnTrade_OpenTrade = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x01FF Trade_CloseTrade. CloseTrade: End trading
        /// </summary>
        public event EventHandler<Trade_CloseTrade>? OnTrade_CloseTrade {
            add { _OnTrade_CloseTrade.Subscribe(value); }
            remove { _OnTrade_CloseTrade.Unsubscribe(value); }
        }
        private readonly WeakEvent<Trade_CloseTrade> _OnTrade_CloseTrade = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0200 Trade_AddToTrade. RemoveFromTrade: Item was removed from trade window
        /// </summary>
        public event EventHandler<Trade_AddToTrade>? OnTrade_AddToTrade {
            add { _OnTrade_AddToTrade.Subscribe(value); }
            remove { _OnTrade_AddToTrade.Unsubscribe(value); }
        }
        private readonly WeakEvent<Trade_AddToTrade> _OnTrade_AddToTrade = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0201 Trade_RemoveFromTrade. Removes an item from the trade window, not sure if this is used still?
        /// </summary>
        public event EventHandler<Trade_RemoveFromTrade>? OnTrade_RemoveFromTrade {
            add { _OnTrade_RemoveFromTrade.Subscribe(value); }
            remove { _OnTrade_RemoveFromTrade.Unsubscribe(value); }
        }
        private readonly WeakEvent<Trade_RemoveFromTrade> _OnTrade_RemoveFromTrade = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0202 Trade_AcceptTrade. AcceptTrade: The trade was accepted
        /// </summary>
        public event EventHandler<Trade_AcceptTrade>? OnTrade_AcceptTrade {
            add { _OnTrade_AcceptTrade.Subscribe(value); }
            remove { _OnTrade_AcceptTrade.Unsubscribe(value); }
        }
        private readonly WeakEvent<Trade_AcceptTrade> _OnTrade_AcceptTrade = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0203 Trade_DeclineTrade. DeclineTrade: The trade was declined
        /// </summary>
        public event EventHandler<Trade_DeclineTrade>? OnTrade_DeclineTrade {
            add { _OnTrade_DeclineTrade.Subscribe(value); }
            remove { _OnTrade_DeclineTrade.Unsubscribe(value); }
        }
        private readonly WeakEvent<Trade_DeclineTrade> _OnTrade_DeclineTrade = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0205 Trade_ResetTrade. ResetTrade: The trade window was reset
        /// </summary>
        public event EventHandler<Trade_ResetTrade>? OnTrade_ResetTrade {
            add { _OnTrade_ResetTrade.Subscribe(value); }
            remove { _OnTrade_ResetTrade.Unsubscribe(value); }
        }
        private readonly WeakEvent<Trade_ResetTrade> _OnTrade_ResetTrade = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0207 Trade_TradeFailure. TradeFailure: Failure to add a trade item
        /// </summary>
        public event EventHandler<Trade_TradeFailure>? OnTrade_TradeFailure {
            add { _OnTrade_TradeFailure.Subscribe(value); }
            remove { _OnTrade_TradeFailure.Unsubscribe(value); }
        }
        private readonly WeakEvent<Trade_TradeFailure> _OnTrade_TradeFailure = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0208 Trade_ClearTradeAcceptance. ClearTradeAcceptance: Failure to complete a trade
        /// </summary>
        public event EventHandler<Trade_ClearTradeAcceptance>? OnTrade_ClearTradeAcceptance {
            add { _OnTrade_ClearTradeAcceptance.Subscribe(value); }
            remove { _OnTrade_ClearTradeAcceptance.Unsubscribe(value); }
        }
        private readonly WeakEvent<Trade_ClearTradeAcceptance> _OnTrade_ClearTradeAcceptance = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x021D House_HouseProfile. Buy a dwelling or pay maintenance
        /// </summary>
        public event EventHandler<House_HouseProfile>? OnHouse_HouseProfile {
            add { _OnHouse_HouseProfile.Subscribe(value); }
            remove { _OnHouse_HouseProfile.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_HouseProfile> _OnHouse_HouseProfile = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0225 House_HouseData. House panel information for owners.
        /// </summary>
        public event EventHandler<House_HouseData>? OnHouse_HouseData {
            add { _OnHouse_HouseData.Subscribe(value); }
            remove { _OnHouse_HouseData.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_HouseData> _OnHouse_HouseData = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0226 House_HouseStatus. House Data
        /// </summary>
        public event EventHandler<House_HouseStatus>? OnHouse_HouseStatus {
            add { _OnHouse_HouseStatus.Subscribe(value); }
            remove { _OnHouse_HouseStatus.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_HouseStatus> _OnHouse_HouseStatus = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0227 House_UpdateRentTime. Update Rent Time
        /// </summary>
        public event EventHandler<House_UpdateRentTime>? OnHouse_UpdateRentTime {
            add { _OnHouse_UpdateRentTime.Subscribe(value); }
            remove { _OnHouse_UpdateRentTime.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_UpdateRentTime> _OnHouse_UpdateRentTime = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0228 House_UpdateRentPayment. Update Rent Payment
        /// </summary>
        public event EventHandler<House_UpdateRentPayment>? OnHouse_UpdateRentPayment {
            add { _OnHouse_UpdateRentPayment.Subscribe(value); }
            remove { _OnHouse_UpdateRentPayment.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_UpdateRentPayment> _OnHouse_UpdateRentPayment = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0248 House_UpdateRestrictions. Update Restrictions
        /// </summary>
        public event EventHandler<House_UpdateRestrictions>? OnHouse_UpdateRestrictions {
            add { _OnHouse_UpdateRestrictions.Subscribe(value); }
            remove { _OnHouse_UpdateRestrictions.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_UpdateRestrictions> _OnHouse_UpdateRestrictions = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0257 House_UpdateHAR. House Guest List
        /// </summary>
        public event EventHandler<House_UpdateHAR>? OnHouse_UpdateHAR {
            add { _OnHouse_UpdateHAR.Subscribe(value); }
            remove { _OnHouse_UpdateHAR.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_UpdateHAR> _OnHouse_UpdateHAR = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0259 House_HouseTransaction. House Profile
        /// </summary>
        public event EventHandler<House_HouseTransaction>? OnHouse_HouseTransaction {
            add { _OnHouse_HouseTransaction.Subscribe(value); }
            remove { _OnHouse_HouseTransaction.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_HouseTransaction> _OnHouse_HouseTransaction = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0264 Item_QueryItemManaResponse. Update an item's mana bar.
        /// </summary>
        public event EventHandler<Item_QueryItemManaResponse>? OnItem_QueryItemManaResponse {
            add { _OnItem_QueryItemManaResponse.Subscribe(value); }
            remove { _OnItem_QueryItemManaResponse.Unsubscribe(value); }
        }
        private readonly WeakEvent<Item_QueryItemManaResponse> _OnItem_QueryItemManaResponse = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0271 House_AvailableHouses. Display a list of available dwellings in the chat window.
        /// </summary>
        public event EventHandler<House_AvailableHouses>? OnHouse_AvailableHouses {
            add { _OnHouse_AvailableHouses.Subscribe(value); }
            remove { _OnHouse_AvailableHouses.Unsubscribe(value); }
        }
        private readonly WeakEvent<House_AvailableHouses> _OnHouse_AvailableHouses = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0274 Character_ConfirmationRequest. Display a confirmation panel.
        /// </summary>
        public event EventHandler<Character_ConfirmationRequest>? OnCharacter_ConfirmationRequest {
            add { _OnCharacter_ConfirmationRequest.Subscribe(value); }
            remove { _OnCharacter_ConfirmationRequest.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_ConfirmationRequest> _OnCharacter_ConfirmationRequest = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0276 Character_ConfirmationDone. Confirmation done
        /// </summary>
        public event EventHandler<Character_ConfirmationDone>? OnCharacter_ConfirmationDone {
            add { _OnCharacter_ConfirmationDone.Subscribe(value); }
            remove { _OnCharacter_ConfirmationDone.Unsubscribe(value); }
        }
        private readonly WeakEvent<Character_ConfirmationDone> _OnCharacter_ConfirmationDone = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x027A Allegiance_AllegianceLoginNotificationEvent. Display an allegiance login/logout message in the chat window.
        /// </summary>
        public event EventHandler<Allegiance_AllegianceLoginNotificationEvent>? OnAllegiance_AllegianceLoginNotificationEvent {
            add { _OnAllegiance_AllegianceLoginNotificationEvent.Subscribe(value); }
            remove { _OnAllegiance_AllegianceLoginNotificationEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_AllegianceLoginNotificationEvent> _OnAllegiance_AllegianceLoginNotificationEvent = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x027C Allegiance_AllegianceInfoResponseEvent. Returns data for a player's allegiance information
        /// </summary>
        public event EventHandler<Allegiance_AllegianceInfoResponseEvent>? OnAllegiance_AllegianceInfoResponseEvent {
            add { _OnAllegiance_AllegianceInfoResponseEvent.Subscribe(value); }
            remove { _OnAllegiance_AllegianceInfoResponseEvent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Allegiance_AllegianceInfoResponseEvent> _OnAllegiance_AllegianceInfoResponseEvent = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0281 Game_JoinGameResponse. Joining game response
        /// </summary>
        public event EventHandler<Game_JoinGameResponse>? OnGame_JoinGameResponse {
            add { _OnGame_JoinGameResponse.Subscribe(value); }
            remove { _OnGame_JoinGameResponse.Unsubscribe(value); }
        }
        private readonly WeakEvent<Game_JoinGameResponse> _OnGame_JoinGameResponse = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0282 Game_StartGame. Start game
        /// </summary>
        public event EventHandler<Game_StartGame>? OnGame_StartGame {
            add { _OnGame_StartGame.Subscribe(value); }
            remove { _OnGame_StartGame.Unsubscribe(value); }
        }
        private readonly WeakEvent<Game_StartGame> _OnGame_StartGame = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0283 Game_MoveResponse. Move response
        /// </summary>
        public event EventHandler<Game_MoveResponse>? OnGame_MoveResponse {
            add { _OnGame_MoveResponse.Subscribe(value); }
            remove { _OnGame_MoveResponse.Unsubscribe(value); }
        }
        private readonly WeakEvent<Game_MoveResponse> _OnGame_MoveResponse = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0284 Game_OpponentTurn. Opponent Turn
        /// </summary>
        public event EventHandler<Game_OpponentTurn>? OnGame_OpponentTurn {
            add { _OnGame_OpponentTurn.Subscribe(value); }
            remove { _OnGame_OpponentTurn.Unsubscribe(value); }
        }
        private readonly WeakEvent<Game_OpponentTurn> _OnGame_OpponentTurn = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0285 Game_OpponentStalemateState. Opponent Stalemate State
        /// </summary>
        public event EventHandler<Game_OpponentStalemateState>? OnGame_OpponentStalemateState {
            add { _OnGame_OpponentStalemateState.Subscribe(value); }
            remove { _OnGame_OpponentStalemateState.Unsubscribe(value); }
        }
        private readonly WeakEvent<Game_OpponentStalemateState> _OnGame_OpponentStalemateState = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x028A Communication_WeenieError. Display a status message in the chat window.
        /// </summary>
        public event EventHandler<Communication_WeenieError>? OnCommunication_WeenieError {
            add { _OnCommunication_WeenieError.Subscribe(value); }
            remove { _OnCommunication_WeenieError.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_WeenieError> _OnCommunication_WeenieError = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x028B Communication_WeenieErrorWithString. Display a parameterized status message in the chat window.
        /// </summary>
        public event EventHandler<Communication_WeenieErrorWithString>? OnCommunication_WeenieErrorWithString {
            add { _OnCommunication_WeenieErrorWithString.Subscribe(value); }
            remove { _OnCommunication_WeenieErrorWithString.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_WeenieErrorWithString> _OnCommunication_WeenieErrorWithString = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x028C Game_GameOver. End of Chess game
        /// </summary>
        public event EventHandler<Game_GameOver>? OnGame_GameOver {
            add { _OnGame_GameOver.Subscribe(value); }
            remove { _OnGame_GameOver.Unsubscribe(value); }
        }
        private readonly WeakEvent<Game_GameOver> _OnGame_GameOver = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0295 Communication_ChatRoomTracker. Set Turbine Chat channel numbers.
        /// </summary>
        public event EventHandler<Communication_ChatRoomTracker>? OnCommunication_ChatRoomTracker {
            add { _OnCommunication_ChatRoomTracker.Subscribe(value); }
            remove { _OnCommunication_ChatRoomTracker.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_ChatRoomTracker> _OnCommunication_ChatRoomTracker = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x02AE Admin_QueryPluginList. TODO: QueryPluginList
        /// </summary>
        public event EventHandler<Admin_QueryPluginList>? OnAdmin_QueryPluginList {
            add { _OnAdmin_QueryPluginList.Subscribe(value); }
            remove { _OnAdmin_QueryPluginList.Unsubscribe(value); }
        }
        private readonly WeakEvent<Admin_QueryPluginList> _OnAdmin_QueryPluginList = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x02B1 Admin_QueryPlugin. TODO: QueryPlugin
        /// </summary>
        public event EventHandler<Admin_QueryPlugin>? OnAdmin_QueryPlugin {
            add { _OnAdmin_QueryPlugin.Subscribe(value); }
            remove { _OnAdmin_QueryPlugin.Unsubscribe(value); }
        }
        private readonly WeakEvent<Admin_QueryPlugin> _OnAdmin_QueryPlugin = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x02B3 Admin_QueryPluginResponse2. TODO: QueryPluginResponse
        /// </summary>
        public event EventHandler<Admin_QueryPluginResponse2>? OnAdmin_QueryPluginResponse2 {
            add { _OnAdmin_QueryPluginResponse2.Subscribe(value); }
            remove { _OnAdmin_QueryPluginResponse2.Unsubscribe(value); }
        }
        private readonly WeakEvent<Admin_QueryPluginResponse2> _OnAdmin_QueryPluginResponse2 = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x02B4 Inventory_SalvageOperationsResultData. Salvage operation results
        /// </summary>
        public event EventHandler<Inventory_SalvageOperationsResultData>? OnInventory_SalvageOperationsResultData {
            add { _OnInventory_SalvageOperationsResultData.Subscribe(value); }
            remove { _OnInventory_SalvageOperationsResultData.Unsubscribe(value); }
        }
        private readonly WeakEvent<Inventory_SalvageOperationsResultData> _OnInventory_SalvageOperationsResultData = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x02BD Communication_HearDirectSpeech. Someone has sent you a @tell.
        /// </summary>
        public event EventHandler<Communication_HearDirectSpeech>? OnCommunication_HearDirectSpeech {
            add { _OnCommunication_HearDirectSpeech.Subscribe(value); }
            remove { _OnCommunication_HearDirectSpeech.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_HearDirectSpeech> _OnCommunication_HearDirectSpeech = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x02BE Fellowship_FullUpdate. Create or join a fellowship
        /// </summary>
        public event EventHandler<Fellowship_FullUpdate>? OnFellowship_FullUpdate {
            add { _OnFellowship_FullUpdate.Subscribe(value); }
            remove { _OnFellowship_FullUpdate.Unsubscribe(value); }
        }
        private readonly WeakEvent<Fellowship_FullUpdate> _OnFellowship_FullUpdate = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x02BF Fellowship_Disband. Disband your fellowship.
        /// </summary>
        public event EventHandler<Fellowship_Disband>? OnFellowship_Disband {
            add { _OnFellowship_Disband.Subscribe(value); }
            remove { _OnFellowship_Disband.Unsubscribe(value); }
        }
        private readonly WeakEvent<Fellowship_Disband> _OnFellowship_Disband = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x02C0 Fellowship_UpdateFellow. Add/Update a member to your fellowship.
        /// </summary>
        public event EventHandler<Fellowship_UpdateFellow>? OnFellowship_UpdateFellow {
            add { _OnFellowship_UpdateFellow.Subscribe(value); }
            remove { _OnFellowship_UpdateFellow.Unsubscribe(value); }
        }
        private readonly WeakEvent<Fellowship_UpdateFellow> _OnFellowship_UpdateFellow = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x02C1 Magic_UpdateSpell. Add a spell to your spellbook.
        /// </summary>
        public event EventHandler<Magic_UpdateSpell>? OnMagic_UpdateSpell {
            add { _OnMagic_UpdateSpell.Subscribe(value); }
            remove { _OnMagic_UpdateSpell.Unsubscribe(value); }
        }
        private readonly WeakEvent<Magic_UpdateSpell> _OnMagic_UpdateSpell = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x02C2 Magic_UpdateEnchantment. Apply an enchantment to your character.
        /// </summary>
        public event EventHandler<Magic_UpdateEnchantment>? OnMagic_UpdateEnchantment {
            add { _OnMagic_UpdateEnchantment.Subscribe(value); }
            remove { _OnMagic_UpdateEnchantment.Unsubscribe(value); }
        }
        private readonly WeakEvent<Magic_UpdateEnchantment> _OnMagic_UpdateEnchantment = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x02C3 Magic_RemoveEnchantment. Remove an enchantment from your character.
        /// </summary>
        public event EventHandler<Magic_RemoveEnchantment>? OnMagic_RemoveEnchantment {
            add { _OnMagic_RemoveEnchantment.Subscribe(value); }
            remove { _OnMagic_RemoveEnchantment.Unsubscribe(value); }
        }
        private readonly WeakEvent<Magic_RemoveEnchantment> _OnMagic_RemoveEnchantment = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x02C4 Magic_UpdateMultipleEnchantments. Update multiple enchantments from your character.
        /// </summary>
        public event EventHandler<Magic_UpdateMultipleEnchantments>? OnMagic_UpdateMultipleEnchantments {
            add { _OnMagic_UpdateMultipleEnchantments.Subscribe(value); }
            remove { _OnMagic_UpdateMultipleEnchantments.Unsubscribe(value); }
        }
        private readonly WeakEvent<Magic_UpdateMultipleEnchantments> _OnMagic_UpdateMultipleEnchantments = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x02C5 Magic_RemoveMultipleEnchantments. Remove multiple enchantments from your character.
        /// </summary>
        public event EventHandler<Magic_RemoveMultipleEnchantments>? OnMagic_RemoveMultipleEnchantments {
            add { _OnMagic_RemoveMultipleEnchantments.Subscribe(value); }
            remove { _OnMagic_RemoveMultipleEnchantments.Unsubscribe(value); }
        }
        private readonly WeakEvent<Magic_RemoveMultipleEnchantments> _OnMagic_RemoveMultipleEnchantments = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x02C6 Magic_PurgeEnchantments. Silently remove all enchantments from your character, e.g. when you die (no message in the chat window).
        /// </summary>
        public event EventHandler<Magic_PurgeEnchantments>? OnMagic_PurgeEnchantments {
            add { _OnMagic_PurgeEnchantments.Subscribe(value); }
            remove { _OnMagic_PurgeEnchantments.Unsubscribe(value); }
        }
        private readonly WeakEvent<Magic_PurgeEnchantments> _OnMagic_PurgeEnchantments = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x02C7 Magic_DispelEnchantment. Silently remove An enchantment from your character.
        /// </summary>
        public event EventHandler<Magic_DispelEnchantment>? OnMagic_DispelEnchantment {
            add { _OnMagic_DispelEnchantment.Subscribe(value); }
            remove { _OnMagic_DispelEnchantment.Unsubscribe(value); }
        }
        private readonly WeakEvent<Magic_DispelEnchantment> _OnMagic_DispelEnchantment = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x02C8 Magic_DispelMultipleEnchantments. Silently remove multiple enchantments from your character (no message in the chat window).
        /// </summary>
        public event EventHandler<Magic_DispelMultipleEnchantments>? OnMagic_DispelMultipleEnchantments {
            add { _OnMagic_DispelMultipleEnchantments.Subscribe(value); }
            remove { _OnMagic_DispelMultipleEnchantments.Unsubscribe(value); }
        }
        private readonly WeakEvent<Magic_DispelMultipleEnchantments> _OnMagic_DispelMultipleEnchantments = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x02C9 Misc_PortalStormBrewing. A portal storm is brewing.
        /// </summary>
        public event EventHandler<Misc_PortalStormBrewing>? OnMisc_PortalStormBrewing {
            add { _OnMisc_PortalStormBrewing.Subscribe(value); }
            remove { _OnMisc_PortalStormBrewing.Unsubscribe(value); }
        }
        private readonly WeakEvent<Misc_PortalStormBrewing> _OnMisc_PortalStormBrewing = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x02CA Misc_PortalStormImminent. A portal storm is imminent.
        /// </summary>
        public event EventHandler<Misc_PortalStormImminent>? OnMisc_PortalStormImminent {
            add { _OnMisc_PortalStormImminent.Subscribe(value); }
            remove { _OnMisc_PortalStormImminent.Unsubscribe(value); }
        }
        private readonly WeakEvent<Misc_PortalStormImminent> _OnMisc_PortalStormImminent = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x02CB Misc_PortalStorm. You have been portal stormed.
        /// </summary>
        public event EventHandler<Misc_PortalStorm>? OnMisc_PortalStorm {
            add { _OnMisc_PortalStorm.Subscribe(value); }
            remove { _OnMisc_PortalStorm.Unsubscribe(value); }
        }
        private readonly WeakEvent<Misc_PortalStorm> _OnMisc_PortalStorm = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x02CC Misc_PortalStormSubsided. The portal storm has subsided.
        /// </summary>
        public event EventHandler<Misc_PortalStormSubsided>? OnMisc_PortalStormSubsided {
            add { _OnMisc_PortalStormSubsided.Subscribe(value); }
            remove { _OnMisc_PortalStormSubsided.Unsubscribe(value); }
        }
        private readonly WeakEvent<Misc_PortalStormSubsided> _OnMisc_PortalStormSubsided = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x02EB Communication_TransientString. Display a status message on the Action Viewscreen (the red text overlaid on the 3D area).
        /// </summary>
        public event EventHandler<Communication_TransientString>? OnCommunication_TransientString {
            add { _OnCommunication_TransientString.Subscribe(value); }
            remove { _OnCommunication_TransientString.Unsubscribe(value); }
        }
        private readonly WeakEvent<Communication_TransientString> _OnCommunication_TransientString = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0312 Magic_PurgeBadEnchantments. Remove all bad enchantments from your character.
        /// </summary>
        public event EventHandler<Magic_PurgeBadEnchantments>? OnMagic_PurgeBadEnchantments {
            add { _OnMagic_PurgeBadEnchantments.Subscribe(value); }
            remove { _OnMagic_PurgeBadEnchantments.Unsubscribe(value); }
        }
        private readonly WeakEvent<Magic_PurgeBadEnchantments> _OnMagic_PurgeBadEnchantments = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0314 Social_SendClientContractTrackerTable. Sends all contract data
        /// </summary>
        public event EventHandler<Social_SendClientContractTrackerTable>? OnSocial_SendClientContractTrackerTable {
            add { _OnSocial_SendClientContractTrackerTable.Subscribe(value); }
            remove { _OnSocial_SendClientContractTrackerTable.Unsubscribe(value); }
        }
        private readonly WeakEvent<Social_SendClientContractTrackerTable> _OnSocial_SendClientContractTrackerTable = new();
    
        /// <summary>
        /// Fired on GameEvent type 0x0315 Social_SendClientContractTracker. Updates a contract data
        /// </summary>
        public event EventHandler<Social_SendClientContractTracker>? OnSocial_SendClientContractTracker {
            add { _OnSocial_SendClientContractTracker.Subscribe(value); }
            remove { _OnSocial_SendClientContractTracker.Unsubscribe(value); }
        }
        private readonly WeakEvent<Social_SendClientContractTracker> _OnSocial_SendClientContractTracker = new();
    
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
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Allegiance_AllegianceUpdateAborted));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Allegiance_AllegianceUpdateAborted);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Allegiance_AllegianceUpdateAborted));
                            _OnAllegiance_AllegianceUpdateAborted?.Invoke(this, data_Allegiance_AllegianceUpdateAborted);
                            return data_Allegiance_AllegianceUpdateAborted;
        
                        case GameEventType.Communication_PopUpString:
                            var data_Communication_PopUpString = new Communication_PopUpString();
                            data_Communication_PopUpString.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_PopUpString));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Communication_PopUpString);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Communication_PopUpString));
                            _OnCommunication_PopUpString?.Invoke(this, data_Communication_PopUpString);
                            return data_Communication_PopUpString;
        
                        case GameEventType.Login_PlayerDescription:
                            var data_Login_PlayerDescription = new Login_PlayerDescription();
                            data_Login_PlayerDescription.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Login_PlayerDescription));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Login_PlayerDescription);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Login_PlayerDescription));
                            _OnLogin_PlayerDescription?.Invoke(this, data_Login_PlayerDescription);
                            return data_Login_PlayerDescription;
        
                        case GameEventType.Allegiance_AllegianceUpdate:
                            var data_Allegiance_AllegianceUpdate = new Allegiance_AllegianceUpdate();
                            data_Allegiance_AllegianceUpdate.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Allegiance_AllegianceUpdate));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Allegiance_AllegianceUpdate);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Allegiance_AllegianceUpdate));
                            _OnAllegiance_AllegianceUpdate?.Invoke(this, data_Allegiance_AllegianceUpdate);
                            return data_Allegiance_AllegianceUpdate;
        
                        case GameEventType.Social_FriendsUpdate:
                            var data_Social_FriendsUpdate = new Social_FriendsUpdate();
                            data_Social_FriendsUpdate.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Social_FriendsUpdate));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Social_FriendsUpdate);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Social_FriendsUpdate));
                            _OnSocial_FriendsUpdate?.Invoke(this, data_Social_FriendsUpdate);
                            return data_Social_FriendsUpdate;
        
                        case GameEventType.Item_ServerSaysContainId:
                            var data_Item_ServerSaysContainId = new Item_ServerSaysContainId();
                            data_Item_ServerSaysContainId.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_ServerSaysContainId));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Item_ServerSaysContainId);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Item_ServerSaysContainId));
                            _OnItem_ServerSaysContainId?.Invoke(this, data_Item_ServerSaysContainId);
                            return data_Item_ServerSaysContainId;
        
                        case GameEventType.Item_WearItem:
                            var data_Item_WearItem = new Item_WearItem();
                            data_Item_WearItem.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_WearItem));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Item_WearItem);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Item_WearItem));
                            _OnItem_WearItem?.Invoke(this, data_Item_WearItem);
                            return data_Item_WearItem;
        
                        case GameEventType.Social_CharacterTitleTable:
                            var data_Social_CharacterTitleTable = new Social_CharacterTitleTable();
                            data_Social_CharacterTitleTable.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Social_CharacterTitleTable));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Social_CharacterTitleTable);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Social_CharacterTitleTable));
                            _OnSocial_CharacterTitleTable?.Invoke(this, data_Social_CharacterTitleTable);
                            return data_Social_CharacterTitleTable;
        
                        case GameEventType.Social_AddOrSetCharacterTitle:
                            var data_Social_AddOrSetCharacterTitle = new Social_AddOrSetCharacterTitle();
                            data_Social_AddOrSetCharacterTitle.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Social_AddOrSetCharacterTitle));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Social_AddOrSetCharacterTitle);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Social_AddOrSetCharacterTitle));
                            _OnSocial_AddOrSetCharacterTitle?.Invoke(this, data_Social_AddOrSetCharacterTitle);
                            return data_Social_AddOrSetCharacterTitle;
        
                        case GameEventType.Item_StopViewingObjectContents:
                            var data_Item_StopViewingObjectContents = new Item_StopViewingObjectContents();
                            data_Item_StopViewingObjectContents.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_StopViewingObjectContents));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Item_StopViewingObjectContents);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Item_StopViewingObjectContents));
                            _OnItem_StopViewingObjectContents?.Invoke(this, data_Item_StopViewingObjectContents);
                            return data_Item_StopViewingObjectContents;
        
                        case GameEventType.Vendor_VendorInfo:
                            var data_Vendor_VendorInfo = new Vendor_VendorInfo();
                            data_Vendor_VendorInfo.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Vendor_VendorInfo));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Vendor_VendorInfo);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Vendor_VendorInfo));
                            _OnVendor_VendorInfo?.Invoke(this, data_Vendor_VendorInfo);
                            return data_Vendor_VendorInfo;
        
                        case GameEventType.Character_StartBarber:
                            var data_Character_StartBarber = new Character_StartBarber();
                            data_Character_StartBarber.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Character_StartBarber));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Character_StartBarber);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Character_StartBarber));
                            _OnCharacter_StartBarber?.Invoke(this, data_Character_StartBarber);
                            return data_Character_StartBarber;
        
                        case GameEventType.Fellowship_Quit:
                            var data_Fellowship_Quit = new Fellowship_Quit();
                            data_Fellowship_Quit.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Fellowship_Quit));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Fellowship_Quit);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Fellowship_Quit));
                            _OnFellowship_Quit?.Invoke(this, data_Fellowship_Quit);
                            return data_Fellowship_Quit;
        
                        case GameEventType.Fellowship_Dismiss:
                            var data_Fellowship_Dismiss = new Fellowship_Dismiss();
                            data_Fellowship_Dismiss.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Fellowship_Dismiss));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Fellowship_Dismiss);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Fellowship_Dismiss));
                            _OnFellowship_Dismiss?.Invoke(this, data_Fellowship_Dismiss);
                            return data_Fellowship_Dismiss;
        
                        case GameEventType.Writing_BookOpen:
                            var data_Writing_BookOpen = new Writing_BookOpen();
                            data_Writing_BookOpen.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Writing_BookOpen));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Writing_BookOpen);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Writing_BookOpen));
                            _OnWriting_BookOpen?.Invoke(this, data_Writing_BookOpen);
                            return data_Writing_BookOpen;
        
                        case GameEventType.Writing_BookAddPageResponse:
                            var data_Writing_BookAddPageResponse = new Writing_BookAddPageResponse();
                            data_Writing_BookAddPageResponse.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Writing_BookAddPageResponse));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Writing_BookAddPageResponse);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Writing_BookAddPageResponse));
                            _OnWriting_BookAddPageResponse?.Invoke(this, data_Writing_BookAddPageResponse);
                            return data_Writing_BookAddPageResponse;
        
                        case GameEventType.Writing_BookDeletePageResponse:
                            var data_Writing_BookDeletePageResponse = new Writing_BookDeletePageResponse();
                            data_Writing_BookDeletePageResponse.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Writing_BookDeletePageResponse));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Writing_BookDeletePageResponse);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Writing_BookDeletePageResponse));
                            _OnWriting_BookDeletePageResponse?.Invoke(this, data_Writing_BookDeletePageResponse);
                            return data_Writing_BookDeletePageResponse;
        
                        case GameEventType.Writing_BookPageDataResponse:
                            var data_Writing_BookPageDataResponse = new Writing_BookPageDataResponse();
                            data_Writing_BookPageDataResponse.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Writing_BookPageDataResponse));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Writing_BookPageDataResponse);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Writing_BookPageDataResponse));
                            _OnWriting_BookPageDataResponse?.Invoke(this, data_Writing_BookPageDataResponse);
                            return data_Writing_BookPageDataResponse;
        
                        case GameEventType.Item_GetInscriptionResponse:
                            var data_Item_GetInscriptionResponse = new Item_GetInscriptionResponse();
                            data_Item_GetInscriptionResponse.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_GetInscriptionResponse));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Item_GetInscriptionResponse);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Item_GetInscriptionResponse));
                            _OnItem_GetInscriptionResponse?.Invoke(this, data_Item_GetInscriptionResponse);
                            return data_Item_GetInscriptionResponse;
        
                        case GameEventType.Item_SetAppraiseInfo:
                            var data_Item_SetAppraiseInfo = new Item_SetAppraiseInfo();
                            data_Item_SetAppraiseInfo.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_SetAppraiseInfo));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Item_SetAppraiseInfo);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Item_SetAppraiseInfo));
                            _OnItem_SetAppraiseInfo?.Invoke(this, data_Item_SetAppraiseInfo);
                            return data_Item_SetAppraiseInfo;
        
                        case GameEventType.Communication_ChannelBroadcast:
                            var data_Communication_ChannelBroadcast = new Communication_ChannelBroadcast();
                            data_Communication_ChannelBroadcast.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_ChannelBroadcast));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Communication_ChannelBroadcast);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Communication_ChannelBroadcast));
                            _OnCommunication_ChannelBroadcast?.Invoke(this, data_Communication_ChannelBroadcast);
                            return data_Communication_ChannelBroadcast;
        
                        case GameEventType.Communication_ChannelList:
                            var data_Communication_ChannelList = new Communication_ChannelList();
                            data_Communication_ChannelList.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_ChannelList));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Communication_ChannelList);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Communication_ChannelList));
                            _OnCommunication_ChannelList?.Invoke(this, data_Communication_ChannelList);
                            return data_Communication_ChannelList;
        
                        case GameEventType.Communication_ChannelIndex:
                            var data_Communication_ChannelIndex = new Communication_ChannelIndex();
                            data_Communication_ChannelIndex.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_ChannelIndex));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Communication_ChannelIndex);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Communication_ChannelIndex));
                            _OnCommunication_ChannelIndex?.Invoke(this, data_Communication_ChannelIndex);
                            return data_Communication_ChannelIndex;
        
                        case GameEventType.Item_OnViewContents:
                            var data_Item_OnViewContents = new Item_OnViewContents();
                            data_Item_OnViewContents.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_OnViewContents));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Item_OnViewContents);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Item_OnViewContents));
                            _OnItem_OnViewContents?.Invoke(this, data_Item_OnViewContents);
                            return data_Item_OnViewContents;
        
                        case GameEventType.Item_ServerSaysMoveItem:
                            var data_Item_ServerSaysMoveItem = new Item_ServerSaysMoveItem();
                            data_Item_ServerSaysMoveItem.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_ServerSaysMoveItem));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Item_ServerSaysMoveItem);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Item_ServerSaysMoveItem));
                            _OnItem_ServerSaysMoveItem?.Invoke(this, data_Item_ServerSaysMoveItem);
                            return data_Item_ServerSaysMoveItem;
        
                        case GameEventType.Combat_HandleAttackDoneEvent:
                            var data_Combat_HandleAttackDoneEvent = new Combat_HandleAttackDoneEvent();
                            data_Combat_HandleAttackDoneEvent.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Combat_HandleAttackDoneEvent));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Combat_HandleAttackDoneEvent);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Combat_HandleAttackDoneEvent));
                            _OnCombat_HandleAttackDoneEvent?.Invoke(this, data_Combat_HandleAttackDoneEvent);
                            return data_Combat_HandleAttackDoneEvent;
        
                        case GameEventType.Magic_RemoveSpell:
                            var data_Magic_RemoveSpell = new Magic_RemoveSpell();
                            data_Magic_RemoveSpell.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Magic_RemoveSpell));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Magic_RemoveSpell);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Magic_RemoveSpell));
                            _OnMagic_RemoveSpell?.Invoke(this, data_Magic_RemoveSpell);
                            return data_Magic_RemoveSpell;
        
                        case GameEventType.Combat_HandleVictimNotificationEventSelf:
                            var data_Combat_HandleVictimNotificationEventSelf = new Combat_HandleVictimNotificationEventSelf();
                            data_Combat_HandleVictimNotificationEventSelf.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Combat_HandleVictimNotificationEventSelf));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Combat_HandleVictimNotificationEventSelf);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Combat_HandleVictimNotificationEventSelf));
                            _OnCombat_HandleVictimNotificationEventSelf?.Invoke(this, data_Combat_HandleVictimNotificationEventSelf);
                            return data_Combat_HandleVictimNotificationEventSelf;
        
                        case GameEventType.Combat_HandleVictimNotificationEventOther:
                            var data_Combat_HandleVictimNotificationEventOther = new Combat_HandleVictimNotificationEventOther();
                            data_Combat_HandleVictimNotificationEventOther.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Combat_HandleVictimNotificationEventOther));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Combat_HandleVictimNotificationEventOther);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Combat_HandleVictimNotificationEventOther));
                            _OnCombat_HandleVictimNotificationEventOther?.Invoke(this, data_Combat_HandleVictimNotificationEventOther);
                            return data_Combat_HandleVictimNotificationEventOther;
        
                        case GameEventType.Combat_HandleAttackerNotificationEvent:
                            var data_Combat_HandleAttackerNotificationEvent = new Combat_HandleAttackerNotificationEvent();
                            data_Combat_HandleAttackerNotificationEvent.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Combat_HandleAttackerNotificationEvent));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Combat_HandleAttackerNotificationEvent);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Combat_HandleAttackerNotificationEvent));
                            _OnCombat_HandleAttackerNotificationEvent?.Invoke(this, data_Combat_HandleAttackerNotificationEvent);
                            return data_Combat_HandleAttackerNotificationEvent;
        
                        case GameEventType.Combat_HandleDefenderNotificationEvent:
                            var data_Combat_HandleDefenderNotificationEvent = new Combat_HandleDefenderNotificationEvent();
                            data_Combat_HandleDefenderNotificationEvent.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Combat_HandleDefenderNotificationEvent));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Combat_HandleDefenderNotificationEvent);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Combat_HandleDefenderNotificationEvent));
                            _OnCombat_HandleDefenderNotificationEvent?.Invoke(this, data_Combat_HandleDefenderNotificationEvent);
                            return data_Combat_HandleDefenderNotificationEvent;
        
                        case GameEventType.Combat_HandleEvasionAttackerNotificationEvent:
                            var data_Combat_HandleEvasionAttackerNotificationEvent = new Combat_HandleEvasionAttackerNotificationEvent();
                            data_Combat_HandleEvasionAttackerNotificationEvent.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Combat_HandleEvasionAttackerNotificationEvent));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Combat_HandleEvasionAttackerNotificationEvent);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Combat_HandleEvasionAttackerNotificationEvent));
                            _OnCombat_HandleEvasionAttackerNotificationEvent?.Invoke(this, data_Combat_HandleEvasionAttackerNotificationEvent);
                            return data_Combat_HandleEvasionAttackerNotificationEvent;
        
                        case GameEventType.Combat_HandleEvasionDefenderNotificationEvent:
                            var data_Combat_HandleEvasionDefenderNotificationEvent = new Combat_HandleEvasionDefenderNotificationEvent();
                            data_Combat_HandleEvasionDefenderNotificationEvent.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Combat_HandleEvasionDefenderNotificationEvent));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Combat_HandleEvasionDefenderNotificationEvent);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Combat_HandleEvasionDefenderNotificationEvent));
                            _OnCombat_HandleEvasionDefenderNotificationEvent?.Invoke(this, data_Combat_HandleEvasionDefenderNotificationEvent);
                            return data_Combat_HandleEvasionDefenderNotificationEvent;
        
                        case GameEventType.Combat_HandleCommenceAttackEvent:
                            var data_Combat_HandleCommenceAttackEvent = new Combat_HandleCommenceAttackEvent();
                            data_Combat_HandleCommenceAttackEvent.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Combat_HandleCommenceAttackEvent));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Combat_HandleCommenceAttackEvent);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Combat_HandleCommenceAttackEvent));
                            _OnCombat_HandleCommenceAttackEvent?.Invoke(this, data_Combat_HandleCommenceAttackEvent);
                            return data_Combat_HandleCommenceAttackEvent;
        
                        case GameEventType.Combat_QueryHealthResponse:
                            var data_Combat_QueryHealthResponse = new Combat_QueryHealthResponse();
                            data_Combat_QueryHealthResponse.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Combat_QueryHealthResponse));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Combat_QueryHealthResponse);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Combat_QueryHealthResponse));
                            _OnCombat_QueryHealthResponse?.Invoke(this, data_Combat_QueryHealthResponse);
                            return data_Combat_QueryHealthResponse;
        
                        case GameEventType.Character_QueryAgeResponse:
                            var data_Character_QueryAgeResponse = new Character_QueryAgeResponse();
                            data_Character_QueryAgeResponse.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Character_QueryAgeResponse));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Character_QueryAgeResponse);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Character_QueryAgeResponse));
                            _OnCharacter_QueryAgeResponse?.Invoke(this, data_Character_QueryAgeResponse);
                            return data_Character_QueryAgeResponse;
        
                        case GameEventType.Item_UseDone:
                            var data_Item_UseDone = new Item_UseDone();
                            data_Item_UseDone.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_UseDone));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Item_UseDone);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Item_UseDone));
                            _OnItem_UseDone?.Invoke(this, data_Item_UseDone);
                            return data_Item_UseDone;
        
                        case GameEventType.Allegiance_AllegianceUpdateDone:
                            var data_Allegiance_AllegianceUpdateDone = new Allegiance_AllegianceUpdateDone();
                            data_Allegiance_AllegianceUpdateDone.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Allegiance_AllegianceUpdateDone));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Allegiance_AllegianceUpdateDone);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Allegiance_AllegianceUpdateDone));
                            _OnAllegiance_AllegianceUpdateDone?.Invoke(this, data_Allegiance_AllegianceUpdateDone);
                            return data_Allegiance_AllegianceUpdateDone;
        
                        case GameEventType.Fellowship_FellowUpdateDone:
                            var data_Fellowship_FellowUpdateDone = new Fellowship_FellowUpdateDone();
                            data_Fellowship_FellowUpdateDone.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Fellowship_FellowUpdateDone));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Fellowship_FellowUpdateDone);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Fellowship_FellowUpdateDone));
                            _OnFellowship_FellowUpdateDone?.Invoke(this, data_Fellowship_FellowUpdateDone);
                            return data_Fellowship_FellowUpdateDone;
        
                        case GameEventType.Fellowship_FellowStatsDone:
                            var data_Fellowship_FellowStatsDone = new Fellowship_FellowStatsDone();
                            data_Fellowship_FellowStatsDone.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Fellowship_FellowStatsDone));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Fellowship_FellowStatsDone);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Fellowship_FellowStatsDone));
                            _OnFellowship_FellowStatsDone?.Invoke(this, data_Fellowship_FellowStatsDone);
                            return data_Fellowship_FellowStatsDone;
        
                        case GameEventType.Item_AppraiseDone:
                            var data_Item_AppraiseDone = new Item_AppraiseDone();
                            data_Item_AppraiseDone.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_AppraiseDone));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Item_AppraiseDone);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Item_AppraiseDone));
                            _OnItem_AppraiseDone?.Invoke(this, data_Item_AppraiseDone);
                            return data_Item_AppraiseDone;
        
                        case GameEventType.Character_ReturnPing:
                            var data_Character_ReturnPing = new Character_ReturnPing();
                            data_Character_ReturnPing.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Character_ReturnPing));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Character_ReturnPing);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Character_ReturnPing));
                            _OnCharacter_ReturnPing?.Invoke(this, data_Character_ReturnPing);
                            return data_Character_ReturnPing;
        
                        case GameEventType.Communication_SetSquelchDB:
                            var data_Communication_SetSquelchDB = new Communication_SetSquelchDB();
                            data_Communication_SetSquelchDB.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_SetSquelchDB));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Communication_SetSquelchDB);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Communication_SetSquelchDB));
                            _OnCommunication_SetSquelchDB?.Invoke(this, data_Communication_SetSquelchDB);
                            return data_Communication_SetSquelchDB;
        
                        case GameEventType.Trade_RegisterTrade:
                            var data_Trade_RegisterTrade = new Trade_RegisterTrade();
                            data_Trade_RegisterTrade.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Trade_RegisterTrade));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Trade_RegisterTrade);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Trade_RegisterTrade));
                            _OnTrade_RegisterTrade?.Invoke(this, data_Trade_RegisterTrade);
                            return data_Trade_RegisterTrade;
        
                        case GameEventType.Trade_OpenTrade:
                            var data_Trade_OpenTrade = new Trade_OpenTrade();
                            data_Trade_OpenTrade.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Trade_OpenTrade));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Trade_OpenTrade);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Trade_OpenTrade));
                            _OnTrade_OpenTrade?.Invoke(this, data_Trade_OpenTrade);
                            return data_Trade_OpenTrade;
        
                        case GameEventType.Trade_CloseTrade:
                            var data_Trade_CloseTrade = new Trade_CloseTrade();
                            data_Trade_CloseTrade.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Trade_CloseTrade));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Trade_CloseTrade);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Trade_CloseTrade));
                            _OnTrade_CloseTrade?.Invoke(this, data_Trade_CloseTrade);
                            return data_Trade_CloseTrade;
        
                        case GameEventType.Trade_AddToTrade:
                            var data_Trade_AddToTrade = new Trade_AddToTrade();
                            data_Trade_AddToTrade.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Trade_AddToTrade));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Trade_AddToTrade);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Trade_AddToTrade));
                            _OnTrade_AddToTrade?.Invoke(this, data_Trade_AddToTrade);
                            return data_Trade_AddToTrade;
        
                        case GameEventType.Trade_RemoveFromTrade:
                            var data_Trade_RemoveFromTrade = new Trade_RemoveFromTrade();
                            data_Trade_RemoveFromTrade.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Trade_RemoveFromTrade));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Trade_RemoveFromTrade);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Trade_RemoveFromTrade));
                            _OnTrade_RemoveFromTrade?.Invoke(this, data_Trade_RemoveFromTrade);
                            return data_Trade_RemoveFromTrade;
        
                        case GameEventType.Trade_AcceptTrade:
                            var data_Trade_AcceptTrade = new Trade_AcceptTrade();
                            data_Trade_AcceptTrade.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Trade_AcceptTrade));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Trade_AcceptTrade);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Trade_AcceptTrade));
                            _OnTrade_AcceptTrade?.Invoke(this, data_Trade_AcceptTrade);
                            return data_Trade_AcceptTrade;
        
                        case GameEventType.Trade_DeclineTrade:
                            var data_Trade_DeclineTrade = new Trade_DeclineTrade();
                            data_Trade_DeclineTrade.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Trade_DeclineTrade));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Trade_DeclineTrade);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Trade_DeclineTrade));
                            _OnTrade_DeclineTrade?.Invoke(this, data_Trade_DeclineTrade);
                            return data_Trade_DeclineTrade;
        
                        case GameEventType.Trade_ResetTrade:
                            var data_Trade_ResetTrade = new Trade_ResetTrade();
                            data_Trade_ResetTrade.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Trade_ResetTrade));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Trade_ResetTrade);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Trade_ResetTrade));
                            _OnTrade_ResetTrade?.Invoke(this, data_Trade_ResetTrade);
                            return data_Trade_ResetTrade;
        
                        case GameEventType.Trade_TradeFailure:
                            var data_Trade_TradeFailure = new Trade_TradeFailure();
                            data_Trade_TradeFailure.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Trade_TradeFailure));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Trade_TradeFailure);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Trade_TradeFailure));
                            _OnTrade_TradeFailure?.Invoke(this, data_Trade_TradeFailure);
                            return data_Trade_TradeFailure;
        
                        case GameEventType.Trade_ClearTradeAcceptance:
                            var data_Trade_ClearTradeAcceptance = new Trade_ClearTradeAcceptance();
                            data_Trade_ClearTradeAcceptance.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Trade_ClearTradeAcceptance));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Trade_ClearTradeAcceptance);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Trade_ClearTradeAcceptance));
                            _OnTrade_ClearTradeAcceptance?.Invoke(this, data_Trade_ClearTradeAcceptance);
                            return data_Trade_ClearTradeAcceptance;
        
                        case GameEventType.House_HouseProfile:
                            var data_House_HouseProfile = new House_HouseProfile();
                            data_House_HouseProfile.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_House_HouseProfile));
                            _OnOrdered_GameEvent?.Invoke(this,  data_House_HouseProfile);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_House_HouseProfile));
                            _OnHouse_HouseProfile?.Invoke(this, data_House_HouseProfile);
                            return data_House_HouseProfile;
        
                        case GameEventType.House_HouseData:
                            var data_House_HouseData = new House_HouseData();
                            data_House_HouseData.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_House_HouseData));
                            _OnOrdered_GameEvent?.Invoke(this,  data_House_HouseData);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_House_HouseData));
                            _OnHouse_HouseData?.Invoke(this, data_House_HouseData);
                            return data_House_HouseData;
        
                        case GameEventType.House_HouseStatus:
                            var data_House_HouseStatus = new House_HouseStatus();
                            data_House_HouseStatus.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_House_HouseStatus));
                            _OnOrdered_GameEvent?.Invoke(this,  data_House_HouseStatus);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_House_HouseStatus));
                            _OnHouse_HouseStatus?.Invoke(this, data_House_HouseStatus);
                            return data_House_HouseStatus;
        
                        case GameEventType.House_UpdateRentTime:
                            var data_House_UpdateRentTime = new House_UpdateRentTime();
                            data_House_UpdateRentTime.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_House_UpdateRentTime));
                            _OnOrdered_GameEvent?.Invoke(this,  data_House_UpdateRentTime);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_House_UpdateRentTime));
                            _OnHouse_UpdateRentTime?.Invoke(this, data_House_UpdateRentTime);
                            return data_House_UpdateRentTime;
        
                        case GameEventType.House_UpdateRentPayment:
                            var data_House_UpdateRentPayment = new House_UpdateRentPayment();
                            data_House_UpdateRentPayment.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_House_UpdateRentPayment));
                            _OnOrdered_GameEvent?.Invoke(this,  data_House_UpdateRentPayment);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_House_UpdateRentPayment));
                            _OnHouse_UpdateRentPayment?.Invoke(this, data_House_UpdateRentPayment);
                            return data_House_UpdateRentPayment;
        
                        case GameEventType.House_UpdateRestrictions:
                            var data_House_UpdateRestrictions = new House_UpdateRestrictions();
                            data_House_UpdateRestrictions.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_House_UpdateRestrictions));
                            _OnOrdered_GameEvent?.Invoke(this,  data_House_UpdateRestrictions);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_House_UpdateRestrictions));
                            _OnHouse_UpdateRestrictions?.Invoke(this, data_House_UpdateRestrictions);
                            return data_House_UpdateRestrictions;
        
                        case GameEventType.House_UpdateHAR:
                            var data_House_UpdateHAR = new House_UpdateHAR();
                            data_House_UpdateHAR.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_House_UpdateHAR));
                            _OnOrdered_GameEvent?.Invoke(this,  data_House_UpdateHAR);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_House_UpdateHAR));
                            _OnHouse_UpdateHAR?.Invoke(this, data_House_UpdateHAR);
                            return data_House_UpdateHAR;
        
                        case GameEventType.House_HouseTransaction:
                            var data_House_HouseTransaction = new House_HouseTransaction();
                            data_House_HouseTransaction.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_House_HouseTransaction));
                            _OnOrdered_GameEvent?.Invoke(this,  data_House_HouseTransaction);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_House_HouseTransaction));
                            _OnHouse_HouseTransaction?.Invoke(this, data_House_HouseTransaction);
                            return data_House_HouseTransaction;
        
                        case GameEventType.Item_QueryItemManaResponse:
                            var data_Item_QueryItemManaResponse = new Item_QueryItemManaResponse();
                            data_Item_QueryItemManaResponse.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_QueryItemManaResponse));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Item_QueryItemManaResponse);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Item_QueryItemManaResponse));
                            _OnItem_QueryItemManaResponse?.Invoke(this, data_Item_QueryItemManaResponse);
                            return data_Item_QueryItemManaResponse;
        
                        case GameEventType.House_AvailableHouses:
                            var data_House_AvailableHouses = new House_AvailableHouses();
                            data_House_AvailableHouses.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_House_AvailableHouses));
                            _OnOrdered_GameEvent?.Invoke(this,  data_House_AvailableHouses);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_House_AvailableHouses));
                            _OnHouse_AvailableHouses?.Invoke(this, data_House_AvailableHouses);
                            return data_House_AvailableHouses;
        
                        case GameEventType.Character_ConfirmationRequest:
                            var data_Character_ConfirmationRequest = new Character_ConfirmationRequest();
                            data_Character_ConfirmationRequest.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Character_ConfirmationRequest));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Character_ConfirmationRequest);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Character_ConfirmationRequest));
                            _OnCharacter_ConfirmationRequest?.Invoke(this, data_Character_ConfirmationRequest);
                            return data_Character_ConfirmationRequest;
        
                        case GameEventType.Character_ConfirmationDone:
                            var data_Character_ConfirmationDone = new Character_ConfirmationDone();
                            data_Character_ConfirmationDone.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Character_ConfirmationDone));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Character_ConfirmationDone);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Character_ConfirmationDone));
                            _OnCharacter_ConfirmationDone?.Invoke(this, data_Character_ConfirmationDone);
                            return data_Character_ConfirmationDone;
        
                        case GameEventType.Allegiance_AllegianceLoginNotificationEvent:
                            var data_Allegiance_AllegianceLoginNotificationEvent = new Allegiance_AllegianceLoginNotificationEvent();
                            data_Allegiance_AllegianceLoginNotificationEvent.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Allegiance_AllegianceLoginNotificationEvent));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Allegiance_AllegianceLoginNotificationEvent);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Allegiance_AllegianceLoginNotificationEvent));
                            _OnAllegiance_AllegianceLoginNotificationEvent?.Invoke(this, data_Allegiance_AllegianceLoginNotificationEvent);
                            return data_Allegiance_AllegianceLoginNotificationEvent;
        
                        case GameEventType.Allegiance_AllegianceInfoResponseEvent:
                            var data_Allegiance_AllegianceInfoResponseEvent = new Allegiance_AllegianceInfoResponseEvent();
                            data_Allegiance_AllegianceInfoResponseEvent.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Allegiance_AllegianceInfoResponseEvent));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Allegiance_AllegianceInfoResponseEvent);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Allegiance_AllegianceInfoResponseEvent));
                            _OnAllegiance_AllegianceInfoResponseEvent?.Invoke(this, data_Allegiance_AllegianceInfoResponseEvent);
                            return data_Allegiance_AllegianceInfoResponseEvent;
        
                        case GameEventType.Game_JoinGameResponse:
                            var data_Game_JoinGameResponse = new Game_JoinGameResponse();
                            data_Game_JoinGameResponse.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Game_JoinGameResponse));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Game_JoinGameResponse);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Game_JoinGameResponse));
                            _OnGame_JoinGameResponse?.Invoke(this, data_Game_JoinGameResponse);
                            return data_Game_JoinGameResponse;
        
                        case GameEventType.Game_StartGame:
                            var data_Game_StartGame = new Game_StartGame();
                            data_Game_StartGame.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Game_StartGame));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Game_StartGame);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Game_StartGame));
                            _OnGame_StartGame?.Invoke(this, data_Game_StartGame);
                            return data_Game_StartGame;
        
                        case GameEventType.Game_MoveResponse:
                            var data_Game_MoveResponse = new Game_MoveResponse();
                            data_Game_MoveResponse.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Game_MoveResponse));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Game_MoveResponse);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Game_MoveResponse));
                            _OnGame_MoveResponse?.Invoke(this, data_Game_MoveResponse);
                            return data_Game_MoveResponse;
        
                        case GameEventType.Game_OpponentTurn:
                            var data_Game_OpponentTurn = new Game_OpponentTurn();
                            data_Game_OpponentTurn.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Game_OpponentTurn));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Game_OpponentTurn);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Game_OpponentTurn));
                            _OnGame_OpponentTurn?.Invoke(this, data_Game_OpponentTurn);
                            return data_Game_OpponentTurn;
        
                        case GameEventType.Game_OpponentStalemateState:
                            var data_Game_OpponentStalemateState = new Game_OpponentStalemateState();
                            data_Game_OpponentStalemateState.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Game_OpponentStalemateState));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Game_OpponentStalemateState);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Game_OpponentStalemateState));
                            _OnGame_OpponentStalemateState?.Invoke(this, data_Game_OpponentStalemateState);
                            return data_Game_OpponentStalemateState;
        
                        case GameEventType.Communication_WeenieError:
                            var data_Communication_WeenieError = new Communication_WeenieError();
                            data_Communication_WeenieError.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_WeenieError));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Communication_WeenieError);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Communication_WeenieError));
                            _OnCommunication_WeenieError?.Invoke(this, data_Communication_WeenieError);
                            return data_Communication_WeenieError;
        
                        case GameEventType.Communication_WeenieErrorWithString:
                            var data_Communication_WeenieErrorWithString = new Communication_WeenieErrorWithString();
                            data_Communication_WeenieErrorWithString.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_WeenieErrorWithString));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Communication_WeenieErrorWithString);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Communication_WeenieErrorWithString));
                            _OnCommunication_WeenieErrorWithString?.Invoke(this, data_Communication_WeenieErrorWithString);
                            return data_Communication_WeenieErrorWithString;
        
                        case GameEventType.Game_GameOver:
                            var data_Game_GameOver = new Game_GameOver();
                            data_Game_GameOver.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Game_GameOver));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Game_GameOver);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Game_GameOver));
                            _OnGame_GameOver?.Invoke(this, data_Game_GameOver);
                            return data_Game_GameOver;
        
                        case GameEventType.Communication_ChatRoomTracker:
                            var data_Communication_ChatRoomTracker = new Communication_ChatRoomTracker();
                            data_Communication_ChatRoomTracker.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_ChatRoomTracker));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Communication_ChatRoomTracker);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Communication_ChatRoomTracker));
                            _OnCommunication_ChatRoomTracker?.Invoke(this, data_Communication_ChatRoomTracker);
                            return data_Communication_ChatRoomTracker;
        
                        case GameEventType.Admin_QueryPluginList:
                            var data_Admin_QueryPluginList = new Admin_QueryPluginList();
                            data_Admin_QueryPluginList.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Admin_QueryPluginList));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Admin_QueryPluginList);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Admin_QueryPluginList));
                            _OnAdmin_QueryPluginList?.Invoke(this, data_Admin_QueryPluginList);
                            return data_Admin_QueryPluginList;
        
                        case GameEventType.Admin_QueryPlugin:
                            var data_Admin_QueryPlugin = new Admin_QueryPlugin();
                            data_Admin_QueryPlugin.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Admin_QueryPlugin));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Admin_QueryPlugin);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Admin_QueryPlugin));
                            _OnAdmin_QueryPlugin?.Invoke(this, data_Admin_QueryPlugin);
                            return data_Admin_QueryPlugin;
        
                        case GameEventType.Admin_QueryPluginResponse2:
                            var data_Admin_QueryPluginResponse2 = new Admin_QueryPluginResponse2();
                            data_Admin_QueryPluginResponse2.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Admin_QueryPluginResponse2));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Admin_QueryPluginResponse2);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Admin_QueryPluginResponse2));
                            _OnAdmin_QueryPluginResponse2?.Invoke(this, data_Admin_QueryPluginResponse2);
                            return data_Admin_QueryPluginResponse2;
        
                        case GameEventType.Inventory_SalvageOperationsResultData:
                            var data_Inventory_SalvageOperationsResultData = new Inventory_SalvageOperationsResultData();
                            data_Inventory_SalvageOperationsResultData.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Inventory_SalvageOperationsResultData));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Inventory_SalvageOperationsResultData);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Inventory_SalvageOperationsResultData));
                            _OnInventory_SalvageOperationsResultData?.Invoke(this, data_Inventory_SalvageOperationsResultData);
                            return data_Inventory_SalvageOperationsResultData;
        
                        case GameEventType.Communication_HearDirectSpeech:
                            var data_Communication_HearDirectSpeech = new Communication_HearDirectSpeech();
                            data_Communication_HearDirectSpeech.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_HearDirectSpeech));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Communication_HearDirectSpeech);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Communication_HearDirectSpeech));
                            _OnCommunication_HearDirectSpeech?.Invoke(this, data_Communication_HearDirectSpeech);
                            return data_Communication_HearDirectSpeech;
        
                        case GameEventType.Fellowship_FullUpdate:
                            var data_Fellowship_FullUpdate = new Fellowship_FullUpdate();
                            data_Fellowship_FullUpdate.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Fellowship_FullUpdate));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Fellowship_FullUpdate);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Fellowship_FullUpdate));
                            _OnFellowship_FullUpdate?.Invoke(this, data_Fellowship_FullUpdate);
                            return data_Fellowship_FullUpdate;
        
                        case GameEventType.Fellowship_Disband:
                            var data_Fellowship_Disband = new Fellowship_Disband();
                            data_Fellowship_Disband.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Fellowship_Disband));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Fellowship_Disband);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Fellowship_Disband));
                            _OnFellowship_Disband?.Invoke(this, data_Fellowship_Disband);
                            return data_Fellowship_Disband;
        
                        case GameEventType.Fellowship_UpdateFellow:
                            var data_Fellowship_UpdateFellow = new Fellowship_UpdateFellow();
                            data_Fellowship_UpdateFellow.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Fellowship_UpdateFellow));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Fellowship_UpdateFellow);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Fellowship_UpdateFellow));
                            _OnFellowship_UpdateFellow?.Invoke(this, data_Fellowship_UpdateFellow);
                            return data_Fellowship_UpdateFellow;
        
                        case GameEventType.Magic_UpdateSpell:
                            var data_Magic_UpdateSpell = new Magic_UpdateSpell();
                            data_Magic_UpdateSpell.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Magic_UpdateSpell));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Magic_UpdateSpell);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Magic_UpdateSpell));
                            _OnMagic_UpdateSpell?.Invoke(this, data_Magic_UpdateSpell);
                            return data_Magic_UpdateSpell;
        
                        case GameEventType.Magic_UpdateEnchantment:
                            var data_Magic_UpdateEnchantment = new Magic_UpdateEnchantment();
                            data_Magic_UpdateEnchantment.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Magic_UpdateEnchantment));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Magic_UpdateEnchantment);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Magic_UpdateEnchantment));
                            _OnMagic_UpdateEnchantment?.Invoke(this, data_Magic_UpdateEnchantment);
                            return data_Magic_UpdateEnchantment;
        
                        case GameEventType.Magic_RemoveEnchantment:
                            var data_Magic_RemoveEnchantment = new Magic_RemoveEnchantment();
                            data_Magic_RemoveEnchantment.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Magic_RemoveEnchantment));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Magic_RemoveEnchantment);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Magic_RemoveEnchantment));
                            _OnMagic_RemoveEnchantment?.Invoke(this, data_Magic_RemoveEnchantment);
                            return data_Magic_RemoveEnchantment;
        
                        case GameEventType.Magic_UpdateMultipleEnchantments:
                            var data_Magic_UpdateMultipleEnchantments = new Magic_UpdateMultipleEnchantments();
                            data_Magic_UpdateMultipleEnchantments.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Magic_UpdateMultipleEnchantments));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Magic_UpdateMultipleEnchantments);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Magic_UpdateMultipleEnchantments));
                            _OnMagic_UpdateMultipleEnchantments?.Invoke(this, data_Magic_UpdateMultipleEnchantments);
                            return data_Magic_UpdateMultipleEnchantments;
        
                        case GameEventType.Magic_RemoveMultipleEnchantments:
                            var data_Magic_RemoveMultipleEnchantments = new Magic_RemoveMultipleEnchantments();
                            data_Magic_RemoveMultipleEnchantments.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Magic_RemoveMultipleEnchantments));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Magic_RemoveMultipleEnchantments);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Magic_RemoveMultipleEnchantments));
                            _OnMagic_RemoveMultipleEnchantments?.Invoke(this, data_Magic_RemoveMultipleEnchantments);
                            return data_Magic_RemoveMultipleEnchantments;
        
                        case GameEventType.Magic_PurgeEnchantments:
                            var data_Magic_PurgeEnchantments = new Magic_PurgeEnchantments();
                            data_Magic_PurgeEnchantments.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Magic_PurgeEnchantments));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Magic_PurgeEnchantments);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Magic_PurgeEnchantments));
                            _OnMagic_PurgeEnchantments?.Invoke(this, data_Magic_PurgeEnchantments);
                            return data_Magic_PurgeEnchantments;
        
                        case GameEventType.Magic_DispelEnchantment:
                            var data_Magic_DispelEnchantment = new Magic_DispelEnchantment();
                            data_Magic_DispelEnchantment.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Magic_DispelEnchantment));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Magic_DispelEnchantment);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Magic_DispelEnchantment));
                            _OnMagic_DispelEnchantment?.Invoke(this, data_Magic_DispelEnchantment);
                            return data_Magic_DispelEnchantment;
        
                        case GameEventType.Magic_DispelMultipleEnchantments:
                            var data_Magic_DispelMultipleEnchantments = new Magic_DispelMultipleEnchantments();
                            data_Magic_DispelMultipleEnchantments.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Magic_DispelMultipleEnchantments));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Magic_DispelMultipleEnchantments);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Magic_DispelMultipleEnchantments));
                            _OnMagic_DispelMultipleEnchantments?.Invoke(this, data_Magic_DispelMultipleEnchantments);
                            return data_Magic_DispelMultipleEnchantments;
        
                        case GameEventType.Misc_PortalStormBrewing:
                            var data_Misc_PortalStormBrewing = new Misc_PortalStormBrewing();
                            data_Misc_PortalStormBrewing.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Misc_PortalStormBrewing));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Misc_PortalStormBrewing);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Misc_PortalStormBrewing));
                            _OnMisc_PortalStormBrewing?.Invoke(this, data_Misc_PortalStormBrewing);
                            return data_Misc_PortalStormBrewing;
        
                        case GameEventType.Misc_PortalStormImminent:
                            var data_Misc_PortalStormImminent = new Misc_PortalStormImminent();
                            data_Misc_PortalStormImminent.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Misc_PortalStormImminent));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Misc_PortalStormImminent);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Misc_PortalStormImminent));
                            _OnMisc_PortalStormImminent?.Invoke(this, data_Misc_PortalStormImminent);
                            return data_Misc_PortalStormImminent;
        
                        case GameEventType.Misc_PortalStorm:
                            var data_Misc_PortalStorm = new Misc_PortalStorm();
                            data_Misc_PortalStorm.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Misc_PortalStorm));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Misc_PortalStorm);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Misc_PortalStorm));
                            _OnMisc_PortalStorm?.Invoke(this, data_Misc_PortalStorm);
                            return data_Misc_PortalStorm;
        
                        case GameEventType.Misc_PortalStormSubsided:
                            var data_Misc_PortalStormSubsided = new Misc_PortalStormSubsided();
                            data_Misc_PortalStormSubsided.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Misc_PortalStormSubsided));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Misc_PortalStormSubsided);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Misc_PortalStormSubsided));
                            _OnMisc_PortalStormSubsided?.Invoke(this, data_Misc_PortalStormSubsided);
                            return data_Misc_PortalStormSubsided;
        
                        case GameEventType.Communication_TransientString:
                            var data_Communication_TransientString = new Communication_TransientString();
                            data_Communication_TransientString.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_TransientString));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Communication_TransientString);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Communication_TransientString));
                            _OnCommunication_TransientString?.Invoke(this, data_Communication_TransientString);
                            return data_Communication_TransientString;
        
                        case GameEventType.Magic_PurgeBadEnchantments:
                            var data_Magic_PurgeBadEnchantments = new Magic_PurgeBadEnchantments();
                            data_Magic_PurgeBadEnchantments.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Magic_PurgeBadEnchantments));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Magic_PurgeBadEnchantments);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Magic_PurgeBadEnchantments));
                            _OnMagic_PurgeBadEnchantments?.Invoke(this, data_Magic_PurgeBadEnchantments);
                            return data_Magic_PurgeBadEnchantments;
        
                        case GameEventType.Social_SendClientContractTrackerTable:
                            var data_Social_SendClientContractTrackerTable = new Social_SendClientContractTrackerTable();
                            data_Social_SendClientContractTrackerTable.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Social_SendClientContractTrackerTable));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Social_SendClientContractTrackerTable);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Social_SendClientContractTrackerTable));
                            _OnSocial_SendClientContractTrackerTable?.Invoke(this, data_Social_SendClientContractTrackerTable);
                            return data_Social_SendClientContractTrackerTable;
        
                        case GameEventType.Social_SendClientContractTracker:
                            var data_Social_SendClientContractTracker = new Social_SendClientContractTracker();
                            data_Social_SendClientContractTracker.Read(reader);
                            _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Social_SendClientContractTracker));
                            _OnOrdered_GameEvent?.Invoke(this,  data_Social_SendClientContractTracker);
                            _OnGameEvent?.Invoke(this, new GameEventEventArgs(eventType, data_Social_SendClientContractTracker));
                            _OnSocial_SendClientContractTracker?.Invoke(this, data_Social_SendClientContractTracker);
                            return data_Social_SendClientContractTracker;
        
                        }
                        return null;// end 0xF7B0
    
                    case S2CMessageType.Item_ServerSaysRemove:
                        var data_Item_ServerSaysRemove = new Item_ServerSaysRemove();
                        data_Item_ServerSaysRemove.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_ServerSaysRemove));
                        _OnItem_ServerSaysRemove?.Invoke(this, data_Item_ServerSaysRemove);
                        return data_Item_ServerSaysRemove;
    
                    case S2CMessageType.Character_ServerSaysAttemptFailed:
                        var data_Character_ServerSaysAttemptFailed = new Character_ServerSaysAttemptFailed();
                        data_Character_ServerSaysAttemptFailed.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Character_ServerSaysAttemptFailed));
                        _OnCharacter_ServerSaysAttemptFailed?.Invoke(this, data_Character_ServerSaysAttemptFailed);
                        return data_Character_ServerSaysAttemptFailed;
    
                    case S2CMessageType.Item_UpdateStackSize:
                        var data_Item_UpdateStackSize = new Item_UpdateStackSize();
                        data_Item_UpdateStackSize.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_UpdateStackSize));
                        _OnItem_UpdateStackSize?.Invoke(this, data_Item_UpdateStackSize);
                        return data_Item_UpdateStackSize;
    
                    case S2CMessageType.Combat_HandlePlayerDeathEvent:
                        var data_Combat_HandlePlayerDeathEvent = new Combat_HandlePlayerDeathEvent();
                        data_Combat_HandlePlayerDeathEvent.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Combat_HandlePlayerDeathEvent));
                        _OnCombat_HandlePlayerDeathEvent?.Invoke(this, data_Combat_HandlePlayerDeathEvent);
                        return data_Combat_HandlePlayerDeathEvent;
    
                    case S2CMessageType.Qualities_PrivateRemoveIntEvent:
                        var data_Qualities_PrivateRemoveIntEvent = new Qualities_PrivateRemoveIntEvent();
                        data_Qualities_PrivateRemoveIntEvent.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateRemoveIntEvent));
                        _OnQualities_PrivateRemoveIntEvent?.Invoke(this, data_Qualities_PrivateRemoveIntEvent);
                        return data_Qualities_PrivateRemoveIntEvent;
    
                    case S2CMessageType.Qualities_RemoveIntEvent:
                        var data_Qualities_RemoveIntEvent = new Qualities_RemoveIntEvent();
                        data_Qualities_RemoveIntEvent.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_RemoveIntEvent));
                        _OnQualities_RemoveIntEvent?.Invoke(this, data_Qualities_RemoveIntEvent);
                        return data_Qualities_RemoveIntEvent;
    
                    case S2CMessageType.Qualities_PrivateRemoveBoolEvent:
                        var data_Qualities_PrivateRemoveBoolEvent = new Qualities_PrivateRemoveBoolEvent();
                        data_Qualities_PrivateRemoveBoolEvent.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateRemoveBoolEvent));
                        _OnQualities_PrivateRemoveBoolEvent?.Invoke(this, data_Qualities_PrivateRemoveBoolEvent);
                        return data_Qualities_PrivateRemoveBoolEvent;
    
                    case S2CMessageType.Qualities_RemoveBoolEvent:
                        var data_Qualities_RemoveBoolEvent = new Qualities_RemoveBoolEvent();
                        data_Qualities_RemoveBoolEvent.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_RemoveBoolEvent));
                        _OnQualities_RemoveBoolEvent?.Invoke(this, data_Qualities_RemoveBoolEvent);
                        return data_Qualities_RemoveBoolEvent;
    
                    case S2CMessageType.Qualities_PrivateRemoveFloatEvent:
                        var data_Qualities_PrivateRemoveFloatEvent = new Qualities_PrivateRemoveFloatEvent();
                        data_Qualities_PrivateRemoveFloatEvent.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateRemoveFloatEvent));
                        _OnQualities_PrivateRemoveFloatEvent?.Invoke(this, data_Qualities_PrivateRemoveFloatEvent);
                        return data_Qualities_PrivateRemoveFloatEvent;
    
                    case S2CMessageType.Qualities_RemoveFloatEvent:
                        var data_Qualities_RemoveFloatEvent = new Qualities_RemoveFloatEvent();
                        data_Qualities_RemoveFloatEvent.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_RemoveFloatEvent));
                        _OnQualities_RemoveFloatEvent?.Invoke(this, data_Qualities_RemoveFloatEvent);
                        return data_Qualities_RemoveFloatEvent;
    
                    case S2CMessageType.Qualities_PrivateRemoveStringEvent:
                        var data_Qualities_PrivateRemoveStringEvent = new Qualities_PrivateRemoveStringEvent();
                        data_Qualities_PrivateRemoveStringEvent.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateRemoveStringEvent));
                        _OnQualities_PrivateRemoveStringEvent?.Invoke(this, data_Qualities_PrivateRemoveStringEvent);
                        return data_Qualities_PrivateRemoveStringEvent;
    
                    case S2CMessageType.Qualities_RemoveStringEvent:
                        var data_Qualities_RemoveStringEvent = new Qualities_RemoveStringEvent();
                        data_Qualities_RemoveStringEvent.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_RemoveStringEvent));
                        _OnQualities_RemoveStringEvent?.Invoke(this, data_Qualities_RemoveStringEvent);
                        return data_Qualities_RemoveStringEvent;
    
                    case S2CMessageType.Qualities_PrivateRemoveDataIdEvent:
                        var data_Qualities_PrivateRemoveDataIdEvent = new Qualities_PrivateRemoveDataIdEvent();
                        data_Qualities_PrivateRemoveDataIdEvent.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateRemoveDataIdEvent));
                        _OnQualities_PrivateRemoveDataIdEvent?.Invoke(this, data_Qualities_PrivateRemoveDataIdEvent);
                        return data_Qualities_PrivateRemoveDataIdEvent;
    
                    case S2CMessageType.Qualities_RemoveDataIdEvent:
                        var data_Qualities_RemoveDataIdEvent = new Qualities_RemoveDataIdEvent();
                        data_Qualities_RemoveDataIdEvent.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_RemoveDataIdEvent));
                        _OnQualities_RemoveDataIdEvent?.Invoke(this, data_Qualities_RemoveDataIdEvent);
                        return data_Qualities_RemoveDataIdEvent;
    
                    case S2CMessageType.Qualities_PrivateRemoveInstanceIdEvent:
                        var data_Qualities_PrivateRemoveInstanceIdEvent = new Qualities_PrivateRemoveInstanceIdEvent();
                        data_Qualities_PrivateRemoveInstanceIdEvent.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateRemoveInstanceIdEvent));
                        _OnQualities_PrivateRemoveInstanceIdEvent?.Invoke(this, data_Qualities_PrivateRemoveInstanceIdEvent);
                        return data_Qualities_PrivateRemoveInstanceIdEvent;
    
                    case S2CMessageType.Qualities_RemoveInstanceIdEvent:
                        var data_Qualities_RemoveInstanceIdEvent = new Qualities_RemoveInstanceIdEvent();
                        data_Qualities_RemoveInstanceIdEvent.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_RemoveInstanceIdEvent));
                        _OnQualities_RemoveInstanceIdEvent?.Invoke(this, data_Qualities_RemoveInstanceIdEvent);
                        return data_Qualities_RemoveInstanceIdEvent;
    
                    case S2CMessageType.Qualities_PrivateRemovePositionEvent:
                        var data_Qualities_PrivateRemovePositionEvent = new Qualities_PrivateRemovePositionEvent();
                        data_Qualities_PrivateRemovePositionEvent.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateRemovePositionEvent));
                        _OnQualities_PrivateRemovePositionEvent?.Invoke(this, data_Qualities_PrivateRemovePositionEvent);
                        return data_Qualities_PrivateRemovePositionEvent;
    
                    case S2CMessageType.Qualities_RemovePositionEvent:
                        var data_Qualities_RemovePositionEvent = new Qualities_RemovePositionEvent();
                        data_Qualities_RemovePositionEvent.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_RemovePositionEvent));
                        _OnQualities_RemovePositionEvent?.Invoke(this, data_Qualities_RemovePositionEvent);
                        return data_Qualities_RemovePositionEvent;
    
                    case S2CMessageType.Qualities_PrivateRemoveInt64Event:
                        var data_Qualities_PrivateRemoveInt64Event = new Qualities_PrivateRemoveInt64Event();
                        data_Qualities_PrivateRemoveInt64Event.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateRemoveInt64Event));
                        _OnQualities_PrivateRemoveInt64Event?.Invoke(this, data_Qualities_PrivateRemoveInt64Event);
                        return data_Qualities_PrivateRemoveInt64Event;
    
                    case S2CMessageType.Qualities_RemoveInt64Event:
                        var data_Qualities_RemoveInt64Event = new Qualities_RemoveInt64Event();
                        data_Qualities_RemoveInt64Event.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_RemoveInt64Event));
                        _OnQualities_RemoveInt64Event?.Invoke(this, data_Qualities_RemoveInt64Event);
                        return data_Qualities_RemoveInt64Event;
    
                    case S2CMessageType.Qualities_PrivateUpdateInt:
                        var data_Qualities_PrivateUpdateInt = new Qualities_PrivateUpdateInt();
                        data_Qualities_PrivateUpdateInt.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateInt));
                        _OnQualities_PrivateUpdateInt?.Invoke(this, data_Qualities_PrivateUpdateInt);
                        return data_Qualities_PrivateUpdateInt;
    
                    case S2CMessageType.Qualities_UpdateInt:
                        var data_Qualities_UpdateInt = new Qualities_UpdateInt();
                        data_Qualities_UpdateInt.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateInt));
                        _OnQualities_UpdateInt?.Invoke(this, data_Qualities_UpdateInt);
                        return data_Qualities_UpdateInt;
    
                    case S2CMessageType.Qualities_PrivateUpdateInt64:
                        var data_Qualities_PrivateUpdateInt64 = new Qualities_PrivateUpdateInt64();
                        data_Qualities_PrivateUpdateInt64.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateInt64));
                        _OnQualities_PrivateUpdateInt64?.Invoke(this, data_Qualities_PrivateUpdateInt64);
                        return data_Qualities_PrivateUpdateInt64;
    
                    case S2CMessageType.Qualities_UpdateInt64:
                        var data_Qualities_UpdateInt64 = new Qualities_UpdateInt64();
                        data_Qualities_UpdateInt64.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateInt64));
                        _OnQualities_UpdateInt64?.Invoke(this, data_Qualities_UpdateInt64);
                        return data_Qualities_UpdateInt64;
    
                    case S2CMessageType.Qualities_PrivateUpdateBool:
                        var data_Qualities_PrivateUpdateBool = new Qualities_PrivateUpdateBool();
                        data_Qualities_PrivateUpdateBool.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateBool));
                        _OnQualities_PrivateUpdateBool?.Invoke(this, data_Qualities_PrivateUpdateBool);
                        return data_Qualities_PrivateUpdateBool;
    
                    case S2CMessageType.Qualities_UpdateBool:
                        var data_Qualities_UpdateBool = new Qualities_UpdateBool();
                        data_Qualities_UpdateBool.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateBool));
                        _OnQualities_UpdateBool?.Invoke(this, data_Qualities_UpdateBool);
                        return data_Qualities_UpdateBool;
    
                    case S2CMessageType.Qualities_PrivateUpdateFloat:
                        var data_Qualities_PrivateUpdateFloat = new Qualities_PrivateUpdateFloat();
                        data_Qualities_PrivateUpdateFloat.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateFloat));
                        _OnQualities_PrivateUpdateFloat?.Invoke(this, data_Qualities_PrivateUpdateFloat);
                        return data_Qualities_PrivateUpdateFloat;
    
                    case S2CMessageType.Qualities_UpdateFloat:
                        var data_Qualities_UpdateFloat = new Qualities_UpdateFloat();
                        data_Qualities_UpdateFloat.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateFloat));
                        _OnQualities_UpdateFloat?.Invoke(this, data_Qualities_UpdateFloat);
                        return data_Qualities_UpdateFloat;
    
                    case S2CMessageType.Qualities_PrivateUpdateString:
                        var data_Qualities_PrivateUpdateString = new Qualities_PrivateUpdateString();
                        data_Qualities_PrivateUpdateString.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateString));
                        _OnQualities_PrivateUpdateString?.Invoke(this, data_Qualities_PrivateUpdateString);
                        return data_Qualities_PrivateUpdateString;
    
                    case S2CMessageType.Qualities_UpdateString:
                        var data_Qualities_UpdateString = new Qualities_UpdateString();
                        data_Qualities_UpdateString.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateString));
                        _OnQualities_UpdateString?.Invoke(this, data_Qualities_UpdateString);
                        return data_Qualities_UpdateString;
    
                    case S2CMessageType.Qualities_PrivateUpdateDataId:
                        var data_Qualities_PrivateUpdateDataId = new Qualities_PrivateUpdateDataId();
                        data_Qualities_PrivateUpdateDataId.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateDataId));
                        _OnQualities_PrivateUpdateDataId?.Invoke(this, data_Qualities_PrivateUpdateDataId);
                        return data_Qualities_PrivateUpdateDataId;
    
                    case S2CMessageType.Qualities_UpdateDataId:
                        var data_Qualities_UpdateDataId = new Qualities_UpdateDataId();
                        data_Qualities_UpdateDataId.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateDataId));
                        _OnQualities_UpdateDataId?.Invoke(this, data_Qualities_UpdateDataId);
                        return data_Qualities_UpdateDataId;
    
                    case S2CMessageType.Qualities_PrivateUpdateInstanceId:
                        var data_Qualities_PrivateUpdateInstanceId = new Qualities_PrivateUpdateInstanceId();
                        data_Qualities_PrivateUpdateInstanceId.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateInstanceId));
                        _OnQualities_PrivateUpdateInstanceId?.Invoke(this, data_Qualities_PrivateUpdateInstanceId);
                        return data_Qualities_PrivateUpdateInstanceId;
    
                    case S2CMessageType.Qualities_UpdateInstanceId:
                        var data_Qualities_UpdateInstanceId = new Qualities_UpdateInstanceId();
                        data_Qualities_UpdateInstanceId.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateInstanceId));
                        _OnQualities_UpdateInstanceId?.Invoke(this, data_Qualities_UpdateInstanceId);
                        return data_Qualities_UpdateInstanceId;
    
                    case S2CMessageType.Qualities_PrivateUpdatePosition:
                        var data_Qualities_PrivateUpdatePosition = new Qualities_PrivateUpdatePosition();
                        data_Qualities_PrivateUpdatePosition.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdatePosition));
                        _OnQualities_PrivateUpdatePosition?.Invoke(this, data_Qualities_PrivateUpdatePosition);
                        return data_Qualities_PrivateUpdatePosition;
    
                    case S2CMessageType.Qualities_UpdatePosition:
                        var data_Qualities_UpdatePosition = new Qualities_UpdatePosition();
                        data_Qualities_UpdatePosition.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdatePosition));
                        _OnQualities_UpdatePosition?.Invoke(this, data_Qualities_UpdatePosition);
                        return data_Qualities_UpdatePosition;
    
                    case S2CMessageType.Qualities_PrivateUpdateSkill:
                        var data_Qualities_PrivateUpdateSkill = new Qualities_PrivateUpdateSkill();
                        data_Qualities_PrivateUpdateSkill.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateSkill));
                        _OnQualities_PrivateUpdateSkill?.Invoke(this, data_Qualities_PrivateUpdateSkill);
                        return data_Qualities_PrivateUpdateSkill;
    
                    case S2CMessageType.Qualities_UpdateSkill:
                        var data_Qualities_UpdateSkill = new Qualities_UpdateSkill();
                        data_Qualities_UpdateSkill.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateSkill));
                        _OnQualities_UpdateSkill?.Invoke(this, data_Qualities_UpdateSkill);
                        return data_Qualities_UpdateSkill;
    
                    case S2CMessageType.Qualities_PrivateUpdateSkillLevel:
                        var data_Qualities_PrivateUpdateSkillLevel = new Qualities_PrivateUpdateSkillLevel();
                        data_Qualities_PrivateUpdateSkillLevel.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateSkillLevel));
                        _OnQualities_PrivateUpdateSkillLevel?.Invoke(this, data_Qualities_PrivateUpdateSkillLevel);
                        return data_Qualities_PrivateUpdateSkillLevel;
    
                    case S2CMessageType.Qualities_UpdateSkillLevel:
                        var data_Qualities_UpdateSkillLevel = new Qualities_UpdateSkillLevel();
                        data_Qualities_UpdateSkillLevel.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateSkillLevel));
                        _OnQualities_UpdateSkillLevel?.Invoke(this, data_Qualities_UpdateSkillLevel);
                        return data_Qualities_UpdateSkillLevel;
    
                    case S2CMessageType.Qualities_PrivateUpdateSkillAC:
                        var data_Qualities_PrivateUpdateSkillAC = new Qualities_PrivateUpdateSkillAC();
                        data_Qualities_PrivateUpdateSkillAC.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateSkillAC));
                        _OnQualities_PrivateUpdateSkillAC?.Invoke(this, data_Qualities_PrivateUpdateSkillAC);
                        return data_Qualities_PrivateUpdateSkillAC;
    
                    case S2CMessageType.Qualities_UpdateSkillAC:
                        var data_Qualities_UpdateSkillAC = new Qualities_UpdateSkillAC();
                        data_Qualities_UpdateSkillAC.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateSkillAC));
                        _OnQualities_UpdateSkillAC?.Invoke(this, data_Qualities_UpdateSkillAC);
                        return data_Qualities_UpdateSkillAC;
    
                    case S2CMessageType.Qualities_PrivateUpdateAttribute:
                        var data_Qualities_PrivateUpdateAttribute = new Qualities_PrivateUpdateAttribute();
                        data_Qualities_PrivateUpdateAttribute.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateAttribute));
                        _OnQualities_PrivateUpdateAttribute?.Invoke(this, data_Qualities_PrivateUpdateAttribute);
                        return data_Qualities_PrivateUpdateAttribute;
    
                    case S2CMessageType.Qualities_UpdateAttribute:
                        var data_Qualities_UpdateAttribute = new Qualities_UpdateAttribute();
                        data_Qualities_UpdateAttribute.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateAttribute));
                        _OnQualities_UpdateAttribute?.Invoke(this, data_Qualities_UpdateAttribute);
                        return data_Qualities_UpdateAttribute;
    
                    case S2CMessageType.Qualities_PrivateUpdateAttributeLevel:
                        var data_Qualities_PrivateUpdateAttributeLevel = new Qualities_PrivateUpdateAttributeLevel();
                        data_Qualities_PrivateUpdateAttributeLevel.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateAttributeLevel));
                        _OnQualities_PrivateUpdateAttributeLevel?.Invoke(this, data_Qualities_PrivateUpdateAttributeLevel);
                        return data_Qualities_PrivateUpdateAttributeLevel;
    
                    case S2CMessageType.Qualities_UpdateAttributeLevel:
                        var data_Qualities_UpdateAttributeLevel = new Qualities_UpdateAttributeLevel();
                        data_Qualities_UpdateAttributeLevel.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateAttributeLevel));
                        _OnQualities_UpdateAttributeLevel?.Invoke(this, data_Qualities_UpdateAttributeLevel);
                        return data_Qualities_UpdateAttributeLevel;
    
                    case S2CMessageType.Qualities_PrivateUpdateAttribute2nd:
                        var data_Qualities_PrivateUpdateAttribute2nd = new Qualities_PrivateUpdateAttribute2nd();
                        data_Qualities_PrivateUpdateAttribute2nd.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateAttribute2nd));
                        _OnQualities_PrivateUpdateAttribute2nd?.Invoke(this, data_Qualities_PrivateUpdateAttribute2nd);
                        return data_Qualities_PrivateUpdateAttribute2nd;
    
                    case S2CMessageType.Qualities_UpdateAttribute2nd:
                        var data_Qualities_UpdateAttribute2nd = new Qualities_UpdateAttribute2nd();
                        data_Qualities_UpdateAttribute2nd.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateAttribute2nd));
                        _OnQualities_UpdateAttribute2nd?.Invoke(this, data_Qualities_UpdateAttribute2nd);
                        return data_Qualities_UpdateAttribute2nd;
    
                    case S2CMessageType.Qualities_PrivateUpdateAttribute2ndLevel:
                        var data_Qualities_PrivateUpdateAttribute2ndLevel = new Qualities_PrivateUpdateAttribute2ndLevel();
                        data_Qualities_PrivateUpdateAttribute2ndLevel.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_PrivateUpdateAttribute2ndLevel));
                        _OnQualities_PrivateUpdateAttribute2ndLevel?.Invoke(this, data_Qualities_PrivateUpdateAttribute2ndLevel);
                        return data_Qualities_PrivateUpdateAttribute2ndLevel;
    
                    case S2CMessageType.Qualities_UpdateAttribute2ndLevel:
                        var data_Qualities_UpdateAttribute2ndLevel = new Qualities_UpdateAttribute2ndLevel();
                        data_Qualities_UpdateAttribute2ndLevel.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Qualities_UpdateAttribute2ndLevel));
                        _OnQualities_UpdateAttribute2ndLevel?.Invoke(this, data_Qualities_UpdateAttribute2ndLevel);
                        return data_Qualities_UpdateAttribute2ndLevel;
    
                    case S2CMessageType.Communication_HearEmote:
                        var data_Communication_HearEmote = new Communication_HearEmote();
                        data_Communication_HearEmote.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_HearEmote));
                        _OnCommunication_HearEmote?.Invoke(this, data_Communication_HearEmote);
                        return data_Communication_HearEmote;
    
                    case S2CMessageType.Communication_HearSoulEmote:
                        var data_Communication_HearSoulEmote = new Communication_HearSoulEmote();
                        data_Communication_HearSoulEmote.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_HearSoulEmote));
                        _OnCommunication_HearSoulEmote?.Invoke(this, data_Communication_HearSoulEmote);
                        return data_Communication_HearSoulEmote;
    
                    case S2CMessageType.Communication_HearSpeech:
                        var data_Communication_HearSpeech = new Communication_HearSpeech();
                        data_Communication_HearSpeech.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_HearSpeech));
                        _OnCommunication_HearSpeech?.Invoke(this, data_Communication_HearSpeech);
                        return data_Communication_HearSpeech;
    
                    case S2CMessageType.Communication_HearRangedSpeech:
                        var data_Communication_HearRangedSpeech = new Communication_HearRangedSpeech();
                        data_Communication_HearRangedSpeech.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_HearRangedSpeech));
                        _OnCommunication_HearRangedSpeech?.Invoke(this, data_Communication_HearRangedSpeech);
                        return data_Communication_HearRangedSpeech;
    
                    case S2CMessageType.Admin_Environs:
                        var data_Admin_Environs = new Admin_Environs();
                        data_Admin_Environs.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Admin_Environs));
                        _OnAdmin_Environs?.Invoke(this, data_Admin_Environs);
                        return data_Admin_Environs;
    
                    case S2CMessageType.Movement_PositionAndMovementEvent:
                        var data_Movement_PositionAndMovementEvent = new Movement_PositionAndMovementEvent();
                        data_Movement_PositionAndMovementEvent.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Movement_PositionAndMovementEvent));
                        _OnMovement_PositionAndMovementEvent?.Invoke(this, data_Movement_PositionAndMovementEvent);
                        return data_Movement_PositionAndMovementEvent;
    
                    case S2CMessageType.Item_ObjDescEvent:
                        var data_Item_ObjDescEvent = new Item_ObjDescEvent();
                        data_Item_ObjDescEvent.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_ObjDescEvent));
                        _OnItem_ObjDescEvent?.Invoke(this, data_Item_ObjDescEvent);
                        return data_Item_ObjDescEvent;
    
                    case S2CMessageType.Character_SetPlayerVisualDesc:
                        var data_Character_SetPlayerVisualDesc = new Character_SetPlayerVisualDesc();
                        data_Character_SetPlayerVisualDesc.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Character_SetPlayerVisualDesc));
                        _OnCharacter_SetPlayerVisualDesc?.Invoke(this, data_Character_SetPlayerVisualDesc);
                        return data_Character_SetPlayerVisualDesc;
    
                    case S2CMessageType.Character_CharGenVerificationResponse:
                        var data_Character_CharGenVerificationResponse = new Character_CharGenVerificationResponse();
                        data_Character_CharGenVerificationResponse.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Character_CharGenVerificationResponse));
                        _OnCharacter_CharGenVerificationResponse?.Invoke(this, data_Character_CharGenVerificationResponse);
                        return data_Character_CharGenVerificationResponse;
    
                    case S2CMessageType.Login_AwaitingSubscriptionExpiration:
                        var data_Login_AwaitingSubscriptionExpiration = new Login_AwaitingSubscriptionExpiration();
                        data_Login_AwaitingSubscriptionExpiration.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Login_AwaitingSubscriptionExpiration));
                        _OnLogin_AwaitingSubscriptionExpiration?.Invoke(this, data_Login_AwaitingSubscriptionExpiration);
                        return data_Login_AwaitingSubscriptionExpiration;
    
                    case S2CMessageType.Login_LogOffCharacter:
                        var data_Login_LogOffCharacter = new Login_LogOffCharacter();
                        data_Login_LogOffCharacter.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Login_LogOffCharacter));
                        _OnLogin_LogOffCharacter?.Invoke(this, data_Login_LogOffCharacter);
                        return data_Login_LogOffCharacter;
    
                    case S2CMessageType.Character_CharacterDelete:
                        var data_Character_CharacterDelete = new Character_CharacterDelete();
                        data_Character_CharacterDelete.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Character_CharacterDelete));
                        _OnCharacter_CharacterDelete?.Invoke(this, data_Character_CharacterDelete);
                        return data_Character_CharacterDelete;
    
                    case S2CMessageType.Login_LoginCharacterSet:
                        var data_Login_LoginCharacterSet = new Login_LoginCharacterSet();
                        data_Login_LoginCharacterSet.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Login_LoginCharacterSet));
                        _OnLogin_LoginCharacterSet?.Invoke(this, data_Login_LoginCharacterSet);
                        return data_Login_LoginCharacterSet;
    
                    case S2CMessageType.Character_CharacterError:
                        var data_Character_CharacterError = new Character_CharacterError();
                        data_Character_CharacterError.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Character_CharacterError));
                        _OnCharacter_CharacterError?.Invoke(this, data_Character_CharacterError);
                        return data_Character_CharacterError;
    
                    case S2CMessageType.Item_CreateObject:
                        var data_Item_CreateObject = new Item_CreateObject();
                        data_Item_CreateObject.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_CreateObject));
                        _OnItem_CreateObject?.Invoke(this, data_Item_CreateObject);
                        return data_Item_CreateObject;
    
                    case S2CMessageType.Login_CreatePlayer:
                        var data_Login_CreatePlayer = new Login_CreatePlayer();
                        data_Login_CreatePlayer.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Login_CreatePlayer));
                        _OnLogin_CreatePlayer?.Invoke(this, data_Login_CreatePlayer);
                        return data_Login_CreatePlayer;
    
                    case S2CMessageType.Item_DeleteObject:
                        var data_Item_DeleteObject = new Item_DeleteObject();
                        data_Item_DeleteObject.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_DeleteObject));
                        _OnItem_DeleteObject?.Invoke(this, data_Item_DeleteObject);
                        return data_Item_DeleteObject;
    
                    case S2CMessageType.Movement_PositionEvent:
                        var data_Movement_PositionEvent = new Movement_PositionEvent();
                        data_Movement_PositionEvent.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Movement_PositionEvent));
                        _OnMovement_PositionEvent?.Invoke(this, data_Movement_PositionEvent);
                        return data_Movement_PositionEvent;
    
                    case S2CMessageType.Item_ParentEvent:
                        var data_Item_ParentEvent = new Item_ParentEvent();
                        data_Item_ParentEvent.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_ParentEvent));
                        _OnItem_ParentEvent?.Invoke(this, data_Item_ParentEvent);
                        return data_Item_ParentEvent;
    
                    case S2CMessageType.Inventory_PickupEvent:
                        var data_Inventory_PickupEvent = new Inventory_PickupEvent();
                        data_Inventory_PickupEvent.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Inventory_PickupEvent));
                        _OnInventory_PickupEvent?.Invoke(this, data_Inventory_PickupEvent);
                        return data_Inventory_PickupEvent;
    
                    case S2CMessageType.Item_SetState:
                        var data_Item_SetState = new Item_SetState();
                        data_Item_SetState.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_SetState));
                        _OnItem_SetState?.Invoke(this, data_Item_SetState);
                        return data_Item_SetState;
    
                    case S2CMessageType.Movement_SetObjectMovement:
                        var data_Movement_SetObjectMovement = new Movement_SetObjectMovement();
                        data_Movement_SetObjectMovement.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Movement_SetObjectMovement));
                        _OnMovement_SetObjectMovement?.Invoke(this, data_Movement_SetObjectMovement);
                        return data_Movement_SetObjectMovement;
    
                    case S2CMessageType.Movement_VectorUpdate:
                        var data_Movement_VectorUpdate = new Movement_VectorUpdate();
                        data_Movement_VectorUpdate.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Movement_VectorUpdate));
                        _OnMovement_VectorUpdate?.Invoke(this, data_Movement_VectorUpdate);
                        return data_Movement_VectorUpdate;
    
                    case S2CMessageType.Effects_SoundEvent:
                        var data_Effects_SoundEvent = new Effects_SoundEvent();
                        data_Effects_SoundEvent.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Effects_SoundEvent));
                        _OnEffects_SoundEvent?.Invoke(this, data_Effects_SoundEvent);
                        return data_Effects_SoundEvent;
    
                    case S2CMessageType.Effects_PlayerTeleport:
                        var data_Effects_PlayerTeleport = new Effects_PlayerTeleport();
                        data_Effects_PlayerTeleport.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Effects_PlayerTeleport));
                        _OnEffects_PlayerTeleport?.Invoke(this, data_Effects_PlayerTeleport);
                        return data_Effects_PlayerTeleport;
    
                    case S2CMessageType.Effects_PlayScriptId:
                        var data_Effects_PlayScriptId = new Effects_PlayScriptId();
                        data_Effects_PlayScriptId.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Effects_PlayScriptId));
                        _OnEffects_PlayScriptId?.Invoke(this, data_Effects_PlayScriptId);
                        return data_Effects_PlayScriptId;
    
                    case S2CMessageType.Effects_PlayScriptType:
                        var data_Effects_PlayScriptType = new Effects_PlayScriptType();
                        data_Effects_PlayScriptType.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Effects_PlayScriptType));
                        _OnEffects_PlayScriptType?.Invoke(this, data_Effects_PlayScriptType);
                        return data_Effects_PlayScriptType;
    
                    case S2CMessageType.Login_AccountBanned:
                        var data_Login_AccountBanned = new Login_AccountBanned();
                        data_Login_AccountBanned.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Login_AccountBanned));
                        _OnLogin_AccountBanned?.Invoke(this, data_Login_AccountBanned);
                        return data_Login_AccountBanned;
    
                    case S2CMessageType.Admin_ReceiveAccountData:
                        var data_Admin_ReceiveAccountData = new Admin_ReceiveAccountData();
                        data_Admin_ReceiveAccountData.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Admin_ReceiveAccountData));
                        _OnAdmin_ReceiveAccountData?.Invoke(this, data_Admin_ReceiveAccountData);
                        return data_Admin_ReceiveAccountData;
    
                    case S2CMessageType.Admin_ReceivePlayerData:
                        var data_Admin_ReceivePlayerData = new Admin_ReceivePlayerData();
                        data_Admin_ReceivePlayerData.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Admin_ReceivePlayerData));
                        _OnAdmin_ReceivePlayerData?.Invoke(this, data_Admin_ReceivePlayerData);
                        return data_Admin_ReceivePlayerData;
    
                    case S2CMessageType.Item_UpdateObject:
                        var data_Item_UpdateObject = new Item_UpdateObject();
                        data_Item_UpdateObject.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Item_UpdateObject));
                        _OnItem_UpdateObject?.Invoke(this, data_Item_UpdateObject);
                        return data_Item_UpdateObject;
    
                    case S2CMessageType.Login_AccountBooted:
                        var data_Login_AccountBooted = new Login_AccountBooted();
                        data_Login_AccountBooted.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Login_AccountBooted));
                        _OnLogin_AccountBooted?.Invoke(this, data_Login_AccountBooted);
                        return data_Login_AccountBooted;
    
                    case S2CMessageType.Communication_TurbineChat:
                        var data_Communication_TurbineChat = new Communication_TurbineChat();
                        data_Communication_TurbineChat.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_TurbineChat));
                        _OnCommunication_TurbineChat?.Invoke(this, data_Communication_TurbineChat);
                        return data_Communication_TurbineChat;
    
                    case S2CMessageType.Login_EnterGame_ServerReady:
                        var data_Login_EnterGame_ServerReady = new Login_EnterGame_ServerReady();
                        data_Login_EnterGame_ServerReady.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Login_EnterGame_ServerReady));
                        _OnLogin_EnterGame_ServerReady?.Invoke(this, data_Login_EnterGame_ServerReady);
                        return data_Login_EnterGame_ServerReady;
    
                    case S2CMessageType.Communication_TextboxString:
                        var data_Communication_TextboxString = new Communication_TextboxString();
                        data_Communication_TextboxString.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Communication_TextboxString));
                        _OnCommunication_TextboxString?.Invoke(this, data_Communication_TextboxString);
                        return data_Communication_TextboxString;
    
                    case S2CMessageType.Login_WorldInfo:
                        var data_Login_WorldInfo = new Login_WorldInfo();
                        data_Login_WorldInfo.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_Login_WorldInfo));
                        _OnLogin_WorldInfo?.Invoke(this, data_Login_WorldInfo);
                        return data_Login_WorldInfo;
    
                    case S2CMessageType.DDD_DataMessage:
                        var data_DDD_DataMessage = new DDD_DataMessage();
                        data_DDD_DataMessage.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_DDD_DataMessage));
                        _OnDDD_DataMessage?.Invoke(this, data_DDD_DataMessage);
                        return data_DDD_DataMessage;
    
                    case S2CMessageType.DDD_ErrorMessage:
                        var data_DDD_ErrorMessage = new DDD_ErrorMessage();
                        data_DDD_ErrorMessage.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_DDD_ErrorMessage));
                        _OnDDD_ErrorMessage?.Invoke(this, data_DDD_ErrorMessage);
                        return data_DDD_ErrorMessage;
    
                    case S2CMessageType.DDD_BeginDDDMessage:
                        var data_DDD_BeginDDDMessage = new DDD_BeginDDDMessage();
                        data_DDD_BeginDDDMessage.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_DDD_BeginDDDMessage));
                        _OnDDD_BeginDDDMessage?.Invoke(this, data_DDD_BeginDDDMessage);
                        return data_DDD_BeginDDDMessage;
    
                    case S2CMessageType.DDD_InterrogationMessage:
                        var data_DDD_InterrogationMessage = new DDD_InterrogationMessage();
                        data_DDD_InterrogationMessage.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_DDD_InterrogationMessage));
                        _OnDDD_InterrogationMessage?.Invoke(this, data_DDD_InterrogationMessage);
                        return data_DDD_InterrogationMessage;
    
                    case S2CMessageType.DDD_OnEndDDD:
                        var data_DDD_OnEndDDD = new DDD_OnEndDDD();
                        data_DDD_OnEndDDD.Read(reader);
                        _OnMessage?.Invoke(this, new S2CMessageEventArgs(opcode, data_DDD_OnEndDDD));
                        _OnDDD_OnEndDDD?.Invoke(this, data_DDD_OnEndDDD);
                        return data_DDD_OnEndDDD;
    
                default:
                    var rawData = reader.ReadBytes((int)(reader.BaseStream.Length - reader.BaseStream.Position));
                    _OnUnknownMessage?.Invoke(this, new UnknownMessageEventArgs(MessageDirection.ServerToClient, (uint)opcode, rawData));
                    return null;
            }
        }
    }
}
