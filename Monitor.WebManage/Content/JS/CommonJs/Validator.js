//为空
function IsNull(obj) {
    obj = $.trim(obj);
    if (obj.length == 0 || obj == null || obj == undefined)
        return true;
    else
        return false;
}
//不能为空
function IsNotNull(obj) {
    return !(IsNull(obj));
}
//校验是否相等
function IsEqual(value1, value2) {
    value1 = $.trim(value1);
    value2 = $.trim(value2);
    if (value1 == value2) {
        return true;
    }
    else {
        return false;
    }
}



//校验表单元素是否通过
//obj 表示表单元素的容器
//data-check="1" 表示需要检验的元素
//data-err 表示提示内容
//data-min 表示最小值
//data-max 表示最大值
//data-expression 表示调用的校验格式,多个之间用逗号隔开
function ValidateCheck(obj) {
    var validateMsg = "", validateFlag = true;
    $(obj).find("[data-check]=1").each(function () {
        if ($(this).data("expression") != undefined) {
            var expressions = $.trim($(this).data("expression"));
            var currentValue=$(this).val();
            if (IsNotNull(expressions)) {
                var expressionArray = expressions.split(',');
                for (var i = 0; i < expressionArray.length; i++) {
                    var expression = expressionArray[i];
                    if (IsNotNull(expression)) {
                        switch (expression) {
                            case "NotNull"://不能为空
                                if (!IsNotNull(currentValue)) {
                                    validateMsg = $(this).attr("err") + "不能为空！";
                                    validateFlag = false;
                                    ChangeToErrorCss($(this), validateMsg);
                                }
                                break;
                        }
                    }
                }
            }
        }
    })
    if (!validateFlag) {
        //展示错误信息
    }
    return validateFlag;
}
//更改输入错误元素的样式
function ChangeToErrorCss(obj, msg) {
    $(obj).addClass("validateError");
    $(obj).focus();
    $('body').append('<table id="tipTable" class="tableTip"><tr><td  class="leftImage"></td> <td class="contenImage" align="left"></td> <td class="rightImage"></td></tr></table>');
    var X = $(obj).offset().top;
    var Y = $(obj).offset().left;
    $('#tipTable').css({ left: Y - 2 + 'px', top: X + 21 + 'px' });
    $('#tipTable').show()
    $('.contenImage').html(Validatemsg);
    $(obj).change(function () {
        if ($(obj).val() != "") {
            $(obj).removeClass("validateError");
            $(obj).addClass("validateSuccess");
            $('#tipTable').hide()
        }
    });
}