//切换验证码
function ToggleCode(obj, codeurl) {
    $("#FCode").val("");
    $(obj).attr("src", codeurl + "?time=" + Math.random());
}

//表单提交
$("form").submit(function () {
    if (ValidateCheck("form")) {
        Ajax({
            url: "/Authority/Authority",
            type: "POST",
            data: $(this).serialize()
        }, function (data) {
            ShowSuccessMsg(data.Message);
            location.href = $("#BackUrl").val();
        }, function (error) {
        });
    }
    return false;
})