using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Plugin.Configuration.Properties;
using SAL.Flatbed;
using SAL.Windows;

namespace Plugin.Configuration
{
	internal partial class PluginsDlg : Form
	{
		protected PluginWindows Plugin { get; private set; }

		/// <summary>The selected plugin in the list</summary>
		protected IPluginDescription SelectedPlugin
		{
			get => lvPlugins.SelectedItems.Count > 0 ? (IPluginDescription)lvPlugins.SelectedItems[0].Tag : null;
		}

		public PluginsDlg(PluginWindows plugin)
		{
			this.Plugin = plugin;
			this.InitializeComponent();

			splitInformation.Panel2Collapsed = true;

			tabMain.Controls.Remove(tabSettings);

			IntPtr hIcon = Resources.settingsIcon.GetHicon();
			using(Icon ico = Icon.FromHandle(hIcon))
				base.Icon = ico;
		}

		protected override void OnLoad(EventArgs e)
		{
			if(this.Plugin.Settings.SplitterDistance > 0)
				splitMain.SplitterDistance = this.Plugin.Settings.SplitterDistance;

			if(this.Plugin.Settings.WindowSize != Size.Empty)
				this.Size = this.Plugin.Settings.WindowSize;
			if(this.Plugin.Settings.WindowLocation != Point.Empty)
				this.Location = this.Plugin.Settings.WindowLocation;

			base.OnLoad(e);
		}

		protected override void OnClosed(EventArgs e)
		{
			this.Plugin.Settings.SplitterDistance = splitMain.SplitterDistance;
			this.Plugin.Settings.WindowSize = this.Size;
			this.Plugin.Settings.WindowLocation = this.Location;
			base.OnClosed(e);
		}

		private void LoadPlugins(String searchText=null)
		{
			lvPlugins.Items.Clear();
			ilPlugin.Images.Clear();
			Boolean isSearch = !String.IsNullOrEmpty(searchText);
			tsSearch.Visible = isSearch;

			base.Cursor = Cursors.WaitCursor;
			try
			{
				List<ListViewItem> itemsToAdd = new List<ListViewItem>((Int32)this.Plugin.HostWindows.Plugins.Count);
				foreach(IPluginDescription plugin in this.Plugin.HostWindows.Plugins.OrderBy(p => p.Name))
				{
					if(isSearch)
					{//Let's try to search for search text in the plugin
						Boolean isFound = false;
						foreach(String str in Utils.GetPluginSearchMembers(plugin))
							if(str.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) > -1)
							{
								isFound = true;
								break;
							}

						if(!isFound)//Search text - not found. Skipping plugin
							continue;
					}

					ListViewItem item = new ListViewItem(plugin.Name)
					{
						Tag = plugin,
						ImageIndex = 0,
						StateImageIndex = 0,
					};

					if(plugin.Instance is IKernelInfo app)
					{
						if(app.ApplicationIcon is Icon ico)
						{
							ilPlugin.Images.Add(ico);
							item.ImageIndex = ilPlugin.Images.Count - 1;
						}

						/*if(plugin.Equals(this.Host.Plugins.KernelPlugin))
							item.ForeColor = Color.Red;*/
					}
					itemsToAdd.Add(item);
				}
				lvPlugins.Items.AddRange(itemsToAdd.ToArray());
				this.lvPlugins_SizeChanged(null, null);
			} finally
			{
				base.Cursor = Cursors.Arrow;
			}
		}

		private void PluginsDlg_Load(Object sender, EventArgs e)
			=> this.LoadPlugins();

		private void lvPlugins_ItemSelectionChanged(Object sender, ListViewItemSelectionChangedEventArgs e)
		{
			try
			{
				if(tabOptions.Controls.Count > 0)
				{//Delete all elements
					if(tabOptions.Controls[0] != ctlOptions)
						tabOptions.Controls[0].Dispose();
					tabOptions.Controls.Clear();
				}

				if(e.IsSelected)
				{
					tCloseInfo.Stop();
					IPluginDescription plugin = (IPluginDescription)e.Item.Tag;
					splitInformation.Panel2Collapsed = false;
					txtName.Text = plugin.Name;
					txtAuthor.Text = plugin.Company;
					txtVersion.Text = plugin.Version.ToString();
					txtSource.Text = plugin.Source;
					txtDescription.Text = plugin.Description;

					tt.SetToolTip(txtSource, plugin.Source);
					if(plugin.Instance is IPluginSettings)//Setting up the basic plugin settings dialog
					{
						if(tabSettings.Parent == null)// We only add the tab if it is not already added
							tabMain.Controls.Add(tabSettings);
					} else if(tabSettings.Parent != null)
						tabMain.Controls.Remove(tabSettings);

					IPluginMethodInfo member = plugin.Type.GetMember<IPluginMethodInfo>(PluginMessage.GetPluginOptionsControl);
					UserControl ctrl = member == null ? null : (UserControl)member.Invoke();
					if(ctrl == null)//Installing an additional plugin settings dialog
					{
						if(tabOptions.Parent != null)
							tabMain.TabPages.Remove(tabOptions);
					} else
					{
						if(tabOptions.Parent == null)
							tabMain.TabPages.Insert(0, tabOptions);
						ctrl.Dock = DockStyle.Fill;
						tabOptions.Controls.Add(ctrl);
						tabMain.SelectedTab = tabOptions;
					}

					pgSettings.SelectedObject = null;
					lvPlugins.Focus();
					this.tabMain_SelectedIndexChanged(sender, e);
				} else
					tCloseInfo.Start();
			} catch(Exception exc)
			{
				this.Plugin.Trace.TraceData(TraceEventType.Error, 10, exc);

				if(tabSettings.Parent != null)//Removing both tabs on exception
					tabMain.TabPages.Remove(tabSettings);
				if(tabOptions.Parent != null)
					tabMain.TabPages.Remove(tabOptions);
			}
		}

		private void tCloseInfo_Tick(Object sender, EventArgs e)
		{
			tCloseInfo.Stop();

			splitInformation.Panel2Collapsed = true;

			if(tabSettings.Parent != null)//Removing the basic settings tab
				tabMain.TabPages.Remove(tabSettings);
			if(tabOptions.Parent == null)
				tabMain.TabPages.Insert(0, tabOptions);
			tabOptions.Controls.Add(ctlOptions);
		}

		private void lvPlugins_SizeChanged(Object sender, EventArgs e)
			=> lvPlugins.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

		/// <summary>If the plugin supports customization, then display the settings tab</summary>
		private void tabMain_SelectedIndexChanged(Object sender, EventArgs e)
		{
			if(tabMain.SelectedTab == tabSettings
				&& pgSettings.SelectedObject == null)
			{//Displaying basic plugin settings
				IPluginSettings settings = (IPluginSettings)this.SelectedPlugin.Instance;
				pgSettings.SelectedObject = settings.Settings;
			}
		}

		/// <summary>Changing plugin parameters</summary>
		private void pgSettings_PropertyValueChanged(Object sender, PropertyValueChangedEventArgs e)
		{
			base.Cursor = Cursors.WaitCursor;
			base.SuspendLayout();
			try
			{
				this.Plugin.HostWindows.Plugins.Settings(this.SelectedPlugin.Instance).SaveAssemblyParameter(e.ChangedItem.PropertyDescriptor.Name, e.ChangedItem.Value);
			} finally
			{
				base.Cursor = Cursors.Arrow;
				base.ResumeLayout();
			}
		}

		private void lvPlugins_KeyDown(Object sender, KeyEventArgs e)
		{
			switch(e.KeyData)
			{
			case Keys.F | Keys.Control:
				e.Handled = true;
				tsSearch.Visible = true;
				txtSearch.Focus();
				break;
			case Keys.C | Keys.Control:
				IPluginDescription plugin = this.SelectedPlugin;
				if(plugin != null)
				{
					Clipboard.SetText(plugin.Name);
					e.Handled = true;
				}
				break;
			}
		}

		private void lvPlugins_MouseDown(Object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Right)
			{
				ListViewItem item = lvPlugins.GetItemAt(e.Location.X, e.Location.Y);
				if(item != null)
				{
					IPluginDescription plugin = (IPluginDescription)item.Tag;
					/*tsmiOptions.Enabled = */tsmiReset.Enabled = tsmiUnload.Enabled = false;
					if(plugin.Instance is IPluginSettings)
						tsmiReset.Enabled = true;

					IPluginMethodInfo method = plugin.Type.GetMember<IPluginMethodInfo>(PluginMessage.GetPluginOptionsControl);
					UserControl ctrl = method == null ? null : (UserControl)method.Invoke();
					if(ctrl != null)
					{
						//tsmiOptions.Enabled = true;
						ctrl.Dock = DockStyle.Fill;
						tabOptions.Controls.Add(ctrl);
					}
					/*if(plugin.Instance is IConfigurable && !((IConfigurable)plugin.Instance).IsUserControl)
						tsmiOptions.Enabled = true;*/
					if(!(plugin.Instance is IPluginKernel))
						tsmiUnload.Enabled = true;

					if(/*tsmiOptions.Enabled || */tsmiReset.Enabled || tsmiUnload.Enabled)
						cmsPlugin.Show(lvPlugins, e.Location);
				}
			}
		}

		private void cmsPlugin_ItemClicked(Object sender, ToolStripItemClickedEventArgs e)
		{
			IPluginDescription plugin = this.SelectedPlugin;
			if(e.ClickedItem == tsmiReset)//Delete all settings parameters of the selected plugin
			{
				if(MessageBox.Show(Resources.msgConfirmPluginReset, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					ISettingsProvider settings = this.Plugin.HostWindows.Plugins.Settings(plugin.Instance);
					settings.RemoveAssemblyParameter();

					pgSettings.SelectedObject = null;
					this.tabMain_SelectedIndexChanged(sender, e);//To update the property list
				}
			}/* else if(e.ClickedItem == tsmiOptions)//Additional application settings
			{
				using(Form dlg = ((IConfigurable)plugin.Instance).MainInterface as Form)
					if(dlg != null)
						dlg.ShowDialog();
			}*/ else if(e.ClickedItem == tsmiUnload)//Unload plugin
			{
				if(MessageBox.Show(Resources.msgConfirmUnload, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes
					&& this.Plugin.HostWindows.Plugins.UnloadPlugin(plugin))
					lvPlugins.Items.Remove(lvPlugins.SelectedItems[0]);
			}
		}

		private void txtItem_KeyDown(Object sender, KeyEventArgs e)
		{
			switch(e.KeyData)
			{
			case Keys.A | Keys.Control:
				e.Handled = true;
				((TextBox)sender).SelectAll();
				break;
			}
		}

		private void cmsSettings_Opening(Object sender, CancelEventArgs e)
		{
			GridItem item = pgSettings.SelectedGridItem;
			tsmiSettingsReset.Enabled = item.PropertyDescriptor.CanResetValue(pgSettings.SelectedObject);
			tsmiSettingsDescription.Checked = pgSettings.HelpVisible;
		}

		private void cmsSettings_ItemClicked(Object sender, ToolStripItemClickedEventArgs e)
		{
			GridItem item = pgSettings.SelectedGridItem;
			if(e.ClickedItem == tsmiSettingsReset)
				if(item.PropertyDescriptor.CanResetValue(pgSettings.SelectedObject))
				{
					base.Cursor = Cursors.WaitCursor;
					try
					{
						pgSettings.ResetSelectedProperty();
						this.Plugin.HostWindows.Plugins.Settings(this.SelectedPlugin.Instance).SaveAssemblyParameter(pgSettings.SelectedGridItem.PropertyDescriptor.Name, pgSettings.SelectedGridItem.Value);
					} finally
					{
						base.Cursor = Cursors.Arrow;
					}
				} else if(e.ClickedItem == tsmiSettingsDescription)
				{
					pgSettings.HelpVisible = tsmiSettingsDescription.Checked;
					tsmiSettingsDescription.Checked = !tsmiSettingsDescription.Checked;
				}
		}

		private void txtSearch_KeyDown(Object sender, KeyEventArgs e)
		{
			switch(e.KeyData)
			{
			case Keys.Return:
				this.bnSearch_Click(sender, e);
				e.Handled = true;
				break;
			case Keys.Escape:
				lvPlugins.Focus();
				tsSearch.Visible = false;
				e.Handled = true;
				break;
			}
		}

		private Int32? _searchHeight;
		private void tsSearch_Resize(Object sender, EventArgs e)
		{
			if(this._searchHeight == null)
				this._searchHeight = tsSearch.Height;
			txtSearch.Size = new Size(tsSearch.Width - bnSearch.Width - 20, txtSearch.Height);
			tsSearch.Height = this._searchHeight.Value;
		}

		private void bnSearch_Click(Object sender, EventArgs e)
		{
			String strSearch = txtSearch.Text.Trim();
			this.LoadPlugins(strSearch);
		}
	}
}