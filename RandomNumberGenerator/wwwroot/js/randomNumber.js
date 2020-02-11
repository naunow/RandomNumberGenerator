$(function () {

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
        $('#Result').val(0);
        alertGameClear();
    })

    /**
     * 結果に応じてResultの文字色を変える
     */
    function alertGameClear() {
        let resultVal = Number($('#Result').val());
        let targetVal = Number($('#Target').val());

        if (resultVal < targetVal) {

            $('#Result').addClass("black");
            $('#Result').removeClass("red");
            $('#Result').removeClass("blue");
        }
        else if (resultVal > targetVal) {
            $('#Result').addClass("red");
            $('#Result').removeClass("black");
            $('#Result').removeClass("blue");
        }
        else if (resultVal == targetVal) {
            $('#Result').addClass("blue");
            $('#Result').removeClass("red");
            $('#Result').removeClass("black");

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
            url: "./Home/Cal",
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
