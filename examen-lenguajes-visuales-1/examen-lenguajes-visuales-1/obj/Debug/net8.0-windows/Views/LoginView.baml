   M S B A M L   `   `   `  ����  examen-lenguajes-visuales-11    +examen_lenguajes_visuales_1.Views.LoginView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Login - Biblioteca��5   	   $	��250��6$   $	��400��61    � WindowStartupLocation$ CenterScreen=�6=   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Usuario:��6   $��0��6$   $��Center=�61   �� 5   
   $��0��6   $��80,0,0,0q�6   $	��200��61   ��5      �� *	Usuario+ �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $��Contraseña:��6   $��1��6'   $��0,20,0,0q�64   $��Center=�6F   G� 5   
   -   5        $��PasswordBox��5      $��1��5      $��	80,20,0,0q�6#   $	��200��66   5      �� 5   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��0,30,0,0q�6;   .+�5      �� $��Iniciar Sesión��6   $	��120��6O   $��0,0,10,0q�6[   ��6.   �� *LoginCommand+6[   �� 5      $��Registrarse��6   $	��120��6T   ��6+   �� *AbrirRegistroCommand+6T   5      �� 5   
   $��3��6   
���  ��$��0,20,0,0q�6K   ��6!   �� *	Mensaje+6K   5      5      