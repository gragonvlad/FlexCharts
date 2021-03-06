﻿using System.IO;
using System.Windows;
using FlexCharts.Helpers.DependencyHelpers;

namespace Material.Controls.FileManager
{
	public abstract class AbstractFileSystemListItem<T> : AbstractFileSystemListItem
		where T : FileSystemInfo
	{
		#region Dependency Properties
		public static readonly DependencyProperty FileSystemItemProperty = DP.Register(
			new Meta<AbstractFileSystemListItem<T>, T>());
		public T FileSystemItem
		{
			get { return (T)GetValue(FileSystemItemProperty); }
			set { SetValue(FileSystemItemProperty, value); }
		}
		#endregion

		#region Overriden Methods
		public override FileSystemInfo FileSystemItemBase => FileSystemItem;
		#endregion
	}
}
