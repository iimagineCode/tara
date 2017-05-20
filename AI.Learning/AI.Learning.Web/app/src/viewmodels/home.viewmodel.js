$(function(){
    var vm = {
        messages: ko.observableArray([{createdBy:'Tara', content: "Hi, my name is Tara. Let's get started."}]),
        message: { 
            createdBy:ko.observable('Me'), 
            content: ko.observable('') 
            },
        addMessage: function(){
            this.messages.push({
                createdBy: this.message.createdBy(), 
                content: this.message.content()
            });
            //TODO: send message to tara service
        },
        addResponse: function(){
            //TODO: add tara responses
        }
    };
    ko.applyBindings(vm);
});
