(function () {
    var mod = angular.module('app');

    mod.controller('app.views.page.item', ['$scope', '$routeParams', 'Page',
        function ($scope, $routeParams, Page) {

            $scope.item = Page.get({ id: $routeParams.id }, function(data) {
                $scope.contentHtml = marked(data.content || '');
            });
        }
    ]);
})();
