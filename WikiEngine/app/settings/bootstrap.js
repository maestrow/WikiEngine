(function() {
    angular.module('app')
        .constant('paginationConfig', {
            firstText: '«',
            previousText: '‹',
            nextText: '›',
            lastText: '»',
            itemsPerPage: 50,
            boundaryLinks: true,
            directionLinks: true,
            rotate: true
        });
})();