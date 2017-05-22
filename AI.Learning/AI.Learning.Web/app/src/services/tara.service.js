//TODO: remove from global scope
function taraSvc(){
    var uri = 'http://tarasvc.azurewebsites.net/api/';
    return {
        sendMessage: postMessage
    };

    function postMessage( msg, vm ){
        $.post( uri + 'messages', msg)
        .done( function( data ) {
            vm.addResponse(data);
        })
        .fail( function( err ){
            console.log(err);  
        });
    }
}