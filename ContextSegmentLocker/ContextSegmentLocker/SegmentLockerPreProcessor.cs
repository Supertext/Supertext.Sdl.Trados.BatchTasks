using System.Collections.Generic;
using ContextSegmentLocker.Settings;
using Sdl.FileTypeSupport.Framework.BilingualApi;

namespace ContextSegmentLocker
{
    public class SegmentLockerPreProcessor : AbstractBilingualContentHandler
    {
        private readonly List<string> _contextList;

        public SegmentLockerPreProcessor(List<SettingItemsEnum> items)
        {
            _contextList = items.ConvertAll(f => f.ToString());
        }

        public override void ProcessParagraphUnit(IParagraphUnit paragraphUnit)
        {
            base.ProcessParagraphUnit(paragraphUnit);
            if (paragraphUnit.IsStructure) { return; }
            if (paragraphUnit.Properties.Contexts == null) { return; }

            foreach (var context in paragraphUnit.Properties.Contexts.Contexts)
            {
                if (_contextList.Contains(context.DisplayName))
                {
                    foreach (var segmentPair in paragraphUnit.SegmentPairs)
                    {
                        segmentPair.Properties.IsLocked = true;
                    }
                }
            }
        }
    }
}