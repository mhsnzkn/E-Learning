
function next() {
    var uid = parseInt(document.getElementById("userid").innerText);
    var qid = parseInt(document.getElementById("questionid").innerText);
    var qcid = parseInt(document.getElementById("questionchoiceid").innerText);
    var ucid = parseInt(document.getElementById("usercourseid").innerText);
    var ucdid = parseInt(document.getElementById("usercoursedetailid").innerText);
    var type = document.getElementById("type").innerText;

    if (qcid) {
        var model = { usercoursedetailid: ucdid, userid: uid, questionid: qid, questionchoiceid: qcid, usercourseid: ucid,type:type };
        $.ajax({
            url: '/api/Services/AddQuestionChoice',
            type: 'POST',
            contentType:'application/json; charset=utf-8',
            dataType: 'json',
            data: JSON.stringify(model),
            success: function (response) {
                return true;
            },
            error: function (response) {
                alert("Bir hata oluştu!!");
                return false;
            }
        });

    } else {
        alert("İşaretleme Yapmadınız!");
        return false;
    }
};
//sayfa hazır olunca
document.addEventListener("DOMContentLoaded", function (event) {
    if (document.getElementById("done").innerText == "False") {
        var ex = document.getElementsByName("example");
        for (var i = 0; i < ex.length; i++) {
            ex[i].addEventListener("click", function () {
                document.getElementById("questionchoiceid").innerText = this.value;
            });
        };
    }
    
    var uid = parseInt(document.getElementById("userid").innerText);
    var qid = parseInt(document.getElementById("questionid").innerText);
    var ucdid = parseInt(document.getElementById("usercoursedetailid").innerText);

    var datamodel = { userid: uid, questionid: qid, usercoursedetailid:ucdid };
    $.ajax({
        url: '/api/Services/GetUserChoice',
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: datamodel,
        success: function (response) {
            if (response != 0) {
                document.getElementById("c-" + response).checked = true;
                document.getElementById("questionchoiceid").innerText = response;
            }
        },
        error: function (response) {
        }
    });

});
