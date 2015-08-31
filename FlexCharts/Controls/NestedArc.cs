﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using FlexCharts.Animation;
using FlexCharts.Controls.Contracts;
using FlexCharts.Controls.Primitives;
using FlexCharts.CustomGeometry;
using FlexCharts.Data.Sorting;
using FlexCharts.Data.Structures;
using FlexCharts.Extensions;
using FlexCharts.GenerationContext;
using FlexCharts.Helpers;
using FlexCharts.Helpers.DependencyHelpers;
using FlexCharts.Layout;
using FlexCharts.MaterialDesign;
using FlexCharts.MaterialDesign.Descriptors;
using FlexCharts.MaterialDesign.Providers;

namespace FlexCharts.Controls
{
	public class NestedArc : AbstractFlexChart<DoubleSeries>,
		ICircularContract, IValueContract, ISecondaryValueContract, ISegmentContract
	{
		#region Dependency Properties
		#region			CircularContract
		public static readonly DependencyProperty CircleScaleProperty = DP.Add(CircularPrimitive.CircleScaleProperty,
			new Meta<NestedArc, double> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty AngleOffsetProperty = DP.Add(CircularPrimitive.AngleOffsetProperty,
			new Meta<NestedArc, double> { Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public double CircleScale
		{
			get { return (double)GetValue(CircleScaleProperty); }
			set { SetValue(CircleScaleProperty, value); }
		}
		public double AngleOffset
		{
			get { return (double)GetValue(AngleOffsetProperty); }
			set { SetValue(AngleOffsetProperty, value); }
		}
		#endregion

		#region			ValueContract
		public static readonly DependencyProperty ValueFontFamilyProperty = DP.Add(ValuePrimitive.ValueFontFamilyProperty,
			new Meta<NestedArc, FontFamily>{ Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty ValueFontStyleProperty = DP.Add(ValuePrimitive.ValueFontStyleProperty,
			new Meta<NestedArc, FontStyle>{ Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty ValueFontWeightProperty = DP.Add(ValuePrimitive.ValueFontWeightProperty,
			new Meta<NestedArc, FontWeight>{ Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty ValueFontStretchProperty = DP.Add(ValuePrimitive.ValueFontStretchProperty,
			new Meta<NestedArc, FontStretch>{ Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty ValueFontSizeProperty = DP.Add(ValuePrimitive.ValueFontSizeProperty,
			new Meta<NestedArc, double>{ Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty ValueForegroundProperty = DP.Add(ValuePrimitive.ValueForegroundProperty,
			new Meta<NestedArc, AbstractMaterialDescriptor>{ Flags = INH | FXR }, DPExtOptions.ForceManualInherit);


		[Category("Charting")]
		public FontFamily ValueFontFamily
		{
			get { return (FontFamily)GetValue(ValueFontFamilyProperty); }
			set { SetValue(ValueFontFamilyProperty, value); }
		}
		[Category("Charting")]
		public FontStyle ValueFontStyle
		{
			get { return (FontStyle)GetValue(ValueFontStyleProperty); }
			set { SetValue(ValueFontStyleProperty, value); }
		}
		[Category("Charting")]
		public FontWeight ValueFontWeight
		{
			get { return (FontWeight)GetValue(ValueFontWeightProperty); }
			set { SetValue(ValueFontWeightProperty, value); }
		}
		[Category("Charting")]
		public FontStretch ValueFontStretch
		{
			get { return (FontStretch)GetValue(ValueFontStretchProperty); }
			set { SetValue(ValueFontStretchProperty, value); }
		}
		[Category("Charting")]
		public double ValueFontSize
		{
			get { return (double)GetValue(ValueFontSizeProperty); }
			set { SetValue(ValueFontSizeProperty, value); }
		}
		[Category("Charting")]
		public AbstractMaterialDescriptor ValueForeground
		{
			get { return (AbstractMaterialDescriptor)GetValue(ValueForegroundProperty); }
			set { SetValue(ValueForegroundProperty, value); }
		}
		#endregion

		#region			SecondaryValueContract
		public static readonly DependencyProperty SecondaryValueFontFamilyProperty = DP.Add(SecondaryValuePrimitive.SecondaryValueFontFamilyProperty,
			new Meta<NestedArc, FontFamily>{ Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty SecondaryValueFontStyleProperty = DP.Add(SecondaryValuePrimitive.SecondaryValueFontStyleProperty,
			new Meta<NestedArc, FontStyle>{ Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty SecondaryValueFontWeightProperty = DP.Add(SecondaryValuePrimitive.SecondaryValueFontWeightProperty,
			new Meta<NestedArc, FontWeight>{ Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty SecondaryValueFontStretchProperty = DP.Add(SecondaryValuePrimitive.SecondaryValueFontStretchProperty,
			new Meta<NestedArc, FontStretch>{ Flags = INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty SecondaryValueFontSizeProperty = DP.Add(SecondaryValuePrimitive.SecondaryValueFontSizeProperty,
			new Meta<NestedArc, double>{ Flags = FXR | INH }, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty SecondaryValueForegroundProperty = DP.Add(SecondaryValuePrimitive.SecondaryValueForegroundProperty,
			new Meta<NestedArc, AbstractMaterialDescriptor>{ Flags = INH | FXR}, DPExtOptions.ForceManualInherit);

		[Category("Charting")]
		public FontFamily SecondaryValueFontFamily
		{
			get { return (FontFamily)GetValue(SecondaryValueFontFamilyProperty); }
			set { SetValue(SecondaryValueFontFamilyProperty, value); }
		}
		[Category("Charting")]
		public FontStyle SecondaryValueFontStyle
		{
			get { return (FontStyle)GetValue(SecondaryValueFontStyleProperty); }
			set { SetValue(SecondaryValueFontStyleProperty, value); }
		}
		[Category("Charting")]
		public FontWeight SecondaryValueFontWeight
		{
			get { return (FontWeight)GetValue(SecondaryValueFontWeightProperty); }
			set { SetValue(SecondaryValueFontWeightProperty, value); }
		}
		[Category("Charting")]
		public FontStretch SecondaryValueFontStretch
		{
			get { return (FontStretch)GetValue(SecondaryValueFontStretchProperty); }
			set { SetValue(SecondaryValueFontStretchProperty, value); }
		}
		[Category("Charting")]
		public double SecondaryValueFontSize
		{
			get { return (double)GetValue(SecondaryValueFontSizeProperty); }
			set { SetValue(SecondaryValueFontSizeProperty, value); }
		}
		[Category("Charting")]
		public AbstractMaterialDescriptor SecondaryValueForeground
		{
			get { return (AbstractMaterialDescriptor)GetValue(SecondaryValueForegroundProperty); }
			set { SetValue(SecondaryValueForegroundProperty, value); }
		}
		#endregion

		#region			SegmentContract
		public static readonly DependencyProperty SegmentSpaceBackgroundProperty = DP.Add(SegmentPrimitive.SegmentSpaceBackgroundProperty,
			new Meta<NestedArc, AbstractMaterialDescriptor> {Flags = INH}, DPExtOptions.ForceManualInherit);

		public static readonly DependencyProperty SegmentWidthPercentageProperty = DP.Add(SegmentPrimitive.SegmentWidthPercentageProperty,
			new Meta<NestedArc, double>{ Flags = INH | FXR }, DPExtOptions.ForceManualInherit);


		[Category("Charting")]
		public AbstractMaterialDescriptor SegmentSpaceBackground
		{
			get { return (AbstractMaterialDescriptor)GetValue(SegmentSpaceBackgroundProperty); }
			set { SetValue(SegmentSpaceBackgroundProperty, value); }
		}
		[Category("Charting")]
		public double SegmentWidthPercentage
		{
			get { return (double)GetValue(SegmentWidthPercentageProperty); }
			set { SetValue(SegmentWidthPercentageProperty, value); }
		}
		#endregion

		public static readonly DependencyProperty TopRingPaddingProperty = DP.Register(
			new Meta<NestedArc, double> { Flags = FXR });

		public static readonly DependencyProperty BottomRingPaddingProperty = DP.Register(
			new Meta<NestedArc, double>(80) { Flags = FXR });

		public static readonly DependencyProperty MaxArcAngleProperty = DP.Register(
			new Meta<NestedArc, double>(85) { Flags = FXR });

		public static readonly DependencyProperty ValueLabelHorizontalSpacingProperty = DP.Register(
			new Meta<NestedArc, double>(150) { Flags = FXR });

		public static readonly DependencyProperty LeftArcLabelSpacingProperty = DP.Register(
			new Meta<NestedArc, double>(20) { Flags = FXR });

		[Category("Charting")]
		public double TopRingPadding
		{
			get { return (double)GetValue(TopRingPaddingProperty); }
			set { SetValue(TopRingPaddingProperty, value); }
		}
		[Category("Charting")]
		public double BottomRingPadding
		{
			get { return (double)GetValue(BottomRingPaddingProperty); }
			set { SetValue(BottomRingPaddingProperty, value); }
		}
		[Category("Charting")]
		public double MaxArcAngle
		{
			get { return (double)GetValue(MaxArcAngleProperty); }
			set { SetValue(MaxArcAngleProperty, value); }
		}
		[Category("Charting")]
		public double ValueLabelHorizontalSpacing
		{
			get { return (double)GetValue(ValueLabelHorizontalSpacingProperty); }
			set { SetValue(ValueLabelHorizontalSpacingProperty, value); }
		}
		[Category("Charting")]
		public double LeftArcLabelSpacing
		{
			get { return (double)GetValue(LeftArcLabelSpacingProperty); }
			set { SetValue(LeftArcLabelSpacingProperty, value); }
		}
		#endregion

		#region Fields
		internal NestedArcChartVisualContext visualContext;
		protected readonly Grid _segments = new Grid
		{
			RenderTransformOrigin = new Point(.5, .5),
			ClipToBounds = true
		};
		protected readonly Grid _categoryLabels = new Grid();
		protected readonly Grid _inactiveSegments = new Grid
		{
			RenderTransformOrigin = new Point(.5, 1),
		};
		#endregion

		#region Constructors
		static NestedArc()
		{
			DataSorterProperty.OverrideMetadata(typeof (NestedArc),
				new FrameworkPropertyMetadata(new AscendingDataSorter()));
			TitleProperty.OverrideMetadata(typeof(NestedArc), new FrameworkPropertyMetadata("Nested Arc 2"));
		}
		public NestedArc()
		{
			var rotateTransform = new RotateTransform(0, .5, .5);
			_segments.RenderTransform = rotateTransform;
			BindingOperations.SetBinding(rotateTransform, RotateTransform.AngleProperty, new Binding("AngleOffset") { Source = this });

			_segments.RenderTransformOrigin = new Point(.5, 1);

			_main.Children.Add(_inactiveSegments);
			_main.Children.Add(_segments);
			_main.Children.Add(_categoryLabels);
			Loaded += onLoaded;
		}
		#endregion

		#region Methods
		private void onLoaded(object s, RoutedEventArgs e)
		{
			BeginRevealAnimation();
		}
		public void BeginRevealAnimation()
		{
			var animationOffset = 0;
			foreach (var category in visualContext.CategoryVisuals)
			{
				category.ActiveArcVisual.RenderTransform.BeginAnimation(RotateTransform.AngleProperty,
					new DoubleAnimation(180, 0, new Duration(TimeSpan.FromMilliseconds(600 + (animationOffset / 3))))
					{
						BeginTime = TimeSpan.FromMilliseconds(animationOffset),
						AccelerationRatio = AnimationParameters.AccelerationRatio,
						DecelerationRatio = AnimationParameters.DecelerationRatio,
					});
				category.CategoryLabel.BeginAnimation(OpacityProperty,
					new DoubleAnimation(1, new Duration(TimeSpan.FromMilliseconds(300 + (animationOffset / 3))))
					{
						BeginTime = TimeSpan.FromMilliseconds(animationOffset + 500),
						AccelerationRatio = AnimationParameters.AccelerationRatio,
						DecelerationRatio = AnimationParameters.DecelerationRatio,
					});
				category.ValuePercentLabel.BeginAnimation(OpacityProperty,
					new DoubleAnimation(1, new Duration(TimeSpan.FromMilliseconds(300 + (animationOffset / 3))))
					{
						BeginTime = TimeSpan.FromMilliseconds(animationOffset + 500),
						AccelerationRatio = AnimationParameters.AccelerationRatio,
						DecelerationRatio = AnimationParameters.DecelerationRatio,
					});
				category.ValueLabel.BeginAnimation(OpacityProperty,
					new DoubleAnimation(1, new Duration(TimeSpan.FromMilliseconds(300 + (animationOffset / 3))))
					{
						BeginTime = TimeSpan.FromMilliseconds(animationOffset + 500),
						AccelerationRatio = AnimationParameters.AccelerationRatio,
						DecelerationRatio = AnimationParameters.DecelerationRatio,
					});
				animationOffset += 25;
			}
		}

		public void BeginCollapseAnimation()
		{
			var animationOffset = 0;
			foreach (var category in visualContext.CategoryVisuals)
			{
				category.ActiveArcVisual.RenderTransform.BeginAnimation(RotateTransform.AngleProperty,
					new DoubleAnimation(-180, new Duration(TimeSpan.FromMilliseconds(600 + (animationOffset / 3))))
					{
						BeginTime = TimeSpan.FromMilliseconds(animationOffset),
						AccelerationRatio = AnimationParameters.AccelerationRatio,
						DecelerationRatio = AnimationParameters.DecelerationRatio,
					});
				category.CategoryLabel.BeginAnimation(OpacityProperty,
					new DoubleAnimation(0, new Duration(TimeSpan.FromMilliseconds(300 + (animationOffset / 3))))
					{
						BeginTime = TimeSpan.FromMilliseconds(animationOffset),
						AccelerationRatio = AnimationParameters.AccelerationRatio,
						DecelerationRatio = AnimationParameters.DecelerationRatio,
					});
				category.ValuePercentLabel.BeginAnimation(OpacityProperty,
					new DoubleAnimation(0, new Duration(TimeSpan.FromMilliseconds(300 + (animationOffset / 3))))
					{
						BeginTime = TimeSpan.FromMilliseconds(animationOffset),
						AccelerationRatio = AnimationParameters.AccelerationRatio,
						DecelerationRatio = AnimationParameters.DecelerationRatio,
					});
				category.ValueLabel.BeginAnimation(OpacityProperty,
					new DoubleAnimation(0, new Duration(TimeSpan.FromMilliseconds(300 + (animationOffset / 3))))
					{
						BeginTime = TimeSpan.FromMilliseconds(animationOffset),
						AccelerationRatio = AnimationParameters.AccelerationRatio,
						DecelerationRatio = AnimationParameters.DecelerationRatio,
					});

				animationOffset += 25;
			}
		}
		#endregion

		#region Overrided Methods
		protected override void OnRender(DrawingContext drawingContext)
		{
			visualContext = new NestedArcChartVisualContext();

			_segments.Children.Clear();
			_inactiveSegments.Children.Clear();
			_categoryLabels.Children.Clear();

			var context = new ProviderContext(Data.Count);
			MaterialProvider.Reset(context);

			var fullArcDiameter = _main.RenderSize.Height - TopRingPadding;
			var fullArcWidth = fullArcDiameter - BottomRingPadding;
			var subArcAvailableWidth = fullArcWidth / Data.Count;
			var subArcActualWidth = subArcAvailableWidth * SegmentWidthPercentage;
			var subRingOffset = (subArcAvailableWidth - subArcActualWidth) / 2;

			var fullRadius = _main.RenderSize.Width / 2;
			var centerPoint = new Point(0, fullRadius);
			
			if (Data.Count < 1)
			{
				base.OnRender(drawingContext);
				return;
			}

			var max = Data.MaxValue();
			var trace = 0;
			foreach (var d in Data)
			{
				var categoryVisualContext = new NestedArcCategoryVisualContext();
				var materialSet = MaterialProvider.ProvideNext(context);

				categoryVisualContext.CategoryDataPoint = d;
				var arcDiameter = BottomRingPadding + (subArcAvailableWidth * trace) + subRingOffset;

				var inactiveArcPath = CalculatePath(centerPoint, arcDiameter, subArcActualWidth);
				inactiveArcPath.Fill = SegmentSpaceBackground.GetMaterial(materialSet);

				categoryVisualContext.InactiveArcVisual = inactiveArcPath;
				_inactiveSegments.Children.Add(inactiveArcPath);

				var activeArcAngle = d.Value.Map(0, max, 0, MaxArcAngle);
	
				var activeArcPath = CalculateActiveArcPath(centerPoint, arcDiameter, subArcActualWidth, activeArcAngle);

				
				categoryVisualContext.CategoryMaterialSet = materialSet;

				activeArcPath.Fill = SegmentForeground.GetMaterial(materialSet);
				activeArcPath.MouseOverFill = materialSet.GetMaterial(Luminosity.P700);
				activeArcPath.RenderTransformOrigin = new Point(.5, 1);
				activeArcPath.RenderTransform = new RotateTransform((IsLoaded ? 0 : 180), .5, .5);
				d.RenderedVisual = activeArcPath;

				categoryVisualContext.ActiveArcVisual = activeArcPath;
				_segments.Children.Add(activeArcPath);

				visualContext.CategoryVisuals.Add(categoryVisualContext);
				trace++;
			}
			var ltrace = 0;

			for (var x = Data.Count - 1; x >= 0; x--)
			{
				var d = Data[x];
				var currentCategoryVisualContext = visualContext.CategoryVisuals[x];
				var shape = (Shape)d.RenderedVisual;//.ShouldBeCastable<Shape>();
				var renderedFill = (SolidColorBrush)shape.Fill;//.ShouldBeType<SolidColorBrush>();
				var arcLabelMarginLeft = fullRadius + LeftArcLabelSpacing;
				var categoryLabel = new Label
				{
					Width = ValueLabelHorizontalSpacing,
					VerticalAlignment = VerticalAlignment.Top,
					HorizontalAlignment = HorizontalAlignment.Left,
					VerticalContentAlignment = VerticalAlignment.Center,
					HorizontalContentAlignment = HorizontalAlignment.Left,
					Margin = new Thickness(arcLabelMarginLeft, (ltrace * subArcAvailableWidth) + subRingOffset + 6, 0, 0),
					//Foreground = renderedFill.Lighten(.2),
					Foreground =  ValueForeground.GetMaterial(currentCategoryVisualContext.CategoryMaterialSet),
					Content = d.CategoryName.ToUpper(),
					Height = subArcAvailableWidth,
					Padding = new Thickness(0),
					Opacity = IsLoaded ? 1 : 0, // TODO isloaded
					DataContext = this
				};
				currentCategoryVisualContext.CategoryLabel = categoryLabel;

				categoryLabel.BindTextualPrimitive<ValuePrimitive>(this);

				var valuePercentLabel = new Label
				{
					Width = ValueLabelHorizontalSpacing,
					VerticalAlignment = VerticalAlignment.Top,
					HorizontalAlignment = HorizontalAlignment.Left,
					VerticalContentAlignment = VerticalAlignment.Center,
					HorizontalContentAlignment = HorizontalAlignment.Right,
					Margin = new Thickness(arcLabelMarginLeft, (ltrace * subArcAvailableWidth) + subRingOffset + 6, 0, 0),
					//Foreground = renderedFill.Lighten(.2),
					Foreground =  ValueForeground.GetMaterial(currentCategoryVisualContext.CategoryMaterialSet),
					Content = d.Value + " Minutes",
					Height = subArcAvailableWidth,
					Padding = new Thickness(0),
					Opacity = IsLoaded ? 1 : 0,
					DataContext = this
				};
				currentCategoryVisualContext.ValuePercentLabel = valuePercentLabel;
				valuePercentLabel.BindTextualPrimitive<ValuePrimitive>(this);

				var valueLabelLeftSpace = arcLabelMarginLeft + ValueLabelHorizontalSpacing;
				var valueLabelWidth = _main.RenderSize.Width - valueLabelLeftSpace;
				if (valueLabelWidth < 0) valueLabelWidth = 0;
				var valueLabel = new Label()
				{
					Width = valueLabelWidth,
					VerticalAlignment = VerticalAlignment.Top,
					HorizontalAlignment = HorizontalAlignment.Left,
					VerticalContentAlignment = VerticalAlignment.Center,
					HorizontalContentAlignment = HorizontalAlignment.Left,
					Foreground =  SecondaryValueForeground.GetMaterial(currentCategoryVisualContext.CategoryMaterialSet),
					Margin = new Thickness(arcLabelMarginLeft + ValueLabelHorizontalSpacing, (ltrace * subArcAvailableWidth) + subRingOffset + 6, 0, 0),
					//Foreground = FlatUI.LightGray,
					Content = $" = {Math.Round(d.Value / 60, 2)} Hours",//{Math.Round(d.Value * 48):n0}
					Height = subArcAvailableWidth,
					Opacity = IsLoaded ? 1 : 0, // TODO isloaded
					Padding = new Thickness(0),
				};
				currentCategoryVisualContext.ValueLabel = valueLabel;
				valueLabel.BindTextualPrimitive<SecondaryValuePrimitive>(this);

				_categoryLabels.Children.Add(categoryLabel);
				_categoryLabels.Children.Add(valuePercentLabel);
				_categoryLabels.Children.Add(valueLabel);

				ltrace++;
			}
			base.OnRender(drawingContext);
		}
		#endregion

		//TODO get rid of this. use custom paths and geometry
		public CustomPath CalculatePath(Point center, double radius, double arcWidth)
		{
			var startOuterPolar = new PolarPoint(0, radius);
			var endOuterPolar = new PolarPoint(180, radius);
			var startInnerPolar = new PolarPoint(0, radius - arcWidth);
			var endInnerPolar = new PolarPoint(180, radius - arcWidth);
			var space = new Size(_main.RenderSize.Width, _main.RenderSize.Height * 2);
			return new CustomPath(null)
			{
				Data = new PathGeometry
				{
					Figures = new PathFigureCollection
					{
						new PathFigure
						{
							StartPoint = startOuterPolar.ToCartesian().LocalizeInPolarSpace(space),
							Segments = new PathSegmentCollection
							{
								new ArcSegment
								{
									Size = new Size(radius, radius), //<-? why radius?
									Point = endOuterPolar.ToCartesian().LocalizeInPolarSpace(space),
									IsLargeArc = false
								},
								new LineSegment
								{
									Point = endInnerPolar.ToCartesian().LocalizeInPolarSpace(space)
								},
								new ArcSegment
								{
									Size = new Size(radius - arcWidth, radius - arcWidth),
									Point = startInnerPolar.ToCartesian().LocalizeInPolarSpace(space),
									SweepDirection = SweepDirection.Clockwise,
									IsLargeArc = false
								}
							}
						}
					}
				}
			};
		}
		public CustomPath CalculateActiveArcPath(Point center, double radius, double arcWidth, double angle)
		{
			var startOuterPolar = new PolarPoint(90, radius);
			var endOuterPolar = new PolarPoint(90 + angle, radius);
			var startInnerPolar = new PolarPoint(90, radius - arcWidth);
			var endInnerPolar = new PolarPoint(90 + angle, radius - arcWidth);
			var space = new Size(_main.RenderSize.Width, _main.RenderSize.Height * 2);
			return new CustomPath(null)
			{
				Data = new PathGeometry
				{
					Figures = new PathFigureCollection
					{
						new PathFigure
						{
							StartPoint = startOuterPolar.ToCartesian().LocalizeInPolarSpace(space),
							Segments = new PathSegmentCollection
							{
								new ArcSegment
								{
									Size = new Size(radius, radius),
									Point = endOuterPolar.ToCartesian().LocalizeInPolarSpace(space),
									IsLargeArc = false
								},
								new LineSegment
								{
									Point = endInnerPolar.ToCartesian().LocalizeInPolarSpace(space)
								},
								new ArcSegment
								{
									Size = new Size(radius - arcWidth, radius - arcWidth),
									Point = startInnerPolar.ToCartesian().LocalizeInPolarSpace(space),
									SweepDirection = SweepDirection.Clockwise,
									IsLargeArc = false
								}
							}
						}
					}
				}
			};
		}
	}
}
