   M S B A M L   `   `   `  ����A  =player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:playerplayer  5   	       player.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:player     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � $	��634��6   $��
0,0,-366,0q�6   .+�5
   
   r� -   5         r�Name$ mediaelement1��5
   O    r� Stretch$
 Fill=�6   $
{�True��6&    r� LoadedBehavior$ Manual=�67   $
��Left=�6f   $��74��6�   $��	48,47,0,0q�6�   $	��Top=�6�   $	��445��6�    J� Opacity$ 0Q�6   K� ZIndex$ 1��6    J� OpacityMask 5      �� 5       �� Color$ 	#FFC70D0D��6"    �� Opacity$ 0Q�64   5      �� 5   
   -   5        	 ��Name$	 
playButton��5      $��播放��6%   $
��Left=�62   $��41,0,0,0q�6M   $��Center=�6_   $��25��6z   $��55��6�   
 J� RenderTransformOrigin$
 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -0.761Q�6&   T� 5      5      5      �� 5   
   -   5        $	 pauseButton��5      $��停止��6&   $
��Left=�63   $��	218,0,0,0q�6N   $��Center=�6a   $��26��6|   $��55��6�   6�   �� 5   
   -   5        $	 
stopButton��5      $��暂停��6%   $
��Left=�62   $��	130,0,0,0q�6M   $��Center=�6`   $��25��6{   $��54��6�   6�   �� 5   
   -   5        $	 chooseFileButton��5      $��添加��6+   $
��Left=�68   $��561,375,0,0q�6S   $	��Top=�6h   $��22��6�   $��54��6�   6�   �� 5   
   -   5         ��Name$ 	musiclist��5      $��547,88,453,271q�6%   $
 0.497,0.584&�6=   z�5      V� 5      .~�5       �� �� 5!       �� AngleY$ 0Q�6$   �� 5"      T� 5#       T� Y$ 0Q�6)   5$      5&      �� 5'   
   $��播放列表��6   $
��Left=�6   $��
599,10,0,0q�6:   $	��Top=�6N   $��74��6f   �� 5(   
   -   5        $	 deleteFileButton��5(      $��删除��6+   $
��Left=�68   $��644,375,0,0q�6S   $	��Top=�6h   $��22��6�   $��47��6�   $
 0.725,1.816&�6�   �� 5)   
   -   5         ��Name$ 
playSlider��5)      $
��Left=�6%   $��
64,241,0,0q�6@   $	��Top=�6T   $	��241��6l    � Maximum$ 1Q�6x   6�   �� 5*   
   -	   5         ��Name$ label1��5*      $��还未选中播放文件��6    $
��Left=�63   $��
504,40,0,0q�6N   $	��Top=�6b   $
 0.415,-0.123&�6z   $	��280��6�   $��35��6�   �� 5+   
   -
   5        $	 showfileinfoBtn��5+      $��查看播放文件信息��6*   $
��Left=�6=   $��
22,358,0,0q�6X   $	��Top=�6l   $	��118��6�   $��25��6�   6�   �� 5,   
   -   5        $ 	timelabel��5,      $�� ��6#   $
��Left=�6.   $��174,264,0,0q�6I   $	��Top=�6^   $��60��6v   �� 5-   
   -   5        $ totaltimelabel��5-      $�� ��6(   $
��Left=�63   $��238,264,0,0q�6N   $	��Top=�6c   $
 4.202,3.319&�6{   �� 5.   
   $��/��6   $
��Left=�6   $��218,264,0,0q�67   $	��Top=�6L   �� 5/   
   -   5         ��Name$ image��5/      $
��Left=�6   $	��151��6:   $��	64,58,0,0q�6G   $	��Top=�6Z   $	��257��6r   �� 50   
   -   5        $
 icon��50      $
��Left=�6   $��25��69   $��157,358,0,0q�6E   $	��Top=�6Z   $��24��6r   $��
音量.png��6}   �� 51   
   -   5        $ volumeslider��51      $
��Left=�6'   $��204,358,0,0q�6B   $	��Top=�6W   $	��127��6o   $��24��6{   6�   53      54      