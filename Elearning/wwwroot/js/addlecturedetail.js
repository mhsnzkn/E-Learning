$('#ld_form').submit(function (e) {
    e.preventDefault();

    $.ajax({
        url: this.action,
        type: this.method,
        data: new FormData(this),
        cache: false,
        contentType: false,
        processData: false,
        success: function (res) {
            $('#ld_form')[0].reset();
            toastr.success("Ders Detayı eklendi");
        },
        error: function (xhr, error, status) {
            toastr.error("Bir hata oldu!");
        }
    });
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
            $('.close')[0].click();
            $('#video_form')[0].reset();
            $('#typeid').val(res);
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
            $('.close')[1].click();
            $('#question_form')[0].reset();
            $('#typeid').val(res);
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
            $('.close')[2].click();
            $('#article_form')[0].reset();
            $('#typeid').val(res);
            toastr.success("Makale eklendi");
        },
        error: function (xhr, error, status) {
            toastr.error("Bir hata oldu!");
        }
    });
})



$('#btn-add-question').click(function () {
    var countelm = $('#counter');
    var counter = parseInt(countelm.val());
    counter++;
    $('#div_question').append(`<hr><div class="row form-group">
                                <label for="example-tel-input" class="col-2 col-form-label text-right">Sıra</label>
                                <div class="col-10">
                                    <input class="form-control" type="number" name="row_`+ counter + `">
                                </div>
                            </div>
                            <div class="row form-group">
                                <label for="example-tel-input" class="col-2 col-form-label text-right">Cevap Metni</label>
                                <div class="col-10">
                                    <input class="form-control" type="text" name="text_`+ counter + `">
                                </div>
                            </div>
                            <div class="row form-group">
                                <label for="example-tel-input" class="col-2 col-form-label text-right">Doğru cevap</label>
                                <div class="col-10">
                                    <input class="form-control" type="radio" name="isCorrect"  value="`+ counter + `">
                                </div>
                            </div>`);
    countelm.val(counter);
})