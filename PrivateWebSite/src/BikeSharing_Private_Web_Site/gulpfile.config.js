const libs = [
    './node_modules/jquery/dist/jquery.js',
    './node_modules/jquery-validation/dist/jquery.validate.js',
    './node_modules/tether/dist/js/tether.js',
    './node_modules/bootstrap/dist/js/bootstrap.js'
];

const main = [
    './src/js/site.js'
];


const src = './src';
const dist = './wwwroot';

module.exports = {
    dist: {
        base: dist,
        js: dist + '/js',
        css: dist + '/css',
        images: dist + '/images',
        fonts: dist + '/fonts'
    },
    src: {
        base: src,
        libs: libs,
        main: main,
        images: src + '/images/**/*',
        fonts: src + '/fonts/**/*',
        styles: src + '/scss/*.scss'
    }
};