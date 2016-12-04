const libs = [
    './node_modules/jquery/dist/jquery.js',
    './node_modules/picturefill/dist/picturefill.js',
    './node_modules/waypoints/lib/noframework.waypoints.js',
    './node_modules/tether/dist/js/tether.js',
    './node_modules/bootstrap/dist/js/bootstrap.js'
];

const main = [
    './src/modules/main.ts'
];


const src = './src';
const dist = './content/build';

module.exports = {
    dist: {
        base: dist,
        js: dist + '/js',
        css: dist + '/css'
    },
    src: {
        base: src,
        libs: libs,
        main: main,
        styles: [src + '/scss/vendor/*.scss', src + '/scss/app/*.scss']
    }
};