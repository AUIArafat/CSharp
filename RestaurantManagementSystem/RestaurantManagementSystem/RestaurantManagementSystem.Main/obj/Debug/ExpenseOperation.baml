   M S B A M L   `   `   `  ����Z  VRestaurantManagementSystem.Main, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:RestaurantManagementSystem.MainRestaurantManagementSystem.Main  5   	   6    0RestaurantManagementSystem.Main.ExpenseOperation   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:RestaurantManagementSystem.Main     5   	   -   5          � 
ResizeMode$  NoResize=�5   	    � Title$ ExpenseOperation��5	   	   $	��600��6"   $
��1000��6/   .��5
      ]� .+�5   
   �� -   5        $��Submit��5   S   $	��Top=�6   $��Center=�6*   $��20q�6G   .+�5      ]� .+�5      �� $
��Left=�6   .+�5      �� $��ExpenseCategory��6    $��
10,5,10,15q�68   �� 5      $��ExpenseDate��6    $��
10,5,10,15q�64   �� 5      $��ExpenseDescription��6    $��
10,5,10,10q�6;   �� 5      $��ExpenseAmount��6    $��
10,5,10,10q�66   5      �� 5      $��Right=�6   .+�5      �� -   5         ��Name$ expenseCategoryTextBox��5      $��23��6>   $	��120��6K   $��5q�6W   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ expenseDate��5   !   $��23��66   $	��120��6D   $��5q�6P   �� 5      -   5        $ expenseDescriptionTextBox��5      $��23��6A   $	��120��6N   $��5q�6Z   �� 5      -   5        $ expenseAmountTextBox��5      $��23��6<   $	��120��6I   $��5q�6U   5      5      � 5      $��10q�6   $��Right=�6$   .+�5      �� -   5         ��Name$ 	addButton��5      $	��Add��6,   $��75��6;   
����·�6^   5      5      �� 5   
   $��Bottom=�6   .+�5       &   System.Windows.Controls.DataGrid  -   5          Name$ expenseDataGrid��5          AutoGenerateColumns .  $
��auto��6L   $
��Auto��6[      SelectionMode$ Single=�6h   ��.    CanUserAddRows .  	   Columns	 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *	ExpenseId+6S     5#      $
 CATEGORY��6)   $ 2* 6_    6;   �� *ExpenseCategory+6_     5$      $
 AMOUNT��6)   $ 2* 6[    69   �� *ExpenseAmount+6[     5%      $

 DATE��6)   $ 2* 6W    67   �� *ExpenseDate+6W     5&      $
 DESCRIPTION��6)   $ 3* 6e    6>   �� *ExpenseDescription+6e   4  .System.Windows.Controls.DataGridTemplateColumn  5'      $
 DELETE��6-   $ 2* 6=      CellTemplate 5(      �� 5)      .R�5*   "   �� -	   5        $��DELETE��5*   )   6:   5+      5-        5.      $

 EDIT��6-   $ 2* 6;    5/      �� 50      .R�51   "   �� -
   5        $
��EDIT��51   )   68   52      54      56      57      59      5:      