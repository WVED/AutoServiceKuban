   M S B A M L   `   `   `  ����F  BAutoService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:AutoServiceAutoService  5           AutoService.ServiceAddPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:AutoService     5        N� Title$  ServiceAddPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��80 �6   6*   �� 5      $��80 �6   6*   �� 5      $��80 �6   6*   �� 5      $��80 �6   6*   �� 5      $��80 �6   6*   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $	��300 �6   6-   �� 5      $��* �6   6+   .+�5   
   �� $+��%Наименование услуги��6   $��Center=�6/   $��Center=�6J   $��20(�6g   6w   �� 5   
   $��Стоимость��6   $��Center=�6%   $��Center=�6@   $��1��6]   $��20(�6j   6z   �� 5   
   $%��Время выполнения��6   $��Center=�6,   $��Center=�6G   $��2��6d   $��20(�6q   6�   �� 5   
   $��Описание��6   $��Center=�6$   $��Center=�6?   $��3��6\   $��20(�6i   6y   �� 5   
   $��Скидка��6   $��Center=�6"   $��Center=�6=   $��4��6Z   $��20(�6g   6w   �� 5   
   -   5        $��TextBoxTitle��5   Q   $��1��6   $	��300��69   $��25��6E   ��6"   �� *Title+6g   �� 5   
   -   5        $��TextBoxCost��5   ]   $��1��6   $��1��68   $	��300��6E   $��25��6Q   ��6"   �� *Cost+6r   �� 5   
   -   5        $��TextBoxDurTime��5   y   $��1��6   $��2��6E   $��Center=�6R   $	��300��6m   ��6"   �� *DurationInSeconds+6�   �� 5    
   $��1��6   $��3��6?   $	��300��6L   $��25��6X   ��6"   �� *Description+6f   �� 5!   
   -   5        $��TextBoxDiscount��5!   p   $��1��6   $��4��6<   $��Center=�6I   $	��300��6d   ��6"   �� *
Discount+6�   �� 5"   
   -   5        $��BtnSave��5"   3   $��16(�6   $��Сохранить��6   $��Bottom=�6B   $��Center=�6]   $��5��6�   $��2��6�   $��Comic Sans MC)�6�   $	��200��6�   $��25��6�   $��
0,0,300,10q�6�   6�   5#      5$      