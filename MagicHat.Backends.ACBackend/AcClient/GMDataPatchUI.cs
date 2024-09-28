using AcClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcClient {
    public unsafe struct gmDataPatchUI {
        public UIMainFramework a0;
        public CDDDStatusPlugin a1;
        public gmNoticeHandler a2;
        public CPlayerSystem* m_pPlayerSystem;
        public UIElement* m_datapatchField;
        public UIElement_Text* m_connectText;
        public UIElement_Text* m_patchText;
        public UIElement* m_patchMeter;
        public float m_fConnectLevel;
        public float m_fPatchLevel;
        public uint m_expected;
        public uint m_recieved;
        public double m_timeNextDiskspaceCheck;
    }
}
