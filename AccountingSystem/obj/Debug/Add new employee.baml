   M S B A M L   `   `   `  ����K  GAccountingSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AccountingSystemAccountingSystem  5   	   '    !AccountingSystem.Add_new_employee   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:AccountingSystem     5   	     � Title$  Add_new_employee��5   	   $	��450��6"   $	��500��6/   .��5	      � ���	#FF7D999B$��0,0,2,0q�6"   .+�5   
   �� -   5         ��Name$ LastName��5      $��	Last Name��6"   $
��Left=�66   $��254,128,0,0q�6Q   $	��Top=�6f   $	��207��6~   $��43��6�   $��Center=�6�   $��18(�6�   $��Lucida Handwriting)�6�   �� 5   
   -   5         ��Name$ LastNameBox��5      $
��Left=�6'   $��36��6B   $��
31,179,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��207��6�   $��Center=�6�   $��Center=�6�   $��Lucida Handwriting)�6
   �� SelectionOpacity$	 0.9Q�6*  �� 5   
   -   5        $ startWorking��5      $��Start working date��6&   $
��Left=�6C   $��148,236,0,0q�6^   $	��Top=�6s   $	��207��6�   $��42��6�   $��Center=�6�   $��Center=�6�   $��18(�6�   $��Lucida Handwriting)�6�   ���	#FF932E2E��6  Z� 6-  �� 5   
   -   5         ��Name$ image��5      $
��Left=�6   $��Source/php3zs1aw.png��6:   $	��100��6X   $��
197,23,0,0q�6e   $	��Top=�6y   $	��100��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5      �� 5   
   -   5        $ 	FirstName��5      $��
First Name��6#   $
��Left=�68   $��
31,131,0,0q�6S   $	��Top=�6g   $	��207��6   $��43��6�   $��Center=�6�   $��18(�6�   $��Lucida Handwriting)�6�   �� 5   
   -   5        $ FirstNameBox��5      $
��Left=�6(   $��36��6C   $��254,179,0,0q�6O   $
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��207��6�   $��Center=�6�   $��Center=�6�   $��Lucida Handwriting)�6  $	 0.9Q�6,  (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ StartDateBox��5      $
��Left=�6+   $��148,283,0,0q�6F   $	��Top=�6[   $	��207��6s   $��22��6   �� 5   
   -   5         ��Name$ Confirm��5      $��Confirm��6"   $
��Left=�64   $��
31,343,0,0q�6O   $	��Top=�6d   $	��207��6|   $��37��6�   ���	#FF2A52DA	 �� 	IsDefault	 . $��2q�6�   
���   �
 J� SnapsToDevicePixels
 . $��18(�6�   $��Lucida Handwriting)�6   5        5      5      �� 5   
   -	   5        $
 Back��5      $
��Back��6   $
��Left=�6.   $��254,343,0,0q�6I   $	��Top=�6^   $	��207��6v   $��37��6�   ���	#FF2A52DA	 . $��2q�6�   
���   �
 . $��18(�6�   $��Lucida Handwriting)�6   5        5      5      �� 5    
   ���	#FF930C37$��2,2,2,2q�6)   $
��Left=�6C   $	��409��6^   $	��Top=�6k   $	��480��6�    �� CornerRadius$ 20��6�    5!        5"      5$      5%      5&      