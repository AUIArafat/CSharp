   M S B A M L   `   `   `  ����Z  VRestaurantManagementSystem.Main, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:RestaurantManagementSystem.MainRestaurantManagementSystem.Main  5   	   .    (RestaurantManagementSystem.Main.Category   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:RestaurantManagementSystem.Main     5   	   -   5          � Title$  Category��5   	   $	��600��6   $
��1000��6'   .��5
      ]� .+�5   
   �� -   5        $��Submit��5   S   $	��Top=�6   $��Center=�6*   $��20q�6G   .+�5      ]� .+�5      � $
��Left=�6   .+�5      �� .+�5      �� $��Department Name��6$   $��
10,5,10,15q�6<   �� 5      $��Category Name��6$   $��
10,5,10,15q�6:   �� 5      $��Category Price��6$   $��
10,5,10,10q�6;   5      �� 5      .+�5      �� -   5         ��Name$ departmentNameComboBox��5   #   $��23��6C   $	��120��6P   $��5q�6\   �� 5      -   5         ��Name$ CategoryNameTextBox��5   "   $��23��6?   $	��120��6M   $��5q�6Y   �� 5      -   5        $ CategoryPriceTextBox��5   "   $��23��6@   $	��120��6M   $��5q�6Y   5      5      �� 5      $��Right=�6   .+�5      �� 
���   �$��1q�61   $��Right=�6E   ._�5      �� -   5         ��Name$ categoryImage��5       $	��100��67   $	��100��6D   5      �� 5      -   5        $��Browse��5      6.   5      5      � 5       $��10q�6   $��Center=�6$   .+�5"      �� -   5         ��Name$ 	addButton��5"      $	��Add��6,   $��75��6;   
����·�6^   5#      5$      �� 5%   
   $��Bottom=�6   .+�5&      &   System.Windows.Controls.DataGrid  -	   5          Name$ categoryDataGrid��5&         AutoGenerateColumns .  $
��auto��6M   $
��Auto��6\      SelectionMode$ Single=�6i      CanUserAddRows .  	   Columns	 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Category ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6]   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *
CategoryId+6]     5)      $
 Category Name��6)   $ 2* 6a    6@   �� *CategoryName+6a     5*      $
 Price��6)   $ 1* 6Z    68   �� *CategoryPrice+6Z     5+      $
 	Menu Item��6)   $ 3* 6Y    6<   �� *
MenuList+6Y   4  .System.Windows.Controls.DataGridTemplateColumn  5,      $
 Category Image��6-   $ 2* 6E      CellTemplate 5-      �� 5.      .R�5/   "   �� ��6(   �� *Image+50      52        53      $
 DELETE��6-   $ 2* 6=    54      �� 55      .R�56   "   �� -
   5        $��DELETE��56   )   6:   57      59      5;      5<      5>      5?      