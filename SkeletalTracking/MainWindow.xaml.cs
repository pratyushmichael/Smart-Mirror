
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Kinect;
using Coding4Fun.Kinect.Wpf;


        
    namespace SkeletalTracking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            
        }
        public int i = 1;
        public int count = 0;
        bool closing = false;
        const int skeletonCount = 6; 
        Skeleton[] allSkeletons = new Skeleton[skeletonCount];

       
        KinectSensor sensor;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sensor = KinectSensor.KinectSensors[0];
            kinectSensorChooser1.KinectSensorChanged += new DependencyPropertyChangedEventHandler(kinectSensorChooser1_KinectSensorChanged);

        }
        
        void kinectSensorChooser1_KinectSensorChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
           

            if (sensor == null)
            {
                return;
            }

            


            var parameters = new TransformSmoothParameters
            {
                Smoothing = 0.3f,
                Correction = 1.0f,
                Prediction = 0.0f,
                JitterRadius = 0.3f,
                MaxDeviationRadius = 0.0f
            };
           // sensor.SkeletonStream.Enable(parameters);

            sensor.SkeletonStream.Enable();

            sensor.AllFramesReady += new EventHandler<AllFramesReadyEventArgs>(sensor_AllFramesReady);
            sensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30); 
            sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);

            try
            {
                sensor.Start();
            }
            catch (System.IO.IOException)
            {
                kinectSensorChooser1.AppConflictOccurred();
            }
        }

        void sensor_AllFramesReady(object sender, AllFramesReadyEventArgs e)
        {
            if (closing)
            {
                return;
            }
            
            //Get a skeleton
            Skeleton first =  GetFirstSkeleton(e);

            if (first == null)
            {
                return; 
            }



            //set scaled position
            //ScalePosition(headImage, first.Joints[JointType.Head]);
            //ScalePosition(leftEllipse, first.Joints[JointType.HandLeft]);
            //ScalePosition(rightEllipse, first.Joints[JointType.HandRight]);

          
            GetCameraPoint(first, e );

        }

        void GetCameraPoint(Skeleton first, AllFramesReadyEventArgs e)
        {
           

            using (DepthImageFrame depth = e.OpenDepthImageFrame())
            {
                if (depth == null ||
                    kinectSensorChooser1.Kinect == null)
                {
                    return;
                }

                

                //Map a joint location to a point on the depth map
                //head
                //DepthImagePoint headDepthPoint =
                // depth.MapFromSkeletonPoint(first.Joints[JointType.Head].Position);

                DepthImagePoint r = sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(first.Joints[JointType.HandRight].Position, DepthImageFormat.Resolution640x480Fps30);
                DepthImagePoint w = sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(first.Joints[JointType.WristRight].Position, DepthImageFormat.Resolution640x480Fps30);

                //left hand
                DepthImagePoint leftDepthPoint =sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(first.Joints[JointType.ShoulderLeft].Position,DepthImageFormat.Resolution640x480Fps30);

                //right hand
                DepthImagePoint rightDepthPoint =
                sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(first.Joints[JointType.ShoulderRight].Position, DepthImageFormat.Resolution640x480Fps30);

                DepthImagePoint up =
                sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(first.Joints[JointType.ShoulderCenter].Position, DepthImageFormat.Resolution640x480Fps30);

                DepthImagePoint down =
                sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(first.Joints[JointType.HipCenter].Position, DepthImageFormat.Resolution640x480Fps30);

                DepthImagePoint head = sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(first.Joints[JointType.Head].Position, DepthImageFormat.Resolution640x480Fps30);

               





                //Map a depth point to a point on the color image
                //head
                //ColorImagePoint headColorPoint =
                //depth.MapToColorImagePoint(headDepthPoint.X, headDepthPoint.Y,
                //ColorImageFormat.RgbResolution640x480Fps30);

                ColorImagePoint rc =
                    sensor.CoordinateMapper.MapDepthPointToColorPoint(DepthImageFormat.Resolution640x480Fps30, r,
                    ColorImageFormat.RgbResolution640x480Fps30);
                ColorImagePoint wc =
                   sensor.CoordinateMapper.MapDepthPointToColorPoint(DepthImageFormat.Resolution640x480Fps30, w,
                   ColorImageFormat.RgbResolution640x480Fps30);


                //left hand
                ColorImagePoint leftColorPoint =
                    sensor.CoordinateMapper.MapDepthPointToColorPoint(DepthImageFormat.Resolution640x480Fps30, leftDepthPoint,
                    ColorImageFormat.RgbResolution640x480Fps30);
                //right hand
                ColorImagePoint rightColorPoint =
                    sensor.CoordinateMapper.MapDepthPointToColorPoint(DepthImageFormat.Resolution640x480Fps30, rightDepthPoint, 
                    ColorImageFormat.RgbResolution640x480Fps30);

                ColorImagePoint downColorPoint =
                    sensor.CoordinateMapper.MapDepthPointToColorPoint(DepthImageFormat.Resolution640x480Fps30, down,
                    ColorImageFormat.RgbResolution640x480Fps30);
                ColorImagePoint upColorPoint =
                   sensor.CoordinateMapper.MapDepthPointToColorPoint(DepthImageFormat.Resolution640x480Fps30, up,
                   ColorImageFormat.RgbResolution640x480Fps30);

                ColorImagePoint headColorPoint =
                   sensor.CoordinateMapper.MapDepthPointToColorPoint(DepthImageFormat.Resolution640x480Fps30, head,
                   ColorImageFormat.RgbResolution640x480Fps30);

                Console.WriteLine(rc.Y + " " + rightColorPoint.Y+" " +i +"  "+count);
                    
                    if (rc.Y < rightColorPoint.Y)
                    {
                        count = count + 1;
                    }
                    if(count==1)
                    {
                      i = i + 1;
                    }

                    if (rc.Y > rightColorPoint.Y)
                    {
                        count = 0;
                    }
                    string headImage = "headImage" + i.ToString();

                    
                    

                    //Set location                   
                   //CameraPosition(headImage, leftColorPoint, rightColorPoint, upColorPoint, downColorPoint, headColorPoint);

                    

                   

                    if ((i%7) == 1)
                    {
                        headImage1.Visibility = Visibility.Visible;
                        headImage2.Visibility = Visibility.Collapsed;
                        headImage3.Visibility = Visibility.Collapsed;
                        headImage4.Visibility = Visibility.Collapsed;
                        headImage5.Visibility = Visibility.Collapsed;
                        headImage6.Visibility = Visibility.Collapsed;
                        headImage7.Visibility = Visibility.Collapsed;
                    CameraPosition(headImage1, leftColorPoint, rightColorPoint, upColorPoint, downColorPoint, headColorPoint);

                    }
                    else if ((i % 7) == 2)
                    {
                        headImage1.Visibility = Visibility.Collapsed;
                        headImage2.Visibility = Visibility.Visible;
                        headImage3.Visibility = Visibility.Collapsed;
                        headImage4.Visibility = Visibility.Collapsed;
                        headImage5.Visibility = Visibility.Collapsed;
                        headImage6.Visibility = Visibility.Collapsed;
                        headImage7.Visibility = Visibility.Collapsed;
                    CameraPosition(headImage2, leftColorPoint, rightColorPoint, upColorPoint, downColorPoint, headColorPoint);

                    }
                else if ((i % 7) == 3)
                {
                    headImage1.Visibility = Visibility.Collapsed;
                    headImage2.Visibility = Visibility.Collapsed;
                    headImage3.Visibility = Visibility.Visible;
                    headImage4.Visibility = Visibility.Collapsed;
                    headImage5.Visibility = Visibility.Collapsed;
                    headImage6.Visibility = Visibility.Collapsed;
                    headImage7.Visibility = Visibility.Collapsed;
                    CameraPosition(headImage3, leftColorPoint, rightColorPoint, upColorPoint, downColorPoint, headColorPoint);

                }
                else if ((i % 7) == 4)
                {
                    headImage1.Visibility = Visibility.Collapsed;
                    headImage2.Visibility = Visibility.Collapsed;
                    headImage4.Visibility = Visibility.Visible;
                    headImage3.Visibility = Visibility.Collapsed;
                    headImage5.Visibility = Visibility.Collapsed;
                    headImage6.Visibility = Visibility.Collapsed;
                    headImage7.Visibility = Visibility.Collapsed;
                    CameraPosition(headImage4, leftColorPoint, rightColorPoint, upColorPoint, downColorPoint, headColorPoint);

                }
                else if ((i % 7) == 5)
                {
                    headImage1.Visibility = Visibility.Collapsed;
                    headImage2.Visibility = Visibility.Collapsed;
                    headImage5.Visibility = Visibility.Visible;
                    headImage3.Visibility = Visibility.Collapsed;
                    headImage4.Visibility = Visibility.Collapsed;
                    headImage6.Visibility = Visibility.Collapsed;
                    headImage7.Visibility = Visibility.Collapsed;
                    CameraPosition(headImage5, leftColorPoint, rightColorPoint, upColorPoint, downColorPoint, headColorPoint);

                }
                else if ((i % 7) == 6)
                {
                    headImage1.Visibility = Visibility.Collapsed;
                    headImage2.Visibility = Visibility.Collapsed;
                    headImage6.Visibility = Visibility.Visible;
                    headImage3.Visibility = Visibility.Collapsed;
                    headImage5.Visibility = Visibility.Collapsed;
                    headImage4.Visibility = Visibility.Collapsed;
                    headImage7.Visibility = Visibility.Collapsed;
                    CameraPosition(headImage6, leftColorPoint, rightColorPoint, upColorPoint, downColorPoint, headColorPoint);

                }
                else if ((i % 7) == 0)
                {
                    headImage1.Visibility = Visibility.Collapsed;
                    headImage7.Visibility = Visibility.Visible;
                    headImage3.Visibility = Visibility.Collapsed;
                    headImage4.Visibility = Visibility.Collapsed;
                    headImage5.Visibility = Visibility.Collapsed;
                    headImage6.Visibility = Visibility.Collapsed;
                    headImage2.Visibility = Visibility.Collapsed;
                    CameraPosition(headImage7, leftColorPoint, rightColorPoint, upColorPoint, downColorPoint, headColorPoint);

                }
                else {
                    headImage1.Visibility = Visibility.Collapsed;
                    headImage2.Visibility = Visibility.Visible;
                    headImage4.Visibility = Visibility.Collapsed;
                    headImage3.Visibility = Visibility.Collapsed;
                    headImage5.Visibility = Visibility.Collapsed;
                    headImage6.Visibility = Visibility.Collapsed;
                    headImage7.Visibility = Visibility.Collapsed;
                    CameraPosition(headImage2, leftColorPoint, rightColorPoint, upColorPoint, downColorPoint, headColorPoint);

                }


            }        
        }


        Skeleton GetFirstSkeleton(AllFramesReadyEventArgs e)
        {
            using (SkeletonFrame skeletonFrameData = e.OpenSkeletonFrame())
            {
                if (skeletonFrameData == null)
                {
                    return null; 
                }

                
                skeletonFrameData.CopySkeletonDataTo(allSkeletons);

                //get the first tracked skeleton
                Skeleton first = (from s in allSkeletons
                                         where s.TrackingState == SkeletonTrackingState.Tracked
                                         select s).FirstOrDefault();

                return first;

            }
        }

        private void StopKinect(KinectSensor sensor)
        {
            if (sensor != null)
            {
                if (sensor.IsRunning)
                {
                    //stop sensor 
                    sensor.Stop();

                    //stop audio if not null
                    if (sensor.AudioSource != null)
                    {
                        sensor.AudioSource.Stop();
                    }


                }
            }
        }

        private void CameraPosition(FrameworkElement element, ColorImagePoint point1, ColorImagePoint point2, ColorImagePoint point3, ColorImagePoint point4, ColorImagePoint point5)
        {
            //Divide by 2 for width and height so point is right in the middle 
            // instead of in top/left corner
            //Canvas.SetLeft(element, point.X - element.Width / 2);
            //Canvas.SetTop(element, point.Y - element.Height / 2);

            //element.Visibility = Visibility.Visible;

            element.Width = Math.Abs((point2.X - point1.X)+100);
            element.Height = Math.Abs(point4.Y - point5.Y+22+20);
            Canvas.SetLeft(element, (point1.X-element.Width/2+50));
            Canvas.SetTop(element, ((point5.Y+point3.Y)/2+10+5));
           

        }

        private void CheckPosition(FrameworkElement element, ColorImagePoint point)
        {
            //Divide by 2 for width and height so point is right in the middle 
            // instead of in top/left corner
            Canvas.SetLeft(element, point.X - element.Width / 2);
            Canvas.SetTop(element, point.Y - element.Height / 2);

        }
        private void ScalePosition(FrameworkElement element, Joint joint)
        {
            //convert the value to X/Y
            //Joint scaledJoint = joint.ScaleTo(1280, 720); 
            
            //convert & scale (.3 = means 1/3 of joint distance)
            Joint scaledJoint = joint.ScaleTo(1280, 720, .3f, .3f);

            Canvas.SetLeft(element, scaledJoint.Position.X);
            Canvas.SetTop(element, scaledJoint.Position.Y); 
            
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            closing = true; 
            StopKinect(kinectSensorChooser1.Kinect); 
        }

        


    }
}
