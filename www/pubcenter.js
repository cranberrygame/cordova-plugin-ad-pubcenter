
module.exports = {

	preloadBannerAd: function(applicationId, adUnitId, successCallback, errorCallback) {
		cordova.exec(
			successCallback,
			errorCallback,
			'Pubcenter',
			'preloadBannerAd',
			[applicationId, adUnitId]
		);
    },
    showBannerAd: function(applicationId, adUnitId, position, successCallback, errorCallback) {
		cordova.exec(
			successCallback,
			errorCallback,
			'Pubcenter',
			'showBannerAd',
			[applicationId, adUnitId, position]
		); 
    },
    hideBannerAd: function(successCallback, errorCallback) {
		cordova.exec(
			successCallback,
			errorCallback,
			'Pubcenter',
			'hideBannerAd',
			[]
		);
    },
	refreshBannerAd: function(successCallback, errorCallback) {
		cordova.exec(
			successCallback,
			errorCallback,
			'Pubcenter',
			'refreshBannerAd',
			[]
		);
    }
};
