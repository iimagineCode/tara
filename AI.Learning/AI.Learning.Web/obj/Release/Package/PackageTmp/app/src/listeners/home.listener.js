//TODO: remove from global scope
document.getElementById("addMessage").addEventListener("click", scrollMessages);

function scrollMessages(){
    document.getElementById('messages').scrollTop = 9999999;
}