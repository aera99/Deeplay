   M S B A M L   `   `   `  ����D  @DeePlayTZ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:DeePlayTZ.ViewDeePlayTZ.View  5   	   #    DeePlayTZ.View.EmployeeEditor   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:DeePlayTZ.View     5   	   $	��300��5   $   $	��500��61     � 
ResizeMode$  NoResize=�5	   	   ���	#FF579077 � Title 5   	   �� *
TitleTxt+.��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      $��35 �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   � $��0��6   $��0��6   .+�5      �� $��Имя��6   $��10,10,10,83q�6#   �� 5      $��10,47,10,10q�6    �� TextWrapping$
 Wrap=�6+   ��6?   �� *	FirstName+5      � 5   
   $��1��6   $��0��6   .+�5      �� $��Фамилия��6   $��10,10,10,83q�6'   �� 5      $��10,47,10,10q�6   $
 Wrap=�6+   ��6?   �� *
LastName+5      � 5    
   $��2��6   $��0��6   .+�5!      �� $��Отчество��6   $��10,10,10,83q�6(   �� 5"      $��10,47,10,10q�6   $
 Wrap=�6+   ��6?   �� *
MiddleName+5#      � 5$   
   $��0��6   $��1��6   .+�5%      �� $��10q�6   .+�5&      	� $��Мужчина��6    d� 	IsChecked 60   �� *IsMan+	� 5'      $��Женщина��6    60   �� *	IsWoman+5(      5)      � 5*   
   $��1��6   $��1��6   .+�5+      �� $��Должность��6   $��10,10,10,85q�6)   �� 5,      $��10,45,10,10q�6    �� SelectedIndex$ 0��6R   ��6,   �� *PositionsView+ �� SelectedItem 6d   �� *SelectedPosition+5-      � 5.   
   $��2��6   $��1��6   .+�5/      �� $��
Отдел��6   $��10,10,10,85q�6%   �� 50      $��10,45,10,10q�6   $ 0��6T   ��6,   �� *DepartmentsView+ 6f   �� *SelectedDepartment+51      �� 52   
   $��1��6   $��2��6!   $��5q�6.   $��Добавить��69   ��6L   �� *AddEmployee+�� 53   
   $��2��6   $��2��6!   $��5q�6.   $��Отменить��69    �� IsCancel$
 True��6L   54      55      