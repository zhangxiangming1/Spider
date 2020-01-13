function setPage(options) {
    var containerID = options.containerID;
    var recordCount = options.recordCount;
    var pageSize = options.pageSize || 10;
    var pageIndex = options.pageIndex;
    var groupSize = options.groupSize || 10;
    var click = options.click;

    var pageCount = parseInt(recordCount / pageSize);
    if (recordCount % pageSize > 0) {
        pageCount++;
    }
    var groupCount = parseInt(pageCount / groupSize);
    if (pageCount % groupSize > 0) {
        groupCount++;
    }
    var groupIndex = parseInt(pageIndex / groupSize);
    if (pageIndex % groupSize > 0) {
        groupIndex++;
    }
    var html = "<span class='easy-page record-count'>共" + recordCount + "行</span>";
    html += "<span class='easy-page page-count'>共" + pageCount + "页</span>";
    if (pageIndex > 1) {
        html += "<span class='easy-page first-page'>首页</span>";
        html += "<span class='easy-page before-page'><</span>";
    }
    var startPage = (groupIndex - 1) * groupSize + 1;
    var endPage = startPage + groupSize - 1;
    if (endPage > pageCount) {
        endPage = pageCount;
    }
    for (var i = startPage; i <= endPage; i++) {
        if (i == pageIndex) {
            html += "<span class='easy-page page-index current-page'>" + i + "</span>";
        } else {
            html += "<span class='easy-page page-index'>" + i + "</span>";
        }
    }
    if (pageIndex < pageCount) {
        html += "<span class='easy-page after-page'>></span>";
        html += "<span class='easy-page end-page'>尾页</span>";
    }
    $(html).appendTo("#" + containerID);
    //数字页
    $("#" + containerID + " .page-index").click(function () {
        var index = parseInt($.trim($(this).text()));
        click(index);
    });
    //首页
    $("#" + containerID + " .first-page").click(function () {
        click(1);
    });
    //尾页
    $("#" + containerID + " .end-page").click(function () {
        click(pageCount);
    });
    //上一页
    $("#" + containerID + " .before-page").click(function () {
        var index = pageIndex - 1;
        if (index <= 0) {
            return;
        }
        click(index);
    });
    //下一页
    $("#" + containerID + " .after-page").click(function () {
        var index = pageIndex + 1;
        if (index >= pageCount) {
            return;
        }
        click(index);
    });
}