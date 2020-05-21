document.addEventListener("DOMContentLoaded", function () {
    btnupdatepassword();
    btnupdateaccount();
    opencert();
});

document.getElementById("upd_pass").addEventListener("click", function () {
    var curpass = document.getElementById("currentpass");
    var newpass1 = document.getElementById("newpass1");
    var newpass2 = document.getElementById("newpass2");
    var formok = true;

    if (curpass.value && newpass1.value && newpass2.value) {
        if ((curpass.value === newpass1.value) && (newpass1.value === newpass2.value)) {
            formok = false;
            toastr.warning("Tüm şifreler aynı");
        }
        if (newpass1.value === newpass2.value) {
            if (newpass1.value.length > 4) {

            } else {
                formok = false;
                toastr.warning("Şifre en az 5 karakter olmalı");
            }
        } else {
            formok = false;
            toastr.warning("Yeni girilen şifreler eşleşmiyor!");
        }
    } else {
        formok = false;
        toastr.warning("Eski ve yeni şifreleri eksiksiz giriniz!");
    }
    if (formok) {
        var model = { userName: curpass.value, Password: newpass1.value };
        $.ajax({
            url: '/api/Services/ChangePassword',
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(model),
            success: function (res) {
                var rslt = res.split('####');
                if (rslt[0] == "1") {
                    toastr.success("Şifre güncellendi!");
                    curpass.value = "";
                    newpass1.value = "";
                    newpass2.value = "";

                } else {
                    toastr.error(rslt[1]);
                }
            },
            error: function (res) {
                toastr.error("Bir hata oldu!");
            }
        })
    }
});


$('#certTab').click(function () {
    $('#send').attr('disabled', true);

    var iscert = document.getElementById("iscert");
    if (iscert.innerText == "0") {

        $.ajax({
            url: '/api/Services/GetUserCertificates',
            type: 'GET',
            dataType: 'json',
            success: function (res) {
                var content = "";
                for (var i = 0; i < res.length; i++) {
                    content += '<div class="col-md-6 mt-4"><a href = "/Result/Certificate/'+res[i].id+'" class="card text-gray overflow-hidden height-100p shadow-v1 border" >'+
                            '<img class="card-img-top" src="'+res[i].path+'" alt="">'+
                                '<div class="card-body"><h4 class="h5">'+
                        res[i].title+
                                 '</h4></div></a></div >';
                }
                document.getElementById("certs").innerHTML = content;
                iscert.innerText = "1";
            },
            error: function () {
                toastr.error("Bir hata oldu!");
            }
        });
    }

});


function btnupdatepassword() {
    var pass = document.getElementsByClassName("form2");
    for (var i = 0; i < pass.length; i++) {
        pass[i].addEventListener("input", function () {
            document.getElementById("upd_pass").disabled = false;
        })
    }
}


function btnupdateaccount() {
    var pass = document.getElementsByClassName("form1");
    for (var i = 0; i < pass.length; i++) {
        pass[i].addEventListener("input", function () {
            document.getElementById("upd_account").disabled = false;
        })
    }
}

function opencert() {
    var iscerton = $('#cert').text();
    if (iscerton == "1") {
        $('#certTab').click();
    }
}

$('#upd_account').click(function () {
    var name = $('#Name').val();
    var surname = $('#Surname').val();
    var title = $('#Title').val();
    var tcno = $('#TcNo').val();
    var username = $('#UserName').val();
    var phone = $('#Phone').val();
    var job = $('#Job').val();
    var institute = $('#Institute').val();
    var address = $('#Address').val();
    var formok = true;

    if (!name) {
        toastr.warning("İsim boş bırakılamaz!");
        formok = false;
    }
    if (!surname) {
        toastr.warning("Soysim boş bırakılamaz!");
        formok = false;
    }
    if (!title) {
        toastr.warning("Ünvan boş bırakılamaz!");
        formok = false;
    }
    if (!username) {
        toastr.warning("Email boş bırakılamaz!");
        formok = false;
    } else {
        if (!username.includes("@") || !username.includes(".")) {
            toastr.warning("Email uygun değil!");
            formok = false;
        }
    }
    if (!phone) {
        toastr.warning("Telfon boş bırakılamaz!");
        formok = false;
    }
    if (phone.length<10) {
        toastr.warning("Telfon numarası en az 10 hane olmalı!");
        formok = false;
    }
    if (!tcno) {
        toastr.warning("TC No boş bırakılamaz!");
        formok = false;
    } else {
        var value = tcno.toString();
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
    if (!job) {
        toastr.warning("Meslek boş bırakılamaz!");
        formok = false;
    }
    if (!address) {
        toastr.warning("Adres boş bırakılamaz!");
        formok = false;
    }
    if (!institute) {
        toastr.warning("Kurum boş bırakılamaz!");
        formok = false;
    }

    if (formok) {
        var user = {
            Name: name,
            Surname: surname,
            Title: title,
            TcNo: tcno,
            UserName: username,
            Phone: phone,
            Job: job,
            Institute: institute,
            Address: address
        };

        $.ajax({
            url: '/api/Services/UpdateUser',
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            data: JSON.stringify(user),
            success: function (res) {
                if (res == "1") {
                    $('#txt_name').text(name + " " + surname);
                    $('#txt_title').text(title);
                    $('#txt_username').text(username);
                    $('#txt_phone').text(phone);
                    $('#txt_address').text(address);

                    toastr.success("Güncelleme Başarılı!");
                } else {
                    toastr.error("Güncelleme yapılamadı");
                }
                
            },
            error: function () {
                toastr.error("Bir hata oldu! Güncelleme yapılamadı");
            }
        });
    }
})
