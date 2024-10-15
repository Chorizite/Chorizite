using System;
using System.IO;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Messages.C2S;
using Chorizite.ACProtocol.Messages.C2S.Actions;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol;

namespace Chorizite.ACProtocol {

    public class C2SMessageHandler { 
        /// <summary>
        /// Fired for every valid parsed Message
        /// </summary> 
        public event EventHandler<C2SMessageEventArgs>? OnMessage;

        /// <summary>
        /// Fired for every valid parsed GameAction
        /// </summary>
        public event EventHandler<GameActionEventArgs>? OnGameAction;

        /// <summary>
        /// Fired when an unknown Message type was encountered
        /// </summary>
        public event EventHandler<UnknownMessageEventArgs>? OnUnknownMessage;

        /// <summary>
        /// Fired on Message type 0xF653 Login_LogOffCharacter. Instructs the client to return to 2D mode - the character list.
        /// </summary>
        public event EventHandler<Login_LogOffCharacter>? OnLogin_LogOffCharacter;
    
        /// <summary>
        /// Fired on Message type 0xF655 Character_CharacterDelete. Mark a character for deletetion.
        /// </summary>
        public event EventHandler<Character_CharacterDelete>? OnCharacter_CharacterDelete;
    
        /// <summary>
        /// Fired on Message type 0xF656 Character_SendCharGenResult. Character creation result
        /// </summary>
        public event EventHandler<Character_SendCharGenResult>? OnCharacter_SendCharGenResult;
    
        /// <summary>
        /// Fired on Message type 0xF657 Login_SendEnterWorld. The character to log in.
        /// </summary>
        public event EventHandler<Login_SendEnterWorld>? OnLogin_SendEnterWorld;
    
        /// <summary>
        /// Fired on Message type 0xF6EA Object_SendForceObjdesc. Asks server for a new object description
        /// </summary>
        public event EventHandler<Object_SendForceObjdesc>? OnObject_SendForceObjdesc;
    
        /// <summary>
        /// Fired on Message type 0xF7C8 Login_SendEnterWorldRequest. The user has clicked 'Enter'. This message does not contain the Id of the character logging on; that comes later.
        /// </summary>
        public event EventHandler<Login_SendEnterWorldRequest>? OnLogin_SendEnterWorldRequest;
    
        /// <summary>
        /// Fired on Message type 0xF7CC Admin_SendAdminGetServerVersion. Sent if player is an PSR, I assume it displays the server version number
        /// </summary>
        public event EventHandler<Admin_SendAdminGetServerVersion>? OnAdmin_SendAdminGetServerVersion;
    
        /// <summary>
        /// Fired on Message type 0xF7CD Social_SendFriendsCommand. Seems to be a legacy friends command, /friends old, for when Jan 2006 event changed the friends list
        /// </summary>
        public event EventHandler<Social_SendFriendsCommand>? OnSocial_SendFriendsCommand;
    
        /// <summary>
        /// Fired on Message type 0xF7D9 Admin_SendAdminRestoreCharacter. Admin command to restore a character
        /// </summary>
        public event EventHandler<Admin_SendAdminRestoreCharacter>? OnAdmin_SendAdminRestoreCharacter;
    
        /// <summary>
        /// Fired on Message type 0xF7DE Communication_TurbineChat. Send or receive a message using Turbine Chat.
        /// </summary>
        public event EventHandler<Communication_TurbineChat>? OnCommunication_TurbineChat;
    
        /// <summary>
        /// Fired on Message type 0xF7E3 DDD_RequestDataMessage. DDD request for data
        /// </summary>
        public event EventHandler<DDD_RequestDataMessage>? OnDDD_RequestDataMessage;
    
        /// <summary>
        /// Fired on Message type 0xF7E6 DDD_InterrogationResponseMessage. TODO
        /// </summary>
        public event EventHandler<DDD_InterrogationResponseMessage>? OnDDD_InterrogationResponseMessage;
    
        /// <summary>
        /// Fired on Message type 0xF7EB DDD_EndDDDMessage. Ends DDD message update
        /// </summary>
        public event EventHandler<DDD_EndDDDMessage>? OnDDD_EndDDDMessage;
    
        /// <summary>
        /// Fired on Message type 0xF7EA DDD_OnEndDDD. Ends DDD update
        /// </summary>
        public event EventHandler<DDD_OnEndDDD>? OnDDD_OnEndDDD;
    
        /// <summary>
        /// Fired on Message type 0xF7B1 Ordered_GameAction. Ordered game action
        /// </summary>
        public event EventHandler<Ordered_GameAction>? OnOrdered_GameAction;
    
        /// <summary>
        /// Fired on GameAction type 0x0005 Character_PlayerOptionChangedEvent. Set a single character option.
        /// </summary>
        public event EventHandler<Character_PlayerOptionChangedEvent>? OnCharacter_PlayerOptionChangedEvent;
    
        /// <summary>
        /// Fired on GameAction type 0x0008 Combat_TargetedMeleeAttack. Starts a melee attack against a target
        /// </summary>
        public event EventHandler<Combat_TargetedMeleeAttack>? OnCombat_TargetedMeleeAttack;
    
        /// <summary>
        /// Fired on GameAction type 0x000A Combat_TargetedMissileAttack. Starts a missle attack against a target
        /// </summary>
        public event EventHandler<Combat_TargetedMissileAttack>? OnCombat_TargetedMissileAttack;
    
        /// <summary>
        /// Fired on GameAction type 0x000F Communication_SetAFKMode. Set AFK mode.
        /// </summary>
        public event EventHandler<Communication_SetAFKMode>? OnCommunication_SetAFKMode;
    
        /// <summary>
        /// Fired on GameAction type 0x0010 Communication_SetAFKMessage. Set AFK message.
        /// </summary>
        public event EventHandler<Communication_SetAFKMessage>? OnCommunication_SetAFKMessage;
    
        /// <summary>
        /// Fired on GameAction type 0x0015 Communication_Talk. Talking
        /// </summary>
        public event EventHandler<Communication_Talk>? OnCommunication_Talk;
    
        /// <summary>
        /// Fired on GameAction type 0x0017 Social_RemoveFriend. Removes a friend
        /// </summary>
        public event EventHandler<Social_RemoveFriend>? OnSocial_RemoveFriend;
    
        /// <summary>
        /// Fired on GameAction type 0x0018 Social_AddFriend. Adds a friend
        /// </summary>
        public event EventHandler<Social_AddFriend>? OnSocial_AddFriend;
    
        /// <summary>
        /// Fired on GameAction type 0x0019 Inventory_PutItemInContainer. Store an item in a container.
        /// </summary>
        public event EventHandler<Inventory_PutItemInContainer>? OnInventory_PutItemInContainer;
    
        /// <summary>
        /// Fired on GameAction type 0x001A Inventory_GetAndWieldItem. Gets and weilds an item.
        /// </summary>
        public event EventHandler<Inventory_GetAndWieldItem>? OnInventory_GetAndWieldItem;
    
        /// <summary>
        /// Fired on GameAction type 0x001B Inventory_DropItem. Drop an item.
        /// </summary>
        public event EventHandler<Inventory_DropItem>? OnInventory_DropItem;
    
        /// <summary>
        /// Fired on GameAction type 0x001D Allegiance_SwearAllegiance. Swear allegiance
        /// </summary>
        public event EventHandler<Allegiance_SwearAllegiance>? OnAllegiance_SwearAllegiance;
    
        /// <summary>
        /// Fired on GameAction type 0x001E Allegiance_BreakAllegiance. Break allegiance
        /// </summary>
        public event EventHandler<Allegiance_BreakAllegiance>? OnAllegiance_BreakAllegiance;
    
        /// <summary>
        /// Fired on GameAction type 0x001F Allegiance_UpdateRequest. Allegiance update request
        /// </summary>
        public event EventHandler<Allegiance_UpdateRequest>? OnAllegiance_UpdateRequest;
    
        /// <summary>
        /// Fired on GameAction type 0x0025 Social_ClearFriends. Clears friend list
        /// </summary>
        public event EventHandler<Social_ClearFriends>? OnSocial_ClearFriends;
    
        /// <summary>
        /// Fired on GameAction type 0x0026 Character_TeleToPKLArena. Teleport to the PKLite Arena
        /// </summary>
        public event EventHandler<Character_TeleToPKLArena>? OnCharacter_TeleToPKLArena;
    
        /// <summary>
        /// Fired on GameAction type 0x0027 Character_TeleToPKArena. Teleport to the PK Arena
        /// </summary>
        public event EventHandler<Character_TeleToPKArena>? OnCharacter_TeleToPKArena;
    
        /// <summary>
        /// Fired on GameAction type 0x002C Social_SetDisplayCharacterTitle. Sets a character's display title
        /// </summary>
        public event EventHandler<Social_SetDisplayCharacterTitle>? OnSocial_SetDisplayCharacterTitle;
    
        /// <summary>
        /// Fired on GameAction type 0x0030 Allegiance_QueryAllegianceName. Query the allegiance name
        /// </summary>
        public event EventHandler<Allegiance_QueryAllegianceName>? OnAllegiance_QueryAllegianceName;
    
        /// <summary>
        /// Fired on GameAction type 0x0031 Allegiance_ClearAllegianceName. Clears the allegiance name
        /// </summary>
        public event EventHandler<Allegiance_ClearAllegianceName>? OnAllegiance_ClearAllegianceName;
    
        /// <summary>
        /// Fired on GameAction type 0x0032 Communication_TalkDirect. Direct message by Id
        /// </summary>
        public event EventHandler<Communication_TalkDirect>? OnCommunication_TalkDirect;
    
        /// <summary>
        /// Fired on GameAction type 0x0033 Allegiance_SetAllegianceName. Sets the allegiance name
        /// </summary>
        public event EventHandler<Allegiance_SetAllegianceName>? OnAllegiance_SetAllegianceName;
    
        /// <summary>
        /// Fired on GameAction type 0x0035 Inventory_UseWithTargetEvent. Attempt to use an item with a target.
        /// </summary>
        public event EventHandler<Inventory_UseWithTargetEvent>? OnInventory_UseWithTargetEvent;
    
        /// <summary>
        /// Fired on GameAction type 0x0036 Inventory_UseEvent. Attempt to use an item.
        /// </summary>
        public event EventHandler<Inventory_UseEvent>? OnInventory_UseEvent;
    
        /// <summary>
        /// Fired on GameAction type 0x003B Allegiance_SetAllegianceOfficer. Sets an allegiance officer
        /// </summary>
        public event EventHandler<Allegiance_SetAllegianceOfficer>? OnAllegiance_SetAllegianceOfficer;
    
        /// <summary>
        /// Fired on GameAction type 0x003C Allegiance_SetAllegianceOfficerTitle. Sets an allegiance officer title for a given level
        /// </summary>
        public event EventHandler<Allegiance_SetAllegianceOfficerTitle>? OnAllegiance_SetAllegianceOfficerTitle;
    
        /// <summary>
        /// Fired on GameAction type 0x003D Allegiance_ListAllegianceOfficerTitles. List the allegiance officer titles
        /// </summary>
        public event EventHandler<Allegiance_ListAllegianceOfficerTitles>? OnAllegiance_ListAllegianceOfficerTitles;
    
        /// <summary>
        /// Fired on GameAction type 0x003E Allegiance_ClearAllegianceOfficerTitles. Clears the allegiance officer titles
        /// </summary>
        public event EventHandler<Allegiance_ClearAllegianceOfficerTitles>? OnAllegiance_ClearAllegianceOfficerTitles;
    
        /// <summary>
        /// Fired on GameAction type 0x003F Allegiance_DoAllegianceLockAction. Perform the allegiance lock action
        /// </summary>
        public event EventHandler<Allegiance_DoAllegianceLockAction>? OnAllegiance_DoAllegianceLockAction;
    
        /// <summary>
        /// Fired on GameAction type 0x0040 Allegiance_SetAllegianceApprovedVassal. Sets a person as an approved vassal
        /// </summary>
        public event EventHandler<Allegiance_SetAllegianceApprovedVassal>? OnAllegiance_SetAllegianceApprovedVassal;
    
        /// <summary>
        /// Fired on GameAction type 0x0041 Allegiance_AllegianceChatGag. Gags a person in allegiance chat
        /// </summary>
        public event EventHandler<Allegiance_AllegianceChatGag>? OnAllegiance_AllegianceChatGag;
    
        /// <summary>
        /// Fired on GameAction type 0x0042 Allegiance_DoAllegianceHouseAction. Perform the allegiance house action
        /// </summary>
        public event EventHandler<Allegiance_DoAllegianceHouseAction>? OnAllegiance_DoAllegianceHouseAction;
    
        /// <summary>
        /// Fired on GameAction type 0x0044 Train_TrainAttribute2nd. Spend XP to raise a vital.
        /// </summary>
        public event EventHandler<Train_TrainAttribute2nd>? OnTrain_TrainAttribute2nd;
    
        /// <summary>
        /// Fired on GameAction type 0x0045 Train_TrainAttribute. Spend XP to raise an attribute.
        /// </summary>
        public event EventHandler<Train_TrainAttribute>? OnTrain_TrainAttribute;
    
        /// <summary>
        /// Fired on GameAction type 0x0046 Train_TrainSkill. Spend XP to raise a skill.
        /// </summary>
        public event EventHandler<Train_TrainSkill>? OnTrain_TrainSkill;
    
        /// <summary>
        /// Fired on GameAction type 0x0047 Train_TrainSkillAdvancementClass. Spend skill credits to train a skill.
        /// </summary>
        public event EventHandler<Train_TrainSkillAdvancementClass>? OnTrain_TrainSkillAdvancementClass;
    
        /// <summary>
        /// Fired on GameAction type 0x0048 Magic_CastUntargetedSpell. Cast a spell with no target.
        /// </summary>
        public event EventHandler<Magic_CastUntargetedSpell>? OnMagic_CastUntargetedSpell;
    
        /// <summary>
        /// Fired on GameAction type 0x004A Magic_CastTargetedSpell. Cast a spell on a target
        /// </summary>
        public event EventHandler<Magic_CastTargetedSpell>? OnMagic_CastTargetedSpell;
    
        /// <summary>
        /// Fired on GameAction type 0x0053 Combat_ChangeCombatMode. Changes the combat mode
        /// </summary>
        public event EventHandler<Combat_ChangeCombatMode>? OnCombat_ChangeCombatMode;
    
        /// <summary>
        /// Fired on GameAction type 0x0054 Inventory_StackableMerge. Merges one stack with another
        /// </summary>
        public event EventHandler<Inventory_StackableMerge>? OnInventory_StackableMerge;
    
        /// <summary>
        /// Fired on GameAction type 0x0055 Inventory_StackableSplitToContainer. Split a stack and place it into a container
        /// </summary>
        public event EventHandler<Inventory_StackableSplitToContainer>? OnInventory_StackableSplitToContainer;
    
        /// <summary>
        /// Fired on GameAction type 0x0056 Inventory_StackableSplitTo3D. Split a stack and place it into the world
        /// </summary>
        public event EventHandler<Inventory_StackableSplitTo3D>? OnInventory_StackableSplitTo3D;
    
        /// <summary>
        /// Fired on GameAction type 0x0058 Communication_ModifyCharacterSquelch. Changes an account squelch
        /// </summary>
        public event EventHandler<Communication_ModifyCharacterSquelch>? OnCommunication_ModifyCharacterSquelch;
    
        /// <summary>
        /// Fired on GameAction type 0x0059 Communication_ModifyAccountSquelch. Changes an account squelch
        /// </summary>
        public event EventHandler<Communication_ModifyAccountSquelch>? OnCommunication_ModifyAccountSquelch;
    
        /// <summary>
        /// Fired on GameAction type 0x005B Communication_ModifyGlobalSquelch. Changes the global filters, /filter -type as well as /chat and /notell
        /// </summary>
        public event EventHandler<Communication_ModifyGlobalSquelch>? OnCommunication_ModifyGlobalSquelch;
    
        /// <summary>
        /// Fired on GameAction type 0x005D Communication_TalkDirectByName. Direct message by name
        /// </summary>
        public event EventHandler<Communication_TalkDirectByName>? OnCommunication_TalkDirectByName;
    
        /// <summary>
        /// Fired on GameAction type 0x005F Vendor_Buy. Buy from a vendor
        /// </summary>
        public event EventHandler<Vendor_Buy>? OnVendor_Buy;
    
        /// <summary>
        /// Fired on GameAction type 0x0060 Vendor_Sell. Sell to a vendor
        /// </summary>
        public event EventHandler<Vendor_Sell>? OnVendor_Sell;
    
        /// <summary>
        /// Fired on GameAction type 0x0063 Character_TeleToLifestone. Teleport to your lifestone. (/lifestone)
        /// </summary>
        public event EventHandler<Character_TeleToLifestone>? OnCharacter_TeleToLifestone;
    
        /// <summary>
        /// Fired on GameAction type 0x00A1 Character_LoginCompleteNotification. The client is ready for the character to materialize after portalling or logging on.
        /// </summary>
        public event EventHandler<Character_LoginCompleteNotification>? OnCharacter_LoginCompleteNotification;
    
        /// <summary>
        /// Fired on GameAction type 0x00A2 Fellowship_Create. Create a fellowship
        /// </summary>
        public event EventHandler<Fellowship_Create>? OnFellowship_Create;
    
        /// <summary>
        /// Fired on GameAction type 0x00A3 Fellowship_Quit. Quit the fellowship
        /// </summary>
        public event EventHandler<Fellowship_Quit>? OnFellowship_Quit;
    
        /// <summary>
        /// Fired on GameAction type 0x00A4 Fellowship_Dismiss. Dismiss a player from the fellowship
        /// </summary>
        public event EventHandler<Fellowship_Dismiss>? OnFellowship_Dismiss;
    
        /// <summary>
        /// Fired on GameAction type 0x00A5 Fellowship_Recruit. Recruit a player to the fellowship
        /// </summary>
        public event EventHandler<Fellowship_Recruit>? OnFellowship_Recruit;
    
        /// <summary>
        /// Fired on GameAction type 0x00A6 Fellowship_UpdateRequest. Update request
        /// </summary>
        public event EventHandler<Fellowship_UpdateRequest>? OnFellowship_UpdateRequest;
    
        /// <summary>
        /// Fired on GameAction type 0x00AA Writing_BookAddPage. Request update to book data (seems to be sent after failed add page)
        /// </summary>
        public event EventHandler<Writing_BookAddPage>? OnWriting_BookAddPage;
    
        /// <summary>
        /// Fired on GameAction type 0x00AB Writing_BookModifyPage. Updates a page in a book
        /// </summary>
        public event EventHandler<Writing_BookModifyPage>? OnWriting_BookModifyPage;
    
        /// <summary>
        /// Fired on GameAction type 0x00AC Writing_BookData. Add a page to a book
        /// </summary>
        public event EventHandler<Writing_BookData>? OnWriting_BookData;
    
        /// <summary>
        /// Fired on GameAction type 0x00AD Writing_BookDeletePage. Removes a page from a book
        /// </summary>
        public event EventHandler<Writing_BookDeletePage>? OnWriting_BookDeletePage;
    
        /// <summary>
        /// Fired on GameAction type 0x00AE Writing_BookPageData. Requests data for a page in a book
        /// </summary>
        public event EventHandler<Writing_BookPageData>? OnWriting_BookPageData;
    
        /// <summary>
        /// Fired on GameAction type 0x00BF Writing_SetInscription. Sets the inscription on an object
        /// </summary>
        public event EventHandler<Writing_SetInscription>? OnWriting_SetInscription;
    
        /// <summary>
        /// Fired on GameAction type 0x00C8 Item_Appraise. Appraise something
        /// </summary>
        public event EventHandler<Item_Appraise>? OnItem_Appraise;
    
        /// <summary>
        /// Fired on GameAction type 0x00CD Inventory_GiveObjectRequest. Give an item to someone.
        /// </summary>
        public event EventHandler<Inventory_GiveObjectRequest>? OnInventory_GiveObjectRequest;
    
        /// <summary>
        /// Fired on GameAction type 0x00D6 Advocate_Teleport. Advocate Teleport
        /// </summary>
        public event EventHandler<Advocate_Teleport>? OnAdvocate_Teleport;
    
        /// <summary>
        /// Fired on GameAction type 0x0140 Character_AbuseLogRequest. Sends an abuse report.
        /// </summary>
        public event EventHandler<Character_AbuseLogRequest>? OnCharacter_AbuseLogRequest;
    
        /// <summary>
        /// Fired on GameAction type 0x0145 Communication_AddToChannel. Joins a chat channel
        /// </summary>
        public event EventHandler<Communication_AddToChannel>? OnCommunication_AddToChannel;
    
        /// <summary>
        /// Fired on GameAction type 0x0146 Communication_RemoveFromChannel. Leaves a chat channel
        /// </summary>
        public event EventHandler<Communication_RemoveFromChannel>? OnCommunication_RemoveFromChannel;
    
        /// <summary>
        /// Fired on GameAction type 0x0147 Communication_ChannelBroadcast. Sends a message to a chat channel
        /// </summary>
        public event EventHandler<Communication_ChannelBroadcast>? OnCommunication_ChannelBroadcast;
    
        /// <summary>
        /// Fired on GameAction type 0x0148 Communication_ChannelList. 
        /// </summary>
        public event EventHandler<Communication_ChannelList>? OnCommunication_ChannelList;
    
        /// <summary>
        /// Fired on GameAction type 0x0149 Communication_ChannelIndex. Requests a channel index
        /// </summary>
        public event EventHandler<Communication_ChannelIndex>? OnCommunication_ChannelIndex;
    
        /// <summary>
        /// Fired on GameAction type 0x0195 Inventory_NoLongerViewingContents. Stop viewing the contents of a container
        /// </summary>
        public event EventHandler<Inventory_NoLongerViewingContents>? OnInventory_NoLongerViewingContents;
    
        /// <summary>
        /// Fired on GameAction type 0x019B Inventory_StackableSplitToWield. Splits an item to a wield location.
        /// </summary>
        public event EventHandler<Inventory_StackableSplitToWield>? OnInventory_StackableSplitToWield;
    
        /// <summary>
        /// Fired on GameAction type 0x019C Character_AddShortCut. Add an item to the shortcut bar.
        /// </summary>
        public event EventHandler<Character_AddShortCut>? OnCharacter_AddShortCut;
    
        /// <summary>
        /// Fired on GameAction type 0x019D Character_RemoveShortCut. Remove an item from the shortcut bar.
        /// </summary>
        public event EventHandler<Character_RemoveShortCut>? OnCharacter_RemoveShortCut;
    
        /// <summary>
        /// Fired on GameAction type 0x01A1 Character_CharacterOptionsEvent. Set multiple character options.
        /// </summary>
        public event EventHandler<Character_CharacterOptionsEvent>? OnCharacter_CharacterOptionsEvent;
    
        /// <summary>
        /// Fired on GameAction type 0x01A8 Magic_RemoveSpell. Removes a spell from the spell book
        /// </summary>
        public event EventHandler<Magic_RemoveSpell>? OnMagic_RemoveSpell;
    
        /// <summary>
        /// Fired on GameAction type 0x01B7 Combat_CancelAttack. Cancels an attack
        /// </summary>
        public event EventHandler<Combat_CancelAttack>? OnCombat_CancelAttack;
    
        /// <summary>
        /// Fired on GameAction type 0x01BF Combat_QueryHealth. Query's a creatures health
        /// </summary>
        public event EventHandler<Combat_QueryHealth>? OnCombat_QueryHealth;
    
        /// <summary>
        /// Fired on GameAction type 0x01C2 Character_QueryAge. Query a character's age
        /// </summary>
        public event EventHandler<Character_QueryAge>? OnCharacter_QueryAge;
    
        /// <summary>
        /// Fired on GameAction type 0x01C4 Character_QueryBirth. Query a character's birth day
        /// </summary>
        public event EventHandler<Character_QueryBirth>? OnCharacter_QueryBirth;
    
        /// <summary>
        /// Fired on GameAction type 0x01DF Communication_Emote. Emote message
        /// </summary>
        public event EventHandler<Communication_Emote>? OnCommunication_Emote;
    
        /// <summary>
        /// Fired on GameAction type 0x01E1 Communication_SoulEmote. Soul emote message
        /// </summary>
        public event EventHandler<Communication_SoulEmote>? OnCommunication_SoulEmote;
    
        /// <summary>
        /// Fired on GameAction type 0x01E3 Character_AddSpellFavorite. Add a spell to a spell bar.
        /// </summary>
        public event EventHandler<Character_AddSpellFavorite>? OnCharacter_AddSpellFavorite;
    
        /// <summary>
        /// Fired on GameAction type 0x01E4 Character_RemoveSpellFavorite. Remove a spell from a spell bar.
        /// </summary>
        public event EventHandler<Character_RemoveSpellFavorite>? OnCharacter_RemoveSpellFavorite;
    
        /// <summary>
        /// Fired on GameAction type 0x01E9 Character_RequestPing. Request a ping
        /// </summary>
        public event EventHandler<Character_RequestPing>? OnCharacter_RequestPing;
    
        /// <summary>
        /// Fired on GameAction type 0x01F6 Trade_OpenTradeNegotiations. Starts trading with another player.
        /// </summary>
        public event EventHandler<Trade_OpenTradeNegotiations>? OnTrade_OpenTradeNegotiations;
    
        /// <summary>
        /// Fired on GameAction type 0x01F7 Trade_CloseTradeNegotiations. Ends trading, when trade window is closed?
        /// </summary>
        public event EventHandler<Trade_CloseTradeNegotiations>? OnTrade_CloseTradeNegotiations;
    
        /// <summary>
        /// Fired on GameAction type 0x01F8 Trade_AddToTrade. Adds an object to the trade.
        /// </summary>
        public event EventHandler<Trade_AddToTrade>? OnTrade_AddToTrade;
    
        /// <summary>
        /// Fired on GameAction type 0x01FA Trade_AcceptTrade. Accepts a trade.
        /// </summary>
        public event EventHandler<Trade_AcceptTrade>? OnTrade_AcceptTrade;
    
        /// <summary>
        /// Fired on GameAction type 0x01FB Trade_DeclineTrade. Declines a trade, when cancel is clicked?
        /// </summary>
        public event EventHandler<Trade_DeclineTrade>? OnTrade_DeclineTrade;
    
        /// <summary>
        /// Fired on GameAction type 0x0204 Trade_ResetTrade. Resets the trade, when clear all is clicked?
        /// </summary>
        public event EventHandler<Trade_ResetTrade>? OnTrade_ResetTrade;
    
        /// <summary>
        /// Fired on GameAction type 0x0216 Character_ClearPlayerConsentList. Clears the player's corpse looting consent list, /consent clear
        /// </summary>
        public event EventHandler<Character_ClearPlayerConsentList>? OnCharacter_ClearPlayerConsentList;
    
        /// <summary>
        /// Fired on GameAction type 0x0217 Character_DisplayPlayerConsentList. Display the player's corpse looting consent list, /consent who 
        /// </summary>
        public event EventHandler<Character_DisplayPlayerConsentList>? OnCharacter_DisplayPlayerConsentList;
    
        /// <summary>
        /// Fired on GameAction type 0x0218 Character_RemoveFromPlayerConsentList. Remove your corpse looting permission for the given player, /consent remove 
        /// </summary>
        public event EventHandler<Character_RemoveFromPlayerConsentList>? OnCharacter_RemoveFromPlayerConsentList;
    
        /// <summary>
        /// Fired on GameAction type 0x0219 Character_AddPlayerPermission. Grants a player corpse looting permission, /permit add
        /// </summary>
        public event EventHandler<Character_AddPlayerPermission>? OnCharacter_AddPlayerPermission;
    
        /// <summary>
        /// Fired on GameAction type 0x021C House_BuyHouse. Buy a house
        /// </summary>
        public event EventHandler<House_BuyHouse>? OnHouse_BuyHouse;
    
        /// <summary>
        /// Fired on GameAction type 0x021E House_QueryHouse. Query your house info, during signin
        /// </summary>
        public event EventHandler<House_QueryHouse>? OnHouse_QueryHouse;
    
        /// <summary>
        /// Fired on GameAction type 0x021F House_AbandonHouse. Abandons your house
        /// </summary>
        public event EventHandler<House_AbandonHouse>? OnHouse_AbandonHouse;
    
        /// <summary>
        /// Fired on GameAction type 0x0220 Character_RemovePlayerPermission. Revokes a player's corpse looting permission, /permit remove
        /// </summary>
        public event EventHandler<Character_RemovePlayerPermission>? OnCharacter_RemovePlayerPermission;
    
        /// <summary>
        /// Fired on GameAction type 0x0221 House_RentHouse. Pay rent for a house
        /// </summary>
        public event EventHandler<House_RentHouse>? OnHouse_RentHouse;
    
        /// <summary>
        /// Fired on GameAction type 0x0224 Character_SetDesiredComponentLevel. Sets a new fill complevel for a component
        /// </summary>
        public event EventHandler<Character_SetDesiredComponentLevel>? OnCharacter_SetDesiredComponentLevel;
    
        /// <summary>
        /// Fired on GameAction type 0x0245 House_AddPermanentGuest. Adds a guest to your house guest list
        /// </summary>
        public event EventHandler<House_AddPermanentGuest>? OnHouse_AddPermanentGuest;
    
        /// <summary>
        /// Fired on GameAction type 0x0246 House_RemovePermanentGuest. Removes a specific player from your house guest list, /house guest remove
        /// </summary>
        public event EventHandler<House_RemovePermanentGuest>? OnHouse_RemovePermanentGuest;
    
        /// <summary>
        /// Fired on GameAction type 0x0247 House_SetOpenHouseStatus. Sets your house open status
        /// </summary>
        public event EventHandler<House_SetOpenHouseStatus>? OnHouse_SetOpenHouseStatus;
    
        /// <summary>
        /// Fired on GameAction type 0x0249 House_ChangeStoragePermission. Changes a specific players storage permission, /house storage add/remove
        /// </summary>
        public event EventHandler<House_ChangeStoragePermission>? OnHouse_ChangeStoragePermission;
    
        /// <summary>
        /// Fired on GameAction type 0x024A House_BootSpecificHouseGuest. Boots a specific player from your house /house boot
        /// </summary>
        public event EventHandler<House_BootSpecificHouseGuest>? OnHouse_BootSpecificHouseGuest;
    
        /// <summary>
        /// Fired on GameAction type 0x024C House_RemoveAllStoragePermission. Removes all storage permissions, /house storage remove_all
        /// </summary>
        public event EventHandler<House_RemoveAllStoragePermission>? OnHouse_RemoveAllStoragePermission;
    
        /// <summary>
        /// Fired on GameAction type 0x024D House_RequestFullGuestList. Requests your full guest list, /house guest list
        /// </summary>
        public event EventHandler<House_RequestFullGuestList>? OnHouse_RequestFullGuestList;
    
        /// <summary>
        /// Fired on GameAction type 0x0254 Allegiance_SetMotd. Sets the allegiance message of the day, /allegiance motd set
        /// </summary>
        public event EventHandler<Allegiance_SetMotd>? OnAllegiance_SetMotd;
    
        /// <summary>
        /// Fired on GameAction type 0x0255 Allegiance_QueryMotd. Query the motd, /allegiance motd
        /// </summary>
        public event EventHandler<Allegiance_QueryMotd>? OnAllegiance_QueryMotd;
    
        /// <summary>
        /// Fired on GameAction type 0x0256 Allegiance_ClearMotd. Clear the motd, /allegiance motd clear
        /// </summary>
        public event EventHandler<Allegiance_ClearMotd>? OnAllegiance_ClearMotd;
    
        /// <summary>
        /// Fired on GameAction type 0x0258 House_QueryLord. Gets SlumLord info, sent after getting a failed house transaction
        /// </summary>
        public event EventHandler<House_QueryLord>? OnHouse_QueryLord;
    
        /// <summary>
        /// Fired on GameAction type 0x025C House_AddAllStoragePermission. Adds all to your storage permissions, /house storage add -all
        /// </summary>
        public event EventHandler<House_AddAllStoragePermission>? OnHouse_AddAllStoragePermission;
    
        /// <summary>
        /// Fired on GameAction type 0x025E House_RemoveAllPermanentGuests. Removes all guests, /house guest remove_all
        /// </summary>
        public event EventHandler<House_RemoveAllPermanentGuests>? OnHouse_RemoveAllPermanentGuests;
    
        /// <summary>
        /// Fired on GameAction type 0x025F House_BootEveryone. Boot everyone from your house, /house boot -all
        /// </summary>
        public event EventHandler<House_BootEveryone>? OnHouse_BootEveryone;
    
        /// <summary>
        /// Fired on GameAction type 0x0262 House_TeleToHouse. Teleports you to your house, /house recall
        /// </summary>
        public event EventHandler<House_TeleToHouse>? OnHouse_TeleToHouse;
    
        /// <summary>
        /// Fired on GameAction type 0x0263 Item_QueryItemMana. Queries an item's mana
        /// </summary>
        public event EventHandler<Item_QueryItemMana>? OnItem_QueryItemMana;
    
        /// <summary>
        /// Fired on GameAction type 0x0266 House_SetHooksVisibility. Modify whether house hooks are visibile or not, /house hooks on/off
        /// </summary>
        public event EventHandler<House_SetHooksVisibility>? OnHouse_SetHooksVisibility;
    
        /// <summary>
        /// Fired on GameAction type 0x0267 House_ModifyAllegianceGuestPermission. Modify whether allegiance members are guests, /house guest add_allegiance/remove_allegiance
        /// </summary>
        public event EventHandler<House_ModifyAllegianceGuestPermission>? OnHouse_ModifyAllegianceGuestPermission;
    
        /// <summary>
        /// Fired on GameAction type 0x0268 House_ModifyAllegianceStoragePermission. Modify whether allegiance members can access storage, /house storage add_allegiance/remove_allegiance
        /// </summary>
        public event EventHandler<House_ModifyAllegianceStoragePermission>? OnHouse_ModifyAllegianceStoragePermission;
    
        /// <summary>
        /// Fired on GameAction type 0x0269 Game_Join. Joins a chess game
        /// </summary>
        public event EventHandler<Game_Join>? OnGame_Join;
    
        /// <summary>
        /// Fired on GameAction type 0x026A Game_Quit. Quits a chess game
        /// </summary>
        public event EventHandler<Game_Quit>? OnGame_Quit;
    
        /// <summary>
        /// Fired on GameAction type 0x026B Game_Move. Makes a chess move
        /// </summary>
        public event EventHandler<Game_Move>? OnGame_Move;
    
        /// <summary>
        /// Fired on GameAction type 0x026D Game_MovePass. Skip a move?
        /// </summary>
        public event EventHandler<Game_MovePass>? OnGame_MovePass;
    
        /// <summary>
        /// Fired on GameAction type 0x026E Game_Stalemate. Offer or confirm stalemate
        /// </summary>
        public event EventHandler<Game_Stalemate>? OnGame_Stalemate;
    
        /// <summary>
        /// Fired on GameAction type 0x0270 House_ListAvailableHouses. Lists available house /house available
        /// </summary>
        public event EventHandler<House_ListAvailableHouses>? OnHouse_ListAvailableHouses;
    
        /// <summary>
        /// Fired on GameAction type 0x0275 Character_ConfirmationResponse. Confirms a dialog
        /// </summary>
        public event EventHandler<Character_ConfirmationResponse>? OnCharacter_ConfirmationResponse;
    
        /// <summary>
        /// Fired on GameAction type 0x0277 Allegiance_BreakAllegianceBoot. Boots a player from the allegiance, optionally all characters on their account
        /// </summary>
        public event EventHandler<Allegiance_BreakAllegianceBoot>? OnAllegiance_BreakAllegianceBoot;
    
        /// <summary>
        /// Fired on GameAction type 0x0278 House_TeleToMansion. Teleports player to their allegiance housing, /house mansion_recall
        /// </summary>
        public event EventHandler<House_TeleToMansion>? OnHouse_TeleToMansion;
    
        /// <summary>
        /// Fired on GameAction type 0x0279 Character_Suicide. Player is commiting suicide
        /// </summary>
        public event EventHandler<Character_Suicide>? OnCharacter_Suicide;
    
        /// <summary>
        /// Fired on GameAction type 0x027B Allegiance_AllegianceInfoRequest. Request allegiance info for a player
        /// </summary>
        public event EventHandler<Allegiance_AllegianceInfoRequest>? OnAllegiance_AllegianceInfoRequest;
    
        /// <summary>
        /// Fired on GameAction type 0x027D Inventory_CreateTinkeringTool. Salvages items
        /// </summary>
        public event EventHandler<Inventory_CreateTinkeringTool>? OnInventory_CreateTinkeringTool;
    
        /// <summary>
        /// Fired on GameAction type 0x0286 Character_SpellbookFilterEvent. Changes the spell book filter
        /// </summary>
        public event EventHandler<Character_SpellbookFilterEvent>? OnCharacter_SpellbookFilterEvent;
    
        /// <summary>
        /// Fired on GameAction type 0x028D Character_TeleToMarketplace. Teleport to the marketplace
        /// </summary>
        public event EventHandler<Character_TeleToMarketplace>? OnCharacter_TeleToMarketplace;
    
        /// <summary>
        /// Fired on GameAction type 0x028F Character_EnterPKLite. Enter PKLite mode
        /// </summary>
        public event EventHandler<Character_EnterPKLite>? OnCharacter_EnterPKLite;
    
        /// <summary>
        /// Fired on GameAction type 0x0290 Fellowship_AssignNewLeader. Fellowship Assign a new leader
        /// </summary>
        public event EventHandler<Fellowship_AssignNewLeader>? OnFellowship_AssignNewLeader;
    
        /// <summary>
        /// Fired on GameAction type 0x0291 Fellowship_ChangeFellowOpeness. Fellowship Change openness
        /// </summary>
        public event EventHandler<Fellowship_ChangeFellowOpeness>? OnFellowship_ChangeFellowOpeness;
    
        /// <summary>
        /// Fired on GameAction type 0x02A0 Allegiance_AllegianceChatBoot. Boots a player from the allegiance chat
        /// </summary>
        public event EventHandler<Allegiance_AllegianceChatBoot>? OnAllegiance_AllegianceChatBoot;
    
        /// <summary>
        /// Fired on GameAction type 0x02A1 Allegiance_AddAllegianceBan. Bans a player from the allegiance
        /// </summary>
        public event EventHandler<Allegiance_AddAllegianceBan>? OnAllegiance_AddAllegianceBan;
    
        /// <summary>
        /// Fired on GameAction type 0x02A2 Allegiance_RemoveAllegianceBan. Removes a player ban from the allegiance
        /// </summary>
        public event EventHandler<Allegiance_RemoveAllegianceBan>? OnAllegiance_RemoveAllegianceBan;
    
        /// <summary>
        /// Fired on GameAction type 0x02A3 Allegiance_ListAllegianceBans. Display allegiance bans
        /// </summary>
        public event EventHandler<Allegiance_ListAllegianceBans>? OnAllegiance_ListAllegianceBans;
    
        /// <summary>
        /// Fired on GameAction type 0x02A5 Allegiance_RemoveAllegianceOfficer. Removes an allegiance officer
        /// </summary>
        public event EventHandler<Allegiance_RemoveAllegianceOfficer>? OnAllegiance_RemoveAllegianceOfficer;
    
        /// <summary>
        /// Fired on GameAction type 0x02A6 Allegiance_ListAllegianceOfficers. List allegiance officers
        /// </summary>
        public event EventHandler<Allegiance_ListAllegianceOfficers>? OnAllegiance_ListAllegianceOfficers;
    
        /// <summary>
        /// Fired on GameAction type 0x02A7 Allegiance_ClearAllegianceOfficers. Clear allegiance officers
        /// </summary>
        public event EventHandler<Allegiance_ClearAllegianceOfficers>? OnAllegiance_ClearAllegianceOfficers;
    
        /// <summary>
        /// Fired on GameAction type 0x02AB Allegiance_RecallAllegianceHometown. Recalls to players allegiance hometown
        /// </summary>
        public event EventHandler<Allegiance_RecallAllegianceHometown>? OnAllegiance_RecallAllegianceHometown;
    
        /// <summary>
        /// Fired on GameAction type 0x02AF Admin_QueryPluginListResponse. Admin Returns a plugin list response
        /// </summary>
        public event EventHandler<Admin_QueryPluginListResponse>? OnAdmin_QueryPluginListResponse;
    
        /// <summary>
        /// Fired on GameAction type 0x02B2 Admin_QueryPluginResponse. Admin Returns plugin info
        /// </summary>
        public event EventHandler<Admin_QueryPluginResponse>? OnAdmin_QueryPluginResponse;
    
        /// <summary>
        /// Fired on GameAction type 0x0311 Character_FinishBarber. Completes the barber interaction
        /// </summary>
        public event EventHandler<Character_FinishBarber>? OnCharacter_FinishBarber;
    
        /// <summary>
        /// Fired on GameAction type 0x0316 Social_AbandonContract. Abandons a contract
        /// </summary>
        public event EventHandler<Social_AbandonContract>? OnSocial_AbandonContract;
    
        /// <summary>
        /// Fired on GameAction type 0xF61B Movement_Jump. Performs a jump
        /// </summary>
        public event EventHandler<Movement_Jump>? OnMovement_Jump;
    
        /// <summary>
        /// Fired on GameAction type 0xF61C Movement_MoveToState. Move to state data
        /// </summary>
        public event EventHandler<Movement_MoveToState>? OnMovement_MoveToState;
    
        /// <summary>
        /// Fired on GameAction type 0xF61E Movement_DoMovementCommand. Performs a movement based on input
        /// </summary>
        public event EventHandler<Movement_DoMovementCommand>? OnMovement_DoMovementCommand;
    
        /// <summary>
        /// Fired on GameAction type 0xF661 Movement_StopMovementCommand. Stops a movement
        /// </summary>
        public event EventHandler<Movement_StopMovementCommand>? OnMovement_StopMovementCommand;
    
        /// <summary>
        /// Fired on GameAction type 0xF752 Movement_AutonomyLevel. Sets an autonomy level
        /// </summary>
        public event EventHandler<Movement_AutonomyLevel>? OnMovement_AutonomyLevel;
    
        /// <summary>
        /// Fired on GameAction type 0xF753 Movement_AutonomousPosition. Sends an autonomous position
        /// </summary>
        public event EventHandler<Movement_AutonomousPosition>? OnMovement_AutonomousPosition;
    
        /// <summary>
        /// Fired on GameAction type 0xF7C9 Movement_Jump_NonAutonomous. Performs a non autonomous jump
        /// </summary>
        public event EventHandler<Movement_Jump_NonAutonomous>? OnMovement_Jump_NonAutonomous;
    
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
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_PlayerOptionChangedEvent));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_PlayerOptionChangedEvent);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_PlayerOptionChangedEvent));
                                OnCharacter_PlayerOptionChangedEvent?.Invoke(this, data_Character_PlayerOptionChangedEvent);
                                return data_Character_PlayerOptionChangedEvent;
                            case GameActionType.Combat_TargetedMeleeAttack:
                                var data_Combat_TargetedMeleeAttack = new Combat_TargetedMeleeAttack();
                                data_Combat_TargetedMeleeAttack.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Combat_TargetedMeleeAttack));
                                OnOrdered_GameAction?.Invoke(this,  data_Combat_TargetedMeleeAttack);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Combat_TargetedMeleeAttack));
                                OnCombat_TargetedMeleeAttack?.Invoke(this, data_Combat_TargetedMeleeAttack);
                                return data_Combat_TargetedMeleeAttack;
                            case GameActionType.Combat_TargetedMissileAttack:
                                var data_Combat_TargetedMissileAttack = new Combat_TargetedMissileAttack();
                                data_Combat_TargetedMissileAttack.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Combat_TargetedMissileAttack));
                                OnOrdered_GameAction?.Invoke(this,  data_Combat_TargetedMissileAttack);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Combat_TargetedMissileAttack));
                                OnCombat_TargetedMissileAttack?.Invoke(this, data_Combat_TargetedMissileAttack);
                                return data_Combat_TargetedMissileAttack;
                            case GameActionType.Communication_SetAFKMode:
                                var data_Communication_SetAFKMode = new Communication_SetAFKMode();
                                data_Communication_SetAFKMode.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_SetAFKMode));
                                OnOrdered_GameAction?.Invoke(this,  data_Communication_SetAFKMode);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_SetAFKMode));
                                OnCommunication_SetAFKMode?.Invoke(this, data_Communication_SetAFKMode);
                                return data_Communication_SetAFKMode;
                            case GameActionType.Communication_SetAFKMessage:
                                var data_Communication_SetAFKMessage = new Communication_SetAFKMessage();
                                data_Communication_SetAFKMessage.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_SetAFKMessage));
                                OnOrdered_GameAction?.Invoke(this,  data_Communication_SetAFKMessage);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_SetAFKMessage));
                                OnCommunication_SetAFKMessage?.Invoke(this, data_Communication_SetAFKMessage);
                                return data_Communication_SetAFKMessage;
                            case GameActionType.Communication_Talk:
                                var data_Communication_Talk = new Communication_Talk();
                                data_Communication_Talk.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_Talk));
                                OnOrdered_GameAction?.Invoke(this,  data_Communication_Talk);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_Talk));
                                OnCommunication_Talk?.Invoke(this, data_Communication_Talk);
                                return data_Communication_Talk;
                            case GameActionType.Social_RemoveFriend:
                                var data_Social_RemoveFriend = new Social_RemoveFriend();
                                data_Social_RemoveFriend.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Social_RemoveFriend));
                                OnOrdered_GameAction?.Invoke(this,  data_Social_RemoveFriend);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Social_RemoveFriend));
                                OnSocial_RemoveFriend?.Invoke(this, data_Social_RemoveFriend);
                                return data_Social_RemoveFriend;
                            case GameActionType.Social_AddFriend:
                                var data_Social_AddFriend = new Social_AddFriend();
                                data_Social_AddFriend.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Social_AddFriend));
                                OnOrdered_GameAction?.Invoke(this,  data_Social_AddFriend);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Social_AddFriend));
                                OnSocial_AddFriend?.Invoke(this, data_Social_AddFriend);
                                return data_Social_AddFriend;
                            case GameActionType.Inventory_PutItemInContainer:
                                var data_Inventory_PutItemInContainer = new Inventory_PutItemInContainer();
                                data_Inventory_PutItemInContainer.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Inventory_PutItemInContainer));
                                OnOrdered_GameAction?.Invoke(this,  data_Inventory_PutItemInContainer);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Inventory_PutItemInContainer));
                                OnInventory_PutItemInContainer?.Invoke(this, data_Inventory_PutItemInContainer);
                                return data_Inventory_PutItemInContainer;
                            case GameActionType.Inventory_GetAndWieldItem:
                                var data_Inventory_GetAndWieldItem = new Inventory_GetAndWieldItem();
                                data_Inventory_GetAndWieldItem.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Inventory_GetAndWieldItem));
                                OnOrdered_GameAction?.Invoke(this,  data_Inventory_GetAndWieldItem);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Inventory_GetAndWieldItem));
                                OnInventory_GetAndWieldItem?.Invoke(this, data_Inventory_GetAndWieldItem);
                                return data_Inventory_GetAndWieldItem;
                            case GameActionType.Inventory_DropItem:
                                var data_Inventory_DropItem = new Inventory_DropItem();
                                data_Inventory_DropItem.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Inventory_DropItem));
                                OnOrdered_GameAction?.Invoke(this,  data_Inventory_DropItem);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Inventory_DropItem));
                                OnInventory_DropItem?.Invoke(this, data_Inventory_DropItem);
                                return data_Inventory_DropItem;
                            case GameActionType.Allegiance_SwearAllegiance:
                                var data_Allegiance_SwearAllegiance = new Allegiance_SwearAllegiance();
                                data_Allegiance_SwearAllegiance.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_SwearAllegiance));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_SwearAllegiance);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_SwearAllegiance));
                                OnAllegiance_SwearAllegiance?.Invoke(this, data_Allegiance_SwearAllegiance);
                                return data_Allegiance_SwearAllegiance;
                            case GameActionType.Allegiance_BreakAllegiance:
                                var data_Allegiance_BreakAllegiance = new Allegiance_BreakAllegiance();
                                data_Allegiance_BreakAllegiance.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_BreakAllegiance));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_BreakAllegiance);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_BreakAllegiance));
                                OnAllegiance_BreakAllegiance?.Invoke(this, data_Allegiance_BreakAllegiance);
                                return data_Allegiance_BreakAllegiance;
                            case GameActionType.Allegiance_UpdateRequest:
                                var data_Allegiance_UpdateRequest = new Allegiance_UpdateRequest();
                                data_Allegiance_UpdateRequest.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_UpdateRequest));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_UpdateRequest);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_UpdateRequest));
                                OnAllegiance_UpdateRequest?.Invoke(this, data_Allegiance_UpdateRequest);
                                return data_Allegiance_UpdateRequest;
                            case GameActionType.Social_ClearFriends:
                                var data_Social_ClearFriends = new Social_ClearFriends();
                                data_Social_ClearFriends.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Social_ClearFriends));
                                OnOrdered_GameAction?.Invoke(this,  data_Social_ClearFriends);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Social_ClearFriends));
                                OnSocial_ClearFriends?.Invoke(this, data_Social_ClearFriends);
                                return data_Social_ClearFriends;
                            case GameActionType.Character_TeleToPKLArena:
                                var data_Character_TeleToPKLArena = new Character_TeleToPKLArena();
                                data_Character_TeleToPKLArena.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_TeleToPKLArena));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_TeleToPKLArena);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_TeleToPKLArena));
                                OnCharacter_TeleToPKLArena?.Invoke(this, data_Character_TeleToPKLArena);
                                return data_Character_TeleToPKLArena;
                            case GameActionType.Character_TeleToPKArena:
                                var data_Character_TeleToPKArena = new Character_TeleToPKArena();
                                data_Character_TeleToPKArena.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_TeleToPKArena));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_TeleToPKArena);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_TeleToPKArena));
                                OnCharacter_TeleToPKArena?.Invoke(this, data_Character_TeleToPKArena);
                                return data_Character_TeleToPKArena;
                            case GameActionType.Social_SetDisplayCharacterTitle:
                                var data_Social_SetDisplayCharacterTitle = new Social_SetDisplayCharacterTitle();
                                data_Social_SetDisplayCharacterTitle.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Social_SetDisplayCharacterTitle));
                                OnOrdered_GameAction?.Invoke(this,  data_Social_SetDisplayCharacterTitle);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Social_SetDisplayCharacterTitle));
                                OnSocial_SetDisplayCharacterTitle?.Invoke(this, data_Social_SetDisplayCharacterTitle);
                                return data_Social_SetDisplayCharacterTitle;
                            case GameActionType.Allegiance_QueryAllegianceName:
                                var data_Allegiance_QueryAllegianceName = new Allegiance_QueryAllegianceName();
                                data_Allegiance_QueryAllegianceName.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_QueryAllegianceName));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_QueryAllegianceName);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_QueryAllegianceName));
                                OnAllegiance_QueryAllegianceName?.Invoke(this, data_Allegiance_QueryAllegianceName);
                                return data_Allegiance_QueryAllegianceName;
                            case GameActionType.Allegiance_ClearAllegianceName:
                                var data_Allegiance_ClearAllegianceName = new Allegiance_ClearAllegianceName();
                                data_Allegiance_ClearAllegianceName.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_ClearAllegianceName));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_ClearAllegianceName);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_ClearAllegianceName));
                                OnAllegiance_ClearAllegianceName?.Invoke(this, data_Allegiance_ClearAllegianceName);
                                return data_Allegiance_ClearAllegianceName;
                            case GameActionType.Communication_TalkDirect:
                                var data_Communication_TalkDirect = new Communication_TalkDirect();
                                data_Communication_TalkDirect.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_TalkDirect));
                                OnOrdered_GameAction?.Invoke(this,  data_Communication_TalkDirect);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_TalkDirect));
                                OnCommunication_TalkDirect?.Invoke(this, data_Communication_TalkDirect);
                                return data_Communication_TalkDirect;
                            case GameActionType.Allegiance_SetAllegianceName:
                                var data_Allegiance_SetAllegianceName = new Allegiance_SetAllegianceName();
                                data_Allegiance_SetAllegianceName.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_SetAllegianceName));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_SetAllegianceName);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_SetAllegianceName));
                                OnAllegiance_SetAllegianceName?.Invoke(this, data_Allegiance_SetAllegianceName);
                                return data_Allegiance_SetAllegianceName;
                            case GameActionType.Inventory_UseWithTargetEvent:
                                var data_Inventory_UseWithTargetEvent = new Inventory_UseWithTargetEvent();
                                data_Inventory_UseWithTargetEvent.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Inventory_UseWithTargetEvent));
                                OnOrdered_GameAction?.Invoke(this,  data_Inventory_UseWithTargetEvent);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Inventory_UseWithTargetEvent));
                                OnInventory_UseWithTargetEvent?.Invoke(this, data_Inventory_UseWithTargetEvent);
                                return data_Inventory_UseWithTargetEvent;
                            case GameActionType.Inventory_UseEvent:
                                var data_Inventory_UseEvent = new Inventory_UseEvent();
                                data_Inventory_UseEvent.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Inventory_UseEvent));
                                OnOrdered_GameAction?.Invoke(this,  data_Inventory_UseEvent);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Inventory_UseEvent));
                                OnInventory_UseEvent?.Invoke(this, data_Inventory_UseEvent);
                                return data_Inventory_UseEvent;
                            case GameActionType.Allegiance_SetAllegianceOfficer:
                                var data_Allegiance_SetAllegianceOfficer = new Allegiance_SetAllegianceOfficer();
                                data_Allegiance_SetAllegianceOfficer.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_SetAllegianceOfficer));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_SetAllegianceOfficer);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_SetAllegianceOfficer));
                                OnAllegiance_SetAllegianceOfficer?.Invoke(this, data_Allegiance_SetAllegianceOfficer);
                                return data_Allegiance_SetAllegianceOfficer;
                            case GameActionType.Allegiance_SetAllegianceOfficerTitle:
                                var data_Allegiance_SetAllegianceOfficerTitle = new Allegiance_SetAllegianceOfficerTitle();
                                data_Allegiance_SetAllegianceOfficerTitle.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_SetAllegianceOfficerTitle));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_SetAllegianceOfficerTitle);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_SetAllegianceOfficerTitle));
                                OnAllegiance_SetAllegianceOfficerTitle?.Invoke(this, data_Allegiance_SetAllegianceOfficerTitle);
                                return data_Allegiance_SetAllegianceOfficerTitle;
                            case GameActionType.Allegiance_ListAllegianceOfficerTitles:
                                var data_Allegiance_ListAllegianceOfficerTitles = new Allegiance_ListAllegianceOfficerTitles();
                                data_Allegiance_ListAllegianceOfficerTitles.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_ListAllegianceOfficerTitles));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_ListAllegianceOfficerTitles);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_ListAllegianceOfficerTitles));
                                OnAllegiance_ListAllegianceOfficerTitles?.Invoke(this, data_Allegiance_ListAllegianceOfficerTitles);
                                return data_Allegiance_ListAllegianceOfficerTitles;
                            case GameActionType.Allegiance_ClearAllegianceOfficerTitles:
                                var data_Allegiance_ClearAllegianceOfficerTitles = new Allegiance_ClearAllegianceOfficerTitles();
                                data_Allegiance_ClearAllegianceOfficerTitles.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_ClearAllegianceOfficerTitles));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_ClearAllegianceOfficerTitles);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_ClearAllegianceOfficerTitles));
                                OnAllegiance_ClearAllegianceOfficerTitles?.Invoke(this, data_Allegiance_ClearAllegianceOfficerTitles);
                                return data_Allegiance_ClearAllegianceOfficerTitles;
                            case GameActionType.Allegiance_DoAllegianceLockAction:
                                var data_Allegiance_DoAllegianceLockAction = new Allegiance_DoAllegianceLockAction();
                                data_Allegiance_DoAllegianceLockAction.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_DoAllegianceLockAction));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_DoAllegianceLockAction);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_DoAllegianceLockAction));
                                OnAllegiance_DoAllegianceLockAction?.Invoke(this, data_Allegiance_DoAllegianceLockAction);
                                return data_Allegiance_DoAllegianceLockAction;
                            case GameActionType.Allegiance_SetAllegianceApprovedVassal:
                                var data_Allegiance_SetAllegianceApprovedVassal = new Allegiance_SetAllegianceApprovedVassal();
                                data_Allegiance_SetAllegianceApprovedVassal.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_SetAllegianceApprovedVassal));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_SetAllegianceApprovedVassal);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_SetAllegianceApprovedVassal));
                                OnAllegiance_SetAllegianceApprovedVassal?.Invoke(this, data_Allegiance_SetAllegianceApprovedVassal);
                                return data_Allegiance_SetAllegianceApprovedVassal;
                            case GameActionType.Allegiance_AllegianceChatGag:
                                var data_Allegiance_AllegianceChatGag = new Allegiance_AllegianceChatGag();
                                data_Allegiance_AllegianceChatGag.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_AllegianceChatGag));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_AllegianceChatGag);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_AllegianceChatGag));
                                OnAllegiance_AllegianceChatGag?.Invoke(this, data_Allegiance_AllegianceChatGag);
                                return data_Allegiance_AllegianceChatGag;
                            case GameActionType.Allegiance_DoAllegianceHouseAction:
                                var data_Allegiance_DoAllegianceHouseAction = new Allegiance_DoAllegianceHouseAction();
                                data_Allegiance_DoAllegianceHouseAction.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_DoAllegianceHouseAction));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_DoAllegianceHouseAction);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_DoAllegianceHouseAction));
                                OnAllegiance_DoAllegianceHouseAction?.Invoke(this, data_Allegiance_DoAllegianceHouseAction);
                                return data_Allegiance_DoAllegianceHouseAction;
                            case GameActionType.Train_TrainAttribute2nd:
                                var data_Train_TrainAttribute2nd = new Train_TrainAttribute2nd();
                                data_Train_TrainAttribute2nd.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Train_TrainAttribute2nd));
                                OnOrdered_GameAction?.Invoke(this,  data_Train_TrainAttribute2nd);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Train_TrainAttribute2nd));
                                OnTrain_TrainAttribute2nd?.Invoke(this, data_Train_TrainAttribute2nd);
                                return data_Train_TrainAttribute2nd;
                            case GameActionType.Train_TrainAttribute:
                                var data_Train_TrainAttribute = new Train_TrainAttribute();
                                data_Train_TrainAttribute.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Train_TrainAttribute));
                                OnOrdered_GameAction?.Invoke(this,  data_Train_TrainAttribute);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Train_TrainAttribute));
                                OnTrain_TrainAttribute?.Invoke(this, data_Train_TrainAttribute);
                                return data_Train_TrainAttribute;
                            case GameActionType.Train_TrainSkill:
                                var data_Train_TrainSkill = new Train_TrainSkill();
                                data_Train_TrainSkill.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Train_TrainSkill));
                                OnOrdered_GameAction?.Invoke(this,  data_Train_TrainSkill);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Train_TrainSkill));
                                OnTrain_TrainSkill?.Invoke(this, data_Train_TrainSkill);
                                return data_Train_TrainSkill;
                            case GameActionType.Train_TrainSkillAdvancementClass:
                                var data_Train_TrainSkillAdvancementClass = new Train_TrainSkillAdvancementClass();
                                data_Train_TrainSkillAdvancementClass.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Train_TrainSkillAdvancementClass));
                                OnOrdered_GameAction?.Invoke(this,  data_Train_TrainSkillAdvancementClass);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Train_TrainSkillAdvancementClass));
                                OnTrain_TrainSkillAdvancementClass?.Invoke(this, data_Train_TrainSkillAdvancementClass);
                                return data_Train_TrainSkillAdvancementClass;
                            case GameActionType.Magic_CastUntargetedSpell:
                                var data_Magic_CastUntargetedSpell = new Magic_CastUntargetedSpell();
                                data_Magic_CastUntargetedSpell.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Magic_CastUntargetedSpell));
                                OnOrdered_GameAction?.Invoke(this,  data_Magic_CastUntargetedSpell);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Magic_CastUntargetedSpell));
                                OnMagic_CastUntargetedSpell?.Invoke(this, data_Magic_CastUntargetedSpell);
                                return data_Magic_CastUntargetedSpell;
                            case GameActionType.Magic_CastTargetedSpell:
                                var data_Magic_CastTargetedSpell = new Magic_CastTargetedSpell();
                                data_Magic_CastTargetedSpell.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Magic_CastTargetedSpell));
                                OnOrdered_GameAction?.Invoke(this,  data_Magic_CastTargetedSpell);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Magic_CastTargetedSpell));
                                OnMagic_CastTargetedSpell?.Invoke(this, data_Magic_CastTargetedSpell);
                                return data_Magic_CastTargetedSpell;
                            case GameActionType.Combat_ChangeCombatMode:
                                var data_Combat_ChangeCombatMode = new Combat_ChangeCombatMode();
                                data_Combat_ChangeCombatMode.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Combat_ChangeCombatMode));
                                OnOrdered_GameAction?.Invoke(this,  data_Combat_ChangeCombatMode);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Combat_ChangeCombatMode));
                                OnCombat_ChangeCombatMode?.Invoke(this, data_Combat_ChangeCombatMode);
                                return data_Combat_ChangeCombatMode;
                            case GameActionType.Inventory_StackableMerge:
                                var data_Inventory_StackableMerge = new Inventory_StackableMerge();
                                data_Inventory_StackableMerge.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Inventory_StackableMerge));
                                OnOrdered_GameAction?.Invoke(this,  data_Inventory_StackableMerge);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Inventory_StackableMerge));
                                OnInventory_StackableMerge?.Invoke(this, data_Inventory_StackableMerge);
                                return data_Inventory_StackableMerge;
                            case GameActionType.Inventory_StackableSplitToContainer:
                                var data_Inventory_StackableSplitToContainer = new Inventory_StackableSplitToContainer();
                                data_Inventory_StackableSplitToContainer.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Inventory_StackableSplitToContainer));
                                OnOrdered_GameAction?.Invoke(this,  data_Inventory_StackableSplitToContainer);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Inventory_StackableSplitToContainer));
                                OnInventory_StackableSplitToContainer?.Invoke(this, data_Inventory_StackableSplitToContainer);
                                return data_Inventory_StackableSplitToContainer;
                            case GameActionType.Inventory_StackableSplitTo3D:
                                var data_Inventory_StackableSplitTo3D = new Inventory_StackableSplitTo3D();
                                data_Inventory_StackableSplitTo3D.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Inventory_StackableSplitTo3D));
                                OnOrdered_GameAction?.Invoke(this,  data_Inventory_StackableSplitTo3D);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Inventory_StackableSplitTo3D));
                                OnInventory_StackableSplitTo3D?.Invoke(this, data_Inventory_StackableSplitTo3D);
                                return data_Inventory_StackableSplitTo3D;
                            case GameActionType.Communication_ModifyCharacterSquelch:
                                var data_Communication_ModifyCharacterSquelch = new Communication_ModifyCharacterSquelch();
                                data_Communication_ModifyCharacterSquelch.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_ModifyCharacterSquelch));
                                OnOrdered_GameAction?.Invoke(this,  data_Communication_ModifyCharacterSquelch);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_ModifyCharacterSquelch));
                                OnCommunication_ModifyCharacterSquelch?.Invoke(this, data_Communication_ModifyCharacterSquelch);
                                return data_Communication_ModifyCharacterSquelch;
                            case GameActionType.Communication_ModifyAccountSquelch:
                                var data_Communication_ModifyAccountSquelch = new Communication_ModifyAccountSquelch();
                                data_Communication_ModifyAccountSquelch.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_ModifyAccountSquelch));
                                OnOrdered_GameAction?.Invoke(this,  data_Communication_ModifyAccountSquelch);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_ModifyAccountSquelch));
                                OnCommunication_ModifyAccountSquelch?.Invoke(this, data_Communication_ModifyAccountSquelch);
                                return data_Communication_ModifyAccountSquelch;
                            case GameActionType.Communication_ModifyGlobalSquelch:
                                var data_Communication_ModifyGlobalSquelch = new Communication_ModifyGlobalSquelch();
                                data_Communication_ModifyGlobalSquelch.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_ModifyGlobalSquelch));
                                OnOrdered_GameAction?.Invoke(this,  data_Communication_ModifyGlobalSquelch);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_ModifyGlobalSquelch));
                                OnCommunication_ModifyGlobalSquelch?.Invoke(this, data_Communication_ModifyGlobalSquelch);
                                return data_Communication_ModifyGlobalSquelch;
                            case GameActionType.Communication_TalkDirectByName:
                                var data_Communication_TalkDirectByName = new Communication_TalkDirectByName();
                                data_Communication_TalkDirectByName.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_TalkDirectByName));
                                OnOrdered_GameAction?.Invoke(this,  data_Communication_TalkDirectByName);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_TalkDirectByName));
                                OnCommunication_TalkDirectByName?.Invoke(this, data_Communication_TalkDirectByName);
                                return data_Communication_TalkDirectByName;
                            case GameActionType.Vendor_Buy:
                                var data_Vendor_Buy = new Vendor_Buy();
                                data_Vendor_Buy.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Vendor_Buy));
                                OnOrdered_GameAction?.Invoke(this,  data_Vendor_Buy);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Vendor_Buy));
                                OnVendor_Buy?.Invoke(this, data_Vendor_Buy);
                                return data_Vendor_Buy;
                            case GameActionType.Vendor_Sell:
                                var data_Vendor_Sell = new Vendor_Sell();
                                data_Vendor_Sell.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Vendor_Sell));
                                OnOrdered_GameAction?.Invoke(this,  data_Vendor_Sell);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Vendor_Sell));
                                OnVendor_Sell?.Invoke(this, data_Vendor_Sell);
                                return data_Vendor_Sell;
                            case GameActionType.Character_TeleToLifestone:
                                var data_Character_TeleToLifestone = new Character_TeleToLifestone();
                                data_Character_TeleToLifestone.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_TeleToLifestone));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_TeleToLifestone);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_TeleToLifestone));
                                OnCharacter_TeleToLifestone?.Invoke(this, data_Character_TeleToLifestone);
                                return data_Character_TeleToLifestone;
                            case GameActionType.Character_LoginCompleteNotification:
                                var data_Character_LoginCompleteNotification = new Character_LoginCompleteNotification();
                                data_Character_LoginCompleteNotification.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_LoginCompleteNotification));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_LoginCompleteNotification);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_LoginCompleteNotification));
                                OnCharacter_LoginCompleteNotification?.Invoke(this, data_Character_LoginCompleteNotification);
                                return data_Character_LoginCompleteNotification;
                            case GameActionType.Fellowship_Create:
                                var data_Fellowship_Create = new Fellowship_Create();
                                data_Fellowship_Create.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Fellowship_Create));
                                OnOrdered_GameAction?.Invoke(this,  data_Fellowship_Create);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Fellowship_Create));
                                OnFellowship_Create?.Invoke(this, data_Fellowship_Create);
                                return data_Fellowship_Create;
                            case GameActionType.Fellowship_Quit:
                                var data_Fellowship_Quit = new Fellowship_Quit();
                                data_Fellowship_Quit.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Fellowship_Quit));
                                OnOrdered_GameAction?.Invoke(this,  data_Fellowship_Quit);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Fellowship_Quit));
                                OnFellowship_Quit?.Invoke(this, data_Fellowship_Quit);
                                return data_Fellowship_Quit;
                            case GameActionType.Fellowship_Dismiss:
                                var data_Fellowship_Dismiss = new Fellowship_Dismiss();
                                data_Fellowship_Dismiss.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Fellowship_Dismiss));
                                OnOrdered_GameAction?.Invoke(this,  data_Fellowship_Dismiss);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Fellowship_Dismiss));
                                OnFellowship_Dismiss?.Invoke(this, data_Fellowship_Dismiss);
                                return data_Fellowship_Dismiss;
                            case GameActionType.Fellowship_Recruit:
                                var data_Fellowship_Recruit = new Fellowship_Recruit();
                                data_Fellowship_Recruit.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Fellowship_Recruit));
                                OnOrdered_GameAction?.Invoke(this,  data_Fellowship_Recruit);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Fellowship_Recruit));
                                OnFellowship_Recruit?.Invoke(this, data_Fellowship_Recruit);
                                return data_Fellowship_Recruit;
                            case GameActionType.Fellowship_UpdateRequest:
                                var data_Fellowship_UpdateRequest = new Fellowship_UpdateRequest();
                                data_Fellowship_UpdateRequest.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Fellowship_UpdateRequest));
                                OnOrdered_GameAction?.Invoke(this,  data_Fellowship_UpdateRequest);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Fellowship_UpdateRequest));
                                OnFellowship_UpdateRequest?.Invoke(this, data_Fellowship_UpdateRequest);
                                return data_Fellowship_UpdateRequest;
                            case GameActionType.Writing_BookAddPage:
                                var data_Writing_BookAddPage = new Writing_BookAddPage();
                                data_Writing_BookAddPage.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Writing_BookAddPage));
                                OnOrdered_GameAction?.Invoke(this,  data_Writing_BookAddPage);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Writing_BookAddPage));
                                OnWriting_BookAddPage?.Invoke(this, data_Writing_BookAddPage);
                                return data_Writing_BookAddPage;
                            case GameActionType.Writing_BookModifyPage:
                                var data_Writing_BookModifyPage = new Writing_BookModifyPage();
                                data_Writing_BookModifyPage.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Writing_BookModifyPage));
                                OnOrdered_GameAction?.Invoke(this,  data_Writing_BookModifyPage);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Writing_BookModifyPage));
                                OnWriting_BookModifyPage?.Invoke(this, data_Writing_BookModifyPage);
                                return data_Writing_BookModifyPage;
                            case GameActionType.Writing_BookData:
                                var data_Writing_BookData = new Writing_BookData();
                                data_Writing_BookData.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Writing_BookData));
                                OnOrdered_GameAction?.Invoke(this,  data_Writing_BookData);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Writing_BookData));
                                OnWriting_BookData?.Invoke(this, data_Writing_BookData);
                                return data_Writing_BookData;
                            case GameActionType.Writing_BookDeletePage:
                                var data_Writing_BookDeletePage = new Writing_BookDeletePage();
                                data_Writing_BookDeletePage.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Writing_BookDeletePage));
                                OnOrdered_GameAction?.Invoke(this,  data_Writing_BookDeletePage);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Writing_BookDeletePage));
                                OnWriting_BookDeletePage?.Invoke(this, data_Writing_BookDeletePage);
                                return data_Writing_BookDeletePage;
                            case GameActionType.Writing_BookPageData:
                                var data_Writing_BookPageData = new Writing_BookPageData();
                                data_Writing_BookPageData.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Writing_BookPageData));
                                OnOrdered_GameAction?.Invoke(this,  data_Writing_BookPageData);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Writing_BookPageData));
                                OnWriting_BookPageData?.Invoke(this, data_Writing_BookPageData);
                                return data_Writing_BookPageData;
                            case GameActionType.Writing_SetInscription:
                                var data_Writing_SetInscription = new Writing_SetInscription();
                                data_Writing_SetInscription.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Writing_SetInscription));
                                OnOrdered_GameAction?.Invoke(this,  data_Writing_SetInscription);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Writing_SetInscription));
                                OnWriting_SetInscription?.Invoke(this, data_Writing_SetInscription);
                                return data_Writing_SetInscription;
                            case GameActionType.Item_Appraise:
                                var data_Item_Appraise = new Item_Appraise();
                                data_Item_Appraise.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Item_Appraise));
                                OnOrdered_GameAction?.Invoke(this,  data_Item_Appraise);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Item_Appraise));
                                OnItem_Appraise?.Invoke(this, data_Item_Appraise);
                                return data_Item_Appraise;
                            case GameActionType.Inventory_GiveObjectRequest:
                                var data_Inventory_GiveObjectRequest = new Inventory_GiveObjectRequest();
                                data_Inventory_GiveObjectRequest.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Inventory_GiveObjectRequest));
                                OnOrdered_GameAction?.Invoke(this,  data_Inventory_GiveObjectRequest);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Inventory_GiveObjectRequest));
                                OnInventory_GiveObjectRequest?.Invoke(this, data_Inventory_GiveObjectRequest);
                                return data_Inventory_GiveObjectRequest;
                            case GameActionType.Advocate_Teleport:
                                var data_Advocate_Teleport = new Advocate_Teleport();
                                data_Advocate_Teleport.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Advocate_Teleport));
                                OnOrdered_GameAction?.Invoke(this,  data_Advocate_Teleport);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Advocate_Teleport));
                                OnAdvocate_Teleport?.Invoke(this, data_Advocate_Teleport);
                                return data_Advocate_Teleport;
                            case GameActionType.Character_AbuseLogRequest:
                                var data_Character_AbuseLogRequest = new Character_AbuseLogRequest();
                                data_Character_AbuseLogRequest.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_AbuseLogRequest));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_AbuseLogRequest);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_AbuseLogRequest));
                                OnCharacter_AbuseLogRequest?.Invoke(this, data_Character_AbuseLogRequest);
                                return data_Character_AbuseLogRequest;
                            case GameActionType.Communication_AddToChannel:
                                var data_Communication_AddToChannel = new Communication_AddToChannel();
                                data_Communication_AddToChannel.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_AddToChannel));
                                OnOrdered_GameAction?.Invoke(this,  data_Communication_AddToChannel);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_AddToChannel));
                                OnCommunication_AddToChannel?.Invoke(this, data_Communication_AddToChannel);
                                return data_Communication_AddToChannel;
                            case GameActionType.Communication_RemoveFromChannel:
                                var data_Communication_RemoveFromChannel = new Communication_RemoveFromChannel();
                                data_Communication_RemoveFromChannel.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_RemoveFromChannel));
                                OnOrdered_GameAction?.Invoke(this,  data_Communication_RemoveFromChannel);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_RemoveFromChannel));
                                OnCommunication_RemoveFromChannel?.Invoke(this, data_Communication_RemoveFromChannel);
                                return data_Communication_RemoveFromChannel;
                            case GameActionType.Communication_ChannelBroadcast:
                                var data_Communication_ChannelBroadcast = new Communication_ChannelBroadcast();
                                data_Communication_ChannelBroadcast.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_ChannelBroadcast));
                                OnOrdered_GameAction?.Invoke(this,  data_Communication_ChannelBroadcast);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_ChannelBroadcast));
                                OnCommunication_ChannelBroadcast?.Invoke(this, data_Communication_ChannelBroadcast);
                                return data_Communication_ChannelBroadcast;
                            case GameActionType.Communication_ChannelList:
                                var data_Communication_ChannelList = new Communication_ChannelList();
                                data_Communication_ChannelList.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_ChannelList));
                                OnOrdered_GameAction?.Invoke(this,  data_Communication_ChannelList);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_ChannelList));
                                OnCommunication_ChannelList?.Invoke(this, data_Communication_ChannelList);
                                return data_Communication_ChannelList;
                            case GameActionType.Communication_ChannelIndex:
                                var data_Communication_ChannelIndex = new Communication_ChannelIndex();
                                data_Communication_ChannelIndex.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_ChannelIndex));
                                OnOrdered_GameAction?.Invoke(this,  data_Communication_ChannelIndex);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_ChannelIndex));
                                OnCommunication_ChannelIndex?.Invoke(this, data_Communication_ChannelIndex);
                                return data_Communication_ChannelIndex;
                            case GameActionType.Inventory_NoLongerViewingContents:
                                var data_Inventory_NoLongerViewingContents = new Inventory_NoLongerViewingContents();
                                data_Inventory_NoLongerViewingContents.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Inventory_NoLongerViewingContents));
                                OnOrdered_GameAction?.Invoke(this,  data_Inventory_NoLongerViewingContents);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Inventory_NoLongerViewingContents));
                                OnInventory_NoLongerViewingContents?.Invoke(this, data_Inventory_NoLongerViewingContents);
                                return data_Inventory_NoLongerViewingContents;
                            case GameActionType.Inventory_StackableSplitToWield:
                                var data_Inventory_StackableSplitToWield = new Inventory_StackableSplitToWield();
                                data_Inventory_StackableSplitToWield.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Inventory_StackableSplitToWield));
                                OnOrdered_GameAction?.Invoke(this,  data_Inventory_StackableSplitToWield);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Inventory_StackableSplitToWield));
                                OnInventory_StackableSplitToWield?.Invoke(this, data_Inventory_StackableSplitToWield);
                                return data_Inventory_StackableSplitToWield;
                            case GameActionType.Character_AddShortCut:
                                var data_Character_AddShortCut = new Character_AddShortCut();
                                data_Character_AddShortCut.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_AddShortCut));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_AddShortCut);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_AddShortCut));
                                OnCharacter_AddShortCut?.Invoke(this, data_Character_AddShortCut);
                                return data_Character_AddShortCut;
                            case GameActionType.Character_RemoveShortCut:
                                var data_Character_RemoveShortCut = new Character_RemoveShortCut();
                                data_Character_RemoveShortCut.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_RemoveShortCut));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_RemoveShortCut);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_RemoveShortCut));
                                OnCharacter_RemoveShortCut?.Invoke(this, data_Character_RemoveShortCut);
                                return data_Character_RemoveShortCut;
                            case GameActionType.Character_CharacterOptionsEvent:
                                var data_Character_CharacterOptionsEvent = new Character_CharacterOptionsEvent();
                                data_Character_CharacterOptionsEvent.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_CharacterOptionsEvent));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_CharacterOptionsEvent);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_CharacterOptionsEvent));
                                OnCharacter_CharacterOptionsEvent?.Invoke(this, data_Character_CharacterOptionsEvent);
                                return data_Character_CharacterOptionsEvent;
                            case GameActionType.Magic_RemoveSpell:
                                var data_Magic_RemoveSpell = new Magic_RemoveSpell();
                                data_Magic_RemoveSpell.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Magic_RemoveSpell));
                                OnOrdered_GameAction?.Invoke(this,  data_Magic_RemoveSpell);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Magic_RemoveSpell));
                                OnMagic_RemoveSpell?.Invoke(this, data_Magic_RemoveSpell);
                                return data_Magic_RemoveSpell;
                            case GameActionType.Combat_CancelAttack:
                                var data_Combat_CancelAttack = new Combat_CancelAttack();
                                data_Combat_CancelAttack.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Combat_CancelAttack));
                                OnOrdered_GameAction?.Invoke(this,  data_Combat_CancelAttack);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Combat_CancelAttack));
                                OnCombat_CancelAttack?.Invoke(this, data_Combat_CancelAttack);
                                return data_Combat_CancelAttack;
                            case GameActionType.Combat_QueryHealth:
                                var data_Combat_QueryHealth = new Combat_QueryHealth();
                                data_Combat_QueryHealth.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Combat_QueryHealth));
                                OnOrdered_GameAction?.Invoke(this,  data_Combat_QueryHealth);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Combat_QueryHealth));
                                OnCombat_QueryHealth?.Invoke(this, data_Combat_QueryHealth);
                                return data_Combat_QueryHealth;
                            case GameActionType.Character_QueryAge:
                                var data_Character_QueryAge = new Character_QueryAge();
                                data_Character_QueryAge.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_QueryAge));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_QueryAge);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_QueryAge));
                                OnCharacter_QueryAge?.Invoke(this, data_Character_QueryAge);
                                return data_Character_QueryAge;
                            case GameActionType.Character_QueryBirth:
                                var data_Character_QueryBirth = new Character_QueryBirth();
                                data_Character_QueryBirth.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_QueryBirth));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_QueryBirth);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_QueryBirth));
                                OnCharacter_QueryBirth?.Invoke(this, data_Character_QueryBirth);
                                return data_Character_QueryBirth;
                            case GameActionType.Communication_Emote:
                                var data_Communication_Emote = new Communication_Emote();
                                data_Communication_Emote.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_Emote));
                                OnOrdered_GameAction?.Invoke(this,  data_Communication_Emote);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_Emote));
                                OnCommunication_Emote?.Invoke(this, data_Communication_Emote);
                                return data_Communication_Emote;
                            case GameActionType.Communication_SoulEmote:
                                var data_Communication_SoulEmote = new Communication_SoulEmote();
                                data_Communication_SoulEmote.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_SoulEmote));
                                OnOrdered_GameAction?.Invoke(this,  data_Communication_SoulEmote);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Communication_SoulEmote));
                                OnCommunication_SoulEmote?.Invoke(this, data_Communication_SoulEmote);
                                return data_Communication_SoulEmote;
                            case GameActionType.Character_AddSpellFavorite:
                                var data_Character_AddSpellFavorite = new Character_AddSpellFavorite();
                                data_Character_AddSpellFavorite.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_AddSpellFavorite));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_AddSpellFavorite);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_AddSpellFavorite));
                                OnCharacter_AddSpellFavorite?.Invoke(this, data_Character_AddSpellFavorite);
                                return data_Character_AddSpellFavorite;
                            case GameActionType.Character_RemoveSpellFavorite:
                                var data_Character_RemoveSpellFavorite = new Character_RemoveSpellFavorite();
                                data_Character_RemoveSpellFavorite.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_RemoveSpellFavorite));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_RemoveSpellFavorite);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_RemoveSpellFavorite));
                                OnCharacter_RemoveSpellFavorite?.Invoke(this, data_Character_RemoveSpellFavorite);
                                return data_Character_RemoveSpellFavorite;
                            case GameActionType.Character_RequestPing:
                                var data_Character_RequestPing = new Character_RequestPing();
                                data_Character_RequestPing.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_RequestPing));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_RequestPing);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_RequestPing));
                                OnCharacter_RequestPing?.Invoke(this, data_Character_RequestPing);
                                return data_Character_RequestPing;
                            case GameActionType.Trade_OpenTradeNegotiations:
                                var data_Trade_OpenTradeNegotiations = new Trade_OpenTradeNegotiations();
                                data_Trade_OpenTradeNegotiations.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Trade_OpenTradeNegotiations));
                                OnOrdered_GameAction?.Invoke(this,  data_Trade_OpenTradeNegotiations);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Trade_OpenTradeNegotiations));
                                OnTrade_OpenTradeNegotiations?.Invoke(this, data_Trade_OpenTradeNegotiations);
                                return data_Trade_OpenTradeNegotiations;
                            case GameActionType.Trade_CloseTradeNegotiations:
                                var data_Trade_CloseTradeNegotiations = new Trade_CloseTradeNegotiations();
                                data_Trade_CloseTradeNegotiations.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Trade_CloseTradeNegotiations));
                                OnOrdered_GameAction?.Invoke(this,  data_Trade_CloseTradeNegotiations);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Trade_CloseTradeNegotiations));
                                OnTrade_CloseTradeNegotiations?.Invoke(this, data_Trade_CloseTradeNegotiations);
                                return data_Trade_CloseTradeNegotiations;
                            case GameActionType.Trade_AddToTrade:
                                var data_Trade_AddToTrade = new Trade_AddToTrade();
                                data_Trade_AddToTrade.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Trade_AddToTrade));
                                OnOrdered_GameAction?.Invoke(this,  data_Trade_AddToTrade);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Trade_AddToTrade));
                                OnTrade_AddToTrade?.Invoke(this, data_Trade_AddToTrade);
                                return data_Trade_AddToTrade;
                            case GameActionType.Trade_AcceptTrade:
                                var data_Trade_AcceptTrade = new Trade_AcceptTrade();
                                data_Trade_AcceptTrade.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Trade_AcceptTrade));
                                OnOrdered_GameAction?.Invoke(this,  data_Trade_AcceptTrade);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Trade_AcceptTrade));
                                OnTrade_AcceptTrade?.Invoke(this, data_Trade_AcceptTrade);
                                return data_Trade_AcceptTrade;
                            case GameActionType.Trade_DeclineTrade:
                                var data_Trade_DeclineTrade = new Trade_DeclineTrade();
                                data_Trade_DeclineTrade.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Trade_DeclineTrade));
                                OnOrdered_GameAction?.Invoke(this,  data_Trade_DeclineTrade);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Trade_DeclineTrade));
                                OnTrade_DeclineTrade?.Invoke(this, data_Trade_DeclineTrade);
                                return data_Trade_DeclineTrade;
                            case GameActionType.Trade_ResetTrade:
                                var data_Trade_ResetTrade = new Trade_ResetTrade();
                                data_Trade_ResetTrade.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Trade_ResetTrade));
                                OnOrdered_GameAction?.Invoke(this,  data_Trade_ResetTrade);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Trade_ResetTrade));
                                OnTrade_ResetTrade?.Invoke(this, data_Trade_ResetTrade);
                                return data_Trade_ResetTrade;
                            case GameActionType.Character_ClearPlayerConsentList:
                                var data_Character_ClearPlayerConsentList = new Character_ClearPlayerConsentList();
                                data_Character_ClearPlayerConsentList.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_ClearPlayerConsentList));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_ClearPlayerConsentList);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_ClearPlayerConsentList));
                                OnCharacter_ClearPlayerConsentList?.Invoke(this, data_Character_ClearPlayerConsentList);
                                return data_Character_ClearPlayerConsentList;
                            case GameActionType.Character_DisplayPlayerConsentList:
                                var data_Character_DisplayPlayerConsentList = new Character_DisplayPlayerConsentList();
                                data_Character_DisplayPlayerConsentList.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_DisplayPlayerConsentList));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_DisplayPlayerConsentList);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_DisplayPlayerConsentList));
                                OnCharacter_DisplayPlayerConsentList?.Invoke(this, data_Character_DisplayPlayerConsentList);
                                return data_Character_DisplayPlayerConsentList;
                            case GameActionType.Character_RemoveFromPlayerConsentList:
                                var data_Character_RemoveFromPlayerConsentList = new Character_RemoveFromPlayerConsentList();
                                data_Character_RemoveFromPlayerConsentList.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_RemoveFromPlayerConsentList));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_RemoveFromPlayerConsentList);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_RemoveFromPlayerConsentList));
                                OnCharacter_RemoveFromPlayerConsentList?.Invoke(this, data_Character_RemoveFromPlayerConsentList);
                                return data_Character_RemoveFromPlayerConsentList;
                            case GameActionType.Character_AddPlayerPermission:
                                var data_Character_AddPlayerPermission = new Character_AddPlayerPermission();
                                data_Character_AddPlayerPermission.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_AddPlayerPermission));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_AddPlayerPermission);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_AddPlayerPermission));
                                OnCharacter_AddPlayerPermission?.Invoke(this, data_Character_AddPlayerPermission);
                                return data_Character_AddPlayerPermission;
                            case GameActionType.House_BuyHouse:
                                var data_House_BuyHouse = new House_BuyHouse();
                                data_House_BuyHouse.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_BuyHouse));
                                OnOrdered_GameAction?.Invoke(this,  data_House_BuyHouse);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_BuyHouse));
                                OnHouse_BuyHouse?.Invoke(this, data_House_BuyHouse);
                                return data_House_BuyHouse;
                            case GameActionType.House_QueryHouse:
                                var data_House_QueryHouse = new House_QueryHouse();
                                data_House_QueryHouse.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_QueryHouse));
                                OnOrdered_GameAction?.Invoke(this,  data_House_QueryHouse);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_QueryHouse));
                                OnHouse_QueryHouse?.Invoke(this, data_House_QueryHouse);
                                return data_House_QueryHouse;
                            case GameActionType.House_AbandonHouse:
                                var data_House_AbandonHouse = new House_AbandonHouse();
                                data_House_AbandonHouse.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_AbandonHouse));
                                OnOrdered_GameAction?.Invoke(this,  data_House_AbandonHouse);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_AbandonHouse));
                                OnHouse_AbandonHouse?.Invoke(this, data_House_AbandonHouse);
                                return data_House_AbandonHouse;
                            case GameActionType.Character_RemovePlayerPermission:
                                var data_Character_RemovePlayerPermission = new Character_RemovePlayerPermission();
                                data_Character_RemovePlayerPermission.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_RemovePlayerPermission));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_RemovePlayerPermission);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_RemovePlayerPermission));
                                OnCharacter_RemovePlayerPermission?.Invoke(this, data_Character_RemovePlayerPermission);
                                return data_Character_RemovePlayerPermission;
                            case GameActionType.House_RentHouse:
                                var data_House_RentHouse = new House_RentHouse();
                                data_House_RentHouse.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_RentHouse));
                                OnOrdered_GameAction?.Invoke(this,  data_House_RentHouse);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_RentHouse));
                                OnHouse_RentHouse?.Invoke(this, data_House_RentHouse);
                                return data_House_RentHouse;
                            case GameActionType.Character_SetDesiredComponentLevel:
                                var data_Character_SetDesiredComponentLevel = new Character_SetDesiredComponentLevel();
                                data_Character_SetDesiredComponentLevel.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_SetDesiredComponentLevel));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_SetDesiredComponentLevel);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_SetDesiredComponentLevel));
                                OnCharacter_SetDesiredComponentLevel?.Invoke(this, data_Character_SetDesiredComponentLevel);
                                return data_Character_SetDesiredComponentLevel;
                            case GameActionType.House_AddPermanentGuest:
                                var data_House_AddPermanentGuest = new House_AddPermanentGuest();
                                data_House_AddPermanentGuest.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_AddPermanentGuest));
                                OnOrdered_GameAction?.Invoke(this,  data_House_AddPermanentGuest);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_AddPermanentGuest));
                                OnHouse_AddPermanentGuest?.Invoke(this, data_House_AddPermanentGuest);
                                return data_House_AddPermanentGuest;
                            case GameActionType.House_RemovePermanentGuest:
                                var data_House_RemovePermanentGuest = new House_RemovePermanentGuest();
                                data_House_RemovePermanentGuest.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_RemovePermanentGuest));
                                OnOrdered_GameAction?.Invoke(this,  data_House_RemovePermanentGuest);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_RemovePermanentGuest));
                                OnHouse_RemovePermanentGuest?.Invoke(this, data_House_RemovePermanentGuest);
                                return data_House_RemovePermanentGuest;
                            case GameActionType.House_SetOpenHouseStatus:
                                var data_House_SetOpenHouseStatus = new House_SetOpenHouseStatus();
                                data_House_SetOpenHouseStatus.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_SetOpenHouseStatus));
                                OnOrdered_GameAction?.Invoke(this,  data_House_SetOpenHouseStatus);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_SetOpenHouseStatus));
                                OnHouse_SetOpenHouseStatus?.Invoke(this, data_House_SetOpenHouseStatus);
                                return data_House_SetOpenHouseStatus;
                            case GameActionType.House_ChangeStoragePermission:
                                var data_House_ChangeStoragePermission = new House_ChangeStoragePermission();
                                data_House_ChangeStoragePermission.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_ChangeStoragePermission));
                                OnOrdered_GameAction?.Invoke(this,  data_House_ChangeStoragePermission);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_ChangeStoragePermission));
                                OnHouse_ChangeStoragePermission?.Invoke(this, data_House_ChangeStoragePermission);
                                return data_House_ChangeStoragePermission;
                            case GameActionType.House_BootSpecificHouseGuest:
                                var data_House_BootSpecificHouseGuest = new House_BootSpecificHouseGuest();
                                data_House_BootSpecificHouseGuest.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_BootSpecificHouseGuest));
                                OnOrdered_GameAction?.Invoke(this,  data_House_BootSpecificHouseGuest);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_BootSpecificHouseGuest));
                                OnHouse_BootSpecificHouseGuest?.Invoke(this, data_House_BootSpecificHouseGuest);
                                return data_House_BootSpecificHouseGuest;
                            case GameActionType.House_RemoveAllStoragePermission:
                                var data_House_RemoveAllStoragePermission = new House_RemoveAllStoragePermission();
                                data_House_RemoveAllStoragePermission.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_RemoveAllStoragePermission));
                                OnOrdered_GameAction?.Invoke(this,  data_House_RemoveAllStoragePermission);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_RemoveAllStoragePermission));
                                OnHouse_RemoveAllStoragePermission?.Invoke(this, data_House_RemoveAllStoragePermission);
                                return data_House_RemoveAllStoragePermission;
                            case GameActionType.House_RequestFullGuestList:
                                var data_House_RequestFullGuestList = new House_RequestFullGuestList();
                                data_House_RequestFullGuestList.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_RequestFullGuestList));
                                OnOrdered_GameAction?.Invoke(this,  data_House_RequestFullGuestList);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_RequestFullGuestList));
                                OnHouse_RequestFullGuestList?.Invoke(this, data_House_RequestFullGuestList);
                                return data_House_RequestFullGuestList;
                            case GameActionType.Allegiance_SetMotd:
                                var data_Allegiance_SetMotd = new Allegiance_SetMotd();
                                data_Allegiance_SetMotd.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_SetMotd));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_SetMotd);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_SetMotd));
                                OnAllegiance_SetMotd?.Invoke(this, data_Allegiance_SetMotd);
                                return data_Allegiance_SetMotd;
                            case GameActionType.Allegiance_QueryMotd:
                                var data_Allegiance_QueryMotd = new Allegiance_QueryMotd();
                                data_Allegiance_QueryMotd.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_QueryMotd));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_QueryMotd);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_QueryMotd));
                                OnAllegiance_QueryMotd?.Invoke(this, data_Allegiance_QueryMotd);
                                return data_Allegiance_QueryMotd;
                            case GameActionType.Allegiance_ClearMotd:
                                var data_Allegiance_ClearMotd = new Allegiance_ClearMotd();
                                data_Allegiance_ClearMotd.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_ClearMotd));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_ClearMotd);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_ClearMotd));
                                OnAllegiance_ClearMotd?.Invoke(this, data_Allegiance_ClearMotd);
                                return data_Allegiance_ClearMotd;
                            case GameActionType.House_QueryLord:
                                var data_House_QueryLord = new House_QueryLord();
                                data_House_QueryLord.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_QueryLord));
                                OnOrdered_GameAction?.Invoke(this,  data_House_QueryLord);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_QueryLord));
                                OnHouse_QueryLord?.Invoke(this, data_House_QueryLord);
                                return data_House_QueryLord;
                            case GameActionType.House_AddAllStoragePermission:
                                var data_House_AddAllStoragePermission = new House_AddAllStoragePermission();
                                data_House_AddAllStoragePermission.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_AddAllStoragePermission));
                                OnOrdered_GameAction?.Invoke(this,  data_House_AddAllStoragePermission);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_AddAllStoragePermission));
                                OnHouse_AddAllStoragePermission?.Invoke(this, data_House_AddAllStoragePermission);
                                return data_House_AddAllStoragePermission;
                            case GameActionType.House_RemoveAllPermanentGuests:
                                var data_House_RemoveAllPermanentGuests = new House_RemoveAllPermanentGuests();
                                data_House_RemoveAllPermanentGuests.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_RemoveAllPermanentGuests));
                                OnOrdered_GameAction?.Invoke(this,  data_House_RemoveAllPermanentGuests);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_RemoveAllPermanentGuests));
                                OnHouse_RemoveAllPermanentGuests?.Invoke(this, data_House_RemoveAllPermanentGuests);
                                return data_House_RemoveAllPermanentGuests;
                            case GameActionType.House_BootEveryone:
                                var data_House_BootEveryone = new House_BootEveryone();
                                data_House_BootEveryone.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_BootEveryone));
                                OnOrdered_GameAction?.Invoke(this,  data_House_BootEveryone);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_BootEveryone));
                                OnHouse_BootEveryone?.Invoke(this, data_House_BootEveryone);
                                return data_House_BootEveryone;
                            case GameActionType.House_TeleToHouse:
                                var data_House_TeleToHouse = new House_TeleToHouse();
                                data_House_TeleToHouse.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_TeleToHouse));
                                OnOrdered_GameAction?.Invoke(this,  data_House_TeleToHouse);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_TeleToHouse));
                                OnHouse_TeleToHouse?.Invoke(this, data_House_TeleToHouse);
                                return data_House_TeleToHouse;
                            case GameActionType.Item_QueryItemMana:
                                var data_Item_QueryItemMana = new Item_QueryItemMana();
                                data_Item_QueryItemMana.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Item_QueryItemMana));
                                OnOrdered_GameAction?.Invoke(this,  data_Item_QueryItemMana);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Item_QueryItemMana));
                                OnItem_QueryItemMana?.Invoke(this, data_Item_QueryItemMana);
                                return data_Item_QueryItemMana;
                            case GameActionType.House_SetHooksVisibility:
                                var data_House_SetHooksVisibility = new House_SetHooksVisibility();
                                data_House_SetHooksVisibility.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_SetHooksVisibility));
                                OnOrdered_GameAction?.Invoke(this,  data_House_SetHooksVisibility);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_SetHooksVisibility));
                                OnHouse_SetHooksVisibility?.Invoke(this, data_House_SetHooksVisibility);
                                return data_House_SetHooksVisibility;
                            case GameActionType.House_ModifyAllegianceGuestPermission:
                                var data_House_ModifyAllegianceGuestPermission = new House_ModifyAllegianceGuestPermission();
                                data_House_ModifyAllegianceGuestPermission.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_ModifyAllegianceGuestPermission));
                                OnOrdered_GameAction?.Invoke(this,  data_House_ModifyAllegianceGuestPermission);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_ModifyAllegianceGuestPermission));
                                OnHouse_ModifyAllegianceGuestPermission?.Invoke(this, data_House_ModifyAllegianceGuestPermission);
                                return data_House_ModifyAllegianceGuestPermission;
                            case GameActionType.House_ModifyAllegianceStoragePermission:
                                var data_House_ModifyAllegianceStoragePermission = new House_ModifyAllegianceStoragePermission();
                                data_House_ModifyAllegianceStoragePermission.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_ModifyAllegianceStoragePermission));
                                OnOrdered_GameAction?.Invoke(this,  data_House_ModifyAllegianceStoragePermission);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_ModifyAllegianceStoragePermission));
                                OnHouse_ModifyAllegianceStoragePermission?.Invoke(this, data_House_ModifyAllegianceStoragePermission);
                                return data_House_ModifyAllegianceStoragePermission;
                            case GameActionType.Game_Join:
                                var data_Game_Join = new Game_Join();
                                data_Game_Join.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Game_Join));
                                OnOrdered_GameAction?.Invoke(this,  data_Game_Join);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Game_Join));
                                OnGame_Join?.Invoke(this, data_Game_Join);
                                return data_Game_Join;
                            case GameActionType.Game_Quit:
                                var data_Game_Quit = new Game_Quit();
                                data_Game_Quit.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Game_Quit));
                                OnOrdered_GameAction?.Invoke(this,  data_Game_Quit);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Game_Quit));
                                OnGame_Quit?.Invoke(this, data_Game_Quit);
                                return data_Game_Quit;
                            case GameActionType.Game_Move:
                                var data_Game_Move = new Game_Move();
                                data_Game_Move.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Game_Move));
                                OnOrdered_GameAction?.Invoke(this,  data_Game_Move);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Game_Move));
                                OnGame_Move?.Invoke(this, data_Game_Move);
                                return data_Game_Move;
                            case GameActionType.Game_MovePass:
                                var data_Game_MovePass = new Game_MovePass();
                                data_Game_MovePass.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Game_MovePass));
                                OnOrdered_GameAction?.Invoke(this,  data_Game_MovePass);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Game_MovePass));
                                OnGame_MovePass?.Invoke(this, data_Game_MovePass);
                                return data_Game_MovePass;
                            case GameActionType.Game_Stalemate:
                                var data_Game_Stalemate = new Game_Stalemate();
                                data_Game_Stalemate.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Game_Stalemate));
                                OnOrdered_GameAction?.Invoke(this,  data_Game_Stalemate);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Game_Stalemate));
                                OnGame_Stalemate?.Invoke(this, data_Game_Stalemate);
                                return data_Game_Stalemate;
                            case GameActionType.House_ListAvailableHouses:
                                var data_House_ListAvailableHouses = new House_ListAvailableHouses();
                                data_House_ListAvailableHouses.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_ListAvailableHouses));
                                OnOrdered_GameAction?.Invoke(this,  data_House_ListAvailableHouses);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_ListAvailableHouses));
                                OnHouse_ListAvailableHouses?.Invoke(this, data_House_ListAvailableHouses);
                                return data_House_ListAvailableHouses;
                            case GameActionType.Character_ConfirmationResponse:
                                var data_Character_ConfirmationResponse = new Character_ConfirmationResponse();
                                data_Character_ConfirmationResponse.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_ConfirmationResponse));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_ConfirmationResponse);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_ConfirmationResponse));
                                OnCharacter_ConfirmationResponse?.Invoke(this, data_Character_ConfirmationResponse);
                                return data_Character_ConfirmationResponse;
                            case GameActionType.Allegiance_BreakAllegianceBoot:
                                var data_Allegiance_BreakAllegianceBoot = new Allegiance_BreakAllegianceBoot();
                                data_Allegiance_BreakAllegianceBoot.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_BreakAllegianceBoot));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_BreakAllegianceBoot);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_BreakAllegianceBoot));
                                OnAllegiance_BreakAllegianceBoot?.Invoke(this, data_Allegiance_BreakAllegianceBoot);
                                return data_Allegiance_BreakAllegianceBoot;
                            case GameActionType.House_TeleToMansion:
                                var data_House_TeleToMansion = new House_TeleToMansion();
                                data_House_TeleToMansion.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_House_TeleToMansion));
                                OnOrdered_GameAction?.Invoke(this,  data_House_TeleToMansion);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_House_TeleToMansion));
                                OnHouse_TeleToMansion?.Invoke(this, data_House_TeleToMansion);
                                return data_House_TeleToMansion;
                            case GameActionType.Character_Suicide:
                                var data_Character_Suicide = new Character_Suicide();
                                data_Character_Suicide.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_Suicide));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_Suicide);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_Suicide));
                                OnCharacter_Suicide?.Invoke(this, data_Character_Suicide);
                                return data_Character_Suicide;
                            case GameActionType.Allegiance_AllegianceInfoRequest:
                                var data_Allegiance_AllegianceInfoRequest = new Allegiance_AllegianceInfoRequest();
                                data_Allegiance_AllegianceInfoRequest.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_AllegianceInfoRequest));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_AllegianceInfoRequest);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_AllegianceInfoRequest));
                                OnAllegiance_AllegianceInfoRequest?.Invoke(this, data_Allegiance_AllegianceInfoRequest);
                                return data_Allegiance_AllegianceInfoRequest;
                            case GameActionType.Inventory_CreateTinkeringTool:
                                var data_Inventory_CreateTinkeringTool = new Inventory_CreateTinkeringTool();
                                data_Inventory_CreateTinkeringTool.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Inventory_CreateTinkeringTool));
                                OnOrdered_GameAction?.Invoke(this,  data_Inventory_CreateTinkeringTool);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Inventory_CreateTinkeringTool));
                                OnInventory_CreateTinkeringTool?.Invoke(this, data_Inventory_CreateTinkeringTool);
                                return data_Inventory_CreateTinkeringTool;
                            case GameActionType.Character_SpellbookFilterEvent:
                                var data_Character_SpellbookFilterEvent = new Character_SpellbookFilterEvent();
                                data_Character_SpellbookFilterEvent.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_SpellbookFilterEvent));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_SpellbookFilterEvent);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_SpellbookFilterEvent));
                                OnCharacter_SpellbookFilterEvent?.Invoke(this, data_Character_SpellbookFilterEvent);
                                return data_Character_SpellbookFilterEvent;
                            case GameActionType.Character_TeleToMarketplace:
                                var data_Character_TeleToMarketplace = new Character_TeleToMarketplace();
                                data_Character_TeleToMarketplace.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_TeleToMarketplace));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_TeleToMarketplace);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_TeleToMarketplace));
                                OnCharacter_TeleToMarketplace?.Invoke(this, data_Character_TeleToMarketplace);
                                return data_Character_TeleToMarketplace;
                            case GameActionType.Character_EnterPKLite:
                                var data_Character_EnterPKLite = new Character_EnterPKLite();
                                data_Character_EnterPKLite.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_EnterPKLite));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_EnterPKLite);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_EnterPKLite));
                                OnCharacter_EnterPKLite?.Invoke(this, data_Character_EnterPKLite);
                                return data_Character_EnterPKLite;
                            case GameActionType.Fellowship_AssignNewLeader:
                                var data_Fellowship_AssignNewLeader = new Fellowship_AssignNewLeader();
                                data_Fellowship_AssignNewLeader.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Fellowship_AssignNewLeader));
                                OnOrdered_GameAction?.Invoke(this,  data_Fellowship_AssignNewLeader);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Fellowship_AssignNewLeader));
                                OnFellowship_AssignNewLeader?.Invoke(this, data_Fellowship_AssignNewLeader);
                                return data_Fellowship_AssignNewLeader;
                            case GameActionType.Fellowship_ChangeFellowOpeness:
                                var data_Fellowship_ChangeFellowOpeness = new Fellowship_ChangeFellowOpeness();
                                data_Fellowship_ChangeFellowOpeness.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Fellowship_ChangeFellowOpeness));
                                OnOrdered_GameAction?.Invoke(this,  data_Fellowship_ChangeFellowOpeness);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Fellowship_ChangeFellowOpeness));
                                OnFellowship_ChangeFellowOpeness?.Invoke(this, data_Fellowship_ChangeFellowOpeness);
                                return data_Fellowship_ChangeFellowOpeness;
                            case GameActionType.Allegiance_AllegianceChatBoot:
                                var data_Allegiance_AllegianceChatBoot = new Allegiance_AllegianceChatBoot();
                                data_Allegiance_AllegianceChatBoot.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_AllegianceChatBoot));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_AllegianceChatBoot);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_AllegianceChatBoot));
                                OnAllegiance_AllegianceChatBoot?.Invoke(this, data_Allegiance_AllegianceChatBoot);
                                return data_Allegiance_AllegianceChatBoot;
                            case GameActionType.Allegiance_AddAllegianceBan:
                                var data_Allegiance_AddAllegianceBan = new Allegiance_AddAllegianceBan();
                                data_Allegiance_AddAllegianceBan.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_AddAllegianceBan));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_AddAllegianceBan);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_AddAllegianceBan));
                                OnAllegiance_AddAllegianceBan?.Invoke(this, data_Allegiance_AddAllegianceBan);
                                return data_Allegiance_AddAllegianceBan;
                            case GameActionType.Allegiance_RemoveAllegianceBan:
                                var data_Allegiance_RemoveAllegianceBan = new Allegiance_RemoveAllegianceBan();
                                data_Allegiance_RemoveAllegianceBan.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_RemoveAllegianceBan));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_RemoveAllegianceBan);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_RemoveAllegianceBan));
                                OnAllegiance_RemoveAllegianceBan?.Invoke(this, data_Allegiance_RemoveAllegianceBan);
                                return data_Allegiance_RemoveAllegianceBan;
                            case GameActionType.Allegiance_ListAllegianceBans:
                                var data_Allegiance_ListAllegianceBans = new Allegiance_ListAllegianceBans();
                                data_Allegiance_ListAllegianceBans.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_ListAllegianceBans));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_ListAllegianceBans);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_ListAllegianceBans));
                                OnAllegiance_ListAllegianceBans?.Invoke(this, data_Allegiance_ListAllegianceBans);
                                return data_Allegiance_ListAllegianceBans;
                            case GameActionType.Allegiance_RemoveAllegianceOfficer:
                                var data_Allegiance_RemoveAllegianceOfficer = new Allegiance_RemoveAllegianceOfficer();
                                data_Allegiance_RemoveAllegianceOfficer.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_RemoveAllegianceOfficer));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_RemoveAllegianceOfficer);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_RemoveAllegianceOfficer));
                                OnAllegiance_RemoveAllegianceOfficer?.Invoke(this, data_Allegiance_RemoveAllegianceOfficer);
                                return data_Allegiance_RemoveAllegianceOfficer;
                            case GameActionType.Allegiance_ListAllegianceOfficers:
                                var data_Allegiance_ListAllegianceOfficers = new Allegiance_ListAllegianceOfficers();
                                data_Allegiance_ListAllegianceOfficers.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_ListAllegianceOfficers));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_ListAllegianceOfficers);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_ListAllegianceOfficers));
                                OnAllegiance_ListAllegianceOfficers?.Invoke(this, data_Allegiance_ListAllegianceOfficers);
                                return data_Allegiance_ListAllegianceOfficers;
                            case GameActionType.Allegiance_ClearAllegianceOfficers:
                                var data_Allegiance_ClearAllegianceOfficers = new Allegiance_ClearAllegianceOfficers();
                                data_Allegiance_ClearAllegianceOfficers.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_ClearAllegianceOfficers));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_ClearAllegianceOfficers);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_ClearAllegianceOfficers));
                                OnAllegiance_ClearAllegianceOfficers?.Invoke(this, data_Allegiance_ClearAllegianceOfficers);
                                return data_Allegiance_ClearAllegianceOfficers;
                            case GameActionType.Allegiance_RecallAllegianceHometown:
                                var data_Allegiance_RecallAllegianceHometown = new Allegiance_RecallAllegianceHometown();
                                data_Allegiance_RecallAllegianceHometown.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Allegiance_RecallAllegianceHometown));
                                OnOrdered_GameAction?.Invoke(this,  data_Allegiance_RecallAllegianceHometown);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Allegiance_RecallAllegianceHometown));
                                OnAllegiance_RecallAllegianceHometown?.Invoke(this, data_Allegiance_RecallAllegianceHometown);
                                return data_Allegiance_RecallAllegianceHometown;
                            case GameActionType.Admin_QueryPluginListResponse:
                                var data_Admin_QueryPluginListResponse = new Admin_QueryPluginListResponse();
                                data_Admin_QueryPluginListResponse.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Admin_QueryPluginListResponse));
                                OnOrdered_GameAction?.Invoke(this,  data_Admin_QueryPluginListResponse);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Admin_QueryPluginListResponse));
                                OnAdmin_QueryPluginListResponse?.Invoke(this, data_Admin_QueryPluginListResponse);
                                return data_Admin_QueryPluginListResponse;
                            case GameActionType.Admin_QueryPluginResponse:
                                var data_Admin_QueryPluginResponse = new Admin_QueryPluginResponse();
                                data_Admin_QueryPluginResponse.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Admin_QueryPluginResponse));
                                OnOrdered_GameAction?.Invoke(this,  data_Admin_QueryPluginResponse);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Admin_QueryPluginResponse));
                                OnAdmin_QueryPluginResponse?.Invoke(this, data_Admin_QueryPluginResponse);
                                return data_Admin_QueryPluginResponse;
                            case GameActionType.Character_FinishBarber:
                                var data_Character_FinishBarber = new Character_FinishBarber();
                                data_Character_FinishBarber.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_FinishBarber));
                                OnOrdered_GameAction?.Invoke(this,  data_Character_FinishBarber);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Character_FinishBarber));
                                OnCharacter_FinishBarber?.Invoke(this, data_Character_FinishBarber);
                                return data_Character_FinishBarber;
                            case GameActionType.Social_AbandonContract:
                                var data_Social_AbandonContract = new Social_AbandonContract();
                                data_Social_AbandonContract.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Social_AbandonContract));
                                OnOrdered_GameAction?.Invoke(this,  data_Social_AbandonContract);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Social_AbandonContract));
                                OnSocial_AbandonContract?.Invoke(this, data_Social_AbandonContract);
                                return data_Social_AbandonContract;
                            case GameActionType.Movement_Jump:
                                var data_Movement_Jump = new Movement_Jump();
                                data_Movement_Jump.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Movement_Jump));
                                OnOrdered_GameAction?.Invoke(this,  data_Movement_Jump);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Movement_Jump));
                                OnMovement_Jump?.Invoke(this, data_Movement_Jump);
                                return data_Movement_Jump;
                            case GameActionType.Movement_MoveToState:
                                var data_Movement_MoveToState = new Movement_MoveToState();
                                data_Movement_MoveToState.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Movement_MoveToState));
                                OnOrdered_GameAction?.Invoke(this,  data_Movement_MoveToState);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Movement_MoveToState));
                                OnMovement_MoveToState?.Invoke(this, data_Movement_MoveToState);
                                return data_Movement_MoveToState;
                            case GameActionType.Movement_DoMovementCommand:
                                var data_Movement_DoMovementCommand = new Movement_DoMovementCommand();
                                data_Movement_DoMovementCommand.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Movement_DoMovementCommand));
                                OnOrdered_GameAction?.Invoke(this,  data_Movement_DoMovementCommand);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Movement_DoMovementCommand));
                                OnMovement_DoMovementCommand?.Invoke(this, data_Movement_DoMovementCommand);
                                return data_Movement_DoMovementCommand;
                            case GameActionType.Movement_StopMovementCommand:
                                var data_Movement_StopMovementCommand = new Movement_StopMovementCommand();
                                data_Movement_StopMovementCommand.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Movement_StopMovementCommand));
                                OnOrdered_GameAction?.Invoke(this,  data_Movement_StopMovementCommand);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Movement_StopMovementCommand));
                                OnMovement_StopMovementCommand?.Invoke(this, data_Movement_StopMovementCommand);
                                return data_Movement_StopMovementCommand;
                            case GameActionType.Movement_AutonomyLevel:
                                var data_Movement_AutonomyLevel = new Movement_AutonomyLevel();
                                data_Movement_AutonomyLevel.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Movement_AutonomyLevel));
                                OnOrdered_GameAction?.Invoke(this,  data_Movement_AutonomyLevel);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Movement_AutonomyLevel));
                                OnMovement_AutonomyLevel?.Invoke(this, data_Movement_AutonomyLevel);
                                return data_Movement_AutonomyLevel;
                            case GameActionType.Movement_AutonomousPosition:
                                var data_Movement_AutonomousPosition = new Movement_AutonomousPosition();
                                data_Movement_AutonomousPosition.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Movement_AutonomousPosition));
                                OnOrdered_GameAction?.Invoke(this,  data_Movement_AutonomousPosition);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Movement_AutonomousPosition));
                                OnMovement_AutonomousPosition?.Invoke(this, data_Movement_AutonomousPosition);
                                return data_Movement_AutonomousPosition;
                            case GameActionType.Movement_Jump_NonAutonomous:
                                var data_Movement_Jump_NonAutonomous = new Movement_Jump_NonAutonomous();
                                data_Movement_Jump_NonAutonomous.Read(reader);
                                OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Movement_Jump_NonAutonomous));
                                OnOrdered_GameAction?.Invoke(this,  data_Movement_Jump_NonAutonomous);
                                OnGameAction?.Invoke(this, new GameActionEventArgs(actionType, data_Movement_Jump_NonAutonomous));
                                OnMovement_Jump_NonAutonomous?.Invoke(this, data_Movement_Jump_NonAutonomous);
                                return data_Movement_Jump_NonAutonomous;
                        }
                        return null; // end 0xF7B1
    
                    case C2SMessageType.Login_LogOffCharacter:
                        var data_Login_LogOffCharacter = new Login_LogOffCharacter();
                        data_Login_LogOffCharacter.Read(reader);
                        OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Login_LogOffCharacter));
                        OnLogin_LogOffCharacter?.Invoke(this, data_Login_LogOffCharacter);
                        return data_Login_LogOffCharacter;
    
                    case C2SMessageType.Character_CharacterDelete:
                        var data_Character_CharacterDelete = new Character_CharacterDelete();
                        data_Character_CharacterDelete.Read(reader);
                        OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_CharacterDelete));
                        OnCharacter_CharacterDelete?.Invoke(this, data_Character_CharacterDelete);
                        return data_Character_CharacterDelete;
    
                    case C2SMessageType.Character_SendCharGenResult:
                        var data_Character_SendCharGenResult = new Character_SendCharGenResult();
                        data_Character_SendCharGenResult.Read(reader);
                        OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Character_SendCharGenResult));
                        OnCharacter_SendCharGenResult?.Invoke(this, data_Character_SendCharGenResult);
                        return data_Character_SendCharGenResult;
    
                    case C2SMessageType.Login_SendEnterWorld:
                        var data_Login_SendEnterWorld = new Login_SendEnterWorld();
                        data_Login_SendEnterWorld.Read(reader);
                        OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Login_SendEnterWorld));
                        OnLogin_SendEnterWorld?.Invoke(this, data_Login_SendEnterWorld);
                        return data_Login_SendEnterWorld;
    
                    case C2SMessageType.Object_SendForceObjdesc:
                        var data_Object_SendForceObjdesc = new Object_SendForceObjdesc();
                        data_Object_SendForceObjdesc.Read(reader);
                        OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Object_SendForceObjdesc));
                        OnObject_SendForceObjdesc?.Invoke(this, data_Object_SendForceObjdesc);
                        return data_Object_SendForceObjdesc;
    
                    case C2SMessageType.Login_SendEnterWorldRequest:
                        var data_Login_SendEnterWorldRequest = new Login_SendEnterWorldRequest();
                        data_Login_SendEnterWorldRequest.Read(reader);
                        OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Login_SendEnterWorldRequest));
                        OnLogin_SendEnterWorldRequest?.Invoke(this, data_Login_SendEnterWorldRequest);
                        return data_Login_SendEnterWorldRequest;
    
                    case C2SMessageType.Admin_SendAdminGetServerVersion:
                        var data_Admin_SendAdminGetServerVersion = new Admin_SendAdminGetServerVersion();
                        data_Admin_SendAdminGetServerVersion.Read(reader);
                        OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Admin_SendAdminGetServerVersion));
                        OnAdmin_SendAdminGetServerVersion?.Invoke(this, data_Admin_SendAdminGetServerVersion);
                        return data_Admin_SendAdminGetServerVersion;
    
                    case C2SMessageType.Social_SendFriendsCommand:
                        var data_Social_SendFriendsCommand = new Social_SendFriendsCommand();
                        data_Social_SendFriendsCommand.Read(reader);
                        OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Social_SendFriendsCommand));
                        OnSocial_SendFriendsCommand?.Invoke(this, data_Social_SendFriendsCommand);
                        return data_Social_SendFriendsCommand;
    
                    case C2SMessageType.Admin_SendAdminRestoreCharacter:
                        var data_Admin_SendAdminRestoreCharacter = new Admin_SendAdminRestoreCharacter();
                        data_Admin_SendAdminRestoreCharacter.Read(reader);
                        OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Admin_SendAdminRestoreCharacter));
                        OnAdmin_SendAdminRestoreCharacter?.Invoke(this, data_Admin_SendAdminRestoreCharacter);
                        return data_Admin_SendAdminRestoreCharacter;
    
                    case C2SMessageType.Communication_TurbineChat:
                        var data_Communication_TurbineChat = new Communication_TurbineChat();
                        data_Communication_TurbineChat.Read(reader);
                        OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_Communication_TurbineChat));
                        OnCommunication_TurbineChat?.Invoke(this, data_Communication_TurbineChat);
                        return data_Communication_TurbineChat;
    
                    case C2SMessageType.DDD_RequestDataMessage:
                        var data_DDD_RequestDataMessage = new DDD_RequestDataMessage();
                        data_DDD_RequestDataMessage.Read(reader);
                        OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_DDD_RequestDataMessage));
                        OnDDD_RequestDataMessage?.Invoke(this, data_DDD_RequestDataMessage);
                        return data_DDD_RequestDataMessage;
    
                    case C2SMessageType.DDD_InterrogationResponseMessage:
                        var data_DDD_InterrogationResponseMessage = new DDD_InterrogationResponseMessage();
                        data_DDD_InterrogationResponseMessage.Read(reader);
                        OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_DDD_InterrogationResponseMessage));
                        OnDDD_InterrogationResponseMessage?.Invoke(this, data_DDD_InterrogationResponseMessage);
                        return data_DDD_InterrogationResponseMessage;
    
                    case C2SMessageType.DDD_EndDDDMessage:
                        var data_DDD_EndDDDMessage = new DDD_EndDDDMessage();
                        data_DDD_EndDDDMessage.Read(reader);
                        OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_DDD_EndDDDMessage));
                        OnDDD_EndDDDMessage?.Invoke(this, data_DDD_EndDDDMessage);
                        return data_DDD_EndDDDMessage;
    
                    case C2SMessageType.DDD_OnEndDDD:
                        var data_DDD_OnEndDDD = new DDD_OnEndDDD();
                        data_DDD_OnEndDDD.Read(reader);
                        OnMessage?.Invoke(this, new C2SMessageEventArgs(opcode, data_DDD_OnEndDDD));
                        OnDDD_OnEndDDD?.Invoke(this, data_DDD_OnEndDDD);
                        return data_DDD_OnEndDDD;
    
                default:
                    var rawData = reader.ReadBytes((int)(reader.BaseStream.Length - reader.BaseStream.Position));
                    OnUnknownMessage?.Invoke(this, new UnknownMessageEventArgs(MessageDirection.ClientToServer, (uint)opcode, rawData));
                    return null;
            }
        }
    }
}

        