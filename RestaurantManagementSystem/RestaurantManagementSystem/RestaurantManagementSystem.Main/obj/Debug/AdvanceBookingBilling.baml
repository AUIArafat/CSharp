   M S B A M L   `   `   `  ����Z  VRestaurantManagementSystem.Main, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:RestaurantManagementSystem.MainRestaurantManagementSystem.Main  5   	   ;    5RestaurantManagementSystem.Main.AdvanceBookingBilling   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:RestaurantManagementSystem.Main     5   	     � Title$  AdvanceBookingBilling��5   	   $	��600��6'   $
��1000��64   .��5	      ]� .+�5
   
   � $	��Top=�6   $��10q�6$   $��Center=�60    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6     � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� $��
Booking Id��6   $��0��6)   $��0��66   $��10q�6F   �� 5      $��Booking Date��6   $��0��6+   $��1��68   $��10q�6H   �� 5      $��Table No��6   $��0��6'   $��2��64   $��10q�6D   �� 5      $��Customer Name��6   $��0��6,   $��3��69   $��10q�6I   �� 5      $��Contact��6   $��0��6&   $��4��63   $��10q�6C   �� 5      $��Advance��6   $��0��6&   $��5��63   $��10q�6C   �� 5      -   5        $��bookingIdBlock��5   5   $��1��6   $��0��6%   $��5q�6K    �� Padding$ 5q�6V   (  "System.Windows.Controls.DatePicker  5       -   5        $��bookingDateBlock��5    6   $��1��6   $��1��6&   $��5q�6N   $��5q�6Y   {�.  6e   �� 5!      -   5        $��tableNoBlock��5!   5   $��1��6   $��2��6%   $��5q�6I   $ 5q�6T   �� 5"      -   5        $��customerNameBlock��5"   5   $��1��6   $��3��6%   $��5q�6N   $ 5q�6Y   �� 5#      -   5        $��contactBlock��5#   5   $��1��6   $��4��6%   $��5q�6I   $ 5q�6T   �� 5$      -   5        $��advanceBlock��5$   5   $��1��6   $��5��6%   $��5q�6I   $ 5q�6T   5%      �� 5&   
   $
��Left=�6   $��10q�6+   .+�5'      �� -   5        $��CategoryName��5'      $��Category Name��6(   $��5q�6A   $��5q�6L   � 5(      .+�5)      �� -   5         ��Name$ categoryComboBox��5)      $��	0,5,100,5q�65   $��5q�6I   �� 5*      -	   5        $��GO��5*      $��0,5,20,5q�6&   $��5q�69   6D   5+      �� 5,      $��
Menu Items��6   �� 5-      $��2q�6   
�������$��5q�6=    �� Padding$ 5q�6H   ._�5.      �� -
   5        $��menuLItemsTextBlock��5.      5/      �� 50      $��Price��6   �� 51      -   5        $��priceTextBox��51      $��5q�6*   $��5q�65   �� 52      $��Quantity��6   �� 53      -   5        $��quantityTextBox��53      $��5q�6-   $��5q�68   �� 55      -   5        $	��ADD��55      $��5q�6#   $��5q�6.   6:   56      � 58   
   $��Bottom=�6   $��Bottom=�6'   $��Center=�6B    59      �� 5:      $
��Auto �6    �� 5;      $
��Auto �6    �� 5<      $
��Auto �6     5>      �� 5?      $
��Auto �6#   �� 5@      $
��Auto �6#   �� 5A      $
��Auto �6#   �� 5B      $
��Auto �6#   �� 5C      $
��Auto �6#   .+�5E      �� $��Sub Total(tk)��6   $��0��6,   $��0��69   $��10q�6I   �� 5F      $��Service Tax��6   $��0��6*   $��1��67   $��10q�6G   �� 5G      $��Vat(%)��6   $��0��6%   $��2��62   $��10q�6B   �� 5H      $��Discount(%)��6   $��0��6*   $��3��67   $��10q�6G   �� 5I      -   5        $��subTotal��5I      $��0��6&   $��0��6/   $��1��6?   $��5q�6M   $��5q�6X   �� 5J      -   5        $��
serviceTax��5J      $��0��6(   $��1��61   $��1��6>   $��5q�6O   $��5q�6Z   �� 5K      -   5        $	��vat��5K      $��1��6!   $��2��6.   $��10��6>    �� TextAlignment$ Center=�6H   $��5q�6`   $��5q�6k   �� 5L      -   5        $��discount��5L      $��1��6&   $��3��63   $��5��6C   $ Center=�6L   $��5q�6d   $��5q�6o   �� 5M      -   5        $��Cancel��5M      $��2��6&   $��2��66   $��5q�6D   $��5q�6O   6[   �� 5N      -   5        $��Print��5N      $��2��6%   $��3��62   $��5q�6C   $��5q�6N   6Z   5O      &   System.Windows.Controls.DataGrid  5Q   
   -   5        $��billingDataGrid��5Q      $��Right=�6+   $
��Auto��6B   $	��Top=�6P   $
��auto��6h      AutoGenerateColumns .     CanUserAddRows .  	   Columns	 5R      0  *System.Windows.Controls.DataGridTextColumn  5S      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Order Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *	OrderId+6S     5T      $

 Name��6%   $ 1* 6T    63   �� *CategoryName+6T     5U      $
 Quantity��6%   $ 1* 6T    67   �� *
Quantity+6T     5V      $
 Price��6%   $ * 6S    64   �� *
OrderPrice+6S   4  .System.Windows.Controls.DataGridTemplateColumn  5W      $
 Delete��6)   $ 1* 69      CellTemplate 5X      �� 5Y      .R�5Z      �� -   5        $��Delete��5Z   %   66   5[      5]      5_      5`      5a      