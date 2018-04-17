$(function () {
    var chat = $.connection.chathub;
    var tempUserName = localStorage.getItem('tempUserName');
    var tempUserId;

    chat.client.getMessage = function (id, message, time) {
        var users = usersList.users;
        var userName;
        var normalizedTime = timeParse(time);

        for (var i = 0; i < users.length; i++) {
            if (users[i].id === id)
                userName = users[i].name;
        }

        messages.messages.push({
            userId: id,
            userName: userName,
            text: message,
            time:normalizedTime
        });
    };

    chat.client.onConnected = function (id, allUsers) {
        tempUserId = id;

        usersList.users.push({
            id: tempUserId,
            name: tempUserName,
            isTempUser: true
        });

        for (var i = 0; i < allUsers.length; i++) {
            usersList.users.push({
                id: allUsers[i].ConnectionId,
                name: allUsers[i].Name,
                isTempUser: false
            });
        }
    };

    chat.client.onNewUserConnected = function (id, name) {
        usersList.users.push({
            id: id,
            name: name,
            isTempUser: false
        });
    };

    chat.client.onUserDisconnected = function (id) {
        var users = usersList.users;

        for (var i = 0; i < users.length; i++) {
            if (users[i].id === id) {
                delete usersList.users[i];
            }
        }
    };

    $.connection.hub.start().done(function () {
        chat.server.onConnected(tempUserName);
        $('#enter-button').click(function () {
            chat.server.sendMessage(tempUserId, $('#message-text-box').val());
            $('#message-text-box').val('');
        });
    });
});

function timeParse(time) {
    var splitted = time.split('T');
    var result = splitted[0];

    splitted = splitted[1].split('.');
    result += ' ' + splitted[0];

    return result;
}