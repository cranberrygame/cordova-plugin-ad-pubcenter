// Copyright (c) 2014 cranberrygame
// Email: cranberrygame@yahoo.com
// Phonegap plugin: http://www.github.com/cranberrygame
// Construct2 phonegap plugin: https://www.scirra.com/forum/viewtopic.php?f=153&t=109586
//                             https://dl.dropboxusercontent.com/u/186681453/index.html
//                             https://www.scirra.com/users/cranberrygame
// Facebook: https://www.facebook.com/profile.php?id=100006204729846
// License: MIT (http://opensource.org/licenses/MIT)
using System.Windows;
using System.Runtime.Serialization;
using WPCordovaClassLib.Cordova;
using WPCordovaClassLib.Cordova.Commands;
using WPCordovaClassLib.Cordova.JSON;
using System.Diagnostics; //Debug.WriteLine
//
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using Microsoft.Advertising.Mobile.UI;

namespace Cordova.Extension.Commands
{
    public class Pubcenter : BaseCommand
    {
        private AdControl bannerView;
        private Grid bannerGrid;

        public void preloadBannerAd(string args)
        {
            string applicationId = JsonHelper.Deserialize<string[]>(args)[0];
            Debug.WriteLine("applicationId: " + applicationId);
            string adUnitId = JsonHelper.Deserialize<string[]>(args)[1];
            Debug.WriteLine("adUnitId: " + adUnitId);
           
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {   
                _preloadBannerAd(applicationId, adUnitId);
                
				DispatchCommandResult(new PluginResult(PluginResult.Status.OK));			
				//DispatchCommandResult(new PluginResult(PluginResult.Status.ERROR));
            });
        }
        public void showBannerAd(string args)
        {
            string applicationId = JsonHelper.Deserialize<string[]>(args)[0];
            Debug.WriteLine("applicationId: " + applicationId);
            string adUnitId = JsonHelper.Deserialize<string[]>(args)[1];
            Debug.WriteLine("adUnitId: " + adUnitId);
			string position=JsonHelper.Deserialize<string[]>(args)[2];
			Debug.WriteLine(position);

            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                _showBannerAd(applicationId, adUnitId, position);

				DispatchCommandResult(new PluginResult(PluginResult.Status.OK));			
				//DispatchCommandResult(new PluginResult(PluginResult.Status.ERROR));
            });
        }
        public void hideBannerAd(string args)
        {
            //this.adUnit = JsonHelper.Deserialize<string[]>(args)[0];
            //Debug.WriteLine("adUnit: " + adUnit);

            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                _hideBannerAd();

				DispatchCommandResult(new PluginResult(PluginResult.Status.OK));			
				//DispatchCommandResult(new PluginResult(PluginResult.Status.ERROR));
            });	
        }
        public void refreshBannerAd(string args)
        {
            //this.adUnit = JsonHelper.Deserialize<string[]>(args)[0];
            //Debug.WriteLine("adUnit: " + adUnit);

            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                _refreshBannerAd();

				DispatchCommandResult(new PluginResult(PluginResult.Status.OK));			
				//DispatchCommandResult(new PluginResult(PluginResult.Status.ERROR));
            });					
        }		
 		//---------------------------
        private void _preloadBannerAd(string applicationId, string adUnitId)
        {
            if (bannerView == null)
            {
                bannerView = new AdControl(applicationId, adUnitId, true);//isAutoRefreshEnabled	
                //bannerView = new AdControl("test_client", "Image480_80", true); //must be used for simulator
                bannerView.Width = 480;
                bannerView.Height = 80;
                //bannerView.Loaded += bannerView_Loaded;//compile error ????????
                bannerView.ErrorOccurred += bannerView_ErrorOccurred;
            }
        }
        private void _showBannerAd(string applicationId, string adUnitId, string position)
        {
            if (bannerView == null)
            {
                _preloadBannerAd(applicationId,adUnitId);
            }

            _hideBannerAd();

            PhoneApplicationFrame frame = Application.Current.RootVisual as PhoneApplicationFrame;
            if (frame != null)
            {
                PhoneApplicationPage page = frame.Content as PhoneApplicationPage;
                if (page != null)
                {
                    Grid grid = page.FindName("LayoutRoot") as Grid;
                    if (grid != null)
                    {
                        if (position == "top")
                        {
                            bannerView.VerticalAlignment = VerticalAlignment.Top;
                        }
                        else
                        {
                            bannerView.VerticalAlignment = VerticalAlignment.Bottom;
                        }

                        bannerGrid = new Grid();
                        bannerGrid.Children.Add(bannerView);
                        grid.Children.Add(bannerGrid);
                    }
                }
            }
        }
        private void _hideBannerAd()
        {
            if (bannerView != null)
            {
                PhoneApplicationFrame frame = Application.Current.RootVisual as PhoneApplicationFrame;
                if (frame != null)
                {
                    PhoneApplicationPage page = frame.Content as PhoneApplicationPage;
                    if (page != null)
                    {
                        Grid grid = page.FindName("LayoutRoot") as Grid;
                        if (grid != null)
                        {
                            if (bannerGrid != null)
                            {
                                bannerGrid.Children.Remove(bannerView);
                                grid.Children.Remove(bannerGrid);
                            }
                        }
                    }
                }
            }
        }
        private void _refreshBannerAd()
        {
            if (bannerView != null)
            {
                bannerView.Refresh();
            }
        }

/*
        //compile error ???????
        void bannerView_Loaded(object sender, Microsoft.Advertising.AdErrorEventArgs e)
        {
            Debug.WriteLine("bannerView_Loaded");
        }
*/
        void bannerView_ErrorOccurred(object sender, Microsoft.Advertising.AdErrorEventArgs e)
        {
            Debug.WriteLine("ad error " + e.Error.Message.ToString());
        }
    }
}