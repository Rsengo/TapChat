$(function () {
    $('#sign-in').click(function() {
        var tempUserName = $('#login-field').val();

        if (tempUserName.length === 0) {
            alert('Enter name!');
        } else {
            localStorage.setItem('tempUserName', tempUserName);

            location.href = '/Home/ChatView';
        }
    });
});