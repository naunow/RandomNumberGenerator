$(function () {
    var url = location.href;

    $('#number1Btn').click(function () {
        ajaxCalculate('#Number1');
    })

    $('#number2Btn').click(function () {
        ajaxCalculate('#Number2');
    })

    $('#number3Btn').click(function () {
        ajaxCalculate('#Number3');
    })

    $('#number4Btn').click(function () {
        ajaxCalculate('#Number4');
    })

    $('#resetBtn').click(function () {
        $.ajax({
            type: "GET",
            url: `${url}/Home/Reset`,
            dataType: 'json'
        }).done(function (random) {
            $('#Number1').val(random.Number1);
            $('#Number2').val(random.Number2);
            $('#Number3').val(random.Number3);
            $('#Number4').val(random.Number4);
            $('#Target').val(random.Target);
            $('#Result').val(random.Result);

        }).always(function (data) {
            alertGameClear();
            // 数字ボタンを活性にする
            $('.addBtn').prop('disabled', '');

        })
    })

    /**
     * 結果に応じてResultの文字色を変える
     */
    function alertGameClear() {
        let resultVal = Number($('#Result').val());
        let targetVal = Number($('#Target').val());

        if (resultVal < targetVal) {
            // 文字色を黒にする
            $('#Result').addClass("black");
            $('#Result').removeClass("red");
            $('#Result').removeClass("blue");
        }
        if (resultVal > targetVal) {
            // 文字色を赤にする
            $('#Result').addClass("red");
            $('#Result').removeClass("black");
            $('#Result').removeClass("blue");

            // 数字ボタンを非活性にする
            $('.addBtn').prop('disabled', 'disabled');

            // 失敗した回数をカウント
            let fail = Number($('#fail').text());
            $('#fail').text(fail + 1);

        }
        if (resultVal == targetVal) {
            // 文字色を青にする
            $('#Result').addClass("blue");
            $('#Result').removeClass("red");
            $('#Result').removeClass("black");

            // 数字ボタンを非活性にする
            $('.addBtn').prop('disabled', 'disabled');

            // 成功した回数をカウント
            let success = Number($('#success').text());
            $('#success').text(success + 1);

        }
    }

    /**
     * クリックした数字をResultの数字と合計する
     * @param {string} inputSelector
     */
    function ajaxCalculate(inputSelector) {

        let number = $(inputSelector).val();
        let result = $('#Result').val();
        $.ajax({
            type: "GET",
            url: `${url}/Home/Cal`,
            data: { addend: number, result: result },
            dataType: 'json',
            contentType: 'application/json'
        }).done(function (jsonResult) {
            $(inputSelector).val(jsonResult.Number);
            $('#Result').val(jsonResult.Result);
            alertGameClear();
            
        })
    }

});
