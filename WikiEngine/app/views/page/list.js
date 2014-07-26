(function() {
    var mod = angular.module('app');

    mod.controller('app.views.page.list', ['$scope', 'Page',
        function ($scope, Page) {
            $scope.items = Page.query();

            $scope.delete = function(item) {

                var index = this.items.indexOf(item);
                Page.delete({ id: item.id }, function() {
                    $scope.items.splice(index, 1);
                });
            };
        }
    ]);
})();

