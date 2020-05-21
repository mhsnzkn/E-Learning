
function next() {
    
    var ucdid = parseInt(document.getElementById("usercoursedetailid").innerText);
    var model = { usercoursedetailid:ucdid };
    //var result = false;

    $.ajax({
        url: '/api/Services/LectureDone',
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: JSON.stringify(model),
        success: function (response) {
            if (response == "0") {
                alert("Bir hata oluştu!");
                return false;
            }
        },
        error: function (response) {
            alert("Bir hata oluştu!!");
            return false;
        }
    });

    return true;

}