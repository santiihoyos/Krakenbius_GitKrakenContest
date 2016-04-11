var full = document.getElementById("FullScreen");
full.onclick = function() { console.log("maximize");
    var t = JSEvents.canPerformEventHandlerRequests;
    JSEvents.canPerformEventHandlerRequests = function() {
        return 1
    }, Module.cwrap("SetFullscreen", "void", ["number"])(1), JSEvents.canPerformEventHandlerRequests = t; 
    console.log("end maximize");
};

