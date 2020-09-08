using System.Collections.Generic;
using ContextSegmentLocker.Settings;
using Sdl.FileTypeSupport.Framework.BilingualApi;

namespace ContextSegmentLocker
{
    public class SegmentLockerPreProcessor : AbstractBilingualContentHandler
    {
        private readonly List<string> _contextList;
        private readonly bool _clearLockedSegments;
        private readonly string _otherContextName;

        public SegmentLockerPreProcessor(List<SettingItemsEnum> items, string otherContextName, bool clearLockedSegments)
        {
            _contextList = items.ConvertAll(f => f.ToString());
            _otherContextName = otherContextName;
            _clearLockedSegments = clearLockedSegments;
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

                        if (_clearLockedSegments)
                        {
                            paragraphUnit.Target.Clear();
                        }
                    }
                }

                //special handling for "Other". A bit hacky....
                if (_contextList.Contains("Other"))
                {
                    if (_otherContextName == context.DisplayName)
                    {
                        foreach (var segmentPair in paragraphUnit.SegmentPairs)
                        {
                            segmentPair.Properties.IsLocked = true;

                            if (_clearLockedSegments)
                            {
                                paragraphUnit.Target.Clear();
                            }
                        }
                    }
                }
            }
        }
    }
}