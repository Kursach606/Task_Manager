   M S B A M L   `   `   `  ����F  BTaskManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TaskManagerTaskManager  5   	        TaskManager.EditTaskWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TaskManager     5   	     � Title$  EditTaskWindow��5   	    � SizeToContent$ WidthAndHeight=�6    .��5	      � ��5
   
   �� 5       �� ImageSource$ /Фонн.jpg��6    �� Opacity$	 0.6Q�61    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Название:��6   $��
10,10,10,0q�6$   �� 5   
   -   5         ��Name$ nameTextBox��5      $��0��6'   $��130,10,10,0q�64   �� 5   
   $��Описание:��6   $��
10,79,10,0q�6$   $��1��68   �� 5   
   -   5        $ descriptionTextBox��5      $��1��6.   $��130,77,10,0q�6;   �� 5   
   $$��Срок выполнения:��6   $��10,212,10,0q�6+   $��2��6@   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dueDatePicker��5      $��2��6,   $��130,212,10,0q�69   ��6O   Z� �� 5   
   $��Приоритет:��6   $��10,252,10,0q�6%   $��3��6:   �� 5   
   -   5         ��Name$ priorityComboBox��5      $��3��6-   $��130,252,10,0q�6:   ��6P   Z� ��5       �� 5!       �� EndPoint$	 0,1&�6&   .��5"      � 	 � Color$	 	#FFF0F0F0��6#   � 5#      $	 White��6#   
 � Offset$
 1Q�61   5$      .@�5&      �� $��1��6   �� 5'      $��2��6   �� 5(      $��3��6   �� 5)      $��4��6   �� 5*      $��5��6   �� 5+      $��6��6   �� 5,      $��7��6   �� 5-      $��8��6   �� 5.      $��9��6   �� 5/      $��10��6   50      �� 52   
   -   5        $��Обновить��52      $��4��6=   $��Right=�6J   $��10,10,10,10q�6f   
���������6�   Z� �� 53   
   -   5        $��Отмена��53      $��4��67   $
��Left=�6D   $��10,10,10,10q�6_   
���������6t   Z� 6�   54      55      