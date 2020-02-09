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
    })

    function alertGameClear() {
        if ($('#Result').val() < $('#Target').val()) {
            $('#Result').css('color', '#3e3e3e');
        }
        else if ($('#Result').val() > $('#Target').val()) {
            //alert('GAME OVER');
            //$('#Result').val(0);
            $('#Result').css('color', 'red');
        }
        else if ($('#Result').val() == $('#Target').val()) {
            //alert('CLEAR');
            //$('#Result').val(0);
            $('#Result').css('color', 'blue');

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
            
        }).fail(function (data) {
        }).always(function (data) {
        })
    }

});
