import 'package:demo_app/widgets/animated_widgets/animated_default_text_style.dart';
import 'package:demo_app/widgets/animated_widgets/fade_transition.dart';
import 'package:demo_app/widgets/input_widgets/raw_autocomplete.dart';
import 'package:demo_app/widgets/overlap_wiidgets/baseline.dart';
import 'package:demo_app/widgets/overlap_wiidgets/block_semantics.dart';
import 'package:demo_app/widgets/overlap_wiidgets/merge_semantics.dart';
import 'package:demo_app/widgets/overlap_wiidgets/semantics.dart';
import 'package:demo_app/widgets/overlap_wiidgets/sized_overflow_box.dart';
import 'package:demo_app/widgets/overlap_wiidgets/stack.dart';
//import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import '../../../widgets/access_widgets.dart';

class FlutterWidgetList extends StatefulWidget {
  const FlutterWidgetList({Key? key}) : super(key: key);

  @override
  _FlutterWidgetListState createState() => _FlutterWidgetListState();
}

class _FlutterWidgetListState extends State<FlutterWidgetList> {
  @override
  Widget build(BuildContext context) {
    return ListView(children: [
      //Action Widgets
      getListTileWidget(const AbsorbPointerWidget(), "Absorb Pointer Widget"),
      getListTileWidget(const ChipWidget(), "Chip Widget"),
      getListTileWidget(const ChoiceChipWidget(), "Choice Chip Widget"),
      getListTileWidget(const CloseButtonWidget(), "Close Button Widget"),
      getListTileWidget(const DismissibleWidget(), "Dismissible Widget"),
      getListTileWidget(const DropdownButtonWidget(), "Dropdown Button Widget"),
      getListTileWidget(const ElevatedButtonWidget(), "Elevated Button Widget"),
      getListTileWidget(const FilterChipWidget(), "Filter Chip Widget"),
      getListTileWidget(
          const FloatingActionButtonWidget(), "Floating Action Button Widget"),
      getListTileWidget(
          const GestureDetectorWidget(), "GestureDetector Widget"),
      getListTileWidget(const IconButtonWidget(), "Icon Button Widget"),
      getListTileWidget(const IgnorePointerWidget(), "Ignore Pointer Widget"),
      getListTileWidget(const InkWellWidget(), "Ink Well Widget"),
      getListTileWidget(const InputChipWidget(), "Input Chip Widget"),
      getListTileWidget(const ListenerWidget(), "Listener Widget"),
      getListTileWidget(
          const LongPressDraggableWidget(), "Long Press Draggable Widget"),
      getListTileWidget(const MaterialButtonWidget(), "Material Button Widget"),
      getListTileWidget(const ModalBarrierWidget(), "Modal Barrier Widget"),
      getListTileWidget(const MouseCursorWidget(), "Mouse Cursor Widget"),
      getListTileWidget(const MouseRegionWidget(), "Mouse Region Widget"),
      getListTileWidget(
          const NotificationListenerWidget(), "Notification Listener Widget"),
      getListTileWidget(const OffstageWidget(), "Offstage Widget"),
      getListTileWidget(const OutlinedButtonWidget(), "Outlined Button Widget"),
      getListTileWidget(
          const PopupMenuButtonWidget(), "Popup Menu Button Widget"),
      getListTileWidget(const RawChipWidget(), "Raw Chip Widget"),
      getListTileWidget(const SelectableTextWidget(), "Selectable Text Widget"),
      getListTileWidget(const ShortcutsWidget(), "Shortcuts Widget"),
      getListTileWidget(const SliderWidget(), "Slider Widget"),
      getListTileWidget(const StepperWidget(), "Stepper Widget"),
      getListTileWidget(const StreamBuilderWidget(), "Stream Builder Widget"),
      getListTileWidget(
          const SwitchListTileWidget(), "Switch List Tile Widget"),
      getListTileWidget(const SwitchWidget(), "Switch Widget"),
      getListTileWidget(const TextButtonWidget(), "Text Button Widget"),
      getListTileWidget(const ToggleButtonsWidget(), "Toggle Buttons Widget"),
      getListTileWidget(
          const ValueListenableBuilderWidget(), "Value Listenable Widget"),
      getListTileWidget(const VisibilityWidget(), "Visibility Widget"),
      getListTileWidget(const WillPopScopeWidget(), "Will Pop Scope Widget"),

      //Animated Widgets
      getListTileWidget(const CircularProgressIndicatorWidget(),
          "Circular Progress Indicator Widget"),
      getListTileWidget(const FutureBuilderWidget(), "Future Builder Widget"),
      getListTileWidget(const LinearProgressIndicatorWidget(),
          "Linear Progress Indicator Widget"),
      getListTileWidget(
          const RefreshIndicatorWidget(), "Refresh Indicator Widget"),
      getListTileWidget(const AnimatedAlignWidget(), "Animated Align Widget"),
      getListTileWidget(
          const AnimatedBuilderWidget(), "Animate dBuilder Widget"),
      getListTileWidget(
          const AnimatedContainerWidget(), "Animated Container Widget"),
      getListTileWidget(
          const AnimatedCrossFadeWidget(), "Animated CrossFade Widget"),
      getListTileWidget(const AnimatedDefaultTextStyleWidget(),
          "Animated Default TextSty Widget"),
      getListTileWidget(const AnimatedIconWidget(), "Animated Icon Widget"),
      getListTileWidget(const AnimatedListWidget(), "Animated List Widget"),
      getListTileWidget(
          const AnimatedModalBarrierWidget(), "Animated Modal Widget"),
      getListTileWidget(
          const AnimatedOpacityWidget(), "Animated Opacity Widget"),
      getListTileWidget(
          const AnimatedPaddingWidget(), "Animated Padding Widget"),
      getListTileWidget(const AnimatedPhysicalModelWidget(),
          "Animated Physical Model Widget"),
      getListTileWidget(
          const AnimatedPositionedWidget(), "Animated Positioned Widget"),
      getListTileWidget(
          const AnimatedRotationWidget(), "Animated Rotation Widget"),
      getListTileWidget(const AnimatedSizeWidget(), "Animated Size Widget"),
      getListTileWidget(
          const AnimatedSwitcherWidget(), "Animated Switcher Widget"),
      getListTileWidget(const MyAnimatedWidget(), "My Animated Widget"),
      getListTileWidget(const DecoratedBoxTransitionWidget(),
          "Decorated Box Transition Widget"),
      getListTileWidget(const FadeInImageWidget(), "Fade-In Image Widget"),
      getListTileWidget(const FadeTransitionWidget(), "FadeTransition Widget"),
      getListTileWidget(const HeroWidget(), "Hero Widget"),
      getListTileWidget(const PositionedWidget(), "Positioned Widget Widget"),
      getListTileWidget(
          const RotationTransitionWidget(), "Rotation Transition Widget"),
      getListTileWidget(
          const ScaleTransitionWidget(), "Scale Transition Widget"),
      getListTileWidget(const SizeTransitionWidget(), "Size Transition Widget"),
      getListTileWidget(
          const SlideTransitionWidget(), "Slide Transition Widget"),
      getListTileWidget(const TweenAnimationBuilderWidget(),
          "Tween Animation Builder Widget"),

      //Cupertion Widgets
      getListTileWidget(const CupertinoActionSheetActionWidget(),
          "Cupertino Action Sheet Widget"),
      getListTileWidget(const CupertinoActivityIndicatorWidget(),
          "Cupertino Activity Indicator Widget"),
      getListTileWidget(
          const CupertinoAlertDialogWidget(), "Cupertino Alert Dialog Widget"),
      getListTileWidget(const CupertinoAppWidget(), "Cupertino App Widget"),
      getListTileWidget(
          const CupertinoButtonWidget(), "Cupertino Button Widget"),
      getListTileWidget(
          const CupertinoContextMenuWidget(), "Cupertino Context Menu Widget"),
      getListTileWidget(
          const CupertinoDatePickerWidget(), "Cupertino Date Picker Widget"),
      getListTileWidget(
          const CupertinoPageRouteWidget(), "Cupertino Page Route Widget"),
      getListTileWidget(const CupertinoPageScaffoldWidget(),
          "Cupertino Page Scaffold Widget"),
      getListTileWidget(CupertinoSearchTextFieldWidget(),
          "Cupertino Search Text Field Widget"),
      getListTileWidget(const CupertinoSegmentedControlWidget(),
          "Cupertino Segmented Control Widget"),
      getListTileWidget(
          const CupertinoSliderWidget(), "Cupertino Slider Widget"),
      getListTileWidget(const CupertinoSlidingSegmentedControlWidget(),
          "Cupertino Sliding Segmented Control Widget"),
      getListTileWidget(
          const CupertinoSwitchWidget(), "Cupertino Switch Widget"),
      getListTileWidget(
          const CupertinoTabBarWidget(), "Cupertino Tab Bar Widget"),
      getListTileWidget(
          const CupertinoTabScaffoldWidget(), "Cupertino Tab Scaffold Widget"),
      getListTileWidget(
          const CupertinoTabViewWidget(), "Cupertino Tab View Widget"),
      getListTileWidget(
          CupertinoTextFieldWidget(), "Cupertino Text Field Widget"),

      //Custom Widgets
      getListTileWidget(const BuilderWidget(), "Builder Widget"),
      getListTileWidget(const CustomPaintWidget(), "Custom Paint Widget"),

      //Icon Widgets
      getListTileWidget(const FlutterLogoWidget(), "Flutter Logo Widget"),
      getListTileWidget(const IconWidget(), "Icon Widget"),

      //Image Widgets
      getListTileWidget(const ImageNetworkWidget(), "Image Network Widget"),
      getListTileWidget(const ImageWidget(), "Image Widget"),
      getListTileWidget(const PlaceholderWidget(), "Placeholder Widget"),
      getListTileWidget(const PositionedWidget(), "Positioned Widget"),
      getListTileWidget(const TooltipWidget(), "Tooltip Widget"),

      //Input Widgets
      getListTileWidget(const AutoCompleteWidget(), "Auto Complete Widget"),
      getListTileWidget(
          const CheckBoxListTileWidget(), "Check Box List Tile Widget"),
      getListTileWidget(const CheckBoxWidget(), "Check Box Widget"),
      getListTileWidget(const DatePickerWidget(), "Date Picker Widget"),
      getListTileWidget(
          const DateRangePickerWidget(), "Date Range Picker Widget"),
      getListTileWidget(FormWidget(), "Form Widget"),
      getListTileWidget(const RadioListTileWidget(), "Radio List Tile Widget"),
      getListTileWidget(const RadioWidget(), "Radio Widget"),
      getListTileWidget(const RangeSliderWidget(), "Range Slider Widget"),
      getListTileWidget(
          const RawAutocompleteWidget(), "Raw Autocomplete Widget"),
      getListTileWidget(const TextFieldWidget(), "Text Field Widget"),
      getListTileWidget(const TextFormFieldWidget(), "Text Form Field Widget"),

      //Layout Widgets => Banner
      getListTileWidget(const MaterialBannerWidget(), "Material Banner Widget"),

      //Layout Widgets => Bar
      getListTileWidget(const AppBarWidget(), "App Bar Widget"),
      getListTileWidget(const PreferredSizedWidget(), "Preferred Sized Widget"),
      getListTileWidget(const ScrollBarWidget(), "Scrollbar Widget"),
      getListTileWidget(const SnackBarWidget(), "SnackBar Widget"),

      //Layout Widgets => Card
      getListTileWidget(const CardWidget(), "Card Widget"),
      getListTileWidget(const ClipRRectWidget(), "Clip R Rect Widget"),
      getListTileWidget(const ColorFilteredWidget(), "ColorFiltered Widget"),
      getListTileWidget(const LimitedBoxWidget(), "Limited Box Widget"),

      //Layout Widgets => Container
      getListTileWidget(const AlignWidget(), "Align Widget"),
      getListTileWidget(const AspectRatioWidget(), "AspectRatio Widget"),
      getListTileWidget(const BackdropFilterWidget(), "Backdrop Filter Widget"),
      getListTileWidget(const BannerWidget(), "Banner Widget"),
      getListTileWidget(const BottomSheetWidget(), "Bottom Sheet Widget"),
      getListTileWidget(const CenterWidget(), "Center Widget"),
      getListTileWidget(const ColumnWidget(), "Column Widget"),
      getListTileWidget(const ContainerWidget(), "Container Widget"),
      getListTileWidget(const FlexibleWidget(), "Flexible Widget"),
      getListTileWidget(const IndexedStackWidget(), "Indexed Stack Widget"),
      getListTileWidget(const RowWidget(), "Row Widget"),
      getListTileWidget(const ScaffoldWidget(), "Scaffold Widget"),
      getListTileWidget(const SpacerWidget(), "Spacer Widget"),

      //Layout Widgets => Dialog
      getListTileWidget(const AboutDialogWidget(), "About Dialog Widget"),
      getListTileWidget(const AlertDialogWidget(), "Alert Dialog Widget"),
      getListTileWidget(const SimpleDialogWidget(), "Simple Dialog Widget"),

      //Layout Widgets => Drag
      getListTileWidget(const DragTargetWidget(), "Drag Target Widget"),
      getListTileWidget(const DraggableScrollableSheetWidget(),
          "Draggable Scrollable Sheet Widget"),
      getListTileWidget(const DraggableWidget(), "Draggable Widget"),

      //Layout Widgets => Error
      //getListTileWidget(const ErrorWidget(exception), "Choice Chip Widget"),

      //Layout Widgets => expanded
      getListTileWidget(const ExpandIconWidget(), "Expand Icon Widget"),
      getListTileWidget(const ExpandedWidget(), "Expanded Widget"),
      getListTileWidget(
          const ExpansionPanelListWidget(), "Expansion Panel List Widget"),
      getListTileWidget(const ExpansionTileWidget(), "Expansion Tile Widget"),

      //Layout Widgets => Grid
      getListTileWidget(const GridPaperWidget(), "Grid Paper Widget"),
      getListTileWidget(const GridTileBarWidget(), "Grid Tile Bar Widget"),
      getListTileWidget(const GridTileWidget(), "Grid Tile Widget"),
      getListTileWidget(const GridViewWidget(), "Grid View Widget"),
      getListTileWidget(const SliverGridWidget(), "Sliver Grid Widget"),

      //Layout Widgets => List
      getListTileWidget(const AboutListTileWidget(), "About List Tile Widget"),
      getListTileWidget(const ListTileWidget(), "List Tile Widget"),
      getListTileWidget(const ListViewWidget(), "List View Widget"),
      getListTileWidget(
          const ListWheelScrollViewWidget(), "List Wheel Scroll View Widget"),
      getListTileWidget(const SliverAppBarWidget(), "Sliver App Bar Widget"),
      getListTileWidget(const SliverFixedExtentListWidget(),
          "Sliver Fixed Extent List Widget"),
      getListTileWidget(const SliverListWidget(), "Sliver List Widget"),
      getListTileWidget(const SliverOpacityWidget(), "Sliver Opacity Widget"),
      getListTileWidget(const SliverPaddingWidget(), "Sliver Padding Widget"),

      //Layout Widgets => Menu
      getListTileWidget(const DrawerHeaderWidget(), "Drawer Header Widget"),
      getListTileWidget(const FlowWidget(), "Flow Widget"),
      getListTileWidget(const PlatformMenuWidget(), "Platform Menu Widget"),

      //Layout Widgets => Bottom Navigation
      getListTileWidget(
          const BottomNavigationBarWidget(), "Bottom Navigation Bar Widget"),
      getListTileWidget(const NavigationBarWidget(), "Navigation Bar Widget"),
      getListTileWidget(
          const TabPageSelectorWidget(), "Tab Page Selector Widget"),

      //Layout Widgets => Top Navigation
      getListTileWidget(const TabBarWidget(), "Tab Bar Widget"),

      //Layout Widgets => Shaped
      getListTileWidget(const CircleAvatarWidget(), "Circle Avatar Widget"),
      getListTileWidget(const ClipOvalWidget(), "Clip Oval Widget"),
      getListTileWidget(const ClipPathWidget(), "Clip Path Widget"),
      getListTileWidget(const ClipRectWidget(), "Clip Rect Widget"),
      getListTileWidget(const ColoredBoxWidget(), "Colored Box Widget"),
      getListTileWidget(const ConstrainedBoxWidget(), "Constrained Box Widget"),
      getListTileWidget(const FittedBoxWidget(), "Fitted Box Widget"),
      getListTileWidget(
          const FractionalTranslationWidget(), "Fractional Translation Widget"),
      getListTileWidget(
          const FractionallySizedBoxWidget(), "Fractionally Sized Box Widget"),
      getListTileWidget(const RotatedBoxWidget(), "Rotated Box Widget"),
      getListTileWidget(const SizedBoxWidget(), "Sized Box Widget"),
      getListTileWidget(
          const SliverToBoxAdapterWidget(), "Sliver To Box Adapter Widget"),
      getListTileWidget(const TransformWidget(), "Transform Widget"),

      //Layout Widgets
      getListTileWidget(const DividerWidget(), "Divider Widget"),
      getListTileWidget(const LayoutBuilderWidget(), "Layout Builder Widget"),
      getListTileWidget(const MaterialAppWidget(), "Material App Widget"),
      getListTileWidget(const OpacityWidget(), "Opacity Widget"),
      getListTileWidget(
          const OrientationBuilderWidget(), "Orientation Builder Widget"),
      getListTileWidget(const OverflowBarWidget(), "Over flow Bar Widget"),
      getListTileWidget(const PaddingWidget(), "Padding Widget"),
      getListTileWidget(
          const VerticalDividerWidget(), "Vertical Divider Widget"),

      //Overlap Widgets
      getListTileWidget(const BaselineWidget(), "Baseline Widget"),
      getListTileWidget(const BlockSemanticsWidget(), "Block Semantics Widget"),
      getListTileWidget(const MergeSemanticsWidget(), "Merge Semantics Widget"),
      getListTileWidget(const OverflowBarWidget(), "Overflow Bar Widget"),
      getListTileWidget(const SemanticsWidget(), "Semantics Widget"),
      getListTileWidget(
          const SizedOverflowBoxWidget(), "Sized Overflow Widget"),
      getListTileWidget(const StackWidget(), "Stack Widget"),

      //Themed & Styled Widgets
      getListTileWidget(const DecoratedBoxWidget(), "Decorated Box Widget"),
      getListTileWidget(
          const DefaultTextStyleWidget(), "Default Text Style Widget"),
      getListTileWidget(const PhysicalModelWidget(), "Physical Model Widget"),
      getListTileWidget(const PhysicalShapeWidget(), "Physical Shape Widget"),
      getListTileWidget(const RichTextWidget(), "Rich Text Widget"),
      getListTileWidget(const ShaderMaskWidget(), "Shader Mask Widget"),
      getListTileWidget(const TextSpanWidget(), "Text Span Widget"),
      getListTileWidget(const TextWidget(), "Text Widget"),
      getListTileWidget(const ThemeWidget(), "Theme Widget"),

      // View Widgets
      getListTileWidget(
          const CustomScrollViewWidget(), "Custom Scroll View Widget"),
      getListTileWidget(const DataTableWidget(), "DataTable Widget"),
      getListTileWidget(
          const InteractiveViewerWidget(), "Interactive Viewer Widget"),
      getListTileWidget(const PageViewWidget(), "PageView Widget"),
      getListTileWidget(
          const ReorderableListViewWidget(), "Reorderable List View Widget"),
      getListTileWidget(const SingleChildScrollViewWidget(),
          "Single Child Scroll View Widget"),
      getListTileWidget(const TableWidget(), "Table Widget"),
      getListTileWidget(const WrapWidget(), "Wrap Widget"),
    ]);
  }

  Widget getListTileWidget(Widget bindWidget, String title) {
    return ListTile(
      title: Text(title),
      tileColor: Colors.white30,
      onTap: () {
        //print("navgating to...");
        Navigator.of(context).push(MaterialPageRoute(builder: (context) {
          return Scaffold(
            appBar: AppBar(
              title: Text(title),
            ),
            body: bindWidget,
          );
        }));
      },
      leading: const Icon(Icons.widgets),
      trailing: const Icon(Icons.arrow_forward),
    );
  }
}
