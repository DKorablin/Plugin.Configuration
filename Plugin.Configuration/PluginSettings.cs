using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Plugin.Configuration
{
	public class PluginSettings : INotifyPropertyChanged
	{
		private Int32 _splitterDistance;
		private Size _windowSize = Size.Empty;

		[Category("UI")]
		[DisplayName("Splitter distance")]
		[Description("Plugins list splitter distance")]
		public Int32 SplitterDistance
		{
			get => this._splitterDistance;
			set => this.SetField(ref this._splitterDistance, value, nameof(SplitterDistance));
		}

		[Category("UI")]
		[DisplayName("Window Size")]
		[Description("Size of the window")]
		public Size WindowSize
		{
			get => this._windowSize;
			set => this.SetField(ref this._windowSize, value, nameof(WindowSize));
		}

		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		private Boolean SetField<T>(ref T field, T value, String propertyName)
		{
			if(EqualityComparer<T>.Default.Equals(field, value))
				return false;

			field = value;
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			return true;
		}
		#endregion INotifyPropertyChanged
	}
}