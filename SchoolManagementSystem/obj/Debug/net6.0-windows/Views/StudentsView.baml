   M S B A M L   `   `   `  ����Q  MSchoolManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:SchoolManagementSystem.ViewsSchoolManagementSystem.Views  5      /    )SchoolManagementSystem.Views.StudentsView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:SchoolManagementSystem.Views     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��0,0,0,20q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� $��0��6   $��إدارة الطلاب��5         Heading1#��[  5      �� 5      $��1��6     PrimaryButton#��[ 5      ��5      �� *AddStudentCommand+.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5       �� $	����6    $��Segoe MDL2 Assets)�5!       $��Center=�5"       $��0,0,8,0q�5#       �� 5$      $"��إضافة طالب جديد��6    5%      5&      5'      � 5*   
   $��1��6   $��0,0,0,20q�6    5+      �� 5,      $��* �6#   �� 5-      $
��Auto �6#   .+�50      �� $��0��6     SearchTextBox#��[ 52      $��0,0,10,0q�53      ��51      �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�53      �� 55      $��1��6     
IconButton#��[ 56       � ToolTip$! تحديث البيانات��58      ��57      �� *RefreshCommand+.��59      �� $	����6   $��Segoe MDL2 Assets)�5:        PrimaryBrush#��[ 5;      5<      5=      �� 5@   
   $��2��6     CardBackgroundBrush#��[ 5A        DividerBrush#��[ 5B      $��1q�5C       �� CornerRadius$ 5��5D      ._�5E      � .+�5F      &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��5H         
IsReadOnly$
 True��5I         SelectionMode$ Single=�5J      	   GridLinesVisibility$	 
Horizontal=�5K      $��0q�5L      
������ 
   RowBackground

 ����    AlternatingRowBackground �#F5F5F5��5F      �� *
Students+ �� SelectedItem 5G      �� *SelectedStudent+   Columns 5P      4  .System.Windows.Controls.DataGridTemplateColumn  5Q      ,  &System.Windows.Controls.DataGridColumn   Header$ الصورة��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6A      CellTemplate 5R      �� 5S   "   .R�5T   &   �� $��50��6-   $��50��5U   -   $ 25��5V   -   $��5q�5W   -   ��5X   *   �� 5Y   .    j� Stretch$ UniformToFill=�5Z   9    �� ImageSource 5Y   9   �� *	PhotoPath+ �� TargetNullValue$+ %/Resources/Images/default_student.png��5Z   9   5\   '   5]   #   5_      0  *System.Windows.Controls.DataGridTextColumn  5a      $ رقم الطالب��6-   $	 100 5c   -   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5b   -   �� *	StudentId+5c   -     5e      $ 
الاسم��6-   $ * 5g   -    5f   -   �� *
FullName+5g   -     5i      $ 
الفصل��6-   $	 120 5k   -    5j   -   �� *
Class.Name+5k   -     5m      $ تاريخ الميلاد��6-   $	 120 5o   -    5n   -   �� *DateOfBirth+ �� StringFormat$ {0:dd/MM/yyyy}��5o   -     5q      $ الحالة��61   $	 100 6A    5r      �� 5s   "   .R�5t   &   �� $ 4��5u   -    �� Padding$	 8,4q�5v   -   $��Center=�5w   -   ��5t   -   �� *
IsActive+  BoolToStatusBrushConverter �� 	Converter# [ ._�5x   *   �� 
�������$��12(�5z   4   ��5x   4   �� *
IsActive+  BoolToStatusTextConverter# [ 5z   4   5{   '   5|   #   5~        5�      $ الإجراءات��61   $	 120 6D    5�      �� 5�   "   .R�5�   &   �� $ 
Horizontal=�61   $��Center=�6J   .+�5�   *   �� #��[ 61   $ 
تعديل��5�   1   ��5�   1   �� * DataContext.EditStudentCommand+ �� RelativeSource ��  �� AncestorType DataGrid��5�   1   �� .��5�   .   �� $	����68   $��Segoe MDL2 Assets)�5�   8   #��[ 5�   8   5�   +   �� 5�   *   #��[ 61   $ حذف��5�   1   ��5�   1   �� *" DataContext.DeleteStudentCommand+ ��  DataGrid��5�   1   �� .��5�   .   �� $	����68   $��Segoe MDL2 Assets)�5�   8    	 
ErrorBrush#��[	 5�   8   5�   +   5�   '   5�   #   5�      5�      �� 5�      $��لا يوجد طلاب��6   $��Center=�5�      $��Center=�5�       
 TextSecondaryBrush#��[
 5�      y�5�      �� *Students.Count+ ( $EmptyCollectionToVisibilityConverter# [ � 5�      ���	#80FFFFFFy�5�      �� *	IsLoading+   BooleanToVisibilityConverter# [ .+�5�      �� $��Center=�6!   $��Center=�5�   !   .+�5�      �  � IsIndeterminate$
 True��6&   $	��100��5�   &   $��4��5�   &   �� 5�      $-��'جاري تحميل البيانات...��6$   $��Center=�5�   $   $��0,10,0,0q�5�   $   5�      5�      �� 5�      ���#FFFBE0$ 15q�5�      $ 4��5�      y�5�      �� *ErrorMessage+  StringToVisibilityConverter# [ ._�5�      �� $ 
Horizontal=�6!   .+�5�      �� $	����6$   $��Segoe MDL2 Assets)�5�   $     WarningBrush#��[ 5�   $   $	��Top=�5�   $   $��0,0,10,0q�5�   $   �� 5�      $
��Wrap=�5�   $     TextPrimaryBrush#��[ 5�   $   ��5�   $   �� *ErrorMessage+5�   $   5�      5�      5�      5�      5�      5�      