var Bikes;
(function (Bikes) {
    'use strict';
    // Animations1
    var WayNamespace = 'Waypoint';
    var elements = document.querySelectorAll('.wayp');
    Array.prototype.forEach.call(elements, function (element) {
        var waypoint = new window[WayNamespace]({
            element: element,
            handler: function () {
                this.element.classList.add('animated');
            },
            offset: parseInt(element.dataset.offset, 10) || 500
        });
    });
    // Preload images
    var preimages = document.querySelectorAll('.u-pre img');
    window.onload = function () {
        Array.prototype.forEach.call(preimages, function (image) {
            image.style.opacity = '1';
        });
    };
    // Simple swipe for bikes
    var touchs = {
        start: {
            x: 0,
            y: 0
        },
        end: {
            x: 0,
            y: 0
        }
    };
    var sides = {
        current: null,
        left: 'left',
        right: 'right'
    };
    var touchable = document.querySelector('.js-cities');
    var radios = document.querySelectorAll('.js-cities-check');
    var touchHandler = function () {
        if (touchs.end.x < touchs.start.x) {
            sides.current = sides.left;
        }
        if (touchs.end.x > touchs.start.x) {
            sides.current = sides.right;
        }
        var modified = false;
        Array.prototype.forEach.call(radios, function (radio, i) {
            if (radio.checked && !modified) {
                var direction = sides.current === sides.right ? -1 : 1;
                var next = i + direction;
                next = next < 0 ? radios.length - 1 : next;
                next = next > radios.length - 1 ? 0 : next;
                var nextRadio = radios[next];
                radio.checked = false;
                nextRadio.checked = true;
                modified = true;
            }
        });
    };
    touchable.addEventListener('touchstart', function (e) {
        touchs.start.x = e.touches[0].screenX;
        touchs.start.y = e.touches[0].screenY;
    });
    touchable.addEventListener('touchend', function (e) {
        touchs.end.x = e.changedTouches[0].screenX;
        touchs.end.y = e.changedTouches[0].screenY;
        touchHandler();
    });
})(Bikes || (Bikes = {}));
