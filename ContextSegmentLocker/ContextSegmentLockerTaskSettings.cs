using System.Collections.Generic;
using System.ComponentModel;
using Sdl.Core.Settings;

namespace ContextSegmentLocker
{
    public class ContextSegmentLockerTaskSettings : SettingsGroup
    {
        public bool ParagraphCheck => GetSetting<bool>(nameof(ParagraphCheck), false);
        public bool LinkCheck => GetSetting<bool>(nameof(LinkCheck), false);
        public bool IdCheck => GetSetting<bool>(nameof(IdCheck), false);
        public bool NoteCheck => GetSetting<bool>(nameof(NoteCheck), false);
        public bool TitleCheck => GetSetting<bool>(nameof(TitleCheck), false);
        public bool MetaCheck => GetSetting<bool>(nameof(MetaCheck), false);
        public bool OtherCheck => GetSetting<bool>(nameof(OtherCheck), false);
        public string OtherTextbox => GetSetting<string>(nameof(OtherTextbox), "");
        public bool ClearCheck => GetSetting<bool>(nameof(ClearCheck), false);

    }
}
