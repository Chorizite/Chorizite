using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcClient {
    unsafe struct ChatInterface {
        public gmNoticeHandler a0;
        public UIElement_Field a1;
        public uint m_eWindowID;
        public float m_fDefaultOpacity;
        public float m_fActiveOpacity;
        public float m_fCurrentOpacity;
        public UIElement_Text* m_chatEntry;
        public UIElement_Text* m_chatLog;
        public UIElement* m_chatNewNonVisibleTextIndicator;
        public ulong m_llTextTypeFilter;
        public UIElement_Text* m_pChatTargetButtonText;
        /*
        public PStringBaseArray<ushort> m_InputHistory;
        public uint m_LastInputHistoryPos;
        public ClientCommunicationSystem* m_pCCS;
        */
};
}
