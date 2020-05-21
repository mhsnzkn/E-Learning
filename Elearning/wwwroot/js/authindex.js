document.getElementById("btn-signup").addEventListener("click", function () {
    var name = document.getElementById("name");
    var surname = document.getElementById("surname");
    var title = document.getElementById("title");
    var email = document.getElementById("email");
    var phone = document.getElementById("phone");
    var tcno = document.getElementById("tcno");
    var job = document.getElementById("job");
    var address = document.getElementById("address");
    var institute = document.getElementById("institute");
    var formok = true;

    if (!name.value) {
        toastr.warning("İsim boş bırakılamaz!");
        formok = false;
    }
    if (!surname.value) {
        toastr.warning("Soysim boş bırakılamaz!");
        formok = false;
    }
    if (!email.value) {
        toastr.warning("Email boş bırakılamaz!");
        formok = false;
    } else {
        if (!email.value.includes("@") || !email.value.includes(".")) {
            toastr.warning("Email uygun değil!");
            formok = false;
        }
    }
    if (!phone.value) {
        toastr.warning("Telfon boş bırakılamaz!");
        formok = false;
    }
    if (phone.length < 10) {
        toastr.warning("Telfon numarası en az 10 hane olmalı!");
        formok = false;
    }
    if (!tcno.value) {
        toastr.warning("TC No boş bırakılamaz!");
        formok = false;
    } else {
        var value = tcno.value.toString();
        var isEleven = /^[0-9]{11}$/.test(value);
        var totalX = 0;
        for (var i = 0; i < 10; i++) {
            totalX += Number(value.substr(i, 1));
        }
        var isRuleX = totalX % 10 == value.substr(10, 1);
        var totalY1 = 0;
        var totalY2 = 0;
        for (var i = 0; i < 10; i += 2) {
            totalY1 += Number(value.substr(i, 1));
        }
        for (var i = 1; i < 10; i += 2) {
            totalY2 += Number(value.substr(i, 1));
        }
        var isRuleY = ((totalY1 * 7) - totalY2) % 10 == value.substr(9, 0);
        if (!isEleven || !isRuleX || !isRuleY) {
            toastr.warning("Tc No uygun değil");
            formok = false;
        }
    }
    if (!job.value) {
        toastr.warning("Meslek boş bırakılamaz!");
        formok = false;
    }
    if (!address.value) {
        toastr.warning("Adres boş bırakılamaz!");
        formok = false;
    }
    if (!institute.value) {
        toastr.warning("Kurum boş bırakılamaz!");
        formok = false;
    }

    if (formok) {
        var user = {
            userName: email.value,
            title: title.value,
            name: name.value,
            surname: surname.value,
            tcNo: tcno.value,
            institute: institute.value,
            job: job.value,
            email: email.value,
            phone: phone.value,
            address: address.value
        };
        $.ajax({
            url: '/api/Services/addUser',
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(user),
            success: function (res) {
                var rslt = res.split('####');
                if (rslt[0] == "1") {
                    toastr.success("Kayıt Başarılı! Şifre Mail hesabına gönderildi.");
                    name.value = "";
                    surname.value = "";
                    title.value = "";
                    email.value = "",
                    phone.value = "";
                    tcno.value = "";
                    job.value = "";
                    address.value = "";
                    institute.value = "";
                    document.getElementsByClassName("close")[0].click();
                } else {
                    toastr.warning(rslt[1]);
                }
            },
            error: function (res) {
                var err = res.responseText;
                var first = err.indexOf("[") + 1;
                var last = err.indexOf("]");
                toastr.error(err.substring(first, last));
            }
        });
    }
});

document.getElementById("btn-forgot").addEventListener("click", function () {

    var email = document.getElementById("email_forgot");
    var model = { email:email.value };
    $.ajax({
        url: '/api/Services/passForgot',
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: JSON.stringify(model),
        success: function (res) {
            if (res == "1") {
                email.value = "";
                document.getElementsByClassName("close")[1].click();
                toastr.success("Yeni şifre mail adresinize gönderildi");
            } else {
                toastr.error("Mail bulunamadı!");
            }
        },
        error: function (res) {
            var err = res.responseText;
            var first = err.indexOf("[") + 1;
            var last = err.indexOf("]");
            toastr.error(err.substring(first, last));
        }
    });
});

//FirstUpper Case / LOGIN
$('#name').keyup(function (evt) {
    var txt = $(this).val().toLowerCase();
    txt = txt.replace('i̇', 'i');
    $(this).val(txt.replace(/^(.)|\s(.)/g, function ($1) { return $1.toUpperCase(); }));
});

$('#surname').keyup(function (evt) {
    var txt = $(this).val().toLowerCase();
    $(this).val(txt.replace(/^(.)|\s(.)/g, function ($1) { return $1.toUpperCase(); }));
});