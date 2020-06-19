using System.Collections.Generic;
using ContextSegmentLocker.Settings;
using Sdl.ProjectAutomation.AutomaticTasks;
using Sdl.FileTypeSupport.Framework.IntegrationApi;
using Sdl.ProjectAutomation.Core;

namespace ContextSegmentLocker
{
    [AutomaticTask("My_Custom_Batch_Task_ID",
                   "My_Custom_Batch_Task_Name",
                   "My_Custom_Batch_Task_Description",
                   GeneratedFileType = AutomaticTaskFileType.BilingualTarget)]
    [AutomaticTaskSupportedFileType(AutomaticTaskFileType.BilingualTarget)]
    [RequiresSettings(typeof(ContextSegmentLockerTaskSettings), typeof(ContextSegmentLockerTaskSettingsPage))]
    public class ContextSegmentLockerBatchTask : AbstractFileContentProcessingAutomaticTask
    {
        private ContextSegmentLockerTaskSettings _settings;

        protected override void OnInitializeTask()
        {
            base.OnInitializeTask();

            _settings = GetSetting<ContextSegmentLockerTaskSettings>();
        }

        public override bool OnFileComplete(ProjectFile projectFile, IMultiFileConverter multiFileConverter)
        {
            return true;
        }

        protected override void ConfigureConverter(ProjectFile projectFile, IMultiFileConverter multiFileConverter)
        {
            var segmentsToLock = GetSegmentListFromSettings();
            //In here you should add your custom bilingual processor to the file converter
            multiFileConverter.AddBilingualProcessor(
                    new Sdl.FileTypeSupport.Framework.Core.Utilities.BilingualApi.BilingualContentHandlerAdapter(new SegmentLockerPreProcessor(segmentsToLock)));
        }

        private List<SettingItemsEnum> GetSegmentListFromSettings()
        {
            var lockedSegments = new List<SettingItemsEnum>();

            if (_settings.ParagraphCheck)
            {
                lockedSegments.Add(SettingItemsEnum.Paragraph);
            }
            if (_settings.LinkCheck)
            {
                lockedSegments.Add(SettingItemsEnum.Link);
            }
            if (_settings.IdCheck)
            {
                lockedSegments.Add(SettingItemsEnum.Id);
            }
            if (_settings.NoteCheck)
            {
                lockedSegments.Add(SettingItemsEnum.Note);
            }
            if (_settings.TitleCheck)
            {
                lockedSegments.Add(SettingItemsEnum.Title);
            }
            if (_settings.MetaCheck)
            {
                lockedSegments.Add(SettingItemsEnum.Meta);
            }

            return lockedSegments;
        }
    }
}
