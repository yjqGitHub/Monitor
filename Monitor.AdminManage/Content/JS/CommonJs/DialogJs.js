var loadIndex = -9999;

/**
 * 显示出加载中图片
*/
function ShowLoading() {
    loadIndex=layer.load();
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