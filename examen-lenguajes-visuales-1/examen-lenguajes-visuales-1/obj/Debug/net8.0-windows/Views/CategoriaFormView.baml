   M S B A M L   `   `   `  ����  examen-lenguajes-visuales-19    3examen_lenguajes_visuales_1.Views.CategoriaFormView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
Categoría��5   	   $	��160��6   $	��340��6(    � WindowStartupLocation$ CenterScreen=�64   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6   .+�5   
   �� $��Nombre:��6   $��0��6#   $��Center=�60   �� 5   
   $��0��6   $��70,0,0,0q�6   $	��200��61   ��5      �� *Categoria.Nombre+ �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��0,20,0,0q�6;   .+�5      �� $��Guardar��6   $��90��6J   $��0,0,10,0q�6U   ��6'   �� *GuardarCommand+6U   �� 5      -   5        $��Cancelar��5      $��90��6?   5      �� 5   
   $��1��6   
���  ��$��0,20,0,0q�6K   ��6!   �� *	Mensaje+6K   5      5      