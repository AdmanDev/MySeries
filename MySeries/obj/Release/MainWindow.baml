   M S B A M L   `   `   `  ���� C  ?MySeries, Version=2.2.1.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MySeriesMySeries  J FAdmandev.Rating, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullJ6clr-namespace:Admandev.Rating;assembly=Admandev.RatingAdmandev.Rating     MySeries.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     (localclr-namespace:MySeries     Irating6clr-namespace:Admandev.Rating;assembly=Admandev.Rating     -     �Name$  window�� � Title$ MySeries��$	��643��$	��696�� � SizeToContent$ Width=� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � DataContext ��  �� Mode$ OneWay=� �� RelativeSource �� *Self+	 � 	Resources	 
 ��Name   BT_AddCategory  AddCategory  
MainButton  MainButtonBorderColor  SettingsMenu  CategoriesMenu  Edit 
 Delete��%9  &	        7  7  &	 [     &	 �     �� $
 BT_AddCategory��-   #���  8��  8�� 
�������$��Normal"�$	��170��$��25���� .@�m� $��Language��.@�m� -   $��	Français���� m� -   $��English���� �� .@�m� $��MN_EditCategory��-   #���  �� m� $��MN_DeleteCategory��-   #���  .���   WindowBackground#��[  � RowDefinitions �� $	��37* ��� $
��606* �.+�� -    �Name$ 
HeaderGrid��$��38��$	��Top=� 	 HeaderColor#��[	 $��2��.+��� -    ��Name$ IMG_AppIcon��$?��9pack://application:,,,/Resources/Images/Icon/Icon PNG.png��$
��Left=�$��28��$��28��$��5,5,0,0q�$	��Top=��� -	    ��Name$ 
LB_AppName��$��MySeries��$��Center=�$��Center=�$
��Left=�$��43,0,0,0q�$	��Top=�$��38��
�������$��22(�$��Franklin Gothic Demi)��� -
   $
 BT_CloseApp��$��36��$	��Top=�$��38��$��Right=�$��0q���Z� ��Z� .���� $F��@pack://application:,,,/Resources/Images/Headers/Close window.png���� -   $
 BT_Settings�� � ContextMenu# �  $��41��$	��Top=�$��38��$��Right=�$��0,0,44,0q���Z� ��Z� .���� $G��Apack://application:,,,/Resources/Images/Headers/Logo Settings.png���� -   $
 BT_ADMANSoftware��$��ADMANDEV��$��293,2,167,3q�
�������
�������$��16(�����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF5D0B0B�� � Offset$ 0Q�� $ 	#FF2E0202��$ 1Q��� -    ��Name$ Group_SeriesList�� 

 Series#��� 
 $
��Left=�$	��363��$��1,1,0,0q�$��1��$	��Top=�$	��182��$��16(����	#FFFFFEFE$
��Bold"�.��� .+��� -    ��Name$ 	LB_Series��$
��Left=�$	��275��$��0,30,0,0q�$	��Top=�$	��170��$��Normal"��� -   $
 BT_AddSerie��  AddSerie#���  $��0q�#��[ #��[ 
�������$��Normal"�$��Bottom=�$��26���� -    ��Name$ CB_Categories��$
��Left=�$	��Top=�$	��170��$��0,3,0,0q�$��Normal"� �� SelectedIndex$ 0������  �� 
TargetType" ��.���  �� Property � �� �� Value$ Stretch=��� -   $ Group_Infos��$��Infos��$
��Left=�$	��602��$��	185,1,0,0q�$��1��$	��Top=�
�������$��16(�$	��508��$
��Bold"�.��� .+��� -   $ LB_Title��$��Center=�$��	24,3,24,0q�$	��Top=�
�������$��20(�$
��Bold"�$	��448��$��Center=����� *SelectedItem.Title+ �� ElementName$ 	LB_Series��� $��0,36,0,0q�.+�  Admandev.Rating.Rating  -   $��	RatingBar��   
SymbolType$ Heart=�   SymbolsCount$ 10��   NormalSymbolColor
 �����   
SymbolSize$ 39Q�    ReadOnly  . $��Center=�!   SelectedSymbolColor! �� $ 0.5,1&�$ 0.5,0&�.��� $ White��$ 0Q�� $	 Red��$
 0.53Q��� -   $ IMG_SeriePoster��$
��Left=�$	��304��$��6,77,0,0q�$	��Top=�$	��224��$
��Fill=��� $
��Left=�$	��304��$��
237,77,0,0q�$	��Top=�$	��253��.+��� 
���   �$��1q�$��50��$	��252��._�� " � ColumnDefinitions" �� �� .+��� 
���   �$��1q�$��1��$��48��._���  
 Author#���  $��Center=�$��Center=�$
��Bold"��� 
���   �$��1q�$��2��._��� -   # ��Name$# 	LB_Author��$
��Wrap=�$ �� TextAlignment$$ Center=�$��Center=�
���   �$��Normal"����� *SelectedItem.Author+$ 	LB_Series���� 
���   �$��1q�$��50��$	��252��._�� " �� �� .+��� 
���   �$��1q�$��1��$��48��._���   ReleaseDate#���  $��Center=�$��Center=�$
��Bold"��� 
���   �$��1q�$��2��._��� -   $# LB_ReleaseDate��$
��Wrap=�$$ Center=�$��Center=�
���   �$��Normal"����� *SelectedItem.ReleaseDate+$ 	LB_Series���� 
���   �$��1q�$��50��$	��252��._�� " �� �� .+��� 
���   �$��1q�$��1��$��48��._��� $��Genre��$��Center=�$��Center=�$
��Bold"��� 
���   �$��1q�$��2��._��� -   $# LB_Genre��$
��Wrap=�$$ Center=�$��Center=�
���   �$��Normal"����� *SelectedItem.Genre+$ 	LB_Series���� 
���   �$��1q�$��50��$	��252��._�� " �� �� .+��� 
���   �$��1q�$��1��$��48��._���   Language#���  $��Center=�$��Center=�$
��Bold"��� 
���   �$��1q�$��2��._��� -   $# LB_Languages��$
��Wrap=�$$ Center=�$��Center=�
���   �$��Normal"����� *SelectedItem.Language+$ 	LB_Series���� 
���   �$��1q�$��50��$	��252��._�� " �� �� .+��� 
���   �$��1q�$��1��$��48��._���  	 State#���  $��Center=�$��Center=�$
��Bold"��� 
���   �$��1q�$��2��._��� -   $# LB_State��$
��Wrap=�$$ Center=�$��Center=�
���   �$��Normal"����� *SelectedItem.State+$ 	LB_Series���� 
���   �$��1q�$��50��$	��252��._�� " �� �� .+��� 
���   �$��1q�$��1��$��48��._��� $
��Wrap=�  
NbEpisodes#���  $$ Center=�$
��Bold"�
���   �$��Center=��� 
���   �$��1q�$��2��._��� -   $# LB_NbEpisode��$
��Wrap=�$$ Center=�$��Center=�
���   �$��Normal"����� *SelectedItem.EpisodeNb+$ 	LB_Series���� $��Synopsis��$	��161��$��0,0,0,33q�$	��496��$��0.4,0.7,0.4,0.4q�
���   �$
��Bold"�$��Bottom=���Z� .���� -   % ��Name$% TB_Synopsis��& �� TextAlignment$& Justify=�' �� 
IsReadOnly' . "( �� VerticalScrollBarVisibility$
( Auto=�) �� TextWrapping$
) Wrap=�$��0q�$��14(�$��Normal"�* �� 	UndoLimit$* 0���� $��37��$��Bottom=�+ �� Orientation$+ 
Horizontal=�$��Center=�$��
70,0,64,-3q�$	��362��.+��� -   $
 BT_DeleteSerie��#���  $��Center=�$	��170��#��[ #��[ 
�������$
��Left=�$	��5,0q�$��25���� -   $
 BT_EditSerie��#���  $��Center=�$	��170��#��[ #��[ 
�������$
��Left=�$��0,0,5,0q�$��25���� -   $
 BT_Favorite��$��38��$	��Top=�$��38��$��Right=�$��0q���Z� ��Z� .���� -   $ IMG_Favorite��$H��Bpack://application:,,,/Resources/Images/UIs/Star - No favorite.png����  
 Search#���  $
��Left=�$	��234��$��0,0,0,3q�$��1��$��Bottom=�$	��183��$��16(�
�������$
��Bold"�.���  �� $	��35* ��� $
��171* �.+��� -    $% 	TB_Search��$��Center=�$& Center=�$
) Wrap=�$��Normal"��� $��1��.+�	� -!   , 	�Name$, RB_FindTitle��  SearchTitle#���  $��0,4,0,0q�
�������$��Normal"�- d� 	IsChecked$
- TrueY�	� -"   $, RB_FindAuthor��  SearchAuthor#���  $��0,4,0,0q�
�������$��Normal"�	� -#   $, RB_FindGenre��  SearchGenre#���  $��0,4,0,0q�
�������$��Normal"�	� -$   $, RB_FindLanguage��  SearchLanguage#���  $��0,4,0,0q�
�������$��Normal"�	� -%   $, RB_FindState��  SearchState#���  $��0,4,0,0q�
�������$��Normal"�	� -&   $, RB_FindRating��  SearchRating#���  $��0,4,0,0q�
�������$��Normal"�	� -'   $, RB_FindFavorite��  SearchFavorites#���  $��0,4,0,0q�
�������$��Normal"�