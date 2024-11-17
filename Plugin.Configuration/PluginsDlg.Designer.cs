namespace Plugin.Configuration
{
	partial class PluginsDlg
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.ColumnHeader colName;
			System.Windows.Forms.GroupBox gbInformation;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginsDlg));
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.txtSource = new System.Windows.Forms.TextBox();
			this.txtAuthor = new System.Windows.Forms.TextBox();
			this.txtVersion = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.splitMain = new System.Windows.Forms.SplitContainer();
			this.splitInformation = new System.Windows.Forms.SplitContainer();
			this.lvPlugins = new System.Windows.Forms.ListView();
			this.ilPlugin = new System.Windows.Forms.ImageList(this.components);
			this.tsSearch = new System.Windows.Forms.ToolStrip();
			this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
			this.bnSearch = new System.Windows.Forms.ToolStripButton();
			this.tabMain = new System.Windows.Forms.TabControl();
			this.tabOptions = new System.Windows.Forms.TabPage();
			this.ctlOptions = new Plugin.Configuration.OptionsCtrl();
			this.tabSettings = new System.Windows.Forms.TabPage();
			this.pgSettings = new System.Windows.Forms.PropertyGrid();
			this.cmsSettings = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmiSettingsReset = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiSettingsDescription = new System.Windows.Forms.ToolStripMenuItem();
			this.cmsPlugin = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmiReset = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiUnload = new System.Windows.Forms.ToolStripMenuItem();
			this.tt = new System.Windows.Forms.ToolTip(this.components);
			this.tCloseInfo = new System.Windows.Forms.Timer(this.components);
			colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			gbInformation = new System.Windows.Forms.GroupBox();
			gbInformation.SuspendLayout();
			this.splitMain.Panel1.SuspendLayout();
			this.splitMain.Panel2.SuspendLayout();
			this.splitMain.SuspendLayout();
			this.splitInformation.Panel1.SuspendLayout();
			this.splitInformation.Panel2.SuspendLayout();
			this.splitInformation.SuspendLayout();
			this.tsSearch.SuspendLayout();
			this.tabMain.SuspendLayout();
			this.tabOptions.SuspendLayout();
			this.tabSettings.SuspendLayout();
			this.cmsSettings.SuspendLayout();
			this.cmsPlugin.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbInformation
			// 
			gbInformation.Controls.Add(this.txtDescription);
			gbInformation.Controls.Add(this.txtSource);
			gbInformation.Controls.Add(this.txtAuthor);
			gbInformation.Controls.Add(this.txtVersion);
			gbInformation.Controls.Add(this.txtName);
			resources.ApplyResources(gbInformation, "gbInformation");
			gbInformation.Name = "gbInformation";
			gbInformation.TabStop = false;
			// 
			// txtDescription
			// 
			resources.ApplyResources(this.txtDescription, "txtDescription");
			this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.ReadOnly = true;
			this.tt.SetToolTip(this.txtDescription, resources.GetString("txtDescription.ToolTip"));
			this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItem_KeyDown);
			// 
			// txtSource
			// 
			resources.ApplyResources(this.txtSource, "txtSource");
			this.txtSource.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtSource.Name = "txtSource";
			this.txtSource.ReadOnly = true;
			this.tt.SetToolTip(this.txtSource, resources.GetString("txtSource.ToolTip"));
			this.txtSource.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItem_KeyDown);
			// 
			// txtAuthor
			// 
			resources.ApplyResources(this.txtAuthor, "txtAuthor");
			this.txtAuthor.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtAuthor.Name = "txtAuthor";
			this.txtAuthor.ReadOnly = true;
			this.tt.SetToolTip(this.txtAuthor, resources.GetString("txtAuthor.ToolTip"));
			this.txtAuthor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItem_KeyDown);
			// 
			// txtVersion
			// 
			resources.ApplyResources(this.txtVersion, "txtVersion");
			this.txtVersion.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtVersion.Name = "txtVersion";
			this.txtVersion.ReadOnly = true;
			this.tt.SetToolTip(this.txtVersion, resources.GetString("txtVersion.ToolTip"));
			this.txtVersion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItem_KeyDown);
			// 
			// txtName
			// 
			resources.ApplyResources(this.txtName, "txtName");
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtName.Name = "txtName";
			this.txtName.ReadOnly = true;
			this.tt.SetToolTip(this.txtName, resources.GetString("txtName.ToolTip"));
			this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItem_KeyDown);
			// 
			// splitMain
			// 
			resources.ApplyResources(this.splitMain, "splitMain");
			this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitMain.Name = "splitMain";
			// 
			// splitMain.Panel1
			// 
			this.splitMain.Panel1.Controls.Add(this.splitInformation);
			// 
			// splitMain.Panel2
			// 
			this.splitMain.Panel2.Controls.Add(this.tabMain);
			// 
			// splitInformation
			// 
			resources.ApplyResources(this.splitInformation, "splitInformation");
			this.splitInformation.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitInformation.Name = "splitInformation";
			// 
			// splitInformation.Panel1
			// 
			this.splitInformation.Panel1.Controls.Add(this.lvPlugins);
			this.splitInformation.Panel1.Controls.Add(this.tsSearch);
			// 
			// splitInformation.Panel2
			// 
			this.splitInformation.Panel2.Controls.Add(gbInformation);
			// 
			// lvPlugins
			// 
			this.lvPlugins.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            colName});
			resources.ApplyResources(this.lvPlugins, "lvPlugins");
			this.lvPlugins.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvPlugins.HideSelection = false;
			this.lvPlugins.MultiSelect = false;
			this.lvPlugins.Name = "lvPlugins";
			this.lvPlugins.SmallImageList = this.ilPlugin;
			this.lvPlugins.UseCompatibleStateImageBehavior = false;
			this.lvPlugins.View = System.Windows.Forms.View.Details;
			this.lvPlugins.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvPlugins_ItemSelectionChanged);
			this.lvPlugins.SizeChanged += new System.EventHandler(this.lvPlugins_SizeChanged);
			this.lvPlugins.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvPlugins_KeyDown);
			this.lvPlugins.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvPlugins_MouseDown);
			// 
			// ilPlugin
			// 
			this.ilPlugin.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilPlugin.ImageStream")));
			this.ilPlugin.TransparentColor = System.Drawing.Color.Fuchsia;
			this.ilPlugin.Images.SetKeyName(0, "imageOptions.bmp");
			// 
			// tsSearch
			// 
			this.tsSearch.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tsSearch.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.tsSearch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtSearch,
            this.bnSearch});
			this.tsSearch.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			resources.ApplyResources(this.tsSearch, "tsSearch");
			this.tsSearch.Name = "tsSearch";
			this.tsSearch.Resize += new System.EventHandler(this.tsSearch_Resize);
			// 
			// txtSearch
			// 
			resources.ApplyResources(this.txtSearch, "txtSearch");
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			// 
			// bnSearch
			// 
			this.bnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.bnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(this.bnSearch, "bnSearch");
			this.bnSearch.Name = "bnSearch";
			this.bnSearch.Click += new System.EventHandler(this.bnSearch_Click);
			// 
			// tabMain
			// 
			this.tabMain.Controls.Add(this.tabOptions);
			this.tabMain.Controls.Add(this.tabSettings);
			resources.ApplyResources(this.tabMain, "tabMain");
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
			// 
			// tabOptions
			// 
			this.tabOptions.Controls.Add(this.ctlOptions);
			resources.ApplyResources(this.tabOptions, "tabOptions");
			this.tabOptions.Name = "tabOptions";
			this.tabOptions.UseVisualStyleBackColor = true;
			// 
			// ctlOptions
			// 
			resources.ApplyResources(this.ctlOptions, "ctlOptions");
			this.ctlOptions.Name = "ctlOptions";
			// 
			// tabSettings
			// 
			this.tabSettings.Controls.Add(this.pgSettings);
			resources.ApplyResources(this.tabSettings, "tabSettings");
			this.tabSettings.Name = "tabSettings";
			this.tabSettings.UseVisualStyleBackColor = true;
			// 
			// pgSettings
			// 
			this.pgSettings.ContextMenuStrip = this.cmsSettings;
			resources.ApplyResources(this.pgSettings, "pgSettings");
			this.pgSettings.LineColor = System.Drawing.SystemColors.ControlDark;
			this.pgSettings.Name = "pgSettings";
			this.pgSettings.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgSettings_PropertyValueChanged);
			// 
			// cmsSettings
			// 
			this.cmsSettings.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.cmsSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSettingsReset,
            this.tsmiSettingsDescription});
			this.cmsSettings.Name = "cmsSettings";
			resources.ApplyResources(this.cmsSettings, "cmsSettings");
			this.cmsSettings.Opening += new System.ComponentModel.CancelEventHandler(this.cmsSettings_Opening);
			this.cmsSettings.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsSettings_ItemClicked);
			// 
			// tsmiSettingsReset
			// 
			this.tsmiSettingsReset.Name = "tsmiSettingsReset";
			resources.ApplyResources(this.tsmiSettingsReset, "tsmiSettingsReset");
			// 
			// tsmiSettingsDescription
			// 
			this.tsmiSettingsDescription.Name = "tsmiSettingsDescription";
			resources.ApplyResources(this.tsmiSettingsDescription, "tsmiSettingsDescription");
			// 
			// cmsPlugin
			// 
			this.cmsPlugin.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.cmsPlugin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReset,
            this.tsmiUnload});
			this.cmsPlugin.Name = "cmsPlugin";
			resources.ApplyResources(this.cmsPlugin, "cmsPlugin");
			this.cmsPlugin.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsPlugin_ItemClicked);
			// 
			// tsmiReset
			// 
			this.tsmiReset.Name = "tsmiReset";
			resources.ApplyResources(this.tsmiReset, "tsmiReset");
			// 
			// tsmiUnload
			// 
			this.tsmiUnload.Name = "tsmiUnload";
			resources.ApplyResources(this.tsmiUnload, "tsmiUnload");
			// 
			// tCloseInfo
			// 
			this.tCloseInfo.Tick += new System.EventHandler(this.tCloseInfo_Tick);
			// 
			// PluginsDlg
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PluginsDlg";
			this.Load += new System.EventHandler(this.PluginsDlg_Load);
			gbInformation.ResumeLayout(false);
			gbInformation.PerformLayout();
			this.splitMain.Panel1.ResumeLayout(false);
			this.splitMain.Panel2.ResumeLayout(false);
			this.splitMain.ResumeLayout(false);
			this.splitInformation.Panel1.ResumeLayout(false);
			this.splitInformation.Panel1.PerformLayout();
			this.splitInformation.Panel2.ResumeLayout(false);
			this.splitInformation.ResumeLayout(false);
			this.tsSearch.ResumeLayout(false);
			this.tsSearch.PerformLayout();
			this.tabMain.ResumeLayout(false);
			this.tabOptions.ResumeLayout(false);
			this.tabSettings.ResumeLayout(false);
			this.cmsSettings.ResumeLayout(false);
			this.cmsPlugin.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitMain;
		private System.Windows.Forms.ListView lvPlugins;
		private System.Windows.Forms.ContextMenuStrip cmsPlugin;
		private System.Windows.Forms.ToolStripMenuItem tsmiReset;
		private System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.TabPage tabSettings;
		private System.Windows.Forms.PropertyGrid pgSettings;
		private System.Windows.Forms.ImageList ilPlugin;
		private System.Windows.Forms.TabPage tabOptions;
		private System.Windows.Forms.ToolStripMenuItem tsmiUnload;
		private System.Windows.Forms.SplitContainer splitInformation;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.ToolTip tt;
		private System.Windows.Forms.TextBox txtSource;
		private System.Windows.Forms.TextBox txtAuthor;
		private System.Windows.Forms.TextBox txtVersion;
		private OptionsCtrl ctlOptions;
		private System.Windows.Forms.Timer tCloseInfo;
		private System.Windows.Forms.ContextMenuStrip cmsSettings;
		private System.Windows.Forms.ToolStripMenuItem tsmiSettingsReset;
		private System.Windows.Forms.ToolStripMenuItem tsmiSettingsDescription;
		private System.Windows.Forms.ToolStrip tsSearch;
		private System.Windows.Forms.ToolStripTextBox txtSearch;
		private System.Windows.Forms.ToolStripButton bnSearch;
	}
}