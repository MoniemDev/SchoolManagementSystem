   M S B A M L   `   `   `  ����Q  MSchoolManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:SchoolManagementSystem.ViewsSchoolManagementSystem.Views  5   	   U/clr-namespace:SchoolManagementSystem.ViewModels!SchoolManagementSystem.ViewModels  5   	   .    (SchoolManagementSystem.Views.LoginWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:SchoolManagementSystem.Views     5   	   F
viewmodels/clr-namespace:SchoolManagementSystem.ViewModels     5   	     � Title$B  <تسجيل الدخول - نظام إدارة المدرسة��5	   	   $	��450��5
   	   $	��400��6    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � DataContext 5      6   0SchoolManagementSystem.ViewModels.LoginViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6      PrimaryBrush#��[  6    �� Padding$ 20q�6I   ._�5      �� .+�5      �� $(��"نظام إدارة المدرسة��6   
�������$��24(�5      $
��Bold"�5      $��Center=�5       �� 5!      $��تسجيل الدخول��6   
�������$��16(�5#      $��Center=�5$      $��0,5,0,0q�5%      5&      5'      �� 5*   
   $��1��6     CardBackgroundBrush#��[ 5+      $��20q�5,      $ 20q�5-       �� CornerRadius$ 5��5.        DividerBrush#��[ 5/      $��1q�50      ._�51      �� $��Center=�6   .+�52      �� $ ��/Resources/Images/logo.png��6   $��80��53      $��80��54      $��0,0,0,20q�55      �� 57      $��اسم المستخدم��6   $��0,0,0,5q�58      �� 59        BaseTextBoxStyle#��[ 5:      $��0,0,0,15q�5;      ��59      �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�5;      �� 5=      $��كلمة المرور��6   $��0,0,0,5q�5>      G� 5?      -   5         G�Name$ PasswordBox��5?        PasswordBoxStyle#��[ 5@      $��0,0,0,20q�5A      �� 5C        
ErrorBrush#��[ 5D      $
��Wrap=�5E      $��0,0,0,15q�5F      ��5C      �� *ErrorMessage+y�5G      �� *ErrorMessage+  StringToVisibilityConverter	 �� 	Converter#	 [ �� 5I      $��تسجيل الدخول��6     PrimaryButton#��[ 5J      ��5K      �� *LoginCommand+��5L      �� 
 �� ElementName$
 PasswordBox��{�5M      �� *	IsLoading+  InverseBooleanConverter#	 [ � 5O       � IsIndeterminate$
 True��6   $��5��5P      $��0,10,0,0q�5Q      y�5R      �� *	IsLoading+  	 BooleanToVisibilityConverter#	 [	 5S      5T      �� 5W   
   $��2��6   $U��O© 2025 نظام إدارة المدرسة - جميع الحقوق محفوظة��5X      $��Center=�5Y       
 TextSecondaryBrush#��[
 5Z      $��0,0,0,10q�5[      5\      5]      