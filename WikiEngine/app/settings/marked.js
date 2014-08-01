(function() {
    angular.module('app')
        .config(function() {
            var markedOptions = {
                gfm: true,
                tables: true,
                breaks: true,
                pedantic: true,
                sanitize: false,
                smartLists: true,
                smartypants: false,
                langPrefix: 'lang-'
            };

            marked.setOptions(markedOptions);
        });
})();