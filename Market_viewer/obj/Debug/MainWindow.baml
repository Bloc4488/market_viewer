   M S B A M L   `   `   `  ����R  NOxyPlot.Wpf, Version=2.1.2.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0>.clr-namespace:OxyPlot.Wpf;assembly=OxyPlot.WpfOxyPlot.Wpf  5   	   K GMarket_viewer2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Market_viewerMarket_viewer 5   	      Market_viewer.MainWindow   5   	   6oxy.clr-namespace:OxyPlot.Wpf;assembly=OxyPlot.Wpf  5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   'localclr-namespace:Market_viewer  5   	   -   5           MaterialDesignPaper#���   5	   	     MaterialDesignBody#���  5
   	   $��Regular"�5   	   $��14(�5   	     � Title$  Stock application��5   	   $	��450��6#   $	��800��60   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��159* �6   �� 5      .+�5   
   � $��0,27,0,0q�6   $��1��6!   $	��130��6.   $
��Left=�6:    5      �� 5      $
��Auto �6    �� 5      .+�5      �� $��Stocks��6   $��16,8,0,0q�6&      MaterialDesignBody2TextBlock#��[ 68   �� 5       -   5         ��Name$ listOfStock��5    W   $��1��6   #���   6#    �� SelectionMode$ Single=�6�   $��8q�6�     MaterialDesignListBox#��[ 6�   ��6�   �� *	Tickers+��5!      �� 5"      .R�5#      �  5$      �� 5%   "   $
��Auto �63   �� 5&   "   .+�5(      �� -   5        $��20��5(   $   $��20��62   ��6A   �� *Image+6Z   �� 5)      $��1��6(   $
��Bold"�6N      MaterialDesignBody1TextBlock#��[ 6`   ��68   �� *Name+6`   5*      5+      5-      5.      � 5/   
   $��2��6   $��
0,10,10,10q�6#   $��2��67   $��Right=�6H   $	��110��6d    50      �� 51      $
��Auto �6    �� 52      .+�54      �� $��Wallet��6   $��16,8,0,0q�6&   #��[ 68   �� 55      -   5         ��Name$ listOfWallet��55   W   $��1��6   #���   6$   $��8,8,8,80q�6�     MaterialDesignListView#��[ 6�   ��6m   �� *	Wallets+��56      �� 57      .R�58      �  59      �� 5:   "   $
��Auto �63   �� 5;   "   .+�5=      �� $��0��6@   #��[ 6P   ��6(   �� *amount+6P   �� 5>      $
��Bold"�6E   $��1��6W   #��[ 6g   ��6(   �� *Ticker.Name+6g   5?      5@      5B      �� 5C      $��Amount: ��6   #��[ 6(   $��Bottom=�6^   $��0,0,0,70q�6y   $��1��6�   �� 5D      -   5         ��Name$ FullAmountOfWallet��5D      #��[ 64   $��Bottom=�6j   $��0,0,0,50q�6�   $��1��6�   5E      �� 5F   
   -   5        $��
0,0,258,25q�5F   8   $��30��6L   $��Bottom=�6X   $��Right=�6s   $��95��6�     MaterialDesignRaisedButton#��[ 6�   $��1��6�   .��6�   Buy6�   �� 5G   
   -   5        $��
0,0,158,25q�5G   :   $��Right=�6N   $��95��6j   $��30��6u   $��Bottom=�6�   #��[ 6�   $��1��6�   .��6�   Sell6�   �� 5H   
   $��
160,0,0,80q�6   $��Bottom=�6(   $
��Left=�6C   $��1��6^   $��Max Price: ��6k   #��[ 6~   �� 5I   
   $��
160,0,0,50q�6   $��Bottom=�6(   $
��Left=�6C   $��1��6^   $��Min Price: ��6k   #��[ 6~   �� 5J   
   $��160,0,0,110q�6   $��Bottom=�6)   $
��Left=�6D   $��1��6_   $��Current Price: ��6l   #��[ 6�   �� 5K   
   -   5        $ MaxPriceSelectedStock��5K   k   $��
230,0,0,80q�6   $��Bottom=�6(   $
��Left=�6C   $��1��6^   $
��---$��6�   #��[ 6�   �� 5L   
   -	   5        $ MinPriceSelectedStock��5L   k   $��
230,0,0,50q�6   $��Bottom=�6(   $
��Left=�6C   $��1��6^   $
��---$��6�   #��[ 6�   �� 5M   
   -
   5        $ CurrentPriceSelectedStock��5M   l   $��250,0,0,110q�6   $��Bottom=�6)   $
��Left=�6D   $��1��6_   $
��---$��6�   #��[ 6�   �� 5N   
   -   5         ��Name$  AmountOfTickerToAddOrMinus��5N   �   
�������$��Right=�6)   $��
0,0,160,60q�6E    �� TextWrapping$
 Wrap=�6Y   $��Bottom=�6m   $	��196��6�     MaterialDesignTextBox#��[ 6�   $��1��6�   �� 5O   
   -   5        $ AddNewTicker��5O   O   
�������$��10,2,0,0q�6)   $
 Wrap=�6;   $
��Left=�6e   $	��130��6�   $��34��6�   $	��Top=�6�   #��[ 6�   �� 5P   
   -   5        $	��Add��5P   6   $��	12,39,0,0q�6D   	 J� RenderTransformOrigin$	 0.252,0.253&�6W   $
��Left=�6{   $	��126��6�   $��33��6�   $	��Top=�6�   #��[ 6�      OxyPlot.Wpf.PlotView  5Q   
   -   5        
  Name$
 
StockChart��5Q      $��140,14,130,135q�6+   $��2��6C   5R      5S      