using System;
using System.Diagnostics;
using System.Windows.Forms;
using SAL.Flatbed;
using SAL.Windows;

namespace Plugin.Configuration
{
	public class PluginWindows : IPlugin, IPluginSettings<PluginSettings>
	{
		#region Fields
		private PluginSettings _settings;
		private TraceSource _trace;
		private PluginsDlg _plugins;
		#endregion Fields
		#region Properties
		internal TraceSource Trace => this._trace ?? (this._trace = PluginWindows.CreateTraceSource<PluginWindows>());

		internal IHostWindows HostWindows { get; }

		private IMenuItem ConfigMenu { get; set; }

		Object IPluginSettings.Settings => this.Settings;

		public PluginSettings Settings
		{
			get
			{
				if(this._settings == null)
				{
					this._settings = new PluginSettings();
					this.HostWindows.Plugins.Settings(this).LoadAssemblyParameters(this._settings);
				}
				return this._settings;
			}
		}
		#endregion Properties
		#region Methods
		public PluginWindows(IHostWindows hostWindows)
			=> this.HostWindows = hostWindows ?? throw new ArgumentNullException(nameof(hostWindows));

		Boolean IPlugin.OnConnection(ConnectMode mode)
		{
			IMenuItem menuTools = this.HostWindows.MainMenu.FindMenuItem("Tools");
			if(menuTools == null)
				this.Trace.TraceEvent(TraceEventType.Error, 10, "Menu item 'Tools' not found");
			{
				this.ConfigMenu = menuTools.Create("&Plugins");
				this.ConfigMenu.Name = "Tools.Plugins";
				this.ConfigMenu.Click += new EventHandler(this.ConfigMenu_Click);
				menuTools.Items.Insert(0, this.ConfigMenu);
				return true;
			}
		}

		Boolean IPlugin.OnDisconnection(DisconnectMode mode)
		{
			if(this._plugins != null && !this._plugins.IsDisposed)
				this._plugins.Dispose();

			if(this.ConfigMenu != null)
				this.HostWindows.MainMenu.Items.Remove(this.ConfigMenu);
			return true;
		}

		private static TraceSource CreateTraceSource<T>(String name = null) where T : IPlugin
		{
			TraceSource result = new TraceSource(typeof(T).Assembly.GetName().Name + name);
			result.Switch.Level = SourceLevels.All;
			result.Listeners.Remove("Default");
			result.Listeners.AddRange(System.Diagnostics.Trace.Listeners);
			return result;
		}
		#endregion Methods
		#region Event Handlers
		private void ConfigMenu_Click(Object sender, EventArgs e)
		{
			if(this._plugins == null)
			{
				this._plugins = new PluginsDlg(this);
				this._plugins.FormClosed += this.plugins_FormClosed;
			}
			this._plugins.Show();
			/*using(PluginsDlg dlg = new PluginsDlg(this))
				dlg.ShowDialog();*/
		}

		private void plugins_FormClosed(Object sender, FormClosedEventArgs e)
		{
			if(e.CloseReason == CloseReason.UserClosing)
			{
				this._plugins.FormClosed -= this.plugins_FormClosed;
				this._plugins.Dispose();
				this._plugins = null;
			}
		}
		#endregion Event Handlers
	}
}