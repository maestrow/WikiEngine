(function() {
    var mod = angular.module('app');

    mod.controller('app.views.page.list', ['$scope', 'Page',
        function ($scope, Page) {
            $scope.items = Page.query();
        }
    ]);
})();

