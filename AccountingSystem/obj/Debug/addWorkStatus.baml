   M S B A M L   `   `   `  ����K  GAccountingSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AccountingSystemAccountingSystem  5   	   $    AccountingSystem.addWorkStatus   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:AccountingSystem     5   	     � Title$  addWorkStatus��5   	   $	��658��6   $��1016.5��6,   .��5	      � ���	#FF7D999B$��	0,0,-9,-1q�6"   .+�5
   
   �� -   5         ��Name$ EmployeeIDBox��5
      $
��Left=�6)   $��36��6D   $��372,238,0,0q�6P    �� TextWrapping$
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��276��6�   $��Center=�6�   $��Center=�6�   $��Lucida Handwriting)�6   �� SelectionOpacity$	 0.9Q�6-  �� 5   
   -   5         ��Name$ 
EmployeeID��5      $��Employee ID��6$   $
��Left=�6:   $��408,191,0,0q�6U   $	��Top=�6j   $	��208��6�   $��42��6�   $��Center=�6�   $��18(�6�   $��Lucida Handwriting)�6�   �� 5   
   -   5         ��Name$ Confirm��5      $��Confirm��6"   $
��Left=�64   $��302,556,0,0q�6O   $	��Top=�6e   $	��208��6}   $��38��6�   ���	#FF2A52DA �� 	IsDefault . $��2q�6�   
���   � J� SnapsToDevicePixels . $��18(�6   $��Lucida Handwriting)�6   J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5      �� 5   
   -   5        $
 Back��5      $
��Back��6   $
��Left=�6.   $��526,556,0,0q�6I   $	��Top=�6^   $	��206��6v   $��38��6�   ���	#FF2A52DA . $��2q�6�   
���   � . $��18(�6�   $��Lucida Handwriting)�6   5        5      5      �� 5   
   -   5        $ monthBox��5      $
��Left=�6$   $��36��6?   $��
56,350,0,0q�6K   $
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��208��6�   $��Center=�6�   $��Center=�6�   $��Lucida Handwriting)�6  $	 0.9Q�6'  �� 5   
   -   5        $ month��5      $��Month��6   $
��Left=�6/   $��
56,302,0,0q�6J   $	��Top=�6^   $	��208��6v   $��42��6�   $��Center=�6�   $��18(�6�   $��Lucida Handwriting)�6�   �� 5   
   -   5        $ yearBox��5      $
��Left=�6#   $��36��6>   $��280,350,0,0q�6J   $
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��206��6�   $��Center=�6�   $��Center=�6�   $��Lucida Handwriting)�6  $	 0.9Q�6'  �� 5   
   -   5        $
 year��5      $
��Year��6   $
��Left=�6-   $��280,302,0,0q�6H   $	��Top=�6]   $	��208��6u   $��42��6�   $��Center=�6�   $��18(�6�   $��Lucida Handwriting)�6�   �� 5   
   -	   5        $ MaxHoursBox��5      $
��Left=�6'   $��36��6B   $��524,350,0,0q�6N   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��208��6�   $��Center=�6�   $��Center=�6�   $��Lucida Handwriting)�6  $	 0.9Q�6+  �� 5   
   -
   5        $ MaxHours��5      $��	Max Hours��6"   $
��Left=�66   $��524,302,0,0q�6Q   $	��Top=�6f   $	��208��6~   $��42��6�   $��Center=�6�   $��18(�6�   $��Lucida Handwriting)�6�   �� 5   
   -   5        $ ActualHoursBox��5      $
��Left=�6*   $��36��6E   $��748,350,0,0q�6Q   $
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��206��6�   $��Center=�6�   $��Center=�6�   $��Lucida Handwriting)�6  $	 0.9Q�6.  �� 5   
   -   5        $ ActualHours��5      $��Actual Hours��6%   $
��Left=�6<   $��748,302,0,0q�6W   $	��Top=�6l   $	��208��6�   $��42��6�   $��Center=�6�   $��18(�6�   $��Lucida Handwriting)�6�   �� 5   
   -   5        $ MaxSalaryBox��5      $
��Left=�6(   $��36��6C   $��
56,473,0,0q�6O   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��208��6�   $��Center=�6�   $��Center=�6�   $��Lucida Handwriting)�6  $	 0.9Q�6+  �� 5   
   -   5        $ 	MaxSalary��5      $��
Max Salary��6#   $
��Left=�68   $��
56,431,0,0q�6S   $	��Top=�6g   $	��208��6   $��42��6�   $��Center=�6�   $��18(�6�   $��Lucida Handwriting)�6�   �� 5    
   -   5        $ ActualSalary��5       $-��'Actual Salary for this month(with tax):��6&   $
��Left=�6X   $��321,473,0,0q�6s   $	��Top=�6�   $	��422��6�   $��42��6�   $��Center=�6�   $��18(�6�   $��Lucida Handwriting)�6�   �� 5!   
   -   5        	 ��Name$	 ActualSalaryBlock��5!      $
��Left=�6/   $��748,473,0,0q�6J   $
��Wrap=�6_   $�� ��6s   $	��Top=�6{   $��32��6�   $��84��6�   $��18(�6�   �� 5"   
   -   5        
 ��Name$
 image��5"      $
��Left=�6   $	��170��6:   $��Source/Salary.png��6G   $��
437,10,0,0q�6c   $	��Top=�6w   $	��179��6�    J� RenderTransformOrigin$ 0.851,0.507&�6�   �� 5#   
   ���	#FF930C37$��2,2,2,2q�6)   $
��Left=�6C   $	��618��6^   $	��Top=�6k   $	��996��6�    �� CornerRadius$ 20��6�    5$        5%      5'      5(      5)      