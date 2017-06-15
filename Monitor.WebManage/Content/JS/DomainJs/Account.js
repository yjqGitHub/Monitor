//切换验证码
function ToggleCode(obj, codeurl) {
    $("#FCode").val("");
    $(obj).attr("src", codeurl + "?time=" + Math.random());
}

//表单提交
$("form").submit(function () {
    ValidateCheck("form");
    return false;
})