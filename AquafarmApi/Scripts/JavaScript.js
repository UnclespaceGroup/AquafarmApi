
    $(function () {
            //$('#submit').click(function (e) {
            //    // e.preventDefault();
            //    var data = {
            //        Email: $('#email').val(),
            //        Password: $('#password').val() ,
            //        ConfirmPassword: $('#confirmpassword').val()
            //    };

            //    $.ajax({
            //        type: 'POST',
            //        url: '/api/Account/Register',
            //        contentType: 'application/json; charset=utf-8',
            //        data: JSON.stringify(data),
            //        success: function (data) {
            //            alert("Регистрация пройдена");
            //        },
            //        error: (function (er) {
            //            alert(er.responseText)
            //            console.log(er)
            //        })
            //    });
            //});

            var tokenKey = "tokenInfo";
            $('#submitLogin').click(function (e) {
        e.preventDefault();
    var loginData = {
        grant_type: 'password',
    username: $('#emailLogin').val(),
    password: $('#passwordLogin').val()
};

                $.ajax({
        type: 'POST',
    url: '/Token',
    data: loginData,
                    success: function (data) {
        $('.userName').text(data.userName);
    $('.userInfo').css('display', 'block');
    $('.loginForm').css('display', 'none');
    // сохраняем в хранилище sessionStorage токен доступа
    sessionStorage.setItem(tokenKey, data.access_token);
    alert('Вы зашли как ' + data.userName)
    console.log(data.access_token);
},
                    error: function (data) {
        console.log(data)
                        alert('При логине возникла ошибка ' + data.responseText);
}
});
});

            $('#logOut').click(function (e) {
        e.preventDefault();
    sessionStorage.removeItem(tokenKey);
    alert('Вы вышли')
    location.reload()
});
})
