$('.ldetail_form').submit(function (e) {
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

$(document).on('submit', '.add_ldetail_form', function (e) {
    e.preventDefault();

    $.ajax({
        url: this.action,
        type: this.method,
        data: new FormData(this),
        cache: false,
        contentType: false,
        processData: false,
        success: function (res) {
            if (res) {
                toastr.success("Güncelleme yapıldı");
                $('.add_detail_warning').hide();

            } else {
                toastr.error("Güncelleme yapılamadı");
            }
        },
        error: function (xhr, error, status) {
            toastr.error("Bir hata oldu!");
        }
    });
})

$('.btn_delete').click(function () {

    var id = $(this).data("id");
    var form = $(this).closest("form");
    var model = { id: id };

    $.ajax({
        url: '/Admin/DeleteLectureDetail',
        type: 'get',
        data: model,
        success: function (res) {
            if (res == "1") {
                form.hide();
                toastr.success('Başarıyla silindi');
            } else {
                toastr.error('Silinemedi');
            }
        },
        error: function () {
            toastr.error('Bir hata oldu');
        }
    })
})

$('#video_form').submit(function (e) {
    e.preventDefault();

    $.ajax({
        url: this.action,
        type: this.method,
        data: new FormData(this),
        cache: false,
        contentType: false,
        processData: false,
        success: function (res) {
            $('#video_form')[0].reset();
            $('#videoid').val(res);
            toastr.success("Video eklendi");
        },
        error: function (xhr, error, status) {
            toastr.error("Bir hata oldu!");
        }
    });
})

$('#question_form').submit(function (e) {
    e.preventDefault();

    $.ajax({
        url: this.action,
        type: this.method,
        data: new FormData(this),
        cache: false,
        contentType: false,
        processData: false,
        success: function (res) {
            $('#question_form')[0].reset();
            $('#questionid').val(res);
            toastr.success("Soru eklendi");
        },
        error: function (xhr, error, status) {
            toastr.error("Bir hata oldu!");
        }
    });
})

$('#article_form').submit(function (e) {
    e.preventDefault();

    $.ajax({
        url: this.action,
        type: this.method,
        data: new FormData(this),
        cache: false,
        contentType: false,
        processData: false,
        success: function (res) {
            $('#article_form')[0].reset();
            $('#articleid').val(res);
            toastr.success("Makale eklendi");
        },
        error: function (xhr, error, status) {
            toastr.error("Bir hata oldu!");
        }
    });
})


$('#btn-add-ldetail').click(function () {

    $('#div_add').append(`<hr><span class="text-danger add_detail_warning">*Kaydedilmedi</span>
                            <form class="add_ldetail_form" action="/Admin/AddLectureDetail" method="post"> <div class="row form-group">
                            <input type="hidden" class="lecture_id" name="LectureId" value="" />
                            <label for="example-text-input" class="col-2 col-form-label text-right ">Tip</label>
                            <div class="col-10">
                                <select class="form-control" name="Type">
                                <option value="video">Video</option>
                                <option value="poll">Sınav Sorusu</option>
                                <option value="quiz">Quiz Sorusu</option>
                                <option value="pretest">Ön Test</option>
                                <option value="aftertest">Son Test</option>
                                <option value="article">Makale</option>
                            </select>
                            </div>
                        </div>
                        <div class="row form-group">
                            <label for="example-text-input" class="col-2 col-form-label text-right">Tip Id</label>
                            <div class="col-10">
                                <input class="form-control" name="TypeId" >
                            </div>
                        </div>
                        <div class="row form-group">
                            <label for="example-search-input" class="col-2 col-form-label text-right">Sıra</label>
                            <div class="col-10">
                                <input class="form-control" name="Row" >
                            </div>
                        </div>
                        <div class="d-flex justify-content-sm-end">
                            <button type="submit" class="btn btn-success m-1"><i class="fas fa-save"></i> Kaydet</button>
                        </div></form>`);

    $('.lecture_id').val($('#lectureid').val());
})