$('#lectureform').submit(function (e) {
    e.preventDefault();

    $.ajax({
        url: this.action,
        type: this.method,
        data: new FormData(this),
        cache: false,
        contentType: false,
        processData: false,
        success: function (res) {
            if (res == "1") {
                toastr.success("Güncelleme yapıldı");
            } else {
                toastr.error("Güncelleme yapılamadı");
            }
        },
        error: function (xhr, error, status) {
            toastr.error("Bir hata oldu!");
        }
    });
})

$('#ins_form').submit(function (e) {
    e.preventDefault();

    $.ajax({
        url: this.action,
        type: this.method,
        data: new FormData(this),
        cache: false,
        contentType: false,
        processData: false,
        success: function (res) {
            $('.close')[0].click();
            $('#ins_form')[0].reset();
            $('#instructorid').val(res);
        },
        error: function (xhr, error, status) {
            toastr.error("Bir hata oldu!");
        }
    });
})

$('#btn-src-ins').click(function () {
     getins("");
})

function getins(param) {
    var model = { search: param };
    $.ajax({
        url: "/api/Services/GetIns",
        dataType: "json",
        data: model,
        success: function (res) {
            var txt = "";
            for (var i = 0; i < res.length; i++) {
                txt += `<tr>
                                <td>`+ res[i].id + `</td>
                                <td>`+ res[i].name + `</td>
                                <td><button class="btn btn-outline-secondary btn-choose-ins" data-id="`+ res[i].id + `">Seç</button></td>
                            </tr>`;
            }

            $('#list').html(txt);
        },
        error: function (res) {
            taostr.error("Bir hata oldu!");
        }
    })
}
$(document).on("click", ".btn-choose-ins", function () {
    var id = $(this).data("id");
    $('#instructorid').val(id);
    $('.close')[1].click();

})