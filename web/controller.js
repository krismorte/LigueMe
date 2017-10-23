app.controller("ligueMeController", function($scope,$http){

	urlLigueme='WEB-API';
	

	$scope.chamada = function(){
		$scope.solicitacao.fila='LINE-ID';
		$scope.solicitacao.response = grecaptcha.getResponse();

		var req = {
			method: 'POST',
			url: urlLigueme,
			headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
			data: $.param($scope.solicitacao)
		};

		$http(req).then(function successCallback(response) {
            console.log('success');
            alert("Aguarde que iremos lhe ligar");
            $scope.solicitacao.numero=''
            $scope.solicitacao.response=''
            console.log(myModal);
            myModal.style ='display: none;';
        }, function errorCallback(response) {
            console.log('failed');
            alert("Ocorreu uma falha, tente mais tarde.");
        });	

	};

});