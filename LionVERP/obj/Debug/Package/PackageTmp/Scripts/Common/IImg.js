﻿function addEvent(obj, sType, fn) {
    if (obj.addEventListener) {
        obj.addEventListener(sType, fn, false);
    } else {
        obj.attachEvent('on' + sType, fn);
    }
};
function removeEvent(obj, sType, fn) {
    if (obj.removeEventListener) {
        obj.removeEventListener(sType, fn, false);
    } else {
        obj.detachEvent('on' + sType, fn);
    }
};
function prEvent(ev) {
    var oEvent = ev || window.event;
    if (oEvent.preventDefault) {
        oEvent.preventDefault();
    }
    return oEvent;
}
/*添加滑轮事件*/
function addWheelEvent(obj, callback) {
    if (window.navigator.userAgent.toLowerCase().indexOf('firefox') != -1) {
        addEvent(obj, 'DOMMouseScroll', wheel);
    } else {
        addEvent(obj, 'mousewheel', wheel);
    }
    function wheel(ev) {
        var oEvent = prEvent(ev),
		delta = oEvent.detail ? oEvent.detail > 0 : oEvent.wheelDelta < 0;
        callback && callback.call(oEvent, delta);
        return false;
    }
};
/*页面载入后*/
function nck(id) {
    var oImg = document.getElementById(id);

    /*拖拽功能*/
    (function () {
        addEvent(oImg, 'mousedown', function (ev) {
            var oEvent = prEvent(ev),
			oParent = oImg.parentNode,
			disX = oEvent.clientX - oImg.offsetLeft,
			disY = oEvent.clientY - oImg.offsetTop,
			startMove = function (ev) {
			    if (oParent.setCapture) {
			        oParent.setCapture();
			    }
			    var oEvent = ev || window.event,
				l = oEvent.clientX - disX,
				t = oEvent.clientY - disY;
			    oImg.style.left = l + 'px';
			    oImg.style.top = t + 'px';
			    oParent.onselectstart = function () {
			        return false;
			    }
			}, endMove = function (ev) {
			    if (oParent.releaseCapture) {
			        oParent.releaseCapture();
			    }
			    oParent.onselectstart = null;
			    removeEvent(oParent, 'mousemove', startMove);
			    removeEvent(oParent, 'mouseup', endMove);
			};
            addEvent(oParent, 'mousemove', startMove);
            addEvent(oParent, 'mouseup', endMove);
            return false;
        });
    })();
    /*以鼠标位置为中心的滑轮放大功能*/
    (function () {
        addWheelEvent(oImg, function (delta) {
            var ratioL = (this.clientX - oImg.offsetLeft) / oImg.offsetWidth,
			ratioT = (this.clientY - oImg.offsetTop) / oImg.offsetHeight,
			ratioDelta = !delta ? 1 + 0.1 : 1 - 0.1,
			w = parseInt(oImg.offsetWidth * ratioDelta),
			h = parseInt(oImg.offsetHeight * ratioDelta),
			l = Math.round(this.clientX - (w * ratioL)),
			t = Math.round(this.clientY - (h * ratioT));
            with (oImg.style) {
                width = w + 'px';
                height = h + 'px';
                left = l + 'px';
                top = t + 'px';
            }
        });
    })();
};