   M S B A M L   `   `   `  ����^  ZMicrosoft.Samples.Kinect.WpfViewers, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null�^clr-namespace:Microsoft.Samples.Kinect.WpfViewers;assembly=Microsoft.Samples.Kinect.WpfViewers#Microsoft.Samples.Kinect.WpfViewers  5   	    SkeletalTracking!   SkeletalTracking.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   mmy^clr-namespace:Microsoft.Samples.Kinect.WpfViewers;assembly=Microsoft.Samples.Kinect.WpfViewers     5   	   -   5          � Title$  
MainWindow��5   	   $	��800��6   $	��800��6)    � WindowState$ 	Maximized=�5   "   .��5      �� -   5        $��
MainCanvas��5      .+�5   
   ;   5Microsoft.Samples.Kinect.WpfViewers.KinectColorViewer  -   5        $��kinectColorViewer1��5   W    �� Left$ 0��6   
 �� Top$ 0��6/   $	��640��6>   $	��480��6J   5   /Microsoft.Samples.Kinect.WpfViewers.ImageViewer   Kinect 5	      ��  �� ElementName$ kinectSensorChooser1�� �� Path$ Kinect�A� 5
   
   -   5        $��leftEllipse��5
   >    �� Right$ 0��6   $ 0��6#   $��50��62   $y�	Collapsed=�6R   $��50��6i   ���	#FF4D298D J� Opacity$ 1Q�6�   
�������6�   A� 5   
   -   5        $��rightEllipse��5   g   $	 100��6   $ 0��6$   ���	#FF2CACE3$y�	Collapsed=�6D   $��50��6[   $��50��6{   $ 1Q�6�   
�������6�   =   7Microsoft.Samples.Kinect.WpfViewers.KinectSensorChooser  5   
   -   5        $��kinectSensorChooser1��5   D   $	 250��6!   $	 380��63   $	��328��6`   �� 5   
   -   5        $��
headImage1��5   =   $ 66��6   $ 90��6!   $��87��61   $��84��6O   $y�Visible=�6Z   $ ��C:\Users\hp\Desktop\s7.png��6o   $
��Fill=�6�   �� 5   
   -   5        $��
headImage2��5   >   $	 169��6   $ 90��6"   $��87��62   $��84��6P   $y�Visible=�6[   $!��C:\Users\hp\Desktop\e30.png��6p   $
��Fill=�6�   �� 5   
   -	   5        $��
headImage3��5   >   $	 269��6   $ 90��6"   $��87��62   $��84��6P   $y�Visible=�6[   $!��C:\Users\hp\Desktop\e25.png��6p   $
��Fill=�6�   �� 5   
   -
   5        $��
headImage4��5   >   $	 369��6   $ 90��6"   $��87��62   $��84��6P   $y�Visible=�6[   $!��C:\Users\hp\Desktop\e11.png��6p   $
��Fill=�6�   �� 5   
   -   5        $��
headImage5��5   >   $	 369��6   $ 90��6"   $��87��62   $��84��6P   $y�Visible=�6[   $!��C:\Users\hp\Desktop\e23.png��6p   $
��Fill=�6�   �� 5   
   -   5        $��
headImage6��5   >   $	 369��6   $ 90��6"   $��87��62   $��84��6P   $y�Visible=�6[   $!��C:\Users\hp\Desktop\e32.png��6p   $
��Fill=�6�   �� 5   
   -   5        $��
headImage7��5   >   $	 369��6   $ 90��6"   $��87��62   $��84��6P   $y�Visible=�6[   $!��C:\Users\hp\Desktop\s13.png��6p   $
��Fill=�6�   >   8Microsoft.Samples.Kinect.WpfViewers.KinectSkeletonViewer  5   
   $	��433��6"   $	 832��6/   $ 0��6A   $	��420��6R   	 J� RenderTransformOrigin$	 0.0,0.0&�6�   $	 -80��6�    6^   �� *Kinect+$ kinectSensorChooser1��z�5      V� 5      .~�5      �� �� 5      �� 5      
 �� Angle$
 -0.378Q�6&   T� 5      5      5      ;   5Microsoft.Samples.Kinect.WpfViewers.KinectDepthViewer  5    
   $	��345��6   $	 850��6,   $	 434��6>   $	��427��6O   $	 0.631,0.134&�6[    6   �� *Kinect+$ kinectSensorChooser1��r� 5!   
    r� Source$&  C:\Users\hp\Desktop\welcome1.mp3?�6    r� LoadedBehavior$
 Play=�6A   5"      5$      