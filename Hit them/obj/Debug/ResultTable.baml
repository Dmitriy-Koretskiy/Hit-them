   M S B A M L   `   `   `  ����  Hit them    Hit_them.ResultTable   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  ResultTable��5   	   $	��308��6   $	��495��6*   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��ResultDataGrid��5   ^      AutoGenerateColumns .     
IsReadOnly .    CanUserAddRows .     CanUserDeleteRows .  $	��250��6      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6    $
��Left=�60   $��	12,12,0,0q�6K   $	��Top=�6t   $	��450��6�   ��6�   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5
      -   5        	cName��,  &System.Windows.Controls.DataGridColumn   Header$
 Name��5
   M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Name+6M     5      -   5        
cScore��$ Score��5   O    65   �� *Score+6O     5      -   5        
cLevel��$ Level��5   O    65   �� *Level+6O     5      -   5        	cDate��$
 Date��5   m   	   
IsReadOnly	 .  64   �� *Date+
 �� StringFormat$
 {0:dd/MM/yyyy}��6|   5      5      5      