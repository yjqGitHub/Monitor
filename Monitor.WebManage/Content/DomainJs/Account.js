function ToggleCode(obj, codeurl) {
    $("#FCode").val("");
    $(obj).attr("src", codeurl + "?time=" + Math.random());
}