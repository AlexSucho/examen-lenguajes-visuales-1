   M S B A M L   `   `   `  ����  examen-lenguajes-visuales-15    /examen_lenguajes_visuales_1.Views.LibroFormView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Libro��5   	   $	��260��6   $	��420��6$    � WindowStartupLocation$ CenterScreen=�60   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Título:��6   $��0��6#   $��Center=�60   �� 5   
   $��0��6   $��80,0,0,0q�6   $	��250��61   ��5      �� *Libro.Titulo+ �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $��Autor:��6   $��1��6"   $��0,20,0,0q�6/   $��Center=�6A   �� 5   
   $��1��6   $��	80,20,0,0q�6   $	��250��62   ��5      �� *Libro.Autor+$ PropertyChanged=��� 5   
   $��Categoría:��6   $��2��6&   $��0,20,0,0q�63   $��Center=�6E   �� 5   
   $��2��6   $��	80,20,0,0q�6    $	��250��63    �� SelectedValuePath$ Id��5       �� DisplayMemberPath$ Nombre��5      ��5      �� *
Categorias+ �� SelectedValue 5      �� *Libro.CategoriaId+$ PropertyChanged=�5      �� 5   
   $��3��6    �� Orientation$ 
Horizontal=�6"   $��0,30,0,0q�6;   .+�5      �� $��Guardar��6   $	��100��6J   $��0,0,10,0q�6V   ��6'   �� *GuardarCommand+6V   �� 5      -   5        $��Cancelar��5      $	��100��6?   5      �� 5   
   $��4��6   
���  ��$��0,20,0,0q�6K   ��6!   �� *	Mensaje+6K   5      5       