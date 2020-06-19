using Sdl.Desktop.IntegrationApi;
using System;
using System.Windows.Forms;

namespace ContextSegmentLocker
{
    public class ContextSegmentLockerTaskSettingsControl : UserControl, ISettingsAware<ContextSegmentLockerTaskSettings>
    {
        private CheckBox cb_paragraph;
        private CheckBox cb_link;
        private CheckBox cb_id;
        private CheckBox cb_note;
        private CheckBox cb_title;
        private CheckBox cb_meta;
        private Label label1;

        // Member that refers to the batch task settings
        public ContextSegmentLockerTaskSettings Settings { get; set; }

        public ContextSegmentLockerTaskSettingsControl()
        {
            InitializeComponent();
        }

        private void SetSettings(ContextSegmentLockerTaskSettings taskSettings)
        {
            // sets the UI element, i.e. the status dropdown list to the corresponding segment status value
            Settings = taskSettings;

            SettingsBinder.DataBindSetting<bool>(cb_paragraph, "Checked", Settings, nameof(Settings.ParagraphCheck));
            SettingsBinder.DataBindSetting<bool>(cb_link, "Checked", Settings, nameof(Settings.LinkCheck));
            SettingsBinder.DataBindSetting<bool>(cb_id, "Checked", Settings, nameof(Settings.IdCheck));
            SettingsBinder.DataBindSetting<bool>(cb_title, "Checked", Settings, nameof(Settings.TitleCheck));
            SettingsBinder.DataBindSetting<bool>(cb_note, "Checked", Settings, nameof(Settings.NoteCheck));
            SettingsBinder.DataBindSetting<bool>(cb_meta, "Checked", Settings, nameof(Settings.MetaCheck));

            UpdateUi(taskSettings);
        }

        private void UpdateSettings(ContextSegmentLockerTaskSettings mySettings)
        {
            Settings = mySettings;
        }

        // Updates the UI elements to the corresponding settings
        private void UpdateUi(ContextSegmentLockerTaskSettings mySettings)
        {
            Settings = mySettings;
            this.UpdateSettings(Settings);
        }


        // The control elements on the UI are configured with the corresponding values
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.SetSettings(Settings);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cb_paragraph = new System.Windows.Forms.CheckBox();
            this.cb_link = new System.Windows.Forms.CheckBox();
            this.cb_id = new System.Windows.Forms.CheckBox();
            this.cb_note = new System.Windows.Forms.CheckBox();
            this.cb_title = new System.Windows.Forms.CheckBox();
            this.cb_meta = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select context elements to lock: ";
            // 
            // cb_paragraph
            // 
            this.cb_paragraph.AutoSize = true;
            this.cb_paragraph.Location = new System.Drawing.Point(28, 51);
            this.cb_paragraph.Name = "cb_paragraph";
            this.cb_paragraph.Size = new System.Drawing.Size(97, 21);
            this.cb_paragraph.TabIndex = 3;
            this.cb_paragraph.Text = "Paragraph";
            this.cb_paragraph.UseVisualStyleBackColor = true;
            // 
            // cb_link
            // 
            this.cb_link.AutoSize = true;
            this.cb_link.Location = new System.Drawing.Point(28, 78);
            this.cb_link.Name = "cb_link";
            this.cb_link.Size = new System.Drawing.Size(56, 21);
            this.cb_link.TabIndex = 4;
            this.cb_link.Text = "Link";
            this.cb_link.UseVisualStyleBackColor = true;
            // 
            // cb_id
            // 
            this.cb_id.AutoSize = true;
            this.cb_id.Location = new System.Drawing.Point(28, 105);
            this.cb_id.Name = "cb_id";
            this.cb_id.Size = new System.Drawing.Size(43, 21);
            this.cb_id.TabIndex = 5;
            this.cb_id.Text = "ID";
            this.cb_id.UseVisualStyleBackColor = true;
            // 
            // cb_note
            // 
            this.cb_note.AutoSize = true;
            this.cb_note.Location = new System.Drawing.Point(28, 132);
            this.cb_note.Name = "cb_note";
            this.cb_note.Size = new System.Drawing.Size(60, 21);
            this.cb_note.TabIndex = 6;
            this.cb_note.Text = "Note";
            this.cb_note.UseVisualStyleBackColor = true;
            // 
            // cb_title
            // 
            this.cb_title.AutoSize = true;
            this.cb_title.Location = new System.Drawing.Point(28, 159);
            this.cb_title.Name = "cb_title";
            this.cb_title.Size = new System.Drawing.Size(57, 21);
            this.cb_title.TabIndex = 7;
            this.cb_title.Text = "Title";
            this.cb_title.UseVisualStyleBackColor = true;
            // 
            // cb_meta
            // 
            this.cb_meta.AutoSize = true;
            this.cb_meta.Location = new System.Drawing.Point(28, 186);
            this.cb_meta.Name = "cb_meta";
            this.cb_meta.Size = new System.Drawing.Size(61, 21);
            this.cb_meta.TabIndex = 8;
            this.cb_meta.Text = "Meta";
            this.cb_meta.UseVisualStyleBackColor = true;
            // 
            // MyCustomBatchTaskSettingsControl
            // 
            this.Controls.Add(this.cb_meta);
            this.Controls.Add(this.cb_title);
            this.Controls.Add(this.cb_note);
            this.Controls.Add(this.cb_id);
            this.Controls.Add(this.cb_link);
            this.Controls.Add(this.cb_paragraph);
            this.Controls.Add(this.label1);
            this.Name = "MyCustomBatchTaskSettingsControl";
            this.Size = new System.Drawing.Size(469, 528);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
