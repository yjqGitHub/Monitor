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

//是否为字母或者数字
function IsLetterOrNum(obj) {
    var reg = "/^[A-Za-z0-9]+$/";
    return reg.test(obj);
}
//判断输入的字符是否为中文 cchar 
function IsChinese(obj) {
    obj = $.trim(obj);
    var reg = /^[\u0391-\uFFE5]+$/;
    return reg.test(str);
}

//判断输入的字符是否为中文 cchar或者null,空
function isChineseOrNull(obj) {
    return IsNull(obj) || IsChinese(obj);
}

//判断输入的字符是否为双精度 double
function IsDouble(obj) {
    var controlObj = $.trim(obj);
    if (IsNotNull(controlObj)) {
        reg = /^[-\+]?\d+(\.\d+)?$/;
        return reg.test(controlObj);
    }
    return false;
}

//判断输入的字符是否为双精度 double或者null,空
function IsDoubleOrNull(obj) {
    return IsNull(obj) || IsDouble(obj);
}

//验证是否小于等于n位数的字符串 nchar
function IsStrLenLessOrEqual(obj, n) {
    obj = $.trim(obj);
    if (obj.length == 0 || obj.length > n)
        return false;
    else
        return true;
}

//验证是否小于等于n位数的字符串 nchar或者null,空
function IsNullOrStrLenLessOrEqual(obj, n) {
    return IsNull(obj) || IsStrLenLessOrEqual(obj, n);
}

//验证是否大于等于n位数的字符串 nchar
function IsStrLenGreaterOrEqual(obj, n) {
    obj = $.trim(obj);
    if (obj.length == 0 || obj.length < n)
        return false;
    else
        return true;
}

//验证是否大于等于n位数的字符串 nchar或者null,空
function IsNullOrStrLenGreaterOrEqual(obj, n) {
    return IsNull(obj) || IsStrLenGreaterOrEqual(obj, n);
}

//验证长度是否位于最大与最小之间的字符串 nchar
function StrLenBetween(obj, min, max) {
    obj = $.trim(obj);
    return obj.length >= min && obj.length <= max;
}

//验证长度是否位于最大与最小之间的字符串 nchar或者为空
function IsNullOrStrLenBetween(obj, min, max) {
    return IsNull(obj) || StrLenBetween(obj, min, max);
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
    var breakFlag = false;
    $(obj).find("[data-check=1]").each(function () {
        if (breakFlag) {
            return;
        }
        if ($(this).data("expression") != undefined) {
            var expressions = $.trim($(this).data("expression"));
            var currentValue = $(this).val();
            if (IsNotNull(expressions)) {
                var expressionArray = expressions.split(',');
                for (var i = 0; i < expressionArray.length; i++) {
                    if (breakFlag) {
                        break;
                    }
                    var expression = expressionArray[i];
                    if (IsNotNull(expression)) {
                        switch (expression) {
                            case "NotNull"://不能为空
                                if (!IsNotNull(currentValue)) {
                                    validateMsg = $(this).data("err") + "不能为空！";
                                    validateFlag = false;
                                    ChangeToErrorCss(this, validateMsg);
                                    breakFlag = true;
                                }
                                break;

                            case "StringLength"://长度必须位于两者之间
                                var minLenth = $(this).data("min") == undefined ? 1 : $(this).data("min");
                                var manLenth = $(this).data("max") == undefined ? 9999999999 : $(this).data("min");
                                if (!StrLenBetween(currentValue, minLenth, minLenth)) {
                                    validateMsg = $(this).data("err") + "长度必须位于" + minLenth + "-" + manLenth + "之间！";
                                    validateFlag = false;
                                    ChangeToErrorCss(this, validateMsg);
                                    breakFlag = true;
                                }
                                break;

                            case "NullOrStringLength"://空或者长度位于两者之间
                                var minLenth = $(this).data("min") == undefined ? 1 : $(this).data("min");
                                var manLenth = $(this).data("max") == undefined ? 9999999999 : $(this).data("min");
                                if (!IsNullOrStrLenBetween(currentValue, minLenth, minLenth)) {
                                    validateMsg = $(this).data("err") + "长度必须位于" + minLenth + "-" + manLenth + "之间！";
                                    validateFlag = false;
                                    ChangeToErrorCss(this, validateMsg);
                                    breakFlag = true;
                                }
                                break;


                            default: break;
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
    $('body').append('<table id="tipTable" class="tableTip" style="width:auto;z-index:99;"><tr><td  class="leftImage"></td> <td class="contenImage" align="left"></td> <td class="rightImage"></td></tr></table>');
    var X = $(obj).offset().top;
    var Y = $(obj).offset().left;
    $('#tipTable').css({ left: Y - 2 + 'px', top: X + 21 + 'px' });
    $('#tipTable').show()
    $('.contenImage').html(msg);
    $(obj).change(function () {
        if ($(obj).val() != "") {
            $(obj).removeClass("validateError");
            $(obj).addClass("validateSuccess");
            $('.tableTip').remove()
        }
    });
}