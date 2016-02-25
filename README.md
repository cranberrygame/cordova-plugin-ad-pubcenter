Cordova pubCenter plugin
====================

# Overview #
Show microsoft pubcenter banner ad

[windows8 (is supported only for construct2)] [wp8] [crodova cli] [phonegap build service]

Requires microsoft pubcenter account http://pubcenter.microsoft.com

This is open source cordova plugin.

You can see Cordova Plugins in one page: http://cranberrygame.github.io?referrer=github

# Change log #
```c
	
To-Do:
```
# Install plugin #

## Cordova cli ##
https://cordova.apache.org/docs/en/edge/guide_cli_index.md.html#The%20Command-Line%20Interface - npm install -g cordova@6.0.0
```c
cordova plugin add cordova-plugin-ad-pubcenter
(when build error, use github url: cordova plugin add cordova plugin add https://github.com/cranberrygame/cordova-plugin-ad-pubcenter)
```

## Xdk ##
https://software.intel.com/en-us/intel-xdk - Download XDK - XDK PORJECTS - [specific project] - CORDOVA HYBRID MOBILE APP SETTINGS - Plugin Management - Add Plugins to this Project - Third Party Plugins -
```c
Plugin Source: Cordova plugin registry
Plugin ID: cordova-plugin-ad-pubcenter
```

## Cocoon ##

## Phonegap build service (config.xml) ##
https://build.phonegap.com/ - Apps - [specific project] - Update code - Zip file including config.xml
```c
<gap:plugin name="cordova-plugin-ad-pubcenter" source="npm" />
```

## Construct2 ##
Download construct2 plugin<br>
https://dl.dropboxusercontent.com/u/186681453/pluginsforcordova/index.html<br>
How to install c2 native plugins in xdk, cocoon and cordova cli<br>
https://plus.google.com/102658703990850475314/posts/XS5jjEApJYV
<br>
<br>Test mode: c2 official Windows 8 plugin - Properties - Test mode: Yes
# Server setting #
```c
```
<img src="https://raw.githubusercontent.com/cranberrygame/cordova-plugin-ad-admob/master/doc/ad_unit1.png"><br>
<img src="https://raw.githubusercontent.com/cranberrygame/cordova-plugin-ad-admob/master/doc/ad_unit2.png"><br>
<img src="https://raw.githubusercontent.com/cranberrygame/cordova-plugin-ad-admob/master/doc/ad_unit3.png"><br>
<img src="https://raw.githubusercontent.com/cranberrygame/cordova-plugin-ad-admob/master/doc/ad_unit4.png"><br>
<img src="https://raw.githubusercontent.com/cranberrygame/cordova-plugin-ad-admob/master/doc/ad_unit5.png"><br>
<img src="https://raw.githubusercontent.com/cranberrygame/cordova-plugin-ad-admob/master/doc/ad_unit6.png"><br>
<img src="https://raw.githubusercontent.com/cranberrygame/cordova-plugin-ad-admob/master/doc/ad_unit7.png"><br>
<img src="https://raw.githubusercontent.com/cranberrygame/cordova-plugin-ad-admob/master/doc/ad_unit8.png"><br>

# API #
```javascript
var applicationId = "REPLACE_THIS_WITH_YOUR_APPLICATION_ID";
var adUnitId = "REPLACE_THIS_WITH_YOUR_AD_UNIT_ID";
var isOverlap = true; //true: overlap, false: split
/*
var applicationId;
var adUnitId;
var isOverlap = true; //true: overlap, false: split
//wp8
if( navigator.userAgent.match(/Windows Phone/i) ) {
	applicationId = "REPLACE_THIS_WITH_YOUR_APPLICATION_ID";
	adUnitId = "REPLACE_THIS_WITH_YOUR_AD_UNIT_ID";
}
*/

document.addEventListener("deviceready", function(){
	//if no license key, 2% ad traffic share for dev support.
	//you can get paid license key: https://cranberrygame.github.io/request_cordova_ad_plugin_paid_license_key
	//window.pubcenter.setLicenseKey("yourEmailId@yourEmaildDamin.com", "yourLicenseKey");

	window.pubcenter.setUp(applicationId, adUnitId, isOverlap);

	//
	window.pubcenter.onBannerAdPreloaded = function() {
		alert('onBannerAdPreloaded');
	};
	window.pubcenter.onBannerAdLoaded = function() {
		alert('onBannerAdLoaded');
	};
	window.pubcenter.onBannerAdShown = function() {
		alert('onBannerAdShown');
	};
	window.pubcenter.onBannerAdHidden = function() {
		alert('onBannerAdHidden');
	};
}, false);

window.pubcenter.preloadBannerAd();//option, download ad previously for fast show
/*
position: 'top-left', 'top-center', 'top-right', 'left', 'center', 'right', 'bottom-left', 'bottom-center', 'bottom-right'
size: 	'160x600'
		'250x250'
		'300x250'
		'300x600'
		'728x90'
*/
window.pubcenter.showBannerAd('top-center', '160x600');
window.pubcenter.showBannerAd('bottom-center', '160x600');
window.pubcenter.reloadBannerAd();
window.pubcenter.hideBannerAd();

alert(window.pubcenter.loadedBannerAd());//boolean: true or false

alert(window.pubcenter.isShowingBannerAd());//boolean: true or false
```
# Examples #
<a href="https://github.com/cranberrygame/cordova-plugin-ad-pubcenter/blob/master/example/basic/index.html">example/basic/index.html</a><br>

# Test #

[![](http://img.youtube.com/vi/xXrVb8E8gMM/0.jpg)](https://www.youtube.com/watch?v=xXrVb8E8gMM&feature=youtu.be "Youtube")

You can also run following test xap.
https://dl.dropboxusercontent.com/u/186681453/pluginsforcordova/pubcenter/xap.html

# Useful links #

Cordova Plugins<br>
http://cranberrygame.github.io?referrer=github

# Credits #
