   M S B A M L   `   `   `  ����E  ASPECFILE_M, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SPECFILE_M
SPECFILE_M  5   	       SPECFILE_M.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:SPECFILE_M     5   	     � Title$  
MainWindow��5   	   $	��700��6   $	��950��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   6-   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,    � ColumnDefinitions 5   
   �� 5      $��70 �6   6,   �� 5      $��* �6   6+   .+�5   
   �� -   5        $��lblAttachments��5       $��2��5      $��0��6   $	��Top=�5      $	��Top=�5      $
��Left=�5      $
��Left=�5      $��10,18,-20,0q�5      $��80��5    &   .��61   Attachments:6?   �� 5!   
   -   5        $��txtAttachment��5'      $��2��5!      $��1��6   $	��Top=�5"      $��Center=�5#      $
��Left=�5$      $
��Left=�5%      $��	20,18,0,0q�5&      $	��682��5(      $��30��5)      ��5*      �� *txtAttachment+ �� Mode$ OneWay=�.��6>   5+      �� 5,   
   -   5        $��	uploadBtn��5-      $��2��5,      $��1��6   $��Upload File��5.      $
��Left=�5/      $��730,18,0,-2q�50      $	��110��51       J� RenderTransformOrigin$ 0.267,6.615&�52       �� 53   
   -   5         ��Name$ listView��53      $��4��6%   $	��605��62   $��20,18,0,-42q�6>   $	��100��6S   $	��Top=�6`   $
��Left=�6x   $��1��6�   $��6��6�    �� View 54      �� 55      .P�56      �� $��Files Attached��6%    �� Width$	 500��6t    �� DisplayMemberBinding 6=   �� *
fileName+$ OneWay=�6t   �� 57      $��
Files Size��6%   $
 Auto��6p    69   �� *
fileSize+$ OneWay=�6p   58      5:      �� 5;   
   -   5        $��	lblToster��5A      $��3��5;      $��1��6   $	��Top=�5<      $	��Top=�5=      $
��Left=�5>      $
��Left=�5?      $��	20,18,0,0q�5@      $	��682��5A   !   6/   �� 5C   
   -   5        $��9��5C      $��1��6   $��Start��5D      $
��Left=�5E      $��515,0,0,-97.633q�5F      $	��110��5G      $ 0.267,6.615&�5H      $��26.633��6C   $��Bottom=�6S   �� 5I   
   -   5        $��logger��5O      $��9��5I      $��1��6   $	��Top=�5J      $	��Top=�5K      $
��Left=�5L      $
��Left=�5M      $��20,165,0,-447.444q�5N      $	��682��5P      $	��339��5Q      ��5R      �� *logger+$ OneWay=�.��67   5S      5T      5U      