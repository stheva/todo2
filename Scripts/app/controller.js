var TodoListControllers = angular.module("TodoListControllers", []);
// this controller call the api method and display the list of assignments
// in list.html
TodoListControllers.controller("ListController", ['$scope', '$http',
    function ($scope, $http) {
        $http.get('/api/assignments').success(function (data) {
            $scope.assignments = data;
        });
    }
]);
// this controller call the api method and display the record of selected assignment
// in delete.html and provide an option for delete
TodoListControllers.controller("DeleteController", ['$scope', '$http', '$routeParams', '$location',
    function ($scope, $http, $routeParams, $location) {
        $scope.id = $routeParams.id;
        $http.get('/api/assignments/' + $routeParams.id).success(function (data) {
            $scope.description = data.Description;
            $scope.completed = data.Completed;
        });
        $scope.delete = function () {
            $http.delete('/api/assignments/' + $scope.id).success(function (data) {
                $location.path('/list');
            }).error(function (data) {
                $scope.error = "Det oppstod en feil ved sletting av oppgave.. " + data;
            });
        };
    }
]);
// this controller call the api method and display the record of selected assignment
// in edit.html and provide an option for create and modify the assignment and save the assignment record
TodoListControllers.controller("EditController", ['$scope', '$filter', '$http', '$routeParams', '$location',
    function ($scope, $filter, $http, $routeParams, $location) {
        //$http.get('/api/country').success(function (data) {
        //    $scope.countries = data;
        //});
        //$scope.id = 0;
        //$scope.getStates = function () {
        //    var country = $scope.country;
        //    if (country) {
        //        $http.get('/api/country/' + country).success(function (data) {
        //            $scope.states = data;
        //        });
        //    }
        //    else {
        //        $scope.states = null;
        //    }
        //}
        $scope.save = function() {
            var obj = {
                Id: $scope.id,
                Description: $scope.description,
                Completed: $scope.completed
            };
            if ($scope.id === 0) {
                $http.post('/api/assignments/', obj)
                    .success(function(data) {
                        $location.path('/list');
                    })
                    .error(function(data) {
                        $scope.error = "Det oppstod en feil ved oppretting av oppgave: " + data.ExceptionMessage;
                    });
            } else {
                $http.put('/api/assignments/', obj)
                    .success(function(data) {
                        $location.path('/list');
                    })
                    .error(function(data) {
                        console.log(data);
                        $scope.error = "Det oppstod en feil ved lagring av oppgave: " + data.ExceptionMessage;
                    });
            }
        };
        if ($routeParams.id) {
            $scope.id = $routeParams.id;
            $scope.title = "Endre oppgave";
            $http.get('/api/assignments/' + $routeParams.id).success(function (data) {
                $scope.description = data.Description;
                $scope.completed = data.Completed;
            });
        }
        else {
            $scope.title = "Opprett ny oppgave";
        }
    }
]);