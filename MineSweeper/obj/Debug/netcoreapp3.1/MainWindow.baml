   M S B A M L   `   `   `  ����F  BMineSweeper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MineSweeperMineSweeper  5   	   ?$clr-namespace:MineSweeper.ViewModelsMineSweeper.ViewModels  5   	       MineSweeper.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:MineSweeper     5   	   3vm$clr-namespace:MineSweeper.ViewModels     5   	     � Title$  MainMenu��5	   	   $	��500��6   $	��450��6'   $	��400��5
   	   $	��500��6   $	��500��5   	   $	��500��6    � DataContext 5      '   !MineSweeper.ViewModels.MainMenuVM  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��38 �6   �� 5      $	��102 �6   �� 5      .+�5   
   �� $��
Сапёр��6   $��1��6    $��Center=�6-   $��Center=�6J   $��48(�6e   $��74��6s   $	��146��6   �� 5   
   $��2��6   $��	50,0,50,0q�6"   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $!��Количество мин��6   �� 5      $��Center=�6H   ��6   ��  �� Path$ 
MinesCount� �� Mode$ TwoWay=�6H   5      �� 5      -   5         ��Name$ 
MinesCount��5      $��	20,0,20,0q�6)    � SmallChange$ 1Q�5       �� TickPlacement$ BottomRight=�6s   	 �� IsSnapToTickEnabled$
	 True��5      
 � Minimum
 5   %   �� $ MinMinesCount� � Maximum 6L   �� $ MaxMinesCount� � Value 5   0   �� $ 
MinesCount�$ TwoWay=��� 5      $ 
Horizontal=�6   .+�5       �� $��Ширина поля��6   �� 5!      $��Center=�6D   ��6   �� $ XCount�$ TwoWay=�6D   5"      �� 5#      -   5        $ XCount��5#      $��	20,0,20,0q�6%   $ 1Q�5$      $ BottomRight=�6q   $
	 True��5%      
 5$   %   �� $ MinCellCount� 6K   �� $ MaxCellCount� 5%   0   �� $ XCount�$ TwoWay=��� 5&      $ 
Horizontal=�6   .+�5'      �� $��Высота поля��6   �� 5(      $��Center=�6D   ��6   �� $ YCount�$ TwoWay=�6D   5)      �� 5*      -   5        $ YCount��5*      $��	20,0,20,0q�6%   $ 0Q�5+      $ BottomRight=�6q    � LargeChange$ 0Q�6�   $
	 True��5,      
 5+   %   �� $ MinCellCount� 6K   �� $ MaxCellCount� 5,   0   �� $ YCount�$ TwoWay=��� 5-      $��Начать��6   $��
20,20,20,0q�6&   $��20(�6:   $��1,5,1,5q�6H   5.      �� 5/   
   $��Сменить тему��6   $��Right=�6(   $��Center=�6D   $��0,0,20,0q�6_   $��	10,5,10,5q�6q   ��50      �� *ChangeThemeCommand+51      52      