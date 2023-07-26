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
  const FlutterWidgetList({Key? key, this.viewType = ''}) : super(key: key);
  final String viewType;

  @override
  State<FlutterWidgetList> createState() =>
      // ignore: no_logic_in_create_state
      _FlutterWidgetListState(viewType: viewType);
}

class _FlutterWidgetListState extends State<FlutterWidgetList> {
  _FlutterWidgetListState({this.viewType = ''});
  final String viewType;

  @override
  Widget build(BuildContext context) {
    if (viewType == "list") {
      return ListView(children: _getListViewDataList());
    } else {
      return ListView(children: _getExpansionTileDataList());
    }
  }

  Widget _getListTileWidget(Widget bindWidget, String title) {
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

  Widget _getExpansionTileWidget(List<Widget> bindWidgets, String title) {
    return ExpansionTile(
      title: Text(title),
      onExpansionChanged: (bool expanded) {},
      controlAffinity: ListTileControlAffinity.trailing,
      children: bindWidgets,
    );
  }

  List<Widget> _getListViewDataList() {
    List<Widget> allWidgets = <Widget>[];

    allWidgets.addAll(_getActionWidgets());
    allWidgets.addAll(_getAnimatedWidgets());
    allWidgets.addAll(_getCupertionWidgets());
    allWidgets.addAll(_getCustomWidgets());
    allWidgets.addAll(_getIconWidgets());
    allWidgets.addAll(_getImageWidgets());
    allWidgets.addAll(_getInputWidgets());
    allWidgets.addAll(_getBannerWidgets());
    allWidgets.addAll(_getBarWidgets());
    allWidgets.addAll(_getCardWidgets());
    allWidgets.addAll(_getContainerWidgets());
    allWidgets.addAll(_getDialogWidgets());
    allWidgets.addAll(_getDragWidgets());
    allWidgets.addAll(_getErrorWidgets());
    allWidgets.addAll(_getExpandedWidgets());
    allWidgets.addAll(_getGridWidgets());
    allWidgets.addAll(_getListWidgets());
    allWidgets.addAll(_getMenuWidgets());
    allWidgets.addAll(_getBottomNavWidgets());
    allWidgets.addAll(_getTopNavWidgets());
    allWidgets.addAll(_getShapedWidgets());
    allWidgets.addAll(_getOthersWidgets());
    allWidgets.addAll(_getOverlapWidgets());
    allWidgets.addAll(_getThemedStyledWidgets());
    allWidgets.addAll(_getViewWidgets());

    return allWidgets;
  }

  List<Widget> _getExpansionTileDataList() {
    return [
      _getExpansionTileWidget(_getActionWidgets(), "Action Widgets"),
      _getExpansionTileWidget(_getAnimatedWidgets(), "Animated Widgets"),
      _getExpansionTileWidget(_getCupertionWidgets(), "Cupertion Widgets"),
      _getExpansionTileWidget(_getCustomWidgets(), "Custom Widgets"),
      _getExpansionTileWidget(_getIconWidgets(), "Icon Widgets"),
      _getExpansionTileWidget(_getImageWidgets(), "Image Widgets"),
      _getExpansionTileWidget(_getInputWidgets(), "Input Widgets"),
      _getExpansionTileWidget(_getBannerWidgets(), "Banner Widgets"),
      _getExpansionTileWidget(_getBarWidgets(), "Bar Widgets"),
      _getExpansionTileWidget(_getCardWidgets(), "Card Widgets"),
      _getExpansionTileWidget(_getContainerWidgets(), "Container Widgets"),
      _getExpansionTileWidget(_getDialogWidgets(), "Dialog Widgets"),
      _getExpansionTileWidget(_getDragWidgets(), "Drag Widgets"),
      //_getExpansionTileWidget(_getErrorWidgets(), "Error Widgets"),
      _getExpansionTileWidget(_getExpandedWidgets(), "Expanded Widgets"),
      _getExpansionTileWidget(_getGridWidgets(), "Grid Widgets"),
      _getExpansionTileWidget(_getListWidgets(), "List Widgets"),
      _getExpansionTileWidget(_getMenuWidgets(), "Menu Widgets"),
      _getExpansionTileWidget(
          _getBottomNavWidgets(), "Bottom Navigation Widgets"),
      _getExpansionTileWidget(_getTopNavWidgets(), "Top Navingation Widgets"),
      _getExpansionTileWidget(_getShapedWidgets(), "Shaped Widgets"),

      _getExpansionTileWidget(_getOverlapWidgets(), "Overlap Widgets"),
      _getExpansionTileWidget(
          _getThemedStyledWidgets(), "Themed Styled Widgets"),
      _getExpansionTileWidget(_getViewWidgets(), "View Widgets"),
      _getExpansionTileWidget(_getOthersWidgets(), "Others Widgets"),
    ];
  }

  List<Widget> _getActionWidgets() {
    return [
      //Action Widgets
      _getListTileWidget(const AbsorbPointerWidget(), "Absorb Pointer Widget"),
      _getListTileWidget(const ChipWidget(), "Chip Widget"),
      _getListTileWidget(const ChoiceChipWidget(), "Choice Chip Widget"),
      _getListTileWidget(const CloseButtonWidget(), "Close Button Widget"),
      _getListTileWidget(const DismissibleWidget(), "Dismissible Widget"),
      _getListTileWidget(
          const DropdownButtonWidget(), "Dropdown Button Widget"),
      _getListTileWidget(
          const ElevatedButtonWidget(), "Elevated Button Widget"),
      _getListTileWidget(const FilterChipWidget(), "Filter Chip Widget"),
      _getListTileWidget(
          const FloatingActionButtonWidget(), "Floating Action Button Widget"),
      _getListTileWidget(
          const GestureDetectorWidget(), "GestureDetector Widget"),
      _getListTileWidget(const IconButtonWidget(), "Icon Button Widget"),
      _getListTileWidget(const IgnorePointerWidget(), "Ignore Pointer Widget"),
      _getListTileWidget(const InkWellWidget(), "Ink Well Widget"),
      _getListTileWidget(const InputChipWidget(), "Input Chip Widget"),
      _getListTileWidget(const ListenerWidget(), "Listener Widget"),
      _getListTileWidget(
          const LongPressDraggableWidget(), "Long Press Draggable Widget"),
      _getListTileWidget(
          const MaterialButtonWidget(), "Material Button Widget"),
      _getListTileWidget(const ModalBarrierWidget(), "Modal Barrier Widget"),
      _getListTileWidget(const MouseCursorWidget(), "Mouse Cursor Widget"),
      _getListTileWidget(const MouseRegionWidget(), "Mouse Region Widget"),
      _getListTileWidget(
          const NotificationListenerWidget(), "Notification Listener Widget"),
      _getListTileWidget(const OffstageWidget(), "Offstage Widget"),
      _getListTileWidget(
          const OutlinedButtonWidget(), "Outlined Button Widget"),
      _getListTileWidget(
          const PopupMenuButtonWidget(), "Popup Menu Button Widget"),
      _getListTileWidget(const RawChipWidget(), "Raw Chip Widget"),
      _getListTileWidget(
          const SelectableTextWidget(), "Selectable Text Widget"),
      _getListTileWidget(const ShortcutsWidget(), "Shortcuts Widget"),
      _getListTileWidget(const SliderWidget(), "Slider Widget"),
      _getListTileWidget(const StepperWidget(), "Stepper Widget"),
      _getListTileWidget(const StreamBuilderWidget(), "Stream Builder Widget"),
      _getListTileWidget(
          const SwitchListTileWidget(), "Switch List Tile Widget"),
      _getListTileWidget(const SwitchWidget(), "Switch Widget"),
      _getListTileWidget(const TextButtonWidget(), "Text Button Widget"),
      _getListTileWidget(const ToggleButtonsWidget(), "Toggle Buttons Widget"),
      _getListTileWidget(
          const ValueListenableBuilderWidget(), "Value Listenable Widget"),
      _getListTileWidget(const VisibilityWidget(), "Visibility Widget"),
      _getListTileWidget(const WillPopScopeWidget(), "Will Pop Scope Widget"),
    ];
  }

  List<Widget> _getAnimatedWidgets() {
    return [
      //Animated Widgets
      _getListTileWidget(const CircularProgressIndicatorWidget(),
          "Circular Progress Indicator Widget"),
      _getListTileWidget(const FutureBuilderWidget(), "Future Builder Widget"),
      _getListTileWidget(const LinearProgressIndicatorWidget(),
          "Linear Progress Indicator Widget"),
      _getListTileWidget(
          const RefreshIndicatorWidget(), "Refresh Indicator Widget"),
      _getListTileWidget(const AnimatedAlignWidget(), "Animated Align Widget"),
      _getListTileWidget(
          const AnimatedBuilderWidget(), "Animate dBuilder Widget"),
      _getListTileWidget(
          const AnimatedContainerWidget(), "Animated Container Widget"),
      _getListTileWidget(
          const AnimatedCrossFadeWidget(), "Animated CrossFade Widget"),
      _getListTileWidget(const AnimatedDefaultTextStyleWidget(),
          "Animated Default TextSty Widget"),
      _getListTileWidget(const AnimatedIconWidget(), "Animated Icon Widget"),
      _getListTileWidget(const AnimatedListWidget(), "Animated List Widget"),
      _getListTileWidget(
          const AnimatedModalBarrierWidget(), "Animated Modal Widget"),
      _getListTileWidget(
          const AnimatedOpacityWidget(), "Animated Opacity Widget"),
      _getListTileWidget(
          const AnimatedPaddingWidget(), "Animated Padding Widget"),
      _getListTileWidget(const AnimatedPhysicalModelWidget(),
          "Animated Physical Model Widget"),
      _getListTileWidget(
          const AnimatedPositionedWidget(), "Animated Positioned Widget"),
      _getListTileWidget(
          const AnimatedRotationWidget(), "Animated Rotation Widget"),
      _getListTileWidget(const AnimatedSizeWidget(), "Animated Size Widget"),
      _getListTileWidget(
          const AnimatedSwitcherWidget(), "Animated Switcher Widget"),
      _getListTileWidget(const MyAnimatedWidget(), "My Animated Widget"),
      _getListTileWidget(const DecoratedBoxTransitionWidget(),
          "Decorated Box Transition Widget"),
      _getListTileWidget(const FadeInImageWidget(), "Fade-In Image Widget"),
      _getListTileWidget(const FadeTransitionWidget(), "FadeTransition Widget"),
      _getListTileWidget(const HeroWidget(), "Hero Widget"),
      _getListTileWidget(const PositionedWidget(), "Positioned Widget Widget"),
      _getListTileWidget(
          const RotationTransitionWidget(), "Rotation Transition Widget"),
      _getListTileWidget(
          const ScaleTransitionWidget(), "Scale Transition Widget"),
      _getListTileWidget(
          const SizeTransitionWidget(), "Size Transition Widget"),
      _getListTileWidget(
          const SlideTransitionWidget(), "Slide Transition Widget"),
      _getListTileWidget(const TweenAnimationBuilderWidget(),
          "Tween Animation Builder Widget"),
    ];
  }

  List<Widget> _getCupertionWidgets() {
    return [
      //Cupertion Widgets
      _getListTileWidget(const CupertinoActionSheetActionWidget(),
          "Cupertino Action Sheet Widget"),
      _getListTileWidget(const CupertinoActivityIndicatorWidget(),
          "Cupertino Activity Indicator Widget"),
      _getListTileWidget(
          const CupertinoAlertDialogWidget(), "Cupertino Alert Dialog Widget"),
      _getListTileWidget(const CupertinoAppWidget(), "Cupertino App Widget"),
      _getListTileWidget(
          const CupertinoButtonWidget(), "Cupertino Button Widget"),
      _getListTileWidget(
          const CupertinoContextMenuWidget(), "Cupertino Context Menu Widget"),
      _getListTileWidget(
          const CupertinoDatePickerWidget(), "Cupertino Date Picker Widget"),
      _getListTileWidget(
          const CupertinoPageRouteWidget(), "Cupertino Page Route Widget"),
      _getListTileWidget(const CupertinoPageScaffoldWidget(),
          "Cupertino Page Scaffold Widget"),
      _getListTileWidget(CupertinoSearchTextFieldWidget(),
          "Cupertino Search Text Field Widget"),
      _getListTileWidget(const CupertinoSegmentedControlWidget(),
          "Cupertino Segmented Control Widget"),
      _getListTileWidget(
          const CupertinoSliderWidget(), "Cupertino Slider Widget"),
      _getListTileWidget(const CupertinoSlidingSegmentedControlWidget(),
          "Cupertino Sliding Segmented Control Widget"),
      _getListTileWidget(
          const CupertinoSwitchWidget(), "Cupertino Switch Widget"),
      _getListTileWidget(
          const CupertinoTabBarWidget(), "Cupertino Tab Bar Widget"),
      _getListTileWidget(
          const CupertinoTabScaffoldWidget(), "Cupertino Tab Scaffold Widget"),
      _getListTileWidget(
          const CupertinoTabViewWidget(), "Cupertino Tab View Widget"),
      _getListTileWidget(
          CupertinoTextFieldWidget(), "Cupertino Text Field Widget"),
    ];
  }

  List<Widget> _getCustomWidgets() {
    return [
      //Custom Widgets
      _getListTileWidget(const BuilderWidget(), "Builder Widget"),
      _getListTileWidget(const CustomPaintWidget(), "Custom Paint Widget"),
    ];
  }

  List<Widget> _getIconWidgets() {
    return [
      //Icon Widgets
      _getListTileWidget(const FlutterLogoWidget(), "Flutter Logo Widget"),
      _getListTileWidget(const IconWidget(), "Icon Widget"),
    ];
  }

  List<Widget> _getImageWidgets() {
    return [
      //Image Widgets
      _getListTileWidget(const ImageNetworkWidget(), "Image Network Widget"),
      _getListTileWidget(const ImageWidget(), "Image Widget"),
      _getListTileWidget(const PlaceholderWidget(), "Placeholder Widget"),
      _getListTileWidget(const PositionedWidget(), "Positioned Widget"),
      _getListTileWidget(const TooltipWidget(), "Tooltip Widget"),
    ];
  }

  List<Widget> _getInputWidgets() {
    return [
      //Input Widgets
      _getListTileWidget(const AutoCompleteWidget(), "Auto Complete Widget"),
      _getListTileWidget(
          const CheckBoxListTileWidget(), "Check Box List Tile Widget"),
      _getListTileWidget(const CheckBoxWidget(), "Check Box Widget"),
      _getListTileWidget(const DatePickerWidget(), "Date Picker Widget"),
      _getListTileWidget(
          const DateRangePickerWidget(), "Date Range Picker Widget"),
      _getListTileWidget(FormWidget(), "Form Widget"),
      _getListTileWidget(const RadioListTileWidget(), "Radio List Tile Widget"),
      _getListTileWidget(const RadioWidget(), "Radio Widget"),
      _getListTileWidget(const RangeSliderWidget(), "Range Slider Widget"),
      _getListTileWidget(
          const RawAutocompleteWidget(), "Raw Autocomplete Widget"),
      _getListTileWidget(const TextFieldWidget(), "Text Field Widget"),
      _getListTileWidget(const TextFormFieldWidget(), "Text Form Field Widget"),
    ];
  }

  List<Widget> _getBannerWidgets() {
    return [
      //Layout Widgets => Banner
      _getListTileWidget(
          const MaterialBannerWidget(), "Material Banner Widget"),
    ];
  }

  List<Widget> _getBarWidgets() {
    return [
      //Layout Widgets => Bar
      _getListTileWidget(const AppBarWidget(), "App Bar Widget"),
      _getListTileWidget(
          const PreferredSizedWidget(), "Preferred Sized Widget"),
      _getListTileWidget(const ScrollBarWidget(), "Scrollbar Widget"),
      _getListTileWidget(const SnackBarWidget(), "SnackBar Widget"),
    ];
  }

  List<Widget> _getCardWidgets() {
    return [
      //Layout Widgets => Card
      _getListTileWidget(const CardWidget(), "Card Widget"),
      _getListTileWidget(const ClipRRectWidget(), "Clip R Rect Widget"),
      _getListTileWidget(const ColorFilteredWidget(), "ColorFiltered Widget"),
      _getListTileWidget(const LimitedBoxWidget(), "Limited Box Widget"),
    ];
  }

  List<Widget> _getContainerWidgets() {
    return [
      //Layout Widgets => Container
      _getListTileWidget(const AlignWidget(), "Align Widget"),
      _getListTileWidget(const AspectRatioWidget(), "AspectRatio Widget"),
      _getListTileWidget(
          const BackdropFilterWidget(), "Backdrop Filter Widget"),
      _getListTileWidget(const BannerWidget(), "Banner Widget"),
      _getListTileWidget(const BottomSheetWidget(), "Bottom Sheet Widget"),
      _getListTileWidget(const CenterWidget(), "Center Widget"),
      _getListTileWidget(const ColumnWidget(), "Column Widget"),
      _getListTileWidget(const ContainerWidget(), "Container Widget"),
      _getListTileWidget(const FlexibleWidget(), "Flexible Widget"),
      _getListTileWidget(const IndexedStackWidget(), "Indexed Stack Widget"),
      _getListTileWidget(const RowWidget(), "Row Widget"),
      _getListTileWidget(const ScaffoldWidget(), "Scaffold Widget"),
      _getListTileWidget(const SpacerWidget(), "Spacer Widget"),
    ];
  }

  List<Widget> _getDialogWidgets() {
    return [
      //Layout Widgets => Dialog
      _getListTileWidget(const AboutDialogWidget(), "About Dialog Widget"),
      _getListTileWidget(const AlertDialogWidget(), "Alert Dialog Widget"),
      _getListTileWidget(const SimpleDialogWidget(), "Simple Dialog Widget"),
    ];
  }

  List<Widget> _getDragWidgets() {
    return [
      //Layout Widgets => Drag
      _getListTileWidget(const DragTargetWidget(), "Drag Target Widget"),
      _getListTileWidget(const DraggableScrollableSheetWidget(),
          "Draggable Scrollable Sheet Widget"),
      _getListTileWidget(const DraggableWidget(), "Draggable Widget"),
    ];
  }

  List<Widget> _getErrorWidgets() {
    return [
      //Layout Widgets => Error
      //_getListTileWidget(const ErrorWidget(exception), "Choice Chip Widget"),
    ];
  }

  List<Widget> _getExpandedWidgets() {
    return [
      //Layout Widgets => Expanded
      _getListTileWidget(const ExpandIconWidget(), "Expand Icon Widget"),
      _getListTileWidget(const ExpandedWidget(), "Expanded Widget"),
      _getListTileWidget(
          const ExpansionPanelListWidget(), "Expansion Panel List Widget"),
      _getListTileWidget(const ExpansionTileWidget(), "Expansion Tile Widget"),
    ];
  }

  List<Widget> _getGridWidgets() {
    return [
      //Layout Widgets => Grid
      _getListTileWidget(const GridPaperWidget(), "Grid Paper Widget"),
      _getListTileWidget(const GridTileBarWidget(), "Grid Tile Bar Widget"),
      _getListTileWidget(const GridTileWidget(), "Grid Tile Widget"),
      _getListTileWidget(const GridViewWidget(), "Grid View Widget"),
      _getListTileWidget(const SliverGridWidget(), "Sliver Grid Widget"),
    ];
  }

  List<Widget> _getListWidgets() {
    return [
      //Layout Widgets => List
      _getListTileWidget(const AboutListTileWidget(), "About List Tile Widget"),
      _getListTileWidget(const ListTileWidget(), "List Tile Widget"),
      _getListTileWidget(const ListViewWidget(), "List View Widget"),
      _getListTileWidget(
          const ListWheelScrollViewWidget(), "List Wheel Scroll View Widget"),
      _getListTileWidget(const SliverAppBarWidget(), "Sliver App Bar Widget"),
      _getListTileWidget(const SliverFixedExtentListWidget(),
          "Sliver Fixed Extent List Widget"),
      _getListTileWidget(const SliverListWidget(), "Sliver List Widget"),
      _getListTileWidget(const SliverOpacityWidget(), "Sliver Opacity Widget"),
      _getListTileWidget(const SliverPaddingWidget(), "Sliver Padding Widget"),
    ];
  }

  List<Widget> _getMenuWidgets() {
    return [
      //Layout Widgets => Menu
      _getListTileWidget(const DrawerHeaderWidget(), "Drawer Header Widget"),
      _getListTileWidget(const FlowWidget(), "Flow Widget"),
      _getListTileWidget(const PlatformMenuWidget(), "Platform Menu Widget"),
    ];
  }

  List<Widget> _getBottomNavWidgets() {
    return [
      //Layout Widgets => Bottom Navigation
      _getListTileWidget(
          const BottomNavigationBarWidget(), "Bottom Navigation Bar Widget"),
      _getListTileWidget(const NavigationBarWidget(), "Navigation Bar Widget"),
      _getListTileWidget(
          const TabPageSelectorWidget(), "Tab Page Selector Widget"),
    ];
  }

  List<Widget> _getTopNavWidgets() {
    return [
      //Layout Widgets => Top Navigation
      _getListTileWidget(const TabBarWidget(), "Tab Bar Widget"),
    ];
  }

  List<Widget> _getShapedWidgets() {
    return [
      //Layout Widgets => Shaped
      _getListTileWidget(const CircleAvatarWidget(), "Circle Avatar Widget"),
      _getListTileWidget(const ClipOvalWidget(), "Clip Oval Widget"),
      _getListTileWidget(const ClipPathWidget(), "Clip Path Widget"),
      _getListTileWidget(const ClipRectWidget(), "Clip Rect Widget"),
      _getListTileWidget(const ColoredBoxWidget(), "Colored Box Widget"),
      _getListTileWidget(
          const ConstrainedBoxWidget(), "Constrained Box Widget"),
      _getListTileWidget(const FittedBoxWidget(), "Fitted Box Widget"),
      _getListTileWidget(
          const FractionalTranslationWidget(), "Fractional Translation Widget"),
      _getListTileWidget(
          const FractionallySizedBoxWidget(), "Fractionally Sized Box Widget"),
      _getListTileWidget(const RotatedBoxWidget(), "Rotated Box Widget"),
      _getListTileWidget(const SizedBoxWidget(), "Sized Box Widget"),
      _getListTileWidget(
          const SliverToBoxAdapterWidget(), "Sliver To Box Adapter Widget"),
      _getListTileWidget(const TransformWidget(), "Transform Widget"),
    ];
  }

  List<Widget> _getOthersWidgets() {
    return [
      //Layout Widgets => Others
      _getListTileWidget(const DividerWidget(), "Divider Widget"),
      _getListTileWidget(const LayoutBuilderWidget(), "Layout Builder Widget"),
      _getListTileWidget(const MaterialAppWidget(), "Material App Widget"),
      _getListTileWidget(const OpacityWidget(), "Opacity Widget"),
      _getListTileWidget(
          const OrientationBuilderWidget(), "Orientation Builder Widget"),
      _getListTileWidget(const OverflowBarWidget(), "Over flow Bar Widget"),
      _getListTileWidget(const PaddingWidget(), "Padding Widget"),
      _getListTileWidget(
          const VerticalDividerWidget(), "Vertical Divider Widget"),
    ];
  }

  List<Widget> _getOverlapWidgets() {
    return [
      //Overlap Widgets
      _getListTileWidget(const BaselineWidget(), "Baseline Widget"),
      _getListTileWidget(
          const BlockSemanticsWidget(), "Block Semantics Widget"),
      _getListTileWidget(
          const MergeSemanticsWidget(), "Merge Semantics Widget"),
      _getListTileWidget(const OverflowBarWidget(), "Overflow Bar Widget"),
      _getListTileWidget(const SemanticsWidget(), "Semantics Widget"),
      _getListTileWidget(
          const SizedOverflowBoxWidget(), "Sized Overflow Widget"),
      _getListTileWidget(const StackWidget(), "Stack Widget"),
    ];
  }

  List<Widget> _getThemedStyledWidgets() {
    return [
      //Themed & Styled Widgets
      _getListTileWidget(const DecoratedBoxWidget(), "Decorated Box Widget"),
      _getListTileWidget(
          const DefaultTextStyleWidget(), "Default Text Style Widget"),
      _getListTileWidget(const PhysicalModelWidget(), "Physical Model Widget"),
      _getListTileWidget(const PhysicalShapeWidget(), "Physical Shape Widget"),
      _getListTileWidget(const RichTextWidget(), "Rich Text Widget"),
      _getListTileWidget(const ShaderMaskWidget(), "Shader Mask Widget"),
      _getListTileWidget(const TextSpanWidget(), "Text Span Widget"),
      _getListTileWidget(const TextWidget(), "Text Widget"),
      _getListTileWidget(const ThemeWidget(), "Theme Widget"),
    ];
  }

  List<Widget> _getViewWidgets() {
    return [
      // View Widgets
      _getListTileWidget(
          const CustomScrollViewWidget(), "Custom Scroll View Widget"),
      _getListTileWidget(const DataTableWidget(), "DataTable Widget"),
      _getListTileWidget(
          const InteractiveViewerWidget(), "Interactive Viewer Widget"),
      _getListTileWidget(const PageViewWidget(), "PageView Widget"),
      _getListTileWidget(
          const ReorderableListViewWidget(), "Reorderable List View Widget"),
      _getListTileWidget(const SingleChildScrollViewWidget(),
          "Single Child Scroll View Widget"),
      _getListTileWidget(const TableWidget(), "Table Widget"),
      _getListTileWidget(const WrapWidget(), "Wrap Widget"),
    ];
  }
}
