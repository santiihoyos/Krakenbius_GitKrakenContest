console.log('This would be the main JS file.');
// Twitter
!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0],p=/^http:/.test(d.location)?'http':'https';if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=p+'://platform.twitter.com/widgets.js';fjs.parentNode.insertBefore(js,fjs);}}(document, 'script', 'twitter-wjs');

// Facebook
(function(d, s, id) {
  var js, fjs = d.getElementsByTagName(s)[0];
  if (d.getElementById(id)) return;
  js = d.createElement(s); js.id = id;
  js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1&version=v2.5";
  fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));

// Module for GKGAME
var Module = {
    TOTAL_MEMORY: 268435456,
    errorhandler: null,
    compatibilitycheck: null,
    dataUrl: "http://51.254.134.174/gkgame/Release/gkgame.data",
    codeUrl: "http://51.254.134.174/gkgame/Release/gkgame.js",
    memUrl: "http://51.254.134.174/gkgame/Release/gkgame.mem",
};

// maximize screen
var full = document.getElementById("FullScreen");
full.onclick = function() { SetFullscreen(1); };
