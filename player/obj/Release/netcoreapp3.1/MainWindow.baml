   M S B A M L   `   `   `  ���� A  =player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:playerplayer      player.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:player       � Title$  
MainWindow��$	��450��$	��800��.��� $	��634��$��
0,0,-366,0q�.+�r� -    r�Name$ mediaelement1�� r� Stretch$
 Fill=�$
{�True�� r� LoadedBehavior$ Manual=�$
��Left=�$��74��$��	48,47,0,0q�$	��Top=�$	��445�� J� Opacity$ 0Q� K� ZIndex$ 1�� J� OpacityMask ��  �� Color$ 	#FFC70D0D�� �� Opacity$ 0Q��� -   	 ��Name$	 
playButton��$��播放��$
��Left=�$��41,0,0,0q�$��Center=�$��25��$��55��
 J� RenderTransformOrigin$
 0.5,0.5&�z�V� .~��� �� ��  �� Angle$ -0.761Q�T� �� -   $	 pauseButton��$��停止��$
��Left=�$��	218,0,0,0q�$��Center=�$��26��$��55���� -   $	 
stopButton��$��暂停��$
��Left=�$��	130,0,0,0q�$��Center=�$��25��$��54���� -   $	 chooseFileButton��$��添加��$
��Left=�$��561,375,0,0q�$	��Top=�$��22��$��54���� -    ��Name$ 	musiclist��$��547,88,453,271q�$
 0.497,0.584&�z�V� .~��� ��  �� AngleY$ 0Q��� T�  T� Y$ 0Q��� $��播放列表��$
��Left=�$��
599,10,0,0q�$	��Top=�$��74���� -   $	 deleteFileButton��$��删除��$
��Left=�$��644,375,0,0q�$	��Top=�$��22��$��47��$
 0.725,1.816&��� -    ��Name$ 
playSlider��$
��Left=�$��
64,241,0,0q�$	��Top=�$	��241�� � Maximum$ 1Q��� -	    ��Name$ label1��$��还未选中播放文件��$
��Left=�$��
504,40,0,0q�$	��Top=�$
 0.415,-0.123&�$	��280��$��35���� -
   $	 showfileinfoBtn��$��查看播放文件信息��$
��Left=�$��
22,358,0,0q�$	��Top=�$	��118��$��25���� -   $ 	timelabel��$�� ��$
��Left=�$��174,264,0,0q�$	��Top=�$��60���� -   $ totaltimelabel��$�� ��$
��Left=�$��238,264,0,0q�$	��Top=�$
 4.202,3.319&��� $��/��$
��Left=�$��218,264,0,0q�$	��Top=��� -    ��Name$ image��$
��Left=�$	��151��$��	64,58,0,0q�$	��Top=�$	��257���� -   $
 icon��$
��Left=�$��25��$��157,358,0,0q�$	��Top=�$��24��$��
音量.png���� -   $ volumeslider��$
��Left=�$��204,358,0,0q�$	��Top=�$	��127��$��24��