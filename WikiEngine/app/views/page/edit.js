(function() {
    var mod = angular.module('app');

    mod.controller('app.views.page.edit', ['$scope', '$routeParams', '$location', 'Page',
        function ($scope, $routeParams, $location, Page) {

            $scope.item = Page.get({ id: $routeParams.id });

            $scope.save = function () {
                this.item.$save({ id: this.item.id });
                $location.path('/page/' + this.item.id);
            };
        }
    ]);
})();