   M S B A M L   `   `   `  ���� C  ?MySeries, Version=2.2.1.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MySeriesMySeries  F BMyFunctions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullV:clr-namespace:MyFunctions.ControlsWPF;assembly=MyFunctionsMyFunctions.ControlsWPF J FAdmandev.Rating, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullJ6clr-namespace:Admandev.Rating;assembly=Admandev.RatingAdmandev.Rating     MySeries.AddSerie_Window   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     (localclr-namespace:MySeries     Imf:clr-namespace:MyFunctions.ControlsWPF;assembly=MyFunctions     Irating6clr-namespace:Admandev.Rating;assembly=Admandev.Rating       � Title$  Editeur ��$��637.886��$��667.783�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�.���    WindowBackground#��[  .+�� -    �Name$ 
HeaderGrid��$��38��$	��Top=�  HeaderColor#��[ $��2��.+��� -    ��Name$ IMG_AppIcon��$?��9pack://application:,,,/Resources/Images/Icon/Icon PNG.png��$
��Left=�$��28��$��28��$��5,5,0,0q�$	��Top=��� -    ��Name$ 
LB_AppName��$��Editeur��$��Center=�$��Center=�$
��Left=�$��43,0,0,0q�$	��Top=�$��38��
�������$��22(�$��Franklin Gothic Demi)��� -    ��Name$ BT_CloseWindow��$��50��$	��Top=�$��38��$��Right=�$��0q���Z� ��Z� .���� $F��@pack://application:,,,/Resources/Images/Headers/Close window.png���� -    ��Name$ Group_Infos��$��Infos��$
��Left=�$	��602��$��
7,32,0,-80q�$	��Top=�
�������$��16(�$	��653��$
��Bold"�.��� .+��� -   	 ��Name$	 TB_Name��$��Center=�$��	24,3,24,0q�$	��Top=�$��20(�$
��Bold"�$��Center=�$	��448��� $��0,36,0,0q�$��Center=�.+�  Admandev.Rating.Rating  -   $��	RatingBar��
   
SymbolType$
 Heart=�   SymbolsCount$ 10��   NormalSymbolColor
 �����   
SymbolSize$ 39Q�   LockAfterRating .  $��Center=�   SelectedSymbolColor ��  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ White�� � Offset$ 0Q�� $	 Red��$
 0.53Q��� $��1q�
���   �$��0,77,409,203q�._��  � RowDefinitions �� $
��248* ��� $	��39* �.+��� -   $ 
IMG_Poster��$��0���� -	   $ BT_ChoosePoster��  ChooseImage#���  $��1��  
MainButton#��[   MainButtonBorderColor#��[ $��Normal"��� $
��Left=�$	��304��$��
237,77,0,0q�$	��Top=�$	��253��$	��394��.+��� 
���   �$��1q�$��50��._��  � ColumnDefinitions �� �� .+��� 
���   �$��1q�$��1��$��48��._���  
 Author#���  $��Center=�$��Center=�$
��Bold"�$��0,-2,0,2q��� 
���   �$��1q�$��2��._��� -
   $	 	TB_Author�� �� TextAlignment$ Center=�$��Center=� �� TextWrapping$
 Wrap=�
���   �$��Normal"��� 
���   �$��1q�$��50��._��  �� �� .+��� 
���   �$��1q�$��1��$��48��._���   ReleaseDate#���  $��Center=�$��Center=�$
��Bold"��� 
���   �$��1q�$��2��._�+  %MyFunctions.ControlsWPF.NumericUpDown  -     Name$ NUD_ReleaseDate��$��0,4,0,5q�$��Normal"�
   Max$ 1E+36Q�
   Min$
 1900Q�   Value$
 2000Q��� 
���   �$��1q�$��50��._��  �� �� .+��� 
���   �$��1q�$��1��$��48��._��� $��Genre��$��Center=�$��Center=�$
��Bold"��� 
���   �$��1q�$��2��._��� -   $	 TB_Genre��$ Center=�$��Center=�$
 Wrap=�
���   �$��Normal"��� 
���   �$��1q�$��50��._��  �� �� .+��� 
���   �$��1q�$��1��$��48��._���   Language#���  $��Center=�$��Center=�$
��Bold"��� 
���   �$��1q�$��2��._��� -    ��Name$ CB_Language��$��Center=�$��Center=�
���   �$��Normal"� �� 
IsEditable . .@��� $��VOSTFR���� $��VF���� 
���   �$��1q�$��50��._��  �� �� .+��� 
���   �$��1q�$��1��$��48��._���  	 State#���  $��Center=�$��Center=�$
��Bold"��� 
���   �$��1q�$��2��._��� -   $ CB_State��$��Center=�$��Center=�
���   �$��Normal"� . .@���  	 
InProgress#��� 	 ��  
 OnBreak#��� 
 ��   Finished#���  �� 
���   �$��1q�$��50��._��  �� �� .+��� 
���   �$��1q�$��1��$��48��._��� $
��Wrap=�  
NbEpisodes#���   �� TextAlignment$ Center=�$
��Bold"�
���   �$��Center=��� 
���   �$��1q�$��2��._�  -   $ NUD_NbEpisode��$��0,4,0,5q�$��Normal"�$ 1E+36Q�$ 1Q��� $��Synopsis��$	��161��$��0,0,0,42q�$��0.4,0.7,0.4,0.4q�
���   �$
��Bold"�$��Bottom=���Z� .���� -   $	 TB_Synopsis��$ Justify=�" �� VerticalScrollBarVisibility$
 Auto=�$
 Wrap=�  �� AcceptsReturn  . $��0q�$��14(�$��Normal"�! �� 	IsEnabled! . �� $��37��$��Bottom=�" �� Orientation$" 
Horizontal=�$��Center=�.+��� -   $ BT_SaveSerie��  Save#���  $��Center=�$	��170��#��[ #��[ 
�������$
��Left=�$��25��