   M S B A M L   `   `   `  ���� @  <Clock, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClockClock      
Clock.Tray   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     %localclr-namespace:Clock       � Title$
  Tray��$	��125��$	��150�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � AllowsTransparency .  � Topmost . ��Z� ��Z�  � 	Resources    ButtonOwnStyle �� 
TargetType �� Property �� Value	 �� 
TargetType
 ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        �� " ��.���  � ��
 �������  � ��
 �   ���  � ��$ Raleway Medium)���  � �� �� "	 ��.R��� $
 Border��$��0q�$��Center=�$��Center=�$��1q�
���������Z� .���� $��2q���.  P�  �@J�IsMouseOver . . ��� $ Border�� � �� �#03A9F4�� $ Border�� � ��$ 1q�P�  � �� . . ��� $ Border�� � �� �#03A9F4.��� $��0q�$	��150��$��Center=�$��Center=�$	��125��
���   � � RowDefinitions �� .+��� -    ��Name$ buttonAutoAnimation��$��Auto animation��#��[  $��25��$��Center=�
���   �
�������$��Center=�$	��150��$��	0,0,0,100q�$��14(�$��Raleway)���Z� �� -   $ buttonPlaceOnTop��$��Place on top     ��#��[  
���   �
�������$��0,0,0,50q�$��25��$��Center=�$��Center=�$	��150��$��14(�$��Raleway)���Z� �� -   $ buttonLockPosition��$��Lock position   ��#��[  
���   �
�������$��0q�$��Center=�$��Center=�$	��150��$��25��$��14(�$��Raleway)���Z� �� -   $ buttonAlignToCentre��$��Align to centre ��#��[  $��25��$��Center=�
���   �
�������$��0,50,0,0q�$��Center=�$	��150��$��14(�$��Raleway)���Z� �� -   $ buttonClose��$��Center=�#��[  $��Center=�$��25��$��Center=�
���   �
�������$	��150��$��	0,100,0,0q�$��Close                  ��$��14(�$��Raleway)���Z� A� -    A�Name$ ellipseLockPosition�����	#FF4CAF50$��Center=�$��8��$��	0,0,125,0q�$��Center=�$��8��A� -   $ ellipsePlaceOnTop�����	#FF2196F3$��Center=�$��8��$��
0,0,125,50q�$��Center=�$��8��A� -   $ ellipseAnim�����	#FFFF9800$��Center=�$��8��$��0,0,125,100q�$��Center=�$��8��