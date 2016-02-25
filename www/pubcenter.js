
module.exports = {
	_loadedBannerAd: false,
	_isShowingBannerAd: false,
	//
	setLicenseKey: function(email, licenseKey) {
		var self = this;	
        cordova.exec(
            null,
            null,
            'Pubcenter',
            'setLicenseKey',			
            [email, licenseKey]
        ); 
    },
	setUp: function(applicationId, adUnitId, isOverlap) {
		var self = this;	
        cordova.exec(
            function (result) {
				if (typeof result == "string") {
					if (result == "onBannerAdPreloaded") {					
						if (self.onBannerAdPreloaded)
							self.onBannerAdPreloaded();
					}
					else if (result == "onBannerAdLoaded") {
						self._loadedBannerAd = true;
						
						if (self.onBannerAdLoaded)
							self.onBannerAdLoaded();
					}
					else if (result == "onBannerAdShown") {
						self._loadedBannerAd = false;
						self._isShowingBannerAd = true;
					
						if (self.onBannerAdShown)
							self.onBannerAdShown();
					}
					else if (result == "onBannerAdHidden") {
						self._isShowingBannerAd = false;
					
						 if (self.onBannerAdHidden)
							self.onBannerAdHidden();
					}					
				}
				else {
					//var event = result["event"];
					//var location = result["message"];				
					//if (event == "onXXX") {
					//	if (self.onXXX)
					//		self.onXXX(location);
					//}
				}			
			}, 
			function (error) {
			},
            'Pubcenter',
            'setUp',			
            [applicationId, adUnitId, isOverlap]
        ); 
    },
	preloadBannerAd: function() {
		cordova.exec(
            null,
            null,
			'Pubcenter',
			'preloadBannerAd',
			[]
		);
    },
    showBannerAd: function(position) {
		cordova.exec(
            null,
            null,
			'Pubcenter',
			'showBannerAd',
			[position]
		); 
    },
	reloadBannerAd: function() {
		cordova.exec(
            null,
            null,
			'Pubcenter',
			'reloadBannerAd',
			[]
		);
    },
    hideBannerAd: function() {
		cordova.exec(
            null,
            null,
			'Pubcenter',
			'hideBannerAd',
			[]
		);
    },
	loadedBannerAd: function() {
		return this._loadedBannerAd;
	},
	isShowingBannerAd: function() {
		return this._isShowingBannerAd;
	},
	onBannerAdPreloaded: null,
	onBannerAdLoaded: null,
	onBannerAdShown: null,
	onBannerAdHidden: null
};
