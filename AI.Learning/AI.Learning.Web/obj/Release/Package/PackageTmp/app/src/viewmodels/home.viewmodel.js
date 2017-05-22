$(function(){
    //TODO: jquery ready function feels weird to me
    var tara = new taraSvc();
    var vm = {
        showResults: ko.observable(false),
        messages: ko.observableArray([{createdBy:'Tara', content: "Hi, my name is Tara. Let's get started."}]),
        message: { 
            createdBy:ko.observable('Me'), 
            content: ko.observable('') 
            },
        response: {
            dictionary: {
                word: ko.observable(""),
                definition: ko.observable("")
            }
        },
        addMessage: function(){
            this.messages.push({
                createdBy: this.message.createdBy(), 
                content: this.message.content()
            });
            //TODO: scope forces the entire vm to the service
            var response = tara.sendMessage({createdBy: this.message.createdBy(), content: this.message.content()}, this);
        },
        addResponse: function(resp){
            //TODO: add tara response callback
            if(resp){
                if(resp.message){
                    this.messages.push(resp.message);
                    scrollMessages();
                }    
                if(resp.dictionaryResult){
                    this.showResults(true);
                    this.response.dictionary.word(resp.dictionaryResult.results[0].word);
                    this.response.dictionary
                    .definition(
                        resp.dictionaryResult
                        .results[0]
                        .lexicalEntries[0]
                        .entries[0]
                        .senses[0]
                        .definitions[0]
                        );
                }   
            }  else{
                this.messages.push({createdBy:'Tara', content: "I'm sorry, my brain had a hiccup. Please let me try again by making abother request."});
                    scrollMessages();
            }                 
        }
    };
    ko.applyBindings(vm);
});
