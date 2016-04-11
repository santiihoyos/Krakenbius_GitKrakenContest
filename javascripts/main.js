// Twitter
!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0],p=/^http:/.test(d.location)?'http':'https';if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=p+'://platform.twitter.com/widgets.js';fjs.parentNode.insertBefore(js,fjs);}}(document, 'script', 'twitter-wjs');

// Module for GKGAME
var Module = {
    TOTAL_MEMORY: 536870912,
    errorhandler: null,
    compatibilitycheck: null,
    dataUrl: "http://51.254.134.174/gkgame/Release/gkgame.data",
    codeUrl: "http://51.254.134.174/gkgame/Release/gkgame.js",
    memUrl: "http://51.254.134.174/gkgame/Release/gkgame.mem",
};

// maximize screen
var full = document.getElementById("FullScreen");
full.onclick = function() { SetFullscreen(1); };
