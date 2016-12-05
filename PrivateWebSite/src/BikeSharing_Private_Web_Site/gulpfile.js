/// <binding BeforeBuild='build' />
'use strict';

// Dependencies
const gulp = require('gulp');
const gulpLoadPlugins = require('gulp-load-plugins');

const config = require('./gulpfile.config');
const $ = gulpLoadPlugins();

// libs
gulp.task('libs', () => {
    return gulp.src(config.src.libs)
        .pipe($.concat('libs.js'))
        .pipe(gulp.dest(config.dist.js));
});

gulp.task('libs:release', () => {
    return gulp.src(config.src.libs)
        .pipe($.concat('libs.js'))
        .pipe($.uglify())
        .pipe(gulp.dest(config.dist.js));
});

// main
gulp.task('main', () => {
    return gulp.src(config.src.main)
        .pipe($.concat('main.js'))
        .pipe(gulp.dest(config.dist.js));
});

gulp.task('main:release', () => {
    return gulp.src(config.src.main)
        .pipe($.concat('main.js'))
        .pipe($.uglify())
        .pipe(gulp.dest(config.dist.js));
});

// styles
gulp.task('styles', () => {
    return gulp.src(config.src.styles)
        .pipe($.sass({ outputStyle: 'compressed' }).on('error', $.sass.logError))
        .pipe($.concat('styles.css'))
        .pipe($.autoprefixer({ browsers: ['last 2 versions'] }))
        .pipe(gulp.dest(config.dist.css));
});

// images
gulp.task('images', () => {
    return gulp.src(config.src.images)
        .pipe(gulp.dest(config.dist.images));
});

// fonts
gulp.task('fonts', () => {
    return gulp.src(config.src.fonts)
        .pipe(gulp.dest(config.dist.fonts));
});

// clean
var del = require('del');
gulp.task('clean', () => {
    return del.sync(config.dist.base);
});

// watch
gulp.task('watch', () => {
    gulp.watch(config.src.base + '/js/**/*', ['main']);
    gulp.watch(config.src.base + '/scss/**/*', ['styles']);
    gulp.watch(config.src.base + '/fonts/**/*', ['styles']);
    return gulp.watch(config.src.base + '/images/**/*', ['images']);
});

gulp.task('default', ['main', 'images', 'fonts', 'styles']);
gulp.task('debug', ['default', 'watch']);
gulp.task('release', ['main:release', 'images', 'fonts', 'styles']);
gulp.task('build', ['clean', 'libs', 'default']);

