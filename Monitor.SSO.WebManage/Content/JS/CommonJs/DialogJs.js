var loadIndex = -9999;

/**
 * 显示出加载中图片
*/
function ShowLoading() {
    loadIndex = layer.load();
}
/**
 * 隐藏加载中图片
*/
function HideLoading() {
    layer.close(loadIndex);
    //$("#loading").hide();
}
/**
 * 隐藏或显示加载中图片
*/
function LoadingFunc(bool) {
    if (bool) {
        ShowLoading();
    } else {
        setTimeout(HidenLoading, 800);
    }
}

/**
 * 显示系统提示,需要点击确认按钮才能关闭
 * @param [String]   msg         提示内容
*/
function AlertMsg(msg) {
    layer.alert(msg);
}

/**
 * 显示提示,2S后自动关闭
 * @param [String]   msg         提示内容
*/
function ShowMsg(msg) {
    layer.msg(msg, {
        time: 2000 //2秒关闭（如果不配置，默认是3秒）
    });
}

/**
 * 显示错误提示,2S后自动关闭
 * @param [String]   msg         提示内容
*/
function ShowWarningMsg(msg) {
    layer.msg(msg, {
        icon: 5,
        time: 2000 //2秒关闭（如果不配置，默认是3秒）
    });
}

/**
 * 显示成功提示,2S后自动关闭
 * @param [String]   msg         提示内容
*/
function ShowSuccessMsg(msg) {
    layer.msg(msg, {
        icon: 1,
        time: 2000 //2秒关闭（如果不配置，默认是3秒）
    });
}

/**
 * 弹出确认提示框
 * @param [String]   msg         确认内容
 * @param [function]   confirmCallback 确认后要执行的方法
*/
function ShowConfirm(msg, confirmCallback) {
    layer.confirm(msg, { title: '提示' }, function (index) {
        //do something
        if (confirmCallback && confirmCallback != null) {
            confirmCallback();
        }
        layer.close(index);
    });
}

/*  关闭当前打开的页面
 */
function CloseCurrent() {
    var index = parent.layer.getFrameIndex(window.name); //先得到当前iframe层的索引
    parent.layer.close(index); //再执行关闭
}

/* 对指定元素绑定打开ifram方法
*/
function InitDailog(document) {
    $(document).click(function () {
        var t = this.title || this.name || null;
        var a = this.href || this.alt;
        top.OpenDailog(t,a);
        this.blur();
        return false;
    });
}

/*
	title	标题
	url		请求的url
*/
function OpenDailog(title,url) {
    if (title == null || title == '') {
        title = false;
    };
    if (url == null || url == '') {
        url = "404.html";
    };
    var param = ParseQuery(url);
    var w = param['w'];
    var h = param['h'];
    var id = param['frameid'];
    if (w == null || w == '') {
        w = 800;
    };
    if (h == null || h == '') {
        h = ($(window).height() - 50);
    };
    if (id == null) {
        id = '';
    }
    layer.open({
        type: 2,
        id:id,
        area: [w + 'px', h + 'px'],
        fix: true, //不固定
        maxmin: true,
        shade: 0.4,
        title: title,
        content: [url,'no'],
        move: false
    });
}

/* 将地址参数转为字典
 */
function ParseQuery(url) {
    var query = url.replace(/^[^\?]+\??/, '');
    var Params = {};
    if (!query) { return Params; }// return empty object
    var Pairs = query.split(/[;&]/);
    for (var i = 0; i < Pairs.length; i++) {
        var KeyVal = Pairs[i].split('=');
        if (!KeyVal || KeyVal.length != 2) { continue; }
        var key = unescape(KeyVal[0]);
        var val = unescape(KeyVal[1]);
        val = val.replace(/\+/g, ' ');
        Params[key] = val;
    }
    return Params;
}