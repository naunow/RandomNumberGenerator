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
        }).fail(function (data) {
        })
    }

});
