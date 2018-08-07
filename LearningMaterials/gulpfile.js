/// <binding BeforeBuild='default' />
var gulp = require('gulp'),
    plumber = require('gulp-plumber'),
    sass = require('gulp-sass'),
    concat = require('gulp-concat'),
    uglify = require('gulp-uglify'),
    cssmin = require('gulp-cssmin'),
    filter = require('gulp-filter'),
    bom = require('gulp-bom'),
    jsminify = require('gulp-minify');
rename = require('gulp-rename');
gutil = require('gulp-util');
del = require('del');
environments = require('gulp-environments');
runSequence = require('run-sequence');
angularFilesort = require('gulp-angular-filesort');
inject = require('gulp-inject');
saveLicense = require('uglify-save-license');
gulpif = require('gulp-if');
development = environments.development;
production = environments.production;
UWPBuild = true;

var errorHandler = function (error) {
    gutil.log(error);
}

var resolveMinifiedPath = function (path) {
    var params = path.split("/");
    var file = params.splice(params.length - 1, 1)[0];
    var newPath = params.join("/") + "/";

    return {
        file: file,
        path: newPath
    };
}

//default task - Will get loaded during Debug in VS and on running gulp Ex: gulp
gulp.task('default', function (callback) {
    environments.current(development);
    gutil.log("Production: " + production());
    gutil.log("Development: " + development());
    runSequence('model', 'common', 'css', 'services', 'adminservices', 'core', 'directives', 'controller', 'admincontroller','appContextSdk', callback);
});


//production task - Will get loaded during build and on running gulp with param Ex: gulp production
gulp.task('productionUWP', function (callback) {
    environments.current(production);

    UWPBuild = true;

    gutil.log("Production: " + production());
    gutil.log("Development: " + development());
    gutil.log("UWPBuild: true");
    runSequence('model', 'common', 'css', 'services', 'adminservices', 'core', 'directives', 'controller', 'admincontroller','appContextSdk', callback);
});
//production task - Will get loaded during build and on running gulp with param Ex: gulp production
gulp.task('productionWebsite', function (callback) {
    UWPBuild = false;
    environments.current(production);
    gutil.log("Production: " + production());
    gutil.log("Development: " + development());
    gutil.log("UWPBuild: false");
    runSequence('model', 'common', 'css', 'services', 'adminservices', 'core', 'directives', 'controller', 'admincontroller', 'appContextSdk', callback);
});



// Process Model js
gulp.task('model', function (callback) {

    var min = resolveMinifiedPath("./model/model.min.js");

    return gulp.src('./defaultweb.html')
    .pipe(inject(gulp.src(['model/**/*.js', '!model/**/*.min.js'])
    .pipe(angularFilesort())
    .pipe(production(uglify()))
    .pipe(gulpif(UWPBuild,production(bom())))
    .pipe(production(concat(min.file)))
    .pipe(production(gulp.dest(min.path))), { name: 'model' }))
    .pipe(gulp.dest('.'))
});

// Process Common js
gulp.task('common', function (callback) {

    var min = resolveMinifiedPath("./common/common.min.js");

    return gulp.src('./defaultweb.html')
    .pipe(inject(gulp.src(['common/**/*.js', '!common/**/*.min.js'])
    .pipe(angularFilesort())
    .pipe(production(uglify()))
    .pipe(gulpif(UWPBuild,production(bom())))
    .pipe(production(concat(min.file)))
    .pipe(production(gulp.dest(min.path))), { name: 'common' }))
    .pipe(gulp.dest('.'))
});

// Compile out sass files and minify it
gulp.task('css', function () {

    var min = resolveMinifiedPath("./css/uap.min.css");

    return gulp.src('./defaultweb.html')
    .pipe(inject(gulp.src(['./sass/**/*.scss'])
    .pipe(plumber(errorHandler))
    .pipe(sass())
    .pipe(cssmin())
    .pipe(gulpif(UWPBuild,production(bom())))
    .pipe(concat(min.file))
    .pipe(gulp.dest(min.path)), { name: 'css' }))
    .pipe(gulp.dest('.'))

});

// Process Controller for User mode js
gulp.task('controller', function () {

    var min = resolveMinifiedPath("./controllers/controller.min.js");

    return gulp.src('./defaultweb.html')
    .pipe(inject(gulp.src(['controllers/**/*.js', '!controllers/**/*.min.js'])
    .pipe(angularFilesort())
    .pipe(production(uglify()))
    .pipe(gulpif(UWPBuild,production(bom())))
    .pipe(production(concat(min.file)))
    .pipe(production(gulp.dest(min.path))), { name: 'controller' }))
    .pipe(gulp.dest('.'))


});

// Process Controller for Admin mode js
gulp.task('admincontroller', function () {

    var min = resolveMinifiedPath("./admin/controllers/adminController.min.js");

    return gulp.src('./defaultweb.html')
    .pipe(inject(gulp.src(['admin/controllers/**/*.js', '!admin/controllers/**/*.min.js'])
    .pipe(angularFilesort())
    .pipe(production(uglify()))
    .pipe(gulpif(UWPBuild,production(bom())))
    .pipe(production(concat(min.file)))
    .pipe(production(gulp.dest(min.path))), { name: 'admincontroller' }))
    .pipe(gulp.dest('.'))

});

// Process Core js
gulp.task('core', function () {

    var min = resolveMinifiedPath("./core/core.min.js");

    return gulp.src('./defaultweb.html')
    .pipe(inject(gulp.src(['core/**/*.js', '!core/**/*.min.js', '!core/**/yammerlib.js'])
    .pipe(angularFilesort())
    .pipe(production(uglify()))
    .pipe(gulpif(UWPBuild,production(bom())))
    .pipe(production(concat(min.file)))
    .pipe(production(gulp.dest(min.path))), { name: 'core' }))
    .pipe(gulp.dest('.'))

});

// Process Directives js
gulp.task('directives', function () {

    var min = resolveMinifiedPath("./directives/directives.min.js");

    return gulp.src('./defaultweb.html')
    .pipe(inject(gulp.src(['directives/**/*.js', '!directives/**/*.min.js'])
    .pipe(angularFilesort())
    .pipe(production(uglify()))
    .pipe(gulpif(UWPBuild,production(bom())))
    .pipe(production(concat(min.file)))
    .pipe(production(gulp.dest(min.path))), { name: 'directives' }))
    .pipe(gulp.dest('.'))

});



// Process User Mode Services js
gulp.task('services', function () {

    var min = resolveMinifiedPath("./services/services.min.js");

    return gulp.src('./defaultweb.html')
    .pipe(inject(gulp.src(['services/**/*.js', '!services/**/*.min.js'])
    .pipe(angularFilesort())
    .pipe(production(uglify()))
    .pipe(gulpif(UWPBuild,production(bom())))
    .pipe(production(concat(min.file)))
    .pipe(production(gulp.dest(min.path))), { name: 'services' }))
    .pipe(gulp.dest('.'))

});

// Process Admin Mode Services js
gulp.task('adminservices', function () {

    var min = resolveMinifiedPath("./admin/services/adminServices.min.js");

    return gulp.src('./defaultweb.html')
    .pipe(inject(gulp.src(['admin/services/**/*.js', '!admin/services/**/*.min.js'])
    .pipe(angularFilesort())
    .pipe(production(uglify()))
    .pipe(gulpif(UWPBuild,production(bom())))
    .pipe(production(concat(min.file)))
    .pipe(production(gulp.dest(min.path))), { name: 'adminservices' }))
    .pipe(gulp.dest('.'))

});

// Compile out sass files and minify it
gulp.task('appContextSdk', function () {

    var min = resolveMinifiedPath("appContextSdk.min.js");

    return gulp.src(['common/appContextConfig.js', 'common/appContextProvider.js', 'model/consumer.js', 'model/entity.js', 'model/consumerEntity.js', 'model/contextAttribute.js',
    'model/entityAttribute.js', 'services/appContextDataService.js', 'services/appContextRepository.js', 'core/appContextManager.js'])
    .pipe(angularFilesort())
    .pipe(production(uglify({
        output: {
            comments: saveLicense
        }
    })))
    .pipe(gulpif(UWPBuild,production(bom())))
    .pipe(production(concat(min.file)))
    .pipe(production(gulp.dest('./lib')))
});

// Compile out sass files and minify it
gulp.task('MicrosoftIT-css', function () {

    var min = resolveMinifiedPath("./MicrosoftIT/Compliance/css/WinJSCompliance.min.css");
    return gulp.src(['MicrosoftIT/Compliance/css/*.css', '!MicrosoftIT/Compliance/css/*.min.css'])
        .pipe(cssmin())
    .pipe(gulpif(UWPBuild,production(bom())))
        .pipe(concat(min.file))
        .pipe(gulp.dest(min.path));
});

gulp.task('MicrosoftIT-js', function () {
   
    return gulp.src(['MicrosoftIT/**/*.js', '!MicrosoftIT/**/*.min.js'])
       .pipe(uglify())
       .pipe(gulpif(UWPBuild,production(bom())))
       .pipe(rename({ suffix: '.min' }))
       .pipe(gulp.dest('MicrosoftIT'));
});



gulp.task('root-uglify:js', function () {
    gulp.src(['*.js', '!gulpfile.js', '!*.min.js'])
      .pipe(uglify())
      .pipe(gulpif(UWPBuild,production(bom())))
      .pipe(rename({ suffix: '.min' }))
      .pipe(gulp.dest('.'));
});

gulp.task('lib-uglify:js', function () {
    gulp.src(['lib/**/*.js', '!lib/**/*.min.js'])
	  .pipe(uglify())
      .pipe(gulpif(UWPBuild,production(bom())))
      .pipe(rename({ suffix: '.min' }))
      .pipe(gulp.dest('lib'));
});

