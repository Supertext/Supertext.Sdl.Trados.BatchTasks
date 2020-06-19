using System.Collections.Generic;
using System.ComponentModel;
using Sdl.Core.Settings;

namespace ContextSegmentLocker
{
    public class ContextSegmentLockerTaskSettings : SettingsGroup
    {
        public bool ParagraphCheck => GetSetting<bool>(nameof(ParagraphCheck));
        public bool LinkCheck => GetSetting<bool>(nameof(LinkCheck));
        public bool IdCheck => GetSetting<bool>(nameof(IdCheck));
        public bool NoteCheck => GetSetting<bool>(nameof(NoteCheck));
        public bool TitleCheck => GetSetting<bool>(nameof(TitleCheck));
        public bool MetaCheck => GetSetting<bool>(nameof(MetaCheck));

    }
}
