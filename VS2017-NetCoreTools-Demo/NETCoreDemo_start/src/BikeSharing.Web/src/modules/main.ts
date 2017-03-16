module Bikes {
    'use strict';

    // Animations1
    let WayNamespace = 'Waypoint';
    let elements = document.querySelectorAll('.wayp');
    Array.prototype.forEach.call(elements, element => {
        var waypoint = new window[WayNamespace]({
            element: element,
            handler: function () {
                this.element.classList.add('animated')
            },
            offset: parseInt(element.dataset.offset, 10) || 500
        });
    });

    // Preload images
    let preimages = document.querySelectorAll('.u-pre img');
    window.onload = () => {
        Array.prototype.forEach.call(preimages, (image: HTMLElement) => {
            image.style.opacity = '1';
        });
    }


    // Simple swipe for bikes
    let touchs = {
        start: {
            x: 0,
            y: 0
        },
        end: {
            x: 0,
            y: 0
        }
    };

    let sides = {
        current: null,
        left: 'left',
        right: 'right'
    };

    let touchable = document.querySelector('.js-cities');
    let radios = document.querySelectorAll('.js-cities-check');
    let touchHandler = () => {
        if (touchs.end.x < touchs.start.x) {
            sides.current = sides.left;
        }
        if (touchs.end.x > touchs.start.x) {
            sides.current = sides.right;
        }

        let modified: boolean = false;
        Array.prototype.forEach.call(radios, (radio: HTMLInputElement, i: number) => {
            if (radio.checked && !modified) {
                let direction = sides.current === sides.right ? -1 : 1;
                let next = i + direction;
                next = next < 0 ? radios.length - 1 : next;
                next = next > radios.length - 1 ? 0 : next;

                let nextRadio: HTMLInputElement = <HTMLInputElement>radios[next];
                radio.checked = false;
                nextRadio.checked = true;
                modified = true;
            }

        });
    }

    touchable.addEventListener('touchstart', (e: TouchEvent) => {
        touchs.start.x = e.touches[0].screenX;
        touchs.start.y = e.touches[0].screenY;
    });

    touchable.addEventListener('touchend', (e: TouchEvent) => {
        touchs.end.x = e.changedTouches[0].screenX;
        touchs.end.y = e.changedTouches[0].screenY;
        touchHandler();
    });
}
